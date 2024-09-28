using DustInTheWind.ConsoleTools.Controls.InputControls;
using System.Reflection;

namespace ConsoleAppLibrary.FormHandlers {
    public class BoolFormsHandler : IFormsTypeHandler {
        public Type Type => typeof(bool);

        public object Handle(PropertyInfo propertyInfo) {
            YesNoQuestion question = new YesNoQuestion($"{propertyInfo.Name}?");
            bool answer = question.ReadAnswer() == YesNoAnswer.Yes;
            return answer;
        } 
    }
}
