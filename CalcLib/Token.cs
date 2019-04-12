using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    class Token
    {
        // Markers
        private const string NumberMarker = "#";
        private const string OperatorMarker = "$";
        private const string FunctionMarker = "@";

        // Internal Token
        private const string Plus = OperatorMarker + "+";
        private const string UnaryPlus = OperatorMarker + "Un+";
        private const string Minus = OperatorMarker + "-";
        private const string UnaryMinus = OperatorMarker + "Un-";
        private const string Multiply = OperatorMarker + "*";
        private const string Divide = OperatorMarker + "/";
        private const string Exponent = OperatorMarker + "^";
        private const string LeftParen = OperatorMarker + "(";
        private const string RightParen = OperatorMarker + ")";
        private const string Sqrt = FunctionMarker + "sqrt";
        private const string Sin = FunctionMarker + "sin";
        private const string Cos = FunctionMarker + "cos";
        private const string Tan = FunctionMarker + "tan";
        private const string Csc = FunctionMarker + "csc";
        private const string Sec = FunctionMarker + "sec";
        private const string Cot = FunctionMarker + "cot";
        private const string Log = FunctionMarker + "log";

        // Supported Operators
        private readonly Dictionary<string, string> supportedOperators =
        new Dictionary<string, string>
        {
            { "+", Plus },
            { "-", Minus },
            { "*", Multiply },
            { "/", Divide },
            { "^", Exponent },
            { "(", LeftParen },
            { ")", RightParen }
        };

        // Supported Functions
        private readonly Dictionary<string, string> supportedFunctions =
        new Dictionary<string, string>
        {
            { "sqrt", Sqrt },
            { "sin", Sin },
            { "cos", Cos },
            { "tan", Tan },
            { "csc", Csc },
            { "sec", Sec },
            { "cot", Cot },
            { "log", Log }
        };

        private readonly Dictionary<string, string> supportedConstants =
        new Dictionary<string, string>
        {
            { "pi", NumberMarker + Math.PI.ToString() },
            { "e", NumberMarker + Math.E.ToString() }
        };
        


    }
}
