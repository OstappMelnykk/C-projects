namespace ExtentionMethods;

class Program
{
    static void Main(string[] args)
    {
        MyPoint point1 = new MyPoint(10, 10, 10);
        MyPoint point2 = new MyPoint(20, 20, 20);
        double distanceToCenter = point1.DistanceFromPointToCenterOfCoordinates();
        Console.WriteLine($"Distance from point1 to the origin: {distanceToCenter}");

        // Використовуємо метод розширення для обчислення відстані між двома точками
        double distanceBetweenPoints = point1.DistanceBetween2Points(point2);
        Console.WriteLine($"Distance between point1 and point2: {distanceBetweenPoints}");

        // Використовуємо метод розширення для рядка
        string fullName = "John Doe";
        string initials = fullName.MakeInitials(1);
        Console.WriteLine($"Initials: {initials}");
    }
}


public sealed class MyPoint
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public MyPoint()
    {
        X = Y = Z = 0;
    }
    
    public MyPoint(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}




public static class MyPointExtemtionClass
{
    public static double DistanceFromPointToCenterOfCoordinates(this MyPoint point)
    {
        return System.Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2) + Math.Pow(point.Z, 2));
    }
    public static double DistanceBetween2Points(this MyPoint point, MyPoint otherPoint)
    {
        double xDistance = Math.Abs(point.X - otherPoint.X);
        double yDistance = Math.Abs(point.Y - otherPoint.Y);
        double zDistance = Math.Abs(point.Z - otherPoint.Z);
        
        return System.Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2) + Math.Pow(zDistance, 2));
    }
    
}





public static class StringExtensionClass
{
    //робить ініціали перертворюючи імя і прізвище
    public static string MakeInitials(this string str, int id)
    {
        if (string.IsNullOrWhiteSpace(str))
            return string.Empty;

        string[] words = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
            words[i] = words[i][0].ToString().ToUpper();
        return id + " - " + string.Join(".", words) + ".";
    }
}