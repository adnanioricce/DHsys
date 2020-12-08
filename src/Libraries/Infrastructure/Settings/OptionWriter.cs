using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Settings
{
	public class OptionWriter<T> : IWritableOptions<T> where T : class,new()
	{
		private readonly IHostEnvironment _environment;		
        private readonly IOptionsMonitor<T> _options;
        private readonly string _file;
        //private readonly string _section;
		public OptionWriter(IHostEnvironment environment,
                      IOptionsMonitor<T> options,
                      string file)
		{
			_environment = environment;			
			_file = file;
            _options = options;
		}

        public T Value => _options.CurrentValue;
        public T Get(string name) => _options.Get(name);

        public void Update(Action<T> applyChanges)
        {
            var fileProvider = _environment.ContentRootFileProvider;
            var fileInfo = fileProvider.GetFileInfo(_file);
            var physicalPath = fileInfo.PhysicalPath;

            var jObject = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(physicalPath));
            var sectionObject = jObject.TryGetValue(typeof(T).Name, out JToken section) ?
                JsonConvert.DeserializeObject<T>(section.ToString()) : (Value ?? new T());
            
            applyChanges(sectionObject);

            jObject[typeof(T).Name] = JObject.Parse(JsonConvert.SerializeObject(sectionObject));
            File.WriteAllText(physicalPath, JsonConvert.SerializeObject(jObject, Formatting.Indented));
        }
    }
}
