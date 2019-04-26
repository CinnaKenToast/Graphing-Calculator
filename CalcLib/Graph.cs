using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
namespace CalcLib
{
    public class Graph
    {
        private double xUpperBound;
        private double xLowerBound;
        private double yUpperBound;
        private double yLowerBound;
        private double numPoints;
        private double resolution;
        private MathParser parser;

        public Graph()
        {
            xUpperBound = 10;
            xLowerBound = -10;
            yUpperBound = 10;
            yLowerBound = -10;
            parser = new MathParser();
            numPoints = 10;
            resolution = 1 / numPoints;
        }

        public double getXLowerBound()
        {
            return xLowerBound;
        }
        public double getXUpperBound()
        {
            return xUpperBound;
        }
        public double getYLowerBound()
        {
            return yLowerBound;
        }
        public double getYUpperBound()
        {
            return yUpperBound;
        }
        public double getResoltuion()
        {
            return resolution;
        }
        public double getY(string Expression, double x)
        {
            double y;
            parser.changeVariable("x", x);
            y = parser.Parse(Expression);

            PointF point = new PointF();
            point.X = (float)x;
            point.Y = (float)y;

            return y;

        }
    }
}