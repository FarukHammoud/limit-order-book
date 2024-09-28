using ConsoleAppLibrary;
using DustInTheWind.ConsoleTools.Controls.Menus;

namespace ClientConsoleApp {
    public static class BuyMenu {
        private static void Display() {
            Menu menu = new() {
                Title = "Open Limit Order Book",
                Items = new[] {
                    new MenuItem() {
                        Text = "Add Buy Order",
                        Handler = () => { }
                    },
                    new MenuItem() {
                        Text = "Amend Buy Order",
                        Handler = () => { }
                    },
                    new MenuItem() {
                        Text = "Cancel Buy Order",
                        Handler = () => { }
                    }
                }
            };
            menu.Display();
        }
    }
}
