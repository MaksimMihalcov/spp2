using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faker;

namespace Faker.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public class A
        {
            private A(int id, double db, string s)
            {
                Id = 666;
                dbl = db;
                str = "private";
                throw new System.Exception("ex");
            }
            public A(int id, string st) { Id = 777; str = st; }
            public A() { }
            public int Id { get; set; }
            public double dbl;
            public string str;
            public B b;
        }

        public class B
        {
            public B() { Aa = new A(); }
            public A Aa { get; set; }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var fak = new ÑFaker();
            var obj = fak.Create<A>();
            Assert.IsTrue(obj.Id == 777 && obj.dbl != 0 && obj.str != null && obj.b.Aa.Id == 0);
        }
    }
}