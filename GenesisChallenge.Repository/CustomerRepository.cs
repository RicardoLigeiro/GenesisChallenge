using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GenesisChallenge.Entities;
using GenesisChallenge.EntityFramework;
using GenesisChallenge.Repository.ExtensionMethods;

namespace GenesisChallenge.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        ///     Retrieves all the customer orders
        /// </summary>
        /// <param name="recordsToSkip">Number of records to skip</param>
        /// <param name="recordsToTake">Number of records to take</param>
        /// <param name="sortColumn">Column to sort</param>
        /// <param name="sortDirection">Sort direction</param>
        /// <returns>List of customer orders</returns>
        public async Task<QueryResult<CustomerOrder>> GetCustomerOrdersAsync(int recordsToSkip, int recordsToTake,
            string sortColumn, SortDirection sortDirection)
        {
            QueryResult<CustomerOrder> result = null;
            await Task.Run(() =>
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    int count = db.Orders.Count();
                    IQueryable<CustomerOrder> queryable = from o in db.Orders
                        join c in db.Customers on o.CustomerId equals c.Id
                        select new CustomerOrder
                        {
                            Id = c.Id,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            OrderId = o.Id,
                            ReferenceNumber = o.ReferenceNumber,
                            OrderValue = o.OrderValue,
                            OrderDate = o.OrderDate
                        };

                    queryable = sortColumn == nameof(CustomerOrder.CustomerName)
                        ? queryable.OrderBy(nameof(CustomerOrder.FirstName), sortDirection == SortDirection.Descending)
                            .ThenBy(nameof(CustomerOrder.LastName), sortDirection == SortDirection.Descending)
                        : queryable.OrderBy(sortColumn, sortDirection == SortDirection.Descending);

                    //if (sortColumn == nameof(CustomerOrder.CustomerName))
                    //{
                    //    queryable = queryable.OrderBy(nameof(CustomerOrder.FirstName), sortDirection == SortDirection.Descending).ThenBy(nameof(CustomerOrder.LastName), sortDirection == SortDirection.Descending);
                    //}
                    //else
                    //{
                    //    queryable = queryable.OrderBy(sortColumn, sortDirection == SortDirection.Descending);
                    //}
                    result = new QueryResult<CustomerOrder>(count,
                        queryable.Skip(recordsToSkip).Take(recordsToTake).ToList());
                }
            });

            // return query object
            return result;
        }

        /// <summary>
        ///     Saves the customer info (First and Last name)
        /// </summary>
        /// <param name="obj">Customer object</param>
        /// <returns>True for success</returns>
        public async Task<PersistenceResult> SaveCustomerInfoAsync(CustomerOrder obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(CustomerOrder), "{0} cannot be null");

            PersistenceResult result = null;
            await Task.Run(() =>
            {
                // Validate the object that we have received
                ValidationContext context = new ValidationContext(obj, null, null);
                List<ValidationResult> results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(obj, context, results, true))
                {
                    List<string> errors = new List<string>();
                    foreach (ValidationResult vr in results)
                        errors.Add($"Member Name :{vr.MemberNames.First()}, Error: {vr.ErrorMessage}");
                    result = new PersistenceResult(false, errors);
                }

                // save it
                using (DatabaseContext db = new DatabaseContext())
                {
                    Customer customer = db.Customers.SingleOrDefault(s => s.Id == obj.Id);

                    if (customer != null)
                    {
                        customer.FirstName = obj.FirstName;
                        customer.LastName = obj.LastName;
                        db.Entry(customer).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        result = new PersistenceResult(false, new[] {"There is no customer with the supplied id!"});
                    }
                }

                result = new PersistenceResult(true, null);
            });

            // return persistence result
            return result;
        }
    }
}