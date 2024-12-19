namespace Properties.Access.Modifiers;

class Program
{
    static void Main(string[] args)
    {
        AClass aClass = new AClass(2);//{A = 3};
        BClass bClass = new BClass(2){A = 3};
        CClass cClass = new CClass(2);//{A = 3};
        DClass dClass = new DClass(2); //{A = 3};
        
        //   aClass.A = 4; // Error 
        //   bClass.A = 4; // Error
        //   cClass.A = 4; // Error
        //   dClass.A = 4; // Error

        Console.WriteLine(aClass.A); //   2
        Console.WriteLine(bClass.A); //   3
        Console.WriteLine(cClass.A); //   2
        Console.WriteLine(dClass.A); //   2
        
    }
}

//     public int A { get; } - 
//              1) по замовчуванню
//              2) конструктор
//
//      public int A { get; init; }
//              1) по замовчуванню
//              2) конструктор
//              3) ініціалізатор
//
//      public int A { get; private set; }
//              1) по замовчуванню
//              2) конструктор
//              3) будь-де у класі в тому самому класі
//
//
//      public readonly int A = 1;
//              1) властивість не може бути readonly!!!
//              2) по замовчуванню 
//              3) конструктор


class AClass
{
    public int A { get; } = 1;
    public AClass(int val) => A = val;

            // The property 'ConsoleApp3.AClass.A' has no setter
    // public void MethodToSet_A_Prop(int val) => A = val;
    
    
}

class BClass
{
    public int A { get; init; } = 1;
    public BClass(int val) => A = val;

            // Init-only property 'ConsoleApp3.BClass.A' can only be assigned
            // in an object initializer, or on 'this' or 'base' in an instance
            // constructor or an 'init' accessor
    // public void MethodToSet_A_Prop(int val) => A = val;
}

class CClass
{
    public int A { get; private set; } = 1;
    public CClass(int val) => A = val;

    public void MethodToSet_A_Prop(int val) => A = val;
}

class DClass
{
            //Property cannot be 'readonly'
    //public readonly int A { get; set; } 

    public readonly int A = 1;
    public DClass(int val) => A = val;

            //Field 'A2' is read-only (except in constructor or init-only setter of the type 
            //in which the field is defined). The assignment target must be an assignable
            //variable, property, or indexer
    //public void MethodToSet_A_Prop(int val) => A = val;
}