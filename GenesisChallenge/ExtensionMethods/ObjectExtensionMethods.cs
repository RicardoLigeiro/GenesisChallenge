using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GenesisChallenge.ExtensionMethods
{
    /// <summary>
    ///     Extension methods for objects
    /// </summary>
    public static class ObjectExtensionMethods
    {

        /// <summary>
        ///     This method will produce a deep clone of an object
        /// </summary>
        /// <typeparam name="T"> Object Type </typeparam>
        /// <param name="source"> Source object </param>
        /// <returns> An object exactly like the source </returns>
        public static T Clone<T>(this T source)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, source);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}