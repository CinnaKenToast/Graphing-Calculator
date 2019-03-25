using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    interface IExpression
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

        abstract protected double evaluate(double left, double right);
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
        protected override double evaluate(double left, double right)
        {
            return left + right;
        }
    }

    class MinusExpression : BinaryExpression
    {
        protected override double evaluate(double left, double right)
        {
            return left - right;
        }
    }

    class MultiplyExpression : BinaryExpression
    {
        protected override double evaluate(double left, double right)
        {
            return left * right;
        }
    }

    class DivideExpression : BinaryExpression
    {
        protected override double evaluate(double left, double right)
        {
            return left / right;
        }
    }

    class ExpononetExpression : BinaryExpression
    {
        protected override double evaluate(double left, double right)
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
}
