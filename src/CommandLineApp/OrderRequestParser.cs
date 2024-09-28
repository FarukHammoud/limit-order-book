
using Application;

namespace CommandLineApp {
    public static class OrderRequestParser {
        private static readonly Dictionary<String, InvestorId> _investorIdMap = new();

        // BUY a1b2c3 10 9.315 GoodTilCancel N N 10 
        public static OrderRequest? Parse(string input) {
            String[] words = input.Split().Where(e => e != "").ToArray();
            if (words.Length != 8) {
                return null;
            }
            InvestorId investorId = GetInvestorId(words[1]);
            int quantity = Convert.ToInt32(words[2]);
            double limitPrice = Convert.ToDouble(words[3]);
            TIF timeInForce = (TIF)Enum.Parse(typeof(TIF), words[4]);
            bool hidden = words[5].Equals("Y");
            bool postOnly = words[6].Equals("Y");
            double displayQuantity = Convert.ToDouble(words[7]);

            OrderRequest? orderRequest = null;
            if (words[0] == "BUY") {
                orderRequest = new BuyOrderRequest();
            }
            else if (words[0] == "SELL") {
                orderRequest = new SellOrderRequest();
            }
            if (orderRequest == null) {
                return null;
            }
            orderRequest.Quantity = quantity;
            orderRequest.LimitPrice = limitPrice;
            orderRequest.PostOnly = postOnly;
            orderRequest.DisplayQuantity = displayQuantity;
            orderRequest.Hidden = hidden;
            orderRequest.TimeInForce = timeInForce;
            orderRequest.InvestorCode = investorId.Code.ToString();
            return orderRequest;
        }

        private static InvestorId GetInvestorId(String investorCode) {
            _investorIdMap.TryAdd(investorCode, new InvestorId());
            return _investorIdMap[investorCode];
        }
    }
}
