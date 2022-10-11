using Faker.Generators;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Faker
{
    public class ValueGenerator
    {
        private List<IValueGenerator> ValueGenerators { get; set; }
        private List<string> ClassNames = new List<string>();
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

        public object Generate(Type type, [CallerMemberName] string callerName = "")
        {
            if (callerName == "GenerateNonPrimitiveType")
            {
                if (type.IsClass && type.Name != "String" || (type.IsValueType && !type.IsPrimitive))
                    if (ClassNames.FirstOrDefault(x => x == type.FullName) == null)
                        ClassNames.Add(type.FullName);
                    else
                        return null;
            }
            else
            {
                ClassNames.Clear();
            } 
            for (int i = 0; i < ValueGenerators.Count; i++)  
                if (ValueGenerators[i].CanGenerate(type))
                    return ValueGenerators[i].Generate(type);
            try { return GenerateNonPrimitiveType(type); }
            catch { return Activator.CreateInstance(type); }
        }

        private object GenerateNonPrimitiveType(Type type)
        {
            var constructors = (type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)).OrderByDescending(x =>x.GetParameters().Length).ToList();
            object obj = Activator.CreateInstance(type);
            if (constructors.Count != 0)
            {
                ConstructorInfo constructor;
                for(int i = 0; i < constructors.Count; i++)
                    try
                    {
                        constructor = constructors[i];
                        var parameters = constructor.GetParameters();
                        var prms = new ArrayList();
                        for (int j = 0; j < parameters.Length; j++)
                            prms.Add(Generate(parameters[j].ParameterType));
                        obj = constructor.Invoke(prms.ToArray());
                        break;
                    }
                    catch { }
                
            }
            var properties = type.GetProperties();
            var fields = type.GetFields();
            PropertyInfo property;
            for (int i = 0; i < properties.Length; i++)
            {
                property = type.GetProperty(properties[i].Name, BindingFlags.Public | BindingFlags.Instance);
                var value = property.GetValue(obj, null);
                if ((value == null) || (properties[i].PropertyType.IsValueType && !properties[i].PropertyType.IsPrimitive) || (properties[i].PropertyType.IsPrimitive && (Convert.ToInt32(value)) == 0))
                    property.SetValue(obj, Generate(properties[i].PropertyType), null);
            }
            FieldInfo field;
            for (int i = 0; i < fields.Length; i++)
            {
                field = type.GetField(fields[i].Name, BindingFlags.Public | BindingFlags.Instance);
                var value = field.GetValue(obj);
                if ((value == null) || (fields[i].FieldType.IsPrimitive && (Convert.ToInt32(value)) == 0))
                    field.SetValue(obj, Generate(fields[i].FieldType));
            }
            return obj;
        }
    }
}
