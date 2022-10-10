namespace Faker
{
    public class СFaker
    {
        private ValueGenerator Generator { get; set; }
        public СFaker()
        {
            Generator = new ValueGenerator();
        }

        public T Create<T>()
        {
            return (T)Generator.Generate(typeof(T));
        }

    }
}