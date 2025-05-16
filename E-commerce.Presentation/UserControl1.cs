using System.ComponentModel;
using E_commerce.Application.DTOs.CartItem;
using E_commerce.Application.Helper;
using E_commerce.Application.Services;

namespace Ecommerce
{
    public partial class UserControl1 : UserControl
    {

        public int _id;
        public string _name;
        public string _price;
        public string _imagePath;
        public static UserControl1 existProductControl;

        private readonly ICartItemService _cartItemService;
        public UserControl1(ICartItemService cartItemService)
        {
            InitializeComponent();
            _cartItemService = cartItemService;

        }


        public UserControl1(ICartItemService cartItemService, int id, string name)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            _cartItemService = cartItemService;
            _id = id;
            _name = name;
        }



        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public void SetData(string name, string price, string id, string imagePath, string desc)
        {
            txtTitle.Text = name;
            ProductPrice.Text = price;
            idProduct.Text = id;
            DescText.Text = desc;

            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                ProductPicture.Image = Image.FromFile(imagePath);
            }
            else
            {
                string defaultImagePath = Path.Combine(Application.StartupPath, "Images", "default.png");
                if (File.Exists(defaultImagePath))
                {
                    ProductPicture.Image = Image.FromFile(defaultImagePath);
                }
                else
                {
                    ProductPicture.Image = null;
                }
            }

        }

        private bool isSelected = false;
        public void Deselect()
        {
            isSelected = false;
            UpdateSelectionAppearance();
        }
        private void UserControl1_Click(object sender, EventArgs e)
        {
            if (existProductControl != null && existProductControl != this)
            {
                existProductControl.Deselect();
            }

            // حدد العنصر الحالي
            isSelected = true;
            UpdateSelectionAppearance();

            // خليه العنصر الحالي المحدد
            existProductControl = this;
        }

        public void ToggleSelection()
        {
            isSelected = !isSelected;
            UpdateSelectionAppearance();
        }

        private void UpdateSelectionAppearance()
        {
            if (isSelected)
            {
                // مظهر عند التحديد
                this.BackColor = Color.FromArgb(230, 240, 250); // لون أزرق فاتح
                this.Padding = new Padding(2);
                this.BorderStyle = BorderStyle.FixedSingle;
                this.BorderColor = Color.DodgerBlue; // تحتاج خاصية BorderColor المخصصة
            }
            else
            {
                // مظهر عادي
                this.BackColor = Color.Transparent;
                this.Padding = new Padding(0);
                this.BorderStyle = BorderStyle.None;
            }
        }



        // إضافة خاصية BorderColor المخصصة
        private Color borderColor = Color.Gray;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            if (BorderStyle == BorderStyle.FixedSingle)
            {
                using (Pen pen = new Pen(borderColor, 2))
                {
                    e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, Width - 1, Height - 1));
                }
            }
        }

        private void ProductPicture_Click(object sender, EventArgs e)
        {

        }

        private async void btnBuy1_1_Click(object sender, EventArgs e)
        {
            

            try
            {
                if(_cartItemService == null)
                {
                    MessageBox.Show("CartItemService is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var cartItemDto = new CreateCartItemDTO
                {
                    UserID = SessionManager.CurrentUser?.UserID??3,
                    ProductID = _id,
                    Quantity = 1 // Default quantity; can be modified to allow user input
                };

                var response = await _cartItemService.AddCartItemAsync(cartItemDto);
                if (response.Succeeded)
                {
                    var toast = new Guna.UI2.WinForms.Guna2MessageDialog
                    {
                        Caption = "Success",
                        Text = "Product added to cart successfully!",
                        Icon = Guna.UI2.WinForms.MessageDialogIcon.Information,
                        Style = Guna.UI2.WinForms.MessageDialogStyle.Light
                    };
                    toast.Show();
                }
                else
                {
                    MessageBox.Show($"Failed to add product to cart: {string.Join(", ", response.Errors)}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
