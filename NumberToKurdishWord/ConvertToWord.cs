//Diyari Ismael
//https://github.com/Diyari-Kurdi

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NumberToKurdishWord
{
    public static class ConvertToWord
    {
        static string FirstNumber;
        private static string CurrencyStr = "";
        static string LastNumber;
        private static bool isZero = false;

        public static string GetWords(object number, Currency _currency = Currency.USD)
        {
            return NumberToWords(number, false, _currency);
        }

        private static bool IsKurdish(string value)
        {
            char[] kurdishNumbers = { '٠', '١', '٢', '٣', '٤', '٥', '٦', '٧', '٨', '٩' };

            if (value.Any(ch => kurdishNumbers.Contains(ch)))
                return true;
            else
                return false;

        }

        private static char ConverKurdishNumberToEN(char value)
        {
            switch (value)
            {
                case '٠':
                    return '0';
                case '١':
                    return '1';
                case '٢':
                    return '2';
                case '٣':
                    return '3';
                case '٤':
                    return '4';
                case '٥':
                    return '5';
                case '٦':
                    return '6';
                case '٧':
                    return '7';
                case '٨':
                    return '8';
                case '٩':
                    return '9';
                case '.':
                    return '.';
            }
            return value;
        }
        private static string NumberToWords(object num, bool isCents = false, Currency _currency = Currency.USD)
        {
            if (!isZero)
            {
                if (_currency == Currency.IQD)
                {
                    CurrencyStr = "دینار";
                }
                else
                {
                    CurrencyStr = "دۆلار";
                }
            }

            string newStr = "";
            if (IsKurdish(num.ToString()))
            {
                foreach (char ch in num.ToString().ToCharArray())
                {
                    newStr += ConverKurdishNumberToEN(ch).ToString();
                }
                num = newStr;
            }

            if (!String.IsNullOrWhiteSpace(num.ToString()) && !Regex.IsMatch(num.ToString(), @"[a-zA-Z]") && !Regex.IsMatch(num.ToString(), @"\p{IsArabic}"))
            {
                string x = num.ToString();
                string words = "";
                if (!num.ToString().Contains("."))
                {

                    var units = new[]
                                {
                    "سفر", "یەک", "دوو", "سێ", "چوار", "پێنچ", "شەش", "حەوت", "هەشت", "نۆ", "دە", "یازدە", "دوازدە", "سێزدە", "چواردە", "پازدە", "شازدە", "حەڤدە", "هەژدە", "نۆزدە"
                };
                    var tens = new[]
                            {
                    "سفر", "دە", "بیست", "سی", "چل", "پەنجا", "شێست", "حەفتا", "هەشتا", "نەوەت"
                };

                    Int64 number = Convert.ToInt64(num.ToString());
                    if (!isCents)
                    {
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
                                        words += NumberToWords(number / 100).TrimEnd() + " سەد";
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
                                if (words != "" && !words.TrimEnd().EndsWith("*"))
                                    words += " * ";

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
                    else
                    {
                        if (number > 0)
                        {
                            if (words != "")
                                words += " * ";

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
                }

                else if (num.ToString().Contains("."))
                {
                    try
                    {
                        decimal parsed = decimal.Parse(num.ToString(), System.Globalization.CultureInfo.InvariantCulture);

                        long main = (long)Math.Floor(parsed);
                        long cents = (long)Math.Round((parsed - main) * 100);

                        if (main > 0)
                        {
                            FirstNumber = NumberToWords(main);
                        }
                        else
                        {
                            FirstNumber = "";
                            CurrencyStr = "";
                            isZero = true;
                        }

                        if (cents != 0)
                        {
                            LastNumber = NumberToWords(cents, true);
                            string kurdish_W = isZero ? "" : " و ";
                            words += FirstNumber + " " + CurrencyStr + kurdish_W + LastNumber + " سەنت";
                            isZero = false;
                        }
                        else
                        {
                            words += FirstNumber + " " + CurrencyStr;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }


                return words.TrimEnd('*', ' ').Replace("*", "و");
            }
            else
            {
                return "سفر";
            }

        }
    }
}
