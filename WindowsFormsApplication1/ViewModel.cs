using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class ViewModel
    {
        Button buttonStartTest;
        RichTextBox tBox1;
        RichTextBox tBox2;
        RichTextBox tBoxOutput;

        private string sampleLine1 = "..w..w.w...w...", sampleLine2 = ".w....w.....w..";

        public ViewModel(Button btn, RichTextBox tBox1, RichTextBox tBox2, RichTextBox tBoxOutput)
        {
            this.buttonStartTest = btn;
            this.tBox1 = tBox1;
            this.tBox2 = tBox2;
            this.tBoxOutput = tBoxOutput;
            
            this.tBox1.Text = sampleLine1;
            this.tBox2.Text = sampleLine2;
        }

        public void addLine(string text)
        {
            this.tBoxOutput.AppendText(text + "\n");
        }

        public void clearTextBox()
        {
            this.tBoxOutput.Clear();
        }

        public void setScreenColor(Color color)
        {
            this.tBoxOutput.BackColor = color;
        }
    }
}
