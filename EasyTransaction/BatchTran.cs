using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace EasyTransaction
{

    delegate void BatchMessagePushHandle(MessageEventArgs args);

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
        /// 工作线程
        /// </summary>
        private Thread workThread;

        /// <summary>
        /// 翻译文件名
        /// </summary>
        private string srcFileName;

        /// <summary>
        /// 是否正在翻译中
        /// </summary>
        public bool IsRuning
        {
            get
            {
                return workThread != null && workThread.ThreadState != ThreadState.Aborted;
            }
        }

        public BatchTran(TranslateTool tool)
        {
            this.Tool = tool;
            this.Tool.Start();
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
            if (workThread !=null)
            {
                workThread.Abort(); 
            } 
            workThread = new Thread(new ThreadStart(WorkGo));
            srcFileName = fileName;
            workThread.Start();

        }
        public void Stop()
        {
            if (!IsRuning)
            {
                return;
            }
            workThread.Abort();
        }
        private void WorkGo()
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
            }
            catch (Exception ex)
            {
                pushMessage("读取翻译文件内容失败:" + ex.Message);
                return;
            }

            pushMessage("翻译任务完成");

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
            BatchMessagePushed(new MessageEventArgs(msg));
        }


    }
}
