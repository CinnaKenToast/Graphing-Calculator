using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//how we get to to talk to our libary
using CalcLib;

namespace Graphing_Claculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //numeric buttons
        private void one_button_Click_1(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.NumButtonPress(Screen.Text, "1");
        }

        private void two_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.NumButtonPress(Screen.Text, "2");
        }

        private void three_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.NumButtonPress(Screen.Text, "3");
        }

        private void four_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.NumButtonPress(Screen.Text, "4");
        }

        private void five_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.NumButtonPress(Screen.Text, "5");
        }

        private void six_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.NumButtonPress(Screen.Text, "6");
        }

        private void seven_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.NumButtonPress(Screen.Text, "7");
        }

        private void eight_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.NumButtonPress(Screen.Text, "8");
        }

        private void nine_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.NumButtonPress(Screen.Text, "9");
        }

        private void zero_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.NumButtonPress(Screen.Text, "0");
        }

        //arithmetic buttions
        private void plus_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "+");
        }

        private void minus_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "-");
        }

        private void division_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "/");
        }

        private void multiply_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "*");
        }

        private void decimal_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, ".");
        }

        //trig buttons 
        private void sin_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "sin(");
        }
        private void cos_button_click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "cos(");
        }
        private void tan_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "tan(");
        }
        private void csc_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "csc(");
        }
        private void sec_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "sec(");
        }
        private void cot_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "cot(");
        }


        //misc buttons
        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.ClearButtonPress(Screen.Text);
        }

        //TODO: Make some sort of history display
        List<string> input = new List<string>();
        MathParser parser = new MathParser();
        private void equals_button_Click(object sender, RoutedEventArgs e)
        {
            //trim the input, save in it list
            input.Insert(0,Screen.Text.Trim());

            //get answer from parser, display on screen
            double ans = parser.Parse(input[0]);
            Screen.Text = ans.ToString();

            //MessageBox.Show(input[0]);
        }

        //menu stuff
        //TODO: implement the calculator view button
        graphing Graph = new graphing();
        private void Calculator_Clicked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Graphing_Clicked(object sender, RoutedEventArgs e)
        {
            Graph.Show();
        }

        private void right_parentheses_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, ")");
        }

        private void left_parentheses_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "(");
        }

        private void power_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "^");
        }

        private void mod_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "mod(");
        }

        private void log_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "log(");
        }

        private void ln_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "ln(");
        }

        private void factorial_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "!");
        }

        private void negate_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "(+/-)");
        }

        private void sqrt_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "sqrt(");
        }

        private void pi_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "pi");
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.DeleteButtonPress(Screen.Text);
        }

        private void e_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "e");
        }
    }
}
