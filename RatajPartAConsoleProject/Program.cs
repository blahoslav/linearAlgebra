using System;

namespace RatajPartAConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.WriteLine("Blahoslav Rataj - Graduate Programming Test - Part A");
            Console.WriteLine("Question 1");
            Point2D firstPoint = new Point2D(5, -1);
            double distanceBetweenFirstPointAndNewPoint = firstPoint.CalculateDistanceBetweenMeAndAnotherPoint2DInstance(new Point2D(2, 3));
            Console.WriteLine("Distance between the first point (5, -1) and a newly defined point (2, 3): " + Convert.ToString(Math.Round(distanceBetweenFirstPointAndNewPoint, 2)));
            Console.WriteLine();

            Console.WriteLine("Question 2");
            Point2D origin = new Point2D(0, 0);
            Point2D secondPoint = new Point2D(random.Next(-10, 10), random.Next(-10, 10));
            Point2D thirdPoint = new Point2D(random.Next(-10, 10), random.Next(-10, 10));
            Point2D fourthPoint = new Point2D(random.Next(-10, 10), random.Next(-10, 10));
            Point2D fifthPoint = new Point2D(random.Next(-10, 10), random.Next(-10, 10));
            Point2D[] randomlyGeneratedPointsInSpace = { secondPoint, thirdPoint, fourthPoint, fifthPoint };
            Sorter pointSorter = new Sorter();
            Point2D[] sortedPointsByDistanceFromOrigin = pointSorter.SortArrayOfPointsByDistanceFromOrigin(randomlyGeneratedPointsInSpace, origin);
            Console.WriteLine("Sorted points:");
            foreach (var singlePoint in sortedPointsByDistanceFromOrigin)
            {
                Console.WriteLine("x: " + singlePoint.X + " y: " + singlePoint.Y + " distance: " + Math.Round(singlePoint.distanceToOrigin), 2);
            }
            Console.WriteLine("");


            Console.WriteLine("Question 3");
            Analyzer analyzer = new Analyzer();
            string orientationBetweenPoints = analyzer.FindOrientationOfThreePoints(secondPoint, thirdPoint, fourthPoint);
          
            Console.WriteLine("First point " + secondPoint.X + "," + secondPoint.Y + " Second point " + thirdPoint.X + "," + thirdPoint.Y + " Third point " + fourthPoint.X + "," + fourthPoint.Y + " --> orientation: " + orientationBetweenPoints);
            Console.WriteLine();

            Console.WriteLine("Question 4");
            firstPoint.X = random.Next(-10, 10);
            firstPoint.Y = random.Next(-10, 10);
            Console.WriteLine("First line segment: " + " First point " + "[" + firstPoint.X + "," + firstPoint.Y + "]" + " Second point " + "[" + secondPoint.X + "," + secondPoint.Y + "]");
            Console.WriteLine("Second line segment: " + " First point " + "[" + thirdPoint.X + "," + thirdPoint.Y + "]" + " Second point " + "[" + fourthPoint.X + "," + fourthPoint.Y + "]");
            string[] lineSegmentOrientations = new string[2];
            lineSegmentOrientations[0] = analyzer.FindOrientationOfThreePoints(firstPoint, secondPoint, thirdPoint);
            lineSegmentOrientations[1] = analyzer.FindOrientationOfThreePoints(firstPoint, secondPoint, fourthPoint);
            bool areOrientationsDifferentinFirstCase = (lineSegmentOrientations[0] != lineSegmentOrientations[1]) ? true : false;
            bool allOrientationsCollinearFirstCase = (lineSegmentOrientations[0] == "collinear" && lineSegmentOrientations[1] == "collinear") ? true : false;
            lineSegmentOrientations[0] = analyzer.FindOrientationOfThreePoints(thirdPoint, fourthPoint, firstPoint);
            lineSegmentOrientations[1] = analyzer.FindOrientationOfThreePoints(thirdPoint, fourthPoint, secondPoint);
            bool areOrientationsDifferentinSecondCase = (lineSegmentOrientations[0] != lineSegmentOrientations[1]) ? true : false;
            bool allOrientationsCollinearSecondCase = (lineSegmentOrientations[0] == "collinear" && lineSegmentOrientations[1] == "collinear") ? true : false;
            bool doTwoLineSegmentsIntersect = false;
            if (allOrientationsCollinearFirstCase == true && allOrientationsCollinearSecondCase == true && secondPoint.X >= thirdPoint.X && secondPoint.Y >= thirdPoint.Y)
            {
                doTwoLineSegmentsIntersect = true;
            }
            else
            {
                doTwoLineSegmentsIntersect = (areOrientationsDifferentinFirstCase == true && areOrientationsDifferentinSecondCase == true) ? true : false;
            }
            Console.WriteLine("Statement that two line segments intersect is " + doTwoLineSegmentsIntersect);

            Console.WriteLine("Question 5");
            Point2D[] square = { new Point2D(0, 0), new Point2D(0, 5), new Point2D(5, 0), new Point2D(5, 5) };
            Point2D randomPoint = new Point2D(random.Next(-5,5), random.Next(-5, 5));
            Point2D pointOutOfSquare = new Point2D(10, randomPoint.Y);
            int numberOfIntersections = 0;
            int counter = 0;
            while (counter <= 2)
            {
                lineSegmentOrientations[0] = analyzer.FindOrientationOfThreePoints(square[counter], square[counter + 1], randomPoint);
                lineSegmentOrientations[1] = analyzer.FindOrientationOfThreePoints(square[counter], square[counter + 1], pointOutOfSquare);
                areOrientationsDifferentinFirstCase = (lineSegmentOrientations[0] != lineSegmentOrientations[1]) ? true : false;
                lineSegmentOrientations[0] = analyzer.FindOrientationOfThreePoints(randomPoint, pointOutOfSquare, square[counter]);
                lineSegmentOrientations[1] = analyzer.FindOrientationOfThreePoints(randomPoint, pointOutOfSquare, square[counter + 1]);
                areOrientationsDifferentinSecondCase = (lineSegmentOrientations[0] != lineSegmentOrientations[1]) ? true : false;
                doTwoLineSegmentsIntersect = (areOrientationsDifferentinFirstCase == true && areOrientationsDifferentinSecondCase == true) ? true : false;
                if (doTwoLineSegmentsIntersect == true)
                {
                    numberOfIntersections++;
                }
                counter += 2;
            }
            bool isPointInsideSquare = (numberOfIntersections == 1) ? true : false;
            Console.WriteLine("Given square " + "[" + square[0].X + "," + square[0].Y + "] " + "[" + square[1].X + "," + square[1].Y + "] " + "[" + square[2].X + "," + square[2].Y + "] " + "[" + square[3].X + "," + square[3].Y + "] ");
            if (isPointInsideSquare == true)
            {
                Console.WriteLine("the randomly generated point [" + randomPoint.X + "," + randomPoint.Y + "]" + " is inside the square.");
            }
            else
            {
                Console.WriteLine("the randomly generated point [" + randomPoint.X + "," + randomPoint.Y + "]" + " is not inside the square.");
            }
            Console.ReadLine();
        }
       

    }
}
