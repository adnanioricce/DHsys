namespace Infrastructure.Interfaces
{
    ///<summary>
    /// handles input from barcode scanner to application 
    ///</summary>
    public interface IScanner
    {
        // event EventHandle<>
        T GetEntityFromBarCode<T>(string barcode);
    }
}