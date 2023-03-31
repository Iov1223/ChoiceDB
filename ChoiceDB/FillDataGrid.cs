using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChoiceDB
{
    internal class FillDataGrid
    {
        private SqlConnection _connection;
        public FillDataGrid(SqlConnection connection)
        {
            _connection = connection;
        }
        public void fill_DataGrid(string _tamebleName, DataGridView dataGridView)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand($"SELECT * FROM {_tamebleName}", _connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.Height = 133;
            dataGridView.DataSource = data;
        }
    }
}
