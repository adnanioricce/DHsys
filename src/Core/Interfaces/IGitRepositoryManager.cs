using Core.Models;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IGitRepositoryManager
    {
        /// <summary>
        /// Runs git diff between last commit and HEAD, and return string paths of files changed
        /// </summary>
        /// <returns></returns>
        RepositoryDiffChanges GetDiff();
        /// <summary>
        /// runs "git add ." on watched repository
        /// </summary>
        void AddChanges();
    }
}
