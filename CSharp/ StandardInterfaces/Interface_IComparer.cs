namespace StandardInterfaces;



public class Run_IComparer
{
    public static void main()
    {
        User user1 = new("1_Josef", 25);
        User user2 = new("2_Josef", 25);
        User user3 = new("Mark", 19);
        User user4 = new("Ostap", 34);
        User[] users = new User[] { user1,  user3, user4, user2, };
        
        Array.Sort(users, new AgeAndNumberComparer());

        foreach (var user in users)
        {
            Console.WriteLine($"{user.Name}, {user.Age}");
        }
    }
}

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }

}

public class AgeAndNumberComparer : IComparer<User>
{
    public int Compare(User x, User y)
    {
        if (x.Age == y.Age)
            return 0;  // if ages are equals u can compare by name: return Name.CompareTo(other.Name);          
        else if (x.Age < y.Age)
            return -1;
        else
            return 1;
    }
}
