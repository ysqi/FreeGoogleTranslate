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
            this.wb = new System.Windows.Forms.WebBrowser();
            this.gpWeb = new System.Windows.Forms.GroupBox();
            this.txtTestText = new System.Windows.Forms.TextBox();
            this.txtTestResult = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRunTest = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnAction = new System.Windows.Forms.Button();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.lblSavePath = new System.Windows.Forms.Label();
            this.lblBatchResult = new System.Windows.Forms.Label();
            this.gpWeb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(3, 17);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(835, 176);
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
            this.gpWeb.Controls.Add(this.wb);
            this.gpWeb.Location = new System.Drawing.Point(1, 2);
            this.gpWeb.Name = "gpWeb";
            this.gpWeb.Size = new System.Drawing.Size(841, 196);
            this.gpWeb.TabIndex = 1;
            this.gpWeb.TabStop = false;
            this.gpWeb.Text = "浏览：";
            // 
            // txtTestText
            // 
            this.txtTestText.Location = new System.Drawing.Point(9, 20);
            this.txtTestText.Multiline = true;
            this.txtTestText.Name = "txtTestText";
            this.txtTestText.Size = new System.Drawing.Size(136, 45);
            this.txtTestText.TabIndex = 2;
            this.txtTestText.Text = "输入文本测试";
            // 
            // txtTestResult
            // 
            this.txtTestResult.Location = new System.Drawing.Point(9, 71);
            this.txtTestResult.Multiline = true;
            this.txtTestResult.Name = "txtTestResult";
            this.txtTestResult.ReadOnly = true;
            this.txtTestResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTestResult.Size = new System.Drawing.Size(185, 83);
            this.txtTestResult.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnRunTest);
            this.groupBox1.Controls.Add(this.txtTestResult);
            this.groupBox1.Controls.Add(this.txtTestText);
            this.groupBox1.Location = new System.Drawing.Point(4, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 160);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自动翻译测试";
            // 
            // btnRunTest
            // 
            this.btnRunTest.Location = new System.Drawing.Point(151, 20);
            this.btnRunTest.Name = "btnRunTest";
            this.btnRunTest.Size = new System.Drawing.Size(43, 45);
            this.btnRunTest.TabIndex = 4;
            this.btnRunTest.Text = "测试";
            this.btnRunTest.UseVisualStyleBackColor = true;
            this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblBatchResult);
            this.groupBox2.Controls.Add(this.lblSavePath);
            this.groupBox2.Controls.Add(this.proBar);
            this.groupBox2.Controls.Add(this.btnAction);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblFileName);
            this.groupBox2.Controls.Add(this.btnSelectFile);
            this.groupBox2.Location = new System.Drawing.Point(245, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 154);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "批量翻译";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 53);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(65, 12);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "翻译文件：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "翻译间隔(ms):";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(402, 42);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 21);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(483, 15);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(81, 56);
            this.btnAction.TabIndex = 4;
            this.btnAction.Text = "开始";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // proBar
            // 
            this.proBar.Location = new System.Drawing.Point(6, 125);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(558, 23);
            this.proBar.TabIndex = 5;
            this.proBar.Value = 2;
            // 
            // lblSavePath
            // 
            this.lblSavePath.AutoSize = true;
            this.lblSavePath.Location = new System.Drawing.Point(6, 74);
            this.lblSavePath.Name = "lblSavePath";
            this.lblSavePath.Size = new System.Drawing.Size(65, 12);
            this.lblSavePath.TabIndex = 6;
            this.lblSavePath.Text = "存储地址：";
            // 
            // lblBatchResult
            // 
            this.lblBatchResult.AutoSize = true;
            this.lblBatchResult.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBatchResult.Location = new System.Drawing.Point(6, 101);
            this.lblBatchResult.Name = "lblBatchResult";
            this.lblBatchResult.Size = new System.Drawing.Size(70, 12);
            this.lblBatchResult.TabIndex = 7;
            this.lblBatchResult.Text = "翻译进度：";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 386);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpWeb);
            this.Name = "FrmMain";
            this.Text = "Google批量翻译小助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gpWeb.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wb;
        private System.Windows.Forms.GroupBox gpWeb;
        private System.Windows.Forms.TextBox txtTestText;
        private System.Windows.Forms.TextBox txtTestResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRunTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.ProgressBar proBar;
        private System.Windows.Forms.Label lblSavePath;
        private System.Windows.Forms.Label lblBatchResult;
    }
}

