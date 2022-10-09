using Faker;

var faker = new СFaker();

var obj = faker.Create<C>();
Console.ReadLine();

enum DayTime
{
    Morning,
    Afternoon,
    Evening,
    Night
}

public class A
{
    public int AA { get; set; }
    public double B { get; set; }
}

public class C
{
    public C(){}
    public C(int a, int f, string ef) { A = a; this.f = f; str = ef; }
    public C(int a) { A = a; }
    public int A { get; set; }
    public string str;
    public int f;
    public int cvcv;
    public A aa;
    public B B { get; set; }
}

public struct B
{
    public int A { get; set; }
    public double BB { get; set; }
}