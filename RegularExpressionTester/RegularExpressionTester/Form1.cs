using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RegularExpressionTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            txtPattern.BackColor = Color.White;

            if (VerifyRegEx(txtPattern.Text))
            {
                string pattTest = txtPattern.Text;
                Regex rgx = new Regex(pattTest);
                string testText = textBox1.Text.Trim();


                if (rgx.IsMatch(testText))
                { textBox1.ForeColor = Color.Green; }
                else
                { textBox1.ForeColor = Color.Red; }

            }
            else {
                txtPattern.Text = txtPattern.Text + " <<< NOT A VALID REGEX!!!";
                txtPattern.ForeColor = Color.Red;
                txtPattern.BackColor = Color.Ivory;

                //  a{3(}}}$ - INVALID PATTERN EXAMPLE
            }

        }

        public static bool VerifyRegEx(string testPattern)
        {
            bool isValid = true;
            if ((testPattern != null) && (testPattern.Trim().Length > 0))
            {
                try
                {
                    Regex.Match("", testPattern);
                }
                catch (ArgumentException)
                {
                    // BAD PATTERN: Syntax error
                    isValid = false;
                }
            }
            else
            {
                //BAD PATTERN: Pattern is null or blank
                isValid = false;
            }
            return (isValid);
        }

        private void txtPattern_TextChanged(object sender, EventArgs e)
        {
            txtPattern.ForeColor = Color.Black;
        }


    }
}
