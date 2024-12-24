using System.Collections;

namespace StandardInterfaces;

public class Run_IComparable
{
    public static void main()
    {
        User user1 = new("1_Josef", 25);
        User user2 = new("2_Josef", 25);
        User user3 = new("Mark", 19);
        User user4 = new("Ostap", 34);
        User[] users = new User[] { user1,  user3, user4, user2, };
        
        Array.Sort(users);

        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name}, {user.Age}");
        }
    }
}

file class User: IComparable<User>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }

    
    // return -1, 0 or 1
    // compare by increasing age
    
    public int CompareTo(User? other)
    {
        int ageCompare = Age.CompareTo(other.Age);
        if (ageCompare == 0)
        {
            return Name.CompareTo(other.Name);
        }
        return ageCompare;
        
        /*
         
        if (Age == other.Age)
            return 0;  // if ages are equals u can compare by name: return Name.CompareTo(other.Name);          
        else if (Age < other.Age)
            return -1;
        else
            return 1;
            
        */
    }
}