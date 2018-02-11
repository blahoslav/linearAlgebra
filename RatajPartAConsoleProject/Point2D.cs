using System;
using System.Collections.Generic;
using System.Text;

namespace RatajPartAConsoleProject
{
    public class Point2D
    {
        public int X;
        public int Y;
        public double distanceToOrigin;

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

    

        public double CalculateDistanceBetweenMeAndAnotherPoint2DInstance(Point2D anotherPoint)
        {
            double distanceBetweenTwoPoints = Math.Sqrt((Math.Pow((anotherPoint.X - X), 2) + Math.Pow((anotherPoint.Y - Y),2)));
            return distanceBetweenTwoPoints;
        }



    }

   


}
