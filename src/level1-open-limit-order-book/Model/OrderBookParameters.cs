namespace Application {
    public class OrderBookParameters {
        public enum Priority { TimePrice, Size }
        public double TickSize { get; set; } = 0.01;
        public double LotSize { get; set; } = 1;
        public Fees Fees { get; set; } = new(0,0);
        public Priority PrioritySystem { get; set; } = Priority.TimePrice;

    }
}
