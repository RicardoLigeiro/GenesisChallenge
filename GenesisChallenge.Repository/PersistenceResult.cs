using System.Collections.Generic;

namespace GenesisChallenge.Repository
{
    /// <summary>
    ///     This will just return the result for the persistence acts against the database
    /// </summary>
    public class PersistenceResult
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public PersistenceResult(bool success, IEnumerable<string> errors)
        {
            Success = success;
            Errors = errors;
        }

        /// <summary>
        ///     Did the save went well?
        /// </summary>
        public bool Success { get; }

        /// <summary>
        ///     List of errors
        /// </summary>
        public IEnumerable<string> Errors { get; }
    }
}