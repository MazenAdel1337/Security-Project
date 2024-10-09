using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sdees
{
    public partial class SDES : Form
    {
        int[] text;
        int[] key;
        int[] p10 = {3, 5, 2, 7, 4, 10, 1, 9, 8, 6 };
        int[] p8  = { 6, 3, 7, 4, 8, 5, 10, 9 };
        int[] ip  = {2, 6, 3, 1, 4, 8, 5, 7 };
        int[] ipinv = new int  [8];
        int[] ep  = { 4, 1, 2, 3, 2, 3, 4, 1 };
        int[] p4  = { 2, 4, 3, 1 };
        List<int> k1 = new List<int>();
        List<int> k2 = new List<int>();
        List<int> ipPlainText= new List<int>();
        int[,] S0 = new int[,] { 
            { 1, 0,3,2 }, 
            { 3,2,1,0 }, 
            { 0,2,1,3 }, 
            { 3,1,3,2 } 
        };

        int[,] S1 = new int[,] {
            { 0, 1,2,3 },
            { 2,0,1,3 },
            { 3,0,1,0 },
            { 2,1,0,3 }
        };
        private List<int> afterswap;

        List<int> round1 = new List<int>();
        List<int> round2 = new List<int>();
        private List<int> afterswap2;

        List<int> cipherText = new List<int>();

        public SDES()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "01110010";
            textBox2.Text = "1010000010";


        }

        private void init()
        {
            text = textBox1.Text.Select(s => Int32.Parse(s.ToString())).ToArray();
            key = textBox2.Text.Select(s => Int32.Parse(s.ToString())).ToArray();
           
        }

        private List<int> keyGeneration(int [] key, List<int> k,int shift)
        {
           List<int> left = new List<int>();
           List<int> right = new List<int>();
            for (int i = 0; i < p10.Length; i++)
           {
                int index = p10[i] -1;
                if (i < 5)
                {

                    left.Add(key[index]);
                }
                else
                {
                    //MessageBox.Show(key[index] + "");
                    right.Add(key[index]);
                  
                }
           }
            richTextBox1.Text += "P10";
            richTextBox1.Text += "\n";
            richTextBox1.Text += "LEFT : ";
            string combindedString = string.Join(" ", left);
            richTextBox1.Text += combindedString + " ";
            combindedString = string.Join("  ", right);
            richTextBox1.Text += "RIGHT : ";
            richTextBox1.Text += combindedString + " ";
            left = shiftLeft(left,shift);
            right = shiftLeft(right,shift);
            left = left.Concat(right).ToList();

            for (int i = 0; i < p8.Length; i++)
            {
                int index = p8[i] - 1;

                k.Add(left[index]);
                
            }
          

            return k;
            
        }

        private List<int> shiftLeft(List<int> k,int bit=1)
        {
            List<int> temp = new List<int>();
            List<int> temp2 = new List<int>();
            for (int i = 0; i < bit; i++)
            {
                temp.Add(k[i]);
            }
            for(int i = bit; i < k.Count; i++)
            {
                temp2.Add(k[i]);
            }
            for(int i = 0; i < temp.Count; i++)
            {
                temp2.Add(temp[i]);
            }
            return temp2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            init();
            k1 = keyGeneration(key,k1,1);
            richTextBox1.Text += "\n";
            richTextBox1.Text += "K1 ";
            richTextBox1.Text += "\n";
            string combindedString = string.Join(" ", k1);
            richTextBox1.Text += combindedString;
            richTextBox1.Text += "\n";
            richTextBox1.Text += "\n";
            richTextBox1.Text += "\n";
            k2 = keyGeneration(key, k2,3);
            richTextBox1.Text += "\n";
            richTextBox1.Text += "K2 ";
            richTextBox1.Text += "\n";
            combindedString = string.Join(" ", k2);
            richTextBox1.Text += combindedString;
            richTextBox1.Text += "\n";
            richTextBox1.Text += "\n";
            richTextBox1.Text += "\n";
            for (int i = 0; i < ip.Length; i++)
            {
                int index = ip[i] - 1;

                ipPlainText.Add(text[index]);

            }
            afterswap = doARound(ipPlainText,k1);


           
            for (int i = 0; i < ipPlainText.Count; i++)
            {
                if (i >= 4)
                {
                    round1.Add(ipPlainText[i]);

                }
            }

            for(int i = 0; i < afterswap.Count; i++)
            {
                round1.Add(afterswap[i]);
            }
            richTextBox1.Text += "\n";
            richTextBox1.Text += "Round 1 :";
            richTextBox1.Text += "\n";

            combindedString = string.Join(" ", round1);
            richTextBox1.Text += combindedString + " ";



            richTextBox1.Text += "\n";
            richTextBox1.Text += "\n";
            afterswap2  = doARound(round1, k2);

           


            for (int i = 0; i < afterswap2.Count; i++)
            {
                round2.Add(afterswap2[i]);
            }
            for (int i = 0; i < round1.Count; i++)
            {
                if (i >= 4)
                {
                    round2.Add(round1[i]);

                }
            }

            // IP Inverese 

            for(int i = 0; i < ip.Length; i++)
            {
                int index = ip[i] - 1;

                ipinv[index] = i + 1;
            }


            //for (int i = 0; i < ipinv.Length; i++)
            //{
            //    MessageBox.Show(ipinv[i] + "");
            //}

            for (int i = 0; i < ipinv.Length; i++)
            {
                int index = ipinv[i] - 1;

                cipherText.Add(round2[index]);

            }
            richTextBox1.Text += "\n";
            richTextBox1.Text += "\n";
            richTextBox1.Text += "cipherText :";
            richTextBox1.Text += "\n";

            combindedString = string.Join(" ", cipherText);
            richTextBox1.Text += combindedString + " ";

            MessageBox.Show(cipherText[0] + " " + cipherText[1] + " " + cipherText[2] + "  " + cipherText[3] + "  " + cipherText[4] + "  " + cipherText[5] + " " + cipherText[6] + " " + cipherText[7] + "  ");



        }
        private List<int> XOR(List<int> array1, List<int> array2)
        {
            List<int> temp = new List<int>();

            for (int i = 0; i < array1.Count; i++)
            {
                if (array1[i] == array2[i])
                {
                    temp.Add(0);
                }
                else
                {
                    temp.Add(1);
                }
            }

            return temp;
        }
        private List<int> doARound(List<int> ipPlainText, List<int> k)
        {
            List<int> right = new List<int>();
            List<int> left = new List<int>();

            List<int> right2 = new List<int>();
            List<int> left2 = new List<int>();

            List<int> fin = new List<int>();
            List<int> fin2 = new List<int>();
            for (int i = 0; i < ipPlainText.Count; i++)
            {
                if (i >= 4)
                {
                    right.Add(ipPlainText[i]);

                }
                else
                {
                    left.Add(ipPlainText[i]);
                }
            }

           
            List<int> te = new List<int>();

            for (int i = 0; i < ep.Length; i++)
            {
                int index = ep[i] - 1;

                te.Add(right[index]);

            }

            richTextBox1.Text += "\n";
            richTextBox1.Text += "AFTER EP: ";
            richTextBox1.Text += "\n";
           
            string combindedString = string.Join(" ", te);
            richTextBox1.Text += combindedString + " ";
           
            te = XOR(te, k);
            richTextBox1.Text += "\n";
            richTextBox1.Text += "AFTER XOR: ";
            richTextBox1.Text += "\n";

            combindedString = string.Join(" ", te);
            richTextBox1.Text += combindedString + " ";
            for (int i = 0; i < te.Count; i++)
            {
                if (i >= 4)
                {
                    right2.Add(te[i]);

                }
                else
                {
                    left2.Add(te[i]);
                }
            }

            // left side 
           
            string outer = left2[0].ToString() + left2[3].ToString();
            int outerDec  = binaryToDec(int.Parse(outer));

            string inner = left2[1].ToString() + left2[2].ToString();
            int innerDec = binaryToDec(int.Parse(inner));

            int f = S0[outerDec,innerDec];

           

            // ri side 

            outer = right2[0].ToString() + right2[3].ToString();
            outerDec = binaryToDec(int.Parse(outer));

            inner = right2[1].ToString() + right2[2].ToString();
            innerDec = binaryToDec(int.Parse(inner));

            int f2 = S1[outerDec, innerDec];


          


            fin = DectoBinary(f);

            richTextBox1.Text += "\n";
            richTextBox1.Text += "Left S-BOXES: ";
            richTextBox1.Text += "\n";

            combindedString = string.Join(" ", fin2);
            richTextBox1.Text += combindedString + " ";

            fin2 = DectoBinary(f2);

           
            richTextBox1.Text += "Right S-BOXES: ";
            richTextBox1.Text += "\n";

            combindedString = string.Join(" ", fin2);
            richTextBox1.Text += combindedString + " ";

            for (int i = 0; i < fin2.Count; i++)
            {
                fin.Add(fin2[i]);
            }

            List<int> afterP4 = new List<int>();
            for (int i = 0; i < p4.Length; i++)
            {
                int index = p4[i] - 1;

                afterP4.Add(fin[index]);

            }

            afterP4 = XOR(afterP4, left);

            return afterP4;

        }

        private List<int> DectoBinary(int number)
        {
           
            int i;
            //int[] numberArray = new int[10];
            List<int> numberArray = new List<int>();
            List<int> tem = new List<int>();
            if (number == 0)
            {
                tem.Add(0);
                tem.Add(0);

                return tem;
            }
            else if (number == 1)
            {
                tem.Add(0);
                tem.Add(1);

                return tem;
            }
            for (i = 0; number > 0; i++)
            {
               
                numberArray.Add(number % 2);
                number = number / 2;
            }
           
            for(int j=numberArray.Count-1;j>=0;j--)
            {
                tem.Add(numberArray[j]);
            }

            return tem;
        }

        private int binaryToDec(int num)
        {
            int  binVal, decVal = 0, baseVal = 1, rem;
            
            binVal = num;
            while (num > 0)
            {
                rem = num % 10;
                decVal = decVal + rem * baseVal;
                num = num / 10;
                baseVal = baseVal * 2;
            }

            return decVal;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            init();
            k1 = keyGeneration(key, k1, 1);
            k2 = keyGeneration(key, k2, 3);

            for (int i = 0; i < ip.Length; i++)
            {
                int index = ip[i] - 1;

                ipPlainText.Add(text[index]);

            }
            afterswap = doARound(ipPlainText, k2);

            for (int i = 0; i < ipPlainText.Count; i++)
            {
                if (i >= 4)
                {
                    round1.Add(ipPlainText[i]);

                }
            }

            for (int i = 0; i < afterswap.Count; i++)
            {
                round1.Add(afterswap[i]);
            }

            afterswap2 = doARound(round1, k1);



            for (int i = 0; i < afterswap2.Count; i++)
            {
                round2.Add(afterswap2[i]);
            }
            for (int i = 0; i < round1.Count; i++)
            {
                if (i >= 4)
                {
                    round2.Add(round1[i]);

                }
            }

            // IP Inverese 

            for (int i = 0; i < ip.Length; i++)
            {
                int index = ip[i] - 1;

                ipinv[index] = i + 1;
            }


            //for (int i = 0; i < ipinv.Length; i++)
            //{
            //    MessageBox.Show(ipinv[i] + "");
            //}

            for (int i = 0; i < ipinv.Length; i++)
            {
                int index = ipinv[i] - 1;

                cipherText.Add(round2[index]);

            }

            
                MessageBox.Show(cipherText[0] + " " + cipherText[1] + " " + cipherText[2] + "  " + cipherText[3] + "  "  + cipherText[4] + "  "+ cipherText[5] + " "+ cipherText[6] + " "+ cipherText[7] + "  ");
            


        }
    }
}
