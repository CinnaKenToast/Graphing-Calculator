using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CalcLib;

public class MathParser
{
    
    #region Markers

    private const string NumberMarker = "#";
    private const string OperatorMarker = "$";
    private const string FunctionMarker = "@";

    #endregion
    #region Internal Tokens

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
    private const string Log = FunctionMarker + "log";
    private const string Sin = FunctionMarker + "sin";
    private const string Cos = FunctionMarker + "cos";
    private const string Tan = FunctionMarker + "tan";
    private const string Csc = FunctionMarker + "csc";
    private const string Sec = FunctionMarker + "sec";
    private const string Cot = FunctionMarker + "cot";
    #endregion
    #region Supported Operators
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
    #endregion
    #region Supported Fucntions
    private readonly Dictionary<string, string> supportedFunctions =
        new Dictionary<string, string>
        {
            { "sqrt", Sqrt },
            { "log", Log },
            { "sin", Sin },
            { "cos", Cos },
            { "tan", Tan },
            { "csc", Csc },
            { "sec", Sec },
            { "cot", Cot }
        };
    #endregion
    #region Supported Constants 
    private Dictionary<string, string> supportedConstants =
        new Dictionary<string, string>
        {
            { "pi", NumberMarker + Math.PI.ToString() },
            { "e", NumberMarker + Math.E.ToString() }
        };

    private readonly char decimalSeparator;
    private bool isRadians;
    #endregion

    public void addVariable(string variable, double value)
    {
        supportedConstants.Add(variable, NumberMarker + value);
    }

