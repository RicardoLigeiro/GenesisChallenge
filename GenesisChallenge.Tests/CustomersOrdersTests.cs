using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenesisChallenge.Entities;
using GenesisChallenge.Repository;
using Moq;
using Xunit;

namespace GenesisChallenge.Tests
{
    /// <summary>
    ///     Customer Order tests
    /// </summary>
    public class CustomersOrdersTests
    {
        /// <summary>
        ///     Sample data to Moq the database access
        /// </summary>
        /// <returns>List of Customers orders</returns>
        private List<CustomerOrder> GetSampleData()
        {
            return new List<CustomerOrder>
            {
                new CustomerOrder
                {
                    Id = new Guid("88A96958-A302-4913-9ADC-1997B49C7571"),
                    FirstName = "John",
                    LastName = "Smith",
                    OrderId = new Guid("059FC228-6A3C-4F94-B4F5-2850B593E417"),
                    ReferenceNumber = "1",
                    OrderValue = (decimal) 50.0000000,
                    OrderDate = new DateTime(2019, 3, 12)
                }
            };
        }

        [Fact]
        public void CreateInstance_Ok()
        {
            Assert.NotNull(new CustomerOrder());
        }

        [Fact]
        public async void WhenQueryMockedDatabase_ShouldReturnResults()
        {
            Mock<ICustomerRepository> rep = new Mock<ICustomerRepository>();
            rep.Setup(s => s.GetCustomerOrdersAsync()).Returns(Task.FromResult<List<CustomerOrder>>(GetSampleData()));
            var expected = GetSampleData();
            var actual = await rep.Object.GetCustomerOrdersAsync();

            Assert.True(actual != null);
            Assert.Equal(expected.Count(), actual.Count());
        }

        [Fact]
        public void WhenSavingCustomer_ShouldReturnTrue()
        {
            Mock<ICustomerRepository> rep = new Mock<ICustomerRepository>();
            rep.Setup(s => s.SaveCustomerInfoAsync(It.IsAny<CustomerOrder>())).Returns(Task.FromResult(new PersistenceResult(true, null)));
            Assert.True(rep.Object.SaveCustomerInfoAsync(new CustomerOrder()).Result.Success);
        }

        ///// <summary>
        /////     We could do this direct test against the repository as we expect to fail before reach database
        ///// </summary>
        //[Fact]
        //public void WhenSavingNullCustomer_ShouldThrowArgumentNullException()
        //{
        //    ICustomerRepository rep = new CustomerRepository();
        //    ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => rep.SaveCustomerInfoAsync(null));
        //    Assert.Equal("CustomerOrder", exception.ParamName);
        //}

        ///// <summary>
        ///// This would be used against a production server, witch many people consider it wrong as database might change a lot
        ///// and you have to keep changing this method
        ///// </summary>
        //[Fact]
        //public void WhenQueryLiveDatabase_ShouldReturnResults()
        //{
        //    ICustomerRepository rep = new CustomerRepository();
        //    IEnumerable<CustomerOrder> results = rep.GetCustomerOrdersAsync();
        //    Assert.True(results.Any());
        //}
    }
}