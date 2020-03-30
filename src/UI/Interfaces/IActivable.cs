using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IActivable
    {
        Task ActivateAsync(object parameter);
    }
}
