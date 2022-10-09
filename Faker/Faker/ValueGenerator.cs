using Faker.Generators;
using System.Collections;
using System.Reflection;

namespace Faker
{
    public class ValueGenerator
    {
        private List<IValueGenerator> ValueGenerators { get; set; }
        public ValueGenerator()
        {
            ValueGenerators = new List<IValueGenerator> 
            { 
                new DateTimeGenerator(), 
                new DoubleValueGenerator(),
                new IntValueGenerator(),
                new StringGenerator(),
                new EnumGenerator(),
                new ListGenerator()
            };
        }
        public object Generate(Type type)
        { 
            for (int i = 0; i < ValueGenerators.Count; i++)  
                if (ValueGenerators[i].CanGenerate(type))
                    return ValueGenerators[i].Generate(type);
            return GenerateNonPrimitiveType(type);
        }

        private object GenerateNonPrimitiveType(Type type)
        {
            var constructors = type.GetConstructors();
            ConstructorInfo constructor = constructors[0];
            for(int i = 0; i < constructors.Length; i++)
                if(constructors[i].GetParameters().Length > constructor.GetParameters().Length)
                    constructor = constructors[i];
            var parameters = constructor.GetParameters();
            var prms = new ArrayList();
            for (int i = 0; i < parameters.Length; i++)
                prms.Add(Generate(parameters[i].ParameterType));
            var obj = constructor.Invoke(prms.ToArray());
            //var e = type.IsClass || type.IsValueType;
            var properties = type.GetProperties();
            var fields = type.GetFields();
            PropertyInfo property;
            for (int i = 0; i < properties.Length; i++)
            {
                property = type.GetProperty(properties[i].Name, BindingFlags.Public | BindingFlags.Instance);
                var value = property.GetValue(obj, null);
                if (value == null)
                    property.SetValue(obj, Generate(properties[i].PropertyType), null);
            }
            FieldInfo field;
            for (int i = 0; i < fields.Length; i++)
            {
                field = type.GetField(fields[i].Name, BindingFlags.Public | BindingFlags.Instance);
                var value = field.GetValue(obj);
                if (value == null)
                    field.SetValue(obj, Generate(fields[i].FieldType));
            }
            return obj;
        }
    }
}
