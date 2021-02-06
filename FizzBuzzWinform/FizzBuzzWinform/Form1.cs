using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public event EventHandler FireFizz;
        public event EventHandler FireBuzz;
        public Form1()
        {
            InitializeComponent();
        }

        private void FizzOccured()
        {
            if (FireFizz != null)
            {
                FireFizz.Invoke(this, EventArgs.Empty);
            }
        }

        private void BuzzOccured()
        {
            if (FireBuzz != null)
            {
                FireBuzz.Invoke(this, EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FireFizz += ShowFizz;
            FireBuzz += ShowBuzz;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(numberLbl.Text);
            number++;
            numberLbl.Text = number.ToString();
            fizzLbl.Visible = false;
            buzzLbl.Visible = false;
            if (number % 3 == 0)
            {
                FizzOccured();
            }
            if (number % 5 == 0)
            {
                BuzzOccured();
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void ShowFizz(object sender, EventArgs e)
        {
            fizzLbl.Visible = true;
        }

        private void ShowBuzz(object sender, EventArgs e)
        {
            buzzLbl.Visible = true;
        }
    }
}
