using BaiqiSoft.GridControl;
using BLL;
using DTO;
using GUI.DefinedFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class fBill : Form
    {
        private BLL_Bill bll = new BLL_Bill();
        private BLL_Employee bll_employee = new BLL_Employee();
        private DataTable dt_staff;
        public fBill()
        {
            InitializeComponent();
            tlpWrapper.ColumnStyles[1].Width = 0;
            btnDeleteSearch.Hide();

            BackColor = root.screenColor;
            tlpWrapper.BackColor = root.screenColor;
            dgvBills.ThemeStyle.BackColor = root.screenColor;
            dgvBills.GridColor = root.screenColor;
            dgvBills.DefaultCellStyle.ForeColor = Color.Black;
            dgvBills.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvBills.ColumnHeadersDefaultCellStyle.SelectionBackColor = root.billPrimaryColor;
            pnSearchAndFunction.FillColor = root.backColorComponentBill;
            pnFunctions.FillColor = root.backColorComponentBill;
            cbbFilter.FillColor = root.billPrimaryColor;
            btnDetail.FillColor = root.billPrimaryColor;
            pnSearch.BorderColor = root.billPrimaryColor;
            txtSearch.FillColor = root.backColorComponentBill;
            pnSideBar.FillColor = root.headerSideBarColor;
            pnSideBarBody.FillColor = root.sideBarColor;
            pnSideBarHeader.FillColor = root.headerSideBarColor;
            pnSideBarFooter.FillColor = root.footerSideBarColor;
            gbBillInformation.CustomBorderColor = root.headerSideBarColor;
            gbBillInformation.FillColor = root.componentInSideBarColor;
            gbItemsInformation.CustomBorderColor = root.headerSideBarColor;
            gbItemsInformation.FillColor = root.componentInSideBarColor;

            string error = null;
            dt_staff = bll_employee.GetStaffs(ref error);
            cbbEid.DataSource = dt_staff;
            cbbEid.ValueMember = "ID";
            cbbEname.DataSource = dt_staff;
            cbbEname.ValueMember = "Name";
        }

        private void fBill_Load(object sender, EventArgs e)
        {
            string error = null;
            dgvBills.DataSource = bll.GetAllBills(ref error);
            if (dgvBills.DataSource == null)
            {
                MessageBox.Show(error);
                fMain main = (fMain)Parent.Parent.Parent;
                switch (fMain.beforeForm)
                {
                    case 0: main.OpenHomePage(null, null); break;
                    case 1: main.OpenBillForm(null, null); break;
                    case 2: main.OpenGoodsForm(null, null); break;
                    case 3: main.OpenContractForm(null, null); break;
                    case 4: main.OpenEmployeeForm(null, null); break;
                    case 5: main.OpenCashFlowForm(null, null); break;
                }
                return;
            }
            if (error != null)
                MessageBox.Show(error);
            else
                CustomDgvBill();
            fMain.beforeForm = 1;
        }

        private void CustomDgvBill()
        {
            if (dgvBills.Rows.Count == 0)
            {
                txtSearch.SelectAll();
                pnSearch.BorderColor = Color.FromArgb(240, 67, 80);
            }
            else
                pnSearch.BorderColor = root.billPrimaryColor;
            dgvBills.CellBorderStyle = DataGridViewCellBorderStyle.Single;


            foreach (DataGridViewColumn dc in dgvBills.Columns)
                dc.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvBills.DefaultCellStyle.Font = new Font(new FontFamily("Roboto"), 12, FontStyle.Bold);
            dgvBills.Columns["BID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvBills.Columns["BID"].MinimumWidth = 60;
            dgvBills.Columns["BID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBills.Columns["GID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvBills.Columns["GID"].MinimumWidth = 60;
            dgvBills.Columns["GID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBills.Columns["Goods Name"].MinimumWidth = 250;
            dgvBills.Columns["Goods Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvBills.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvBills.Columns["Quantity"].MinimumWidth = 120;
            dgvBills.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBills.Columns["Unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvBills.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBills.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBills.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBills.Columns["Price"].DefaultCellStyle.Format = "#,##0 đ";
            dgvBills.Columns["Total Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBills.Columns["Total Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBills.Columns["Total Price"].DefaultCellStyle.Format = "#,##0 đ";
            dgvBills.Columns["EID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvBills.Columns["EID"].MinimumWidth = 60;
            dgvBills.Columns["EID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBills.Columns["Employee Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBills.Columns["Employee Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvBills.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBills.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvBills.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss tt";

            int width = 2;
            foreach (DataGridViewColumn col in dgvBills.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font(new FontFamily("Poppins"), 12, FontStyle.Bold);
                col.HeaderCell.Style.ForeColor = Color.BlanchedAlmond;
                width += col.Width;
            }
            int i = 0;
            foreach (DataGridViewRow row in dgvBills.Rows)
            {
                if (row.Index == 0)
                    continue;
                if (row.Cells["BID"].Value.ToString() == dgvBills.Rows[i].Cells["BID"].Value.ToString())
                {
                    row.Cells["BID"].Value = DBNull.Value;
                    row.Cells["Total Price"].Value = DBNull.Value;
                    row.Cells["EID"].Value = DBNull.Value;
                    row.Cells["Employee Name"].Value = DBNull.Value;
                    row.Cells["Date"].Value = DBNull.Value;
                }
                else
                    i = row.Index;
            }
            dgvBills.Width = width;
        }

        private void Reload()
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                txtSearch_KeyDown(null, new KeyEventArgs(Keys.Enter));
                return;
            }
            string error = null;
            DataTable dt = bll.GetAllBills(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvBills.DataSource = null;
                return;
            }
            dgvBills.DataSource = dt;
            CustomDgvBill();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            int row = dgvBills.CurrentRow.Index;
            DataTable dt = (DataTable)dgvBills.DataSource;
            for (int i = row; i >= 0 ; i--) 
                if (dt.Rows[i]["BID"] != DBNull.Value)
                {
                    txtBid.Text = dt.Rows[i]["BID"].ToString();
                    cbbEid.Text = dt.Rows[i]["EID"].ToString();
                    txtTotalPrice.Text = root.MoneyFormat(dt.Rows[i]["Total Price"].ToString());
                    cbbEname.Text = dt.Rows[i]["Employee Name"].ToString();
                    dtpTime.Value = (DateTime)dt.Rows[i]["Date"];
                    break;
                }
            string error = null;
            DataTable dt_goodsInBill = bll.SearchBills("id", int.Parse(txtBid.Text), ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                return;
            } 
            tlpWrapper.ColumnStyles[1].Width = 600;
            SetupPreviewTable(tlpGoodsInBill, 4, dt_goodsInBill.Rows.Count);
            cbbItemName.Items.Clear();
            foreach (DataRow dr in dt_goodsInBill.Rows)
            {
                int id = (int)dr["GID"];
                string name = (string)dr["Goods Name"];
                string unit = (string)dr["Unit"];
                int quantity = (int)dr["Quantity"];
                double price = (double)dr["Price"] / quantity;
                string url = root.ProjectPath() + root.imageGoods + name.Replace(' ', '_') + ".png";
                bool image = File.Exists(url);
                cbbItemName.Items.Add(name);
                tlpGoodsInBill.Controls.Add(new GoodsView(new Goods(id, name, unit, price, quantity, true, image), quantity, price * quantity, false));
            }
            string currentItem = (string)dt.Rows[row]["Goods Name"];
            tlpGoodsInBill.Tag = tlpGoodsInBill.Controls[currentItem];
            cbbItemName.Text = currentItem;
            lbSideBarTitle.Text = "Detail Bill";
            btnTick.Image = global::Manage_Store.Properties.Resources.edit2;
            gbBillInformation.Enabled = false;
            pnItemNameAndID.Enabled = false;
            pnQuantityAndItemPrice.Enabled = false;
            pnSideBarFooter.Enabled = false;
        }

        private void SetupPreviewTable(TableLayoutPanel tlp, int nCol, int n)
        {
            tlp.Controls.Clear();
            int nRow = n % nCol == 0 ? n / nCol : n / nCol + 1;
            tlp.RowCount = nRow;
            tlp.ColumnCount = nCol;
            for (int i = tlp.ColumnStyles.Count; i < nCol; i++)
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
            for (int i = tlp.RowStyles.Count; i < nRow; i++)
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent));
            foreach (ColumnStyle col in tlp.ColumnStyles)
            {
                col.SizeType = SizeType.Percent;
                col.Width = 100 / nCol;
            }
            foreach (RowStyle row in tlp.RowStyles)
            {
                row.SizeType = SizeType.Percent;
                row.Height = 100 / nRow;
            }
            tlp.Height = (tlp.Width / nCol) * nRow;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult chosen = root.MyMessageBox("Do you want to delete this bill or only this goods in bill?",
                "WARNING", "Delete bill", "Delete goods", "Cancel");
            DataTable dt = (DataTable)dgvBills.DataSource;
            int row = dgvBills.CurrentRow.Index;
            int bid = 0;
            for (int i = row; ; i--)
                if (dt.Rows[i]["BID"] != DBNull.Value)
                {
                    bid = (int)dt.Rows[i]["BID"];
                    break;
                }
            string message = null;
            if (chosen == DialogResult.Yes)
            {
                message = bll.DeleteBill(bid);
                if (message != null)
                    MessageBox.Show(message);
            }
            else if (chosen == DialogResult.No)
            {
                int gid = (int)dt.Rows[row]["GID"];
                message = bll.DeleteBill(bid, gid);
                if (message != null)
                    MessageBox.Show(message);
            }
            else
                return;
            Reload();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string s = txtSearch.Text;
            if (s.Trim().Length == 0)
            {
                btnDeleteSearch.Visible = false;
            }
            else
            {
                if (cbbFilter.Text.Contains("BID"))
                {
                    int p = txtSearch.SelectionStart - 1;
                    if (p == -1)
                        return;
                    uint temp;
                    if (!uint.TryParse(s, out temp) || temp == 0)
                    {
                        s = s.Remove(p, 1);
                        txtSearch.Text = s;
                        txtSearch.SelectionStart = p;
                    }
                }
                if (txtSearch.Text.Length > 0)
                    btnDeleteSearch.Visible = true;
            }
        }

        private void btnDeleteSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
        }

        private void cbbItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            tlpGoodsInBill.Tag = tlpGoodsInBill.Controls[cbbItemName.Text];
            GoodsView gv = (GoodsView)tlpGoodsInBill.Tag;
            txtGid.Text = gv.g.Id.ToString();
            nudQuantity.Value = gv.Quantity;
            lbUnit.Text = gv.g.Unit;
            txtItemPrice.Text = root.MoneyFormat(gv.Price.ToString());
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            int quantity = (int)nudQuantity.Value;
            double itemPrice = quantity * ((GoodsView)tlpGoodsInBill.Controls[cbbItemName.Text]).g.Price;
            ((GoodsView)tlpGoodsInBill.Controls[cbbItemName.Text]).UpdateQuantity(quantity);
            ((GoodsView)tlpGoodsInBill.Controls[cbbItemName.Text]).Price = itemPrice;
            txtItemPrice.Text = root.MoneyFormat(itemPrice.ToString());
            double totalPrice = 0;
            foreach (GoodsView gv in tlpGoodsInBill.Controls)
                totalPrice += gv.Price;
            txtTotalPrice.Text = root.MoneyFormat(totalPrice.ToString());
        }

        private void btnTick_Click(object sender, EventArgs e)
        {
            if (lbSideBarTitle.Text.ToLower().Contains("detail"))
            {
                lbSideBarTitle.Text = "Edit Bill";
                btnTick.Image = global::Manage_Store.Properties.Resources.tick;
                gbBillInformation.Enabled = true;
                pnItemNameAndID.Enabled = true;
                pnQuantityAndItemPrice.Enabled = true;
                pnSideBarFooter.Enabled = true;
            }
            else
            {
                lbSideBarTitle.Text = "Detail Bill";
                btnTick.Image = global::Manage_Store.Properties.Resources.edit2;
                gbBillInformation.Enabled = false;
                pnItemNameAndID.Enabled = false;
                pnQuantityAndItemPrice.Enabled = false;
                pnSideBarFooter.Enabled = false;
            }
        }

        private void cbbEid_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dt_staff.Rows) 
                if (dr["ID"].ToString() == cbbEid.Text)
                {
                    cbbEname.Text = dr["Name"].ToString();
                    break;
                }    
        }

        private void cbbEname_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in dt_staff.Rows)
                if (dr["Name"].ToString() == cbbEname.Text)
                {
                    cbbEid.Text = dr["ID"].ToString();
                    break;
                }
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            tlpWrapper.ColumnStyles[1].Width = 0;
        }

        private void btnSideBarConfirm_Click(object sender, EventArgs e)
        {
            int bid = int.Parse(txtBid.Text);
            int eid = int.Parse(cbbEid.Text);
            string time = dtpTime.Value.ToString("yyyy-MM-dd hh:mm:ss");
            string message = bll.UpdateBill(bid, eid, time);
            if (!message.ToLower().Contains("successful"))
            {
                MessageBox.Show(message);
                return;
            }
            foreach (GoodsView gv in tlpGoodsInBill.Controls)
            {
                int gid = gv.g.Id;
                int quantity = gv.Quantity;
                message = bll.UpdateBill(bid, gid, quantity);
                if (!message.ToLower().Contains("successful"))
                {
                    MessageBox.Show(message);
                    return;
                }
            }
            MessageBox.Show("Update successful!", "Notification");
            Reload();
        }

        private void btnSideBarCancel_Click(object sender, EventArgs e)
        {
            btnDetail.PerformClick();
        }

        private void cbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbFilter.Text.Contains("BID"))
            {
                txtSearch.PlaceholderText = "Enter bill ID...";
            }
            else if (cbbFilter.Text.Contains("EID"))
            {
                txtSearch.PlaceholderText = "Enter employee ID or name...";
            }
            else if (cbbFilter.Text.Contains("GID"))
            {
                txtSearch.PlaceholderText = "Enter goods ID or name...";
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            e.SuppressKeyPress = true;
            string s = txtSearch.Text;
            if (string.IsNullOrEmpty(s.Trim()))
                Reload();
            else
            {
                string paramName = string.Empty;
                object paramValue = s;
                if (cbbFilter.Text.Contains("BID"))
                {
                    paramName = "id";
                    paramValue = int.Parse(s);
                }
                else if (cbbFilter.Text.Contains("EID"))
                {
                    uint temp;
                    if (uint.TryParse(s, out temp))
                    {
                        paramName = "eid";
                        paramValue = int.Parse(s);
                    }
                    else
                        paramName = "ename";
                }
                else if (cbbFilter.Text.Contains("GID"))
                {
                    uint temp;
                    if (uint.TryParse(s, out temp))
                    {
                        paramName = "gid";
                        paramValue = int.Parse(s);
                    }
                    else
                        paramName = "gname";
                }
                string error = null;
                DataTable dt = bll.SearchBills(paramName, paramValue,ref error);
                if (error != null)
                {
                    MessageBox.Show(error);
                    dgvBills.DataSource = null;
                    return;
                }
                dgvBills.DataSource = dt;
                CustomDgvBill();
            }
        }
    }
}
