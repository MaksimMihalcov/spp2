namespace Faker.Generators
{
    public class EnumGenerator : IValueGenerator
    {
        private readonly Random random = new Random();
        public bool CanGenerate(Type type)
        {
            return type.IsEnum;
        }

        public object Generate(Type type)
        {
            var v = Enum.GetValues(type);
            return v.GetValue(random.Next(v.Length));
        }
    }
}
