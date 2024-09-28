using DustInTheWind.ConsoleTools.Controls.Menus;

namespace ConsoleAppLibrary {
    public class BaseCommand : ICommand {
        public delegate void Callback();
        public bool IsActive => true;
        public Callback? Handler { get; set; }

        public void Execute() {
            if (Handler != null) {
                Handler();
                return;
            }
            throw new NotImplementedException();
        }
    }
}
