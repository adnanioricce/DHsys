using Core.Interfaces;
using Core.Models;
using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{
    public class GitRepositoryManager : IGitRepositoryManager
    {
        private readonly LibGit2Sharp.Repository _gitRepository;
        private readonly List<Commit> _commits;
        public GitRepositoryManager(string repositoryPath)
        {
            _gitRepository = new LibGit2Sharp.Repository(repositoryPath);
            if (!(_gitRepository.Head.Tip is null))
            {
                _commits = _gitRepository.Commits.ToList();
            }
        }

        public void AddChanges()
        {
            //_gitRepository.Commits.(c => c.Committer.When)
            Commands.Stage(_gitRepository, "*");                                    
        }        
        public void CommitChanges()
        {            
            var lastCommit = _gitRepository.Commits.Last();
            if (_commits.Count != _gitRepository.Commits.Count())
            {
                _commits.Add(lastCommit);
            }
        }
        public RepositoryDiffChanges GetDiff()
        {         
            if(_commits is null)
            {
                return new RepositoryDiffChanges
                {
                    HasChanged = false,
                    Paths = null
                };
            }
            var paths = _gitRepository.Diff.Compare<TreeChanges>(_commits[^1].Tree, DiffTargets.Index | DiffTargets.WorkingDirectory)
                .Where(d => d.Status == ChangeKind.Modified || d.Status == ChangeKind.Added)
                .Select(d => d.Path);

            if (!(paths.Any()))
            {
                return new RepositoryDiffChanges
                {
                    HasChanged = false,
                    Paths = null
                };
            }
            return new RepositoryDiffChanges
            {
                HasChanged = true,
                Paths = paths
            };
        }
        public RepositoryDiffChanges GetStatus()
        {
            var status = _gitRepository.RetrieveStatus();
            if(!(status.Any()))
            {
                return new RepositoryDiffChanges { HasChanged = false, Paths = null };
            }
            return new RepositoryDiffChanges {
                HasChanged = true,
                Paths = status.Select(p => p.FilePath)
            };
        }
    }
}
