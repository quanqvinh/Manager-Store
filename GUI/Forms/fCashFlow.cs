using BLL;
using GUI.DefinedFramework;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class fCashFlow : Form
    {
        private BLL_CashFlow bll = new BLL_CashFlow();
        public fCashFlow()
        {
            InitializeComponent();

            BackColor = root.screenColor;
            dgvCashFlow.ThemeStyle.BackColor = root.screenColor;
            dgvCashFlow.GridColor = root.screenColor;
            dgvCashFlow.DefaultCellStyle.ForeColor = Color.Black;
            dgvCashFlow.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvCashFlow.ColumnHeadersDefaultCellStyle.SelectionBackColor = root.cashFlowPrimaryColor;
            pnTlpMoney.FillColor = root.backColorComponentCashFlow;
            tlpMoneyValue.ForeColor = Color.White;
            pnRevenue.FillColor = Color.FromArgb(26, 136, 58);
            pnSpend.FillColor = Color.FromArgb(180, 14, 22);
            pnProfit.FillColor = Color.FromArgb(200, 155, 0);
        }

        private void fCashFlow_Load(object sender, EventArgs e)
        {
            string error = null;
            DataTable dt = bll.GetCashFlowTable(ref error);
            if (error != null)
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
            dgvCashFlow.DataSource = dt;
            CustomDataGridViewCashFlow();

            object temp = bll.GetRevenue();
            double revenue = temp == null ? 0 : (double)temp;
            temp = bll.GetSpend();
            double spend = temp == null ? 0 : -(double)temp;
            lbRevenueValue.Text = root.MoneyFormat(revenue.ToString());
            lbSpendValue.Text = root.MoneyFormat(spend.ToString());
            lbProfitValue.Text = root.MoneyFormat((revenue - spend).ToString());

            fMain.beforeForm = 5;
        }

        private void CustomDataGridViewCashFlow()
        {
            dgvCashFlow.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            foreach (DataGridViewColumn col in dgvCashFlow.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font(new FontFamily("Poppins"), 12, FontStyle.Bold);
                col.HeaderCell.Style.ForeColor = Color.BlanchedAlmond;
            }
            dgvCashFlow.DefaultCellStyle.Font = new Font(new FontFamily("Roboto"), 12, FontStyle.Bold);
            dgvCashFlow.Columns["Time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCashFlow.Columns["Source"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCashFlow.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCashFlow.Columns["Money"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCashFlow.Columns["Money"].DefaultCellStyle.Format = "#,##0 đ";
        }
    }
}
