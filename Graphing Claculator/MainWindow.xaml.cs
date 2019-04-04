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
            Screen.Text = ButtonControl.DecimalButtonPress(Screen.Text);
        }

        //misc buttons
        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.ClearButtonPress(Screen.Text);
        }

        private void equals_button_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        //menu stuff
        private void Calculator_Checked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Calculator_Unchecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Graphing_Checked(object sender, RoutedEventArgs e)
        {
            var window = new Window();
            window.Show();
        }

        private void Graphing_Unchecked(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
