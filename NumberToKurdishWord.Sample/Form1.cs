using System;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
namespace NumberToKurdishWord.Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = ConvertToWord.GetWords(textBox2.Text, Currency.USD);
        }
    }
}
