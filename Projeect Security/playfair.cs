using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace playfair
{
    public partial class playfair : Form
    {
        public string[] KeyArray;
        char[] Keychar = new char[300];
        string[] Keychar2 = new string[300];
        Char[] plaintext = new char[300];
        string[] plaintext2 = new string[300];
        string[] ciphertext = new string[300];
        Char[] ciphertext2 = new char[300];
        string[] cipertext3 = new string[300];
        string[] decrypttext = new string[300];


        public playfair()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        string[,] EncryptArray = new string[5,5];
            string[,] EncryptArray2 = new string[5,5];
            int[] ct = new int[25];
            for(int k=0;k<25;k++)
            {
                ct[k] = 0;
            }
         
           
            for(int i=0; i<5;i++)
            {
                for(int c=0;c<5;c++)
                {
                    if(i==0&&c==0)
                    {
                        EncryptArray[i, c] = "A";
                    }
                    if(i==0&&c==1)
                    {
                        EncryptArray[i, c] = "B";
                    }
                    if (i == 0 && c == 2)
                    {
                        EncryptArray[i, c] = "C";
                    }
                    if (i == 0 && c == 3)
                    {
                        EncryptArray[i, c] = "D";
                    }
                    if (i == 0 && c == 4)
                    {
                        EncryptArray[i, c] = "E";
                    }
                    if (i == 1 && c == 0)
                    {
                        EncryptArray[i, c] = "F";
                    }
                    if (i == 1 && c == 1)
                    {
                        EncryptArray[i, c] = "G";
                    }
                    if (i == 1 && c == 2)
                    {
                        EncryptArray[i, c] = "H";
                    }
                    if (i == 1 && c == 3)
                    {
                        EncryptArray[i, c] = "i/j";
                    }
                    if (i == 1 && c == 4)
                    {
                        EncryptArray[i, c] = "K";
                    }
                    if (i == 2 && c == 0)
                    {
                        EncryptArray[i, c] = "L";
                    }
                    if (i == 2 && c == 1)
                    {
                        EncryptArray[i, c] = "M";
                    }
                    if (i == 2 && c == 2)
                    {
                        EncryptArray[i, c] = "N";
                    }
                    if (i == 2 && c == 3)
                    {
                        EncryptArray[i, c] = "O";
                    }
                    if (i == 2 && c == 4)
                    {
                        EncryptArray[i, c] = "P";
                    }
                    if (i == 3 && c == 0)
                    {
                        EncryptArray[i, c] = "Q";
                    }
                    if (i == 3 && c == 1)
                    {
                        EncryptArray[i, c] = "R";
                    }
                    if (i == 3 && c == 2)
                    {
                        EncryptArray[i, c] = "S";
                    }
                    if (i == 3 && c == 3)
                    {
                        EncryptArray[i, c] = "T";
                    }
                    if (i == 3 && c == 4)
                    {
                        EncryptArray[i, c] = "U";
                    }
                    if (i == 4 && c == 0)
                    {
                        EncryptArray[i, c] = "V";
                    }
                    if (i == 4 && c == 1)
                    {
                        EncryptArray[i, c] = "W";
                    }
                    if (i == 4 && c == 2)
                    {
                        EncryptArray[i, c] = "X";
                    }
                    if (i == 4 && c == 3)
                    {
                        EncryptArray[i, c] = "Y";
                    }
                    if (i == 4 && c == 4)
                    {
                        EncryptArray[i, c] = "Z";
                    }
                }
            }

            // for(int n=0;n<Keychar.Length;n++)
            //   {
            //       MessageBox.Show(Keychar[n].ToString());
            //   }
            //
            int z = 0;
            for(int i=0;i<Keychar.Count();i++)
            {
                if (Keychar[i] == 'I' || Keychar[i] == 'J')
                {
                    Keychar2[z] = "i/j";
                    z++;
                }
                else
                {
                    Keychar2[z] = Keychar[i].ToString();
                    z++;
                }
            }
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    EncryptArray2[r, c] = "0";
                }
            }
        
            int o = 0; int R2 = 0; int C2 = 0;
          

          for( int y=0;y<Keychar2.Count();y++ )
            {
                for (int r = 0; r < 5; r++)
                {
                    for (int c = 0; c < 5; c++)
                    {

                        if (Keychar2[y] == EncryptArray[r, c])
                        {
                            ct[o]++;
                            if (ct[o] == 1)
                            {




                                EncryptArray2[R2, C2] = Keychar2[y];
                                C2++;
                                if (C2 == 5)
                                {
                                    C2 = 0;
                                    R2++;
                                }
                            }
                        }
                        
                        o++;
                    }
                }
                o = 0;

                

            }

           

                 o = 0; int flag1=0; int flag2=0; int flag3 = 0; 
                 for(int r=0;r<5;r++)
                 {
                     for(int c=0;c<5;c++)
                     {
                        if(EncryptArray2[r,c]=="0")
                         {
                             flag1 = r;
                             flag2 = c;
                             flag3 = 1;
                             break;
                         }
                     }
                     if(flag3==1)
                     {
                         break;
                     }
                 }
                 R2 = flag1;C2 = flag2; o = 0;
                 for(int r=0;r<5;r++)
                 {
                     for(int c=0;c<5;c++)
                     {
                         if (ct[o] == 0)
                         {

                             EncryptArray2[R2, C2] = EncryptArray[r, c];
                             C2++;
                             if (C2 == 5)
                             {
                                 R2++;
                                 C2 = 0;
                             }
                         }
                         o++;
                     }
                 }
          
          
            // for(int j=0;j<5;j++)
            //   {
            //       for(int g=0;g<5;g++)
            //       {
            //     //      MessageBox.Show(EncryptArray2[j,g]+j.ToString()+g.ToString());
            //            
            //       }
            //
            //   }
            

            //for(int s=0;s<25;s++)
            //    {
            //        MessageBox.Show(ct[s].ToString());
            //    }
            ////   
            // encryptarray 2 is final tabel

            // plaintext step
            for (int i = 0; i < plaintext2.Count(); i++)
            {
                plaintext2[i] = "0";
            }
            int z2 = 0;
            for (int i = 0; i < plaintext.Count(); i++)
            {
                if (plaintext[i] != ' ')
                {
                    if (plaintext[i] == 'I' || plaintext[i] == 'J')
                    {
                        plaintext2[z2] = "i/j";
                        z2++;
                    }
                    else
                    {
                        plaintext2[z2] = plaintext[i].ToString();
                        z2++;
                    }
                }
            }
            
            int ct3 = 0;
            for (int i = 0; i < plaintext2.Count(); i++)
            {
                if (plaintext2[i] == "0")
                {
                      
                    break;
                 }else
                {
                    ct3++;
                }
            }
          //  MessageBox.Show(ct3.ToString());
            if((ct3-1)%2==0)
            {
                plaintext2[ct3] = "X";
            }
             for(int i=0;i<plaintext2.Count();i++)
             {
                // MessageBox.Show(plaintext2[i]);
             }
            int flag4 = 0; int flag5 = 0; int flag6 = 0;int flag7 = 0;
            int f = 0;
            int r3 = 0;int c4 = 0; int FLAG = 0;
          for(int i=0;i<plaintext2.Count();i+=2)
            {
               
                if (plaintext2[i]!="0")
                {
                    flag4 = 0; flag5 = 0; flag6 = 0; flag7 = 0; FLAG = 0;
                    for ( r3=0;r3<5;r3++)
                    {
                        for( c4=0;c4<5;c4++)
                        {
                            if(plaintext2[i]==EncryptArray2[r3,c4])
                            {
                                flag4 = r3;
                                flag5 = c4;
                                break;
                            }
                        }
                       
                    }
                   
                    for (r3=0; r3 < 5; r3++)
                    {
                        for (c4=0; c4 < 5; c4++)
                        {
                            
                            if (plaintext2[i+1] == EncryptArray2[r3, c4])
                            {
                                flag6 = r3;
                                flag7 = c4;
                                break;
                            }
                           
                        }
                       // c4 = 0;
                    }
                    // same row
                    if (FLAG == 0)
                    {
                        if (flag4 == flag6)
                        {
                            if (flag5 + 1 == 5)
                            {
                                flag5 = -1;
                            }
                            if (flag7 + 1 == 5)
                            {
                                flag7 = -1;
                            }
                            flag5++;
                            flag7++;
                            ciphertext[f] = EncryptArray2[flag4, flag5];
                            ciphertext[f + 1] = EncryptArray2[flag6, flag7];
                            f += 2;
                            FLAG = 1;
                        }
                    }
                    if (FLAG == 0)
                    {
                        //SAME COLUMN
                        if (flag5 == flag7)
                        {
                            if (flag4 + 1 == 5)
                            {
                                flag4 = -1;
                            }
                            if (flag6 + 1 == 5)
                            {
                                flag6 = -1;
                            }
                            flag4++;
                            flag6++;
                            ciphertext[f] = EncryptArray2[flag4, flag5];
                            ciphertext[f + 1] = EncryptArray2[flag6, flag7];
                            f += 2;
                            FLAG = 1;
                        }
                    }
                    if (FLAG == 0)
                    {
                        // DEFRENT ROW AND ROW AND COLM COL
                        if (flag4 != flag6 && flag5 != flag7)
                        {
                            ciphertext[f] = EncryptArray2[flag4, flag7];
                            ciphertext[f + 1] = EncryptArray2[flag6, flag5];
                            f += 2;
                            FLAG = 1;

                        }
                    }
                }
                else
                {
                    break;
                }
            }
          for(int i=0;i<ciphertext.Count();i+=2)
            {
                if (ciphertext[i] != null)
                {
                    MessageBox.Show(ciphertext[i] + ciphertext[i + 1]);
                }
                
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
               
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // KeyArray = textBox2.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).t;
            string g = textBox2.Text.ToString();
            Keychar = g.ToCharArray();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string g = textBox1.Text.ToString();
            plaintext = g.ToCharArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[,] EncryptArray = new string[5, 5];
            string[,] EncryptArray2 = new string[5, 5];
            int[] ct = new int[25];
            for (int k = 0; k < 25; k++)
            {
                ct[k] = 0;
            }


            for (int i = 0; i < 5; i++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (i == 0 && c == 0)
                    {
                        EncryptArray[i, c] = "A";
                    }
                    if (i == 0 && c == 1)
                    {
                        EncryptArray[i, c] = "B";
                    }
                    if (i == 0 && c == 2)
                    {
                        EncryptArray[i, c] = "C";
                    }
                    if (i == 0 && c == 3)
                    {
                        EncryptArray[i, c] = "D";
                    }
                    if (i == 0 && c == 4)
                    {
                        EncryptArray[i, c] = "E";
                    }
                    if (i == 1 && c == 0)
                    {
                        EncryptArray[i, c] = "F";
                    }
                    if (i == 1 && c == 1)
                    {
                        EncryptArray[i, c] = "G";
                    }
                    if (i == 1 && c == 2)
                    {
                        EncryptArray[i, c] = "H";
                    }
                    if (i == 1 && c == 3)
                    {
                        EncryptArray[i, c] = "i/j";
                    }
                    if (i == 1 && c == 4)
                    {
                        EncryptArray[i, c] = "K";
                    }
                    if (i == 2 && c == 0)
                    {
                        EncryptArray[i, c] = "L";
                    }
                    if (i == 2 && c == 1)
                    {
                        EncryptArray[i, c] = "M";
                    }
                    if (i == 2 && c == 2)
                    {
                        EncryptArray[i, c] = "N";
                    }
                    if (i == 2 && c == 3)
                    {
                        EncryptArray[i, c] = "O";
                    }
                    if (i == 2 && c == 4)
                    {
                        EncryptArray[i, c] = "P";
                    }
                    if (i == 3 && c == 0)
                    {
                        EncryptArray[i, c] = "Q";
                    }
                    if (i == 3 && c == 1)
                    {
                        EncryptArray[i, c] = "R";
                    }
                    if (i == 3 && c == 2)
                    {
                        EncryptArray[i, c] = "S";
                    }
                    if (i == 3 && c == 3)
                    {
                        EncryptArray[i, c] = "T";
                    }
                    if (i == 3 && c == 4)
                    {
                        EncryptArray[i, c] = "U";
                    }
                    if (i == 4 && c == 0)
                    {
                        EncryptArray[i, c] = "V";
                    }
                    if (i == 4 && c == 1)
                    {
                        EncryptArray[i, c] = "W";
                    }
                    if (i == 4 && c == 2)
                    {
                        EncryptArray[i, c] = "X";
                    }
                    if (i == 4 && c == 3)
                    {
                        EncryptArray[i, c] = "Y";
                    }
                    if (i == 4 && c == 4)
                    {
                        EncryptArray[i, c] = "Z";
                    }
                }
            }

            // for(int n=0;n<Keychar.Length;n++)
            //   {
            //       MessageBox.Show(Keychar[n].ToString());
            //   }
            //
            int z = 0;
            for (int i = 0; i < Keychar.Count(); i++)
            {
                if (Keychar[i] == 'I' || Keychar[i] == 'J')
                {
                    Keychar2[z] = "i/j";
                    z++;
                }
                else
                {
                    Keychar2[z] = Keychar[i].ToString();
                    z++;
                }
            }
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    EncryptArray2[r, c] = "0";
                }
            }

            int o = 0; int R2 = 0; int C2 = 0;


            for (int y = 0; y < Keychar2.Count(); y++)
            {
                for (int r = 0; r < 5; r++)
                {
                    for (int c = 0; c < 5; c++)
                    {

                        if (Keychar2[y] == EncryptArray[r, c])
                        {
                            ct[o]++;
                            if (ct[o] == 1)
                            {




                                EncryptArray2[R2, C2] = Keychar2[y];
                                C2++;
                                if (C2 == 5)
                                {
                                    C2 = 0;
                                    R2++;
                                }
                            }
                        }

                        o++;
                    }
                }
                o = 0;



            }



            o = 0; int flag1 = 0; int flag2 = 0; int flag3 = 0;
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (EncryptArray2[r, c] == "0")
                    {
                        flag1 = r;
                        flag2 = c;
                        flag3 = 1;
                        break;
                    }
                }
                if (flag3 == 1)
                {
                    break;
                }
            }
            R2 = flag1; C2 = flag2; o = 0;
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (ct[o] == 0)
                    {

                        EncryptArray2[R2, C2] = EncryptArray[r, c];
                        C2++;
                        if (C2 == 5)
                        {
                            R2++;
                            C2 = 0;
                        }
                    }
                    o++;
                }
            }

          

            // cipher text 
            for (int i = 0; i < cipertext3.Count(); i++)
            {
                cipertext3[i] = "0";
            }
            int z2 = 0;
            for (int i = 0; i < ciphertext2.Count(); i++)
            {
                if (ciphertext2[i] != ' ')
                {
                    if (ciphertext2[i] == 'I' || ciphertext2[i] == 'J')
                    {
                        cipertext3[z2] = "i/j";
                        z2++;
                    }
                    else
                    {
                        cipertext3[z2] = ciphertext2[i].ToString();
                        z2++;
                    }
                }
            }

            int ct3 = 0;
            for (int i = 0; i < cipertext3.Count(); i++)
            {
                if (cipertext3[i] == "0")
                {

                    break;
                }
                else
                {
                    ct3++;
                }
            }
            //  MessageBox.Show(ct3.ToString());
            if ((ct3 - 1) % 2 == 0)
            {
              //   cipertext3[ct3] = cipertext3[ct3-1];
            }
           for (int i = 0; i < cipertext3.Count(); i++)
           {
              // MessageBox.Show(cipertext3[i]);
           }
            int flag4 = 0; int flag5 = 0; int flag6 = 0; int flag7 = 0;
            int f = 0;
            int r3 = 0; int c4 = 0; int FLAG = 0;
            for (int i = 0; i < cipertext3.Count(); i += 2)
            {

                if (cipertext3[i] != "0")
                {
                    flag4 = 0; flag5 = 0; flag6 = 0; flag7 = 0; FLAG = 0;
                    for (r3 = 0; r3 < 5; r3++)
                    {
                        for (c4 = 0; c4 < 5; c4++)
                        {
                            if (cipertext3[i] == EncryptArray2[r3, c4])
                            {
                                flag4 = r3;
                                flag5 = c4;
                                break;
                            }
                        }

                    }

                    for (r3 = 0; r3 < 5; r3++)
                    {
                        for (c4 = 0; c4 < 5; c4++)
                        {

                            if (cipertext3[i + 1] == EncryptArray2[r3, c4])
                            {
                                flag6 = r3;
                                flag7 = c4;
                                break;
                            }

                        }
                        // c4 = 0;
                    }
                    // same row
                    if (FLAG == 0)
                    {
                        if (flag4 == flag6)
                        {
                            if (flag5 - 1 == -1)
                            {
                                flag5 = 5;
                            }
                            if (flag7 -1 == -1)
                            {
                                flag7 = 5;
                            }
                            flag5--;
                            flag7--;
                            decrypttext[f] = EncryptArray2[flag4, flag5];
                            decrypttext[f + 1] = EncryptArray2[flag6, flag7];
                            f += 2;
                            FLAG = 1;
                        }
                    }
                    if (FLAG == 0)
                    {
                        //SAME COLUMN
                        if (flag5 == flag7)
                        {
                            if (flag4 - 1 == -1)
                            {
                                flag4 = 5;
                            }
                            if (flag6 -1 == -1)
                            {
                                flag6 = 5;
                            }
                            flag4--;
                            flag6--;
                            decrypttext[f] = EncryptArray2[flag4, flag5];
                            decrypttext[f + 1] = EncryptArray2[flag6, flag7];
                            f += 2;
                            FLAG = 1;
                        }
                    }
                    if (FLAG == 0)
                    {
                        // DEFRENT ROW AND ROW AND COLM COL
                        if (flag4 != flag6 && flag5 != flag7)
                        {
                            decrypttext[f] = EncryptArray2[flag4, flag7];
                            
                                decrypttext[f + 1] = EncryptArray2[flag6, flag5];
                            
                            f += 2;
                            FLAG = 1;

                        }
                    }
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < decrypttext.Count(); i += 2)
            {
                if (decrypttext[i] != null)
                {
                   MessageBox.Show(decrypttext[i] + decrypttext[i + 1]);
                }

            }


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string g = textBox3.Text.ToString();
            ciphertext2 = g.ToCharArray();
        }
    }
}

