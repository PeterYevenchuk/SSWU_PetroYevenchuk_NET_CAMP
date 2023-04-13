using System.Drawing;

namespace Home_Task_5_1;

public class Garden
{
    private List<Point> points;

    public Garden(List<Point> points)
    {
        this.points = points;
    }

    private double Distance(Point p1, Point p2)
    {
        double dx = p1.X - p2.X;
        double dy = p1.Y - p2.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    private bool IsRightTurn(Point p1, Point p2, Point p3)
    {
        double crossProduct = (p2.X - p1.X) * (p3.Y - p1.Y) - (p2.Y - p1.Y) * (p3.X - p1.X);
        return crossProduct < 0;
    }

    public double GetMinFenceLength()
    {
        // Find the lowest point (or the leftmost point in case of a tie)
        Point lowestPoint = points[0];
        for (int i = 1; i < points.Count; i++)
        {
            if (points[i].Y < lowestPoint.Y || (points[i].Y == lowestPoint.Y && points[i].X < lowestPoint.X))
            {
                lowestPoint = points[i];
            }
        }

        List<Point> sortedPoints = new List<Point>(points);
        sortedPoints.Sort(delegate (Point p1, Point p2)
        {
            double angle1 = Math.Atan2(p1.Y - lowestPoint.Y, p1.X - lowestPoint.X);
            double angle2 = Math.Atan2(p2.Y - lowestPoint.Y, p2.X - lowestPoint.X);
            if (angle1 < angle2)
            {
                return -1;
            }
            else if (angle1 > angle2)
            {
                return 1;
            }
            else
            {
                double distance1 = Distance(lowestPoint, p1);
                double distance2 = Distance(lowestPoint, p2);
                if (distance1 < distance2)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        });

        Stack<Point> hull = new Stack<Point>(); // Build the convex hull
        hull.Push(lowestPoint);
        hull.Push(sortedPoints[0]);
        hull.Push(sortedPoints[1]);
        for (int i = 2; i < sortedPoints.Count; i++)
        {
            Point top = hull.Pop();
            while (IsRightTurn(hull.Peek(), top, sortedPoints[i]))
            {
                top = hull.Pop();
            }
            hull.Push(top);
            hull.Push(sortedPoints[i]);
        }

        Point[] hullArray = hull.ToArray();
        double fenceLength = 0;
        for (int i = 0; i < hullArray.Length; i++)
        {
            int j = (i + 1) % hullArray.Length;
            fenceLength += Distance(hullArray[i], hullArray[j]); // Calculate the fence length
        }

        return fenceLength;
    }

    // Operator overloading to compare gardens by fence length
    public static bool operator <(Garden garden1, Garden garden2)
    {
        double fenceLength1 = garden1.GetMinFenceLength();
        double fenceLength2 = garden2.GetMinFenceLength();
        return fenceLength1 < fenceLength2;
    }

    public static bool operator >(Garden garden1, Garden garden2)
    {
        double fenceLength1 = garden1.GetMinFenceLength();
        double fenceLength2 = garden2.GetMinFenceLength();
        return fenceLength1 > fenceLength2;
    }

    public static bool operator <=(Garden garden1, Garden garden2)
    {
        double fenceLength1 = garden1.GetMinFenceLength();
        double fenceLength2 = garden2.GetMinFenceLength();
        return fenceLength1 <= fenceLength2;
    }

    public static bool operator >=(Garden garden1, Garden garden2)
    {
        double fenceLength1 = garden1.GetMinFenceLength();
        double fenceLength2 = garden2.GetMinFenceLength();
        return fenceLength1 >= fenceLength2;
    }
}
