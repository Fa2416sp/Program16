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

namespace Program16
{
    public partial class Form1 : Form
    {
        string[] spisok = new string[10];
        string[] vozrast = new string[10];
        string[] ves = new string[10];
        string[] list = new string[10];

        string filename;
        int i, j, k, vt, vd, m, u;

        public Form1()
        {
            InitializeComponent();
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) ;
            {
                filename = openFileDialog1.FileName;
                StreamReader f1 = new StreamReader(openFileDialog1.OpenFile() as FileStream, System.Text.Encoding.Default);
                spisok = File.ReadAllLines(filename, Encoding.Default);
                listBox1.Items.Clear();
                for (int i = 0; i < spisok.Length; i++)
                    listBox1.Items.Add(spisok[i]);
                f1.Close();
                openFileDialog1.Dispose();
                textBox4.Text = Convert.ToString(spisok.Length);
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK) ;
            {
                filename = openFileDialog1.FileName;
                StreamReader f2 = new StreamReader(openFileDialog1.OpenFile() as FileStream, System.Text.Encoding.Default);
                vozrast = File.ReadAllLines(filename, Encoding.Default);
                listBox2.Items.Clear();
                for (int i = 0; i < vozrast.Length; i++)
                    listBox2.Items.Add(vozrast[i]);
                f2.Close();
                openFileDialog1.Dispose();
                textBox4.Text = Convert.ToString(vozrast.Length);
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK) ;
            {
                filename = openFileDialog1.FileName;
                StreamReader f3 = new StreamReader(openFileDialog1.OpenFile() as FileStream, System.Text.Encoding.Default);
                ves = File.ReadAllLines(filename, Encoding.Default);
                listBox3.Items.Clear();
                for (int i = 0; i < ves.Length; i++)
                    listBox3.Items.Add(ves[i]);
                f3.Close();
                openFileDialog1.Dispose();
                textBox4.Text = Convert.ToString(ves.Length);
            }
        }

        private void вывестиВПолеСоСпискомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader f1 = new StreamReader(openFileDialog1.OpenFile() as FileStream, System.Text.Encoding.Default);
            StreamReader f2 = new StreamReader(openFileDialog1.OpenFile() as FileStream, System.Text.Encoding.Default);
            StreamReader f3 = new StreamReader(openFileDialog1.OpenFile() as FileStream, System.Text.Encoding.Default);
            k = Convert.ToInt32(textBox4.Text);
            m = Convert.ToInt32(textBox3.Text);
            vd = Convert.ToInt32(textBox2.Text);
            vt = Convert.ToInt32(textBox1.Text);
            j = 0;
            for (int i = 0; i < k; i++)
            {
                if ((Convert.ToInt32(ves[i]) < m) && (Convert.ToInt32(vozrast[i]) >= vt) && (Convert.ToInt32(vozrast[i]) <= vd))
                {
                    j++;
                    list[j] = spisok[i] + "  " + vozrast[i] + "  " + ves[i];
                    listBox4.Items.Add(list[j]);
                }
            }
        }

        private void СуммарныйВесToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int sum;
            sum = 0;
            for (int i = 0; i < k; i++)
            {
                if ((Convert.ToInt32(ves[i]) < m) && (Convert.ToInt32(vozrast[i]) >= vt) && (Convert.ToInt32(vozrast[i]) <= vd))
                {
                    sum = sum + Convert.ToInt32(ves[i]);
                }
            }
            textBox5.Text = Convert.ToString(sum);
        }

        private void дбавкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double dov;
            dov = 0;
            for (int i = 0; i < k; i++)
            {
                if ((Convert.ToInt32(ves[i]) < m) && (Convert.ToInt32(vozrast[i]) >= vt) && (Convert.ToInt32(vozrast[i]) <= vd))
                {
                    dov = dov + 0.2;
                }
            }
            textBox7.Text = Convert.ToString(dov);
        }

        private void датаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string List;
            List = " ";
            for (int i = 0; i <= j; i++)
            {
                List = List + List[i] + Environment.NewLine;
            }
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt";
            saveFileDialog1.ShowDialog();
            if ((saveFileDialog1.FileName != ""))
            {
                StreamWriter f = new StreamWriter(saveFileDialog1.OpenFile() as FileStream, Encoding.Default);
                f.WriteLine("Дата:{0}", DateTime.Now.ToLongDateString());
                f.Write("Время:{0}", DateTime.Now.ToLongTimeString());
                f.WriteLine(List);
                f.Close();
            }
            textBox6.Text = saveFileDialog1.FileName;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}