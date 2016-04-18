namespace EasyTransaction
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.wb = new System.Windows.Forms.WebBrowser();
            this.gpWeb = new System.Windows.Forms.GroupBox();
            this.txtTestText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRunTest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtResultSaveDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProcess = new System.Windows.Forms.Label();
            this.txtToLan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFromLan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lkSaveFile = new System.Windows.Forms.LinkLabel();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.numTranslateInv = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolProBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolLableStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChangeURL = new System.Windows.Forms.Button();
            this.gpWeb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslateInv)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(3, 17);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.ScriptErrorsSuppressed = true;
            this.wb.Size = new System.Drawing.Size(835, 100);
            this.wb.TabIndex = 0;
            this.wb.Url = new System.Uri("", System.UriKind.Relative);
            this.wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            this.wb.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wb_Navigated);
            // 
            // gpWeb
            // 
            this.gpWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpWeb.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.gpWeb.Controls.Add(this.panel1);
            this.gpWeb.Controls.Add(this.wb);
            this.gpWeb.Location = new System.Drawing.Point(1, 2);
            this.gpWeb.Name = "gpWeb";
            this.gpWeb.Size = new System.Drawing.Size(841, 120);
            this.gpWeb.TabIndex = 1;
            this.gpWeb.TabStop = false;
            this.gpWeb.Text = "浏览：";
            // 
            // txtTestText
            // 
            this.txtTestText.Location = new System.Drawing.Point(9, 20);
            this.txtTestText.Multiline = true;
            this.txtTestText.Name = "txtTestText";
            this.txtTestText.Size = new System.Drawing.Size(259, 46);
            this.txtTestText.TabIndex = 2;
            this.txtTestText.Text = "Hello World!";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnRunTest);
            this.groupBox1.Controls.Add(this.txtTestText);
            this.groupBox1.Location = new System.Drawing.Point(4, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 74);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自动翻译测试";
            // 
            // btnRunTest
            // 
            this.btnRunTest.Location = new System.Drawing.Point(287, 20);
            this.btnRunTest.Name = "btnRunTest";
            this.btnRunTest.Size = new System.Drawing.Size(81, 46);
            this.btnRunTest.TabIndex = 4;
            this.btnRunTest.Text = "测试";
            this.btnRunTest.UseVisualStyleBackColor = true;
            this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.txtResultSaveDir);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblProcess);
            this.groupBox2.Controls.Add(this.txtToLan);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtFromLan);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lkSaveFile);
            this.groupBox2.Controls.Add(this.lblSavePath);
            this.groupBox2.Controls.Add(this.btnAction);
            this.groupBox2.Controls.Add(this.numTranslateInv);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblFileName);
            this.groupBox2.Controls.Add(this.btnSelectFile);
            this.groupBox2.Location = new System.Drawing.Point(4, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 153);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "批量翻译";
            // 
            // txtResultSaveDir
            // 
            this.txtResultSaveDir.Location = new System.Drawing.Point(110, 78);
            this.txtResultSaveDir.Name = "txtResultSaveDir";
            this.txtResultSaveDir.Size = new System.Drawing.Size(157, 21);
            this.txtResultSaveDir.TabIndex = 14;
            this.txtResultSaveDir.Text = "./data/";
            this.txtResultSaveDir.Leave += new System.EventHandler(this.txtResultSaveDir_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "结果存储位置：";
            // 
            // lblProcess
            // 
            this.lblProcess.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProcess.ForeColor = System.Drawing.Color.Green;
            this.lblProcess.Location = new System.Drawing.Point(261, 81);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(107, 66);
            this.lblProcess.TabIndex = 7;
            this.lblProcess.Text = "100%";
            this.lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtToLan
            // 
            this.txtToLan.Location = new System.Drawing.Point(220, 48);
            this.txtToLan.Name = "txtToLan";
            this.txtToLan.Size = new System.Drawing.Size(47, 21);
            this.txtToLan.TabIndex = 12;
            this.txtToLan.Text = "zh-CN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "目标语言：";
            // 
            // txtFromLan
            // 
            this.txtFromLan.Location = new System.Drawing.Point(110, 48);
            this.txtFromLan.Name = "txtFromLan";
            this.txtFromLan.Size = new System.Drawing.Size(47, 21);
            this.txtFromLan.TabIndex = 10;
            this.txtFromLan.Text = "en";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "文件语言：";
            // 
            // lkSaveFile
            // 
            this.lkSaveFile.AutoSize = true;
            this.lkSaveFile.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lkSaveFile.Location = new System.Drawing.Point(73, 133);
            this.lkSaveFile.Name = "lkSaveFile";
            this.lkSaveFile.Size = new System.Drawing.Size(35, 12);
            this.lkSaveFile.TabIndex = 8;
            this.lkSaveFile.TabStop = true;
            this.lkSaveFile.Text = "Open:";
            this.lkSaveFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkSaveFile_LinkClicked);
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(6, 133);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(65, 12);
            this.lblSavePath.TabIndex = 6;
            this.lblSavePath.Text = "存储地址：";
            // 
            // btnAction
            // 
            this.btnAction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAction.Location = new System.Drawing.Point(287, 14);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(81, 46);
            this.btnAction.TabIndex = 4;
            this.btnAction.Text = "开始";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // numTranslateInv
            // 
            this.numTranslateInv.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numTranslateInv.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTranslateInv.Location = new System.Drawing.Point(193, 19);
            this.numTranslateInv.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTranslateInv.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numTranslateInv.Name = "numTranslateInv";
            this.numTranslateInv.Size = new System.Drawing.Size(75, 21);
            this.numTranslateInv.TabIndex = 3;
            this.numTranslateInv.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numTranslateInv.ValueChanged += new System.EventHandler(this.numTranslateInv_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "翻译间隔(ms)：";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(7, 109);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(65, 12);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "翻译文件：";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(6, 18);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(88, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "选择翻译文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolProBar,
            this.toolLableStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(854, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolProBar
            // 
            this.toolProBar.Name = "toolProBar";
            this.toolProBar.Size = new System.Drawing.Size(525, 16);
            // 
            // toolLableStatus
            // 
            this.toolLableStatus.Name = "toolLableStatus";
            this.toolLableStatus.Size = new System.Drawing.Size(68, 17);
            this.toolLableStatus.Text = "翻译进度：";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtResult);
            this.groupBox3.Location = new System.Drawing.Point(393, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(446, 233);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志";
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 17);
            this.txtResult.MaxLength = 327670000;
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(440, 213);
            this.txtResult.TabIndex = 0;
            this.txtResult.Text = "===========操作====================\r\n1. 打开程序后，可以手工进行几次翻译，降低封IP概率\r\n2. 开始批量翻译前，可进行一次【" +
    "测试】，检测自动翻译是否正常\r\n3. 在批量翻译过程中，尽量不要操作上面页面，防止自动翻译获取Token失败\r\n========================" +
    "==========\r\n";
            // 
            // txtUrl
            // 
            this.txtUrl.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUrl.Location = new System.Drawing.Point(0, 0);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(236, 21);
            this.txtUrl.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnChangeURL);
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Location = new System.Drawing.Point(602, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 44);
            this.panel1.TabIndex = 2;
            // 
            // btnChangeURL
            // 
            this.btnChangeURL.Location = new System.Drawing.Point(129, 19);
            this.btnChangeURL.Name = "btnChangeURL";
            this.btnChangeURL.Size = new System.Drawing.Size(106, 26);
            this.btnChangeURL.TabIndex = 2;
            this.btnChangeURL.Text = "修改翻译网址";
            this.btnChangeURL.UseVisualStyleBackColor = true;
            this.btnChangeURL.Click += new System.EventHandler(this.btnChangeURL_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 386);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpWeb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Google批量翻译小助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gpWeb.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTranslateInv)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.GroupBox gpWeb;
        private System.Windows.Forms.TextBox txtTestText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRunTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numTranslateInv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolProBar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ToolStripStatusLabel toolLableStatus;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.LinkLabel lkSaveFile;
        private System.Windows.Forms.TextBox txtToLan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFromLan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResultSaveDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChangeURL;
        private System.Windows.Forms.TextBox txtUrl;
    }
}

