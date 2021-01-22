using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Entities;
using Newtonsoft.Json;

namespace Infrastructure.Helpers
{
    public static class DataReaders
    {
        /// <summary>
        /// Group the json file entries in fractions of a max of 512 entries(counting from the highest node)
        /// </summary>
        /// <typeparam name="T">The entity type to be parsed from json</typeparam>
        /// <param name="jsonPath">The path to the json file</param>
        /// <returns>a <see cref="IEnumerable{T}"/> of grouped <see cref="T"/></returns>
        public static IEnumerable<T[]> GetDataChunked<T>(string jsonPath) where T : BaseEntity
        {
            var items = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(jsonPath));
            var chunkSize = (int)MathF.Round((items.Count * 0.1f), MidpointRounding.AwayFromZero);
            if (chunkSize > 512)
            {
                chunkSize = 512;
            }
            return items.Select((item, index) => new { Item = item, Index = index })
                        .GroupBy(i => i.Index / chunkSize, v => v.Item)
                        .Select(chunk => chunk.ToArray());
        }
    }
}