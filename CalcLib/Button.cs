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
            if(Text != null && Text == "0")
            {
                Text = num;
                return Text;
            }
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

    }
}
