using DustInTheWind.ConsoleTools.Controls;

namespace ClientExchangeConsoleApp {
    public static class Success {
        public static void Display(string text, Callback callback) {
            Pause.QuickDisplay($"[Success] {text}. Enter to Continue");
            callback();
        }
    }
}
