using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GenesisChallenge.Entities;

namespace GenesisChallenge.Repository
{
    /// <summary>
    ///     Here we are simplifying the persistence implementation as que example just needs a 1 to 1 relationship
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        ///     Retrieves all the customer orders
        /// </summary>
        /// <returns></returns>
        Task<List<CustomerOrder>> GetCustomerOrdersAsync();

        /// <summary>
        ///     Saves the customer info (First and Last name)
        /// </summary>
        /// <param name="obj">Customer object</param>
        /// <returns>True for success</returns>
        Task<PersistenceResult> SaveCustomerInfoAsync(CustomerOrder obj);
    }
}