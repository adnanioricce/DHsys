﻿using System;
using System.Collections.Generic;

namespace Core.Entities.Legacy
{
    public class Clicheq : BaseEntity
    {        
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime? Datanasc { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Fone { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
    }
}