using Application;

namespace InfrastructureExchange {
    public interface IExchangeAdmin {
        /// <summary>
        /// Adds a new security to the list of traded securities
        /// </summary>
        /// <param name="security">Security Object</param>
        /// <param name="parameters">OrderBookParameters object</param>
        public void AddTradedSecurity(Security security, OrderBookParameters parameters);
        
        /// <summary>
        /// Removes an existing security from the list of traded securities
        /// </summary>
        /// <param name="code">Code string</param>
        public void RemoveTradedSecurity(string code);

        /// <summary>
        /// Removes a registered investor
        /// </summary>
        /// <param name="code">Investor's name</param>
        public void RemoveInvestor(string name);

        /// <summary>
        /// Gets a list of investors
        /// </summary>
        public IList<(string, InvestorId)> GetInvestors();

        /// <summary>
        /// Gets a specific Order Book Logger
        /// </summary>
        /// <param name="code">Code string</param>
        public IOrderBookLogger GetLogger(Security security);
    }
}
