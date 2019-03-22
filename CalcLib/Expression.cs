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
}
