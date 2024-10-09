using RSA;
using Sdees;
using SecuProj;
using Simplified_RC4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeect_Security
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SDES s = new SDES();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            playfair.playfair p = new playfair.playfair();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rc r = new rc();
            r.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saes f = new saes();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 r = new Form1();
            r.Show();
        }
    }
}
