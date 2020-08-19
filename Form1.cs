using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = NumberToWords(Convert.ToInt32(textBox1.Text))+" دۆلار ";
            }
            catch { }
        }

        private string NumberToWords(int number)
        {
            if (number == 0)
                return "سفر";

            if (number < 0)
                return "کەم " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                if (number > 1000999) 
                {
                    words += NumberToWords(number / 1000000) + " ملیۆن و ";
                    number %= 1000000;
                }
                else 
                {
                    words += NumberToWords(number / 1000000) + " ملیۆن ";
                    number %= 1000000;
                }
                
            }

            if ((number / 1000) > 0)
            {
                if (number > 1099)
                {
                    words += NumberToWords(number / 1000) + " هەزار و ";
                    number %= 1000;
                }
                else
                {
                    words += NumberToWords(number / 1000) + " هەزار ";
                    number %= 1000;
                }
            }
            if (number != 100)
            {
                if (number > 199)
                {
                    if ((number / 100) > 0)
                    {
                        words += NumberToWords(number / 100) + " سەد ";
                        number %= 100;
                    }
                }
                else if(!(number<=100))
                {
                    words +=  " سەد ";
                    number %= 100;
                }
            }
            else 
            {
                words +=" سەد ";
                number %= 100;
            }


            if (number > 0)
            {
                if (words != "")
                    words += " و ";

                var units = new[] 
                {
                    "سفر", "یەک", "دوو", "سێ", "چوار", "پێنچ", "شەش", "حەوت", "هەشت", "نۆ", "دە", "یازدە", "دوازدە", "سێزدە", "چواردە", "پازدە", "شازدە", "حەڤدە", "هەژدە", "نۆزدە" 
                };
                var tens = new[] 
                {
                    "سفر", "دە", "بیست", "سی", "چل", "پەنجا", "شێست", "حەفتا", "هەشتا", "نەوەت" 
                };

                if (number < 20)
                    words += units[number];
                else
                {
                    words += tens[number / 10];
                    if ((number % 10) > 0)
                        words += " و " + units[number % 10];
                }
            }
            return words;
        }


    }
}
