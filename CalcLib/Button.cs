using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static string ZeroButtonPress(string Text)
        {
            //if there is just a 0, dont add more 0s
            if(Text != null && Text == "0")
            {
                return Text;
            }
            else
            {
                Text += "0";
                return Text;
            }
        }

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

    }
}
