using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace EasyTransaction
{

    delegate void BatchMessagePushHandle(MessageEventArgs args);
    delegate void BatchWorkItemsChangedHandle(WorkProcessEventArgs args);

    class WorkProcessEventArgs : EventArgs
    {
        /// <summary>
        /// 总处理数
        /// </summary>
        public int SumCount { get; set; }
        /// <summary>
        /// 累计完成量
        /// </summary>
        public int CompletedCount
        {
            get
            {
                return FailCount + SuccessCount;
            }
        }
        /// <summary>
        /// 成功数
        /// </summary>
        public int SuccessCount { get; set; }

        /// <summary>
        /// 翻译失败数量
        /// </summary>
        public int FailCount { get; set; }
        /// <summary>
        /// 本次事件消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 完成比例
        /// </summary>
        public double CompletionRatio
        {
            get
            {
                if (SumCount == 0)
                {
                    return 1.00;
                }
                return (double)CompletedCount / (double)SumCount;
            }
        }

    }
    class MessageEventArgs : EventArgs
    {
        public string Message
        {
            get;
            private set;
        }

        public MessageEventArgs(string msg)
        {
            this.Message = msg;
        }

    }



    /// <summary>
    /// 批量文件翻译
    /// </summary>
    class BatchTran
    {
        public event BatchMessagePushHandle BatchMessagePushed;
        public event BatchWorkItemsChangedHandle ProcessChanged;
        public event BatchWorkItemsChangedHandle Completed;
        /// <summary>
        /// 翻译间隔
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// 翻译结果文件保存地址
        /// </summary>
        public string SaveDir { get; set; }

        /// <summary>
        /// 翻译工具
        /// </summary>
        public TranslateTool Tool { get; set; }

        /// <summary>
        /// 翻译原始语言，默认为autho
        /// </summary>
        public string FromLanguage { get; set; }

        /// <summary>
        /// 翻译结果语言
        /// </summary>
        public string ToLanguage { get; set; }

        /// <summary>
        /// 工作线程
        /// </summary>
        private Thread workThread;

        /// <summary>
        /// 翻译文件名
        /// </summary>
        private string srcFileName;


        private Thread saveResultThread;
        private ConcurrentQueue<TrasnlateResult> resultQueue;

        /// <summary>
        /// 是否正在翻译中
        /// </summary>
        public bool IsRuning
        {
            get
            {
                return workThread != null && workThread.ThreadState != ThreadState.Running;
            }
        }

        public BatchTran(TranslateTool tool)
        {
            this.Tool = tool;
            this.Tool.Start();
            this.Interval = 500;
            this.FromLanguage = "auto";
            this.ToLanguage = "zh-CN";
            this.SaveDir = "./data/";
        }

        public void Start(string fileName)
        {
            if (IsRuning)
            {
                throw new Exception("翻译线程正在工作中");
            }
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException("文件不能为空");
            }
            if (workThread != null)
            {
                workThread.Abort();
            }
            if (workThread == null)
            {
                workThread = new Thread(new ThreadStart(WorkGo));
                workThread.IsBackground = true;
            }
            srcFileName = fileName;
            workThread.Start();

        }
        public void Stop()
        {
            if (!IsRuning)
            {
                return;
            }
            if (workThread != null)
            {
                workThread.Abort();
                workThread = null;
            }
            if (saveResultThread != null)
            {
                saveResultThread.Abort();
                saveResultThread = null;
            }
        }
        private void WorkGo()
        {
            int successCount = 0;
            int failCount = 0;
            int sumCount = 0;
            try
            {


                IList<string> dataRows;
                try
                {
                    dataRows = FileLib.ScanEnterFile(srcFileName);
                    if (dataRows == null)
                    {
                        pushMessage("翻译文件不存在");
                        return;
                    }
                    if (dataRows.Count == 0)
                    {
                        pushMessage("翻译文件内容为空，翻译停止");
                        return;
                    }
                    sumCount = dataRows.Count;
                    pushMessage(string.Format("翻译文件加载完成，待翻译行数:{0}", sumCount));
                }
                catch (Exception ex)
                {
                    pushMessage("读取翻译文件内容失败:" + ex.Message);
                    return;
                }

                processChange(sumCount, successCount, failCount, "开始行翻译...");

                try
                {
                    if (saveResultThread != null)
                    {
                        saveResultThread.Abort();
                    }
                    saveResultThread = new Thread(new ThreadStart(saveFileWork));
                    saveResultThread.IsBackground = true;
                    saveResultThread.Start();
                }
                catch (Exception ex)
                {
                    pushMessage("创建翻译结果存储文件失败:" + ex.Message);
                    return;
                }
                try
                {
                    foreach (var item in dataRows)
                    {
                        var text = item.Trim();
                        if (text == "")
                        {
                            successCount++;
                            continue;
                        }
                        if (Translate(text))
                        {
                            successCount++;
                        }
                        else
                        {
                            failCount++;
                        }
                        processChange(sumCount, successCount, failCount);
                        //休眠
                        Thread.Sleep(this.Interval);
                    }
                    //全部完成
                    processChange(sumCount, successCount, failCount);

                }
                catch (Exception ex)
                {
                    pushMessage(string.Format("翻译异常,{0},终止翻译。", ex.Message));
                }
                finally
                {
                    try
                    {
                        //释放资源
                        successResultWriter.Flush();
                        successResultWriter.Close();
                        failResultWriter.Flush();
                        failResultWriter.Close();
                    }
                    catch (Exception)
                    {
                        pushMessage("保存文件是否资源失败");
                    }
                }
            }
            finally
            {
                completed(sumCount, successCount, failCount);

                pushMessage("翻译任务结束");
            }
        }

        private string successFileName;
        private StreamWriter successResultWriter;
        private StreamWriter failResultWriter;
        public string GetSaveFileName()
        {
            if (successResultWriter == null)
            {
                return successFileName;
            }
            if (successResultWriter.BaseStream != null)
            {
                return (successResultWriter.BaseStream as FileStream).Name;
            }
            return successFileName;
        }
        private void initResultFile()
        {

            successFileName = Path.Combine(this.SaveDir, string.Format("{0}_success_{1:yyyMMddHHmmss}.xml", Path.GetFileNameWithoutExtension(this.srcFileName), DateTime.Now));
            var failFileName = Path.Combine(this.SaveDir, string.Format("{0}_fail_{1:yyyMMddHHmmss}.txt", Path.GetFileNameWithoutExtension(this.srcFileName), DateTime.Now));

            string dir = Path.GetDirectoryName(successFileName);
            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }
            this.successResultWriter = File.CreateText(successFileName);
            this.failResultWriter = File.CreateText(failFileName);

            successResultWriter.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            successResultWriter.AutoFlush = true;
            failResultWriter.AutoFlush = true;
        }


        private void saveFileWork()
        {
            initResultFile();
            resultQueue = new ConcurrentQueue<TrasnlateResult>();
            do
            {
                //翻译工作已完成，且队列中无记录时退出
                if (!IsRuning && resultQueue.Count == 0)
                {
                    break;
                }
                TrasnlateResult result;
                if (!resultQueue.TryDequeue(out result))
                {
                    Thread.Sleep(500);
                    continue;
                }
                try
                {
                    saveTranslateResult(result);
                }
                catch (Exception ex)
                {
                    pushMessage(string.Format("保存翻译行[{0}]结果[{1}]失败,{2}", result.Text, result.Result, ex.Message));
                }
            } while (true);
        }

        private void saveTranslateResult(TrasnlateResult result)
        {

            if (result.IsSuccess)
            {
                successResultWriter.WriteLine("<item>");
                successResultWriter.WriteLine("<hw>" + result.Text + "<hw>");
                successResultWriter.WriteLine("<tr>");
                successResultWriter.WriteLine(result.Result);
                successResultWriter.WriteLine("</tr></item>");
            }
            else
            {
                failResultWriter.WriteLine(result.Text);
            }

        }

        /// <summary>
        /// 翻译文本
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool Translate(string text)
        {
            bool isOk = false;
            int tryCount = 0;
            int sleepTime = 0;

            try
            {
                do
                {
                    if (tryCount > 0)
                    {
                        sleepTime += tryCount * 1000;
                        Thread.Sleep(sleepTime);
                    }
                    tryCount++;
                    var result = Tool.Translate(text, FromLanguage, ToLanguage);
                    if (result.IsSuccess)
                    {
                        saveTranslateResult(result);
                        isOk = true;
                        break;
                    }
                    if (tryCount > 3)
                    {
                        pushMessage(string.Format("翻译{0}失败，{1}", text, result.ErrorMessage));
                        result.ErrorMessage += ",已尝试3次，依旧失败";
                        saveTranslateResult(result);
                        break;
                    }


                } while (true);

            }
            catch (Exception)
            {
                isOk = false;
            }
            return isOk;
        }
        private void processChange(int sumCount, int completedCount, int failCount, string message = "")
        {
            if (ProcessChanged == null)
            {
                return;
            }
            var args = new WorkProcessEventArgs()
            {
                SumCount = sumCount,
                SuccessCount = completedCount,
                FailCount = failCount,
                Message = message,
            };
            var d = this.ProcessChanged.GetInvocationList();
            foreach (BatchWorkItemsChangedHandle item in d)
            {
                item.BeginInvoke(args, null, null);
            }

        }
        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="msg"></param>
        private void pushMessage(string msg)
        {
            if (BatchMessagePushed == null)
            {
                return;
            }
            var d = this.BatchMessagePushed.GetInvocationList();
            var args = new MessageEventArgs(msg);
            foreach (BatchMessagePushHandle item in d)
            {
                item.BeginInvoke(args, null, null);
            }
        }

        private void completed(int sumCount, int successCount, int failCount)
        {
            if (Completed == null)
            {
                return;
            }
            var args = new WorkProcessEventArgs()
            {
                SumCount = sumCount,
                SuccessCount = successCount,
                FailCount = failCount,
            };

            var d = this.Completed.GetInvocationList();
            foreach (BatchWorkItemsChangedHandle item in d)
            {
                item.BeginInvoke(args, null, null);
            }

        }

    }
}
