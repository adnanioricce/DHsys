using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Logsys
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public string Usuario { get; set; }
        public string Time { get; set; }
        public string Nivel { get; set; }
        public string Opcao { get; set; }
    }
}
