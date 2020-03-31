namespace UI.Models
{
    public class ProdutoModel 
    {
        public string Codigo { get; set; }
        public int Quantidade { get; set; }
        public string CodigoDeBarras { get; set; }
        public string NCM { get; set; }
        public string Descricao { get; set; }
        public string Laboratorio { get; set; }
        public string Subsecao { get; set; }
        public string Portaria { get; set; }
        public string Bematech { get; set; }
        public string Daruma { get; set; }
        public decimal ICMS { get; set; } // <- string
        public string RegistroMs { get; set; }
        public string DCB { get; set; }
        public string DescontoMaximo { get; set; }
        public string RepassaDescCoV { get; set; }
        public string Un { get; set; }
        public string Comissao { get; set; }
        public string Fixa { get; set; }
        public string Localizacao { get; set; }
        public string Condicao { get; set; } // -> Enum
        public string Ate { get; set; } // -> DateTime
        public int EstoqueMinimo { get; set; }
        public int Embalagem { get; set; }
        public decimal PrecoFabrica { get; set; }
        public decimal Margem { get; set; }
        public decimal PrecoConsumidor { get; set; }
        public decimal PrecoAPrazo { get; set; }
        public string EtiquetaPadrao { get; set; } // -> bool
        public string EtiquetaBarras { get; set; }
        public string EtiquetaGrafica { get; set; }
        public string CodigoPadrao { get; set; }
        public string FarmaciaPopular { get; set; }
        public string IsencaoPISOuCONFISN { get; set; }
        public string Sal { get; set; }
    }
}
