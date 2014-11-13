namespace UI
{
    partial class FormDepartmentManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDepartmentManage));
            this.grpList = new System.Windows.Forms.GroupBox();
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.grpUser = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtMEMO = new System.Windows.Forms.RichTextBox();
            this.lbMEMO = new System.Windows.Forms.Label();
            this.txtDepartmentID = new System.Windows.Forms.TextBox();
            this.txtDepartName = new System.Windows.Forms.TextBox();
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
            this.grpUser.Controls.Add(this.label2);
            this.grpUser.Controls.Add(this.label1);
            this.grpUser.Controls.Add(this.btnClear);
            this.grpUser.Controls.Add(this.btnDel);
            this.grpUser.Controls.Add(this.btnAdd);
            this.grpUser.Controls.Add(this.txtMEMO);
            this.grpUser.Controls.Add(this.lbMEMO);
            this.grpUser.Controls.Add(this.txtDepartmentID);
            this.grpUser.Controls.Add(this.txtDepartName);
            this.grpUser.Controls.Add(this.lbUSER_LOGIN_ID);
            this.grpUser.Location = new System.Drawing.Point(10, 70);
            this.grpUser.Name = "grpUser";
            this.grpUser.Size = new System.Drawing.Size(768, 122);
            this.grpUser.TabIndex = 1;
            this.grpUser.TabStop = false;
            this.grpUser.Text = "部门信息";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(659, 84);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 30);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "关闭";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(445, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 32;
            this.label2.Text = "编号自动生成";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(266, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 31;
            this.label1.Text = "部门编号";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Location = new System.Drawing.Point(562, 15);
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
            this.btnDel.Location = new System.Drawing.Point(659, 50);
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
            this.btnAdd.Location = new System.Drawing.Point(562, 50);
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
            this.txtMEMO.Location = new System.Drawing.Point(94, 49);
            this.txtMEMO.MaxLength = 128;
            this.txtMEMO.Name = "txtMEMO";
            this.txtMEMO.Size = new System.Drawing.Size(450, 62);
            this.txtMEMO.TabIndex = 4;
            this.txtMEMO.Text = "";
            // 
            // lbMEMO
            // 
            this.lbMEMO.AutoSize = true;
            this.lbMEMO.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMEMO.Location = new System.Drawing.Point(36, 49);
            this.lbMEMO.Name = "lbMEMO";
            this.lbMEMO.Size = new System.Drawing.Size(52, 21);
            this.lbMEMO.TabIndex = 30;
            this.lbMEMO.Text = "备  注";
            // 
            // txtDepartmentID
            // 
            this.txtDepartmentID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDepartmentID.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtDepartmentID.Location = new System.Drawing.Point(346, 16);
            this.txtDepartmentID.MaxLength = 20;
            this.txtDepartmentID.Name = "txtDepartmentID";
            this.txtDepartmentID.ReadOnly = true;
            this.txtDepartmentID.Size = new System.Drawing.Size(93, 29);
            this.txtDepartmentID.TabIndex = 2;
            this.txtDepartmentID.Text = "123";
            // 
            // txtDepartName
            // 
            this.txtDepartName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDepartName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDepartName.Location = new System.Drawing.Point(94, 18);
            this.txtDepartName.MaxLength = 20;
            this.txtDepartName.Name = "txtDepartName";
            this.txtDepartName.Size = new System.Drawing.Size(166, 29);
            this.txtDepartName.TabIndex = 1;
            // 
            // lbUSER_LOGIN_ID
            // 
            this.lbUSER_LOGIN_ID.AutoSize = true;
            this.lbUSER_LOGIN_ID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUSER_LOGIN_ID.Location = new System.Drawing.Point(14, 21);
            this.lbUSER_LOGIN_ID.Name = "lbUSER_LOGIN_ID";
            this.lbUSER_LOGIN_ID.Size = new System.Drawing.Size(74, 21);
            this.lbUSER_LOGIN_ID.TabIndex = 4;
            this.lbUSER_LOGIN_ID.Text = "部门名称";
            // 
            // DepartmentManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 575);
            this.Controls.Add(this.grpList);
            this.Controls.Add(this.grpUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "DepartmentManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "部门管理";
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
        private System.Windows.Forms.TextBox txtDepartmentID;
        private System.Windows.Forms.TextBox txtDepartName;
        private System.Windows.Forms.Label lbUSER_LOGIN_ID;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}