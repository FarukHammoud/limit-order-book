namespace ConsoleAppLibrary {
    public class MenuItem {
        public string Text { get; set; } = "";
        public delegate void Callback();
        public Callback Handler { get; set; }
    }
}
