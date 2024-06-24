using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class sing_up : Form
    {
        Database dataBase = new Database();

        public sing_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox_login.Text;
            var password = textBox_password.Text;

            string querystring = $"insert into register(login_user, password_user) values('{login}', '{password}')";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            dataBase.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(" Аккаунт успішно створено!", "Успіх!");
                log_in frm_login  = new log_in();
                this.Hide();
                frm_login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не створено!");
            }
            dataBase.closeConnection();
        }

        private Boolean checkuser()
        {
            var loginUser = textBox_login.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0 ) 
            {
                MessageBox.Show("Користувач уже існує!");
                return true;
            }
            else 
            { 
                return false; 
            }
        }

        private void sing_up_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';
        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
