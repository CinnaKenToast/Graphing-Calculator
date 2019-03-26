using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    public interface IExpression
    {
        double evaluate();
    }

    
    abstract class BinaryExpression : IExpression
    {
        private IExpression left;
        private IExpression right;

        public BinaryExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public double evaluate()
        {
           return evaluate(left.evaluate(), right.evaluate());
        }

        abstract public double evaluate(double left, double right);
    }

    class NumExression : IExpression
    {
        private double number;

        public NumExression(double number)
        {
            this.number = number;
        }

        public double evaluate()
        {
            return (double)number;
        }
    }

    class AdditionExpression : BinaryExpression
    {
        public AdditionExpression(IExpression left, IExpression right) : base(left, right)
        {
        }

        public override double evaluate(double left, double right)
        {
            return left + right;
        }
    }

    class MinusExpression : BinaryExpression
    {
        public MinusExpression(IExpression left, IExpression right) : base(left, right)
        {
        }

        public override double evaluate(double left, double right)
        {
            return left - right;
        }
    }

    class MultiplyExpression : BinaryExpression
    {
        public MultiplyExpression(IExpression left, IExpression right) : base(left, right)
        {
        }

        public override double evaluate(double left, double right)
        {
            return left * right;
        }
    }

    class DivideExpression : BinaryExpression
    {
        public DivideExpression(IExpression left, IExpression right) : base(left, right)
        {
        }

        public override double evaluate(double left, double right)
        {
            return left / right;
        }
    }

    class ExpononetExpression : BinaryExpression
    {
        public ExpononetExpression(IExpression left, IExpression right) : base(left, right)
        {
        }

        public override double evaluate(double left, double right)
        {
            return Math.Pow(left,right);
        }
    }

    class LogarithmExpression : IExpression
    {
        private IExpression operand;

        public LogarithmExpression(IExpression operand)
        {
            this.operand = operand;
        }

        public double evaluate()
        {
            return Math.Log10(operand.evaluate());
        }
    }

    class NegateExpresion : IExpression
    {
        private IExpression operand;
        public NegateExpresion(IExpression operand)
        {
            this.operand = operand;
        }

        public double evaluate()
        {
            return -operand.evaluate();
        }
    }

    class FactorialExpresion : IExpression
    {
        private double operand;
        public FactorialExpresion(int operand)
        {
            this.operand = operand;
        }

        public double evaluate()
        {
            double ans = 1;
            for(double i = operand; i > 1; i--)
            {
                ans = ans * i;
            }
            return ans;
        }
    }
    
    class SinExpression: IExpression
    {
        private double operand;

        public SinExpression(double operand)
        {
            this.operand = operand;
        }

        public double evaluate()
        {
            return Math.Sin(operand);
        }
    }

    class CosExpression : IExpression
    {
        private double operand;

        public CosExpression(double operand)
        {
            this.operand = operand;
        }

        public double evaluate()
        {
            return Math.Cos(operand);
        }
    }

    class TanExpression : IExpression
    {
        private double operand;

        public TanExpression(double operand)
        {
            this.operand = operand;
        }

        public double evaluate()
        {
            return Math.Tan(operand);
        }
    }

    class CotExpression : IExpression
    {
        private double operand;

        public CotExpression(double operand)
        {
            this.operand = operand;
        }
        public double evaluate()
        {
            return 1 / Math.Tan(operand);
        }
    }

    class CscExpression : IExpression
    {
        private double operand;

        public CscExpression(double operand)
        {
            this.operand = operand;
        }
        public double evaluate()
        {
            return 1 / Math.Sin(operand);
        }
    }
    class SecExpression : IExpression
    {
        private double operand;

        public SecExpression(double operand)
        {
            this.operand = operand;
        }
        public double evaluate()
        {
            return 1 / Math.Cos(operand);
        }
    }
}
