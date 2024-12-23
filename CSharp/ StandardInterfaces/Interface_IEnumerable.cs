using System.Collections;

namespace StandardInterfaces;
public class Run_IEnumerable
{
    public static void main()
    {
        User user1 = new("Josef", 25);
        User user2 = new("mark", 19);
        UsersStorage usersStorage = new(new []{user1, user2});
        
        
        /////////////////////////////////////////////////////////////////////////////////////////
        foreach (var user in usersStorage)
        {
            Console.WriteLine((user as User).Name);
        }

        Console.WriteLine();
        /////////////////////////////////////////////////////////////////////////////////////////
        // equivalent record. the foreach loop wraps itself into
        // this construct under the hood. check Low-level c# code
        
        IEnumerator usersEnumerator = usersStorage.GetEnumerator();
        while (usersEnumerator.MoveNext())
            Console.WriteLine((usersEnumerator.Current as User).Name);
        
        /////////////////////////////////////////////////////////////////////////////////////////
        Console.WriteLine();

        
        
        
        
        //Low-level c# code:
        /////////////////////////////////////////////////////////////////////////////////////////
        //Low-level c# code:
        IEnumerator enumerator = new UsersStorage(new User[2]
        {
            new User("Josef", 25),
            new User("mark", 19)
        }).GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
                Console.WriteLine((enumerator.Current as User).Name);
        }
        finally
        {
            if (enumerator is IDisposable disposable)
                disposable.Dispose();
        }
        /////////////////////////////////////////////////////////////////////////////////////////
    }
}
file class User
{
    public string Name { get; set; }
    public int Age { get; set; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

file class UsersStorage : IEnumerable
{
    private readonly User[] users;
    public UsersStorage(User[] users) => this.users = users;
    
    
    public IEnumerator GetEnumerator()
    {
        return new UsersStorageEnumerator(users);
    }
}

file class UsersStorageEnumerator : IEnumerator
{
    private User[] users;
    private int currentIndex = -1;
    public object? Current { get => users[currentIndex]; }

    public UsersStorageEnumerator(object? users) => this.users = users as User[];

    public bool MoveNext()
    {
        currentIndex++;
        if (currentIndex >= users.Length )
            return false;
        return true;
    }
    
    public void Reset() => throw new NotImplementedException();
}

