namespace Application {
    public record Transaction {
        public Guid Id { get; }
        public double Price { get; }
        public double Size { get; }
        public InvestorId Buyer { get; }
        public InvestorId Seller { get; }
        public DateTime Time { get; }
        public Transaction(double price, double size, InvestorId buyer, InvestorId seller) {
            Id = new();
            Price = price;
            Size = size;
            Buyer = buyer;
            Seller = seller;
            Time = DateTime.Now;
        }
    }
}
