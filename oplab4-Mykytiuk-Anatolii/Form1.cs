using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace oplab4_Mykytiuk_Anatolii
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Перевірка, чи всі поля заповнені
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text) ||
                string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Всі поля повинні бути заповнені!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Рядок підключення до бази даних
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=YourDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                // Запит SQL для вставки даних
                string sqlQuery = "INSERT INTO [dbo].[Table] (mark, production, expiration_date, nicotine, name, price) VALUES (@mark, @production, @expiration_date, @nicotine, @name, @price)";

                // Встановлення з'єднання з базою даних
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Створення об'єкта команди з параметрами
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Додавання параметрів до команди
                        command.Parameters.AddWithValue("@mark", textBox1.Text);
                        command.Parameters.AddWithValue("@production", textBox2.Text);
                        command.Parameters.AddWithValue("@expiration_date", Convert.ToDateTime(textBox3.Text));
                        command.Parameters.AddWithValue("@nicotine", textBox4.Text);
                        command.Parameters.AddWithValue("@name", textBox5.Text);
                        command.Parameters.AddWithValue("@price", Convert.ToInt32(textBox6.Text));

                        // Виконання команди
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Дані успішно додано до бази даних.", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Не вдалося додати дані до бази даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
