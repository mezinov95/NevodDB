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
    public partial class AdditionForm : Form
    {
        public AdditionForm()
        {
            InitializeComponent();
        }

        private void AddDetStation_Click(object sender, EventArgs e)
        {
            int amount_of_points = 0;
            for (int i = 0; i < AddDetStationTB.Text.Length; i++)
            {
                if (AddDetStationTB.Text[i] == '.')
                {
                    amount_of_points++;
                }
            }
            if (amount_of_points != 1)
            {
                MessageBox.Show("Номер детектирующей станции не может быть записан в таком виде(номер должен содержать цифры и одну точку). Добавить данные не удалось, попробуйте снова!", "Ошибка");
                return;
            }

            if( VoltageTB.Text != "" && AddDetStationTB.Text != "")
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + PathToDB.Text + ";";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                string SQLQuery;
                string detector_1 = AddDetStationTB.Text + ".1";
                string detector_2 = AddDetStationTB.Text + ".2";
                string detector_3 = AddDetStationTB.Text + ".3";
                string detector_4 = AddDetStationTB.Text + ".4";
                string detector_5 = AddDetStationTB.Text + ".5";
                SQLQuery = "INSERT INTO Детектирующие_станции(№, Напряжение_питания, детектор1, детектор2, детектор3, детектор4, детектор5) VALUES ('" + AddDetStationTB.Text + "'," + VoltageTB.Text +", '"+ detector_1 + "', '" + detector_2 + "', '" + detector_3 +"', '"+ detector_4 + "','" + detector_5  +  "')";
                OleDbCommand command1 = new OleDbCommand(SQLQuery, connection1);
                OleDbDataReader dataReader1 = command1.ExecuteReader();
            }
            else
            {
                MessageBox.Show("Не оставляйте поля пустыми. Данные добавить не удалось!", "Ошибка");
            }
        }

        private void AddCluster_Click(object sender, EventArgs e)
        {
            int amount_of_points = 0;
            for (int i = 0; i < AddClusterTB.Text.Length; i++)
            {
                  if (AddClusterTB.Text[i] == '.')
                  {
                      amount_of_points++;
                 }
            }
            if (amount_of_points != 0)
            {
                MessageBox.Show("Номер кластера не может быть записан в таком виде(номер должен содержать только цифры). Добавить данные не удалось, попробуйте снова!", "Ошибка");
                return;
            }

            if( AddClusterTB.Text != "")
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + PathToDB.Text + ";";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                string SQLQuery;
                string station_1 = AddClusterTB.Text + ".1";
                string station_2 = AddClusterTB.Text + ".2";
                string station_3 = AddClusterTB.Text + ".3";
                string station_4 = AddClusterTB.Text + ".4";
                SQLQuery = "INSERT INTO Кластеры(№,Станция1, Станция2, Станция3, Станция4) VALUES ('" + AddClusterTB.Text + "', '"+ station_1 + "', '" + station_2 + "', '" + station_3 +"', '"+ station_4 + "')";
                OleDbCommand command1 = new OleDbCommand(SQLQuery, connection1);
                OleDbDataReader dataReader1 = command1.ExecuteReader();
            }
            else
            {
                MessageBox.Show("Не оставляйте поля пустыми. Данные добавить не удалось!", "Ошибка");
            }
        }

        private void RemoveDetStation_Click(object sender, EventArgs e)
        {
            if (RemoveDetStationTB.Text == "")
            {
                MessageBox.Show("Не оставляйте поле пустым. Данные удалить не удалось!", "Ошибка");
                return;
            }
            int amount_of_points = 0;
            for (int i = 0; i < RemoveDetStationTB.Text.Length; i++)
            {
                if (RemoveDetStationTB.Text[i] == '.')
                {
                    amount_of_points++;
                }
            }
            if (amount_of_points != 1)
            {
                MessageBox.Show("Номер детектирующей станции не может быть записан в таком виде(номер должен содержать цифры и одну точку). Удалить данные не удалось, попробуйте снова!", "Ошибка");
                return;
            }
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + PathToDB.Text + ";";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                string SQLQuery;
                SQLQuery = "DELETE FROM Детектирующие_станции WHERE №='" + RemoveDetStationTB.Text + "'";
                OleDbCommand command1 = new OleDbCommand(SQLQuery, connection1);
                OleDbDataReader dataReader1 = command1.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Не удалось удалить данные о детектирующей станции № " + RemoveDetStationTB.Text + " Проверьте корректность указанных данных и попробуйте снова", "Уведомление");
            }
        }

        private void RemoveCluster_Click(object sender, EventArgs e)
        {
            if (RemoveClusterTB.Text == "")
            {
                MessageBox.Show("Не оставляйте поле пустым. Данные удалить не удалось!", "Ошибка");
                return;
            }
            int amount_of_points = 0;
            for (int i = 0; i < RemoveClusterTB.Text.Length; i++)
            {
                if (RemoveClusterTB.Text[i] == '.')
                {
                    amount_of_points++;
                }
            }
            if (amount_of_points != 0)
            {
                MessageBox.Show("Номер кластера не может быть записан в таком виде(номер должен состоять из одного числа). Удалить данные не удалось, попробуйте снова!", "Ошибка");
                return;
            }
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + PathToDB.Text + ";";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                string SQLQuery;
                SQLQuery = "DELETE FROM Кластеры WHERE №='" + RemoveClusterTB.Text + "'";
                OleDbCommand command1 = new OleDbCommand(SQLQuery, connection1);
                OleDbDataReader dataReader1 = command1.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Не удалось удалить данные о кластере № " + RemoveDetStationTB.Text + " Проверьте корректность указанных данных и попробуйте снова", "Уведомление");
            }
        }
    }
}
