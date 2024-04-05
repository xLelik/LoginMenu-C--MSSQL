using System.Data.SqlClient;
using MySql.Data.MySqlClient;
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
 
    public partial class RegisterForm : Form
    {

        DataBase dataBese = new DataBase();

        bool drag = false;
        Point start_point = Global.CurrentWindowPosition;


        public RegisterForm()
        {
            InitializeComponent();
            this.Location = Global.CurrentWindowPosition;

            userNameTextBox.Text = "Введите имя";
            userNameTextBox.ForeColor = Color.Gray;


            LoginTextBox.Text = "Введите логин";
            LoginTextBox.ForeColor = Color.Gray;


            PassTextBox.Text = "Введите пароль";
            PassTextBox.ForeColor = Color.Gray;

        }




        private void buttonRegister_Click(object sender, EventArgs e)
        {

            if (PassTextBox.Text == "Введите пароль")
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            if (LoginTextBox.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (userNameTextBox.Text == "Введите имя")
            {
                MessageBox.Show("Введите имя");
                return;
            }



            if (checkuser())
                return;

            var login = LoginTextBox.Text;
            var password = PassTextBox.Text;
            var username = userNameTextBox.Text;

            string querystring = $"insert into register(login_user, password_user, name_user) values('{login}', '{password}', '{username}')";


            SqlCommand command = new SqlCommand(querystring, dataBese.getConnection());


           
            dataBese.openConnection();




            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт был создан");
            else
                MessageBox.Show("Аккаунт не был создан");



            dataBese.closeConnection();

        }

        public Boolean checkuser()
        {

            var loginUser = LoginTextBox.Text;
            var passUser = PassTextBox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string quertystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user='{passUser}'";


            SqlCommand command = new SqlCommand(quertystring, dataBese.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Такой логин зарегистрирован, введите другой");
                return true;
            }
            else
            {
                return false;
            }

        }




        private void userNameTextBox_Enter(object sender, EventArgs e)
        {
            if(userNameTextBox.Text == "Введите имя")
            userNameTextBox.Text = "";
            userNameTextBox.ForeColor = Color.Black;
        }

        private void userNameTextBox_Leave(object sender, EventArgs e)
        {
            if (userNameTextBox.Text == "")
            {
                userNameTextBox.Text = "Введите имя";
                userNameTextBox.ForeColor = Color.Gray;
            } 
                
               
        }




        private void LoginTextBox_Enter(object sender, EventArgs e)
        {
            if (LoginTextBox.Text == "Введите логин")
                LoginTextBox.Text = "";
                LoginTextBox.ForeColor = Color.Black;
        }

        private void LoginTextBox_Leave(object sender, EventArgs e)
        {
            if (LoginTextBox.Text == "")
            {
                LoginTextBox.Text = "Введите логин";
                LoginTextBox.ForeColor = Color.Gray;
            }

        }





        private void PassTextBox_Enter(object sender, EventArgs e)
        {
            if (PassTextBox.Text == "Введите пароль")
                PassTextBox.Text = "";
                PassTextBox.ForeColor = Color.Black;
        }

        private void PassTextBox_Leave(object sender, EventArgs e)
        {
            if (PassTextBox.Text == "")
            {
                PassTextBox.Text = "Введите пароль";
                PassTextBox.ForeColor = Color.Gray;
            }

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




        private void RegisterLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm1 loginForm = new LoginForm1();
            loginForm.Show();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            if (Global.IsFormMoved)
            {
                this.Location = Global.CurrentWindowPosition;
            }
        }
    }
}
