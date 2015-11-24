using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class ControlModel
    {
        Button buttonStartTest;
        RichTextBox tBox1;
        RichTextBox tBox2;
        RichTextBox tBoxOutput;

        Model model;

        public ControlModel(Model model, Button btn, RichTextBox tBox1, RichTextBox tBox2, RichTextBox tBoxOutput)
        {
            this.model = model;
            this.buttonStartTest = btn;
            this.tBox1 = tBox1;
            this.tBox2 = tBox2;
            this.tBoxOutput = tBoxOutput;

            this.tBox1.TextChanged += (object sender, EventArgs e) =>
            {
               this.buttonStartTest.Enabled = (this.model.isCorrectData(this.tBox1.Text, this.tBox2.Text) ? true : false);                    
            };
            
            this.tBox2.TextChanged += (object sender, EventArgs e) =>
            {
                this.buttonStartTest.Enabled = (this.model.isCorrectData(this.tBox1.Text, this.tBox2.Text) ? true : false);                    
            };
            
            //this.buttonStartTest.Enabled = false;
            this.buttonStartTest.Click += (object sender, EventArgs e) =>
            {
                this.model.startGame(this.tBox1.Text, this.tBox2.Text);
            };
        }
        
    }
}
