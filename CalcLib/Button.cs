﻿using System;


namespace CalcLib
{
    public class ButtonControl
    {
        public static string NumButtonPress(string Text, string num)
        {
            //check if null
            if (Text == null || num == null)
            {
                throw new ArgumentNullException("Cannot pass null text.");
            }
            // if text is just 0, dont add more
            else if (Text.Trim() == "0" && num == "0")
            {
                return Text;
            }
            // if its just 0 on the screen, replace it
            else if (Text.Trim() == "0" && num != "0")
            {
                Text = num;
                return Text;
            }
            //otherwise, just add the number
            else
            {
                Text += num;
                return Text;
            }
        }

        //TODO: fix this
        public static string DecimalButtonPress(string Text)
        {
            //if there is already a decimal, dont add another
            //only works for the setup we have now,
            //wont handle more than one number
            if(Text.Contains("."))
            {
                return Text;
            }
            else
            { 
                Text += ".";
                return Text;
            }
        }

        //just sets the string in the text box to 0,
        public static string ClearButtonPress(string Text)
        {
            Text = "0";
            return Text;
        }

        public static string arithmeticButonPress(string Text, string opr)
        {
            string operate = opr;

            switch (operate)
            {
                case "+":
                    return Text += "+";
                case "-":
                    return Text += "-";
                case "/":
                    return Text += "/";
                case "*":
                    return Text += "*";
                case "Sin":
                    if (Text == "0")
                    {
                        return Text = "Sin(";
                    }
                    else
                    {
                        return Text += "Sin(";
                    }
                case "Cos":
                    if (Text == "0")
                    {
                        return Text = "Cos(";
                    }
                    else
                    {
                        return Text += "Cos(";
                    }
                case "Tan":
                    if (Text == "0")
                    {
                        return Text = "Tan(";
                    }
                    else
                    {
                        return Text += "Tan(";
                    }
                case "Csc":
                    if (Text == "0")
                    {
                        return Text = "Csc(";
                    }
                    else
                    {
                        return Text += "Csc(";
                    }
                case "Sec":
                    if(Text == "0")
                    {
                        return Text = "Sec(";
                    }
                    else
                    {
                        return Text += "Sec(";
                    }
                case "Cot":
                    if(Text == "0")
                    {
                        return Text = "Cot(";
                    }
                    else
                    {
                        return Text += "Cot(";
                    }
                default:
                    throw new ArgumentException("argument passed is not in switch statement!");
            }

        }

    }
}
