
namespace _SystemObjectMethods;

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
        

        
        //User user1 = new("Josef", 25);
        //User user2 = new("Mark", 19);
        //User user3 = new("Mark", 19);
        //Console.WriteLine(user1.Equals(user2));
        //Console.WriteLine(user2.Equals(user3));
    }
}