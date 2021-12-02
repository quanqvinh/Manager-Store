using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.DefinedFramework
{
    public partial class GoodsCell : UserControl
    {
        public string Url { get; set; }
        public string GoodsName { get; set; }
        public double Price { get; set; }
        public int QuantityRemain { get; set; }
        public GoodsCell(string url, string name, double price, int quantity)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            Url = url;
            SetImage(url);
            GoodsName = name;
            SetName(name);
            Price = price;
            SetPrice(price);
            QuantityRemain = quantity;
            nudQuantity.Controls[0].Visible = false;
            nudQuantity.Maximum = QuantityRemain;
            Name = name;

            BackColor = Color.White;
            lbName.ForeColor = Color.Black;
            lbPrice.ForeColor = Color.Red;
            btnAddToCart.FillColor = root.homePrimaryColor;
            btnMinus.FillColor = root.homePrimaryColor;
            btnPlus.FillColor = root.homePrimaryColor;
            btnMinus.Enabled = false;
        }

        private void SetImage(string url)
        {
            if (url == null)
                url = root.ProjectPath() + root.imageGoods + "default.png";
            else
                url = root.ProjectPath() + url;
            pnImage.BackgroundImage = Image.FromFile(url);
        }

        private void SetName(string name)
        {
            lbName.Text = name;
        }

        private void SetPrice(double price)
        {
            string s = price.ToString();
            for (int i = s.Length - 3; i > 0; i -= 3)
                s = s.Insert(i, ".");
            lbPrice.Text = s + " đ";
        }

        private void pnImage_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Panel).DisplayRectangle,
                Color.Transparent, 0, ButtonBorderStyle.Solid,
                Color.Transparent, 0, ButtonBorderStyle.Solid,
                Color.Transparent, 0, ButtonBorderStyle.Solid,
                Color.FromArgb(200, 200, 200), 2, ButtonBorderStyle.Solid);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(nudQuantity.Text);
            nudQuantity.Text = (quantity + 1).ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(nudQuantity.Text);
            nudQuantity.Text = (quantity - 1).ToString();
        }

        public void Reset()
        {
            nudQuantity.Text = "0";
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (nudQuantity.Value > 0)
            {
                btnAddToCart.Enabled = true;
                btnMinus.Enabled = true;
                if (nudQuantity.Value == nudQuantity.Maximum)
                    btnPlus.Enabled = false;
                else
                    btnPlus.Enabled = true;
            }
            else
            {
                btnAddToCart.Enabled = false;
                btnMinus.Enabled = false;
                btnPlus.Enabled = true;
            }
        }
    }
}
