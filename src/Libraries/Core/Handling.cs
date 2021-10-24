using System;

namespace Core
{
    //TODO:
    public static class Handling
    {
        public static TOut Try<TOut>(Func<TOut> func)
        {
            try
            {
                return func();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public static TOut TryCatch<TOut,TException>(Func<TOut> func,Action<Exception> handleException)
        {
            try
            {
                return func();
            }
            catch(Exception ex)
            {
                handleException(ex);
                return default;
            }
        }
        public static void TryCatch<TOut>(Func<TOut> func,Action<Exception> handleException)
        {

        }
    }
}
