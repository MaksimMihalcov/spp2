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

public class C
{
    public C(){}
    private C(int a, int f, string ef) { A = 5; this.f = f; str = "private"; }
    public C(int a) { A = a; }
    public int A { get; set; }
    public string str;
    public int f;
}

public class A
{
    public int Adc { get; set; }
    public string str;
    public int qw;
    public B B { get; set; }
}

public struct B
{
    public int DCsdc { get; set; }
    public A A { get; set; }
}