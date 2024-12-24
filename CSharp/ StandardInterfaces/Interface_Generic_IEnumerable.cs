using System.Collections;

namespace StandardInterfaces;

public class Run_Generic_IEnumerable
{
    public static void main()
    {
        User user1 = new("Josef", 25);
        User user2 = new("mark", 19);
        UsersStorage usersStorage = new(new []{user1, user2});
        
        
        foreach (var user in usersStorage)
        {
            //Console.WriteLine((user as User).Name);
            Console.WriteLine((user).Name);
        }

        Console.WriteLine();
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

file class UsersStorage : IEnumerable<User>
{
    private readonly User[] users;
    public UsersStorage(User[] users) => this.users = users;
    
    

    public IEnumerator<User> GetEnumerator()
    {
        return new UsersStorageEnumerator(this.users);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}

file class UsersStorageEnumerator : IEnumerator<User>
{
    private User[] users;
    private int currentIndex = -1;
    public UsersStorageEnumerator(User[] users) => this.users = users;
    
    public User Current{ get => users[currentIndex]; }
    object IEnumerator.Current => Current;
    
    public bool MoveNext()
    {
        currentIndex++;
        if (currentIndex >= users.Length )
            return false;
        return true;
    }
    
    public void Reset() => throw new NotImplementedException();
    public void Dispose() { }
}

