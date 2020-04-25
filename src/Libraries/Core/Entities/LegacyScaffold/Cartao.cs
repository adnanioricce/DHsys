﻿using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public class Cartao
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Prazo { get; set; }
        public string Parcel { get; set; }
        public double? Qtde { get; set; }
        public double? Taxa { get; set; }
    }
}
