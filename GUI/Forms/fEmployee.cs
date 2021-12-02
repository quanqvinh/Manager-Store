using BLL;
using GUI.DefinedFramework;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class fEmployee : Form
    {
        private BLL_Employee bll = new BLL_Employee();
        public fEmployee()
        {
            InitializeComponent();
            tlpWrapper.ColumnStyles[1].Width = 0;
            btnDeleteSearch.Hide();
            BackColor = root.screenColor;
            tlpWrapper.BackColor = root.screenColor;
            dgvEmployees.ThemeStyle.BackColor = root.screenColor;
            dgvEmployees.GridColor = root.screenColor;
            dgvEmployees.DefaultCellStyle.ForeColor = Color.Black;
            dgvEmployees.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvEmployees.ColumnHeadersDefaultCellStyle.SelectionBackColor = root.employeePrimaryColor;
            pnSearchAndFunction.FillColor = root.backColorComponentEmployee;
            pnFunctions.FillColor = root.backColorComponentEmployee;
            btnAllRoles.FillColor = root.employeePrimaryColor;
            btnStaff.FillColor = root.employeePrimaryColor;
            btnStockManager.FillColor = root.employeePrimaryColor;
            btnRetiredEmployee.FillColor = root.employeePrimaryColor;
            btnDetail.FillColor = root.employeePrimaryColor;
            btnAdd.FillColor = root.employeePrimaryColor;
            pnSearch.BorderColor = root.employeePrimaryColor;
            txtSearch.FillColor = root.backColorComponentEmployee;
            pnSideBar.FillColor = root.sideBarColor;
            cbbFilter.FillColor = root.employeePrimaryColor;
            pnSearch.BorderColor = root.employeePrimaryColor;
            pnSideBarHeader.FillColor = root.headerSideBarColor;
            pnSideBarFooter.FillColor = root.footerSideBarColor;
            pnSideBar.FillColor = root.headerSideBarColor;
            pnSideBarBody.FillColor = root.sideBarColor;
            btnTick.DisabledState.FillColor = root.headerSideBarColor;
            tlpPictureSide.BackColor = root.componentInSideBarColor;
            pnStateOptionWrapper.FillColor = root.componentInSideBarColor;
            gbPersonalInformation.CustomBorderColor = root.headerSideBarColor;
            gbPersonalInformation.FillColor = root.componentInSideBarColor;
            gbWorkInformation.CustomBorderColor = root.headerSideBarColor;
            gbWorkInformation.FillColor = root.componentInSideBarColor;
        }

        private void fEmployee_Load(object sender, EventArgs e)
        {
            btnAllRoles.PerformClick();
            if (dgvEmployees.DataSource == null)
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

            fMain.beforeForm = 4;
        }

        private void CustomDataGridViewEmployee()
        {
            if (dgvEmployees.Rows.Count == 0 && txtSearch.Text.Length > 0)
                pnSearch.BorderColor = Color.Red;
            else
                pnSearch.BorderColor = root.employeePrimaryColor;
            dgvEmployees.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            foreach (DataGridViewColumn col in dgvEmployees.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font(new FontFamily("Poppins"), 12, FontStyle.Bold);
                col.HeaderCell.Style.ForeColor = Color.BlanchedAlmond;
            }

            dgvEmployees.DefaultCellStyle.Font = new Font(new FontFamily("Roboto"), 12, FontStyle.Bold);
            dgvEmployees.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvEmployees.Columns["ID"].MinimumWidth = 60;
            dgvEmployees.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmployees.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEmployees.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmployees.Columns["Birthday"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEmployees.Columns["Birthday"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEmployees.Columns["Birthday"].DefaultCellStyle.Format = "dd-MM-yyyy";
            dgvEmployees.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEmployees.Columns["Address"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmployees.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvEmployees.Columns["Gender"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmployees.Columns["Phone Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvEmployees.Columns["Phone Number"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmployees.Columns["Working Days"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvEmployees.Columns["Working Days"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmployees.Columns["Day's Wage"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvEmployees.Columns["Day's Wage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEmployees.Columns["Day's Wage"].DefaultCellStyle.Format = "#,##0 đ";
            dgvEmployees.Columns["Month Salary"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvEmployees.Columns["Month Salary"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEmployees.Columns["Month Salary"].DefaultCellStyle.Format = "#,##0 đ";
            dgvEmployees.Columns["Password"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEmployees.Columns["Password"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmployees.Columns["Role"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEmployees.Columns["Role"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmployees.Columns["Working"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvEmployees.Columns["Working"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEmployees.Columns["Image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvEmployees.Columns["Image"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            int width = 2, height = dgvEmployees.ColumnHeadersHeight + 1;
            foreach (DataGridViewColumn col in dgvEmployees.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font(new FontFamily("Poppins"), 12, FontStyle.Bold);
                col.HeaderCell.Style.ForeColor = Color.BlanchedAlmond;
                width += col.Width;
            }
            foreach (DataGridViewRow row in dgvEmployees.Rows)
                height += row.Height;
            dgvEmployees.Size = new Size(width, height);
        }

        private void btnAllRoles_Click(object sender, EventArgs e)
        {
            string error = null;
            DataTable dt = bll.GetAllEmployee(ref error);
            if (dt == null)
            {
                MessageBox.Show(error);
                return;
            }
            if (error != null)
            {
                MessageBox.Show(error);
                dgvEmployees.DataSource = null;
                ChangeEmployeeType(btnAllRoles);
                CustomDataGridViewEmployee();
                return;
            }
            dgvEmployees.DataSource = dt;
            ChangeEmployeeType(btnAllRoles);
            CustomDataGridViewEmployee();
            if (!string.IsNullOrEmpty(txtSearch.Text))
                SearchEmployee();
        }

        private void ChangeEmployeeType(object sender)
        {
            foreach (Guna2Button c in tlpEmployeeType.Controls)
                c.FillColor = root.employeePrimaryColor;
            (sender as Guna2Button).FillColor = root.buttonChoosingEmployee;
        }

        private void btnStockManager_Click(object sender, EventArgs e)
        {
            string error = null;
            DataTable dt = bll.GetStockManagers(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvEmployees.DataSource = null;
                ChangeEmployeeType(btnStockManager);
                CustomDataGridViewEmployee();
                return;
            }
            dgvEmployees.DataSource = dt;
            ChangeEmployeeType(btnStockManager);
            CustomDataGridViewEmployee();
            if (!string.IsNullOrEmpty(txtSearch.Text))
                SearchEmployee();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            string error = null;
            DataTable dt = bll.GetStaffs(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvEmployees.DataSource = null;
                ChangeEmployeeType(btnStaff);
                CustomDataGridViewEmployee();
                return;
            }
            dgvEmployees.DataSource = dt;
            ChangeEmployeeType(btnStaff);
            CustomDataGridViewEmployee();
            if (!string.IsNullOrEmpty(txtSearch.Text))
                SearchEmployee();
        }

        private void btnRetiredEmployee_Click(object sender, EventArgs e)
        {
            string error = null;
            DataTable dt = bll.GetRetiredEmployee(ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvEmployees.DataSource = null;
                ChangeEmployeeType(btnRetiredEmployee);
                CustomDataGridViewEmployee();
                return;
            }
            dgvEmployees.DataSource = dt;
            ChangeEmployeeType(btnRetiredEmployee);
            CustomDataGridViewEmployee();
            if (!string.IsNullOrEmpty(txtSearch.Text))
                SearchEmployee();
        }

        private void txtSearch_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as Control).DisplayRectangle,
                Color.FromArgb(200, 200, 200), 2, ButtonBorderStyle.Solid,
                Color.Transparent, 0, ButtonBorderStyle.Solid,
                Color.Transparent, 0, ButtonBorderStyle.Solid,
                Color.Transparent, 0, ButtonBorderStyle.Solid);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            pnSearch.BorderColor = root.employeePrimaryColor;
            if (txtSearch.Text.Length > 0)
            {
                btnDeleteSearch.Show();
                SearchEmployee();
            }
            else
            {
                btnDeleteSearch.Hide();
                foreach (Guna2Button c in tlpEmployeeType.Controls)
                    if (c.FillColor == root.buttonChoosingEmployee)
                        c.PerformClick();
                txtSearch.Focus();
            }
        }

        private void btnDeleteSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
        }

        private void SearchEmployee()
        {
            string searchBy = cbbFilter.Text, text = txtSearch.Text;
            //if (btnRetiredEmployee.FillColor == root.darkerBackGroundSideBarEmployee)
            //    return;
            string role = null;
            foreach (Guna2Button c in tlpEmployeeType.Controls)
                if (c.FillColor == root.buttonChoosingEmployee)
                {
                    role = c.Text;
                    break;
                }
            if (role.ToLower().Contains("all"))
                role = null;
            string error = null;
            DataTable dt = bll.SearchEmployee(searchBy, text, role, ref error);
            if (error != null)
            {
                MessageBox.Show(error);
                dgvEmployees.DataSource = null;
                txtSearch.Focus();
                pnSearch.BorderColor = root.employeePrimaryColor;
                return;
            }
            dgvEmployees.DataSource = dt;
            CustomDataGridViewEmployee();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tlpWrapper.ColumnStyles[1].Width > 0)
                btnDetail.PerformClick();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            lbSideBarTitle.Text = "Detail Information";
            btnChangePicture.Enabled = false;
            btnDeletePicture.Enabled = false;
            gbPersonalInformation.Enabled = false;
            gbWorkInformation.Enabled = false;
            btnTick.Image = global::Manage_Store.Properties.Resources.edit2;

            int row = dgvEmployees.CurrentCell.RowIndex;
            DataRow dr = ((DataTable)dgvEmployees.DataSource).Rows[row];
            txtName.Text = dr["Name"].ToString();
            txtPhoneNumber.Text = dr["Phone Number"].ToString();
            txtID.Text = dr["ID"].ToString();
            dtpBirthday.Text = dr["Birthday"].ToString();
            if (dr["Gender"].ToString().ToLower().Contains("nam"))
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;
            txtAddress.Text = dr["Address"].ToString();
            txtPassword.Text = dr["Password"].ToString();
            string url = root.ProjectPath() + root.imageEmployees + txtPhoneNumber.Text + ".png";
            if (dr["Image"] != null && File.Exists(url))
            {
                pbPiture.Image = Image.FromFile(url);
                txtUrl.Text = url;
            }
            else
            {
                pbPiture.Image = Image.FromFile(root.ProjectPath() + root.imageEmployees + "tempAvatar.png");
                txtUrl.Clear();
            }
            if ((bool)dr["Working"])
                rbWorking.Checked = true;
            else
                rbQuitWork.Checked = true;

            if ((string)dr["Role"] == "ADMIN")
            {
                nudWorkingDays.Value = 0;
                nudDayWage.Value = 0;
                txtMonthSalary.Text = root.MoneyFormat("0");
            }
            else
            {
                nudWorkingDays.Value = decimal.Parse(dr["Working Days"].ToString());
                nudDayWage.Value = decimal.Parse(dr["Day's Wage"].ToString());
                txtMonthSalary.Text = root.MoneyFormat(dr["Month Salary"].ToString());
            }
            
            btnSideBarConfirm.Text = "Save";

            tlpWrapper.ColumnStyles[1].Width = 600;
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            tlpWrapper.ColumnStyles[1].Width = 0;
        }

        private void btnSideBarCancel_Click(object sender, EventArgs e)
        {
            btnCollapse.PerformClick();
        }

        private void btnTick_Click(object sender, EventArgs e)
        {
            if (lbSideBarTitle.Text.ToLower().Contains("detail"))
            {
                lbSideBarTitle.Text = "Edit Information";
                btnTick.Image = global::Manage_Store.Properties.Resources.tick;
                btnChangePicture.Enabled = true;
                btnDeletePicture.Enabled = true;
                gbPersonalInformation.Enabled = true;
                gbWorkInformation.Enabled = true;
                btnSideBarConfirm.Enabled = true;
                pnStateOption.Enabled = true;
                nudDayWage.Enabled = true;
                nudWorkingDays.Enabled = true;
                txtPassword.Enabled = true;
            }
            else if (lbSideBarTitle.Text.ToLower().Contains("edit"))
            {
                lbSideBarTitle.Text = "Detail Information";
                btnTick.Image = global::Manage_Store.Properties.Resources.edit2;
                btnChangePicture.Enabled = false;
                btnDeletePicture.Enabled = false;
                gbPersonalInformation.Enabled = false;
                gbWorkInformation.Enabled = false;
                btnSideBarConfirm.Enabled = false;
                btnSideBarConfirm.PerformClick();
            }
        }

        private void EnableAllControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.Enabled = true;
                EnableAllControls(c);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lbSideBarTitle.Text = "Add employee";
            btnChangePicture.Enabled = true;
            btnDeletePicture.Enabled = true;
            gbPersonalInformation.Enabled = true;
            gbWorkInformation.Enabled = true;
            pnStateOption.Enabled = false;
            nudDayWage.Enabled = false;
            nudWorkingDays.Enabled = false;
            txtPassword.Enabled = false;
            btnTick.Enabled = true;
            btnTick.Image = global::Manage_Store.Properties.Resources.tick;
            btnSideBarConfirm.Enabled = true;
            btnSideBarConfirm.Text = "Add";
            txtName.Clear();
            txtPhoneNumber.Clear();
            txtID.Clear();
            txtAddress.Clear();
            txtPassword.Clear();
            txtUrl.Clear();
            dtpBirthday.Text = "01/01/2001";
            rbMale.Checked = true;
            rbWorking.Checked = true;
            cbbRole.SelectedIndex = 0;
            nudWorkingDays.Value = 0;
            nudDayWage.Value = 160000;
            txtMonthSalary.Text = "0 vnđ";

            tlpWrapper.ColumnStyles[1].Width = 600;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                btnDeleteSearch_Click(btnDeleteSearch, new EventArgs());
            }
        }

        private void btnChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            openFile.ShowDialog();
            if (string.IsNullOrEmpty(openFile.FileName))
                return;
            txtUrl.Text = openFile.FileName;
            pbPiture.Image = Image.FromFile(openFile.FileName);
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrl.Text))
            {
                pbPiture.Image = Image.FromFile(root.ProjectPath() + root.imageEmployees + "tempAvatar.png");
                txtUrl.FocusedState.BorderColor = Color.Red;
            }
            else if (!File.Exists(txtUrl.Text))
            {
                pbPiture.Image = Image.FromFile(root.ProjectPath() + root.imageEmployees + "notFound.png");
                txtUrl.FocusedState.BorderColor = Color.Red;
            }
            else if (txtUrl.FocusedState.BorderColor == Color.Red)
            {
                txtUrl.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
                pbPiture.Image = Image.FromFile(txtUrl.Text);
            }
        }

        private void btnDeletePicture_Click(object sender, EventArgs e)
        {
            txtUrl.Text = "";
        }

        private void btnSideBarConfirm_Click(object sender, EventArgs e)
        {
            int id;
            string name = txtName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");
            bool male = rbMale.Checked;
            string address = txtAddress.Text;
            string password = txtPassword.Text;
            bool working = rbWorking.Checked;
            string role = cbbRole.Text.ToUpper();
            int workingDay = (int)nudWorkingDays.Value;
            double dayWage = (double)nudDayWage.Value;
            string relativeUrl = null, absoluteUrl = null;
            if (int.TryParse(txtID.Text, out id))
            {
                if (!(string.IsNullOrEmpty(txtUrl.Text) || txtUrl.FocusedState.BorderColor == Color.Red))
                    relativeUrl = root.imageEmployees + phoneNumber + ".png";
                absoluteUrl = root.ProjectPath() + root.imageEmployees + phoneNumber + ".png";
            }
            string message = string.Empty;
            if (btnSideBarConfirm.Text.ToLower().Contains("add"))
            {
                string url = txtUrl.FocusedState.BorderColor == Color.Red || string.IsNullOrEmpty(txtUrl.Text) ? 
                    null : root.imageEmployees;
                message = bll.AddEmployee(name, birthday, address, male, phoneNumber, role, url);
                if (!message.ToLower().Contains("successful"))
                    MessageBox.Show(message, "RESPONSE");
                btnSideBarConfirm.Enabled = false;
                if (!message.ToLower().Contains("failed"))
                {
                    pbPiture.Image.Dispose();
                    string ex = root.UpdateImageLocation(txtUrl.Text, url, root.ProjectPath() + root.imageEmployees + phoneNumber + ".png");
                    if (ex != null)
                        MessageBox.Show(ex);
                }
            }
            else if (btnSideBarConfirm.Text.ToLower().Contains("save"))
            {
                message = bll.UpdateInformationEmployee(id, name, phoneNumber, birthday, male, address, password, relativeUrl, working, role, workingDay, dayWage);
                if (!message.ToLower().Contains("successful"))
                    MessageBox.Show(message, "RESPONSE");
                btnSideBarConfirm.Enabled = false;
                if (!message.ToLower().Contains("failed"))
                {
                    pbPiture.Image.Dispose();
                    string ex = root.UpdateImageLocation(txtUrl.Text, relativeUrl, absoluteUrl);
                    if (ex != null)
                        MessageBox.Show(ex);
                }
            }
            ReloadData(true);
        }

        private void ReloadData(bool select)
        {
            int row = dgvEmployees.CurrentCell.RowIndex, col = dgvEmployees.CurrentCell.ColumnIndex;
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                if (btnAllRoles.FillColor == root.buttonChoosingEmployee)
                    btnAllRoles.PerformClick();
                else if (btnStaff.FillColor == root.buttonChoosingEmployee)
                    btnStaff.PerformClick();
                else if (btnStockManager.FillColor == root.buttonChoosingEmployee)
                    btnStockManager.PerformClick();
                else
                    btnRetiredEmployee.PerformClick();
            }
            else
                SearchEmployee();
            if (select && dgvEmployees.Rows.Count > 0)
            {
                dgvEmployees.CurrentCell = dgvEmployees[col, row];
                btnDetail.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult chose = root.MyMessageBox("Do you want to delete or only disable account to keep infomation?",
                "DELETE OPTION", "Delete", "Only disable", "Cancel");
            string message = string.Empty;
            int row = dgvEmployees.CurrentRow.Index;
            int id = (int)dgvEmployees.Rows[row].Cells["ID"].Value;
            if (chose == DialogResult.Yes)
            {
                message = bll.DeleteEmployee(id);
                string url = root.ProjectPath() + root.imageEmployees + (string)dgvEmployees.Rows[row].Cells["Phone Number"].Value;
                if (File.Exists(url))
                {
                    pbPiture.Image.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(url);
                }
            }
            else if (chose == DialogResult.No)
                message = bll.DisableEmployeeAccount(id);
            else
                return;
            if (!message.ToLower().Contains("successful"))
                MessageBox.Show(message, "OOPS");
            ReloadData(false);
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (lbSideBarTitle.Text.ToLower().Contains("add"))
            {
                txtPassword.Text = txtPhoneNumber.Text;
            }
        }
    }
}
