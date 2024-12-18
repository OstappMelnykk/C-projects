namespace Access.Modifiers.Helper;

class Program
{
    static void Main(string[] args)
    {
        A a = new A(); // public 
        // B b = new B(); // internal 
        C c = new C(); // public 
        
        
        // Console.WriteLine(c.a); // private 
        // Console.WriteLine(c.b); // protected
        // Console.WriteLine(c.c); // internal 
        Console.WriteLine(c.d); // public 
        
        // Console.WriteLine(c.e); // protected internal
        // Console.WriteLine(c.f); // private protected
        
    }
}
public class D : A
{
    // public new void Print_a() => Console.WriteLine(this.a); // private 
    public new void Print_b() => Console.WriteLine(this.b); // protected
    // public new void Print_c() => Console.WriteLine(this.c); // internal 
    public new void Print_d() => Console.WriteLine(this.d); // public 
    
    public new void Print_e() => Console.WriteLine(this.e);  // protected internal
    // public new void Print_f() => Console.WriteLine(this.f);  // private protected
}
