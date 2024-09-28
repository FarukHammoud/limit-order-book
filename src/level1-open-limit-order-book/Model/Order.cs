namespace Application {
    public abstract class Order {
        public OrderId Id { get; } 
        public InvestorId InvestorId { get; }
        public double Quantity { get; set; }
        public double LimitPrice { get; set; }
        public DateTime SubmissionTime { get; set; }
        public TIF TimeInForce { get; set; } = TIF.GoodTillCancel;
        public bool PostOnly { get; set; } = false;
        public bool Hidden { get; set; } = false;
        public double? DisplayQuantity { get; set; } = null;

        public Order(OrderRequest request, OrderId id) {
            Id = id;
            Quantity = request.Quantity;
            LimitPrice = request.LimitPrice;    
            SubmissionTime = DateTime.UtcNow;
            if(request.TimeInForce.HasValue) {
                TimeInForce = request.TimeInForce.Value;    
            }
            if (request.PostOnly.HasValue) {
                PostOnly = request.PostOnly.Value;
            }
            if (request.DisplayQuantity.HasValue) {
                DisplayQuantity = request.DisplayQuantity.Value;
            }
        }
    }
}
