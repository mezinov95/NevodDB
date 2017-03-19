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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }
        public void FullDetectorQuery(string SQLQuery)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source="+ textBox3.Text +";";
            OleDbConnection connection1 = new OleDbConnection(connectionString);
            connection1.Open();
            OleDbCommand command1 = new OleDbCommand(SQLQuery, connection1);
            OleDbDataReader DataReader1 = command1.ExecuteReader();
            
            OleDbCommand command2 = new OleDbCommand("SELECT Сцинтилляторы.№ AS Сцинтиллятор, Детекторы.№ AS Детектор, Сцинтилляторы.Относит_световыход FROM Сцинтилляторы, Детекторы WHERE Сцинтилляторы.№ = Детекторы.Сцинтиллятор AND Детекторы.№='" + textBox2.Text.ToString()+"'", connection1);
            OleDbDataReader DataReader2 = command2.ExecuteReader();
            while (DataReader2.Read())
            {
                QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader2["Детектор"] + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Номер сцинтиллятора: " + DataReader2["Сцинтиллятор"] + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Относительный световыход сцинтиллятора: " + DataReader2["Относит_световыход"] + Environment.NewLine;
            }
            while (DataReader1.Read())
            {
                    //QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader1["Детектор"] + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Номер ФЭУ: " + DataReader1["ФЭУ"] + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Коэффициент усиления ФЭУ: " + DataReader1["Коэф_усиления"] + "*10^6" + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Стандартное напряжение ФЭУ: " + DataReader1["Напряжение"] + " В" + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Рабочее напряжение ФЭУ: " + DataReader1["Рабочее_напряжение_питания_ФЭУ"] + " В" +Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Чувствительность ФЭУ на светодиоде: " + DataReader1["Чувствительность_СИД"] + " пКл" + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Чувствительность ФЭУ на сцинтилляторе: " + DataReader1["Чувствительность_сцинтиллятор"] + " пКл" + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Линейность ФЭУ: " + DataReader1["Линейность"] + " пКл" + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Джиттер ФЭУ: " + DataReader1["Джиттер"] + " нс" + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Шумы ФЭУ(U): " + DataReader1["Шумы_U"] + " В" + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Шумы ФЭУ(U+100): " + DataReader1["Шумы_U_плюс_100"] + " В" + Environment.NewLine;
                QueryTB.Text = QueryTB.Text + "Шумы ФЭУ(U-100): " + DataReader1["Шумы_U_минус_100"] + " В" + Environment.NewLine;
            }
            connection1.Close();
        }

        public void FullDetectingStationQuery()
        {
            string[] detectors = new string[10];
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + textBox3.Text + ";";
            OleDbConnection connection1 = new OleDbConnection(connectionString);
            connection1.Open();

            // Выводим напряжение питания
            OleDbCommand command0 = new OleDbCommand("SELECT Напряжение_питания FROM Детектирующие_станции WHERE №='" +textBox2.Text + "'", connection1);
            OleDbDataReader DataReader0 = command0.ExecuteReader();
            while (DataReader0.Read())
            {
                QueryTB.Text = QueryTB.Text + "Напряжение питания: " + DataReader0["Напряжение_питания"] + " В" +Environment.NewLine;
            }
            // Выводим номера детекторов, входящих в данную детектирующую станцию
            OleDbCommand command1 = new OleDbCommand("SELECT № FROM Детекторы WHERE № like '" + textBox2.Text +"%'", connection1);
            OleDbDataReader DataReader1 = command1.ExecuteReader();
            QueryTB.Text = QueryTB.Text + "Детектирующая станция №" +textBox2.Text + " включает в себя детекторы:" + Environment.NewLine;
            int amount_of_detectors,i = 0;
            while (DataReader1.Read())
            {
                detectors[i] = (string)DataReader1["№"];
                i++;
                QueryTB.Text = QueryTB.Text + "   " + DataReader1["№"] + Environment.NewLine;
            }
            amount_of_detectors = i;
            string SQLQuery;
            QueryTB.Text += "--------------------------------------------------------------------" + Environment.NewLine;
            for (int j = 0; j < amount_of_detectors; j++)
            {
                //QueryTB.Text = QueryTB.Text + detectors[j] + " ";
                QueryTB.Text = QueryTB.Text + "Детектор №" + detectors[j] + Environment.NewLine;
                OleDbCommand command2 = new OleDbCommand("SELECT Сцинтилляторы.№ AS Сцинтиллятор, Детекторы.№ AS Детектор, Сцинтилляторы.Относит_световыход FROM Сцинтилляторы, Детекторы WHERE Сцинтилляторы.№ = Детекторы.Сцинтиллятор AND Детекторы.№='" + detectors[j] + "'", connection1);
                OleDbDataReader DataReader2 = command2.ExecuteReader();
                while (DataReader2.Read())
                {
                    //QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader2["Детектор"] + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Номер сцинтиллятора: " + DataReader2["Сцинтиллятор"] + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Относительный световыход сцинтиллятора: " + DataReader2["Относит_световыход"] + Environment.NewLine;
                }

                SQLQuery = "SELECT Детекторы.№ AS Детектор, ФЭУ.№ AS ФЭУ, Детекторы.Рабочее_напряжение_питания_ФЭУ, ФЭУ.Коэф_усиления, ФЭУ.Напряжение, ФЭУ.Чувствительность_СИД, ФЭУ.Чувствительность_сцинтиллятор, ФЭУ.Линейность, ФЭУ.Джиттер,ФЭУ.Шумы_U, ФЭУ.Шумы_U_плюс_100, ФЭУ.Шумы_U_минус_100 FROM Детекторы, ФЭУ WHERE ФЭУ.№ = Детекторы.ФЭУ AND Детекторы.№= '" + detectors[j] + "'";
                OleDbCommand command3 = new OleDbCommand(SQLQuery, connection1);
                OleDbDataReader DataReader3 = command3.ExecuteReader();
                while (DataReader3.Read())
                {
                    //QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader1["Детектор"] + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Номер ФЭУ: " + DataReader3["ФЭУ"] + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Коэффициент усиления ФЭУ: " + DataReader3["Коэф_усиления"] + "*10^6" + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Стандартное напряжение ФЭУ: " + DataReader3["Напряжение"] + " В" + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Рабочее напряжение ФЭУ: " + DataReader3["Рабочее_напряжение_питания_ФЭУ"] + " В" + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Чувствительность ФЭУ на светодиоде: " + DataReader3["Чувствительность_СИД"] + " пКл" + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Чувствительность ФЭУ на сцинтилляторе: " + DataReader3["Чувствительность_сцинтиллятор"] + " пКл" + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Линейность ФЭУ: " + DataReader3["Линейность"] + " пКл" + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Джиттер ФЭУ: " + DataReader3["Джиттер"] + " нс" + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Шумы ФЭУ(U): " + DataReader3["Шумы_U"] + " В" + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Шумы ФЭУ(U+100): " + DataReader3["Шумы_U_плюс_100"] + " В" + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Шумы ФЭУ(U-100): " + DataReader3["Шумы_U_минус_100"] + " В" + Environment.NewLine;
                } 
                QueryTB.Text += "------------------------------------------------------------------" + Environment.NewLine;
            }
            connection1.Close();
        }


        public void ShortDetectingStationQuery()
        {
            string[] detectors = new string[10];
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + textBox3.Text + ";";
            OleDbConnection connection1 = new OleDbConnection(connectionString);
            connection1.Open();

            // Выводим номера детекторов, входящих в данную детектирующую станцию
            OleDbCommand command1 = new OleDbCommand("SELECT № FROM Детекторы WHERE № like '" + textBox2.Text + "%'", connection1);
            OleDbDataReader DataReader1 = command1.ExecuteReader();
            QueryTB.Text = QueryTB.Text + "Детектирующая станция №" + textBox2.Text + " включает в себя детекторы:" + Environment.NewLine;
            int amount_of_detectors, i = 0;
            while (DataReader1.Read())
            {
                detectors[i] = (string)DataReader1["№"];
                i++;
                QueryTB.Text = QueryTB.Text + "   " + DataReader1["№"] + Environment.NewLine;
            }
            amount_of_detectors = i;
            string SQLQuery;
            QueryTB.Text += "--------------------------------------------------------------------" + Environment.NewLine;
            for (int j = 0; j < amount_of_detectors; j++)
            {
                //QueryTB.Text = QueryTB.Text + detectors[j] + " ";
                QueryTB.Text = QueryTB.Text + "Детектор №" + detectors[j] + Environment.NewLine;
                OleDbCommand command2 = new OleDbCommand("SELECT Сцинтилляторы.№ AS Сцинтиллятор, Детекторы.№ AS Детектор  FROM Сцинтилляторы, Детекторы WHERE Сцинтилляторы.№ = Детекторы.Сцинтиллятор AND Детекторы.№='" + detectors[j] + "'", connection1);
                OleDbDataReader DataReader2 = command2.ExecuteReader();
                while (DataReader2.Read())
                {
                    //QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader2["Детектор"] + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Номер сцинтиллятора: " + DataReader2["Сцинтиллятор"] + Environment.NewLine;
                }

                SQLQuery = "SELECT Детекторы.№ AS Детектор, ФЭУ.№ AS ФЭУ FROM Детекторы, ФЭУ WHERE ФЭУ.№ = Детекторы.ФЭУ AND Детекторы.№='" + detectors[j] + "'";
                OleDbCommand command3 = new OleDbCommand(SQLQuery, connection1);
                OleDbDataReader DataReader3 = command3.ExecuteReader();
                while (DataReader3.Read())
                {
                    //QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader1["Детектор"] + Environment.NewLine;
                    QueryTB.Text = QueryTB.Text + "Номер ФЭУ: " + DataReader3["ФЭУ"] + Environment.NewLine;
                }
                QueryTB.Text += "------------------------------------------------------------------" + Environment.NewLine;
            }
            connection1.Close();
        }

        public void ShortDetectorQuery()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + textBox3.Text + ";";
            OleDbConnection connection1 = new OleDbConnection(connectionString);
            connection1.Open();

            // Выводим номера детекторов, входящих в данную детектирующую станцию
            OleDbCommand command1 = new OleDbCommand("SELECT №, ФЭУ, Сцинтиллятор FROM Детекторы WHERE №='"+ textBox2.Text+"'", connection1);
            OleDbDataReader DataReader1 = command1.ExecuteReader();
            QueryTB.Text = "Детектор №" + textBox2.Text + Environment.NewLine;
            while (DataReader1.Read())
            {
                QueryTB.Text += "Номер ФЭУ: " + DataReader1["ФЭУ"] + Environment.NewLine;
                QueryTB.Text += "Номер cцинтиллятора:" + DataReader1["Сцинтиллятор"] + Environment.NewLine;
            }
            connection1.Close();
        }

        public void FullClusterQuery()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + textBox3.Text + ";";
            OleDbConnection connection1 = new OleDbConnection(connectionString);
            connection1.Open();
            string space = "                  ";
            string[] detecting_stations = new string[10];
            string[] detectors = new string[30];
            int amount_of_detecting_stations, i = 0, j = 0;


            OleDbCommand command1 = new OleDbCommand("SELECT № FROM Детектирующие_станции WHERE № like '" + textBox2.Text + ".%'", connection1);
            OleDbDataReader DataReader1 = command1.ExecuteReader();

            while (DataReader1.Read())
            {
                QueryTB.Text += "Детектирующая станция № " + DataReader1["№"] + Environment.NewLine;
                detecting_stations[i] = (string)DataReader1["№"];
                OleDbCommand command2 = new OleDbCommand("SELECT № FROM Детекторы WHERE № like '" + detecting_stations[i] + ".%'", connection1);
                OleDbDataReader DataReader2 = command2.ExecuteReader();
                while (DataReader2.Read())
                {
                    QueryTB.Text += "        Детектор № " + DataReader2["№"] + Environment.NewLine;
                    detectors[j] = (string)DataReader2["№"];
                    OleDbCommand command4 = new OleDbCommand("SELECT Сцинтилляторы.№ AS Сцинтиллятор, Детекторы.№ AS Детектор, Сцинтилляторы.Относит_световыход FROM Сцинтилляторы, Детекторы WHERE Сцинтилляторы.№ = Детекторы.Сцинтиллятор AND Детекторы.№='" + detectors[j] + "'", connection1);
                    OleDbDataReader DataReader4 = command4.ExecuteReader();
                    while (DataReader4.Read())
                    {
                        //QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader2["Детектор"] + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Номер сцинтиллятора: " + DataReader4["Сцинтиллятор"] + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Относительный световыход сцинтиллятора: " + DataReader4["Относит_световыход"] + Environment.NewLine;
                    }
                    string SQLQuery = "SELECT Детекторы.№ AS Детектор, ФЭУ.№ AS ФЭУ, Детекторы.Рабочее_напряжение_питания_ФЭУ, ФЭУ.Коэф_усиления, ФЭУ.Напряжение, ФЭУ.Чувствительность_СИД, ФЭУ.Чувствительность_сцинтиллятор, ФЭУ.Линейность, ФЭУ.Джиттер,ФЭУ.Шумы_U, ФЭУ.Шумы_U_плюс_100, ФЭУ.Шумы_U_минус_100 FROM Детекторы, ФЭУ WHERE ФЭУ.№ = Детекторы.ФЭУ AND Детекторы.№= '" + detectors[j] + "'";
                    OleDbCommand command3 = new OleDbCommand(SQLQuery, connection1);
                    OleDbDataReader DataReader3 = command3.ExecuteReader();
                    while (DataReader3.Read())
                    {
                        //QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader1["Детектор"] + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Номер ФЭУ: " + DataReader3["ФЭУ"] + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Коэффициент усиления ФЭУ: " + DataReader3["Коэф_усиления"] + "*10^6" + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Стандартное напряжение ФЭУ: " + DataReader3["Напряжение"] + " В" + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Рабочее напряжение ФЭУ: " + DataReader3["Рабочее_напряжение_питания_ФЭУ"] + " В" + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Чувствительность ФЭУ на светодиоде: " + DataReader3["Чувствительность_СИД"] + " пКл" + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Чувствительность ФЭУ на сцинтилляторе: " + DataReader3["Чувствительность_сцинтиллятор"] + " пКл" + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Линейность ФЭУ: " + DataReader3["Линейность"] + " пКл" + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Джиттер ФЭУ: " + DataReader3["Джиттер"] + " нс" + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Шумы ФЭУ(U): " + DataReader3["Шумы_U"] + " В" + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Шумы ФЭУ(U+100): " + DataReader3["Шумы_U_плюс_100"] + " В" + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Шумы ФЭУ(U-100): " + DataReader3["Шумы_U_минус_100"] + " В" + Environment.NewLine;
                    }
                    QueryTB.Text += "          ----------------------------------------------------" +Environment.NewLine;
                }
                i++;
            }
            amount_of_detecting_stations = i;

        }

        public void ShortClusterQuery()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + textBox3.Text + ";";
            OleDbConnection connection1 = new OleDbConnection(connectionString);
            connection1.Open();
            string space = "                  ";
            string[] detecting_stations = new string[10];
            string[] detectors = new string[30];
            int amount_of_detecting_stations, i = 0, j = 0;


            OleDbCommand command1 = new OleDbCommand("SELECT № FROM Детектирующие_станции WHERE № like '" + textBox2.Text + ".%'", connection1);
            OleDbDataReader DataReader1 = command1.ExecuteReader();

            while (DataReader1.Read())
            {
                QueryTB.Text += "Детектирующая станция № " + DataReader1["№"] + Environment.NewLine;
                detecting_stations[i] = (string)DataReader1["№"];
                OleDbCommand command2 = new OleDbCommand("SELECT № FROM Детекторы WHERE № like '" + detecting_stations[i] + ".%'", connection1);
                OleDbDataReader DataReader2 = command2.ExecuteReader();
                while (DataReader2.Read())
                {
                    QueryTB.Text += "        Детектор № " + DataReader2["№"] + Environment.NewLine;
                    detectors[j] = (string)DataReader2["№"];
                    OleDbCommand command4 = new OleDbCommand("SELECT Сцинтилляторы.№ AS Сцинтиллятор, Детекторы.№ AS Детектор, Сцинтилляторы.Относит_световыход FROM Сцинтилляторы, Детекторы WHERE Сцинтилляторы.№ = Детекторы.Сцинтиллятор AND Детекторы.№='" + detectors[j] + "'", connection1);
                    OleDbDataReader DataReader4 = command4.ExecuteReader();
                    while (DataReader4.Read())
                    {
                        //QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader2["Детектор"] + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Номер сцинтиллятора: " + DataReader4["Сцинтиллятор"] + Environment.NewLine;
                    }
                    string SQLQuery = "SELECT Детекторы.№ AS Детектор, ФЭУ.№ AS ФЭУ FROM Детекторы, ФЭУ WHERE ФЭУ.№ = Детекторы.ФЭУ AND Детекторы.№= '" + detectors[j] + "'";
                    OleDbCommand command3 = new OleDbCommand(SQLQuery, connection1);
                    OleDbDataReader DataReader3 = command3.ExecuteReader();
                    while (DataReader3.Read())
                    {
                        //QueryTB.Text = QueryTB.Text + "Номер детектора: " + DataReader1["Детектор"] + Environment.NewLine;
                        QueryTB.Text = QueryTB.Text + space + "Номер ФЭУ: " + DataReader3["ФЭУ"] + Environment.NewLine;
                    }
                }
                i++;
            }
            amount_of_detecting_stations = i;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream mystr = null;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystr = saveFileDialog1.OpenFile()) != null)
                {
                    //Создаём класс по работе с файлом
                    StreamWriter mywr = new StreamWriter(mystr);
                    //Записываем в память значение текстового поля
                    mywr.Write(QueryTB.Text);
                    //Записываем в файл
                    mywr.WriteLine();
                    //Закрываем файл (!обязательно)
                    mywr.Close();
                    mystr.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
