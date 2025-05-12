namespace E_commerce.Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            System.Windows.Forms.Application.EnableVisualStyles(); // Corrected method call  
            InitializeComponent();
            this.Text = "Admin Dashboard";
            this.Size = new Size(1000, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            int startX = 240; // leave space for sidebar  
            int startY = 30;
            int cardWidth = 170;
            int cardHeight = 100;
            int spacing = 20;

            CreateCard("Pending Orders", "15", Color.LightSkyBlue, new Point(startX, startY), cardWidth, cardHeight);
            CreateCard("Total Products", "120", Color.LightGreen, new Point(startX + cardWidth + spacing, startY), cardWidth, cardHeight);
            CreateCard("Total Users", "42", Color.SandyBrown, new Point(startX, startY + cardHeight + spacing), cardWidth, cardHeight);
            CreateCard("Total Categories", "8", Color.MediumPurple, new Point(startX + cardWidth + spacing, startY + cardHeight + spacing), cardWidth, cardHeight);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CreateCard(string title, string count, Color bgColor, Point location, int width, int height)
        {
            var card = new RoundedPanel
            {
                BackColor = bgColor,
                Size = new Size(width, height),
                Location = location,
                CornerRadius = 15
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(15, 15)
            };

            var lblCount = new Label
            {
                Text = count,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(15, 45)
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblCount);
            this.Controls.Add(card);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
