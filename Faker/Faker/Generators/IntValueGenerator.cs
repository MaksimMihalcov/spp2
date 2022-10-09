namespace Faker.Generators
{
    public class IntValueGenerator : IValueGenerator
    {
        private readonly Random random = new Random();
        public bool CanGenerate(Type type)
        {
            return type.Name == "Int32";
        }

        public object Generate(Type type)
        {
            return (int)random.NextInt64();
        }
    }
}
