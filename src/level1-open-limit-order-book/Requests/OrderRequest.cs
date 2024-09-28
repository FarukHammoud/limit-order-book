namespace Application {
    public class OrderRequest {
        public string InvestorCode { get; set; }
        public double Quantity { get; set; }
        public double LimitPrice { get; set; }
        public TIF? TimeInForce { get; set; }
        public bool? PostOnly { get; set; }
        public bool? Hidden { get; set; }
        public double? DisplayQuantity { get; set; } 
    }
}
