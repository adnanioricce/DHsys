using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public partial class Reconst
    {
        public int Id { get; set; }
        public string Arquivo { get; set; }
        public string Posicao { get; set; }
        public DateTime? Data { get; set; }
        public string Necessita { get; set; }
    }
}
