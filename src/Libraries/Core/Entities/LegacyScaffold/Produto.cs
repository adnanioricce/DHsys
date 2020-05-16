using System;
using System.Collections.Generic;

namespace Core.Entities.LegacyScaffold
{
    public  class Produto : BaseEntity
    {        
        /// <summary>
        /// Get or set the Unique Code identification field for the current Produto object
        /// </summary>
        /// <value></value>
        public string Prcodi { get; set; }
        /// <summary>
        /// Get or set the Barcode for the current produto object
        /// </summary>
        /// <value></value>
        public string Prbarra { get; set; }
        public string Prreg { get; set; }
        /// <summary>
        /// Get or set the current name for the current <see cref="Core.Entities.LegacyScaffold.Produto"/> object
        /// </summary>
        /// <value></value>
        public string Prdesc { get; set; }
        public string Prlote { get; set; }
        public string Prpos { get; set; }
        public string Prsal { get; set; }
        public string Prneutro { get; set; }
        public string Prcdla { get; set; }
        public string Prnola { get; set; }
        public double? Prcons { get; set; }
        public double? Prconscv { get; set; }
        public double? Prfabr { get; set; }
        public string Prfixa { get; set; }
        public double? Prpromo { get; set; }
        public double? Vlcomis { get; set; }
        public double? Prestq { get; set; }
        public double? Prinicial { get; set; }
        public double? Prfinal { get; set; }
        public double? Prtestq { get; set; }
        public string Prcdse { get; set; }
        public string Prloca { get; set; }
        public string Prnose { get; set; }
        public string Pretiq { get; set; }
        public string Coddcb { get; set; }
        public string Etbarra { get; set; }
        public string Etgraf { get; set; }
        public string Prpret { get; set; }
        public string Prporta { get; set; }
        public string Prsitu { get; set; }
        public double? Prulte { get; set; }
        public DateTime? Prdtul { get; set; }
        public DateTime? Prcddt { get; set; }
        public DateTime? Prdata { get; set; }
        public double? Prcdlucr { get; set; }
        public double? Pricms { get; set; }
        public string Tipo { get; set; }
        public double? DescMax { get; set; }
        public double? Comissao { get; set; }
        public double? EstMinimo { get; set; }
        public string Prcdimp { get; set; }
        public string Prcdimp2 { get; set; }
        public double? Premb { get; set; }
        public double? Prentr { get; set; }
        public DateTime? UlVen { get; set; }
        public DateTime? Ultped { get; set; }
        public string Ultfor { get; set; }
        public string Prclas { get; set; }
        public double? Prmesant { get; set; }
        public double? Ultpreco { get; set; }
        public string Prdesconv { get; set; }
        public string Prpopular { get; set; }
        public string Codesta { get; set; }
        public string Prprinci { get; set; }
        public string Codfis { get; set; }
        public string Secao { get; set; }
        public string Prpis { get; set; }
        public string Prun { get; set; }
        public string Prncms { get; set; }
        public DateTime? Prvalid { get; set; }
        public double? Vendatu { get; set; }
        public double? Vendant { get; set; }
    }
}
