﻿using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Infrastructure.Logging
{
    public static class AppLogger 
    {
        public readonly static Serilog.ILogger Log = Serilog.Log.Logger;        
    }    
}
