using Application;
using ConsoleAppLibrary;
using DustInTheWind.ConsoleTools.Controls.InputControls;

namespace ClientConsoleApp {
    public class AddBuyOrder {
        public static void Display(OrderBook orderBook) {
            double quantity = ValueControl<double>.QuickRead("Quantity:");
            double price = ValueControl<double>.QuickRead("Limit Price:");
            YesNoQuestion postOnlyQuestion = new YesNoQuestion("Post Only?");
            bool postOnly = postOnlyQuestion.ReadAnswer() == YesNoAnswer.Yes;
            YesNoQuestion hiddenQuestion = new YesNoQuestion("Hidden?");
            bool hidden = hiddenQuestion.ReadAnswer() == YesNoAnswer.Yes;
            TIF tif = new();
            var menu = new Menu() {
                Title = "Time-In-Force (TIF)",
                Items = {
                    new MenuItem(){
                        Text = "Good Till Cancel [Default]",
                        Handler = () => tif = TIF.GoodTillCancel
                    },
                    new MenuItem(){
                        Text = "Day",
                        Handler = () => tif = TIF.Day
                    },
                    new MenuItem(){
                        Text = "Immediate Or Cancel",
                        Handler = () => tif = TIF.ImmediateOrCancel
                    },
                    new MenuItem(){
                        Text = "FillOrKill",
                        Handler = () => tif = TIF.FillOrKill
                    },
                }
            };
            menu.Display();
        }
    }
}
