using ConsoleAppLibrary;

namespace ClientConsoleApp {
    public static class SellMenu {
        public static void Display() {
            Menu menu = new() {
                Title = "Open Limit Order Book / Sell Menu",
                Items = new[] {
                    new MenuItem() {
                        Text = "Add Sell Order",
                        Handler = () => { }
                    },
                    new MenuItem() {
                        Text = "Amend Sell Order",
                        Handler = () => { }
                    },
                    new MenuItem() {
                        Text = "Cancel Sell Order",
                        Handler = () => { }
                    }
                }
            };
            menu.Display();
        }
    }
}
