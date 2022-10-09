namespace Faker.Generators
{
    public class ListGenerator : IValueGenerator
    {
        public bool CanGenerate(Type type)
        {
            return type.Name == "List`1";
        }

        public object Generate(Type type)
        {
            var count = (new Random()).Next(1, 100);
            var gen = new ValueGenerator();
            var obj = Activator.CreateInstance(type);
            var list = (System.Collections.IList)obj;
            var t = obj.GetType().GenericTypeArguments[0];
            for (int i = 0; i < count; i++)
                list.Add(gen.Generate(t));
            return list;    
        }
    }
}
