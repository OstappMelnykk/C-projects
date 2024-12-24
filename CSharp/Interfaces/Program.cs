namespace Interfaces;

class Program
{
    static void Main(string[] args)
    {
        var device = new MultiFunctionDevice();

        // Cast to IPrinter to call IPrinter.Print
        IPrinter printer = device;
        printer.Print();

        // Cast to IScanner to call IScanner.Print
        IScanner scanner = device;
        scanner.Print();
        
        MultiFunctionDevice m = new MultiFunctionDevice();
        //m.Print(); // Error
        
        
        
        Calculator calc = new Calculator();

        // Call Add directly
        Console.WriteLine($"Sum: {calc.Add(3, 4)}");

        
        // Call Multiply via the class
        //Console.WriteLine($"Product: {calc.Multiply(3, 4)}");  //Error
        
        
        // Call Multiply via the interface
        IMathOperations mathOps = calc; // Cast to IMathOperations
        Console.WriteLine($"Product: {mathOps.Multiply(3, 4)}");
    }
}


public interface IPrinter
{
    public void Print();
}

public interface IScanner
{
    public void Print(); // Same method name as in IPrinter
}

public class MultiFunctionDevice : IPrinter, IScanner
{
    // Explicit implementation for IPrinter
    void IPrinter.Print()
    {
        Console.WriteLine("Printing document...");
    }

    // Explicit implementation for IScanner
    void IScanner.Print()
    {
        Console.WriteLine("Scanning document...");
    }
}

/// /////////////////////////////////////////////////////////////////////////////////////


public interface IMathOperations
{
    int Add(int a, int b);
    int Multiply(int a, int b);
}

public class Calculator : IMathOperations
{
    // Public method
    public int Add(int a, int b)
    {
        Console.WriteLine($"Adding {a} + {b}");
        return a + b;
    }

    // Explicit implementation for Multiply (hidden from class API)
    int IMathOperations.Multiply(int a, int b)
    {
        Console.WriteLine($"Multiplying {a} * {b}");
        return a * b;
    }
}



/*
    В C# інтерфейс може містити наступні компоненти:
        
    Методи (Methods)
    Властивості - (пара методів)*
    Індексатори - (сеціальні властивості)*
    Події - (вказівники на методи)*
    Статичні методи з реалізацією.
    
    C# 8.0+
        можна додавати реалізацію за замовчуванням до методів та властивостей
        Статичні властивості
        Константи (неявно статичні поля)*
    
    C# 11.0+
        Статичні поля
        Оператори
    
*/
public interface IExample
{
    // Методи
    void MethodWithoutImplementation();
    void MethodWithDefaultImplementation() => Console.WriteLine("Default implementation");

    // Властивості
    int PropertyWithoutImplementation { get; set; }
    int PropertyWithDefaultImplementation
    {
        get => 1000;
        set { }
    }
    
    // Індексатори
    string this[int index] { get; set; }

    // Події
    event Action OnEvent;

    // Статичний метод
    static void StaticMethod() => Console.WriteLine("Static method in interface");

    // Статична властивість
    static int StaticProperty { get; set; } = 10;

    // Константа
    const int ConstantValue = 100;

    // Статичне поле (C# 11.0+)
    static int StaticField = 20;

    // оператор (C# 11.0+)
    static abstract int operator +(IExample a, IExample b);
}
