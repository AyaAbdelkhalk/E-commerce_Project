namespace E_commerce.Presentation.CustomControls
{
    partial class ClientMainDashboardControl
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
            roundedPanel1 = new RoundedPanel();
            SuspendLayout();
            // 
            // roundedPanel1
            // 
            roundedPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            roundedPanel1.BackColor = Color.FromArgb(80, 110, 160);
            roundedPanel1.CornerRadius = 30;
            roundedPanel1.Location = new Point(45, 3);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(1582, 938);
            roundedPanel1.TabIndex = 2;
            roundedPanel1.Paint += roundedPanel1_Paint;
            // 
            // ClientMainDashboardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(roundedPanel1);
            Location = new Point(383, 40);
            Name = "ClientMainDashboardControl";
            Size = new Size(1582, 938);
            Load += ClientMainDashboardControl_Load;
            ResumeLayout(false);
        }

        #endregion

        public RoundedPanel roundedPanel1;
    }
}
