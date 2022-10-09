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
            //если ссылочный тип - получить поля класса, пройтись по ним циклом, попроверять на тип и создать значения
            //если значимый - сгенерировать значение и вернуть

            return (T)Generator.Generate(typeof(T));
        }

    }
}