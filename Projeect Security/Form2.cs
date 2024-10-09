using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplified_RC4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Load += Form2_Load;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < rc.State.Count ; i++)
            {
                textBox1.Text += rc.State[i].ToString() + " ";
                textBox2.Text += rc.Temp[i].ToString() + " ";
            }
            //////////////////////////////////////////////////////////
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                j = (j + rc.State[i] + rc.Temp[i]) % 8;
                int pnn = rc.State[i];
                rc.State[i] = rc.State[j];
                rc.State[j] = pnn;

                if (i == 0)
                {
                    for (int l = 0; l < rc.State.Count; l++)
                    {
                        textBox3.Text += rc.State[l].ToString() + " ";
                    }
                }
                if (i == 1)
                {
                    for (int l = 0; l < rc.State.Count; l++)
                    {
                        textBox4.Text += rc.State[l].ToString() + " ";
                    }
                }
                if (i == 2)
                {
                    for (int l = 0; l < rc.State.Count; l++)
                    {
                        textBox5.Text += rc.State[l].ToString() + " ";
                    }
                }
                if (i == 3)
                {
                    for (int l = 0; l < rc.State.Count; l++)
                    {
                        textBox6.Text += rc.State[l].ToString() + " ";
                    }
                }
                if (i == 4)
                {
                    for (int l = 0; l < rc.State.Count; l++)
                    {
                        textBox7.Text += rc.State[l].ToString() + " ";
                    }
                }
                if (i == 5)
                {
                    for (int l = 0; l < rc.State.Count; l++)
                    {
                        textBox8.Text += rc.State[l].ToString() + " ";
                    }
                }
                if (i == 6)
                {
                    for (int l = 0; l < rc.State.Count; l++)
                    {
                        textBox9.Text += rc.State[l].ToString() + " ";
                    }
                }
                if (i == 7)
                {
                    for (int l = 0; l < rc.State.Count; l++)
                    {
                        textBox10.Text += rc.State[l].ToString() + " ";
                    }
                }

            }
            ///////////////////////////////////////////////////////////////////

            
            int z = 0, x = 0;
            for (int pos = 0; pos < rc.Plain.Count; pos++)
            {
                z = (z + 1) % 8;
                x = (x + rc.State[z]) % 8;
                int pnn = rc.State[z];
                rc.State[z] = rc.State[x];
                rc.State[x] = pnn;
                int pnn2 = (rc.State[z] + rc.State[x]) % 8;
                int Key = rc.State[pnn2];
                string TEMP1 = ConvertToOctal(Key);
                string TEMP2 = ConvertToOctal(rc.Plain[pos]);
                string TEMP3 = MakeXOR(TEMP1, TEMP2);                
                int TEMP4 = ConvertToDec(TEMP3);
                if (pos == 0)
                {
                    textBox11.Text = TEMP3;
                    textBox12.Text = Convert.ToString(TEMP4);
                    rc.Ciphered.Add(TEMP4);
                }
                if (pos == 1)
                {
                    textBox13.Text = TEMP3;
                    textBox14.Text = Convert.ToString(TEMP4);
                    rc.Ciphered.Add(TEMP4);
                }
                if (pos == 2)
                {
                    textBox15.Text = TEMP3;
                    textBox16.Text = Convert.ToString(TEMP4);
                    rc.Ciphered.Add(TEMP4);
                }
                if (pos == 3)
                {
                    textBox17.Text = TEMP3;
                    textBox18.Text = Convert.ToString(TEMP4);
                    rc.Ciphered.Add(TEMP4);
                }
            }
            for (int i = 0; i < rc.Ciphered.Count; i++)
            {
                textBox19.Text += rc.Ciphered[i].ToString() + " ";
            }
            }


        string ConvertToOctal(int M)
        {
            string OCT = "";
            if (M == 0)
            {
                OCT = "000";
            }
            if (M == 1)
            {
                OCT = "001";
            }
            if (M == 2)
            {
                OCT = "010";
            }
            if (M == 3)
            {
                OCT = "011";
            }
            if (M == 4)
            {
                OCT = "100";
            }
            if (M == 5)
            {
                OCT = "101";
            }
            if (M == 6)
            {
                OCT = "110";
            }
            if (M == 7)
            {
                OCT = "111";
            }

            return OCT;
        }
        string MakeXOR(string Arr1, string Arr2)
        {
            string Res = "";
            for (int i = 0; i < Arr1.Length; i++)
            {
                if (Arr1[i] == '0' && Arr2[i] == '0' || Arr1[i] == '1' && Arr2[i] == '1')
                {
                    Res += '0';
                }
                if (Arr1[i] == '1' && Arr2[i] == '0' || Arr1[i] == '0' && Arr2[i] == '1')
                {
                    Res += '1';
                }

            }

            return Res;
        }
        int ConvertToDec(string M)
        {
            int Dec = 0;
            if (M == "000")
            {
                Dec = 0;
            }
            if (M == "001")
            {
                Dec = 1;
            }
            if (M == "010")
            {
                Dec = 2;
            }
            if (M == "011")
            {
                Dec = 3;
            }
            if (M == "100")
            {
                Dec = 4;
            }
            if (M == "101")
            {
                Dec = 5;
            }
            if (M == "110")
            {
                Dec = 6;
            }
            if (M == "111")
            {
                Dec = 7;
            }

            return Dec;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
