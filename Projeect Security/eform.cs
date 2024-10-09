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

    public partial class eform : Form
    {
        public int E;
        public int f;
        public int pin;
        public int qin;
        public int min;
        public int nin;
        public int phin;
        public int x;
        public int d;
        public eform(string p, string q, string m, string n, string phi)
        {
            InitializeComponent();
            label1.Text = "p = " + p;
            label2.Text = "q = " + q;
            label3.Text = "m = " + m;
            label4.Text = "n = " + n;
            label5.Text = "phi = " + phi;
            phin = int.Parse(phi);
            pin  = int.Parse(p);
            qin  = int.Parse(q);
            min  = int.Parse(m);
            nin = int.Parse(n);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            E = int.Parse(textBox1.Text);

            checkvalidE(E, phin);
            if (f == 1)
            {
                for (int x = 1; x < phin; x++)
                    if (((E % phin) * (x % phin)) % phin == 1)
                        d = x;            
            }

            MessageBox.Show("decryption key  = " + d);
            EnOrDy edform = new EnOrDy(pin.ToString(), qin.ToString(), min.ToString(), nin.ToString(),
            phin.ToString(), E.ToString(), d.ToString());
            edform.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void checkvalidE(int Ec, int phic)
        {
            if (1 < Ec && Ec < phic)
            {
                for (;;)
                {
                    if (Ec > phic)
                    {
                        Ec = Ec - phic;
                    }
                    else
                    {
                        phic = phic - Ec;
                    }
                    if (Ec == 1 || phic == 1)
                    {
                        MessageBox.Show("E is valid");
                        f = 1;
                        break;
                    }
                    if (Ec < 1 || phic < 1)
                    {
                        MessageBox.Show("e is invalid please try again");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("e is invalid please try again");
            }
        }
    }
}
