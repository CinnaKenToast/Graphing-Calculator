using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CalcLib
{
    class Graph
    {
        private IExpression equation;
        private double xUpperBound;
        private double xLowerBound;
        private double yUpperBound;
        private double yLowerBound;
        private int Zoom;
        private bool Axis;
        int NumFunctions;
        private MathParser parser;

        public Graph()
        {
            xUpperBound = 10;
            xLowerBound = -10;
            yUpperBound = 10;
            yLowerBound = -10;
            Zoom = 1;
            Axis = true;
            parser.addVariable("x", 1); // 1 will be default value of x
            NumFunctions = 0;
        }

        public void changeZoom(int zoom)
        {
            Zoom = zoom;
        }

        public void changeXBounds(int lower, int upper)
        {
            xLowerBound = lower;
            xUpperBound = upper;
        }

        public void changeYBounds(int lower, int upper)
        {
            yLowerBound = lower;
            yUpperBound = upper;
        }

        public void showHideAxis()
        {
            if(Axis == true)
            {
                Axis = false;
            }
            else
            {
                Axis = true;
            }
        }

        public void CreateFucntion(string Expression)
        {
            NumFunctions++;
            string fileName = "function" + NumFunctions + ".data";
            StreamWriter sw = new StreamWriter(fileName);

            double numPoints = 1000;
            double resolution = 1/numPoints;
            double y;
            sw.WriteLine(numPoints);
            for (double x = xLowerBound; x <= xUpperBound; x += resolution)
            {
                parser.changeVariable("x", x);
                y = parser.Parse(Expression);
                sw.WriteLine(x + " " + y);
            }
        }

        public void plot()
        {
            string fileName = "function" + NumFunctions + ".data";
            StreamReader file = new StreamReader(fileName);

        }
    }
}