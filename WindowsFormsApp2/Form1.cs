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

namespace WindowsFormsApp2
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifidedNew,
        Deleted
    }

    public partial class Form1 : Form
    {
        Database database = new Database();
        int selectedRow;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("mark", "Mark");
            dataGridView1.Columns.Add("production", "Production");
            dataGridView1.Columns.Add("expiration_date", "expiration_date");
            dataGridView1.Columns.Add("nicotine", "nicotine");
            dataGridView1.Columns.Add("name_of_cigarette", "name_of_cigarette");
            dataGridView1.Columns.Add("price", "price");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetInt32(6), RowState.ModifidedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = "select * from cigarettes_db";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());
            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
            database.closeConnection();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Add_Form addfrm = new Add_Form();
            addfrm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBoxID.Text = row.Cells[0].Value.ToString();
                textBoxMark.Text = row.Cells[1].Value.ToString();
                textBoxProduction.Text = row.Cells[2].Value.ToString();
                textBoxDate.Text = row.Cells[3].Value.ToString();
                textBoxNikotine.Text = row.Cells[4].Value.ToString();
                textBoxName.Text = row.Cells[5].Value.ToString();
                textBoxPrice.Text = row.Cells[6].Value.ToString();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from cigarettes_db where concat (id, mark, production, expiration_date, nicotine, name_of_cigarette, price) like '%" + textBoxSearch.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }

            reader.Close();
            database.closeConnection();
        }

        private void DeleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[7].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[7].Value = RowState.Deleted;
        }

        private void Update()
        {
            database.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[7].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deletQuery = $"delete from cigarettes_db where id = {id}";

                    var command = new SqlCommand(deletQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var mark = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var production = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var expiration_date = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var nicotine = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var name_of_cigarette = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var price = dataGridView1.Rows[index].Cells[6].Value.ToString();

                    var changeQuery = $"update cigarettes_db set mark = '{mark}', production = '{production}', expiration_date = '{expiration_date}', nicotine = '{nicotine}', name_of_cigarette = '{name_of_cigarette}', price = '{price}' where id = '{id}'";

                    var command = new SqlCommand(changeQuery, database.getConnection());
                    command.ExecuteNonQuery();
                }
            }

            database.closeConnection();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBoxID.Text;
            var mark = textBoxMark.Text;
            var production = textBoxProduction.Text;
            var expiration_date = textBoxDate.Text;
            var nicotine = textBoxNikotine.Text;
            var name_of_cigarette = textBoxName.Text;
            int price;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBoxPrice.Text, out price))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, mark, production, expiration_date, nicotine, name_of_cigarette, price);
                    dataGridView1.Rows[selectedRowIndex].Cells[7].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Ціна повинна бути у форматі числа!");
                }
            }
        }

        private void changebutton_Click(object sender, EventArgs e)
        {
            Change();
        }
    }
}
