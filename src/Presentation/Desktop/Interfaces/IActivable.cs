using System.Threading.Tasks;

namespace Desktop.Interfaces
{
    public interface IActivable
    {
        Task ActivateAsync(object parameter);
    }
}
