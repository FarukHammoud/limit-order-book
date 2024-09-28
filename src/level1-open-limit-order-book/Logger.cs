namespace Application {
    public class Logger : IOrderBookLogger {
        private List<Transaction> _transactions = new();

        public IList<Transaction> GetLastTransactions(int? quantity) {
            return _transactions.Skip(Math.Max(0, Math.Max(0, _transactions.Count() - quantity ?? 0) )).ToList();
        }

        public IList<Transaction> GetTransactionsByInvestor(InvestorId investorId) {
            return _transactions.Where(t => t.Seller == investorId || t.Buyer == investorId).ToList();
        }

        public void LogTransaction(double quantity, double price, InvestorId buyer, InvestorId seller) {
            Console.WriteLine($"New transaction {quantity} securities @{price}");
            _transactions.Add(new Transaction(quantity, price, buyer, seller));
        }
    }
}
