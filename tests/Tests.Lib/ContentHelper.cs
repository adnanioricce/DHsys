﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Tests.Lib
{
    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj) => new(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
    }
}
