using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators 
{
    public class StringGenerator : IValueGenerator
    {
        private readonly Random random = new Random();
        public bool CanGenerate(Type type)
        {
            return type.Name == "String";
        }

        public object Generate(Type type)
        {
            var length = random.Next(1,255);
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
