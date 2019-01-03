using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.BusinessLayer
{
    public class Point
    {
        public int x;
        public int y;

        /// <summary>
        /// The function define a point -> (x,y)
        /// with the given x and y.
        /// </summary>
        /// <param name="x">x axis value</param>
        /// <param name="y">y axis value</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// The function returns a printable
        /// vertion of the current point
        /// </summary>
        /// <returns>the point as a string</returns>
        public string printPoint()
        {
            return ("(" + x + ", " + y + ")");
        }

        /// <summary>
        /// The function returns true if the other point ("other")
        /// equals to the current point, and false otherwise.
        /// </summary>
        /// <param name="other">the other point</param>
        /// <returns>true or false</returns>
        public bool equal(Point other)
        {
            return (this.y == other.y && this.x == other.x);
        }

    }
}