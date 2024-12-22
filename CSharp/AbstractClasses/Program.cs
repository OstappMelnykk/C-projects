namespace AbstractClasses;

class Program
{
    static void Main(string[] args)
    {
        Type t1 = typeof(A);
        Type t2 = typeof(B);
        Type t3 = typeof(C);
        Type t4 = typeof(D);
        Type t5 = typeof(E);

        Console.WriteLine($"Is {t1.Name} abstract? {t1.IsAbstract}");  //  True
        Console.WriteLine($"Is {t2.Name} abstract? {t2.IsAbstract}");  //  True
        Console.WriteLine($"Is {t3.Name} abstract? {t3.IsAbstract}");  //  True
        Console.WriteLine($"Is {t4.Name} abstract? {t4.IsAbstract}");  //  False
        Console.WriteLine($"Is {t5.Name} abstract? {t5.IsAbstract}");  //  True
    }
}

public abstract class A
{
    public abstract void DoSomething_1();
    public abstract void DoSomething_2();
    public abstract void DoSomething_3();
}

public abstract class B : A {
    public override void DoSomething_1() => Console.WriteLine("DoSomething_1");
}

public abstract class C : B {
    public override void DoSomething_2() => Console.WriteLine("DoSomething_2"); 
    //public override void DoSomething_3() => throw new NotImplementedException();
}

public class D : C {
    public override void DoSomething_3() => Console.WriteLine("DoSomething_3");
}

public abstract class E : D { }