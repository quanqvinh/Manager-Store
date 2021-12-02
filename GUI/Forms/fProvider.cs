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
    public partial class fProvider : Form
    {
        private BLL_Provider bll = new BLL_Provider();
        public fProvider()
        {
            InitializeComponent();
            tlpWrapper.ColumnStyles[1].Width = 0;

            BackColor = root.screenColor;
            tlpWrapper.BackColor = root.screenColor;
            dgvProvider.ThemeStyle.BackColor = root.screenColor;
            dgvProvider.GridColor = root.screenColor;
            dgvProvider.DefaultCellStyle.ForeColor = Color.Black;
            dgvProvider.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvProvider.ColumnHeadersDefaultCellStyle.SelectionBackColor = root.providerPrimaryColor;
            pnSearchAndFunction.FillColor = root.backColorComponentProvider;
            pnFunctions.FillColor = root.backColorComponentProvider;
            btnDetail.FillColor = root.providerPrimaryColor;
            btnAdd.FillColor = root.providerPrimaryColor;
            pnSearch.BorderColor = root.providerPrimaryColor;
            txtSearch.FillColor = root.backColorComponentProvider;
            pnSideBar.FillColor = root.headerSideBarColor;
            pnSideBarBody.FillColor = root.sideBarColor;
            pnSideBarHeader.FillColor = root.headerSideBarColor;
            pnSideBarFooter.FillColor = root.footerSideBarColor;
        }

        private void fProvider_Load(object sender, EventArgs e)
        {
            string error = null;
            dgvProvider.DataSource = bll.GetAllProviders(ref error);
            if (dgvProvider.DataSource == null)
            {
                MessageBox.Show(error);
                fMain main = (fMain)Parent.Parent.Parent;
                switch (fMain.beforeForm)
                {
                    case 0: main.OpenHomePage(null, null); break;
                    case 1: main.OpenBillForm(null, null); break;
                    case 2: main.OpenGoodsForm(null, null); break;
                    case 3: main.OpenContractForm(null, null); break;
                    case 4: main.OpenProviderForm(null, null); break;
                    case 5: main.OpenEmployeeForm(null, null); break;
                    case 6: main.OpenCashFlowForm(null, null); break;
                }
                return;
            }
            if (error != null)
                MessageBox.Show(error);
            else
                CustomProviderTable();
            fMain.beforeForm = 1;
        }

        private void CustomProviderTable()
        {
            if (dgvProvider.Rows.Count == 0)
            {
                txtSearch.SelectAll();
                pnSearch.BorderColor = Color.FromArgb(240, 67, 80);
            }
            else
                pnSearch.BorderColor = root.providerPrimaryColor;
            dgvProvider.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            foreach (DataGridViewColumn col in dgvProvider.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font(new FontFamily("Poppins"), 12, FontStyle.Bold);
                col.HeaderCell.Style.ForeColor = Color.BlanchedAlmond;
            }

            dgvProvider.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProvider.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProvider.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProvider.Columns["Address"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProvider.Columns["Phone Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProvider.Columns["Phone Number"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProvider.Columns["Providing"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvProvider.Columns["Providing"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            int height = dgvProvider.ColumnHeadersHeight + SystemInformation.HorizontalScrollBarHeight + 50;
            foreach (DataGridViewRow row in dgvProvider.Rows)
                height += row.Height;
            dgvProvider.Height = height;
        }

        private void ReloadProvider()
        {
            string error = null;
            DataTable dt = bll.GetAllProviders(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvProvider.DataSource = null;
                return;
            }
            dgvProvider.DataSource = dt;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            lbHeaderTitle.Text = "Detail Provider";
            btnTick.Image = global::Manage_Store.Properties.Resources.edit2;
            int row = dgvProvider.CurrentCell.RowIndex;
            DataTable dt = (DataTable)dgvProvider.DataSource;
            txtPid.Text = dt.Rows[row]["ID"].ToString();
            if ((bool)dt.Rows[row]["Providing"])
                rbProviding.Checked = true;
            else
                rbStopProviding.Checked = true;
            txtPname.Text = (string)dt.Rows[row]["Name"];
            txtPaddress.Text = (string)dt.Rows[row]["Address"];
            txtPphoneNumber.Text = (string)dt.Rows[row]["Phone Number"];
            pnSideBarBody.Enabled = false;
            pnSideBarFooter.Enabled = false;

            tlpWrapper.ColumnStyles[1].Width = 550;
        }

        private void btnTick_Click(object sender, EventArgs e)
        {
            if (lbHeaderTitle.Text.ToLower().Contains("detail"))
            {
                lbHeaderTitle.Text = "Edit Provider";
                btnTick.Image = global::Manage_Store.Properties.Resources.tick;
                pnSideBarBody.Enabled = true;
                pnSideBarFooter.Enabled = true;
            }
            else
            {
                btnSideBarConfirm.PerformClick();
            }
        }

        private void btnSideBarConfirm_Click(object sender, EventArgs e)
        {
            if (lbHeaderTitle.Text.ToLower().Contains("edit"))
            {
                lbHeaderTitle.Text = "Detail Provider";
                btnTick.Image = global::Manage_Store.Properties.Resources.edit2;
                pnSideBarBody.Enabled = false;
                pnSideBarFooter.Enabled = false;

                int id = int.Parse(txtPid.Text);
                string name = txtPname.Text;
                string address = txtPaddress.Text;
                string phoneNumber = txtPphoneNumber.Text;
                bool providing = rbProviding.Checked;
                string message = bll.UpdateInformationProvider(id, name, address, phoneNumber, providing);
                if (message != null)
                    MessageBox.Show(message);
                ReloadProvider();
                btnDetail.PerformClick();
            }
            else if (lbHeaderTitle.Text.ToLower().Contains("add"))
            {
                string name = txtPname.Text;
                string address = txtPaddress.Text;
                string phoneNumber = txtPphoneNumber.Text;
                pnStateOption.Enabled = true;
                string message = bll.InsertProvider(name, address, phoneNumber);
                if (message != null)
                    MessageBox.Show(message);
                ReloadProvider();
                btnDetail.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("If you don't have any contract with provider, we will delete permanent. Unless we only disable this provider." +
                    "\nDo you want to delete ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
                return;
            int row = dgvProvider.CurrentRow.Index;
            int pid = (int)dgvProvider.Rows[row].Cells["ID"].Value;
            string message = bll.DeleteProvider(pid);
            if (message.ToLower().Contains("fail"))
            {
                string pname = (string)dgvProvider.Rows[row].Cells["Name"].Value;
                string paddress = (string)dgvProvider.Rows[row].Cells["Address"].Value;
                string pphoneNumber = (string)dgvProvider.Rows[row].Cells["Phone Number"].Value;
                message = bll.UpdateInformationProvider(pid, pname, paddress, pphoneNumber, false);
                MessageBox.Show("Disable provider successful!");
            }
            else
                MessageBox.Show("Delete successful!");
            ReloadProvider();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            tlpWrapper.ColumnStyles[1].Width = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pnSideBarBody.Enabled = true;
            pnSideBarFooter.Enabled = true;
            pnStateOption.Enabled = false;
            tlpWrapper.ColumnStyles[1].Width = 550;

            lbHeaderTitle.Text = "Add Provider";
            txtPid.Clear();
            rbProviding.Checked = true;
            txtPname.Clear();
            txtPaddress.Clear();
            txtPphoneNumber.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
                btnDeleteSearch.Visible = false;
            else
            {
                pnSearch.BorderColor = root.providerPrimaryColor;
                btnDeleteSearch.Visible = true;
            }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = txtSearch.Text, error = null;
            DataTable dt;
            if (root.IsNummerics(text))
                dt = bll.SearchProvider("id", int.Parse(text), ref error);
            else
                dt = bll.SearchProvider("name", text, ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvProvider.DataSource = null;
                return;
            }
            dgvProvider.DataSource = dt;
            CustomProviderTable();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(btnSearch, new EventArgs());
            }
        }
    }
}
