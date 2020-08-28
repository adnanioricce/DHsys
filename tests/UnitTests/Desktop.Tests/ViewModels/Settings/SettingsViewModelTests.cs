using Desktop.ViewModels.Settings;
using Desktop.ViewModels.Update;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Moq;
using System.Threading.Tasks;
using Xunit;
namespace Desktop.Tests.ViewModels.Settings
{
    public class SettingsViewModelTests
    {
        [Fact]
        public void Given_ViewModel_Master_With_Multiple_Settings_ViewModel_When_User_Chooses_A_Section_Of_Settings_Then_Change_Settings_ViewModel_DataContext_To_Specified_ViewModel()
        {
            //Given 
            var targetViewModel = new ApplicationUpdateViewModel(GetFakeUpdater());
            var masterViewModel = new SettingsViewModel();
            //When
            masterViewModel.ChangeSectionViewModelCommand.Execute(targetViewModel);
            //Then
            Assert.Equal(targetViewModel, masterViewModel.CurrentSectionViewModel);
        }
        private IUpdater GetFakeUpdater()
        {
            var mockUpdater = new Mock<IUpdater>();
            mockUpdater.Setup(m => m.Update())
                .Returns(Task.FromResult(Task.Delay(0)));            
            return mockUpdater.Object;
        }
    }
}
