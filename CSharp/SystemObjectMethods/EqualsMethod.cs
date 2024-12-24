namespace SystemObjectMethods;


/*
 
it is better to implement both IEquatable<T> and override
the standard Equals method. This approach provides maximum
flexibility and consistency when comparing instances of your
User class.

1) IEquatable<T>:
    -Specifically designed for type-safe comparisons.
    -Offers better performance compared to the standard Equals method because it avoids boxing and unboxing of value types.
    -Frequently used in generic collections like List<T>, HashSet<T>, or LINQ.
2)Standard Equals Method:
    -Part of the base object contract in C#.
    -Ensures consistency when comparing objects using non-generic APIs or when working with methods that call Equals(object).


To make your implementation robust, override Equals(object) to
call the IEquatable<User>.Equals method internally.

*/

internal class User : IEquatable<User>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public User(string name, int age)
    {
        Name = name;
        Age = age;
    }

    //IEquatable<User>
    public bool Equals(User? other)
    {
        if (other == null)
            return false;
        return Name == other.Name && Age == other.Age;
    }


    //Standard object method:
    public override bool Equals(object? obj)
    {
        // Check if obj is a User and call the IEquatable<User> method
        return obj is User other && Equals(other);
    }
    
    public override int GetHashCode()
    {
        // Combine Name and Age into a hash code
        return HashCode.Combine(Name, Age);
    }
}