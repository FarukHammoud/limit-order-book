namespace Application {
    public interface IOrderBookLevel3MarketDataGetter {
        List<(double Price, double Quantity)> Bids { get; set; }
        List<(double Price, double Quantity)> Asks { get; set; }
    }
}
