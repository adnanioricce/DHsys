using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Logsys : BaseEntity
    {
        
        public DateTime? Data { get; set; }
        public string Usuario { get; set; }
        public string Time { get; set; }
        public string Nivel { get; set; }
        public string Opcao { get; set; }
    }
}
