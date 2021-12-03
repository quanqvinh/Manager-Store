using DTO;
using FontAwesome.Sharp;
using GUI.DefinedFramework;
using Guna.UI2.WinForms;
using Manage_Store.DefinedFramework;
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
    public partial class fMain : Form
    {
        public FunctionPanel[] PnFunctions { get; set; }
        private int expandSize = 360, collapseSize = 90;
        public static Form ChildForm { get; set; }
        public static Employee Profile { get; set; }
        public static int beforeForm;

        public fMain(Employee emp)
        {
            InitializeComponent();
            PnFunctions = new FunctionPanel[7];
            PnFunctions[0] = new FunctionPanel(IconChar.Home, "Home", Color.Black, root.homePrimaryColor);
            PnFunctions[1] = new FunctionPanel(IconChar.FileInvoiceDollar, "Bills", Color.Black, root.billPrimaryColor);
            PnFunctions[2] = new FunctionPanel(IconChar.CookieBite, "Goods", Color.Black, root.goodsPrimaryColor);
            PnFunctions[3] = new FunctionPanel(IconChar.Box, "Contracts", Color.Black, root.contractPrimaryColor);
            PnFunctions[4] = new FunctionPanel(IconChar.Male, "Provider", Color.Black, root.providerPrimaryColor);
            PnFunctions[5] = new FunctionPanel(IconChar.Users, "Employees", Color.Black, root.employeePrimaryColor);
            PnFunctions[6] = new FunctionPanel(IconChar.ChartLine, "Revenue", Color.Black, root.cashFlowPrimaryColor);
            Profile = emp;
            if (emp != null)
            {
                lbName.Text = root.RemoveSignOfVietnameseString(Profile.Name).ToUpper();
                lbRole.Text = Profile.Role;
                if (emp.UrlImage == null || string.IsNullOrEmpty(emp.UrlImage))
                    pbAvatar.Image = Image.FromFile(root.ProjectPath() + root.imageEmployees + "tempAvatar.png");
                else
                    pbAvatar.Image = Image.FromFile(root.ProjectPath() + emp.UrlImage);
            }
            pnHeader.FillColor = root.titleBarColor;
            pnNav.FillColor = root.navBarColor;
            pnScreen.FillColor = root.screenColor;

        }

        private void fMain_Load(object sender, EventArgs e)
        {
            pnAccount.BackColor = root.navBarColor;
            for (int i = PnFunctions.Length - 1; i >= 0; --i)
            {
                pnNav.Controls.Add(PnFunctions[i]);
            }
            Controls.Add(pnLogo);
            pnNav.Controls.Add(pnLogo);

            // Collapse and expand navigation bar
            pnNav.DoubleClick += new EventHandler(CollapseAndExpand);
            for (int i = 0; i < PnFunctions.Length; ++i)
            {
                PnFunctions[i].DoubleClick += new EventHandler(CollapseAndExpand);
                foreach (Control c in PnFunctions[i].Controls)
                    c.DoubleClick += new EventHandler(CollapseAndExpand);
            }
            lbName.Click += new EventHandler(OpenContextMenuStripAccount);
            lbRole.Click += new EventHandler(OpenContextMenuStripAccount);

            // Open home form
            PnFunctions[0].Click += new EventHandler(OpenHomePage);
            foreach (Control c in PnFunctions[0].Controls)
                c.Click += new EventHandler(OpenHomePage);

            // Open bill form
            PnFunctions[1].Click += new EventHandler(OpenBillForm);
            foreach (Control c in PnFunctions[1].Controls)
                c.Click += new EventHandler(OpenBillForm);

            // Open goods form
            PnFunctions[2].Click += new EventHandler(OpenGoodsForm);
            foreach (Control c in PnFunctions[2].Controls)
                c.Click += new EventHandler(OpenGoodsForm);

            // Open contract form
            PnFunctions[3].Click += new EventHandler(OpenContractForm);
            foreach (Control c in PnFunctions[3].Controls)
                c.Click += new EventHandler(OpenContractForm);

            // Open provider form
            PnFunctions[4].Click += new EventHandler(OpenProviderForm);
            foreach (Control c in PnFunctions[4].Controls)
                c.Click += new EventHandler(OpenProviderForm);

            // Open employees form
            PnFunctions[5].Click += new EventHandler(OpenEmployeeForm);
            foreach (Control c in PnFunctions[5].Controls)
                c.Click += new EventHandler(OpenEmployeeForm);

            // Open cash flow form
            PnFunctions[6].Click += new EventHandler(OpenCashFlowForm);
            foreach (Control c in PnFunctions[6].Controls)
                c.Click += new EventHandler(OpenCashFlowForm);

            // Open menu strip
            pnAccount.Tag = false;
            pnAccount.Click += new EventHandler(OpenContextMenuStripAccount);
            foreach (Control c in pnAccount.Controls)
                c.Click += new EventHandler(OpenContextMenuStripAccount);

            //cmsAccount.Items["myProfileToolStripMenuItem"].Click += new EventHandler(OpenProfile);
            cmsAccount.Items["logOutToolStripMenuItem"].Click += new EventHandler(Logout);
            CollapseAndExpand(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized; 
        }

        private void OpenChildForm(Form childForm) // function to open child_form
        {

            if (fMain.ChildForm != null && childForm.GetType().ToString() == fMain.ChildForm.GetType().ToString())
                return;
            fMain.ChildForm = childForm;
            fMain.ChildForm.TopLevel = false;
            fMain.ChildForm.FormBorderStyle = FormBorderStyle.None;
            fMain.ChildForm.Dock = DockStyle.Fill;
            pnScreen.Controls.Add(childForm);
            fMain.ChildForm.BringToFront();
            fMain.ChildForm.Show();
            lbHeader.Text = fMain.ChildForm.Text.ToUpper();
        }

        private void fMain_SizeChanged(object sender, EventArgs e)
        {
            pnNav.Width = expandSize;
            pnContainer.Width = Width - pnNav.Width;
            pnHeader.Height = (int)(0.06 * Height);
        }

        private void CollapseAndExpand(object sender, EventArgs e)
        {
            if (pnNav.Width == expandSize)
            {
                pnNav.Width = collapseSize;
                foreach (FunctionPanel pn in PnFunctions)
                {
                    pn.name.Visible = false;
                    pn.Width = pnNav.Width - pn.Margin.Left * 2;
                }
                lbLogo.Hide();
                pnNameAndRole.Hide();
                pbLogo.Dock = DockStyle.Fill;
                pnContainer.Width = Width - pnNav.Width;
            }
            else
            {
                pnNav.Width = expandSize;
                foreach (FunctionPanel pn in PnFunctions)
                {
                    pn.AutoSize = false;
                    pn.name.Visible = true;
                    pbLogo.Dock = DockStyle.Left;
                    pn.Width = pnNav.Width - pn.Margin.Left * 2;
                }
                lbLogo.Show();
                pnNameAndRole.Show();
                pnContainer.Width = Width - pnNav.Width;
            }
        }

        private void HighlightOption(int p)
        {
            for (int i = 0; i < PnFunctions.Length; i++)
                PnFunctions[i].Chose();
            PnFunctions[p].Chose(true);
        }

        private void pnScreen_Paint(object sender, PaintEventArgs e)
        {
            if (Profile.Role == "ADMIN")
            {
                HighlightOption(5);
                OpenChildForm(new fEmployee());
                PnFunctions[6].Visible = false;
            }
            else if (Profile.Role == "STAFF")
            {
                HighlightOption(0);
                OpenChildForm(new fHome());
                PnFunctions[2].Visible = false;
                PnFunctions[3].Visible = false;
                PnFunctions[4].Visible = false;
                PnFunctions[5].Visible = false;
                PnFunctions[6].Visible = false;
            }
            else if (Profile.Role == "STOCK MANAGER")
            {
                HighlightOption(3);
                OpenChildForm(new fContract());
                PnFunctions[0].Visible = false;
                PnFunctions[1].Visible = false;
                PnFunctions[5].Visible = false;
                PnFunctions[6].Visible = false;
            }
        }

        public void OpenHomePage(object sender, EventArgs e)
        {
            HighlightOption(0);
            OpenChildForm(new fHome());
        }

        public void OpenBillForm(object sender, EventArgs e)
        {
            HighlightOption(1);
            OpenChildForm(new fBill());
        }

        public void OpenGoodsForm(object sender, EventArgs e)
        {
            HighlightOption(2);
            OpenChildForm(new fGoods());
        }

        public void OpenContractForm(object sender, EventArgs e)
        {
            HighlightOption(3);
            OpenChildForm(new fContract());
        }

        public void OpenProviderForm(object sender, EventArgs e)
        {
            HighlightOption(4);
            OpenChildForm(new fProvider());
        }

        public void OpenEmployeeForm(object sender, EventArgs e)
        {
            HighlightOption(5);
            OpenChildForm(new fEmployee());
        }

        public void OpenCashFlowForm(object sender, EventArgs e)
        {
            HighlightOption(6);
            OpenChildForm(new fCashFlow());
        }

        private void OpenContextMenuStripAccount(object sender, EventArgs e)
        {
            cmsAccount.Show(pnAccount, new Point(pnAccount.Width, pnAccount.Height), ToolStripDropDownDirection.AboveRight);
        }

        private void OpenProfile(object sender, EventArgs e)
        {

        }

        private void Logout(object sender, EventArgs e)
        {
            Hide();
            fLogin logout = new fLogin();
            logout.ShowDialog();
            Close();
        }
    }
}
