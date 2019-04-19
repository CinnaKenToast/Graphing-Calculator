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

    class NumExpression : IExpression
    {
        private double number;

        public NumExpression(double number)
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
        private IExpression operand;
        public FactorialExpresion(IExpression operand)
        {
            this.operand = operand;
        }

        public double evaluate()
        {
            double ans = 1;
            for(double i = operand.evaluate(); i > 1; i--)
            {
                ans = ans * i;
            }
            return ans;
        }
    }
    
    class SinExpression: IExpression
    {
        private IExpression operand;

        public SinExpression(IExpression operand)
        {
            this.operand = operand;
        }

        public double evaluate()
        {
            return Math.Sin(operand.evaluate());
        }
    }

    class CosExpression : IExpression
    {
        private IExpression operand;

        public CosExpression(IExpression operand)
        {
            this.operand = operand;
        }

        public double evaluate()
        {
            return Math.Cos(operand.evaluate());
        }
    }

    class TanExpression : IExpression
    {
        private IExpression operand;

        public TanExpression(IExpression operand)
        {
            this.operand = operand;
        }

        public double evaluate()
        {
            return Math.Tan(operand.evaluate());
        }
    }

    class CotExpression : IExpression
    {
        private IExpression operand;

        public CotExpression(IExpression operand)
        {
            this.operand = operand;
        }
        public double evaluate()
        {
            return 1 / Math.Tan(operand.evaluate());
        }
    }

    class CscExpression : IExpression
    {
        private IExpression operand;

        public CscExpression(IExpression operand)
        {
            this.operand = operand;
        }
        public double evaluate()
        {
            return 1 / Math.Sin(operand.evaluate());
        }
    }
    class SecExpression : IExpression
    {
        private IExpression operand;

        public SecExpression(IExpression operand)
        {
            this.operand = operand;
        }
        public double evaluate()
        {
            return 1 / Math.Cos(operand.evaluate());
        }
    }
    class SqrtExpression : IExpression
    {
        private IExpression operand;

        public SqrtExpression(IExpression operand)
        {
            this.operand = operand;
        }
        public double evaluate()
        {
            return Math.Sqrt(operand.evaluate());
        }
    }
}
