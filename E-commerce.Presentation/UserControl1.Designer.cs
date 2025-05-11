namespace Ecommerce
{
    partial class UserControl1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            idProduct = new Label();
            btnBuy1_1 = new Button();
            ProductPrice = new Label();
            txtTitle = new Label();
            ProductPicture = new Guna.UI2.WinForms.Guna2PictureBox();
            DescText = new Label();
            ((System.ComponentModel.ISupportInitialize)ProductPicture).BeginInit();
            SuspendLayout();
            // 
            // idProduct
            // 
            resources.ApplyResources(idProduct, "idProduct");
            idProduct.Name = "idProduct";
            // 
            // btnBuy1_1
            // 
            btnBuy1_1.BackColor = Color.Lavender;
            resources.ApplyResources(btnBuy1_1, "btnBuy1_1");
            btnBuy1_1.Name = "btnBuy1_1";
            btnBuy1_1.UseVisualStyleBackColor = false;
            // 
            // ProductPrice
            // 
            resources.ApplyResources(ProductPrice, "ProductPrice");
            ProductPrice.Name = "ProductPrice";
            // 
            // txtTitle
            // 
            resources.ApplyResources(txtTitle, "txtTitle");
            txtTitle.Name = "txtTitle";
            // 
            // ProductPicture
            // 
            ProductPicture.CustomizableEdges = customizableEdges1;
            ProductPicture.ImageRotate = 0F;
            resources.ApplyResources(ProductPicture, "ProductPicture");
            ProductPicture.Name = "ProductPicture";
            ProductPicture.ShadowDecoration.CustomizableEdges = customizableEdges2;
            ProductPicture.TabStop = false;
            ProductPicture.Click += ProductPicture_Click;
            // 
            // DescText
            // 
            resources.ApplyResources(DescText, "DescText");
            DescText.Name = "DescText";
            // 
            // UserControl1
            // 
            AllowDrop = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(DescText);
            Controls.Add(ProductPicture);
            Controls.Add(idProduct);
            Controls.Add(btnBuy1_1);
            Controls.Add(ProductPrice);
            Controls.Add(txtTitle);
            Name = "UserControl1";
            Load += UserControl1_Load;
            Click += UserControl1_Click;
            ((System.ComponentModel.ISupportInitialize)ProductPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label idProduct;
        private System.Windows.Forms.Button btnBuy1_1;
        private System.Windows.Forms.Label ProductPrice;
        private System.Windows.Forms.Label txtTitle;
        private Guna.UI2.WinForms.Guna2PictureBox ProductPicture;
        private Label DescText;
    }
}
