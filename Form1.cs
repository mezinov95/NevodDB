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
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;

namespace NEVOD
{
    public partial class Form1 : Form
    {
        public string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void запросыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryForm QF = new QueryForm();
            QF.Visible = true;
        }


        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpWindow HW = new HelpWindow();
            HW.Visible = true;
            HW.OnLoad();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdditionForm AF = new AdditionForm();
            AF.Visible = true;
        }

        private void детектирующиеСтанцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetectingStationsAndClustersTable Form = new DetectingStationsAndClustersTable();
            Form.Visible = true;
            Form.showData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                path = "";
                Encoding enc = Encoding.GetEncoding(1251);
                StringBuilder sb = new StringBuilder();
                StreamReader sr = new StreamReader("Path.txt", enc);
                char[] buf = new char[1024];
                int chars_read;
                while ((chars_read = sr.ReadBlock(buf, 0, 1024)) != 0)
                {
                    sb.Append(buf, 0, chars_read);
                }
                //string path = "";
                path += sb;
                label3.Visible = true;
                textBox1.Text = path;
                textBox1.Visible = true;
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + path + ";";
                dataGridView1.DataMember = "Table";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                DataSet dataSet1 = new DataSet();
                OleDbDataAdapter sqlDataAdapter1 = new OleDbDataAdapter();
                string SQLQuery = "SELECT * FROM ФЭУ ORDER BY №";
                sqlDataAdapter1.SelectCommand = new OleDbCommand(SQLQuery, connection1);
                sqlDataAdapter1.Fill(dataSet1);
                dataGridView1.DataSource = dataSet1;
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


                dataGridView2.DataMember = "Table";
                DataSet dataSet2 = new DataSet();
                OleDbDataAdapter sqlDataAdapter2 = new OleDbDataAdapter();
                string SQLQuery2 = "SELECT * FROM Сцинтилляторы ORDER BY №";
                sqlDataAdapter2.SelectCommand = new OleDbCommand(SQLQuery2, connection1);
                sqlDataAdapter2.Fill(dataSet2);
                dataGridView2.DataSource = dataSet2;
                dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


                dataGridView3.DataMember = "Table";
                DataSet dataSet3 = new DataSet();
                OleDbDataAdapter sqlDataAdapter3 = new OleDbDataAdapter();
                string SQLQuery3 = "SELECT * FROM Детекторы ORDER BY №";
                sqlDataAdapter3.SelectCommand = new OleDbCommand(SQLQuery3, connection1);
                sqlDataAdapter3.Fill(dataSet3);
                dataGridView3.DataSource = dataSet3;
                dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                connection1.Close();
            }
            catch
            {
                MessageBox.Show("Считать данные не удалось. Возможно не существует файл 'path.txt', в котором должен быть записан путь к файлу базы данных или путь записан некорректно! Перейдите по вкладке 'Путь к базе данных'. Также следует иметь в виду, что, возможно, у вас открыт непосредственно файл базы данных, это может привести к ошибке, поээтому его следует закрыть!","Ошибка!");
            }
        }

        private void путьКБазеДанныхToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            PathToDB PTDB = new PathToDB();
            PTDB.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddScintillator ASForm = new AddScintillator();
            ASForm.Visible = true;
            ASForm.path = path;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddDetector ADForm = new AddDetector();
            ADForm.Visible = true;
            ADForm.path = path;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddPhotomultiplier APForm = new AddPhotomultiplier();
            APForm.Visible = true;
            APForm.path = path;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + path + ";";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    int selected_row_index = row.Index;
                    string removed_scintillators = dataGridView2.Rows[selected_row_index].Cells[0].Value.ToString();
                    string SQLQuery = "DELETE FROM Сцинтилляторы WHERE №=" + removed_scintillators;
                    OleDbCommand command1 = new OleDbCommand(SQLQuery, connection1);
                    OleDbDataReader dataReader1 = command1.ExecuteReader();
                }
                connection1.Close();
                MessageBox.Show("Данные по сцинтилляторам удалены", "Уведомление");
            }
            catch
            {
                MessageBox.Show("Данные по сцинтиллторам не были удалены", "Ошибка");
            }          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + path + ";";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    int selected_row_index = row.Index;
                    string removed_photomultipliers = dataGridView1.Rows[selected_row_index].Cells[0].Value.ToString();
                    string SQLQuery = "DELETE FROM ФЭУ WHERE №=" + removed_photomultipliers;
                    OleDbCommand command1 = new OleDbCommand(SQLQuery, connection1);
                    OleDbDataReader dataReader1 = command1.ExecuteReader();
                }
                connection1.Close();
                MessageBox.Show("Данные по ФЭУ удалены", "Уведомление");
            }
            catch
            {
                MessageBox.Show("Данные по ФЭУ не были удалены", "Ошибка");
            } 
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + path + ";";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                foreach (DataGridViewRow row in dataGridView3.SelectedRows)
                {
                    int selected_row_index = row.Index;
                    string removed_detectors = dataGridView3.Rows[selected_row_index].Cells[0].Value.ToString();
                    string SQLQuery = "DELETE FROM Детекторы WHERE №='" + removed_detectors + "'";
                    OleDbCommand command1 = new OleDbCommand(SQLQuery, connection1);
                    OleDbDataReader dataReader1 = command1.ExecuteReader();
                }
                connection1.Close();
                MessageBox.Show("Данные по детекторам удалены", "Уведомление");
            }
            catch
            {
                MessageBox.Show("Данные по детекторам не были удалены", "Ошибка");
            } 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.button5_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                int selected_row_index = row.Index;
                string editable_scintillators = dataGridView2.Rows[selected_row_index].Cells[0].Value.ToString();
                EditScintillators ESForm = new EditScintillators();
                ESForm.Visible = true;
                ESForm.path = path;
                ESForm.textBox1.Text = editable_scintillators;
                ESForm.textBox1.Enabled = false;
                ESForm.textBox2.Text = dataGridView2.Rows[selected_row_index].Cells[1].Value.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                int selected_row_index = row.Index;
                string editable_detectors = dataGridView3.Rows[selected_row_index].Cells[0].Value.ToString();
                EditDetector EDForm = new EditDetector();
                EDForm.Visible = true;
                EDForm.path = path;
                EDForm.textBox1.Text = editable_detectors;
                EDForm.textBox1.Enabled = false;
                EDForm.textBox2.Text = dataGridView3.Rows[selected_row_index].Cells[1].Value.ToString();
                EDForm.textBox3.Text = dataGridView3.Rows[selected_row_index].Cells[2].Value.ToString();
                EDForm.textBox4.Text = dataGridView3.Rows[selected_row_index].Cells[3].Value.ToString();
                EDForm.textBox5.Text = dataGridView3.Rows[selected_row_index].Cells[4].Value.ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                int selected_row_index = row.Index;
                string editable_photomultipliers = dataGridView1.Rows[selected_row_index].Cells[0].Value.ToString();
                EditPhotomultiplier EPForm = new EditPhotomultiplier();
                EPForm.Visible = true;
                EPForm.path = path;
                EPForm.textBox1.Text = editable_photomultipliers;
                EPForm.textBox1.Enabled = false;
                EPForm.textBox2.Text = dataGridView1.Rows[selected_row_index].Cells[1].Value.ToString();
                EPForm.textBox3.Text = dataGridView1.Rows[selected_row_index].Cells[2].Value.ToString();
                EPForm.textBox4.Text = dataGridView1.Rows[selected_row_index].Cells[3].Value.ToString();
                EPForm.textBox5.Text = dataGridView1.Rows[selected_row_index].Cells[4].Value.ToString();
                EPForm.textBox6.Text = dataGridView1.Rows[selected_row_index].Cells[5].Value.ToString();
                EPForm.textBox7.Text = dataGridView1.Rows[selected_row_index].Cells[6].Value.ToString();
                EPForm.textBox8.Text = dataGridView1.Rows[selected_row_index].Cells[7].Value.ToString();
                EPForm.textBox9.Text = dataGridView1.Rows[selected_row_index].Cells[8].Value.ToString();
                EPForm.textBox10.Text = dataGridView1.Rows[selected_row_index].Cells[9].Value.ToString();
            }
        }   
    }
}
