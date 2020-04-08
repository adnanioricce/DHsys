using Core.Services;
using LibGit2Sharp;
using System;
using System.IO;
using System.Linq;
using Xunit;
using Microsoft.Extensions.Options;
using Infrastructure.Settings;
using Infrastructure.Services;

namespace Api.IntegrationTests.Clients
{
    public class GitRepositoryManagerTest
    {
        private readonly IOptions<GitSettings> _gitConfig;
        public GitRepositoryManagerTest(IOptions<GitSettings> gitConfig)
        {
            _gitConfig = gitConfig;
        }
        [Fact]
        public void GetDiff_NoArgumentsTwoCommitsWrited_ShouldReturnOnlyFilesThatChangedSinceLastCommit()
        {
            //Given                               
            //create repo directory
            string randomPath = $"./Data/repo-{Guid.NewGuid().ToString()}/";
            Directory.CreateDirectory(randomPath);            
            string rootedPath = Repository.Init(randomPath);
            var gitSettings = Options.Create<GitSettings>(new GitSettings { RepositoryPath = randomPath });
            //Add content to diff 
            string pathToFile = randomPath + "/file.txt";
            string pathToSeconfFile = randomPath + "/file-2.txt";
            string fileContent = "some test content";
            File.WriteAllText(pathToFile, fileContent);            
            //writing changes
            var repo = new Repository(rootedPath);
            var signature = new Signature(_gitConfig.Value.Username, _gitConfig.Value.Email, DateTimeOffset.UtcNow);
            Commands.Stage(repo, "*");
            repo.Commit("first message", signature, signature);            
            File.WriteAllText(pathToSeconfFile, fileContent);
            Commands.Stage(repo, "*");
            repo.Commit("second message", signature, signature);            
            //now to the repo manager
            var repoManager = new GitRepositoryManager(gitSettings);                                    
            //When
            var diffResult = repoManager.GetDiff();
            //Then
            var filesChanged = diffResult.Paths.ToArray();
            Assert.True(diffResult.HasChanged);
            Assert.Equal(new[] { 
                "file-2.txt"
            },filesChanged);            
            Assert.True(filesChanged.All(f => File.Exists($"{randomPath}{f}")));                                        
        }
        [Fact]
        public void GetStatus_NoArgumentsTwoFilesAdded_ShouldReturnAllFilesAddedAndModified()
        {
            //Given            
            string randomPath = $"./Data/repo-{Guid.NewGuid().ToString()}/";
            var gitSettings = Options.Create<GitSettings>(new GitSettings
            {
                RepositoryPath = randomPath
            });
            var repo = CreateRandomRepository(randomPath);            
            WriteTestFile(randomPath);
            WriteTestFile(randomPath);
            //TODO:Pass gitSettings instead
            var repoManager = new GitRepositoryManager(gitSettings);
            //When
            var changes = repoManager.GetStatus();
            //Then
            Assert.True(changes.HasChanged);
            Assert.Equal(2, changes.Paths.Count());
            Assert.True(changes.Paths.All(p => File.Exists($"{randomPath}{p}")));
        }
        private Repository CreateRandomRepository(string randomPath)
        {            
            Directory.CreateDirectory(randomPath);
            string rootedPath = Repository.Init(randomPath);
            return new Repository(rootedPath);
        }
        private void WriteTestFile(string randomPath)
        {
            string pathToFile = $"{randomPath}/{Guid.NewGuid().ToString()}";
            string fileContent = "some test content";
            File.WriteAllText(pathToFile, fileContent);
        }
    }
}