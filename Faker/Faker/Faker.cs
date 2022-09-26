namespace Faker
{
    public class СFaker
    {
        private Random _random;
        public СFaker()
        {
            _random = new Random();
        }
        public T Create<T>()
        {
            //если ссылочный тип - получить поля класса, пройтись по ним циклом, попроверять на тип и создать значения
            //если значимый - сгенерировать значение и вернуть
            var type = typeof(T);
            return (T)Create(type);
        }

        private object CreateValueType(Type type)
        {

        }

        private object Create(Type type)
        {
            return GetDefaultValue(type);
        }

        private static object GetDefaultValue(Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);
            else
                return null;
        }
    }
}