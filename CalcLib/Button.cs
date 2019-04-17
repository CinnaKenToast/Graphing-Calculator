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
            else if (Text == "0" && num == "0")
            {
                return Text;
            }
            // if its just 0 on the screen, replace it
            else if (Text == "0" && num != "0")
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

        public static string DeleteButtonPress(string Text)
        {   
            //remove(start index, count)
            return Text.Remove(Text.Length -1 , 1);
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
                case "^":
                    return Text += "^";
                case "!":
                    return Text += "!";
                case ".":
                    return Text += ".";
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
                    if(Text == "0")
                    {
                        return Text = opr;
                    }
                    else
                    {
                        return Text += opr;
                    }
            }

        }

    }
}
