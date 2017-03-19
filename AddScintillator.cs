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
    public partial class AddScintillator : Form
    {
        public string path;
        public AddScintillator()
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
                string SQLQuery = "INSERT INTO Сцинтилляторы(№, Относит_световыход) VALUES(" + textBox1.Text + "," + textBox2.Text + ")";
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
