namespace Application {
    public class Fees {
        public double MakerFee { get; }
        public double TakerFee { get; }
        public Fees(double makerFee, double takerFee) { 
            MakerFee = makerFee;
            TakerFee = takerFee;
        }
    }
}
