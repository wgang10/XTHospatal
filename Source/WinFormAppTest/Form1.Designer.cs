namespace WinFormAppTest
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uControlNews1 = new WinFormAppTest.UControlNews();
            this.SuspendLayout();
            // 
            // uControlNews1
            // 
            this.uControlNews1.BackColor = System.Drawing.Color.CadetBlue;
            this.uControlNews1.Location = new System.Drawing.Point(51, 31);
            this.uControlNews1.Name = "uControlNews1";
            this.uControlNews1.Size = new System.Drawing.Size(590, 105);
            this.uControlNews1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 387);
            this.Controls.Add(this.uControlNews1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UControlNews uControlNews1;
    }
}

