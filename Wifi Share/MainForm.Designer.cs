namespace Wifi_Share
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPsw = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.sysLogs = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkStartPowerOn = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textPsw);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textName);
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 99);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "wifi设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "热点密码：";
            // 
            // textPsw
            // 
            this.textPsw.Location = new System.Drawing.Point(86, 60);
            this.textPsw.Name = "textPsw";
            this.textPsw.PasswordChar = '*';
            this.textPsw.Size = new System.Drawing.Size(75, 21);
            this.textPsw.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "热点名称：";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(86, 29);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(75, 21);
            this.textName.TabIndex = 7;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(184, 27);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "新建";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            this.btnCreate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(183, 58);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkStartPowerOn);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.sysLogs);
            this.groupBox2.Controls.Add(this.btnStart);
            this.groupBox2.Location = new System.Drawing.Point(12, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 197);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "wifi操作";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(183, 164);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnStop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            // 
            // sysLogs
            // 
            this.sysLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sysLogs.FormattingEnabled = true;
            this.sysLogs.ItemHeight = 12;
            this.sysLogs.Location = new System.Drawing.Point(6, 20);
            this.sysLogs.Name = "sysLogs";
            this.sysLogs.Size = new System.Drawing.Size(253, 136);
            this.sysLogs.TabIndex = 4;
            this.sysLogs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 164);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            // 
            // chkStartPowerOn
            // 
            this.chkStartPowerOn.AutoSize = true;
            this.chkStartPowerOn.Checked = true;
            this.chkStartPowerOn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartPowerOn.Location = new System.Drawing.Point(96, 168);
            this.chkStartPowerOn.Name = "chkStartPowerOn";
            this.chkStartPowerOn.Size = new System.Drawing.Size(72, 16);
            this.chkStartPowerOn.TabIndex = 5;
            this.chkStartPowerOn.Text = "开机启动";
            this.chkStartPowerOn.UseVisualStyleBackColor = true;
            this.chkStartPowerOn.CheckedChanged += new System.EventHandler(this.chkStartPowerOn_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 316);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 354);
            this.MinimumSize = new System.Drawing.Size(306, 354);
            this.Name = "MainForm";
            this.Text = "PC无线网共享";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPsw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListBox sysLogs;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkStartPowerOn;
    }
}

