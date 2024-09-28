using System.Reflection;

namespace ConsoleAppLibrary {
    public class FormsService {
        private IList<IFormsTypeHandler> _handlers;
        public FormsService(IList<IFormsTypeHandler> handlers) {
            _handlers = handlers;
        }

        public T Display<T>() {
            var obj = (T)Activator.CreateInstance(typeof(T));
            if (obj is null) {
                throw new InvalidCastException();
            }
            var properties = obj.GetType().GetRuntimeProperties();
            foreach (var property in properties) {
                foreach (var handler in _handlers) {
                    if (property.PropertyType == handler.Type) {
                        var value = handler.Handle(property);
                        property.SetValue(obj, value);
                    }
                } 
            }
            return obj;
        }
    }
}
