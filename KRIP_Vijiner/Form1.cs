using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KRIP_Vijiner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Shifr_Click(object sender, EventArgs e)
        {
            char[] text = Text.Text.ToCharArray();
            char[] shifr = Text.Text.ToCharArray();
            char[] ALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] alph = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
            char[] ALPH = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
            char[] key = keyBox.Text.ToCharArray();

            int text_len = 0;
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < ALPH.Length; j++)
                {
                    if (text[i] == ALPH[j] || text[i] == alph[j])
                        text_len++;
                }

                for (int j = 0; j < ALPHA.Length; j++)
                {
                    if (text[i] == ALPHA[j] || text[i] == alpha[j])
                        text_len++;
                }
            }

            char[] full_key = new char[text_len];
            int i1 = 0, j1 = 0;
            for (int i = 0; i < text_len;) // дополняем ключ с проверкой на посторонние символы
            {
                for (int j = 0; j < ALPH.Length; j++)
                {
                    if (key[i1] == ALPH[j] || key[i1] == alph[j])
                    {
                        full_key[i] = key[i1];
                        i++;
                        break;
                    }
                }
                for (int j = 0; j < ALPHA.Length; j++)
                {
                    if (key[i1] == ALPHA[j] || key[i1] == alpha[j])
                    {
                        full_key[i] = key[i1];
                        i++;
                        break;
                    }
                }
                i1++;
                if (i1 == key.Length)
                    i1 = 0;
            }

            int k = 0, z = 0; i1 = -1; j1 = -1;
            for (int i = 0; i < text.Length; i++)
            {
                shifr[k] = text[i];
                for (int j = 0; j < ALPHA.Length; j++)
                {
                    if (text[i] == ALPHA[j])
                    {
                        i1 = j;
                    }
                    if (full_key[z] == ALPHA[j])
                    {
                        j1 = j;                   
                    }
                }
                if (i1 != -1 && j1 != -1)
                {
                    i1 = i1 + j1;
                    if (i1 >= 26)
                        i1 = i1 % 26;
                    shifr[k] = ALPHA[i1];

                    z++; // next full_key
                    if (z == full_key.Length)
                        break;
                }
                i1 = -1; j1 = -1;
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (text[i] == alpha[j])
                    {
                        i1 = j;
                    }
                    if (full_key[z] == alpha[j])
                    {
                        j1 = j;
                        
                    }
                }
                if (i1 != -1 && j1 != -1)
                {
                    i1 = i1 + j1;
                    if (i1 >= 26)
                        i1 = i1 % 26;
                    shifr[k] = alpha[i1];

                    z++; // next full_key
                    if (z == full_key.Length)
                        break;
                }
                i1 = -1; j1 = -1;
                for (int j = 0; j < ALPH.Length; j++)
                {
                    if (text[i] == ALPH[j])
                    {
                        i1 = j;
                    }
                    if (full_key[z] == ALPH[j])
                    {
                        j1 = j;
                        
                    }
                }
                if (i1 != -1 && j1 != -1)
                {
                    i1 = i1 + j1;
                    if (i1 >= 33)
                        i1 = i1 % 33;
                    shifr[k] = ALPH[i1];

                    z++; // next full_key
                    if (z == full_key.Length)
                        break;
                }
                i1 = -1; j1 = -1;
                for (int j = 0; j < ALPH.Length; j++)
                {
                    if (text[i] == alph[j])
                    {
                        i1 = j;
                    }
                    if (full_key[z] == alph[j])
                    {
                        j1 = j;
                        
                    }
                }
                if (i1 != -1 && j1 != -1)
                {
                    i1 = i1 + j1;
                    if (i1 >= 33)
                        i1 = i1 % 33;
                    shifr[k] = alph[i1];

                    z++; // next full_key
                    if (z == full_key.Length)
                        break;
                }
                i1 = -1; j1 = -1;
                k++;
            }
            string text1 = new string(shifr);
            ShifrText.Text = text1;
        }

        private void button_unShifr_Click(object sender, EventArgs e)
        {
            char[] text = Text.Text.ToCharArray();
            char[] shifr = Text.Text.ToCharArray();
            char[] ALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] alph = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л',
