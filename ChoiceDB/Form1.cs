using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChoiceDB
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOnOff_Click(object sender, EventArgs e)
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                string connectionString = $"Data Source=***;Initial Catalog=***;User ID=***;Password=***;Pooling=True;";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
                builder.DataSource = comboBoxServer.Text;
                builder.InitialCatalog = comboBoxChoiceBD.Text;
                builder.UserID = textBoxUserName.Text;
                builder.Password = textBoxPassword.Text;
                try
                {
                    connection = new SqlConnection(builder.ConnectionString);
                    connection.Open();
                    this.Text = "Подключено к БД";
                    if (comboBoxChoiceBD.Text == "exampleDB1")
                    {
                        FillDataGrid dataGrid = new FillDataGrid(connection);
                        dataGrid.fill_DataGrid("Users", dataGridViewUsers);
                    }
                    else if (comboBoxChoiceBD.Text == "exampleDB2")
                    {
                        FillDataGrid dataGrid = new FillDataGrid(connection);
                        dataGrid.fill_DataGrid("Products", dataGridViewUsers);
                    }
                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
                }
            }
            else if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                this.Text = "Отключено от БД";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Закройте это окно и наберитесь терпения,\nидёт загрузка серверов.");
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();
            foreach (DataRow row in table.Rows)
            {
                comboBoxServer.Items.Add(row["ServerName"]+ "\\" + row["InstanceName"].ToString());
            }
        }
        
    }
}
