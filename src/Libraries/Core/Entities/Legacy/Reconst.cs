using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public  class Reconst : BaseEntity
    {
        
        public string ArqCorevo { get; set; }
        public string Posicao { get; set; }
        public DateTime? Data { get; set; }
        public string Necessita { get; set; }
    }
}
