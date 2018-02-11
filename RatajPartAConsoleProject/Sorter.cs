using System;
using System.Collections.Generic;
using System.Text;

namespace RatajPartAConsoleProject
{
    public class Sorter
    {
        public Point2D[] SortArrayOfPointsByDistanceFromOrigin(Point2D[] arrayOfPoints, Point2D originPoint)
        {
            for (int i = 0; i < arrayOfPoints.Length; i++)
            {
                arrayOfPoints[i].distanceToOrigin = arrayOfPoints[i].CalculateDistanceBetweenMeAndAnotherPoint2DInstance(originPoint);
            }

            // Implementation of the insertion sort algorithm
            for (int k = 0; k < arrayOfPoints.Length - 1; k++)
            {
                int s = k + 1;
                Point2D pointSorted = arrayOfPoints[s];
                while (s > 0 && pointSorted.distanceToOrigin > arrayOfPoints[s - 1].distanceToOrigin)
                {
                    arrayOfPoints[s] = arrayOfPoints[s - 1];

                    s--;
                }
                arrayOfPoints[s] = pointSorted;
            }
            return arrayOfPoints;
        }
    }
}
