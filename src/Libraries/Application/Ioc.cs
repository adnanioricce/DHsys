using System.Data;
using Core.Interfaces;
using Serilog;

namespace Application
{    
    /// <summary>
    /// Delegate to resolve different implementations of one interface
    /// </summary>
    /// <param name="key">the key value associated with the implementation</param>
    /// <returns>a IDbConnection implementation</returns>
    public delegate IDbConnection ConnectionResolver(string key);    
}