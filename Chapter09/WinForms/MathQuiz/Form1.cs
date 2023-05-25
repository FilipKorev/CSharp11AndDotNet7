using System.Media;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random randomizer = new Random();
        //integers for adding
        int addend1;
        int addend2;
        //integers for subtracting
        int minuend;
        int subtrahend;
        //integers for multiplication
        int multiplicand;
        int multiplier;
        //integers for division
        int dividend;
        int divisor;

        //timer
        int timeLeft;

        public void StartTheQuiz()
        {
            //adding
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            //subtracting
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            Difference.Value = 0;

            //multiplication
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //division
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;


            //start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();


        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }


        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) &&
                (minuend - subtrahend == Difference.Value) &&
                (multiplicand * multiplier == product.Value) &&
                (dividend / divisor == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + "seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finished in time.");
                sum.Value = addend1 + addend2;
                Difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }

            if (timeLeft <= 5)
            {
                timeLabel.BackColor = Color.Red;
            }
            else
            {
                timeLabel.BackColor = Color.White;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lenghtOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lenghtOfAnswer);
            }
        }



        SoundPlayer simpleSound = new SoundPlayer(@"""D:\Code academy\CSharp11AndDotNet7\Chapter09\WinForms\plastic-ball-bounce-14790.mp3""");
        //private void checkAnswer(object sender, EventArgs e)
        //{
        //    string answer = e as string;
        //    string result = (addend1 + addend2).ToString();
        //    if (sender == answer)
        //    {
        //        simpleSound.Play();
        //    }
        //}

        private void checkAnswer2(object sender, EventArgs e)
        {
            string answer2 = sender as string;
            string result2 = (minuend - subtrahend).ToString();
            if (result2 == answer2)
            {
                simpleSound.Play();
            }
        }

        private void chexkAnswer3(object sender, EventArgs e)
        {
            string answer3 = sender as string;
            string result3 = (multiplicand * multiplier).ToString();
            if (result3 == answer3)
            {
                simpleSound.Play();
            }
        }

        private void checkAnswer4(object sender, EventArgs e)
        {
            string answer4 = sender as string;
            string result4 = (dividend / divisor).ToString();
            if (result4 == answer4)
            {
                simpleSound.Play();
            }
        }
    }
}