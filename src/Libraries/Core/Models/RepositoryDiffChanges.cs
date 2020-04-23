using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class RepositoryDiffChanges
    {
        /// <summary>
        /// file Paths to the files changed
        /// </summary>
        public IEnumerable<string> Paths { get; set; }
        /// <summary>
        /// Flag indicating if repository has any change
        /// </summary>
        public bool HasChanged { get; set; }
        /// <summary>
        /// When commit was writed
        /// </summary>
        public DateTime When { get; set; }
    }
}
