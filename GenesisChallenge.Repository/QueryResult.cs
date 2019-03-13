using System.Collections.Generic;

namespace GenesisChallenge.Repository
{
    /// <summary>
    ///     Outputs the results of the query
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class QueryResult<T>
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public QueryResult(int numberOfRecords, IEnumerable<T> records)
        {
            NumberOfRecords = numberOfRecords;
            Records = records;
        }

        /// <summary>
        ///     Total number of records
        /// </summary>
        public int NumberOfRecords { get; }

        /// <summary>
        ///     The results list
        /// </summary>
        public IEnumerable<T> Records { get; }
    }
}