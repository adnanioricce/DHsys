using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Media
{
    public class MediaResource : BaseEntity
    {        
        public long Size { get; set; }
        public MediaType Type { get; set; }
        public string SourceUrl { get; set; }
        public string Caption { get; set; }
    }
}
