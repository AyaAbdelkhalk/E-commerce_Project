using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace E_commerce.Presentation.CustomControls
{
    [DefaultEvent("_TextChanged")]
    public partial class CustomTextBox2 : UserControl
    {
        public CustomTextBox2()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // لتجنب الـ Flickering
            this.Size = new Size(400, 35); // زيادة الارتفاع بـ 5 بكسل
            this.Padding = new Padding(5); // تحسين الـ Padding
        }

        private void CustomTextBox2_Load(object sender, EventArgs e)
        {
            UpdateControlHeight();
        }

        //Fields
        private Color borderColor = Color.FromArgb(181, 191, 249);
        private int borderSize = 2; // زيادة الحدود لتأثير أفضل
        private bool underlinedStyle = false;
        private Color borderFocusColor = Color.FromArgb(0, 120, 215); // لون أكثر جاذبية
        private bool isFocused = false;
        private int cornerRadius = 8; // زوايا مستديرة

        //Default Event
        public event EventHandler _TextChanged;

        //Properties
        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }

        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }

        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                this.Invalidate();
            }
        }

        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool PasswordChar
        {
            get { return textBox1.UseSystemPasswordChar; }
            set { textBox1.UseSystemPasswordChar = value; }
        }

        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Multiline
        {
            get { return textBox1.Multiline; }
            set { textBox1.Multiline = value; }
        }

        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                textBox1.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }

        //Overridden methods
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.AntiAlias; // لتحسين الرسم

            // Draw rounded border with shadow effect
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                path.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddArc(rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddArc(rect.Width - cornerRadius * 2, rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                path.AddArc(rect.X, rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.CloseFigure();

                this.Region = new Region(path);

                // Add shadow effect
                using (Pen shadowPen = new Pen(Color.FromArgb(50, 0, 0, 0), 2))
                {
                    shadowPen.Alignment = PenAlignment.Inset;
                    graph.DrawPath(shadowPen, path);
                }

                // Draw border
                using (Pen penBorder = new Pen(isFocused ? borderFocusColor : borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    graph.DrawPath(penBorder, path);
                }
            }

            // Underline style if enabled
            if (underlinedStyle && !isFocused)
            {
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
            this.Invalidate(); // إعادة الرسم عند تغيير الحجم
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        //Private methods
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int desiredTextBoxHeight = this.Height - this.Padding.Top - this.Padding.Bottom - borderSize * 2;
                textBox1.Height = desiredTextBoxHeight > 0 ? desiredTextBoxHeight : 22; // Ensure a minimum height
                textBox1.Location = new Point(this.Padding.Left + borderSize, this.Padding.Top + borderSize);
                textBox1.Width = this.Width - this.Padding.Left - this.Padding.Right - borderSize * 2;
            }
        }

        //Change border color in focus mode
        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
        }

        //TextBox-> TextChanged event
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }

        //TextBox events
        private void textBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
        [Category("Advance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public HorizontalAlignment TextAlign
        {
            get { return textBox1.TextAlign; }
            set { textBox1.TextAlign = value; }
        }
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(8, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(384, 23); // تعديل الارتفاع ليتناسب مع 35
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            textBox1.Click += textBox1_Click;
            textBox1.MouseEnter += textBox1_MouseEnter;
            textBox1.MouseLeave += textBox1_MouseLeave;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // CustomTextBox2
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(textBox1);
            ForeColor = Color.FromArgb(38, 32, 59);
            Name = "CustomTextBox2";
            Padding = new Padding(5);
            Size = new Size(400, 35); // الارتفاع الجديد
            Load += CustomTextBox2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textBox1;
    }
}