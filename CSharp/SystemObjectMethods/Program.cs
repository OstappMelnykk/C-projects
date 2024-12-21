using System.Reflection;

namespace SystemObjectMethods;

class Program
{
    static void Main(string[] args)
    {
        Type type = typeof(System.Object);

        // Отримуємо всі методи типу
        
        //MethodInfo[] methods = type.GetMethods();

        // Виводимо всі методи
        foreach (var method in type.GetMethods())
        {
            Console.WriteLine($"{method.Name} - {method.ReturnType.Name}");
        }
        
        /*

            GetType - Type
            ToString - String
            Equals - Boolean
            Equals - Boolean
            ReferenceEquals - Boolean
            GetHashCode - Int32

        */
        

    }
}