namespace UI
{
    partial class UControlNews
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRefrshTime = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lbRefrshTime1 = new System.Windows.Forms.Label();
            this.lbRefrshTime2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.tmrShow_Tick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(541, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(44, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "公告:";
            this.label1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDoubleClick);
            // 
            // lbRefrshTime
            // 
            this.lbRefrshTime.AutoSize = true;
            this.lbRefrshTime.Location = new System.Drawing.Point(3, 17);
            this.lbRefrshTime.Name = "lbRefrshTime";
            this.lbRefrshTime.Size = new System.Drawing.Size(23, 12);
            this.lbRefrshTime.TabIndex = 2;
            this.lbRefrshTime.Text = "600";
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lbRefrshTime1
            // 
            this.lbRefrshTime1.AutoSize = true;
            this.lbRefrshTime1.Location = new System.Drawing.Point(1, 29);
            this.lbRefrshTime1.Name = "lbRefrshTime1";
            this.lbRefrshTime1.Size = new System.Drawing.Size(29, 12);
            this.lbRefrshTime1.TabIndex = 3;
            this.lbRefrshTime1.Text = "秒后";
            // 
            // lbRefrshTime2
            // 
            this.lbRefrshTime2.AutoSize = true;
            this.lbRefrshTime2.Location = new System.Drawing.Point(1, 43);
            this.lbRefrshTime2.Name = "lbRefrshTime2";
            this.lbRefrshTime2.Size = new System.Drawing.Size(29, 12);
            this.lbRefrshTime2.TabIndex = 4;
            this.lbRefrshTime2.Text = "刷新";
            // 
            // UControlNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbRefrshTime2);
            this.Controls.Add(this.lbRefrshTime1);
            this.Controls.Add(this.lbRefrshTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Name = "UControlNews";
            this.Size = new System.Drawing.Size(588, 191);
            this.Load += new System.EventHandler(this.UControlNews_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRefrshTime;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lbRefrshTime1;
        private System.Windows.Forms.Label lbRefrshTime2;
    }
}
