using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ApiModels
{
    public class SyncDatabaseRequest
    {
        public string FileName { get; set; }
        public Dictionary<int, RecordDiff> RecordDiffs { get; set; } = new Dictionary<int, RecordDiff>();

    }
}
