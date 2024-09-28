using ConsoleAppLibrary;

namespace ClientConsoleApp {
    public static class MainMenu {
        public static void Display() {
            Menu menu = new() {
                Title = "Open Limit Order Book",
                Items = new[] {
                    new MenuItem() {
                        Text = "Add / Amend / Cancel Buy Order",
                        Handler = () => { }
                    },
                    new MenuItem() {
                        Text = "Add / Amend / Cancel Sell Order",
                        Handler = () => { }
                    }
                }
            };
            menu.Display();
        }
    }
}
