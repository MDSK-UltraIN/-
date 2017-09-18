using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WindowsFormsApp2
{
    

    public partial class 電子行事曆 : Form
    {
        string things;//項目
        string date;//時間
        string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "storage.txt");

        //System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("D:/Desktop/storage.txt");
        public 電子行事曆()
        {
            InitializeComponent();
           
        }
        //新增項目
        private void button1_Click(object sender, EventArgs e)
        {
            
            things = textBox1.Text;
            if (things == "") things = "N/A";
            date = textBox2.Text;
            if (date == "") date = "N/A";
            listBox1.Items.Add(things+"       "+date);
            textBox1.Clear();
            //textBox2.Clear();

            for (int i = 0; i < listBox1.Items.Count; i++) {

            }

            storeplan();
        }
        //雙擊刪除項目
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            storeplan();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Today.ToString("yyyy /MM/dd");
            //建立時鐘
            StartTimer();
            Loadplan();
        }

        //時鐘的程式馬
        System.Windows.Forms.Timer t = null;
        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
        }

        void storeplan() {

            
            //File.Create(destPath);
            //MessageBox.Show(destPath);
            var sb = new StringBuilder();
                foreach (var item in listBox1.Items)
                {
                    // i am using the .ToString here, you may do more
                    sb.AppendLine(item.ToString());
                }
                string data = sb.ToString();
                foreach (var item in listBox1.Items)
                {
                    System.IO.File.WriteAllText(destPath, data);

                }
            }
        void Loadplan() {
            List<string> lines = new List<string>();
            using (StreamReader r = new StreamReader(destPath))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    listBox1.Items.Add(line);
                }
            }
        }
            
            
        
    }
}
