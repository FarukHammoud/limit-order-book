using DustInTheWind.ConsoleTools.Controls.InputControls;
using System.Reflection;

namespace ConsoleAppLibrary {
    public class StringFormsHandler : IFormsTypeHandler {
        public Type Type => typeof(string);

        public object Handle(PropertyInfo propertyInfo) {
            var answer = ValueControl<string>.QuickRead($"{propertyInfo.Name}:");
            return answer;
        }
    }
}
