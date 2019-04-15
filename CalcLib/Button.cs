using System;


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

        public static string DecimalButtonPress(string Text)
        {
            return Text += ".";
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
                case "sin":
                    if (Text == "0")
                    {
                        return Text = "sin(";
                    }
                    else
                    {
                        return Text += "sin(";
                    }
                case "cos":
                    if (Text == "0")
                    {
                        return Text = "cos(";
                    }
                    else
                    {
                        return Text += "cos(";
                    }
                case "tan":
                    if (Text == "0")
                    {
                        return Text = "tan(";
                    }
                    else
                    {
                        return Text += "tan(";
                    }
                case "csc":
                    if (Text == "0")
                    {
                        return Text = "csc(";
                    }
                    else
                    {
                        return Text += "csc(";
                    }
                case "sec":
                    if(Text == "0")
                    {
                        return Text = "sec(";
                    }
                    else
                    {
                        return Text += "sec(";
                    }
                case "cot":
                    if(Text == "0")
                    {
                        return Text = "cot(";
                    }
                    else
                    {
                        return Text += "cot(";
                    }
                case "(":
                    return Text += "(";
                case ")":
                    return Text += ")";
                case "^":
                    return Text += "^";
                case "mod(":
                    if(Text == "0")
                    {
                        return Text = "mod(";
                    }
                    else
                    {
                        return Text += "mod(";
                    }
                case "log(":
                    if (Text == "0")
                    {
                        return Text = "log(";
                    }
                    else
                    {
                        return Text += "log(";
                    }
                case "ln(":
                    if (Text == "0")
                    {
                        return Text = "ln(";
                    }
                    else
                    {
                        return Text += "ln(";
                    }
                case "!":
                    return Text += "!";
                case "sqrt(":
                    if (Text == "0")
                    {
                        return Text = "sqrt(";
                    }
                    else
                    {
                        return Text += "sqrt(";

                    }
                case "(+/-)":
                    if(Text.StartsWith("-"))
                    {
                        return Text.Remove(0, 1);
                    }
                    else
                    {
                        return Text.Insert(0, "-");
                    }
                default:
                    throw new ArgumentException("argument passed is not in switch statement!");
            }

        }

    }
}
