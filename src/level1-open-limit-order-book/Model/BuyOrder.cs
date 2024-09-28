namespace Application {
    public class BuyOrder : Order {
        new public BuyId Id => (BuyId)base.Id;
        public InvestorId BuyerId { get; }
        public BuyOrder(OrderRequest request) : base(request, new BuyId()) {}
    }
}
