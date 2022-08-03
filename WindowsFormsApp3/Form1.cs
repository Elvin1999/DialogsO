using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in this.Controls)
                {
                    if(item is Label lb)
                    {
                        lb.Font = fontDialog1.Font;
                        lb.ForeColor = fontDialog1.Color;
                    }
                    else if(item is Button bt)
                    {
                        bt.Font= fontDialog1.Font;
                        bt.ForeColor = fontDialog1.Color;
                    }
                }
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files(*.*)|*.*|Text Files(*.txt)| *.txt ||";
            openFileDialog.FilterIndex = 1;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr=new StreamReader(openFileDialog.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw=new StreamWriter(saveFileDialog.FileName))
                {
                    sw.Write(richTextBox1.Text);
                    richTextBox1.Text = String.Empty;
                }
            }
        }
    }
}
