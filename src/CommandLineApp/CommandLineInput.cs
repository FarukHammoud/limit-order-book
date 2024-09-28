using Application;

namespace CommandLineApp {
    public class CommandLineInput {
        private readonly String _inputFileName = "";

        public CommandLineInput(String[] args) {
            if (args != null && args.Length == 1) {
                _inputFileName = args[0];
            }
            else {
                throw new ArgumentException("One and only one argument is expected");
            }
        }

        public IEnumerable<OrderRequest> GetOrders() {
            foreach (String line in File.ReadLines(_inputFileName)) {
                OrderRequest? order = OrderRequestParser.Parse(line);
                if (order != null) {
                    yield return order;
                }
            }
        }
    }
}
