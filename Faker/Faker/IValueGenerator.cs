namespace Faker
{
    internal interface IValueGenerator
    {
        object Generate(Type t);
        bool CanGenerate(Type type);
    }
}
