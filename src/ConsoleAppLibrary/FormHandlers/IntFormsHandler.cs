using DustInTheWind.ConsoleTools.Controls.InputControls;
using System.Reflection;

namespace ConsoleAppLibrary {
    public class IntFormsHandler : IFormsTypeHandler {
        public Type Type => typeof(int);

        public object Handle(PropertyInfo propertyInfo) {
            var answer = ValueControl<int>.QuickRead($"{propertyInfo.Name}:");
            return answer;
        }
    }
}
