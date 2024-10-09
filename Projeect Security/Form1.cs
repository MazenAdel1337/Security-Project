using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Form1 : Form
    {
        public int p;
        public int q;
        public int m;
        public int n;
        public int phi;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = int.Parse(textBox1.Text);
            q = int.Parse(textBox2.Text);
            m = int.Parse(textBox3.Text);
            n = p * q;
            phi = (p - 1) * (q - 1);            
            eform ewin = new eform(p.ToString(),q.ToString(),m.ToString(),n.ToString(),phi.ToString());
            ewin.Show();
            

        }
    }
}
