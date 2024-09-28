namespace Application {
    public class OrderBook : IOrderBook {
        public OrderBookParameters Parameters { get; set; }

        private readonly IOrderBookLogger _logger;
        private readonly Dictionary<SellId, SellOrder> _asks = new();
        private readonly Dictionary<BuyId, BuyOrder> _bids = new();

        public OrderBook(OrderBookParameters parameters,
            IOrderBookLogger logger) {
            Parameters = parameters;
            _logger = logger;
        }

        public OrderId? Add(OrderRequest request) {
            if (request is SellOrderRequest sellRequest) {
                Console.WriteLine($"Adding sell order : {sellRequest.DisplayQuantity} @{sellRequest.LimitPrice}");
                var order = new SellOrder(sellRequest);
                _asks.Add(order.Id, order);
                return order.Id;
            }
            if (request is BuyOrderRequest buyRequest) {
                Console.WriteLine($"Adding buy order : {buyRequest.DisplayQuantity} @{buyRequest.LimitPrice}");
                var order = new BuyOrder(buyRequest);
                _bids.Add(order.Id, order);
                return order.Id;
            }
            return null;
        }

        public void Cancel(OrderId orderId) {
            if (orderId is BuyId buyId) {
                _bids.Remove(buyId);
            }
            else if (orderId is SellId sellId) {
                _asks.Remove(sellId);
            }
            throw new ArgumentException("Neither BuyId or SellId");
        }

        public bool Execute() {
            List<BuyOrder> sortedBids;
            List<SellOrder> sortedAsks;
            if (Parameters.PrioritySystem == OrderBookParameters.Priority.TimePrice) {
                sortedBids = _bids.Values.ToList().OrderBy(o => o.SubmissionTime)
                    .OrderBy(o => o.LimitPrice).ToList();
                sortedAsks = _asks.Values.ToList().OrderBy(o => o.SubmissionTime)
                    .OrderBy(o => o.LimitPrice).ToList();
            } else if (Parameters.PrioritySystem == OrderBookParameters.Priority.Size) {
                sortedBids = _bids.Values.ToList().OrderBy(o => o.Quantity).ToList();
                sortedAsks = _asks.Values.ToList().OrderBy(o => o.Quantity).ToList();
            } else {
                return false;
            }
            foreach (var order in _asks.Values) {
                if (order.TimeInForce == TIF.ImmediateOrCancel ||
                    order.TimeInForce == TIF.FillOrKill) {
                    Cancel(order.Id);
                }
                if (order.TimeInForce == TIF.Day &&
                    order.SubmissionTime + TimeSpan.FromDays(1) > DateTime.Now) {
                    Cancel(order.Id);
                }
            }
            while (sortedBids.Count() > 0 && sortedAsks.Count() > 0) {
                BuyOrder bid = sortedBids.First();
                SellOrder ask = sortedAsks.First();
                if (!TryExecute(bid, ask)) {
                    break;
                }
                if (bid.Quantity == 0) {
                    sortedBids.Remove(bid);
                    _bids.Remove(bid.Id);
                }
                if (ask.Quantity == 0) {
                    sortedAsks.Remove(ask);
                    _asks.Remove(ask.Id);
                }
            }
            return false;
        }

        private bool TryExecute(BuyOrder bid, SellOrder ask) {
            if (bid.LimitPrice < ask.LimitPrice) {
                return false;
            }
            double transactionAmount = Math.Min(bid.Quantity, ask.Quantity);
            double transactionPrice = Math.Round((bid.LimitPrice + ask.LimitPrice) / 2, (int)(-Math.Log10(Parameters.TickSize) + 2));
            _logger.LogTransaction(transactionAmount, transactionPrice, bid.InvestorId, ask.InvestorId);
            ask.Quantity -= transactionAmount;
            bid.Quantity -= transactionAmount;
            return true;
        }

        public void Amend(OrderId id) {
        }

        public double? GetBestBid() {
            return _bids.Values.ToList()
                .OrderBy(o => o.LimitPrice)
                .FirstOrDefault()?
                .LimitPrice;
        }

        public double? GetVolumeAtLimit() {
            throw new NotImplementedException();
        }
    }
}
