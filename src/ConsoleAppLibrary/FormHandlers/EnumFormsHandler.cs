using System.Reflection;

namespace ConsoleAppLibrary.FormHandlers {
    public class EnumFormsHandler : IFormsTypeHandler {
        public Type Type => typeof(Enum);

        public object Handle(PropertyInfo propertyInfo) {
            var menu = new Menu() {
                Title = propertyInfo.Name,
            };
            var answer_enum = Activator.CreateInstance(propertyInfo.PropertyType);
            var names = Enum.GetNames(propertyInfo.PropertyType);
            for (int i = 0; i < names.Count(); i++) {
                menu.Items.Add(new MenuItem() {
                    Text = names[i],
                    Handler = () => { answer_enum = i; }
                }) ;
            }
            menu.Display();
            return answer_enum;
            
        }
    }
}
