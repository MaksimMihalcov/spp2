namespace Faker.Generators
{
    internal class DoubleValueGenerator : IValueGenerator
    {
        private readonly Random random = new Random();
        public bool CanGenerate(Type type)
        {
            return type.Name == "Double";
        }

        public object Generate(Type type)
        {
            return random.NextDouble();
        }
    }
}
