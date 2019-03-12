using System;
using System.ComponentModel.DataAnnotations;

namespace GenesisChallenge.Entities
{
    /// <summary>
    ///     This represents a customer order
    ///     This is a simple implementation as to satisfy the challenge,
    ///     since we don't have to deal with orders and customers independently
    /// </summary>
    [Serializable]
    public class CustomerOrder
    {
        /// <summary>
        ///     Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     First Name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        ///     Last Name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        ///     Customer Name
        /// </summary>
        public string CustomerName => $"{FirstName} {LastName}";

        /// <summary>
        ///     Order Id
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        ///     Reference Number
        /// </summary>
        public string ReferenceNumber { get; set; }

        /// <summary>
        ///     Order Value
        /// </summary>
        public decimal OrderValue { get; set; }

        /// <summary>
        ///     Order Date
        /// </summary>
        public DateTime OrderDate { get; set; }
    }
}