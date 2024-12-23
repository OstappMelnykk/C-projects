namespace Interfaces;

class Program
{
    static void Main(string[] args)
    {
        
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
