namespace Faker.Generators
{
    public class DateTimeGenerator : IValueGenerator
    {
        private readonly Random random = new Random();
        public bool CanGenerate(Type type)
        {
            return type.Name == "DateTime";
        }

        public object Generate(Type type)
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
