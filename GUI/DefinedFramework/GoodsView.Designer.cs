
namespace GUI.DefinedFramework
{
    partial class GoodsView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnHover = new Guna.UI2.WinForms.Guna2Panel();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.ecCell = new ElipseToolDemo.ElipseControl();
            this.ttName = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.pnHover.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHover
            // 
            this.pnHover.BackColor = System.Drawing.Color.Transparent;
            this.pnHover.Controls.Add(this.lbQuantity);
            this.pnHover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnHover.Location = new System.Drawing.Point(0, 0);
            this.pnHover.Name = "pnHover";
            this.pnHover.ShadowDecoration.Parent = this.pnHover;
            this.pnHover.Size = new System.Drawing.Size(236, 223);
            this.pnHover.TabIndex = 1;
            this.pnHover.Click += new System.EventHandler(this.pnHover_Click);
            this.pnHover.MouseEnter += new System.EventHandler(this.pnHover_MouseEnter);
            this.pnHover.MouseLeave += new System.EventHandler(this.pnHover_MouseLeave);
            // 
            // lbQuantity
            // 
            this.lbQuantity.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbQuantity.Font = new System.Drawing.Font("Roboto Black", 12F, System.Drawing.FontStyle.Bold);
            this.lbQuantity.Location = new System.Drawing.Point(0, 193);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(236, 30);
            this.lbQuantity.TabIndex = 1;
            this.lbQuantity.Text = "lbQuantity";
            this.lbQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ecCell
            // 
            this.ecCell.CornerRadius = 11;
            this.ecCell.TargetControl = this;
            // 
            // ttName
            // 
            this.ttName.AllowLinksHandling = true;
            this.ttName.AutoPopDelay = 5000;
            this.ttName.ForeColor = System.Drawing.Color.Black;
            this.ttName.InitialDelay = 0;
            this.ttName.MaximumSize = new System.Drawing.Size(0, 0);
            this.ttName.ReshowDelay = 100;
            this.ttName.TitleFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // 
            // GoodsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.pnHover);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "GoodsView";
            this.Size = new System.Drawing.Size(236, 223);
            this.SizeChanged += new System.EventHandler(this.GoodsPreview_SizeChanged);
            this.pnHover.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ElipseToolDemo.ElipseControl ecCell;
        private System.Windows.Forms.Label lbQuantity;
        public Guna.UI2.WinForms.Guna2Panel pnHover;
        private Guna.UI2.WinForms.Guna2HtmlToolTip ttName;
    }
}
