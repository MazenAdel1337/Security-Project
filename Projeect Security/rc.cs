using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Simplified_RC4
{
    public partial class rc : Form
    {
        static public List<int> Plain = new List<int>();
        static public List<int> Key = new List<int>();                
        static public List<int> Key2 = new List<int>();
        static public List<int> Ciphered = new List<int>();
        static public List<int> State = new List<int>();
        static public List<int> Temp = new List<int>();

        public rc()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] Plaintext = textBox1.Text.Split(' ');
            string[] Keytext = textBox2.Text.Split(' ');

            for (int i = 0; i < Plaintext.Length; i++)
            {
                Plain.Add(Int32.Parse(Plaintext[i]));
                Key.Add(Int32.Parse(Keytext[i]));
            }
            for (int i = 0; i < 8; i++)
            {
                State.Add(i);
                if (i < 4)
                {
                    Temp.Add(Key[i]);
                }
                else
                {
                    Temp.Add(Key[0]);
                    Temp.Add(Key[1]);
                    Temp.Add(Key[2]);
                    Temp.Add(Key[3]);
                }
            }

            Form2 FF = new Form2();
            FF.Show();

            //Res = RC4(textBox1.Text, textBox2.Text);
            //MessageBox.Show(Key[0].ToString() + " " + Key[1].ToString() + " " + Key[2].ToString() + " " + Key[3].ToString());
            //MessageBox.Show(Key2[0].ToString() + " " + Key2[1].ToString() + " " + Key2[2].ToString() + " " + Key2[3].ToString() + " " + Key2[4].ToString() + " " + Key2[5].ToString() + " " + Key2[6].ToString() + " " + Key2[7].ToString());
        }


        public static string RC4(string input, string key)
        {
            StringBuilder result = new StringBuilder();
            int x, y, j = 0;
            int[] box = new int[256];

            for (int i = 0; i < 256; i++)
            {
                box[i] = i;
            }

            for (int i = 0; i < 256; i++)
            {
                j = (key[i % key.Length] + box[i] + j) % 256;
                x = box[i];
                box[i] = box[j];
                box[j] = x;
            }

            for (int i = 0; i < input.Length; i++)
            {
                y = i % 256;
                j = (box[y] + j) % 256;
                x = box[y];
                box[y] = box[j];
                box[j] = x;

                result.Append((char)(input[i] ^ box[(box[y] + box[j]) % 256]));
            }
            return result.ToString();
        }

    }
}
