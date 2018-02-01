namespace MyQQ
{
    partial class Frm_login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_login));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.linklblReg = new System.Windows.Forms.LinkLabel();
            this.cboxAutoLogin = new System.Windows.Forms.CheckBox();
            this.cboxRemember = new System.Windows.Forms.CheckBox();
            this.pboxMin = new System.Windows.Forms.PictureBox();
            this.pboxClose = new System.Windows.Forms.PictureBox();
            this.pboxLogin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Location = new System.Drawing.Point(135, 200);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(191, 14);
            this.txtID.TabIndex = 1;
            this.txtID.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPwd.Location = new System.Drawing.Point(135, 231);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(191, 14);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPwd_KeyPress);
            // 
            // linklblReg
            // 
            this.linklblReg.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.linklblReg.AutoSize = true;
            this.linklblReg.BackColor = System.Drawing.Color.Transparent;
            this.linklblReg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklblReg.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linklblReg.LinkColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.linklblReg.Location = new System.Drawing.Point(344, 216);
            this.linklblReg.Name = "linklblReg";
            this.linklblReg.Size = new System.Drawing.Size(53, 12);
            this.linklblReg.TabIndex = 3;
            this.linklblReg.TabStop = true;
            this.linklblReg.Text = "申请账号";
            this.linklblReg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cboxAutoLogin
            // 
            this.cboxAutoLogin.AutoSize = true;
            this.cboxAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.cboxAutoLogin.Location = new System.Drawing.Point(254, 251);
            this.cboxAutoLogin.Name = "cboxAutoLogin";
            this.cboxAutoLogin.Size = new System.Drawing.Size(72, 16);
            this.cboxAutoLogin.TabIndex = 4;
            this.cboxAutoLogin.Text = "自动登录";
            this.cboxAutoLogin.UseVisualStyleBackColor = false;
            // 
            // cboxRemember
            // 
            this.cboxRemember.AutoSize = true;
            this.cboxRemember.BackColor = System.Drawing.Color.Transparent;
            this.cboxRemember.Location = new System.Drawing.Point(135, 251);
            this.cboxRemember.Name = "cboxRemember";
            this.cboxRemember.Size = new System.Drawing.Size(72, 16);
            this.cboxRemember.TabIndex = 4;
            this.cboxRemember.Text = "记住密码";
            this.cboxRemember.UseVisualStyleBackColor = false;
            this.cboxRemember.CheckedChanged += new System.EventHandler(this.cboxRemember_CheckedChanged);
            // 
            // pboxMin
            // 
            this.pboxMin.BackColor = System.Drawing.Color.Transparent;
            this.pboxMin.Location = new System.Drawing.Point(368, 6);
            this.pboxMin.Name = "pboxMin";
            this.pboxMin.Size = new System.Drawing.Size(24, 25);
            this.pboxMin.TabIndex = 5;
            this.pboxMin.TabStop = false;
            this.pboxMin.Click += new System.EventHandler(this.pboxMin_Click);
            // 
            // pboxClose
            // 
            this.pboxClose.BackColor = System.Drawing.Color.Transparent;
            this.pboxClose.Location = new System.Drawing.Point(403, 6);
            this.pboxClose.Name = "pboxClose";
            this.pboxClose.Size = new System.Drawing.Size(24, 25);
            this.pboxClose.TabIndex = 5;
            this.pboxClose.TabStop = false;
            this.pboxClose.Click += new System.EventHandler(this.pboxClose_Click);
            // 
            // pboxLogin
            // 
            this.pboxLogin.BackColor = System.Drawing.Color.Transparent;
            this.pboxLogin.Location = new System.Drawing.Point(135, 286);
            this.pboxLogin.Name = "pboxLogin";
            this.pboxLogin.Size = new System.Drawing.Size(191, 33);
            this.pboxLogin.TabIndex = 6;
            this.pboxLogin.TabStop = false;
            this.pboxLogin.Click += new System.EventHandler(this.pboxLogin_Click);
            // 
            // Frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(432, 331);
            this.Controls.Add(this.pboxLogin);
            this.Controls.Add(this.pboxClose);
            this.Controls.Add(this.pboxMin);
            this.Controls.Add(this.cboxRemember);
            this.Controls.Add(this.cboxAutoLogin);
            this.Controls.Add(this.linklblReg);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.Frm_login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.LinkLabel linklblReg;
        private System.Windows.Forms.CheckBox cboxAutoLogin;
        private System.Windows.Forms.CheckBox cboxRemember;
        private System.Windows.Forms.PictureBox pboxMin;
        private System.Windows.Forms.PictureBox pboxClose;
        private System.Windows.Forms.PictureBox pboxLogin;
    }
}

