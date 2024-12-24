namespace _SystemObjectMethods;

internal class User// : IEquatable<User>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }

    //IEquatable<User>
    /*public bool Equals(User other)
    {
        return Name == other.Name && Age == other.Age;
    }*/

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }
    
    
}