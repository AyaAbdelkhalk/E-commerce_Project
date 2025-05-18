using Guna.UI2.WinForms;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace E_commerce.Presentation.CustomControls
{
    partial class AdminDashboardControl
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
        private async Task InitializeComponent()
        {
            roundedPanel1 = new RoundedPanel();
            SuspendLayout();
            // 
            // roundedPanel1
            // 
            roundedPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel1.AutoScroll = true;
            roundedPanel1.BackColor = Color.FromArgb(80, 110, 160);
            roundedPanel1.CornerRadius = 30;
            roundedPanel1.Location = new Point(45, 3);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(1430, 920);
            roundedPanel1.TabIndex = 1;
            roundedPanel1.Paint += roundedPanel1_Paint;
            // 
            // AdminDashboardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Transparent;
            Controls.Add(roundedPanel1);
            Location = new Point(383, 40);
            Margin = new Padding(4, 5, 4, 5);
            Name = "AdminDashboardControl";
            Size = new Size(1582, 938);
            //Load += AdminDashboardControl_Load;


            ResumeLayout(false);
        }

        #endregion

        public RoundedPanel roundedPanel1;
    }
}
