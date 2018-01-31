using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patti_Jones_Math_Quiz
{
    public partial class Form1 : Form
    {
        //Create a Random object called randomizer to generate random numbers.
        Random randomizer = new Random();

        //Variables store the number for the addition problem.
        int addend1;
        int addend2;

        //Variables store the number for the substraction problem.
        int minuend;
        int subtrahend;

        //Variables store the numbers for the multiplication problem.
        int multiplicand;
        int multiplier;

        //Variables store the numbers for the division problem.
        int dividend;
        int divisor;

        //Variable to keep track of the remaining time.
        int timeLeft;

        //Start the quiz by filling in all of the problems and starting timer.
        public void StartTheQuiz()
        {
            timeLabel.BackColor = BackColor;
            //Fill the addition problem.
            //Generate two random numbers to add.
            //Store the values in the variables.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //Convert two random generated numbers into string for displaying.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //Step to make sure value starts at zero before adding new values.
            sum.Value = 0;

            //Fill in the substraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //Fill in the multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //Fill in the division problem
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            //Start timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        public Form1()
        {
            InitializeComponent();
            DateTime date = DateTime.Today;
            dateLabel.Text = date.ToString("dd MMMM yyyy");
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) 
                && (minuend - subtrahend == difference.Value) 
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if time left less than five second then change textbox to red
            if (CheckTheAnswer())
            {
                //If returns true, stop the timer and show message
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                    "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                //If returns false, keep counting down. Decrease time
                //by one second and update the time left.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                if (timeLeft < 6 && timeLeft >= 0)
                {
                    timeLabel.BackColor = Color.Red;
                }
                else
                {
                    timeLabel.BackColor = BackColor;
                }
            }
            else
            {
                //If user rans out of time, stop timer and show message
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //Select the whole answer
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
        //do another method that uses an event checker that when the value
        //is changed that has an if statement that when the value is correct a
        //play a sound
        private void PlaySimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
            simpleSound.Play();
        }
        private void sum_ValueChanged(object sender, EventArgs e)
        {
            if (timeLeft > 1 && addend1 + addend2 == sum.Value)
            {
                PlaySimpleSound();
            }
        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {
            if (timeLeft > 1 && minuend - subtrahend == difference.Value)
            {
                PlaySimpleSound();
            }
        }

        private void product_ValueChanged(object sender, EventArgs e)
        {
            if (timeLeft > 1 && multiplicand * multiplier == product.Value)
            {
                PlaySimpleSound();
            }
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {
            if (timeLeft > 1 && dividend / divisor == quotient.Value)
            {
                PlaySimpleSound();
            }
        }
    }
}
