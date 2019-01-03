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

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public string printPoint()
        {
            return ("(" + x + ", " + y + ")");
        }

        public bool equal(Point other)
        {
            return (this.y == other.y && this.x == other.x);
        }

    }
}