'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э',
'ю', 'я' };
            char[] ALPH = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
            char[] key = keyBox.Text.ToCharArray();
            int text_len = 0;
            for (int i = 0; i < shifr.Length; i++)
            {
                for (int j = 0; j < ALPH.Length; j++)
                {
                    if (shifr[i] == ALPH[j] || shifr[i] == alph[j])
                        text_len++;
                }

                for (int j = 0; j < ALPHA.Length; j++)
                {
                    if (shifr[i] == ALPHA[j] || shifr[i] == alpha[j])
                        text_len++;
                }
            }

            char[] full_key = new char[text_len];
            int i1 = 0, j1 = 0;
            for (int i = 0; i < text_len;) // дополняем ключ с проверкой на посторонние символы
            {
                for (int j = 0; j < ALPH.Length; j++)
                {
                    if (key[i1] == ALPH[j] || key[i1] == alph[j])
                    {
                        full_key[i] = key[i1];
                        i++;
                        break;
                    }
                }
                for (int j = 0; j < ALPHA.Length; j++)
                {
                    if (key[i1] == ALPHA[j] || key[i1] == alpha[j])
                    {
                        full_key[i] = key[i1];
                        i++;
                        break;
                    }
                }
                i1++;
                if (i1 == key.Length)
                    i1 = 0;
            }

            int k = 0, z = 0; i1 = -1; j1 = -1;
            for (int i = 0; i < shifr.Length; i++)
            {
                text[k] = shifr[i];
                for (int j = 0; j < ALPHA.Length; j++)
                {
                    if (shifr[i] == ALPHA[j])
                    {
                        i1 = j;
                    }
                    if (full_key[z] == ALPHA[j])
                    {
                        j1 = j;
                    }
                }
                if (i1 != -1 && j1 != -1)
                {
                    i1 = i1 - j1;
                    if (i1 < 0)
                        i1 = i1 + 26;
                    text[k] = ALPHA[i1];

                    z++; // next full_key
                    if (z == full_key.Length)
                        break;
                }
                i1 = -1; j1 = -1;
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (shifr[i] == alpha[j])
                    {
                        i1 = j;
                    }
                    if (full_key[z] == alpha[j])
                    {
                        j1 = j;

                    }
                }
                if (i1 != -1 && j1 != -1)
                {
                    i1 = i1 - j1;
                    if (i1 < 0)
                        i1 = i1 + 26;
                    text[k] = alpha[i1];

                    z++; // next full_key
                    if (z == full_key.Length)
                        break;
                }
                i1 = -1; j1 = -1;
                for (int j = 0; j < ALPH.Length; j++)
                {
                    if (shifr[i] == ALPH[j])
                    {
                        i1 = j;
                    }
                    if (full_key[z] == ALPH[j])
                    {
                        j1 = j;

                    }
                }
                if (i1 != -1 && j1 != -1)
                {
                    i1 = i1 - j1;
                    if (i1 < 0)
                        i1 = i1 + 33;
                    text[k] = ALPH[i1];

                    z++; // next full_key
                    if (z == full_key.Length)
                        break;
                }
                i1 = -1; j1 = -1;
                for (int j = 0; j < ALPH.Length; j++)
                {
                    if (shifr[i] == alph[j])
                    {
                        i1 = j;
                    }
                    if (full_key[z] == alph[j])
                    {
                        j1 = j;

                    }
                }
                if (i1 != -1 && j1 != -1)
                {
                    i1 = i1 - j1;
                    if (i1 < 0)
                        i1 = i1 + 33;
                    text[k] = alph[i1];

                    z++; // next full_key
                    if (z == full_key.Length)
                        break;
                }
                i1 = -1; j1 = -1;
                k++;

            }
            string text1 = new string(text);
            ShifrText.Text = text1;
        }
 



private void Text_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShifrText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
