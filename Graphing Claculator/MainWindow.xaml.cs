using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Graphing_Claculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double firstNum;
        string operation;

        public MainWindow()
        {
            InitializeComponent();
        }

        //numeric buttons
        private void one_button_Click_1(object sender, RoutedEventArgs e)
        {
            if(Screen.Text != null && Screen.Text == "0")
            {
                Screen.Text = "1";
            }
            else
            {
                Screen.Text += "1";
            }
        }

        private void two_button_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != null && Screen.Text == "0")
            {
                Screen.Text = "2";
            }
            else
            {
                Screen.Text += "2";
            }
        }

        private void three_button_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != null && Screen.Text == "0")
            {
                Screen.Text = "3";
            }
            else
            {
                Screen.Text += "3";
            }
        }

        private void four_button_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != null && Screen.Text == "0")
            {
                Screen.Text = "4";
            }
            else
            {
                Screen.Text += "4";
            }
        }

        private void five_button_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != null && Screen.Text == "0")
            {
                Screen.Text = "5";
            }
            else
            {
                Screen.Text += "5";
            }
        }

        private void six_button_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != null && Screen.Text == "0")
            {
                Screen.Text = "6";
            }
            else
            {
                Screen.Text += "6";
            }
        }

        private void seven_button_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != null && Screen.Text == "0")
            {
                Screen.Text = "7";
            }
            else
            {
                Screen.Text += "7";
            }
        }

        private void eight_button_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != null && Screen.Text == "0")
            {
                Screen.Text = "8";
            }
            else
            {
                Screen.Text += "8";
            }
        }

        private void nine_button_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != null && Screen.Text == "0")
            {
                Screen.Text = "9";
            }
            else
            {
                Screen.Text += "9";
            }
        }

        private void zero_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text += "0";
        }

        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = "0";
        }

        private void plus_button_Click(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(Screen.Text);
            Screen.Text = "0";
            operation = "+";
        }

        private void minus_button_Click(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(Screen.Text);
            Screen.Text = "0";
            operation = "-";
        }

        private void division_button_Click(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(Screen.Text);
            Screen.Text = "0";
            operation = "/";
        }

        private void multiply_button_Click(object sender, RoutedEventArgs e)
        {
            firstNum = Convert.ToDouble(Screen.Text);
            Screen.Text = "0";
            operation = "*";
        }

        private void decimal_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text += ".";
        }

        private void equals_button_Click(object sender, RoutedEventArgs e)
        {
            double secondNum;
            double result;

            secondNum = Convert.ToDouble(Screen.Text);

            if(operation == "+")
            {
                result = (firstNum + secondNum);
                Screen.Text = Convert.ToString(result);
                firstNum = result;
            }
            else if(operation == "-")
            {
                result = (firstNum - secondNum);
                Screen.Text = Convert.ToString(result);
                firstNum = result;
            }
            else if(operation == "*")
            {
                result = (firstNum * secondNum);
                Screen.Text = Convert.ToString(result);
                firstNum = result;
            }
            else if (operation == "/")
            {
                if(secondNum == 0)
                {
                    Screen.Text = "Cannot divide by zero";
                }
                else
                {
                    result = (firstNum / secondNum);
                    Screen.Text = Convert.ToString(result);
                    firstNum = result;
                }
            }
        }
    }
}
