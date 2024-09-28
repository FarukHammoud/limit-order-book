namespace Application {
    public interface IOrderBookLevel1MarketDataGetter {
        double BestBid { get; }
        double BestBidVolume { get; }
        double BestAsk { get; }
        double BestAskVolume { get; }
    }
}
