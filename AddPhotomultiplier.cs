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

namespace NEVOD
{
    public partial class AddPhotomultiplier : Form
    {
        public string path;
        public AddPhotomultiplier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + path + ";";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                string SQLQuery = "INSERT INTO ФЭУ(№,Коэф_усиления,Напряжение, Чувствительность_СИД, Чувствительность_сцинтиллятор, Линейность, Джиттер, Шумы_U, Шумы_U_плюс_100, Шумы_U_минус_100) VALUES(" + textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text + "," + textBox5.Text + "," + textBox6.Text + "," + textBox7.Text + "," + textBox8.Text + "," + textBox9.Text + "," + textBox10.Text + ")";
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
