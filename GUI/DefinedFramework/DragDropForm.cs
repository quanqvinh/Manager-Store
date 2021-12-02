using System.Drawing;
using System.Windows.Forms;

namespace GUI.DefinedFramework
{
    public class DragDropForm
    {
        private bool drag = false;
        private Point p;
        private Form f;
        public DragDropForm(Form f, Control p)
        {
            this.f = f;
            p.MouseDown += new MouseEventHandler(c_mouseDown);
            p.MouseMove += new MouseEventHandler(c_mouseMove);
            p.MouseUp += new MouseEventHandler(c_mouseUp);
            foreach (Control c in p.Controls)
            {
                c.MouseDown += new MouseEventHandler(c_mouseDown);
                c.MouseMove += new MouseEventHandler(c_mouseMove);
                c.MouseUp += new MouseEventHandler(c_mouseUp);
            }
        }

        private void c_mouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            p = e.Location;
        }

        private void c_mouseMove(object sender, MouseEventArgs e)
        {
            if (!drag)
                return;
            Point p2 = e.Location;
            f.Location = new Point(f.Location.X + p2.X - p.X, f.Location.Y + p2.Y - p.Y);
        }

        private void c_mouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
