namespace Access.Modifiers;

class Program
{
    static void Main(string[] args)
    { 
        MyClas clas = new MyClas(); //good
        
        A a = new A();
        B b = new B();
        C c = new C();

        // Console.WriteLine(c.a); // private 
        // Console.WriteLine(c.b); // protected
        Console.WriteLine(c.c); // internal 
        Console.WriteLine(c.d); // public 
        
        Console.WriteLine(c.e); // protected internal
        // Console.WriteLine(c.f); // private protected
        
    }
}

file class MyClas {}

public class A
{
    private int a;
    protected int b;
    internal int c;
    public int d;

    // З будь-якого місця в коді в межах того ж проекту
    // З похідних класів, навіть якщо вони в іншому проекті
    protected internal int e;
    
    // Тільки в межах поточного класу.
    // В межах похідних класів, але лише якщо вони в тому ж проекті
    private protected int f;
    
    //  protected internal — дозволяє доступ у всьому проекті +
    //                       похідним класам в інших проектах.
    //
    //  private protected — доступ тільки в межах проекту,
    //                      і лише похідним класам.

    public void Print_a() => Console.WriteLine(this.a); // private 
    public void Print_b() => Console.WriteLine(this.b); // protected
    public void Print_c() => Console.WriteLine(this.c); // internal 
    public void Print_d() => Console.WriteLine(this.d); // public 
    
    public void Print_e() => Console.WriteLine(this.e); // protected internal
    public void Print_f() => Console.WriteLine(this.f); // private protected

}

internal class B { }

public class C : A
{ 
    // public new void Print_a() => Console.WriteLine(this.a); // private 
    public new void Print_b() => Console.WriteLine(this.b); // protected
    public new void Print_c() => Console.WriteLine(this.c); // internal 
    public new void Print_d() => Console.WriteLine(this.d); // public 
    
    public new void Print_e() => Console.WriteLine(this.e);  // protected internal
    public new void Print_f() => Console.WriteLine(this.f);  // private protected
}
