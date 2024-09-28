namespace Application {
    /// <summary>
    /// Represents an order book
    /// </summary>
    public interface IOrderBook {
        /// <summary>
        /// Adds an order to the order book
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The orderId if valid request, null otherwise</returns>
        OrderId? Add(OrderRequest request);

        /// <summary>
        /// Cancels an order
        /// </summary>
        /// <param name="orderId">orderId</param>
        void Cancel(OrderId orderId);

        /// <summary>
        /// Amend an order
        /// </summary>
        /// <param name="orderId">orderId</param>
        void Amend(OrderId orderId);

        /// <summary>
        /// Executes all possible order using the chosen priority
        /// </summary>
        /// <returns>true if some order has been executed, false otherwise</returns>
        bool Execute();

        /// <summary>
        /// Gets the volume that could be executed if Execute() was called
        /// </summary>
        /// <returns>Volume at Limit</returns>
        double? GetVolumeAtLimit();

        /// <summary>
        /// Returns the best bid price
        /// </summary>
        /// <returns>best bid price</returns>
        double? GetBestBid();
    }
}
