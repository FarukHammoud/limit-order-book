namespace Application {
    public interface IOrderBookLevel2MarketDataGetter {
        List<(double Price, double Quantity)> BestAggregatedBids { get; set; }
        List<(double Price, double Quantity)> BestAggregatedAsks { get; set; }
    }
}
