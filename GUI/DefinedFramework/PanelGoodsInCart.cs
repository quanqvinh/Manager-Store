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
    public partial class PanelGoodsInCart : UserControl
    {
        public double Price { get; set; }
        public int QuantityRemain { get; set; }
        public PanelGoodsInCart(string url, string name, double price, int quantity, int quantityRemain)
        {
            InitializeComponent();
            Dock = DockStyle.Top;
            SetImage(url);
            SetName(name);
            SetQuantity(quantity);
            Price = price;
            Name = name;
            QuantityRemain = quantityRemain;
            lbPrice.Text = root.MoneyFormat((price * quantity).ToString());
            nudQuantity.Controls[0].Visible = false;
            nudQuantity.Maximum = QuantityRemain;

            BackColor = root.screenColor;
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

        private void SetQuantity(int quantity)
        {
            nudQuantity.Text = quantity.ToString();
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

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (nudQuantity.Value > 0)
            {
                btnMinus.Enabled = true;
                if (nudQuantity.Value == nudQuantity.Maximum)
                    btnPlus.Enabled = false;
                else
                    btnPlus.Enabled = true;
            }
            else
            {
                btnMinus.Enabled = false;
                btnPlus.Enabled = true;
            }
        }
    }
}
