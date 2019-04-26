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
using System.Drawing;
using System.Windows.Forms;
//how we get to to talk to our libary
using CalcLib;

namespace Graphing_Claculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void drawInitialCanvas()
        {
            // Draw Borders
            Line borderLine1 = new Line();
            borderLine1.Stroke = System.Windows.Media.Brushes.Black;
            borderLine1.StrokeThickness = 2;
            borderLine1.X1 = 0;
            borderLine1.Y1 = 0;
            borderLine1.X2 = 0;
            borderLine1.Y2 = Canvas.Height;
            Canvas.Children.Add(borderLine1);
            Line borderLine2 = new Line();
            borderLine2.Stroke = System.Windows.Media.Brushes.Black;
            borderLine2.StrokeThickness = 2;
            borderLine2.X1 = 0;
            borderLine2.Y1 = 0;
            borderLine2.X2 = Canvas.Width;
            borderLine2.Y2 = 0;
            Canvas.Children.Add(borderLine2);
            Line borderLine3 = new Line();
            borderLine3.Stroke = System.Windows.Media.Brushes.Black;
            borderLine3.StrokeThickness = 2;
            borderLine3.X1 = Canvas.Width;
            borderLine3.Y1 = 0;
            borderLine3.X2 = Canvas.Width;
            borderLine3.Y2 = Canvas.Height;
            Canvas.Children.Add(borderLine3);
            Line borderLine4 = new Line();
            borderLine4.Stroke = System.Windows.Media.Brushes.Black;
            borderLine4.StrokeThickness = 2;
            borderLine4.X1 = 0;
            borderLine4.Y1 = Canvas.Height;
            borderLine4.X2 = Canvas.Width;
            borderLine4.Y2 = Canvas.Height;
            Canvas.Children.Add(borderLine4);

            // Draw Axis
            Line xAxis = new Line();
            xAxis.Stroke = System.Windows.Media.Brushes.Black;
            xAxis.X1 = 0;
            xAxis.Y1 = Canvas.Height / 2;
            xAxis.X2 = Canvas.Width;
            xAxis.Y2 = Canvas.Height / 2;
            Canvas.Children.Add(xAxis);
            Line yAxis = new Line();
            yAxis.Stroke = System.Windows.Media.Brushes.Black;
            yAxis.X1 = Canvas.Width / 2;
            yAxis.Y1 = 0;
            yAxis.X2 = Canvas.Width / 2;
            yAxis.Y2 = Canvas.Height;
            Canvas.Children.Add(yAxis);
        }
        public MainWindow()
        {
            InitializeComponent();
            drawInitialCanvas();
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
            //TextBlock.Text = ButtonControl.ClearButtonPress(TextBlock.Text);
        }

        
        MathParser parser = new MathParser();
        bool isRadians = true;
        Graph graph = new Graph();
        private void Radians_Button_Clicked(object sender, RoutedEventArgs e)
        {
            if(Radians_Button.IsChecked == true)
            {
                isRadians = true;
            }
            else
            {
                isRadians = false;
            }
        }

        
        private void Screen_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Return || e.Key == Key.Enter)
            {
                equals_button_Click(sender, e);
            }
        }
        

        private void equals_button_Click(object sender, RoutedEventArgs e)
        {
            //trim imput, send into parser
            //get answer from parser, display on screen
            double ans = parser.Parse(Screen.Text.Trim(), isRadians);

            //add input and answer to history
            TextBlock.AppendText(Screen.Text.Trim() + " = " + ans.ToString() + "\n");
            TextBlock.ScrollToEnd();

            //clear screen
            Screen.Text = ButtonControl.ClearButtonPress(Screen.Text);
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
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "%");
        }

        private void log_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "log(");
        }

        private void ln_button_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "ln(");
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

        
        private void Plot_button_click(object sender, RoutedEventArgs e)
        {
            string expression = Screen.Text.Trim();
            int sizeX = (int)Canvas.Width;
            int sizeY = (int)Canvas.Height;
            double minX = graph.getXLowerBound();
            double maxX = graph.getXUpperBound();
            double minY = graph.getYLowerBound();
            double maxY = graph.getYUpperBound();

            System.Drawing.Point currentPoint = new System.Drawing.Point();
            System.Drawing.Point previousPoint = new System.Drawing.Point();
            for (double x = minX; x < maxX; x += (maxX - minX)/sizeX)
            {
                Line line = new Line();
                line.Stroke = System.Windows.Media.Brushes.Black;
                double y = graph.getY(expression, x);
                currentPoint.X = (int)(x / ((maxX - minX) / sizeX) - minX / ((maxX - minX) / (double)sizeX));
                currentPoint.Y = (int)(sizeY - (y / ((maxY - minY) / sizeY) - minY / ((maxY - minY) / (double)sizeY)));
                
                line.X1 = previousPoint.X;
                line.Y1 = previousPoint.Y;
                line.X2 = currentPoint.X;
                line.Y2 = currentPoint.Y;
                Canvas.Children.Add(line);
                Console.WriteLine(line.X1 + ", " + line.Y1);
                Console.WriteLine(line.X2 + ", " + line.Y2);
                   

                previousPoint = currentPoint;
            }
            TextBlock.AppendText(Screen.Text.Trim() + " is plotted\n");
        }

        private void Clear_Plot_button_click(object sender, RoutedEventArgs e)
        {
            Canvas.Children.Clear();
            drawInitialCanvas();
        }

        private void clear_history_button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock.Clear();
        }

        private void x_button_click(object sender, RoutedEventArgs e)
        {
            Screen.Text = ButtonControl.arithmeticButonPress(Screen.Text, "x");
        }

    }
}
