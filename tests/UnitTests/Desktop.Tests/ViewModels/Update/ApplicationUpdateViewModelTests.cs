using Desktop.ViewModels.Update;
using Infrastructure.Interfaces;
using Moq;
using System;
using Xunit;

namespace Desktop.Tests.ViewModels.Update
{
    public class ApplicationUpdateViewModelTests
    {                
        public ApplicationUpdateViewModelTests()
        {            
        }
        private IUpdater GetFakeUpdater()
        {
            var fakeUpdater = new Mock<IUpdater>();
            fakeUpdater.Setup(m => m.ConfigureUpdater())
                .Callback(() => Console.WriteLine("working?"));
            return fakeUpdater.Object;
        }
        private ApplicationUpdateViewModel CreateViewModel()
        {
            return new ApplicationUpdateViewModel(GetFakeUpdater());
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var viewModel = this.CreateViewModel();

            // Act
            //viewModel.ConfigureUpdaterCommand.Execute();

            // Assert
            //Assert.True(false);            
        }
    }
}
