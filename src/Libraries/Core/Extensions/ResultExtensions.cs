using Core.Models.Results;
using System;
using System.Threading.Tasks;

namespace Core.Extensions
{
    /// <summary>
    /// Map the result to another that represents either a Success or a Failure
    /// </summary>
    /// <param name="result">the <see cref="Result"/> to transform</param>
    /// <returns>Either a Success or Failure <see cref="Result"/></returns>
    public delegate Result TrailResult(Result result);
    public static class ResultExtensions
    {
        public static Result OnSuccess(this Result result,TrailResult onSuccessFunc)
        {
            if (!result.Success || onSuccessFunc is null)
                return result;
            return onSuccessFunc(result);
        }
        public static Result OnFailure(this Result result,TrailResult onFailureFunc)
        {
            if(result.Success || onFailureFunc is null)
                return result;
            return onFailureFunc(result);
        }        
    }
}
