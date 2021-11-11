using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DansCalculator
{
    public partial class MainWindow
    {
        public decimal number1 { get; set; }
        public decimal number2 { get; set; }
        public decimal answer { get; set; }
        public string op { get; set; }

        public void ButtonInput(decimal input)
        {
            if (op == "")
            {
                number1 = (number1 * 10m) + input;
                numberArea.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10m) + input;
                numberArea.Text = number2.ToString();
            }
        }

        public void ButtonInputOp(string input)
        {
            op = input;
            numberArea.Text = input;
        }

        public void ButtonInputEquals()
        {
            switch (op)
            {
                case "+":
                    answer = number1 + number2;
                    numberArea.Text = answer.ToString();
                    number1 = 0;
                    number2 = 0;
                    op = "";
                    break;
                case "-":
                    answer = number1 - number2;
                    numberArea.Text = answer.ToString();
                    number1 = 0;
                    number2 = 0;
                    op = "";
                    break;
                case "*":
                    answer = number1 * number2;
                    numberArea.Text = answer.ToString();
                    number1 = 0;
                    number2 = 0;
                    op = "";
                    break;
                case "/":
                    answer = number1 / number2;
                    numberArea.Text = answer.ToString();
                    number1 = 0;
                    number2 = 0;
                    op = "";
                    break;
                default:
                    break;
            }
        }
    }
}
