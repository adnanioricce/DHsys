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
        /// Runs git status and return object with list of files modified and added, if repository has no change, HasChange is equal false and returned paths is null
        /// </summary>
        /// <returns>RepositoryDiffChanges with HasChange and file paths</returns>
        RepositoryDiffChanges GetStatus();
        /// <summary>
        /// runs "git add ." on watched repository
        /// </summary>
        void AddChanges();
    }
}
