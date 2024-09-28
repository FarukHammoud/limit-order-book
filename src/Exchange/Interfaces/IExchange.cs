using Application;

namespace InfrastructureExchange {
    public interface IExchange {
        /// <summary>
        /// Registers a new Investor into the exchange
        /// </summary>
        /// <param name="name">Name of the investor</param>
        /// <returns>InvestorId object</returns>
        InvestorId RegisterInvestor(string name);

        /// <summary>
        /// Gets all traded securities
        /// </summary>
        /// <returns>A List of securities</returns>
        IList<Security> GetTradedSecurities();

        /// <summary>
        /// Get the respective order book of a traded security
        /// </summary>
        /// <param name="security">Security object traded in this exchange</param>
        /// <returns>An Order Book</returns>
        IOrderBook GetOrderBook(Security security);
    }
}
