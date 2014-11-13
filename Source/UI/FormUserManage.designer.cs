namespace UI
{
    partial class FormUserManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserManage));
            this.grpList = new System.Windows.Forms.GroupBox();
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMEMO = new System.Windows.Forms.RichTextBox();
            this.lbMEMO = new System.Windows.Forms.Label();
            this.cmbUSER_GROUP = new System.Windows.Forms.ComboBox();
            this.lbUSER_GROUP = new System.Windows.Forms.Label();
            this.txtUSER_WD = new System.Windows.Forms.TextBox();
            this.lbUSER_WD = new System.Windows.Forms.Label();
            this.txtUSER_ID = new System.Windows.Forms.TextBox();
            this.lbUSER_LOGIN_ID = new System.Windows.Forms.Label();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.grpUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpList
            // 
            this.grpList.Controls.Add(this.grdMain);
            this.grpList.Location = new System.Drawing.Point(10, 198);
            this.grpList.Name = "grpList";
            this.grpList.Size = new System.Drawing.Size(766, 362);
            this.grpList.TabIndex = 8;
            this.grpList.TabStop = false;
            this.grpList.Text = "一览";
            // 
            // grdMain
            // 
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMain.Location = new System.Drawing.Point(3, 17);
            this.grdMain.Name = "grdMain";
            this.grdMain.RowTemplate.Height = 21;
            this.grdMain.Size = new System.Drawing.Size(760, 342);
            this.grdMain.TabIndex = 8;
            this.grdMain.Click += new System.EventHandler(this.grdMain_Click);
            // 
            // grpUser
            // 
            this.grpUser.Controls.Add(this.btnExit);
            this.grpUser.Controls.Add(this.btnClear);
            this.grpUser.Controls.Add(this.btnDel);
            this.grpUser.Controls.Add(this.btnAdd);
            this.grpUser.Controls.Add(this.txtMEMO);
            this.grpUser.Controls.Add(this.lbMEMO);
            this.grpUser.Controls.Add(this.cmbUSER_GROUP);
            this.grpUser.Controls.Add(this.lbUSER_GROUP);
            this.grpUser.Controls.Add(this.txtUSER_WD);
            this.grpUser.Controls.Add(this.lbUSER_WD);
            this.grpUser.Controls.Add(this.txtUSER_ID);
            this.grpUser.Controls.Add(this.lbUSER_LOGIN_ID);
            this.grpUser.Location = new System.Drawing.Point(10, 70);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(768, 122);
            this.grpUser.TabIndex = 1;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "用户信息";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(671, 87);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 30);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "关闭";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(576, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 30);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDel.Location = new System.Drawing.Point(671, 55);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(91, 30);
            this.btnDel.TabIndex = 7;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAdd.Location = new System.Drawing.Point(576, 55);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 30);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "确定";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtMEMO
            // 
            this.txtMEMO.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMEMO.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMEMO.Location = new System.Drawing.Point(89, 55);
            this.txtMEMO.MaxLength = 128;
            this.txtMEMO.Name = "txtMEMO";
            this.txtMEMO.Size = new System.Drawing.Size(481, 62);
            this.txtMEMO.TabIndex = 4;
            this.txtMEMO.Text = "";
            // 
            // lbMEMO
            // 
            this.lbMEMO.AutoSize = true;
            this.lbMEMO.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMEMO.Location = new System.Drawing.Point(31, 55);
            this.lbMEMO.Name = "lbMEMO";
            this.lbMEMO.Size = new System.Drawing.Size(52, 21);
            this.lbMEMO.TabIndex = 30;
            this.lbMEMO.Text = "备  注";
            // 
            // cmbUSER_GROUP
            // 
            this.cmbUSER_GROUP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUSER_GROUP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbUSER_GROUP.FormattingEnabled = true;
            this.cmbUSER_GROUP.Items.AddRange(new object[] {
            "管理员",
            "高级用户",
            "一般用户"});
            this.cmbUSER_GROUP.Location = new System.Drawing.Point(407, 20);
            this.cmbUSER_GROUP.Name = "cmbUSER_GROUP";
            this.cmbUSER_GROUP.Size = new System.Drawing.Size(163, 29);
            this.cmbUSER_GROUP.TabIndex = 3;
            // 
            // lbUSER_GROUP
            // 
            this.lbUSER_GROUP.AutoSize = true;
            this.lbUSER_GROUP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUSER_GROUP.Location = new System.Drawing.Point(359, 25);
            this.lbUSER_GROUP.Name = "lbUSER_GROUP";
            this.lbUSER_GROUP.Size = new System.Drawing.Size(42, 21);
            this.lbUSER_GROUP.TabIndex = 22;
            this.lbUSER_GROUP.Text = "组别";
            // 
            // txtUSER_WD
            // 
            this.txtUSER_WD.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUSER_WD.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtUSER_WD.Location = new System.Drawing.Point(253, 20);
            this.txtUSER_WD.MaxLength = 20;
            this.txtUSER_WD.Name = "txtUSER_WD";
            this.txtUSER_WD.PasswordChar = '*';
            this.txtUSER_WD.Size = new System.Drawing.Size(100, 29);
            this.txtUSER_WD.TabIndex = 2;
            // 
            // lbUSER_WD
            // 
            this.lbUSER_WD.AutoSize = true;
            this.lbUSER_WD.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUSER_WD.Location = new System.Drawing.Point(210, 25);
            this.lbUSER_WD.Name = "lbUSER_WD";
            this.lbUSER_WD.Size = new System.Drawing.Size(42, 21);
            this.lbUSER_WD.TabIndex = 6;
            this.lbUSER_WD.Text = "密码";
            // 
            // txtUSER_ID
            // 
            this.txtUSER_ID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUSER_ID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUSER_ID.Location = new System.Drawing.Point(89, 21);
            this.txtUSER_ID.MaxLength = 20;
            this.txtUSER_ID.Name = "txtUSER_ID";
            this.txtUSER_ID.Size = new System.Drawing.Size(121, 29);
            this.txtUSER_ID.TabIndex = 1;
            // 
            // lbUSER_LOGIN_ID
            // 
            this.lbUSER_LOGIN_ID.AutoSize = true;
            this.lbUSER_LOGIN_ID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUSER_LOGIN_ID.Location = new System.Drawing.Point(25, 25);
            this.lbUSER_LOGIN_ID.Name = "lbUSER_LOGIN_ID";
            this.lbUSER_LOGIN_ID.Size = new System.Drawing.Size(58, 21);
            this.lbUSER_LOGIN_ID.TabIndex = 4;
            this.lbUSER_LOGIN_ID.Text = "用户名";
            // 
            // UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 575);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.grpUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserManage_FormClosed);
            this.Load += new System.EventHandler(this.UserManage_Load);
            this.Controls.SetChildIndex(this.grpUser, 0);
            this.Controls.SetChildIndex(this.grpList, 0);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.grpUser.ResumeLayout(false);
            this.grpUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView grdMain;
        private System.Windows.Forms.GroupBox grpUser;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox txtMEMO;
        private System.Windows.Forms.Label lbMEMO;
        private System.Windows.Forms.ComboBox cmbUSER_GROUP;
        private System.Windows.Forms.Label lbUSER_GROUP;
        private System.Windows.Forms.TextBox txtUSER_WD;
        private System.Windows.Forms.Label lbUSER_WD;
        private System.Windows.Forms.TextBox txtUSER_ID;
        private System.Windows.Forms.Label lbUSER_LOGIN_ID;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClear;
    }
}