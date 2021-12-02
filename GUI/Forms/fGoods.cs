using BLL;
using GUI.DefinedFramework;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace GUI
{
    public partial class fGoods : Form
    {
        private BLL_Goods bll = new BLL_Goods();
        public fGoods()
        {
            InitializeComponent();
            tlpWrapper.ColumnStyles[1].Width = 0;

            BackColor = root.screenColor;
            tlpWrapper.BackColor = root.screenColor;
            dgvGoods.ThemeStyle.BackColor = root.screenColor;
            dgvGoods.GridColor = root.screenColor;
            dgvGoods.DefaultCellStyle.ForeColor = Color.Black;
            dgvGoods.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvGoods.ColumnHeadersDefaultCellStyle.SelectionBackColor = root.goodsPrimaryColor;
            pnSearchAndFunction.FillColor = root.backColorComponentGoods;
            pnFunctions.FillColor = root.backColorComponentGoods;
            btnAllGoods.FillColor = root.goodsPrimaryColor;
            btnStocking.FillColor = root.goodsPrimaryColor;
            btnSoldOut.FillColor = root.goodsPrimaryColor;
            btnStopSelling.FillColor = root.goodsPrimaryColor;
            btnDetail.FillColor = root.goodsPrimaryColor;
            btnAdd.FillColor = root.goodsPrimaryColor;
            pnSearch.BorderColor = root.goodsPrimaryColor;
            txtSearch.FillColor = root.backColorComponentGoods;
            pnSideBar.FillColor = root.sideBarColor;
            tlpPictureSide.BackColor = root.componentInSideBarColor;
            pnStateOptionWrapper.FillColor = root.componentInSideBarColor;
        }

        private void fGoods_Load(object sender, EventArgs e)
        {
            btnAllGoods.PerformClick();
            if (dgvGoods.DataSource == null)
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
            btnDeleteSearch.Hide();
            lbTypeInput.Hide();

            fMain.beforeForm = 2;
        }

        private void ReloadData()
        {
            int row = dgvGoods.CurrentCell.RowIndex, col = dgvGoods.CurrentCell.ColumnIndex;
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                if (btnStocking.FillColor == root.buttonChoosingGoods)
                    btnStocking.PerformClick();
                else if (btnSoldOut.FillColor == root.buttonChoosingGoods)
                    btnSoldOut.PerformClick();
                else if (btnStopSelling.FillColor == root.buttonChoosingGoods)
                    btnStopSelling.PerformClick();
                else
                    btnAllGoods.PerformClick();
            }
            else
                btnSearch_Click(btnSearch, new EventArgs());
            if (dgvGoods.Rows.Count > 0)
            {
                dgvGoods.CurrentCell = dgvGoods[col, row];
                btnDetail.PerformClick();
            }
        }

        private void CustomDataGridViewGoods()
        {
            if (dgvGoods.Rows.Count == 0)
            {
                txtSearch.SelectAll();
                pnSearch.BorderColor = Color.FromArgb(240, 67, 80);
            }
            else
                pnSearch.BorderColor = root.goodsPrimaryColor;
            dgvGoods.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            foreach (DataGridViewColumn col in dgvGoods.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font(new FontFamily("Poppins"), 12, FontStyle.Bold);
                col.HeaderCell.Style.ForeColor = Color.BlanchedAlmond;
            }

            dgvGoods.DefaultCellStyle.Font = new Font(new FontFamily("Roboto"), 12, FontStyle.Bold);
            dgvGoods.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvGoods.Columns["ID"].MinimumWidth = 60;
            dgvGoods.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGoods.Columns["Unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvGoods.Columns["Unit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGoods.Columns["Price"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvGoods.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGoods.Columns["Price"].DefaultCellStyle.Format = "#,##0 đ";
            dgvGoods.Columns["Profit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvGoods.Columns["Profit"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvGoods.Columns["Profit"].DefaultCellStyle.Format = "#,##0 đ";
            dgvGoods.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvGoods.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGoods.Columns["Selling"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvGoods.Columns["Selling"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGoods.Columns["Image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvGoods.Columns["Image"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnSearch_Paint(object sender, PaintEventArgs e)
        {
            Panel searchIcon = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, searchIcon.DisplayRectangle,
                Color.Transparent, 0, ButtonBorderStyle.Solid,
                Color.Transparent, 0, ButtonBorderStyle.Solid,
                Color.FromArgb(200, 200, 200), 2, ButtonBorderStyle.Solid,
                Color.Transparent, 0, ButtonBorderStyle.Solid);
        }

        private void btnAllGoods_Click(object sender, EventArgs e)
        {
            string error = null;
            DataTable dt = bll.GetGoodsTable(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvGoods.DataSource = null;
                ChangeGoodsType(btnAllGoods);
                return;
            }
            dgvGoods.DataSource = dt;
            CustomDataGridViewGoods();
            ChangeGoodsType(btnAllGoods);
        }

        private void btnStocking_Click(object sender, EventArgs e)
        {
            string error = null;
            DataTable dt = bll.GetStokingGoodTable(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvGoods.DataSource = null;
                ChangeGoodsType(btnStocking);
                return;
            }
            dgvGoods.DataSource = dt;
            CustomDataGridViewGoods();
            ChangeGoodsType(btnStocking);
        }

        private void btnSoldOut_Click(object sender, EventArgs e)
        {
            string error = null;
            DataTable dt = bll.GetSoldOutGoodTable(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvGoods.DataSource = null;
                ChangeGoodsType(btnSoldOut);
                return;
            }
            dgvGoods.DataSource = dt;
            CustomDataGridViewGoods();
            ChangeGoodsType(btnSoldOut);
        }

        private void btnStopSelling_Click(object sender, EventArgs e)
        {
            string error = null;
            DataTable dt = bll.GetStopSellingGoodTable(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvGoods.DataSource = null;
                ChangeGoodsType(btnStopSelling);
                return;
            }
            dgvGoods.DataSource = dt;
            CustomDataGridViewGoods();
            ChangeGoodsType(btnStopSelling);
        }

        private void btnComingSoon_Click(object sender, EventArgs e)
        {
            string error = null;
            DataTable dt = bll.GetComingSoonGoodTable(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvGoods.DataSource = null;
                ChangeGoodsType(btnStopSelling);
                return;
            }
            dgvGoods.DataSource = dt;
            CustomDataGridViewGoods();
            ChangeGoodsType(btnStopSelling);
        }

        private void ChangeGoodsType(object sender)
        {
            foreach (Guna2Button c in tlpGoodsType.Controls)
                c.FillColor = root.goodsPrimaryColor;
            (sender as Guna2Button).FillColor = root.buttonChoosingGoods;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = txtSearch.Text, error = null;
            DataTable dt;
            string state = null;
            if (btnStocking.FillColor == root.buttonChoosingGoods)
                state = "STOCKING";
            else if (btnSoldOut.FillColor == root.buttonChoosingGoods)
                state = "SOLD OUT";
            else if (btnStopSelling.FillColor == root.buttonChoosingGoods)
                state = "STOP SELLING";
            if (root.IsNummerics(text))
                dt = bll.SearchGoods(Convert.ToInt32(text), state, ref error);
            else
                dt = bll.SearchGoods(text, state, ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvGoods.DataSource = null;
                return;
            }
            dgvGoods.DataSource = dt;
            CustomDataGridViewGoods();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
                btnDeleteSearch.Hide();
            else
            {
                pnSearch.BorderColor = root.goodsPrimaryColor;
                btnDeleteSearch.Show();
            }
        }

        private void btnDeleteSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
            pnSearch.BorderColor = root.goodsPrimaryColor;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(btnSearch, new EventArgs());
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dgvGoods.Rows.Count == 0)
                return;
            int row = dgvGoods.CurrentCell.RowIndex;
            string error = null;
            DataRow dr = ((DataTable)dgvGoods.DataSource).Rows[row];
            if (error != null)
            {
                MessageBox.Show(error);
                return;
            }

            txtName.Text = dr["Name"].ToString();
            txtID.Text = dr["ID"].ToString();
            txtQuantity.Text = dr["Quantity"].ToString();
            string temp = root.ProjectPath() + root.imageGoods + txtName.Text.Replace(' ', '_') + ".png";
            if (File.Exists(temp))
            {
                pbPicture.Image = Image.FromFile(temp);
                txtUrlImage.Text = temp;
            }
            else
            {
                pbPicture.Image = Image.FromFile(root.ProjectPath() + root.imageGoods + "notFound.png");
                txtUrlImage.Clear();
            }
            nudPrice.Value = decimal.Parse(dr["Price"].ToString());
            cbbUnit.Text = dr["Unit"].ToString();
            if ((bool)dr["Selling"])
                rbSelling.Checked = true;
            else
                rbStopSelling.Checked = true;
                

            lbSideBarTitle.Text = "Detail Information";
            btnTick.Image = Manage_Store.Properties.Resources.edit2;

            //txtName.Enabled = false;
            //cbbUnit.Enabled = false;
            //nudPrice.Enabled = false;
            //pnState.Enabled = false;
            //txtUrlImage.Enabled = false;
            //btnChangePicture.Enabled = false;
            //btnDeletePicture.Enabled = false;
            pnSideBarBody.Enabled = false;
            btnSideBarConfirm.Enabled = false;
            tlpWrapper.ColumnStyles[1].Width = 550;
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            tlpWrapper.ColumnStyles[1].Width = 0;
            btnDetail.Enabled = true;
            btnAdd.Enabled = true;
            txtUrlImage.Clear();
        }

        private void btnSideBarCancel_Click(object sender, EventArgs e)
        {
            btnCollapse_Click(btnCollapse, new EventArgs());
        }

        private void btnTick_Click(object sender, EventArgs e)
        {
            if (lbSideBarTitle.Text.ToLower().Contains("detail"))
            {
                lbSideBarTitle.Text = "Edit Information";
                btnTick.Image = global::Manage_Store.Properties.Resources.tick;
                //txtName.Enabled = true;
                //cbbUnit.Enabled = true;
                //nudPrice.Enabled = true;
                //txtQuantity.Enabled = true;
                //pnState.Enabled = true;
                //txtUrlImage.Enabled = true;
                //btnChangePicture.Enabled = true;
                //btnDeletePicture.Enabled = true;
                pnSideBarBody.Enabled = true;
                btnSideBarConfirm.Enabled = true;
            }
            else if (lbSideBarTitle.Text.ToLower().Contains("edit"))
                btnSideBarConfirm_Click(btnSideBarConfirm, new EventArgs());
        }

        private void btnSideBarConfirm_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(txtID.Text, out id);
            string name = txtName.Text;
            string unit = cbbUnit.Text;
            double price = (double)nudPrice.Value;
            bool state = rbSelling.Checked;
            string relativeUrl = txtUrlImage.FocusedState.BorderColor == Color.Red || string.IsNullOrEmpty(txtUrlImage.Text) ?
                null : root.imageGoods + name.Replace(' ', '_') + ".png";
            string newPath = root.ProjectPath() + root.imageGoods + name.Replace(' ', '_') + ".png";
            string message = null;
            if (lbSideBarTitle.Text.ToLower().Contains("edit"))
            {
                message = bll.UpdateInformationGoods(id, name, unit, price, state, relativeUrl);
                if (!message.ToLower().Contains("successful"))
                    MessageBox.Show(message, "RESPONSE");
            }
            else if (lbSideBarTitle.Text.ToLower().Contains("add"))
            {
                if (string.IsNullOrEmpty(name))
                {
                    txtName.Focus();
                    lbTypeInput.Show();
                    return;
                }
                else if (string.IsNullOrEmpty(unit))
                {
                    cbbUnit.Focus();
                    lbTypeInput.Show();
                    return;
                }
                message = bll.InsertGoods(name, unit, price, relativeUrl);
                if (!message.ToLower().Contains("successful"))
                    MessageBox.Show(message, "RESPONSE");
            }
            if (!message.ToLower().Contains("failed"))
            {
                pbPicture.Image.Dispose();
                string ex = root.UpdateImageLocation(txtUrlImage.Text, relativeUrl, newPath);
                if (ex != null)
                    MessageBox.Show(ex);
            }

            int thisRow = dgvGoods.CurrentCell.RowIndex;
            ReloadData();
        }

        private void btnChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            openFile.ShowDialog();
            if (string.IsNullOrEmpty(openFile.FileName))
                return;
            txtUrlImage.Text = openFile.FileName;
            pbPicture.Image = Image.FromFile(openFile.FileName);
        }

        private void txtUrlImage_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(txtUrlImage.Text))
            {
                pbPicture.Image = Image.FromFile(root.ProjectPath() + root.imageGoods + "notFound.png");
                txtUrlImage.FocusedState.BorderColor = Color.Red;
            }
            else if (txtUrlImage.FocusedState.BorderColor == Color.Red)
            {
                txtUrlImage.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
                pbPicture.Image = Image.FromFile(txtUrlImage.Text);
            }
        }

        private void btnDeletePicture_Click(object sender, EventArgs e)
        {
            txtUrlImage.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvGoods.Rows.Count == 0)
                return;
            int row = dgvGoods.CurrentCell.RowIndex;
            int id = (int)dgvGoods.Rows[row].Cells["ID"].Value;
            string name = dgvGoods.Rows[row].Cells["Name"].Value.ToString();
            bool selling = (bool)dgvGoods.Rows[row].Cells["Selling"].Value;
            if (!selling)
            {
                MessageBox.Show("The goods is deleted from selling goods!", "NOTIFICATION");
                return;
            }
            DialogResult choose = MessageBox.Show("Are you sure to delete the goods with:\nID: "
                + name.Replace(' ', '_') + " \nName: \"" + name +"\"", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (choose == DialogResult.No)
                return;
            string message = bll.DeleteGoods(id);
            if (!message.ToLower().Contains("successful"))
                MessageBox.Show(message, "RESPONSE");

            ReloadData();
        }

        private void dgvGoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGoods.Rows.Count == 0)
                return;
            int row = dgvGoods.CurrentCell.RowIndex;
            if ((bool)dgvGoods["Selling", row].Value)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;

            if (tlpWrapper.ColumnStyles[1].Width > 0 && lbSideBarTitle.Text.ToLower().Contains("detail"))
            {
                btnDetail.PerformClick();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Enabled = true;
            cbbUnit.Enabled = true;
            nudPrice.Enabled = true;
            pnState.Enabled = false;
            rbSelling.Checked = true;
            txtUrlImage.Enabled = true;
            btnChangePicture.Enabled = true;
            btnDeletePicture.Enabled = true;
            btnSideBarConfirm.Enabled = true;
            tlpWrapper.ColumnStyles[1].Width = 550;

            lbSideBarTitle.Text = "Add Goods";
            txtName.Clear();
            cbbUnit.Text = "";
            txtID.Clear();
            nudPrice.Value = 1000;
            txtQuantity.Text = "0";
            txtUrlImage.Clear();
            pbPicture.Image = Image.FromFile(root.ProjectPath() + root.imageGoods + "addGoods.png");
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lbTypeInput.Hide();
        }

        private void cbbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTypeInput.Hide();
        }
    }
}
