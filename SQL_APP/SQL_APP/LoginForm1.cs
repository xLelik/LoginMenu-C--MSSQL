using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_APP
{
    public partial class LoginForm1 : Form
    {

        bool drag = false;
        Point start_point = Global.CurrentWindowPosition;

        public LoginForm1()
        {
            InitializeComponent();
        }

        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = LoginTextBox.Text;
            String passUser = PassTextBox.Text;


            DataTable table = new DataTable();


            string quertystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user='{passUser}'";


            SqlCommand command = Global.executeSqlCommand(quertystring);


            Global.adapter.SelectCommand = command;
            Global.adapter.Fill(table);


            if (table.Rows.Count == 1)
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("No");
            }

        }

        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
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
                Global.IsFormMoved = true;
                Global.CurrentWindowPosition = new Point(p.X - start_point.X, p.Y - start_point.Y);
                this.Location = Global.CurrentWindowPosition;

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

        private void LoginForm1_Load(object sender, EventArgs e)
        {
            if (Global.IsFormMoved)
            {
                this.Location = Global.CurrentWindowPosition;
            }
        }

        
    }

}
