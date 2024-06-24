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
    public partial class Add_Form : Form
    {
        Database database = new Database();

        public Add_Form()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            database.openConnection();

            var mark = textBoxMark.Text;
            var production = textBoxProduction.Text;
            var expiration_date = textBoxDate.Text;
            var nicotine = textBoxNikotine.Text;
            var name_of_cigarette = textBoxName.Text;
            int price; 

            if(int.TryParse(textBoxPrice.Text, out price))
            {
                var addQuery = $"insert into cigarettes_db (mark, production, expiration_date, nicotine, name_of_cigarette, price) values ('{mark}', '{production}', '{expiration_date}', '{nicotine}', '{name_of_cigarette}', '{price}')";

                var command = new SqlCommand(addQuery, database.getConnection()) ;
                command.ExecuteNonQuery() ;

                MessageBox.Show("Запис успішно створено!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ціна повинна бути у форматі числа!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            database.closeConnection();

        }
    }
}
