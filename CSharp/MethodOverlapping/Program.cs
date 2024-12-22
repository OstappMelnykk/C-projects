namespace MethodOverlapping;

class Program
{
    static void Main(string[] args)
    {

        /*Console.WriteLine(((object)42).ToString());
        Console.WriteLine(42.ToString());*/

        A a = new A();
        A b = new B();
        A c = new C();
        A d = new D();

        a.Print();//a
        b.Print();//b
        c.Print();//a
        d.Print();//a
        
        Console.WriteLine();
        
        (c as C).Print();//c
        (d as D).Print();//d
        
        Console.WriteLine();
        
        C c1 = new C();
        D d1 = new D();
        
        c1.Print(); // c
        d1.Print(); // d
        
    }
}

public class A {
    public virtual void Print() => Console.WriteLine("im A");
}

public class B : A {
    public override void Print() => Console.WriteLine("im B");
}


public class C : A {
    public new void Print() => Console.WriteLine("im C");
}

public class D : A {
    public void Print() => Console.WriteLine("im D");
}