    public void changeVariable(string variable, double value)
    {
        supportedConstants[variable] = NumberMarker + value;
    }
    // Initializes new instance of MathParser (Decimal separator is retrieved from system settings)
    public MathParser()
	{
        try
        {
            decimalSeparator = char.Parse(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        }
        catch(FormatException ex)
        {
            throw new FormatException("Error: cannot read char decimal separator", ex);
        }
	}

    // Initializes new instance of MathParser
    public MathParser(char decimalSeparator)
    {
        this.decimalSeparator = decimalSeparator;
    }

    // Produces results of given math expression
    public double Parse(string expression, bool isRadians = true)
    {
        this.isRadians = isRadians;

        try
        {
            return Calculate(ConvertToRPN(FormatString(expression)));
        }
        catch(DivideByZeroException e)
        {
            throw e;
        }
        catch(FormatException e)
        {
            throw e;
        }
        catch(InvalidOperationException e)
        {
            throw e;
        }
        catch(ArgumentOutOfRangeException e)
        {
            throw e;
        }
        catch(ArgumentException e)
        {
            throw e;
        }
        catch(Exception e)
        {
            throw e;
        }
    }

    // Formats expression string to a string that can be read by the parser
    private string FormatString(string expression)
    {
        if(string.IsNullOrEmpty(expression))
        {
            throw new ArgumentNullException("Expression is null or empty");
        }

        StringBuilder formattedString = new StringBuilder();
        int balanceOfParen = 0;

        for (int i = 0; i < expression.Length; i++)
        {
            char ch = expression[i];

            if (ch == '(')
            {
                balanceOfParen++;
            }
            else if (ch == ')')
            {
                balanceOfParen--;
            }
            if (Char.IsWhiteSpace(ch))
            {
                continue;
            }
            else if (Char.IsUpper(ch))
            {
                formattedString.Append(Char.ToLower(ch));
            }
            else
            {
                formattedString.Append(ch);
            }
        }
        if(balanceOfParen != 0)
        {
            throw new FormatException("Parenthesises are not balanced");
        }
        return formattedString.ToString();
    }

// Converts to Reverse Polish Notation
    // Produces Reverse Polish Notation expression from Infix Notation expression
    private string ConvertToRPN(string expression)
    {
        int pos = 0;
        StringBuilder outputString = new StringBuilder();
        Stack<string> stack = new Stack<string>();

        // While there is unhandled char in expression
        while(pos < expression.Length)
        {
            string token = LexicalAnalysisInfixNotation(expression, ref pos);
            outputString = SyntaxAnalysisInfixNotation(token, outputString, stack);
        }

        // Pop all elements from stack to output string
        while(stack.Count > 0)
        {
            // There should be only operators
            if(stack.Peek()[0] == OperatorMarker[0])
            {
                outputString.Append(stack.Pop());
            }
            else
            {
                throw new FormatException("Format exception, there is funciton without parenthesis");
            }
        }
        return outputString.ToString();
    }

    // Produces token based on given expression
    private string LexicalAnalysisInfixNotation(string expression, ref int pos)
    {
        // Receive first char
        StringBuilder token = new StringBuilder();
        token.Append(expression[pos]);

        // If it is an operator
        if (supportedOperators.ContainsKey(token.ToString()))
        {
            // Determine it is unary or binary
            bool isUnary = pos == 0 || expression[pos - 1] == '(';
            pos++;

            switch (token.ToString())
            {
                case "+":
                    return isUnary ? UnaryMinus : Plus;
                case "-":
                    return isUnary ? UnaryMinus : Minus;
                default:
                    return supportedOperators[token.ToString()];
            }
        }
        else if (Char.IsLetter(token[0]) 
            || supportedFunctions.ContainsKey(token.ToString()) 
            || supportedConstants.ContainsKey(token.ToString()))
        {
            // Read function or constant name
            while (++pos < expression.Length && Char.IsLetter(expression[pos]))
            {
                token.Append(expression[pos]);
            }
            if (supportedFunctions.ContainsKey(token.ToString()))
            {
                return supportedFunctions[token.ToString()];
            }
            else if (supportedConstants.ContainsKey(token.ToString()))
            {
                return supportedConstants[token.ToString()];
            }
            else
            {
                throw new ArgumentException("Uknown token");
            }
        }
        else if(Char.IsDigit(token[0]) || token[0] == decimalSeparator)
        {
            // Read number
            // Read the whole part of number
            if (Char.IsDigit(token[0]))
            {
                while(++pos < expression.Length && Char.IsDigit(expression[pos]))
                {
                    token.Append(expression[pos]);
                }
            }
            else
            {
                // Because system decimal separator will be added below
                token.Clear();
            }
            // Read the fractional part of number
            if(pos < expression.Length && expression[pos] == decimalSeparator)
            {
                // Add current system specific decimal separator
                token.Append(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                while(++pos < expression.Length && Char.IsDigit(expression[pos]))
                {
                    token.Append(expression[pos]);
                }
            }
            // Read scienctific notation (suffix)
            if (pos + 1 < expression.Length && expression[pos] == 'e'
                && (Char.IsDigit(expression[pos + 1])
                    || (pos + 2 < expression.Length
                        && (expression[pos + 1] == '+'
                            || expression[pos + 1] == '-')
                        && Char.IsDigit(expression[pos + 2])))) 
            {
                token.Append(expression[pos++]); // e
                
                if(expression[pos] == '+' || expression[pos] == '-')
                {
                    token.Append(expression[pos++]); // sign
                }
                while(pos < expression.Length && Char.IsDigit(expression[pos]))
                {
                    token.Append(expression[pos++]); // power
                }
                // Convert number from scientific notation to decimal notation
                return NumberMarker + Convert.ToDouble(token.ToString());
            }

            return NumberMarker + token.ToString();
        }
        else
        {
            throw new ArgumentException("Unknown token is expressoin");
        }
    }

    // Syntax analysis of infix notation
    private StringBuilder SyntaxAnalysisInfixNotation(string token, StringBuilder outputString, Stack<string> stack)
    {
        // If it's a number put to string
        if (token[0] == NumberMarker[0])
        {
            outputString.Append(token);
        }
        else if (token[0] == FunctionMarker[0])
        {
            // If it's a function push to stack
            stack.Push(token);
        }
        else if (token == LeftParen)
        {
            // If it's '(' push to stack
            stack.Push(token);
        }
        else if (token == RightParen)
        {
            //If it's ')' pop elements from stack to output string until it finds the ')'
            string element;
            while ((element = stack.Pop()) != LeftParen)
            {
                outputString.Append(element);
            }
            // If after this a function is in the peek of stack then put it to string
            if (stack.Count > 0 && stack.Peek()[0] == FunctionMarker[0])
            {
                outputString.Append(stack.Pop());
            }
        }
        else
        {
            // While priority of elements at peek of stack >= (>) token's priority
            // put these elements to output string
            while (stack.Count > 0 && Priority(token, stack.Peek()))
            {
                outputString.Append(stack.Pop());
            }
            stack.Push(token);
        }
            return outputString;
    }
   

    // Determine which operator has higher priority
    private bool Priority(string token, string p)
    {
        return IsRightAssociated(token) ? 
            GetPriority(token) < GetPriority(p) :
            GetPriority(token) <= GetPriority(p);
    }

    // Checks if operator is right priority
    private bool IsRightAssociated(string token)
    {
        return token == Exponent;
    }

    // Gets priority of operator
    private int GetPriority(string token)
    {
        switch (token)
        {
            case LeftParen:
                return 0;
            case Plus:
            case Minus:
                return 2;
            case UnaryPlus:
            case UnaryMinus:
                return 6;
            case Multiply:
            case Divide:
                return 4;
            case Exponent:
            case Sqrt:
                return 8;
            case Log:
            case Sin:
            case Cos:
            case Tan:
            case Csc:
            case Sec:
            case Cot:
                return 10;
            default:
                throw new ArgumentException("Unknown operator");
        }
    }

// Calculates Reverse Polish Notation Expression
    // Calculates Expression
    private double Calculate(string expression)
    {
        int pos = 0; // Current position of lexical analysis
        var stack = new Stack<double>();

        // Analyse entire expression
        while(pos < expression.Length)
        {
            string token = LexicalAnalysisRPN(expression, ref pos);

            stack = SyntaxAnalysisRPN(stack, token);
        }

        if(stack.Count > 1)
        {
            throw new ArgumentException("Excess operand");
        }

        return stack.Pop();
    }

    // Produces tokem by the given math expression
    private string LexicalAnalysisRPN(string expression, ref int pos)
    {
        StringBuilder token = new StringBuilder();
        // Read token from marker to next marker
        token.Append(expression[pos++]);

        while (pos < expression.Length && expression[pos] != NumberMarker[0]
            && expression[pos] != OperatorMarker[0]
            && expression[pos] != FunctionMarker[0])
        {
            token.Append(expression[pos++]);
        }

        return token.ToString();
    }

    // Syntax analysis of reverse polish notation expression
    private Stack<double> SyntaxAnalysisRPN(Stack<double> stack, string token)
    {   
        // if it's operand then just push to stack
        if(token[0] == NumberMarker[0])
        {
            stack.Push(double.Parse(token.Remove(0, 1)));
        }

        // otherwise apply operator or funtion to elements in stack
        else if(NumberOfArguments(token) == 1)
        {
            double argument = stack.Pop();
            NumExpression arg = new NumExpression(argument);
            if (!isRadians)
            {
                argument = argument * Math.PI / 180; // Convert value to degree
            }
            NumExpression trigArg = new NumExpression(argument);
            double result;

            switch (token)
            {
                case UnaryPlus:
                    result = arg.evaluate();
                    break;
                case UnaryMinus:
                    NegateExpresion neg = new NegateExpresion(arg);
                    result = neg.evaluate();
                    break;
                case Sqrt:
                    SqrtExpression sqrt = new SqrtExpression(arg);
                    result = sqrt.evaluate();
                    break;
                case Log:
                    result = Math.Log(argument, 10);
                    break;
                case Sin:
                    SinExpression sin = new SinExpression(trigArg);
                    result = sin.evaluate();
                    break;
                case Cos:
                    CosExpression cos = new CosExpression(trigArg);
                    result = cos.evaluate();
                    break;
                case Tan:
                    TanExpression tan = new TanExpression(trigArg);
                    result = tan.evaluate();
                    break;
                case Csc:
                    CscExpression csc = new CscExpression(trigArg);
                    result = csc.evaluate();
                    break;
                case Sec:
                    SecExpression sec = new SecExpression(trigArg);
                    result = sec.evaluate();
                    break;
                case Cot:
                    CotExpression cot = new CotExpression(trigArg);
                    result = cot.evaluate();
                    break;
                default:
                    throw new ArgumentException("Unknown operator");
            }
            stack.Push(result);
        }
        else
        {
            // otherwise operator's number of arguments equal to 2
            double argument2 = stack.Pop();
            double argument1 = stack.Pop();
            NumExpression arg1 = new NumExpression(argument1);
            NumExpression arg2 = new NumExpression(argument2);
            double result;

            switch (token)
            {
                case Plus:
                    AdditionExpression add = new AdditionExpression(arg1, arg2);
                    result = add.evaluate();
                    break;
                case Minus:
                    MinusExpression minus = new MinusExpression(arg1, arg2);
                    result = minus.evaluate();
                    break;
                case Multiply:
                    MultiplyExpression multiply = new MultiplyExpression(arg1, arg2);
                    result = multiply.evaluate();
                    break;
                case Divide:
                    if (argument2 == 0)
                    {
                        throw new DivideByZeroException("Second argument is zero");
                    }
                    DivideExpression divide = new DivideExpression(arg1, arg2);
                    result = divide.evaluate();
                    break;
                case Exponent:
                    ExpononetExpression exp = new ExpononetExpression(arg1, arg2);
                    result = exp.evaluate();
                    break;
                default: throw new ArgumentException("Unknown operator");
            }
            stack.Push(result);
        }
        return stack;
    }

    // Applies trig function to an argument
    private double ApplyTrigFunction(Func<double, double> func, double argument)
    {
        if (!isRadians)
        {
            argument = argument * Math.PI / 180; // Convert value to degree
        }
        return func(argument);
    }

    // Determines number of arguments for an operator
    private int NumberOfArguments(string token)
    {
        switch (token)
        {
            case UnaryPlus:
            case UnaryMinus:
            case Sqrt:
            case Log:
            case Sin:
            case Cos:
            case Tan:
            case Csc:
            case Sec:
            case Cot:
                return 1;
            case Plus:
            case Minus:
            case Multiply:
            case Divide:
            case Exponent:
                return 2;
            default:
                throw new ArgumentException("Unknown operator");
        }
    }
}
