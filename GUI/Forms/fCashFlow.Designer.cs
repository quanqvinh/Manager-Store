
namespace GUI
{
    partial class fCashFlow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnTlpMoney = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpMoneyValue = new System.Windows.Forms.TableLayoutPanel();
            this.pnProfit = new Guna.UI2.WinForms.Guna2Panel();
            this.lbProfitValue = new System.Windows.Forms.Label();
            this.lbProfit = new System.Windows.Forms.Label();
            this.pnSpend = new Guna.UI2.WinForms.Guna2Panel();
            this.lbSpendValue = new System.Windows.Forms.Label();
            this.lbSpend = new System.Windows.Forms.Label();
            this.pnRevenue = new Guna.UI2.WinForms.Guna2Panel();
            this.lbRevenueValue = new System.Windows.Forms.Label();
            this.lbRevenue = new System.Windows.Forms.Label();
            this.ecDgvCashFlow = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.dgvCashFlow = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnDgv = new Guna.UI2.WinForms.Guna2Panel();
            this.pnTlpMoney.SuspendLayout();
            this.tlpMoneyValue.SuspendLayout();
            this.pnProfit.SuspendLayout();
            this.pnSpend.SuspendLayout();
            this.pnRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashFlow)).BeginInit();
            this.pnDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTlpMoney
            // 
            this.pnTlpMoney.AutoRoundedCorners = true;
            this.pnTlpMoney.BorderRadius = 34;
            this.pnTlpMoney.Controls.Add(this.tlpMoneyValue);
            this.pnTlpMoney.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTlpMoney.Location = new System.Drawing.Point(10, 10);
            this.pnTlpMoney.Name = "pnTlpMoney";
            this.pnTlpMoney.Padding = new System.Windows.Forms.Padding(10);
            this.pnTlpMoney.ShadowDecoration.Parent = this.pnTlpMoney;
            this.pnTlpMoney.Size = new System.Drawing.Size(1351, 70);
            this.pnTlpMoney.TabIndex = 0;
            // 
            // tlpMoneyValue
            // 
            this.tlpMoneyValue.BackColor = System.Drawing.Color.Transparent;
            this.tlpMoneyValue.ColumnCount = 3;
            this.tlpMoneyValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMoneyValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMoneyValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMoneyValue.Controls.Add(this.pnProfit, 2, 0);
            this.tlpMoneyValue.Controls.Add(this.pnSpend, 1, 0);
            this.tlpMoneyValue.Controls.Add(this.pnRevenue, 0, 0);
            this.tlpMoneyValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMoneyValue.Location = new System.Drawing.Point(10, 10);
            this.tlpMoneyValue.Name = "tlpMoneyValue";
            this.tlpMoneyValue.RowCount = 1;
            this.tlpMoneyValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMoneyValue.Size = new System.Drawing.Size(1331, 50);
            this.tlpMoneyValue.TabIndex = 0;
            // 
            // pnProfit
            // 
            this.pnProfit.AutoRoundedCorners = true;
            this.pnProfit.BackColor = System.Drawing.Color.Transparent;
            this.pnProfit.BorderRadius = 19;
            this.pnProfit.Controls.Add(this.lbProfitValue);
            this.pnProfit.Controls.Add(this.lbProfit);
            this.pnProfit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnProfit.Location = new System.Drawing.Point(896, 5);
            this.pnProfit.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnProfit.Name = "pnProfit";
            this.pnProfit.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.pnProfit.ShadowDecoration.Parent = this.pnProfit;
            this.pnProfit.Size = new System.Drawing.Size(425, 40);
            this.pnProfit.TabIndex = 2;
            // 
            // lbProfitValue
            // 
            this.lbProfitValue.BackColor = System.Drawing.Color.Transparent;
            this.lbProfitValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbProfitValue.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProfitValue.Location = new System.Drawing.Point(115, 10);
            this.lbProfitValue.Name = "lbProfitValue";
            this.lbProfitValue.Size = new System.Drawing.Size(280, 20);
            this.lbProfitValue.TabIndex = 1;
            this.lbProfitValue.Text = "label5";
            this.lbProfitValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbProfit
            // 
            this.lbProfit.BackColor = System.Drawing.Color.Transparent;
            this.lbProfit.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbProfit.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProfit.Location = new System.Drawing.Point(30, 10);
            this.lbProfit.Name = "lbProfit";
            this.lbProfit.Size = new System.Drawing.Size(85, 20);
            this.lbProfit.TabIndex = 0;
            this.lbProfit.Text = "Profit:";
            this.lbProfit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnSpend
            // 
            this.pnSpend.AutoRoundedCorners = true;
            this.pnSpend.BackColor = System.Drawing.Color.Transparent;
            this.pnSpend.BorderRadius = 19;
            this.pnSpend.Controls.Add(this.lbSpendValue);
            this.pnSpend.Controls.Add(this.lbSpend);
            this.pnSpend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSpend.Location = new System.Drawing.Point(453, 5);
            this.pnSpend.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnSpend.Name = "pnSpend";
            this.pnSpend.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.pnSpend.ShadowDecoration.Parent = this.pnSpend;
            this.pnSpend.Size = new System.Drawing.Size(423, 40);
            this.pnSpend.TabIndex = 1;
            // 
            // lbSpendValue
            // 
            this.lbSpendValue.BackColor = System.Drawing.Color.Transparent;
            this.lbSpendValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSpendValue.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpendValue.Location = new System.Drawing.Point(115, 10);
            this.lbSpendValue.Name = "lbSpendValue";
            this.lbSpendValue.Size = new System.Drawing.Size(278, 20);
            this.lbSpendValue.TabIndex = 1;
            this.lbSpendValue.Text = "label3";
            this.lbSpendValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSpend
            // 
            this.lbSpend.BackColor = System.Drawing.Color.Transparent;
            this.lbSpend.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbSpend.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpend.Location = new System.Drawing.Point(30, 10);
            this.lbSpend.Name = "lbSpend";
            this.lbSpend.Size = new System.Drawing.Size(85, 20);
            this.lbSpend.TabIndex = 0;
            this.lbSpend.Text = "Spend:";
            this.lbSpend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnRevenue
            // 
            this.pnRevenue.AutoRoundedCorners = true;
            this.pnRevenue.BackColor = System.Drawing.Color.Transparent;
            this.pnRevenue.BorderRadius = 19;
            this.pnRevenue.Controls.Add(this.lbRevenueValue);
            this.pnRevenue.Controls.Add(this.lbRevenue);
            this.pnRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRevenue.Location = new System.Drawing.Point(10, 5);
            this.pnRevenue.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.pnRevenue.Name = "pnRevenue";
            this.pnRevenue.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.pnRevenue.ShadowDecoration.Parent = this.pnRevenue;
            this.pnRevenue.Size = new System.Drawing.Size(423, 40);
            this.pnRevenue.TabIndex = 0;
            // 
            // lbRevenueValue
            // 
            this.lbRevenueValue.BackColor = System.Drawing.Color.Transparent;
            this.lbRevenueValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRevenueValue.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRevenueValue.Location = new System.Drawing.Point(115, 10);
            this.lbRevenueValue.Name = "lbRevenueValue";
            this.lbRevenueValue.Size = new System.Drawing.Size(278, 20);
            this.lbRevenueValue.TabIndex = 1;
            this.lbRevenueValue.Text = "label2";
            this.lbRevenueValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbRevenue
            // 
            this.lbRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lbRevenue.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbRevenue.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRevenue.Location = new System.Drawing.Point(30, 10);
            this.lbRevenue.Name = "lbRevenue";
            this.lbRevenue.Size = new System.Drawing.Size(85, 20);
            this.lbRevenue.TabIndex = 0;
            this.lbRevenue.Text = "Revenue:";
            this.lbRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ecDgvCashFlow
            // 
            this.ecDgvCashFlow.BorderRadius = 11;
            this.ecDgvCashFlow.TargetControl = this.dgvCashFlow;
            // 
            // dgvCashFlow
            // 
            this.dgvCashFlow.AllowUserToAddRows = false;
            this.dgvCashFlow.AllowUserToDeleteRows = false;
            this.dgvCashFlow.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.dgvCashFlow.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCashFlow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCashFlow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvCashFlow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCashFlow.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCashFlow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashFlow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCashFlow.ColumnHeadersHeight = 45;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashFlow.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCashFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCashFlow.EnableHeadersVisualStyles = false;
            this.dgvCashFlow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvCashFlow.Location = new System.Drawing.Point(3, 10);
            this.dgvCashFlow.Margin = new System.Windows.Forms.Padding(13, 0, 0, 10);
            this.dgvCashFlow.MultiSelect = false;
            this.dgvCashFlow.Name = "dgvCashFlow";
            this.dgvCashFlow.ReadOnly = true;
            this.dgvCashFlow.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashFlow.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCashFlow.RowHeadersVisible = false;
            this.dgvCashFlow.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5);
            this.dgvCashFlow.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCashFlow.RowTemplate.Height = 40;
            this.dgvCashFlow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashFlow.Size = new System.Drawing.Size(1345, 589);
            this.dgvCashFlow.TabIndex = 3;
            this.dgvCashFlow.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WetAsphalt;
            this.dgvCashFlow.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.dgvCashFlow.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCashFlow.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCashFlow.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCashFlow.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCashFlow.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvCashFlow.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvCashFlow.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvCashFlow.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCashFlow.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCashFlow.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCashFlow.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCashFlow.ThemeStyle.HeaderStyle.Height = 45;
            this.dgvCashFlow.ThemeStyle.ReadOnly = true;
            this.dgvCashFlow.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dgvCashFlow.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCashFlow.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvCashFlow.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvCashFlow.ThemeStyle.RowsStyle.Height = 40;
            this.dgvCashFlow.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            this.dgvCashFlow.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // pnDgv
            // 
            this.pnDgv.Controls.Add(this.dgvCashFlow);
            this.pnDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDgv.Location = new System.Drawing.Point(10, 80);
            this.pnDgv.Name = "pnDgv";
            this.pnDgv.Padding = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pnDgv.ShadowDecoration.Parent = this.pnDgv;
            this.pnDgv.Size = new System.Drawing.Size(1351, 598);
            this.pnDgv.TabIndex = 2;
            // 
            // fCashFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 688);
            this.Controls.Add(this.pnDgv);
            this.Controls.Add(this.pnTlpMoney);
            this.Name = "fCashFlow";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "CASH FLOW";
            this.Load += new System.EventHandler(this.fCashFlow_Load);
            this.pnTlpMoney.ResumeLayout(false);
            this.tlpMoneyValue.ResumeLayout(false);
            this.pnProfit.ResumeLayout(false);
            this.pnSpend.ResumeLayout(false);
            this.pnRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashFlow)).EndInit();
            this.pnDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnTlpMoney;
        private System.Windows.Forms.TableLayoutPanel tlpMoneyValue;
        private Guna.UI2.WinForms.Guna2Panel pnProfit;
        private System.Windows.Forms.Label lbProfitValue;
        private System.Windows.Forms.Label lbProfit;
        private Guna.UI2.WinForms.Guna2Panel pnSpend;
        private System.Windows.Forms.Label lbSpendValue;
        private System.Windows.Forms.Label lbSpend;
        private Guna.UI2.WinForms.Guna2Panel pnRevenue;
        private System.Windows.Forms.Label lbRevenueValue;
        private System.Windows.Forms.Label lbRevenue;
        private Guna.UI2.WinForms.Guna2Elipse ecDgvCashFlow;
        private Guna.UI2.WinForms.Guna2Panel pnDgv;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCashFlow;
    }
}