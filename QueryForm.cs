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
    public partial class QueryForm : Form
    {
        string path="";
        public QueryForm()
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

        public Label L1 = new Label();  // Метка для ФЭУ и Сцинтиллятора
        public TextBox TB1 = new TextBox();  // Textbox для ФЭУ и Сцинтиллятора

        private void button1_Click(object sender, EventArgs e)
        {
            TB1.Location = new Point(755, 95);
            this.Controls.Add(L1);
            this.Controls.Add(TB1);
            L1.Location = new Point(600, 100);
            if (comboBox1.SelectedIndex.ToString() == "0")
            {
               TB1.Left = 760;
               L1.Width = 140;
               L1.Text = "Укажите номер ФЭУ";
            }
            else if (comboBox1.SelectedIndex.ToString() == "1")
            {
               TB1.Left += 40;
               L1.Width = 170;
               L1.Text = "Укажите номер сцинтиллятора";
            }
            else if (comboBox1.SelectedItem == "Информация по детектору")
            {
                TB1.Left += 40;
                L1.Width = 170;
                L1.Text = "Укажите номер детектора";
            }
            else if (comboBox1.SelectedItem == "Информация по детектирующей станции")
            {
                TB1.Left += 100;
                L1.Width = 220;
                L1.Text = "Укажите номер детектирующей станции";
            }
            else if (comboBox1.SelectedItem == "Информация по кластеру")
            {
                TB1.Left += 40;
                L1.Width = 170;
                L1.Text = "Укажите номер кластера";
            }
           
        }

        public TextBox QueryTB = new TextBox();


        public void Query(string QueryPlace, string SQLQuery)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + textBox1.Text + ";";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                if (QueryPlace == "ThisWindow" && (comboBox1.SelectedItem == "Местонахождение ФЭУ" || comboBox1.SelectedItem == "Местонахождение сцинтиллятора"))
                {
                    this.Controls.Add(QueryTB);
                    QueryTB.Multiline = true;
                    QueryTB.Dock = DockStyle.Bottom;
                    QueryTB.Height = 200;
                    QueryTB.ScrollBars = ScrollBars.Vertical;
                    OleDbCommand command1 = new OleDbCommand(SQLQuery, connection1);
                    OleDbDataReader DataReader1 = command1.ExecuteReader();
                    //String place;
                    if (comboBox1.SelectedItem == "Местонахождение ФЭУ")
                    {
                        while (DataReader1.Read())
                        {
                            QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader1["Детектор"] + Environment.NewLine + "Номер ФЭУ: " + DataReader1["ФЭУ"] + Environment.NewLine;
                            QueryTB.Text += "--------------------------------------------" + Environment.NewLine;
                        }
                    }
                    else if (comboBox1.SelectedItem == "Местонахождение сцинтиллятора")
                    {
                        while (DataReader1.Read())
                        {
                            QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader1["Детектор"] + Environment.NewLine + "Номер сцинтиллятора: " + DataReader1["Сцинтиллятор"] + Environment.NewLine;
                            QueryTB.Text += "--------------------------------------------" + Environment.NewLine;
                        }
                    }
                }
                else if (QueryPlace == "NewWindow" && comboBox1.SelectedItem == "Информация по детектору")
                {
                    ReportForm RF = new ReportForm();
                    RF.Visible = true;
                    RF.Text = "Детектор № " + TB1.Text.ToString();
                    RF.textBox1.Text = "Детектору";
                    RF.textBox2.Text = TB1.Text;
                    RF.textBox3.Text = textBox1.Text;
                    RF.FullDetectorQuery(SQLQuery);
                }
                /*else if (QueryPlace == "ThisWindow")
                {
                    string dbLocation = System.IO.Path.GetFullPath("C:/Users/Николай/Desktop/Nevod.accdb");
                    DataGridView DataGridView1 = new DataGridView();
                    //DataGridView1.Name = "QueryResult";
                    DataGridView1.Width = 400;
                    DataGridView1.Height = 220;
                    DataGridView1.DataMember = "Table";
                    DataGridView1.Dock = DockStyle.Bottom;
                    this.Controls.Add(DataGridView1);
                    // Подключаемся к базе данных SQL Server
                    // string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "DataSource C:/Users/Николай/Desktop/Nevod.mdb;";
                    //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=C:/Users/Николай/Desktop/Nevod.accdb;";
                    // Объект DataAdapter выступает в роли посредника при взаимодействии базы данных и хранящегося в памяти объекта DataTable
                    //OleDbConnection connection1 = new OleDbConnection(connectionString);
                    //connection1.Open();
                    // DataSet сохраняет данные в памяти с помощью таблиц данных DataTable
                    DataSet dataSet1 = new DataSet();
                    // Объект DataAdapter является посредником при взаимодействии базы данных и объекта DataSet
                    OleDbDataAdapter sqlDataAdapter1 = new OleDbDataAdapter();
                    sqlDataAdapter1.SelectCommand = new OleDbCommand(SQLQuery, connection1);
                    // Теперь заполняем находящийся в памяти объект DataSet данными
                    sqlDataAdapter1.Fill(dataSet1);
                    // Привязываем элемент DataGridView (визуальную таблицу) к хранящимся в памяти данным
                    DataGridView1.DataSource = dataSet1;
                    // Закрываем подключение к базе данных
                    //connection1.Close();
                } */
                connection1.Close();

            }
            catch
            {
                MessageBox.Show("Возможно, вы ошиблись при вводе пути к файлу базы данных.", "Ошибка!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string[] number_part = TB1.Text.Split(new char[] { ' ' });
            int amount_of_points = 0;
            for (int i = 0; i < TB1.Text.Length; i++)
            {
                if (TB1.Text[i] == '.')
                {
                    amount_of_points++;
                }
            }
            if (comboBox1.SelectedItem == "Информация по детектору" && amount_of_points != 2)
            {
                MessageBox.Show("Номер детектора задан неверно!", "Уведомление");
                return;
            }
            else if (comboBox1.SelectedItem == "Информация по кластеру" && amount_of_points != 0)
            {
                MessageBox.Show("Номер кластера задан неверно!", "Уведомление");
                return;
            }
            else if (comboBox1.SelectedItem == "Информация по детектирующей станции" && amount_of_points != 1)
            {
                MessageBox.Show("Номер детектирующей станции задан неверно!", "Уведомление");
                return;
            }
            string QueryPlace = "";
            string SQLQuery;
            //SQLQuery = "SELECT * FROM ФЭУ";
            if (comboBox1.SelectedItem == "Местонахождение ФЭУ")
            {
                SQLQuery = "SELECT ФЭУ.[№] AS ФЭУ, Детекторы.[№] AS Детектор FROM ФЭУ, Детекторы WHERE ФЭУ.[№]=Детекторы.ФЭУ AND ФЭУ.[№]="+ TB1.Text;
                Query("ThisWindow", SQLQuery);
            }
            else if (comboBox1.SelectedItem == "Местонахождение сцинтиллятора")
            {
                SQLQuery = "SELECT Сцинтилляторы.№ AS Сцинтиллятор, Детекторы.№ AS Детектор FROM Сцинтилляторы, Детекторы WHERE Сцинтилляторы.№ = Детекторы.Сцинтиллятор AND Сцинтилляторы.№=" + TB1.Text;
                Query("ThisWindow", SQLQuery);
            }
            else if (comboBox1.SelectedItem == "Информация по детектору")
            {
                if (RBFullReport.Checked == true)
                {
                    SQLQuery = "SELECT Детекторы.№ AS Детектор, ФЭУ.№ AS ФЭУ, Детекторы.Рабочее_напряжение_питания_ФЭУ, ФЭУ.Коэф_усиления, ФЭУ.Напряжение, ФЭУ.Чувствительность_СИД, ФЭУ.Чувствительность_сцинтиллятор, ФЭУ.Линейность, ФЭУ.Джиттер,ФЭУ.Шумы_U, ФЭУ.Шумы_U_плюс_100, ФЭУ.Шумы_U_минус_100 FROM Детекторы, ФЭУ WHERE ФЭУ.№ = Детекторы.ФЭУ AND Детекторы.№= '" + TB1.Text.ToString()+"'";
                    Query("NewWindow", SQLQuery);
                    /*SQLQuery = "SELECT Сцинтилляторы.№ AS Сцинтиллятор, Детекторы.№ AS Детектор FROM Сцинтилляторы, Детекторы WHERE Сцинтилляторы.№ = Детекторы.Сцинтиллятор AND Детекторы.№='1.1.2'"; 
                    Query(QueryPlace, SQLQuery); */
                }
                else if (RBShortReport.Checked == true)
                {
                    ReportForm RF = new ReportForm();
                    RF.Visible = true;
                    RF.textBox1.Text = "Детектору";
                    RF.textBox2.Text = TB1.Text;
                    RF.textBox3.Text = textBox1.Text;
                    RF.Text = "Детектор № " + TB1.Text.ToString();
                    RF.ShortDetectorQuery();
                }
                else if (RBShortReport.Checked == false && RBFullReport.Checked == false)
                {
                    MessageBox.Show("Выберите полноту отчета", "Уведомление");
                }
                //Query(QueryPlace, SQLQuery);
            }
            else if (comboBox1.SelectedItem == "Информация по детектирующей станции")
            {
                if (RBFullReport.Checked == true)
                {
                    ReportForm RF = new ReportForm();
                    RF.Visible = true;
                    RF.textBox1.Text = "Детектирующей станции";
                    RF.textBox2.Text = TB1.Text;
                    RF.textBox3.Text = textBox1.Text;
                    RF.Text = "Детектирующая станция № " + TB1.Text.ToString();
                    RF.FullDetectingStationQuery();
                }
                else if (RBShortReport.Checked == true)
                {
                    ReportForm RF = new ReportForm();
                    RF.Visible = true;
                    RF.textBox1.Text = "Детектирующей станции";
                    RF.textBox2.Text = TB1.Text;
                    RF.textBox3.Text = textBox1.Text;
                    RF.Text = "Детектирующая станция № " + TB1.Text.ToString();
                    RF.ShortDetectingStationQuery();
                }
                else if (RBShortReport.Checked == false && RBFullReport.Checked == false)
                {
                    MessageBox.Show("Выберите полноту отчета", "Уведомление");
                }
            }
            else if (comboBox1.SelectedItem == "Информация по детектирующей станции")
            {
                if (RBFullReport.Checked == true)
                {
                    ReportForm RF = new ReportForm();
                    RF.Visible = true;
                    RF.textBox1.Text = "Детектирующей станции";
                    RF.textBox2.Text = TB1.Text;
                    RF.textBox3.Text = textBox1.Text;
                    RF.Text = "Детектирующая станция № " + TB1.Text.ToString();
                    RF.FullDetectingStationQuery();
                }
                else if (RBShortReport.Checked == true)
                {
                    ReportForm RF = new ReportForm();
                    RF.Visible = true;
                    RF.textBox1.Text = "Детектирующей станции";
                    RF.textBox2.Text = TB1.Text;
                    RF.textBox3.Text = textBox1.Text;
                    RF.Text = "Детектирующая станция № " + TB1.Text.ToString();
                    RF.ShortDetectingStationQuery();
                }
                else if (RBShortReport.Checked == false && RBFullReport.Checked == false)
                {
                    MessageBox.Show("Выберите полноту отчета", "Уведомление");
                }
            }
            else if (comboBox1.SelectedItem == "Информация по кластеру")
            {
                if (RBFullReport.Checked == true)
                {
                    ReportForm RF = new ReportForm();
                    RF.Visible = true;
                    RF.textBox1.Text = "Кластеру";
                    RF.textBox2.Text = TB1.Text;
                    RF.textBox3.Text = textBox1.Text;
                    RF.Text = "Кластер № " + TB1.Text.ToString();
                    RF.FullClusterQuery();
                }
                else if (RBShortReport.Checked == true)
                {
                    ReportForm RF = new ReportForm();
                    RF.Visible = true;
                    RF.textBox1.Text = "Кластеру";
                    RF.textBox2.Text = TB1.Text;
                    RF.textBox3.Text = textBox1.Text;
                    RF.Text = "Кластер № " + TB1.Text.ToString();
                    RF.ShortClusterQuery();
                }
                else if (RBShortReport.Checked == false && RBFullReport.Checked == false)
                {
                    MessageBox.Show("Выберите полноту отчета", "Уведомление");
                }
            }           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.Controls.Contains(TB1))
            {
                this.Controls.Remove(TB1);
                TB1.Clear();
                //TB1.Dispose();
            }
            if (this.Controls.Contains(L1))
            {
                this.Controls.Remove(L1);
                //L1.Dispose();
            }
            if (this.Controls.Contains(QueryTB))
            {
                this.Controls.Remove(QueryTB);
                QueryTB.Clear();
                //QueryTB.Dispose();
            }
        }
    }
}
