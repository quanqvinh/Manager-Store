using ElipseToolDemo;
using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.DefinedFramework
{
    public partial class PanelMain : UserControl
    {
        private ElipseControl borderRadius;
        public PanelMain(Form parent)
        {
            InitializeComponent();
            borderRadius = new ElipseControl();
            borderRadius.TargetControl = this;
            borderRadius.CornerRadius = root.borderCorner;
            Name = "pnMain";
            Location = new Point(1, 1);
            Width = parent.Width - 2;
            Height = parent.Height - 2;
            BackColor = Color.FromArgb(255, 249, 238);
            parent.BackColor = Color.FromArgb(0, 191, 166);
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
            foreach (Control c in parent.Controls)
            {
                if (c.GetType().ToString() == "GUI.DefinedFramework.PanelMain")
                    continue;
                Controls.Add(c);
            }
            parent.Controls.Add(this);
        }

        public void FixUI()
        {
            Location = new Point(1, 1);
            Width = Parent.Width - 2;
            Height = Parent.Height - 2;
            BackColor = Color.White;
            Parent.BackColor = Color.Red;
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
            foreach (Control c in Parent.Controls)
            {
                if (c.GetType().ToString() == "GUI.DefinedFramework.PanelMain")
                    continue;
                Controls.Add(c);
            }
        }
    }
}
