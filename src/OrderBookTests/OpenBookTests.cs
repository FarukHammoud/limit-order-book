using Application;

namespace ApplicationTests {
    [TestClass]
    public class OpenBookTests {
        [TestMethod]
        public void OrderBook_AddBuyOrder_NoExceptionRaises() { 
            // Arrange
            IOrderBookLogger logger = new Logger();
            IOrderBook orderBook = new OrderBook(
                new OrderBookParameters() {
                    LotSize = 10,
                    TickSize = 0.01,
                    PrioritySystem = OrderBookParameters.Priority.TimePrice
                }, logger);
            // Act 
            try {
                orderBook.Add(new BuyOrderRequest() {
                    InvestorCode = new InvestorId().Code.ToString(),
                    LimitPrice = 30.2,
                    Quantity = 100
                });
            } catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }

        [TestMethod]
        public void OrderBook_AddSellOrder_NoExceptionRaises() {
            // Arrange
            IOrderBookLogger logger = new Logger();
            IOrderBook orderBook = new OrderBook(
                new OrderBookParameters() {
                    LotSize = 10,
                    TickSize = 0.01,
                    PrioritySystem = OrderBookParameters.Priority.TimePrice
                }, logger);
            // Act 
            try {
                orderBook.Add(new SellOrderRequest() {
                    InvestorCode = new InvestorId().Code.ToString(),
                    LimitPrice = 30.2,
                    Quantity = 100
                });
            } catch (Exception ex) {
                Assert.Fail("Expected no exception, but got: " + ex.Message);
            }
        }
    }
}