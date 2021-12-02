using BLL;
using DTO;
using GUI.DefinedFramework;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class fLogin : Form
    {
        private BLL_Login bll = new BLL_Login();
        private PanelMain pnMain;
        private DragDropForm dragDrop, dragDrop2;
        public fLogin()
        {
            InitializeComponent();
            pnMain = new PanelMain(this);
            pnMain.Controls.Add(pnLeft);
            ecForm.CornerRadius = root.borderCorner;
            dragDrop = new DragDropForm(this, pnLeft);
            dragDrop2 = new DragDropForm(this, pnHeader);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text, password = txtPassword.Text;
            if (string.IsNullOrEmpty(phoneNumber))
            {
                txtPhoneNumber.Focus();
                return;
            }
            else if(string.IsNullOrEmpty(password))
            {
                txtPassword.Focus();
                return;
            }
            string error = null;
            string response = bll.CheckAccountInfo(phoneNumber, password, ref error);
            if (error != null)
            {
                MessageBox.Show(error, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id;
            if (!int.TryParse(response, out id))
            {
                MessageBox.Show(response, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (response.Contains("assword"))
                {
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                }
                else
                {
                    txtPhoneNumber.Focus();
                    txtPhoneNumber.SelectAll();
                }
                return;
            }
            bll.InsertLoginTime(id);
            LoginAccount(id);
        }

        private void LoginAccount(int id)
        {
            Hide();
            string error = null;
            Employee emp = bll.GetEmployeeProfile(id, ref error);
            fMain f2 = new fMain(emp);
            bll.ChangeRole(emp.Role);
            f2.ShowDialog();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin.PerformClick();
            }
        }

        private void txtPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                e.SuppressKeyPress = true;
                txtPassword.Focus();
                txtPassword.SelectAll();
            }
        }

        private void txtPhoneNumber_Enter(object sender, EventArgs e)
        {
            txtPhoneNumber.SelectAll();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }
    }
}
