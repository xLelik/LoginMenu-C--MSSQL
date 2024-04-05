using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_APP
{
    public partial class MainForm : Form
    {

        bool drag = false;
        Point start_point = new Point(0, 0);


        public MainForm()
        {
            InitializeComponent();
        }






        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonCloose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(52, 138, 167);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(18, 18, 18);
        }

        private void buttonCloose_MouseEnter(object sender, EventArgs e)
        {
            buttonCloose.BackColor = Color.Red;
        }

        private void buttonCloose_MouseLeave(object sender, EventArgs e)
        {
            buttonCloose.BackColor = Color.FromArgb(18, 18, 18);
        }
    }
}
