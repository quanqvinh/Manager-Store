using BLL;
using GUI.DefinedFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fHome : Form
    {
        private BLL_Goods bll_goods = new BLL_Goods();
        private BLL_Bill bll_bill = new BLL_Bill();
        private DataTable dt = null;
        private GoodsCell[] cells;
        public fHome()
        {
            InitializeComponent();
            tlpMain.ColumnStyles[1].Width = 0;
            btnBack.Hide();
            pnCart.Hide();

            BackColor = root.screenColor;
            tlpWrapper.BackColor = root.screenColor;
            btnClean.FillColor = root.homePrimaryColor;
            btnBack.FillColor = root.homePrimaryColor;
            btnBack.FillColor = root.homePrimaryColor;
            btnCart.FillColor = root.homePrimaryColor;
            pnCartBody.FillColor = root.screenColor;
            pnCartFooter.FillColor = Color.Transparent;
            horizontalLine.FillColor = root.navBarColor;
            btnClean.FillColor = root.backColorComponentBill;
            btnCleanCart.FillColor = root.backColorComponentBill;

            LoadGoods();
            CreateGoodsGrid();
        }

        private void fHome_Load(object sender, EventArgs e)
        {
            bool isStockmanager = fMain.Profile.Role != "STOCK MANAGER";
            tlpGoods.Enabled = isStockmanager;
            pnButtons.Enabled = isStockmanager;
        }

        private void LoadGoods()
        {
            string error = null;
            dt = bll_goods.GetGoodsStillSelling(ref error);
            if (error != null)
            {
                MessageBox.Show(error, "Can not load goods");
                return;
            }
            fMain.beforeForm = 0;
        }

        private void CreateGoodsGrid()
        {
            int colCount = 6;
            int rowCount = dt.Rows.Count % colCount == 0 ? dt.Rows.Count / colCount : dt.Rows.Count / colCount + 1;
            tlpGoods.ColumnCount = colCount;
            tlpGoods.RowCount = rowCount;
            tlpGoods.Height = (int)((tlpGoods.Width / colCount) * (400.0 / 300.0) * rowCount);
            for (int i = 1; i < colCount; i++)
                tlpGoods.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
            for (int i = 1; i < rowCount; i++)
                tlpGoods.RowStyles.Add(new RowStyle(SizeType.Percent));
            foreach (ColumnStyle col in tlpGoods.ColumnStyles)
            {
                col.SizeType = SizeType.Percent;
                col.Width = 100 / colCount;
            }
            foreach (RowStyle row in tlpGoods.RowStyles)
            {
                row.SizeType = SizeType.Percent;
                row.Height = 100 / rowCount;
            }

            // Data
            cells = new GoodsCell[dt.Rows.Count];
            for (int i = 0; i < cells.Length; i++)
            {
                string url = dt.Rows[i]["gphoto"] == DBNull.Value ? null : (string)dt.Rows[i]["gphoto"];
                cells[i] = new GoodsCell(url,
                    (string)dt.Rows[i]["gname"],
                    (double)dt.Rows[i]["gprice"],
                    (int)dt.Rows[i]["gquantity"]);
                cells[i].btnAddToCart.Click += new EventHandler(btnAddToCart_Click);
                tlpGoods.Controls.Add(cells[i]);
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            GoodsCell gc = (GoodsCell)(sender as Control).Parent.Parent;
            if (pnCartBody.Controls.Find(gc.GoodsName, true).Length > 0)
            {
                PanelGoodsInCart pntemp = pnCartBody.Controls[gc.GoodsName] as PanelGoodsInCart;
                pntemp.nudQuantity.Value += gc.nudQuantity.Value;
            }
            else
            {
                PanelGoodsInCart pntemp = new PanelGoodsInCart(gc.Url, gc.GoodsName, gc.Price, (int)gc.nudQuantity.Value, gc.QuantityRemain);
                pnCartBody.Controls.Add(pntemp);
                lbTotalPrice.Text = root.MoneyFormat((int.Parse(root.TurnOffMoneyFormat(lbTotalPrice.Text))
                    + int.Parse(root.TurnOffMoneyFormat(pntemp.lbPrice.Text))).ToString());
                btnCheckout.Enabled = true;
                btnCleanCart.Enabled = true;
                pntemp.nudQuantity.ValueChanged += new EventHandler(nudQuantity_ValueChanged);
                pntemp.btnDelete.Click += new EventHandler(btnDelete_Click);
            }
            gc.nudQuantity.Value = 0;
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            PanelGoodsInCart pntemp = (PanelGoodsInCart)(sender as Control).Parent.Parent.Parent.Parent;
            int totalPrice = int.Parse(root.TurnOffMoneyFormat(lbTotalPrice.Text));
            totalPrice -= int.Parse(root.TurnOffMoneyFormat(pntemp.lbPrice.Text));
            int itemPrice = (int)pntemp.nudQuantity.Value * (int)pntemp.Price;
            totalPrice += itemPrice;
            lbTotalPrice.Text = root.MoneyFormat(totalPrice.ToString());
            pntemp.lbPrice.Text = root.MoneyFormat(itemPrice.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PanelGoodsInCart pntemp = (PanelGoodsInCart)(sender as Control).Parent.Parent.Parent;
            int totalPrice = int.Parse(root.TurnOffMoneyFormat(lbTotalPrice.Text));
            int itemPrice = int.Parse(root.TurnOffMoneyFormat(pntemp.lbPrice.Text));
            lbTotalPrice.Text = root.MoneyFormat((totalPrice - itemPrice).ToString());
            pnCartBody.Controls.Remove(pntemp);
            if (pnCartBody.Controls.Count == 0)
            {
                btnCheckout.Enabled = false;
                btnCleanCart.Enabled = false;
            }
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            tlpMain.ColumnStyles[0].Width = 0;
            tlpMain.ColumnStyles[1].Width = 100;
            btnClean.Hide();
            btnCart.Hide();
            btnBack.Show();
            pnCart.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            tlpMain.ColumnStyles[1].Width = 0;
            tlpMain.ColumnStyles[0].Width = 100;
            btnBack.Hide();
            pnCart.Hide();
            btnClean.Show();
            btnCart.Show();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            foreach (GoodsCell gc in cells)
                gc.Reset();
        }

        private void btnCleanCart_Click(object sender, EventArgs e)
        {
            pnCartBody.Controls.Clear();
            lbTotalPrice.Text = root.MoneyFormat("0");
            btnCleanCart.Enabled = false;
            btnCheckout.Enabled = false;
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            int bid = bll_bill.GetNewBillID();
            int eid = fMain.Profile.Id;
            string message = null;
            foreach (PanelGoodsInCart pn in pnCartBody.Controls)
            {
                string gname = pn.lbName.Text;
                int quantity = (int)pn.nudQuantity.Value;
                message = bll_bill.InsertBill(bid, gname, eid, quantity);
                if (!message.ToLower().Contains("successful"))
                {
                    MessageBox.Show(message);
                    return;
                }
            }
            MessageBox.Show("Add bill successful!");
            btnCleanCart.PerformClick();
            btnBack.PerformClick();
        }
    }
}
