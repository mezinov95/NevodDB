﻿using System;
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
    public partial class EditScintillators : Form
    {
        public EditScintillators()
        {
            InitializeComponent();
        }
        public string path;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + path + ";";
                OleDbConnection connection1 = new OleDbConnection(connectionString);
                connection1.Open();
                string SQLQuery = "UPDATE Сцинтилляторы SET Относит_световыход=" + textBox2.Text + " WHERE №=" + textBox1.Text;
                OleDbCommand command1 = new OleDbCommand(SQLQuery, connection1);
                OleDbDataReader dataReader1 = command1.ExecuteReader();
                connection1.Close();
                MessageBox.Show("Данные по сцинтиллятору № " + textBox1.Text + " были изменены", "Уведомление");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Данные по сцинтиллятору № " + textBox1.Text + " не были изменены", "Ошибка");
                this.Close();
            } 
        }
    }
}
