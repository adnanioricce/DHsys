using Core.Entities.POS;
namespace Core.Interfaces.POS
{
    /// <summary>
    /// Mediates the communication between the <see cref="CashDrawer"/> and the real cash drawer device
    /// </summary>
    public interface ICashDrawerMediator
    {
        bool Open();
        bool Close();
    }
}
