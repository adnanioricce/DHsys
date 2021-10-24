using System;

namespace Example.Plugin
{
    public class GrettingsService
    {
        public string GreetNameWithDate(string name){
            var date = DateTime.Now;
            return $"Hello {name}, now is {date.ToLocalTime()} Today is {date.ToShortDateString()} ";
        }
    }
}
