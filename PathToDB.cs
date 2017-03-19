using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NEVOD
{
    public partial class PathToDB : Form
    {
        public PathToDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Encoding enc = Encoding.GetEncoding(1251);
            string name = "Path.txt";
            File.WriteAllText(name, textBox2.Text, enc);
            this.Close();
        }
    }
}
