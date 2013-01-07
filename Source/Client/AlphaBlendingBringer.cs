using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace XTHospitalUI
{
    public partial class AlphaBlendingBringer : Component
    {
        System.Windows.Forms.Form form = null;
        public AlphaBlendingBringer()
        {
            InitializeComponent();
        }

        public AlphaBlendingBringer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            double d = 1000.0 / fadeTimer.Interval / 100.0;
            if (form.Opacity + d >= 1.0)
            {
                form.Opacity = 1.0;
                fadeTimer.Stop();
            }
            else
            {
                form.Opacity += d;
            }
        }
        public void SetAlphaBlending(System.Windows.Forms.Form form)
        {
            this.form = form;
            this.form.Opacity = 0.0;
            this.form.Activate();
            this.form.Refresh();
            fadeTimer.Start();
        }

        public int Interval
        {
            set
            {
                this.fadeTimer.Interval = value;
            }
        }
    }
}
