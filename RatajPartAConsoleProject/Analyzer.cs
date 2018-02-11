using System;
using System.Collections.Generic;
using System.Text;

namespace RatajPartAConsoleProject
{
    public class Analyzer
    {


        public string FindOrientationOfThreePoints(Point2D firstPoint, Point2D secondPoint, Point2D thirdPoint)
        {
            double twiceSignedArea = CalculateTwiceSignedArea(firstPoint, secondPoint, thirdPoint);
            string orientationOfThreePoints = "";
            if(twiceSignedArea == 0)
            {
                orientationOfThreePoints = "collinear";
                return orientationOfThreePoints;
            }
            else if (twiceSignedArea > 0)
            {
                orientationOfThreePoints = "Anti-Clockwise Turn";
                return orientationOfThreePoints;
            }
            else 
            {
                orientationOfThreePoints = "Clockwise Turn";
                return orientationOfThreePoints;
            }


        }

        private double CalculateTwiceSignedArea(Point2D firstPoint, Point2D secondPoint, Point2D thirdPoint)
        {

            double twiceSignedArea = ((secondPoint.X - firstPoint.X) * (thirdPoint.Y - firstPoint.Y)) - ((secondPoint.Y - firstPoint.Y) * (thirdPoint.X - firstPoint.X));
            return twiceSignedArea;
        }



    }
}
