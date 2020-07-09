using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Net;

namespace Admin_Panel_Finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread islem;

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.turklojen.com/iletisim.html");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.turklojen.com/");
        }

        private void button6_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("https://anonofficial.com/");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://anonsturkey.com/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        void Tarama()
        {
            
            int kactane = listBox1.Items.Count;
            for (int i = 0; i < kactane; i++)
            {
                try
                {
                    HttpWebRequest istek = (HttpWebRequest)HttpWebRequest.Create(textBox1.Text + listBox1.Items[i].ToString());
                    HttpWebResponse cevap = (HttpWebResponse)istek.GetResponse();
                    string durum = cevap.StatusCode.ToString();

                    if (durum == "OK")
                    {
                        listBox2.Items.Add(listBox1.Items[i].ToString() + " ||    SUCCESSFUL ");
                        label3.Text = listBox1.Items[i].ToString();
                        label3.ForeColor = Color.Green;
                    }
                    else
                    {
                        
                    }
                }
                catch 
                {

                    listBox2.Items.Add(listBox1.Items[i].ToString() + " ||   UNSUCCESSFUL ");
                }
               
            }

            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This Program was written by AnonsTurkey member TurKLoJeN", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StreamReader oku = new StreamReader(Application.StartupPath + "/Wordlist.txt");
            string metin = oku.ReadLine();
            while (metin != null)
            {
                listBox1.Items.Add(metin);
                metin = oku.ReadLine();
            }
            CheckForIllegalCrossThreadCalls = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            islem = new Thread(new ThreadStart(Tarama));
            islem.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            islem.Abort();
        }
    }
}
