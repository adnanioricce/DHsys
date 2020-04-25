using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public class Cancdia
    {
        public int Id { get; set; }
        public string Filial { get; set; }
        public string Ticket { get; set; }
        public string Codemp { get; set; }
        public string Codfun { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? Datac { get; set; }
    }
}
