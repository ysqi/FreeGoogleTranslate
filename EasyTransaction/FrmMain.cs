using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace EasyTransaction
{
    public partial class FrmMain : Form
    {
        TranslateTool tool;
        BatchTran tran;
        Stopwatch workTimeWatch;

        public FrmMain()
        {
            InitializeComponent();
            tool = new TranslateTool(wb, "http://translate.google.cn");
            tran = new BatchTran(tool)
            {
                FromLanguage = "en",
                ToLanguage = "zh-Cn",
            };
            tran.BatchMessagePushed += Tran_BatchMessagePushed;
            tran.ProcessChanged += Tran_ProcessChanged;
            tran.Completed += Tran_Completed;
            IsReady(false);
            txtResult.MaxLength = int.MaxValue;
            statusStrip1.Visible = false;
            lblProcess.Text = "";

        }

        private void Tran_Completed(WorkProcessEventArgs args)
        {
            this.Invoke(new Action(() =>
            {
                DoWork(false);
            }));
        }

        /// <summary>
        /// 翻译进度变化
        /// </summary>
        /// <param name="args"></param>
        private void Tran_ProcessChanged(WorkProcessEventArgs args)
        {
            if (workTimeWatch == null)
            {
                workTimeWatch = new Stopwatch();
                workTimeWatch.Start();
            }
            if (args.SumCount == (args.CompletedCount + args.FailCount))
            {
                workTimeWatch.Stop();
            }
            else if (args.CompletedCount == 0 && args.FailCount == 0)
            {
                workTimeWatch.Restart();
            }
            this.Invoke(new Action(() =>
            {
                toolProBar.Minimum = 0;
                toolProBar.Maximum = args.SumCount;
                toolProBar.Value = args.CompletedCount;
                lblProcess.Text = string.Format("{0:P0}", args.CompletionRatio);
                var info = string.Format("翻译进度：已完成{0:P2},{1:N0}/{2:N0},失败数:{3}.", args.CompletionRatio, args.CompletedCount, args.SumCount, args.FailCount);
                if (args.CompletedCount > 0)
                {
                    info += string.Format("速度:{0:N2}ms/行.", workTimeWatch.ElapsedMilliseconds / args.CompletedCount);
                }
                if (!string.IsNullOrWhiteSpace(args.Message))
                {
                    info += "消息:" + args.Message;
                }
                toolLableStatus.Text = info;

                lkSaveFile.Text = "Open:" + Path.GetFileName(tran.GetSaveFileName());
            }));
        }

        /// <summary>
        /// 翻译出来消息接收
        /// </summary>
        /// <param name="args"></param>
        private void Tran_BatchMessagePushed(MessageEventArgs args)
        {
            this.Invoke(new Action(() =>
            {
                showLog(args.Message);
            }));
        }
        /// <summary>
        /// 显示进度信息
        /// </summary>
        /// <param name="msg"></param>
        private void showLog(string msg)
        {
            txtResult.AppendText(string.Format("{0:HH:mm:ss}:{1}\r\n", DateTime.Now, msg));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tool.Start();
        }
        private void wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            gpWeb.Text = wb.DocumentTitle;
            showLog("页面地址：" + wb.Document.Url.ToString());
            if (txtUrl.Focused == false)
            {
                txtUrl.Text = wb.Document.Url.ToString();
            }
        }
        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            IsReady(true);
        }
        private void IsReady(bool yes)
        {
            if (yes)
            {
                btnRunTest.Enabled = true;
                btnRunTest.Text = "测试";
            }
            else
            {
                btnRunTest.Enabled = false;
                btnRunTest.Text = "稍等";
            }
        }
        private void btnRunTest_Click(object sender, EventArgs e)
        {
            var text = txtTestText.Text.Trim();
            var result = tool.Translate(text, txtFromLan.Text.Trim(), txtToLan.Text.Trim());
            showLog(string.Format("测试结果：\r\n 成功:{0}\r\n,结果:{1}\r\n 错误信息:{2} ", result.IsSuccess, result.Result, result.ErrorMessage));
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt";
            if (DialogResult.OK != openFileDialog1.ShowDialog())
            {
                return;
            }
            lblFileName.Text = "翻译文件：" + Path.GetFileName(openFileDialog1.FileName);
            lblSavePath.Text = "结果存储：";
            //openFileDialog1.FileName
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            DoWork((btnAction.Tag as string) != "runing");
        }

        private void DoWork(bool needStart)
        {
            if (!needStart)
            {
                tran.Stop();
                btnAction.Tag = "stoped";
                btnAction.Text = "开始";
                statusStrip1.Visible = true;
                btnSelectFile.Enabled = true;
                txtFromLan.Enabled = true;
                txtToLan.Enabled = true;
            }
            else
            {

                try
                {
                    var file = openFileDialog1.FileName;
                    if (string.IsNullOrWhiteSpace(file))
                    {
                        MessageBox.Show("请先选择要翻译的文件");
                        return;
                    }
                    else if (!File.Exists(file))
                    {
                        MessageBox.Show("待翻译文件不存在");
                        return;
                    }

                    tran.FromLanguage = txtFromLan.Text.Trim();
                    tran.ToLanguage = txtToLan.Text.Trim();
                    tran.Interval = (int)numTranslateInv.Value;
                    tran.Start(file);
                    btnAction.Tag = "runing";
                    btnAction.Text = "停止";
                    statusStrip1.Visible = true;
                    lblProcess.Text = "0.00%";
                    btnSelectFile.Enabled = false;
                    lblProcess.Visible = true;
                    txtFromLan.Enabled = false;
                    txtToLan.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void numTranslateInv_ValueChanged(object sender, EventArgs e)
        {
            this.tran.Interval = (int)numTranslateInv.Value;
        }

        private void lkSaveFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filename = tran.GetSaveFileName();
            if (string.IsNullOrWhiteSpace(filename))
            {
                return;
            }
            try
            {

                Process.Start(Path.GetFullPath(filename));
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开文件失败," + ex.Message);
            }
        }


        private void txtResultSaveDir_Leave(object sender, EventArgs e)
        {
            if (checkSavePath())
            {
                tran.SaveDir = txtResultSaveDir.Text.Trim();
            }
            else
            {
                txtResultSaveDir.Focus();
                txtResultSaveDir.SelectAll();
            }
        }

        /// <summary>
        /// 检测存储位置是否存在
        /// </summary>
        private bool checkSavePath()
        {
            var dir = txtResultSaveDir.Text.Trim();
            if (Directory.Exists(dir))
            {
                return true;
            }
            if (DialogResult.No == MessageBox.Show("翻译结果存储目录不存在，是否自动创建", "提示", MessageBoxButtons.YesNo))
            {
                return false;
            }
            try
            {
                Directory.CreateDirectory(dir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建目录失败," + ex.Message + "，可手工新建目录");
                return false;
            }

            return true;
        }

        private void btnChangeURL_Click(object sender, EventArgs e)
        {
            var url = txtUrl.Text.Trim();
            if (url == "")
            {
                return;
            }
            if (!url.StartsWith("https://") && !url.StartsWith("http://"))
            {
                url = "http://" + url;
            }
            try
            {
                var u = new Uri(url);
                tool.GoogleTranslateWeb = u;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
