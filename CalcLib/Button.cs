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


    }
}
