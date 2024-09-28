namespace Application {
    public class SellOrder : Order {
        new public SellId Id => (SellId)base.Id;
        public SellOrder(OrderRequest request) : base(request, new SellId()) {}
    }
}
