using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace base64_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string dosya = null;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                richTextBox1.ReadOnly = false;
            else
                richTextBox1.ReadOnly = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog sec = new OpenFileDialog();
            sec.Title = "Dosya Seç";
            sec.Filter = "Tüm Dosyalar|*.*";
            if (sec.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = sec.FileName;
                dosya = sec.SafeFileName;
                byte[] bytes = File.ReadAllBytes(sec.FileName);
                richTextBox1.Text = Convert.ToBase64String(bytes);
                label3.Text ="Uzunluk : "+ Convert.ToBase64String(bytes).Length.ToString();

                FileInfo info = new FileInfo(sec.FileName);
                int len =Convert.ToInt32(info.Length)/1024;
                label4.Text = "Boyut : " + len.ToString() + " kb";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                Clipboard.SetText(richTextBox1.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Title = "Kaydet";
            kaydet.Filter = "Tüm Dosyalar|*.*";
            kaydet.FileName = dosya;
            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                byte[] bytes=Convert.FromBase64String(richTextBox1.Text);
                File.WriteAllBytes(kaydet.FileName,bytes);
                MessageBox.Show("Dosya oluşturuldu", "Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
    }
}
