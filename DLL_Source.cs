using System;

namespace NumberToKurdishWord
{
    public class NumToWord
    {
        string FirstNumber;
        public string Currency;
        string LastNumber;
        public string GetWords(decimal number)
        {
            return NumberToWords(number);
        }

        private string NumberToWords(decimal dec)
        {
            string x = dec.ToString();
            string words = "";
            if (!dec.ToString().Contains("."))
            {
                Int64 number = Convert.ToInt64(dec);


                if (number <= 999999999999)
                {


                    if (number == 0)
                        return "سفر";

                    if (number < 0)
                        return "کەم " + NumberToWords(Math.Abs(number));



                    if ((number / 1000000000) > 0)
                    {

                        if (number > 1000099999 && number < 9999999999)
                        {
                            words += NumberToWords(number / 1000000000) + " بلیۆن * ";
                            number %= 1000000000;
                        }
                        else
                        {
                            words += NumberToWords(number / 1000000000) + " بلیۆن ";
                            number %= 1000000000;
                        }

                    }

                    if ((number / 1000000) > 0)
                    {
                        if (number > 1009999 && number < 999999999)
                        {
                            words += NumberToWords(number / 1000000) + " ملیۆن * ";
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
                        if (number < 1001)
                        {
                            words += " هەزار * ";
                            number %= 1000;
                        }
                        else
                        {
                            if (number > 1099 && number < 9999999)
                            {
                                words += NumberToWords(number / 1000) + " هەزار * ";
                                number %= 1000;
                            }
                            else
                            {
                                words += NumberToWords(number / 1000) + " هەزار ";
                                number %= 1000;
                            }

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
                        else if (!(number <= 100))
                        {
                            words += " سەد ";
                            number %= 100;
                        }
                    }
                    else
                    {
                        words += " سەد ";
                        number %= 100;
                    }


                    if (number > 0)
                    {
                        if (words != "")
                            words += " * ";

                        var units = new[]
                        {
                    "سفر", "یەک", "دوو", "سێ", "چوار", "پێنچ", "شەش", "حەوت", "هەشت", "نۆ", "دە", "یازدە", "دوازدە", "سێزدە", "چواردە", "پازدە", "شازدە", "حەڤدە", "هەژدە", "نۆزدە"
                };
                        var tens = new[]
                        {
                    "سفر", "دە", "بیست", "سی", "چل", "پەنجا", "شێست", "حەفتا", "هەشتا", "نەوەت"
                };

                        if (number < 20)
                            words += units[Convert.ToInt64(number)];
                        else
                        {
                            words += tens[Convert.ToInt64(number) / 10];
                            if ((number % 10) > 0)
                                words += " * " + units[Convert.ToInt64(number) % 10];
                        }
                    }

                }
                else
                {
                    return "ئەم ژمارەیە پشتگیری لێ ناکرێت!";
                }
            }
            else if (dec.ToString().Contains("."))
            {
                try
                {
                    
                    FirstNumber = NumberToWords(Convert.ToInt64(x.Substring(0, x.Length - 3)));
                    if (Convert.ToInt32(x.Substring(x.IndexOf('.') + 1)) != 0)
                    {
                        LastNumber = NumberToWords(Convert.ToInt64(x.Substring(x.IndexOf('.') + 1)));
                        words += FirstNumber + " " + Currency + " و " + LastNumber + " سەنت";
                    }
                    else 
                    {
                        words += FirstNumber + " " + Currency ;
                    }
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

            return words.TrimEnd('*', ' ').Replace("*", "و");

        }
    }
}
