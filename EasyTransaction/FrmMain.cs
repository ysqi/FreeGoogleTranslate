using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        Uri googleCNURL = new Uri("http://translate.google.cn/");
        TranslateTool tool;
        BatchTran tran;
        public FrmMain()
        {
            InitializeComponent();
            tool = new TranslateTool(wb);
            tran = new BatchTran(tool);
            tran.BatchMessagePushed += Tran_BatchMessagePushed;
            IsReady(false);

        }

        private void Tran_BatchMessagePushed(MessageEventArgs args)
        {
            lblBatchResult.Invoke(new Action(() =>
            {
                lblBatchResult.Text = "翻译进度：" + args.Message;
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tool.Start();
        }
        private void wb_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            gpWeb.Text = wb.DocumentTitle;
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
            txtTestResult.Text = tool.Translate(text);
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
            if ((btnAction.Tag as string) == "runing")
            {
                tran.Stop();
                btnAction.Tag = "stoped";
                btnAction.Text = "开始";
            }
            else
            {
                if (openFileDialog1.FileName == null)
                {
                    MessageBox.Show("请先选择要翻译的文件");
                    return;
                }
                try
                {
                    tran.Start(openFileDialog1.FileName);
                    btnAction.Tag = "runing";
                    btnAction.Text = "停止";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
