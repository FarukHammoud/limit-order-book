namespace Application {
    public interface IOrderBookLogger {
        void LogTransaction(double quantity, 
            double price, 
            InvestorId buyer, 
            InvestorId seller);

        IList<Transaction> GetLastTransactions(int? quantity);
        IList<Transaction> GetTransactionsByInvestor(InvestorId investorId);
    }
}