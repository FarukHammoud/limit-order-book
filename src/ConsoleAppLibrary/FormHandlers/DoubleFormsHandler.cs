using DustInTheWind.ConsoleTools.Controls.InputControls;
using System.Reflection;

namespace ConsoleAppLibrary {
    public class DoubleFormsHandler : IFormsTypeHandler {
        public Type Type => typeof(double);

        public object Handle(PropertyInfo propertyInfo) {
            var answer = ValueControl<double>.QuickRead($"{propertyInfo.Name}:");
            return answer;
        }
    }
}
