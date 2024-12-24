namespace StandardInterfaces;

public class Run_ICloneable
{
    public static void main()
    {
        //without Clone method
        var tom1 = new Person("Tom", 23);
        var bob1 = tom1;
        bob1.Name = "Bob";
        Console.WriteLine(tom1.Name); // Bob
        
        //with Clone method
        var tom2 = new Person("Tom", 23);
        var bob2 = (Person)tom2.Clone();
        bob2.Name = "Bob";
        Console.WriteLine(tom2.Name); // Tom
        
        
       //MemberwiseClone()  -  поверхневе копіюваненя
    }
}

file class Person : ICloneable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public object Clone()
    {
        return new Person(Name, Age);
    }
    
  //public object Clone() => MemberwiseClone();

}