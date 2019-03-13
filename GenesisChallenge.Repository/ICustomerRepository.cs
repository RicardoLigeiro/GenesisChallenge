using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        /// <param name="recordsToSkip">Number of records to skip</param>
        /// <param name="recordsToTake">Number of records to take</param>
        /// <param name="sortColumn">Column to sort</param>
        /// <param name="sortDirection">Sort direction</param>
        /// <returns>List of customer orders</returns>
        Task<QueryResult<CustomerOrder>> GetCustomerOrdersAsync(int recordsToSkip, int recordsToTake, string sortColumn, SortDirection sortDirection);

        /// <summary>
        ///     Saves the customer info (First and Last name)
        /// </summary>
        /// <param name="obj">Customer object</param>
        /// <returns>True for success</returns>
        Task<PersistenceResult> SaveCustomerInfoAsync(CustomerOrder obj);
    }
}