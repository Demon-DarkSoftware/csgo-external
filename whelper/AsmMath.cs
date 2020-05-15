using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whelper
{
    public static class AsmMath
    {
        public static double DistanceBetween(Position p1, Position p2) {
            double res = Math.Sqrt(
                (Math.Pow((p2.X - p1.X), 2) + 
                Math.Pow((p2.Y - p1.Y), 2) + 
                Math.Pow((p2.Z - p1.Z), 2)));
            return res;
        }
       
    }
}
