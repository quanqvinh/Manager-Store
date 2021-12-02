
namespace GUI.DefinedFramework
{
    partial class PanelGoodsInCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelGoodsInCart));
            this.pnWrapper = new Guna.UI2.WinForms.Guna2Panel();
            this.lbName = new System.Windows.Forms.Label();
            this.pnQuantityWrapper = new System.Windows.Forms.Panel();
            this.pnQuantity = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPlus = new Guna.UI2.WinForms.Guna2Button();
            this.btnMinus = new Guna.UI2.WinForms.Guna2Button();
            this.lbPrice = new System.Windows.Forms.Label();
            this.pnDelete = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.pnImage = new Guna.UI2.WinForms.Guna2Panel();
            this.nudQuantity = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.pnWrapper.SuspendLayout();
            this.pnQuantityWrapper.SuspendLayout();
            this.pnQuantity.SuspendLayout();
            this.pnDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // pnWrapper
            // 
            this.pnWrapper.BackColor = System.Drawing.Color.Transparent;
            this.pnWrapper.BorderRadius = 10;
            this.pnWrapper.Controls.Add(this.lbName);
            this.pnWrapper.Controls.Add(this.pnQuantityWrapper);
            this.pnWrapper.Controls.Add(this.lbPrice);
            this.pnWrapper.Controls.Add(this.pnDelete);
            this.pnWrapper.Controls.Add(this.pnImage);
            this.pnWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnWrapper.FillColor = System.Drawing.Color.White;
            this.pnWrapper.Location = new System.Drawing.Point(0, 5);
            this.pnWrapper.Name = "pnWrapper";
            this.pnWrapper.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnWrapper.ShadowDecoration.Parent = this.pnWrapper;
            this.pnWrapper.Size = new System.Drawing.Size(800, 95);
            this.pnWrapper.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.White;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lbName.ForeColor = System.Drawing.Color.Black;
            this.lbName.Location = new System.Drawing.Point(144, 0);
            this.lbName.Name = "lbName";
            this.lbName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lbName.Size = new System.Drawing.Size(397, 55);
            this.lbName.TabIndex = 19;
            this.lbName.Text = "Mì Hảo Hảo tôm chua cay 75g";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnQuantityWrapper
            // 
            this.pnQuantityWrapper.BackColor = System.Drawing.Color.White;
            this.pnQuantityWrapper.Controls.Add(this.pnQuantity);
            this.pnQuantityWrapper.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnQuantityWrapper.Location = new System.Drawing.Point(144, 55);
            this.pnQuantityWrapper.Name = "pnQuantityWrapper";
            this.pnQuantityWrapper.Padding = new System.Windows.Forms.Padding(20, 0, 0, 10);
            this.pnQuantityWrapper.Size = new System.Drawing.Size(397, 40);
            this.pnQuantityWrapper.TabIndex = 18;
            this.pnQuantityWrapper.Text = "Mì Hảo Hảo tôm chua cay 75g";
            // 
            // pnQuantity
            // 
            this.pnQuantity.AutoRoundedCorners = true;
            this.pnQuantity.BorderRadius = 14;
            this.pnQuantity.Controls.Add(this.nudQuantity);
            this.pnQuantity.Controls.Add(this.btnPlus);
            this.pnQuantity.Controls.Add(this.btnMinus);
            this.pnQuantity.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnQuantity.FillColor = System.Drawing.Color.White;
            this.pnQuantity.Location = new System.Drawing.Point(20, 0);
            this.pnQuantity.Name = "pnQuantity";
            this.pnQuantity.ShadowDecoration.Parent = this.pnQuantity;
            this.pnQuantity.Size = new System.Drawing.Size(100, 30);
            this.pnQuantity.TabIndex = 3;
            // 
            // btnPlus
            // 
            this.btnPlus.Animated = true;
            this.btnPlus.AutoRoundedCorners = true;
            this.btnPlus.BackColor = System.Drawing.Color.Transparent;
            this.btnPlus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.btnPlus.BorderRadius = 14;
            this.btnPlus.CheckedState.Parent = this.btnPlus;
            this.btnPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlus.CustomImages.Parent = this.btnPlus;
            this.btnPlus.CustomizableEdges.BottomLeft = false;
            this.btnPlus.CustomizableEdges.TopLeft = false;
            this.btnPlus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPlus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPlus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPlus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPlus.DisabledState.Parent = this.btnPlus;
            this.btnPlus.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPlus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.btnPlus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPlus.ForeColor = System.Drawing.Color.White;
            this.btnPlus.HoverState.Parent = this.btnPlus;
            this.btnPlus.Image = global::Manage_Store.Properties.Resources.plus;
            this.btnPlus.ImageSize = new System.Drawing.Size(15, 15);
            this.btnPlus.Location = new System.Drawing.Point(70, 0);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.ShadowDecoration.Parent = this.btnPlus;
            this.btnPlus.Size = new System.Drawing.Size(30, 30);
            this.btnPlus.TabIndex = 1;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Animated = true;
            this.btnMinus.AutoRoundedCorners = true;
            this.btnMinus.BackColor = System.Drawing.Color.Transparent;
            this.btnMinus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.btnMinus.BorderRadius = 14;
            this.btnMinus.CheckedState.Parent = this.btnMinus;
            this.btnMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinus.CustomImages.Parent = this.btnMinus;
            this.btnMinus.CustomizableEdges.BottomRight = false;
            this.btnMinus.CustomizableEdges.TopRight = false;
            this.btnMinus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMinus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMinus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMinus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMinus.DisabledState.Parent = this.btnMinus;
            this.btnMinus.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMinus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.btnMinus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinus.ForeColor = System.Drawing.Color.White;
            this.btnMinus.HoverState.Parent = this.btnMinus;
            this.btnMinus.Image = global::Manage_Store.Properties.Resources.minus;
            this.btnMinus.ImageOffset = new System.Drawing.Point(1, 0);
            this.btnMinus.ImageSize = new System.Drawing.Size(15, 15);
            this.btnMinus.Location = new System.Drawing.Point(0, 0);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.ShadowDecoration.Parent = this.btnMinus;
            this.btnMinus.Size = new System.Drawing.Size(30, 30);
            this.btnMinus.TabIndex = 0;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // lbPrice
            // 
            this.lbPrice.BackColor = System.Drawing.Color.White;
            this.lbPrice.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbPrice.Font = new System.Drawing.Font("Poppins", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.lbPrice.Location = new System.Drawing.Point(541, 0);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Padding = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.lbPrice.Size = new System.Drawing.Size(169, 95);
            this.lbPrice.TabIndex = 17;
            this.lbPrice.Text = "30.000 đ";
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnDelete
            // 
            this.pnDelete.BorderColor = System.Drawing.Color.Transparent;
            this.pnDelete.Controls.Add(this.btnDelete);
            this.pnDelete.CustomBorderColor = System.Drawing.Color.Transparent;
            this.pnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnDelete.Location = new System.Drawing.Point(710, 0);
            this.pnDelete.Name = "pnDelete";
            this.pnDelete.ShadowDecoration.Parent = this.pnDelete;
            this.pnDelete.Size = new System.Drawing.Size(90, 95);
            this.pnDelete.TabIndex = 9;
            // 
            // btnDelete
            // 
            this.btnDelete.Animated = true;
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.CheckedState.Parent = this.btnDelete;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.CustomImages.Parent = this.btnDelete;
            this.btnDelete.CustomizableEdges.BottomLeft = false;
            this.btnDelete.CustomizableEdges.TopLeft = false;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.DisabledState.Parent = this.btnDelete;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FillColor = System.Drawing.Color.Empty;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnDelete.HoverState.Parent = this.btnDelete;
            this.btnDelete.Image = global::Manage_Store.Properties.Resources.delete_red;
            this.btnDelete.ImageSize = new System.Drawing.Size(40, 40);
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShadowDecoration.Parent = this.btnDelete;
            this.btnDelete.Size = new System.Drawing.Size(90, 95);
            this.btnDelete.TabIndex = 0;
            // 
            // pnImage
            // 
            this.pnImage.BackColor = System.Drawing.Color.White;
            this.pnImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnImage.BackgroundImage")));
            this.pnImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnImage.Location = new System.Drawing.Point(8, 0);
            this.pnImage.Name = "pnImage";
            this.pnImage.ShadowDecoration.Parent = this.pnImage;
            this.pnImage.Size = new System.Drawing.Size(136, 95);
            this.pnImage.TabIndex = 8;
            // 
            // nudQuantity
            // 
            this.nudQuantity.BackColor = System.Drawing.Color.Transparent;
            this.nudQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudQuantity.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nudQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nudQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nudQuantity.DisabledState.Parent = this.nudQuantity;
            this.nudQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudQuantity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.nudQuantity.FocusedState.Parent = this.nudQuantity;
            this.nudQuantity.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold);
            this.nudQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nudQuantity.Location = new System.Drawing.Point(30, 0);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.ShadowDecoration.Parent = this.nudQuantity;
            this.nudQuantity.Size = new System.Drawing.Size(40, 30);
            this.nudQuantity.TabIndex = 2;
            this.nudQuantity.TextOffset = new System.Drawing.Point(5, 0);
            this.nudQuantity.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudQuantity.ValueChanged += new System.EventHandler(this.nudQuantity_ValueChanged);
            // 
            // PanelGoodsInCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(64)))), ((int)(((byte)(88)))));
            this.Controls.Add(this.pnWrapper);
            this.Name = "PanelGoodsInCart";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Size = new System.Drawing.Size(800, 105);
            this.pnWrapper.ResumeLayout(false);
            this.pnQuantityWrapper.ResumeLayout(false);
            this.pnQuantity.ResumeLayout(false);
            this.pnDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnWrapper;
        private Guna.UI2.WinForms.Guna2Panel pnImage;
        private System.Windows.Forms.Panel pnQuantityWrapper;
        private Guna.UI2.WinForms.Guna2Panel pnQuantity;
        private Guna.UI2.WinForms.Guna2Button btnPlus;
        private Guna.UI2.WinForms.Guna2Button btnMinus;
        public System.Windows.Forms.Label lbPrice;
        private Guna.UI2.WinForms.Guna2Panel pnDelete;
        public Guna.UI2.WinForms.Guna2Button btnDelete;
        public System.Windows.Forms.Label lbName;
        public Guna.UI2.WinForms.Guna2NumericUpDown nudQuantity;
    }
}
