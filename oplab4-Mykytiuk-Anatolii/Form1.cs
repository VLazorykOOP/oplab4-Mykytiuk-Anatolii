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
            // ��������, �� �� ���� ��������
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text) ||
                string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("�� ���� ������ ���� ��������!", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // ����� ���������� �� ���� �����
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=YourDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False";

                // ����� SQL ��� ������� �����
                string sqlQuery = "INSERT INTO [dbo].[Table] (mark, production, expiration_date, nicotine, name, price) VALUES (@mark, @production, @expiration_date, @nicotine, @name, @price)";

                // ������������ �'������� � ����� �����
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // ��������� ��'���� ������� � �����������
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // ��������� ��������� �� �������
                        command.Parameters.AddWithValue("@mark", textBox1.Text);
                        command.Parameters.AddWithValue("@production", textBox2.Text);
                        command.Parameters.AddWithValue("@expiration_date", Convert.ToDateTime(textBox3.Text));
                        command.Parameters.AddWithValue("@nicotine", textBox4.Text);
                        command.Parameters.AddWithValue("@name", textBox5.Text);
                        command.Parameters.AddWithValue("@price", Convert.ToInt32(textBox6.Text));

                        // ��������� �������
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("��� ������ ������ �� ���� �����.", "������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("�� ������� ������ ��� �� ���� �����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�������: {ex.Message}", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
