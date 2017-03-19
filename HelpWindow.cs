using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEVOD
{
    public partial class HelpWindow : Form
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        public void OnLoad()
        {
            richTextBox1.Text += "ОБЩИЕ СВЕДЕНИЯ" + Environment.NewLine;
            richTextBox1.Text += Environment.NewLine;
            richTextBox1.Text += "1) Детектор состоит из ФЭУ и сцинтиллятора" + Environment.NewLine;
            richTextBox1.Text += "2) Детектирующая станция состоит из 5 детекторов" + Environment.NewLine;
            richTextBox1.Text += "3) Кластер состоит 4-х детектирующих станций(т.о. в укомплектованном кластере присутствует 20 детекторов)" + Environment.NewLine;
            richTextBox1.Text += Environment.NewLine;
            richTextBox1.Text += "РАЗМЕРНОСТИ ХАРАКТЕРИСТИК, ПРИСУТСТВУЮЩИХ В БАЗЕ ДАННЫХ" + Environment.NewLine;
            richTextBox1.Text += Environment.NewLine;
            richTextBox1.Text += "№ - число(для ФЭУ и сцинтилляторов) либо строки для кластеров(1,2,3,..n), детектирующих станций(1.1,1.2,...,*.*), детекторов(1.1.1, 1.1.2,..., *.*.*)" + Environment.NewLine;
            richTextBox1.Text += "Коэф. усиления - число * 10^6" + Environment.NewLine;
            richTextBox1.Text += "Напряжение - В" + Environment.NewLine;
            richTextBox1.Text += "Чувствительность - пКл" + Environment.NewLine;
            richTextBox1.Text += "Линейность - пКл" + Environment.NewLine;
            richTextBox1.Text += "Джиттер - нс" + Environment.NewLine;
            richTextBox1.Text += "Шумы - В" + Environment.NewLine;
            richTextBox1.Text += "Относительный световыход сцинтиллятора - безразмерная величина" + Environment.NewLine;
            richTextBox1.Text += "Сопротивление(баластника) - Ом" + Environment.NewLine;
            richTextBox1.Text +=  Environment.NewLine;
        }
    }
}
