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
    public partial class AddDetector : Form
    {
        public string path;
        public AddDetector()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amount_of_points = 0;
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == '.')
                {
                    amount_of_points++;
                }
            }
            if (amount_of_points != 2)
            {
                MessageBox.Show("Номер детектора не может быть записан в таком виде(номер должен содержать цифры и две точки). Добавить данные не удалось, попробуйте снова!", "Ошибка");
                return;
            }
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + path + ";";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                string SQLQuery = "INSERT INTO Детекторы(№, ФЭУ, Сцинтиллятор, Рабочее_напряжение_питания_ФЭУ,Сопротивление_балластника) VALUES('" + textBox1.Text + "'," + textBox2.Text + "," + textBox3.Text+","+ textBox4.Text+ ","+textBox5.Text +")";
                OleDbCommand command1 = new OleDbCommand(SQLQuery, connection1);
                OleDbDataReader dataReader1 = command1.ExecuteReader();
                connection1.Close();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Добавить сцинтиллятор в базу данных не удалось. Проверьте корректность введенных данных", "Ошибка");
            }
        }
    }
}
