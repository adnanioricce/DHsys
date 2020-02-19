using System.Threading.Tasks;

namespace UI.Interfaces
{
    public interface IActivable
    {
        Task ActivateAsync(object parameter);
    }
}
