using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecuProj
{
    public partial class saes : Form
    {

        String[,] Me = new String[,]
         {
             {"1","4"},
             {"4","1"}
         };
        //8x4
        String[,] NibDic = new String[,]
            {
                {"0000",  "1001",  "1000",  "0110"},
                {"0001",  "0100",  "1001",  "0010"},
                {"0010",  "1010",  "1010",  "0000"},
                {"0011",  "1011",  "1011",  "0011"},
                {"0100",  "1101",  "1100",  "1100"},
                {"0101",  "0001",  "1101",  "1110"},
                {"0110",  "1000",  "1110",  "1111"},
                {"0111",  "0101",  "1111",  "0111"}
            };

        String[] BinDic = new String[] { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
            

        String[,] MultTable = new String[,]
            {
                {"1",  "2",  "3",  "4",  "5",  "6",  "7",  "8",  "9",  "a",  "b",  "c",  "d",  "e",  "f"},
                {"2",  "4",  "6",  "8",  "a",  "c",  "e",  "3",  "1",  "7",  "5",  "b",  "9",  "f",  "d"},
                {"3",  "6",  "5",  "c",  "f",  "a",  "9",  "b",  "8",  "d",  "e",  "7",  "4",  "1",  "2"},
                {"4",  "8",  "c",  "3",  "7",  "b",  "f",  "6",  "2",  "e",  "a",  "5",  "1",  "d",  "9"},
                {"5",  "a",  "f",  "7",  "2",  "d",  "8",  "e",  "b",  "4",  "1",  "9",  "c",  "3",  "6"},
                {"6",  "c",  "a",  "b",  "d",  "7",  "1",  "5",  "3",  "9",  "f",  "e",  "8",  "2",  "4"},
                {"7",  "e",  "9",  "f",  "8",  "1",  "6",  "d",  "a",  "3",  "4",  "2",  "5",  "c",  "b"},
                {"8",  "3",  "b",  "6",  "e",  "5",  "d",  "c",  "4",  "f",  "7",  "a",  "2",  "9",  "1"},
                {"9",  "1",  "8",  "2",  "b",  "3",  "a",  "4",  "d",  "5",  "c",  "6",  "f",  "7",  "e"},
                {"a",  "7",  "d",  "e",  "4",  "9",  "3",  "f",  "5",  "8",  "2",  "1",  "b",  "6",  "c"},
                {"b",  "5",  "e",  "a",  "1",  "f",  "4",  "7",  "c",  "2",  "9",  "d",  "6",  "8",  "3"},
                {"c",  "b",  "7",  "5",  "9",  "e",  "2",  "a",  "6",  "1",  "d",  "f",  "3",  "4",  "8"},
                {"d",  "9",  "4",  "1",  "c",  "8",  "5",  "2",  "f",  "b",  "6",  "3",  "e",  "a",  "7"},
                {"e",  "f",  "1",  "d",  "3",  "2",  "c",  "9",  "7",  "6",  "8",  "4",  "a",  "b",  "5"},
                {"f",  "d",  "2",  "9",  "6",  "4",  "b",  "1",  "e",  "c",  "3",  "8",  "7",  "5",  "a"}

            };

        String[,] AddTable = new String[,]
            {
                {"0",  "1",  "2",  "3",  "4",  "5",  "6",  "7",  "8",  "9",  "a",  "b",  "c",  "d",  "e",  "f"},
                {"1",  "0",  "3",  "2",  "5",  "4",  "7",  "6",  "9",  "8",  "b",  "a",  "d",  "c",  "f",  "e"},
                {"2",  "3",  "0",  "1",  "6",  "7",  "4",  "5",  "a",  "b",  "8",  "9",  "e",  "f",  "c",  "d"},
                {"3",  "2",  "1",  "0",  "7",  "6",  "5",  "4",  "b",  "a",  "9",  "8",  "f",  "e",  "d",  "c"},
                {"4",  "5",  "6",  "7",  "0",  "1",  "2",  "3",  "c",  "d",  "e",  "f",  "8",  "9",  "a",  "b"},
                {"5",  "4",  "7",  "6",  "1",  "0",  "3",  "2",  "d",  "c",  "f",  "e",  "9",  "8",  "b",  "a"},
                {"6",  "7",  "4",  "5",  "2",  "3",  "0",  "1",  "e",  "f",  "c",  "d",  "a",  "b",  "8",  "9"},
                {"7",  "6",  "5",  "4",  "3",  "2",  "1",  "0",  "f",  "e",  "d",  "c",  "b",  "a",  "9",  "8"},
                {"8",  "9",  "a",  "b",  "c",  "d",  "e",  "f",  "0",  "1",  "2",  "3",  "4",  "5",  "6",  "7"},
                {"9",  "8",  "b",  "a",  "d",  "c",  "f",  "e",  "1",  "0",  "3",  "2",  "5",  "4",  "7",  "6"},
                {"a",  "b",  "8",  "9",  "e",  "f",  "c",  "d",  "2",  "3",  "0",  "1",  "6",  "7",  "4",  "5"},
                {"b",  "a",  "9",  "8",  "f",  "e",  "d",  "c",  "3",  "2",  "1",  "0",  "7",  "6",  "5",  "4"},
                {"c",  "d",  "e",  "f",  "8",  "9",  "a",  "b",  "4",  "5",  "6",  "7",  "0",  "1",  "2",  "3"},
                {"d",  "c",  "f",  "e",  "9",  "8",  "b",  "a",  "5",  "4",  "7",  "6",  "1",  "0",  "3",  "2"},
                {"e",  "f",  "c",  "d",  "a",  "b",  "8",  "9",  "6",  "7",  "4",  "5",  "2",  "3",  "0",  "1"},
                {"f",  "e",  "d",  "c",  "b",  "a",  "9",  "8",  "7",  "6",  "5",  "4",  "3",  "2",  "1",  "0"}

            };

        String Default1 = "10000000";
        String Default2 = "00110000";
        public saes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String plaintext = textBox1.Text;
            String key = textBox2.Text;

            String w0 = null, w1 = null;
            for (int i = 0; i < 8; i++)
            {
                w0 += key[i];
                w1 += key[8 + i];
            }

            richTextBox1.Text += ("W0 Is : " + w0);
            richTextBox1.Text += "\n";
            richTextBox1.Text += ("W1 Is : " + w1);
            
            String w1R = this.RotNib(w1);
            //richTextBox1.Text += "\n";
            //richTextBox1.Text += ("W1 After Rotate : " + w1R);
            
            String w1S = this.SubNib(w1R);
            
            //richTextBox1.Text += "\n";
            //richTextBox1.Text += ("W1 After Sub :" + w1S);
            
            String temp = this.XOR(w0, Default1);
            String w2 = this.XOR(w1S, temp);
            richTextBox1.Text += "\n";
            richTextBox1.Text += ("w2 is : " + w2);
            
            String w3 = this.XOR(w1, w2);
            richTextBox1.Text += "\n";
            richTextBox1.Text += ("w3 is : " + w3);
            
            String w3R = RotNib(w3);
            String w3S = SubNib(w3R);
            temp = this.XOR(w2, Default2);
            String w4 = this.XOR(temp, w3S);
            richTextBox1.Text += "\n";
            richTextBox1.Text+=("w4 is: " + w4);
            
            String w5 = this.XOR(w4, w3);
            richTextBox1.Text += "\n";
            richTextBox1.Text += ("w5 is: " + w5);


            String Key0 = w0+w1, 
                   Key1 = w2+w3, 
                   Key2 = w4+w5;
            richTextBox1.Text += "\n";
            richTextBox1.Text += ("Key0 is : " + Key0);
            richTextBox1.Text += "\n";
            richTextBox1.Text += ("Key1 is : " + Key1);
            richTextBox1.Text += "\n";
            richTextBox1.Text += ("Key2 is : " + Key2);
            richTextBox1.Text += "\n";

            //1.2.1
            String Round0 = this.XOR16(plaintext, Key0);
            richTextBox1.Text += ("XOR Plain Text With Key 0 : " + Round0);

            //1.2.2
            String Round1 = this.SubNib16(Round0);
            
            richTextBox1.Text += "\n";
            richTextBox1.Text += ("AfterSubNib : " + Round1);

            //Shif
            String Round11 = this.SwapNib(Round1);
            richTextBox1.Text += "\n";
            richTextBox1.Text += ("AfterShiftNib : " + Round11);
            richTextBox1.Text += "\n";

            //Prepare S00,S01,S10,S11
            String S00 = null, S01 = null, S10 = null, S11 = null;
            for (int i = 0; i < 4; i++)
            {
                S00 += Round11[i];
                S01 += Round11[4 + i];
                S10 += Round11[8 + i];
                S11 += Round11[12 + i];
            }
            //S00New
            String ConvS10 = this.ToHexDec(S10);
            String Four = "4";
            
            String ResMul = GetFromMultTable(Four, ConvS10);
            
            String ResBin = ToBin(ResMul);
            

            String S00New = this.XOR4(ResBin, S00);
            richTextBox1.Text += ("S00 New is " + S00New);

           
            //S10New
            String ConvS00 = this.ToHexDec(S00);
            ResMul = GetFromMultTable(Four, ConvS00);
            ResBin = ToBin(ResMul);
            String S10New = this.XOR4(ResBin, S10);
            richTextBox1.Text += "\n";
            richTextBox1.Text += ("S10New is : " + S10New);

            //S01New
            String ConvS01 = this.ToHexDec(S01);
            ResMul = GetFromMultTable(Four, ConvS01);
            ResBin = ToBin(ResMul);
            
            richTextBox1.Text += "\n";
            String S01New = this.XOR4(ResBin, S01);
            richTextBox1.Text += ("S01New is : " + S01New);

            //S11New
            String ConvS11 = this.ToHexDec(S11);
            ResMul = GetFromMultTable(Four, ConvS11);
            ResBin = ToBin(ResMul);
            
            richTextBox1.Text += "\n";
            String S11New = this.XOR4(ResBin, S11);
            richTextBox1.Text += ("S11new is " + S11New);

            String Output = S00New + S10New + S01New + S11New;

            String OutXK1 = this.XOR16(Output, Key1);
            OutXK1 = this.SubNib16(OutXK1);
            OutXK1 = this.SwapNib(OutXK1);
            String OutXK2 = this.XOR16(OutXK1, Key2);
            richTextBox1.Text += "\n";
            richTextBox1.Text += ("Cipher Text is : " + OutXK2);
        }

        String ToBin(String v)
        {
            String v2 = null;
            int Flag = 0;
            for (int i = 0; i < 10; i++)
            {
                if (v == i.ToString())
                {
                    v2 = BinDic[i];
                    Flag = 1;
                    break;
                }
            }

            if (Flag == 0)
            {
                if (v == "a")
                {
                    v2 = BinDic[10];
                }
                if (v == "b")
                {
                    v2 = BinDic[11];
                }
                if (v == "c")
                {
                    v2 = BinDic[12];
                }
                if (v == "d")
                {
                    v2 = BinDic[13];
                }
                if (v == "e")
                {
                    v2 = BinDic[14];
                }
                if (v == "f")
                {
                    v2 = BinDic[15];
                }
            }


            return v2;
        }

        String GetFromMultTable(String v1,String v2)
        {
            String v3=null;
            for (int r = 0; r < 15; r++)
            {
                for (int c = 0; c < 1; c++)
                {
                    if (MultTable[r,c] == v1)
                    {
                        for (int e = 0; e < 15; e++)
                        {
                            if (MultTable[0, e] == v2)
                            {
                                v3 = MultTable[r, e];
                            }
                        }
                    }
                }
            }
            return v3;
        }
        
        String ToHexDec(String v)
        {
            String v2 = null;
            int val = 0;
            if (v[0] == '1')
            {
                val += 8;
            }
            if (v[1] == '1')
            {
                val += 4;
            }
            if (v[2] == '1')
            {
                val += 2;
            }
            if (v[3] == '1')
            {
                val += 1;
            }

            if (val == 10)
            {
                v2 = "a";
            }
            if (val == 11)
            {
                v2 = "b";
            }
            if (val == 12)
            {
                v2 = "c";
            }
            if (val == 13)
            {
                v2 = "d";
            }
            if (val == 14)
            {
                v2 = "e";
            }
            if (val == 15)
            {
                v2 = "f";
            }
            if (val < 10)
            {
                v2 = val.ToString("X");
            }
            return v2;
        }

        String SwapNib(string v)
        {
            String v2 = null; ;
            for (int i = 0; i < 4; i++)
            {
                v2 += v[i];
            }
            for (int i = 0; i < 4; i++)
            {
                v2 += v[12+i];
            }

            for (int i = 0; i < 4; i++)
            {
                v2 += v[8 + i];
            }

            for (int i = 0; i < 4; i++)
            {
                v2 += v[4 + i];
            }
            return v2;
        }

        String SubNib(String v)
        {
            String v2 = null;
            String StHalf = null;
            String NdHalf = null;

            for (int i = 0; i < 4; i++)
            {
                StHalf += v[i];
                NdHalf += v[4 + i];
            }

            for (int c = 0; c < 3; c+=2)
            {
                for (int r = 0; r < 8; r++)
                {
                    if (StHalf == NibDic[r,c])
                    {
                        for (int e = 0; e < 4; e++)
                        {
                            v2 += NibDic[r, c+1][e];
                        }
                    }
                }
            }

            for (int c = 0; c < 3; c += 2)
            {
                for (int r = 0; r < 8; r++)
                {
                    if (NdHalf == NibDic[r, c])
                    {
                        for (int e = 0; e < 4; e++)
                        {
                            v2 += NibDic[r, c+1][e];
                        }
                    }
                }
            }

            return v2;
        }

        String SubNib16(String v)
        {
            String v2 = null;
            String StHalf = null;
            String NdHalf = null;
            String RdHalf = null;
            String ThHalf = null;

            for (int i = 0; i < 4; i++)
            {
                StHalf += v[i];
                NdHalf += v[4 + i];
                RdHalf += v[8 + i];
                ThHalf += v[12 + i];
            }

            for (int c = 0; c < 3; c += 2)
            {
                for (int r = 0; r < 8; r++)
                {
                    if (StHalf == NibDic[r, c])
                    {
                        for (int e = 0; e < 4; e++)
                        {
                            v2 += NibDic[r, c + 1][e];
                        }
                    }
                }
            }

            for (int c = 0; c < 3; c += 2)
            {
                for (int r = 0; r < 8; r++)
                {
                    if (NdHalf == NibDic[r, c])
                    {
                        for (int e = 0; e < 4; e++)
                        {
                            v2 += NibDic[r, c + 1][e];
                        }
                    }
                }
            }

            for (int c = 0; c < 3; c += 2)
            {
                for (int r = 0; r < 8; r++)
                {
                    if (RdHalf == NibDic[r, c])
                    {
                        for (int e = 0; e < 4; e++)
                        {
                            v2 += NibDic[r, c + 1][e];
                        }
                    }
                }
            }

            for (int c = 0; c < 3; c += 2)
            {
                for (int r = 0; r < 8; r++)
                {
                    if (ThHalf == NibDic[r, c])
                    {
                        for (int e = 0; e < 4; e++)
                        {
                            v2 += NibDic[r, c + 1][e];
                        }
                    }
                }
            }

            return v2;
        }

        String RotNib(String v)
        {
            String v2  = null;
            for (int i = 0; i < 4; i++)
            {
                v2 += v[4 + i];
            }
            for (int i = 0; i < 4; i++)
            {
                v2 += v[i];
            }
            return v2;
        }

        String XOR4(String v1, String v2)
        {
            String v3 = null;

            for (int i = 0; i < 4; i++)
            {
                if (v1[i] == v2[i])
                {
                    v3 += 0;
                }
                else
                    v3 += 1;
            }
            return v3;
        }

        String XOR(String v1, String v2)
        {
            String v3 = null;

            for (int i=0;i<8;i++)
            {
                if (v1[i] == v2[i])
                {
                    v3 += 0;
                }
                else
                    v3 += 1;
            }
            return v3;
        }

        String XOR16(String v1, String v2)
        {
            String v3 = null;

            for (int i = 0; i < 16; i++)
            {
                if (v1[i] == v2[i])
                {
                    v3 += 0;
                }
                else
                    v3 += 1;
            }
            return v3;
        }
    }
}

    

