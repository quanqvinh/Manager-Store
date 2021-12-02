using BLL;
using DTO;
using GUI.DefinedFramework;
using Guna.UI2.WinForms;
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
    public partial class fContract : Form
    {
        private BLL_Contract bll = new BLL_Contract();
        private BLL_Employee bll_employee = new BLL_Employee();
        private BLL_Goods bll_goods = new BLL_Goods();
        private BLL_Provider bll_provider = new BLL_Provider();
        private DataTable dt_provider = null, dt_goods = null;
        private Contract contractDetail;
        
        public fContract()
        {
            InitializeComponent();
            tlpWrapper.ColumnStyles[1].Width = 0;
            tlpMain.RowStyles[0].Height = 10;
            tlpMain.RowStyles[1].Height = 10;
            tlpMain.RowStyles[2].Height = 80;
            tlpMain.RowStyles[3].Height = 0;

            BackColor = root.screenColor;
            tlpWrapper.BackColor = root.screenColor;
            dgvContract.ThemeStyle.BackColor = root.screenColor;
            dgvContract.GridColor = root.screenColor;
            dgvContract.DefaultCellStyle.ForeColor = Color.Black;
            dgvContract.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvContract.ColumnHeadersDefaultCellStyle.SelectionBackColor = root.contractPrimaryColor;
            pnSearchAndFunction.FillColor = root.backColorComponentContract;
            pnFunctions.FillColor = root.backColorComponentContract;
            btnGoodsReceipt.FillColor = root.contractPrimaryColor;
            btnImport.FillColor = root.contractPrimaryColor;
            btnDetail.FillColor = root.contractPrimaryColor;
            pnSearch.BorderColor = root.contractPrimaryColor;
            txtSearch.FillColor = root.backColorComponentContract;
            pnSideBar.FillColor = root.sideBarColor;
            pnSideBarHeader.FillColor = root.headerSideBarColor;
            pnSideBarFooter.FillColor = root.footerSideBarColor;
            gbGeneralInformation.CustomBorderColor = root.headerSideBarColor;
            gbGeneralInformation.FillColor = root.componentInSideBarColor;
            gbImportedItemInformation.CustomBorderColor = root.headerSideBarColor;
            gbImportedItemInformation.FillColor = root.componentInSideBarColor;
            gbGoodInformation.CustomBorderColor = root.backColorComponentContract;
            gbGoodInformation.FillColor = root.titleBarColor;
            gbGoodsView.CustomBorderColor = root.backColorComponentContract;
            gbGoodsView.FillColor = root.titleBarColor;
            tlpPictureWrapper2.BackColor = root.backColorComponentContract;
            pnGoodsType2.FillColor = root.backColorComponentContract;
        }

        private void fContract_Load(object sender, EventArgs e)
        {
            btnGoodsReceipt.PerformClick();
            if (dgvContract.DataSource == null)
            {
                Enabled = false;
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
            string error = null;
            cbbEname.DataSource = bll_employee.GetStockManagers(ref error);
            cbbEname.ValueMember = "Name";
            cbbPname.DataSource = bll_provider.GetAllProviders(ref error);
            cbbPname.ValueMember = "Name";
            dt_provider = bll_provider.GetAllProviders(ref error);
            fMain.beforeForm = 3;
        }

        private void CustomGoodsReceiptTable()
        {
            if (dgvContract.Rows.Count == 0)
            {
                txtSearch.SelectAll();
                pnSearch.BorderColor = Color.FromArgb(240, 67, 80);
            }
            else
                pnSearch.BorderColor = root.contractPrimaryColor;
            dgvContract.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            dgvContract.DefaultCellStyle.Font = new Font(new FontFamily("Roboto"), 12, FontStyle.Bold);
            foreach (DataGridViewColumn dc in dgvContract.Columns)
                dc.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvContract.Columns["CID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvContract.Columns["CID"].MinimumWidth = 60;
            dgvContract.Columns["CID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvContract.Columns["GID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvContract.Columns["GID"].MinimumWidth = 60;
            dgvContract.Columns["GID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvContract.Columns["Goods Name"].MinimumWidth = 400;
            dgvContract.Columns["Goods Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvContract.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvContract.Columns["Quantity"].MinimumWidth = 120;
            dgvContract.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvContract.Columns["Unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvContract.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvContract.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvContract.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContract.Columns["Price"].DefaultCellStyle.Format = "#,##0 đ";
            dgvContract.Columns["Total Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvContract.Columns["Total Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContract.Columns["Total Price"].DefaultCellStyle.Format = "#,##0 đ";
            dgvContract.Columns["EID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvContract.Columns["EID"].MinimumWidth = 60;
            dgvContract.Columns["EID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvContract.Columns["Employee Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvContract.Columns["Employee Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvContract.Columns["Provider Name"].MinimumWidth = 250;
            dgvContract.Columns["Provider Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvContract.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvContract.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvContract.Columns["Date"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss tt";
            int width = 2, height = dgvContract.ColumnHeadersHeight + 1;
            //if (dgvContract.Rows.Count > 0)
            //    height += 15;
            foreach (DataGridViewColumn col in dgvContract.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font(new FontFamily("Poppins"), 12, FontStyle.Bold);
                col.HeaderCell.Style.ForeColor = Color.BlanchedAlmond;
                width += col.Width;
            }
            int i = 0;
            foreach (DataGridViewRow row in dgvContract.Rows)
            {
                if (row.Index == 0)
                    continue;
                if (row.Cells["CID"].Value.ToString() == dgvContract.Rows[i].Cells["CID"].Value.ToString())
                {
                    row.Cells["CID"].Value = DBNull.Value;
                    row.Cells["Total Price"].Value = DBNull.Value;
                    row.Cells["EID"].Value = DBNull.Value;
                    row.Cells["Employee Name"].Value = DBNull.Value;
                    row.Cells["Provider Name"].Value = DBNull.Value;
                    row.Cells["Date"].Value = DBNull.Value;
                }
                else
                    i = row.Index;
                height += row.Height + 8;
            }
            dgvContract.Size = new Size(width, height);
        }

        private void ChangeTable(object sender)
        {
            foreach (Guna2Button c in tlpType.Controls)
                c.FillColor = root.contractPrimaryColor;
            (sender as Guna2Button).FillColor = root.buttonChoosingContract;
        }

        private void btnGoodsReceipt_Click(object sender, EventArgs e)
        {
            string error = null;
            DataTable dt = bll.GetAllGoodsReceipt(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvContract.DataSource = null;
                ChangeTable(btnGoodsReceipt);
                return;
            }
            dgvContract.DataSource = dt;
            CustomGoodsReceiptTable();
            ChangeTable(btnGoodsReceipt);
            tlpMain.RowStyles[1].Height = 10;
            tlpMain.RowStyles[2].Height = 80;
            tlpMain.RowStyles[3].Height = 0;
        }

        private void ReloadGoodsReceipt()
        {
            string error = null;
            DataTable dt = bll.GetAllGoodsReceipt(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvContract.DataSource = null;
                return;
            }
            dgvContract.DataSource = dt;
            CustomGoodsReceiptTable();
        }

        //private void btnProvider_Click(object sender, EventArgs e)
        //{
        //    tlpWrapper.ColumnStyles[1].Width = 0;
        //    string error = null;
        //    dt_provider = bll.GetAllProviders(ref error);
        //    if (error != null)
        //    {
        //        MessageBox.Show(error);
        //        dgvContract.DataSource = null;
        //        ChangeTable(btnProvider);
        //        return;
        //    }
        //    dgvContract.DataSource = dt_provider;
        //    CustomProviderTable();
        //    ChangeTable(btnProvider);
        //    tlpMain.RowStyles[1].Height = 10;
        //    tlpMain.RowStyles[2].Height = 80;
        //    tlpMain.RowStyles[3].Height = 0;
        //}

        private void btnImport_Click(object sender, EventArgs e)
        {
            string error = null;
            dt_goods = bll_goods.GetAllGoods(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                return;
            }
            tlpWrapper.ColumnStyles[1].Width = 0;
            tlpMain.RowStyles[1].Height = 0;
            tlpMain.RowStyles[2].Height = 0;
            tlpMain.RowStyles[3].Height = 90;
            ChangeTable(btnImport);

            cbbPname2.DataSource = bll_provider.GetAllProviders(ref error);
            cbbPname2.ValueMember = "Name";
            cbbGname2.DataSource = bll_goods.GetAllGoods(ref error);
            cbbGname2.ValueMember = "Name";
            cbbUnit2.Enabled = false;
            txtSellingPrice2.Enabled = false;
            tlpPictureWrapper2.Enabled = false;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            btnTick.Image = global::Manage_Store.Properties.Resources.edit2;
            btnSideBarConfirm.Enabled = false;
            pnGeneralInformation.Enabled = false;
            foreach (Control c in gbImportedItemInformation.Controls)
                c.Enabled = false;
            pnGoodsView.Enabled = true;
            cbbItemsName.Enabled = true;

            int row = dgvContract.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgvContract.DataSource;
            contractDetail = new Contract();
            string pname = string.Empty;
            for (int i = row; i >= 0; i--)
                if (dt.Rows[i]["CID"] != DBNull.Value)
                {
                    contractDetail.CID = (int)dt.Rows[i]["CID"];
                    contractDetail.EID = (int)dt.Rows[i]["EID"];
                    contractDetail.PriceContract = (double)dt.Rows[i]["Total Price"];
                    contractDetail.Ename = (string)dt.Rows[i]["Employee name"];
                    pname = (string)dt.Rows[i]["Provider name"];
                    contractDetail.Date = (DateTime)dt.Rows[i]["Date"];
                    break;
                }

            txtCid.Text = contractDetail.CID.ToString();
            txtEid.Text = contractDetail.EID.ToString();
            txtPriceContract.Text = root.MoneyFormat(contractDetail.PriceContract.ToString());
            cbbEname.Text = contractDetail.Ename;
            dtpTime.Value = contractDetail.Date;
            string error = null;
            foreach (DataRow dr in dt_provider.Rows)
                if ((string)dr["Name"] == pname)
                {
                    contractDetail.Prov = new Provider(dr, false);
                    break;
                }
            txtPid.Text = contractDetail.Prov.ID.ToString();
            cbbPname.Text = contractDetail.Prov.Name;
            txtPname.Text = contractDetail.Prov.Name;
            txtPname.SelectionStart = 0;
            txtPaddress.Text = contractDetail.Prov.Address;
            txtPaddress.SelectionStart = 0;
            txtPphoneNumber.Text = contractDetail.Prov.PhoneNumber;
            DataTable dtGoods = bll.DetailGoodsInContract(contractDetail.CID, ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                return;
            }
            tlpWrapper.ColumnStyles[1].Width = 550;
            SetupPreviewTable(tlpGoodsInContract, 5, dtGoods.Rows.Count);
            cbbItemsName.Items.Clear();
            foreach (DataRow dr in dtGoods.Rows)
            {
                Goods g = new Goods((int)dr["goods_id"], (string)dr["gname"], (string)dr["unit"],
                    (double)dr["gprice"], (int)dr["gquantity"], (bool)dr["gstate"], dr["gphoto"] != null);
                GoodsView temp = new GoodsView(g, (int)dr["cquantity"], (double)dr["cprice"], false);
                tlpGoodsInContract.Controls.Add(temp);
                cbbItemsName.Items.Add((string)dr["gname"]);
                contractDetail.Add(g, (double)dr["cprice"]);
            }

            string url = root.ProjectPath() + root.imageGoods + dt.Rows[row]["Goods name"].ToString().Replace(' ', '_') + ".png";
            if (File.Exists(url))
            {
                pbPictureSideBar.Image = Image.FromFile(url);
                txtUrl.Text = url;
            }
            else
            {
                pbPictureSideBar.Image = Image.FromFile(root.ProjectPath() + root.imageGoods + "default.png");
                txtUrl.Text = string.Empty;
            }
            tlpGoodsInContract.Tag = tlpGoodsInContract.Controls[(string)dt.Rows[row]["Goods name"]];
            txtGid.Text = dt.Rows[row]["GID"].ToString();
            cbbItemsName.Text = (string)dt.Rows[row]["Goods name"];
            cbbUnit.Text = contractDetail.Goods[cbbItemsName.Text].Unit;
            txtItemPrice.Text = root.MoneyFormat(contractDetail.Goods[cbbItemsName.Text].Price.ToString());
            nudQuantity.Value = (int)dt.Rows[row]["Quantity"];
            txtImportPrice.Text = root.MoneyFormat(dt.Rows[row]["Price"].ToString());
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string text = txtSearch.Text;
            if (text.Length == 0)
            {
                btnGoodsReceipt.PerformClick();
                txtSearch.Focus();
                btnDeleteSearch.Visible = false;
            }
            else
            {
                btnDeleteSearch.Visible = true;
            }
        }

        private void SearchContract()
        {
            string paramName = null, text = txtSearch.Text;
            object paramValue = null;
            if (cbbFilter.SelectedIndex == 0)
            {
                paramName = "cid";
                paramValue = int.Parse(text);
            }
            else if (cbbFilter.SelectedIndex == 1)
            {
                int temp;
                if (int.TryParse(text, out temp))
                {
                    paramName = "eid";
                    paramValue = temp;
                }
                else
                {
                    paramName = "ename";
                    paramValue = text;
                }
            }
            else if (cbbFilter.SelectedIndex == 2)
            {
                int temp;
                if (int.TryParse(text, out temp))
                {
                    paramName = "gid";
                    paramValue = temp;
                }
                else
                {
                    paramName = "gname";
                    paramValue = text;
                }
            }
            else if (cbbFilter.SelectedIndex == 3)
            {
                int temp;
                if (int.TryParse(text, out temp))
                {
                    paramName = "pid";
                    paramValue = temp;
                }
                else
                {
                    paramName = "pname";
                    paramValue = text;
                }
            }
            string error = null;
            DataTable dt = bll.SearchInContract(paramName, paramValue, ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvContract.DataSource = null;
                return;
            }
            dgvContract.DataSource = dt;
            CustomGoodsReceiptTable();
        }

        private void cbbFilter_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbFilter.SelectedIndex == 0)
                txtSearch.PlaceholderText = "Enter contract ID...";
            else if (cbbFilter.SelectedIndex == 1)
                txtSearch.PlaceholderText = "Enter employee ID or employee name...";
            else if (cbbFilter.SelectedIndex == 2)
                txtSearch.PlaceholderText = "Enter goods ID or goods name...";
            else if (cbbFilter.SelectedIndex == 3)
                txtSearch.PlaceholderText = "Enter provider ID or provider name...";
            txtSearch.Focus();
            txtSearch.SelectAll();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            string text = txtSearch.Text;
            if (text.Length > 0 && cbbFilter.SelectedIndex == 0)
            {
                int temp;
                if (!int.TryParse(text, out temp))
                {
                    txtSearch.SelectAll();
                    return;
                }
            }
            if (e.KeyCode == Keys.Enter)
                SearchContract();
        }

        private void tlpPictureSide_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).DisplayRectangle,
                Color.Transparent, 0, ButtonBorderStyle.Solid,
                Color.Black, 2, ButtonBorderStyle.Solid,
                Color.Transparent, 0, ButtonBorderStyle.Solid,
                Color.Transparent, 0, ButtonBorderStyle.Solid);
        }

        private void rbPold_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPold.Checked)
            {
                txtPname.Hide();
                cbbPname.Show();
                cbbPname.Text = contractDetail.Prov.Name;
                txtPaddress.SelectionStart = 0;
            }
            else
            {
                cbbPname.Hide();
                txtPname.Show();
                cbbPname.SelectedIndex = -1;
            }
        }

        private void btnTick_Click(object sender, EventArgs e)
        {
            if (lbSideBarTitle.Text.ToLower().Contains("detail"))
            {
                lbSideBarTitle.Text = "Edit Contract";
                btnTick.Image = global::Manage_Store.Properties.Resources.tick;
                btnSideBarConfirm.Enabled = true;
                pnGeneralInformation.Enabled = true;
                foreach (Control c in gbImportedItemInformation.Controls)
                    c.Enabled = true;
            }
            else
            {
                lbSideBarTitle.Text = "Detail Contract";
                btnTick.Image = global::Manage_Store.Properties.Resources.edit2;
                btnSideBarConfirm.Enabled = false;
                pnGeneralInformation.Enabled = false;
                foreach (Control c in gbImportedItemInformation.Controls)
                    c.Enabled = false;
                pnGoodsView.Enabled = true;
                btnSideBarConfirm.PerformClick();
            }
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            tlpWrapper.ColumnStyles[1].Width = 0;
        }

        private void btnSideBarCancel_Click(object sender, EventArgs e)
        {
            btnDetail.PerformClick();
        }

        private void btnSideBarConfirm_Click(object sender, EventArgs e)
        {
            int cid = int.Parse(txtCid.Text);
            string pname = rbPold.Checked ? cbbPname.Text : txtPname.Text;
            string paddress = txtPaddress.Text;
            string pphonenumber = txtPphoneNumber.Text;
            int eid = int.Parse(txtEid.Text);
            string cdate = dtpTime.Value.ToString("yyyy-MM-dd hh:mm:ss");
            foreach (GoodsView gp in tlpGoodsInContract.Controls)
            {
                int cquantity = gp.Quantity;
                double cprice = gp.Price;
                string gname = gp.g.Name;
                string unit = gp.g.Name;
                double gprice = gp.g.Price;
                string gphoto = gp.g.Image ? root.ProjectPath() + root.imageGoods + gname.Replace(' ', '_') + ".png" : null;
                string message = bll.UpdateInfomationContract(cid, gname, unit, gprice, gphoto, pname, paddress, pphonenumber, eid, cdate, cquantity, cprice);
                if (!message.ToLower().Contains("successful"))
                {
                    MessageBox.Show(gname);
                    MessageBox.Show(message, "RESPONSE");
                    return;
                }
            }
            ReloadGoodsReceipt();
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            ((GoodsView)tlpGoodsInContract.Tag).UpdateQuantity((int)nudQuantity.Value);
        }

        private void txtImportPrice_TextChanged(object sender, EventArgs e)
        {
            ((GoodsView)tlpGoodsInContract.Tag).Price = double.Parse(root.TurnOffMoneyFormat(txtImportPrice.Text));
        }

        private void txtImportPrice_Enter(object sender, EventArgs e)
        {
            txtImportPrice.Text = root.TurnOffMoneyFormat(txtImportPrice.Text);
        }

        private void txtImportPrice_Leave(object sender, EventArgs e)
        {
            txtImportPrice.Text = root.MoneyFormat(txtImportPrice.Text);
        }

        private void rbGnew2_CheckedChanged(object sender, EventArgs e)
        {
            txtGname2.Visible = true;
            cbbGname2.Visible = false;
            cbbUnit2.Enabled = true;
            txtSellingPrice2.Enabled = true;
            tlpPictureWrapper2.Enabled = true;
            txtUrl2.Clear();
            pbPicture2.Image = Image.FromFile(root.ProjectPath() + root.imageGoods + "addGoods.png");
            pbPicture2.Tag = false;
            btnAddGoods.Enabled = true;
        }

        private void rbGold2_CheckedChanged(object sender, EventArgs e)
        {
            txtGname2.Visible = false;
            cbbGname2.Visible = true;
            cbbUnit2.Enabled = false;
            txtSellingPrice2.Enabled = false;
            tlpPictureWrapper2.Enabled = false;
        }

        private void btnChangePicture2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            openFile.ShowDialog();
            if (string.IsNullOrEmpty(openFile.FileName))
                return;
            txtUrl2.Text = openFile.FileName;
            pbPicture2.Image = Image.FromFile(openFile.FileName);
            pbPicture2.Tag = true;
        }

        private void btnDeletePicture2_Click(object sender, EventArgs e)
        {
            txtUrl2.Text = "";
        }

        private void txtUrl2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrl2.Text))
            {
                pbPicture2.Image = Image.FromFile(root.ProjectPath() + root.imageGoods + "addGoods.png");
                pbPicture2.Tag = false;
            }
            else if (!File.Exists(txtUrl2.Text))
            {
                pbPicture2.Image = Image.FromFile(root.ProjectPath() + root.imageGoods + "notFound.png");
                txtUrl2.FocusedState.BorderColor = Color.Red;
                pbPicture2.Tag = false;
            }
            else 
            {
                txtUrl2.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
                pbPicture2.Image = Image.FromFile(txtUrl2.Text);
                pbPicture2.Tag = true;
            }
        }

        private void btnAddGoods_Click(object sender, EventArgs e)
        {
            string name = rbGold2.Checked ? cbbGname2.Text : txtGname2.Text;
            string unit = cbbUnit2.Text;
            double sellingPrice = double.Parse(root.TurnOffMoneyFormat(txtSellingPrice2.Text));
            bool photo = (bool)pbPicture2.Tag;
            int quantity = (int)nudQuantity2.Value;
            double importPrice = double.Parse(root.TurnOffMoneyFormat(txtImportPrice2.Text));
            foreach (GoodsView gv in tlpGoodsView2.Controls)
                if (gv.g.Name == name)
                    tlpGoodsView2.Controls.Remove(gv);
            tlpGoodsView2.Controls.Add(new GoodsView(new Goods(-1, name, unit, sellingPrice, 0, true, photo, txtUrl2.Text), 
                quantity, importPrice, false));
        }

        private void txtImportPrice2_Enter(object sender, EventArgs e)
        {
            txtImportPrice2.Text = root.TurnOffMoneyFormat(txtImportPrice2.Text);
        }

        private void txtImportPrice2_Leave(object sender, EventArgs e)
        {
            txtImportPrice2.Text = root.MoneyFormat(txtImportPrice2.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult chosen = root.MyMessageBox("Do you want to delete this contract or this goods in contract?",
                "WARNING", "Delete contract", "Delete goods", "Cancel");
            DataTable dt = (DataTable)dgvContract.DataSource;
            int row = dgvContract.CurrentRow.Index;
            int cid = 0;
            for (int i = row; ; i--)
                if (dt.Rows[i]["CID"] != DBNull.Value)
                {
                    cid = (int)dt.Rows[i]["CID"];
                    break;
                }
            string message = null;
            if (chosen == DialogResult.Yes)
            {
                message = bll.DeleteContract(cid);
                if (message != null)
                    MessageBox.Show(message);
            }
            else if (chosen == DialogResult.No)
            {
                string gname = (string)dt.Rows[row]["Goods name"];
                message = bll.DeleteGoodsInContract(cid, gname);
                if (message != null)
                    MessageBox.Show(message);
            }
            else
                return;
            ReloadGoodsReceipt();
        }

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            int cid = bll.GetNewContractID();
            string pname = cbbPname2.Text;
            int eid = fMain.Profile.Id;
            string date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string message = null;
            foreach (GoodsView gv in tlpGoodsView2.Controls)
            {
                string gname = gv.g.Name;
                string unit = gv.g.Unit;
                double gprice = gv.g.Price;
                string gphoto = gv.g.Image ? root.imageGoods + gname.Replace(' ', '_') + ".png" : null;
                int cquantity = gv.Quantity;
                double cprice = gv.Price;
                message = bll.InsertContract(cid, gname, unit, gprice, gphoto, pname, eid, date, cquantity, cprice);
                if (!message.ToLower().Contains("successful"))
                {
                    MessageBox.Show(message);
                    return;
                }
                string url = gv.g.Url;
                if (gv.g.Image && !string.IsNullOrEmpty(url))
                {
                    pbPicture2.Image.Dispose();
                    gv.Dispose();
                    string mess = root.UpdateImageLocation(url, gphoto, root.ProjectPath() + gphoto);
                    if (mess != null)
                        MessageBox.Show(mess);
                }
            }
            MessageBox.Show("Insert contract successful!", "Notification");
        }

        private void btnDeleteSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
        }

        private void txtSellingPrice2_Enter(object sender, EventArgs e)
        {
            txtSellingPrice2.Text = root.TurnOffMoneyFormat(txtSellingPrice2.Text);
        }

        private void txtSellingPrice2_Leave(object sender, EventArgs e)
        {
            txtSellingPrice2.Text = root.MoneyFormat(txtSellingPrice2.Text);
        }

        private void rbPnew_CheckedChanged(object sender, EventArgs e)
        {
            txtPname.Clear();
            txtPaddress.Clear();
            txtPphoneNumber.Clear();
        }

        private void cbbPname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dt_provider == null)
                return;
            foreach (DataRow dr in dt_provider.Rows)
                if ((string)dr["Name"] == cbbPname.Text)
                {
                    txtPid.Text = dr["ID"].ToString();
                    txtPaddress.Text = (string)dr["Address"];
                    txtPphoneNumber.Text = (string)dr["Phone Number"];
                    break;
                }
        }

        private void btnSideBar2Cancel_Click(object sender, EventArgs e)
        {
            btnDetail.PerformClick();
        }

        private void cbbGname2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)cbbGname2.DataSource;
            foreach (DataRow dr in dt.Rows) 
                if ((string)dr["Name"] == cbbGname2.Text)
                {
                    cbbUnit2.Text = (string)dr["unit"];
                    txtSellingPrice2.Text = root.MoneyFormat(dr["Price"].ToString());
                    string url = root.ProjectPath() + root.imageGoods;
                    if ((bool)dr["Image"])
                        url += cbbGname2.Text.Replace(' ', '_') + ".png";
                    else
                        url += "default.png";
                    txtUrl2.Text = url;
                }
        }

        private void cbbItemsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gname = cbbItemsName.Text;
            if (string.IsNullOrEmpty(gname))
                return;
            string url = root.ProjectPath() + root.imageGoods + gname.Replace(' ', '_') + ".png";
            if (File.Exists(url))
            {
                pbPictureSideBar.Image = Image.FromFile(url);
                txtUrl.Text = url;
            }
            else
            {
                pbPictureSideBar.Image = Image.FromFile(root.ProjectPath() + root.imageGoods + "default.png");
                txtUrl.Text = string.Empty;
            }
            Goods temp = contractDetail.Goods[gname];
            txtGid.Text = temp.Id.ToString();
            cbbUnit.Text = temp.Unit;
            txtItemPrice.Text = root.MoneyFormat(temp.Price.ToString());
            //GoodsPreview temp2 = (GoodsPreview)tlpPreview.Tag;
            GoodsView temp2 = (GoodsView)tlpGoodsInContract.Controls[cbbItemsName.Text];
            nudQuantity.Value = temp2.Quantity;
            txtImportPrice.Text = root.MoneyFormat(temp2.Price.ToString());
        }
    }
}
