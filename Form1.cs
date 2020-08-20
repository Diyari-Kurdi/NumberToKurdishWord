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
        
        int[] thousends =
            {
            1000,
            2000,
            3000,
            4000,
            5000,
            6000,
            7000,
            8000,
            9000,
            10000,
             20000,
             30000,
             40000,
             50000,
             60000,
             70000,
             80000,
             90000,
             100000,
             200000,
             300000,
             400000,
             500000,
             600000,
             700000,
             800000,
             900000
        };
        int[] millions =
            {
            1000000,
            2000000,
            3000000,
            4000000,
            5000000,
            6000000,
            7000000,
            8000000,
            9000000,
            10000000,
             20000000,
             30000000,
             40000000,
             50000000,
             60000000,
             70000000,
             80000000,
             90000000,
             100000000,
             200000000,
             300000000,
             400000000,
             500000000,
             600000000,
             700000000,
             800000000,
             900000000
        };

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
        
        bool containsthousends = false;

            foreach (int n in thousends)
            {
                if (n == number) 
                {
                    containsthousends = true;
                    break;
                }
            }
            bool containsMillions = false;

            foreach (int n in millions)
            {
                if (n == number)
                {
                    containsMillions = true;
                    break;
                }
            }
        
            if (number == 0)
                return "سفر";

            if (number < 0)
                return "کەم " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                if (number > 1009999 && number< 999999999 && containsMillions!=true) 
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
                if (number > 1099 && number < 9999999 && containsthousends != true)
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
