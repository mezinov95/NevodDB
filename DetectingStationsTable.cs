using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace NEVOD
{
    public partial class DetectingStationsAndClustersTable : Form
    {
        string path = "";
        public DetectingStationsAndClustersTable()
        {
            InitializeComponent();
            Encoding enc = Encoding.GetEncoding(1251);
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader("path.txt", enc);
            char[] buf = new char[1024];
            int chars_read;
            while ((chars_read = sr.ReadBlock(buf, 0, 1024)) != 0)
            {
                sb.Append(buf, 0, chars_read);
            }
            path += sb;
            textBox1.Text = path;
            textBox1.Enabled = false;
        }

        public void showData()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + textBox1.Text + ";";
            dataGridView1.DataMember = "Table";
            dataGridView2.DataMember = "Table";
            OleDbConnection connection1 = new OleDbConnection(connectionString);
            connection1.Open();
            DataSet dataSet1 = new DataSet();
            OleDbDataAdapter sqlDataAdapter1 = new OleDbDataAdapter();
            string SQLQuery = "SELECT * FROM Детектирующие_станции ORDER BY №";
            sqlDataAdapter1.SelectCommand = new OleDbCommand(SQLQuery, connection1);
            sqlDataAdapter1.Fill(dataSet1);
            dataGridView1.DataSource = dataSet1;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            DataSet dataSet2 = new DataSet();
            OleDbDataAdapter sqlDataAdapter2 = new OleDbDataAdapter();
            string SQLQuery2 = "SELECT * FROM Кластеры ORDER BY №";
            sqlDataAdapter2.SelectCommand = new OleDbCommand(SQLQuery2, connection1);
            sqlDataAdapter2.Fill(dataSet2);
            dataGridView2.DataSource = dataSet2;
            dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            connection1.Close();
        }
    }
}
