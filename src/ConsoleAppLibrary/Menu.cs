using DustInTheWind.ConsoleTools.Controls.Menus;
using static ConsoleAppLibrary.BaseCommand;

namespace ConsoleAppLibrary {
    public class Menu {
        public string Title { get; set; } = "";
        public Callback? Parent { get; set; }
        public IList<MenuItem> Items { get; set; } = new List<MenuItem>();
        
        public void Display() {
            Console.Clear();
            TextMenu textMenu = new TextMenu {
                TitleText = Title,
                EraseAfterClose = true,
            };
            int i = 0;
            for(i = 0; i < Items.Count; i++) {
                int j = i;
                textMenu.AddItem(new TextMenuItem {
                    Id = (j+1).ToString(),
                    Text = Items[j].Text,
                    Command = new BaseCommand() {
                        Handler = () => Items[j].Handler()
                    }
                });
            }
            if (Parent != null) {
                textMenu.AddItem(new TextMenuItem {
                    Id = (i + 1).ToString(),
                    Text = "Return",
                    Command = new BaseCommand() {
                        Handler = () => Parent()
                    }
                });
            }
            textMenu.Display();
        }
    }
}
