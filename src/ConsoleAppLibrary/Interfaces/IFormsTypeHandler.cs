using System.Reflection;

namespace ConsoleAppLibrary {
    public interface IFormsTypeHandler {
        Type Type { get; }
        object Handle(PropertyInfo propertyInfo);
    }
}
