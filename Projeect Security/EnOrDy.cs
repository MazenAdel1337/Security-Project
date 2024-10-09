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
    public partial class EnOrDy : Form
    {
        public int pin;
        public int qin;
        public int min;
        public int nin;
        public int phin;
        public int Ein;
        public int din;
        public int[] b = new int[10];
        public int[] a = new int[10];
        public int i;
        public int z;
        public int c = 1;

        public EnOrDy(string p, string q, string m, string n, string phi, string E, string d)
        {
            InitializeComponent();
            label1.Text = "p = " + p;
            label2.Text = "q = " + q;
            label3.Text = "m = " + m;
            label4.Text = "n = " + n;
            label5.Text = "phi = " + phi;
            label6.Text = "e = " + E;
            label7.Text = "d = " + d;
            phin = int.Parse(phi);
            pin = int.Parse(p);
            qin = int.Parse(q);
            min = int.Parse(m);
            nin = int.Parse(n);
            Ein = int.Parse(E);
            din = int.Parse(d);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EnOrDy_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //encryption
            for (i = 0; Ein > 0; i++)
            {
                b[i] = Ein % 2;
                Ein = Ein / 2;

            }
            int j = 0;
            for (i = i - 1; i >= 0; i--)
            {
                a[j] = b[i];
                j++;
            }
            for (i =  0 ; i < j  ; i++)
            {
                if (a[i] == 1 )
                {
                    c = (c * c) % nin;
                    c = (c * min) % nin;
                }
                if (a[i] == 0)
                {
                    if (i == 0)
                    {
                        c = 0;
                        break;
                    }
                    c = (c * c) % nin;
                }
            }
            MessageBox.Show("Ciphertext = " + c);
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //decryption
            for (i = 0; din > 0; i++)
            {
                b[i] = din % 2;
                din = din / 2;
            }
            int j = 0;
            for (i = i - 1; i >= 0; i--)
            {
                a[j] = b[i];
                j++;
            }
            for (i = 0; i < j; i++)
            {
                if (a[i] == 1)
                {
                    c = (c * c) % nin;
                    c = (c * min) % nin;
                }
                if (a[i] == 0)
                {
                    if (i == 0)
                    {
                        c = 0;
                        break;
                    }
                    c = (c * c) % nin;
                }
            }
            MessageBox.Show("Message = " + c);
        }
    }
}
