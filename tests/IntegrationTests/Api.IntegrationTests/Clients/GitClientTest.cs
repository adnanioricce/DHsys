namespace Api.IntegrationTests.Clients
{
    public class GitRepositoryManagerTest
    {
        [Fact]
        public void GetFilesChangedSinceLastCommit_NoArguments_ShouldReturnOnlyFilesThatChangedSinceLastCommit()
        {
            //Given
            // var repository = 
            var repoManager = new GitRepositoryManager("path/to/git/repository");
            //When
            var filesChanged = repoManager.GetFilesChangedSinceLastCommit();            
            //Then
            Assert.Equal(2,filesChanged.Files.Count);            
        }
        
    }
}