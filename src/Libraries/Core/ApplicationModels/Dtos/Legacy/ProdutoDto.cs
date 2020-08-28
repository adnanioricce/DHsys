using System;
using System.Linq;
using Core.Entities.Legacy;

namespace Core.ApplicationModels.Dtos.Legacy
{
    public class ProdutoDto
    {
        public string Prcodi { get; set; }

        public string Prbarra { get; set; }

        public string Prreg { get; set; }

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

        public static ProdutoDto FromModel(Produto model)
        {
            return new ProdutoDto()
            {
                Prcodi = model.Prcodi, 
                Prbarra = model.Prbarra, 
                Prreg = model.Prreg, 
                Prdesc = model.Prdesc, 
                Prlote = model.Prlote, 
                Prpos = model.Prpos, 
                Prsal = model.Prsal, 
                Prneutro = model.Prneutro, 
                Prcdla = model.Prcdla, 
                Prnola = model.Prnola, 
                Prcons = model.Prcons, 
                Prconscv = model.Prconscv, 
                Prfabr = model.Prfabr, 
                Prfixa = model.Prfixa, 
                Prpromo = model.Prpromo, 
                Vlcomis = model.Vlcomis, 
                Prestq = model.Prestq, 
                Prinicial = model.Prinicial, 
                Prfinal = model.Prfinal, 
                Prtestq = model.Prtestq, 
                Prcdse = model.Prcdse, 
                Prloca = model.Prloca, 
                Prnose = model.Prnose, 
                Pretiq = model.Pretiq, 
                Coddcb = model.Coddcb, 
                Etbarra = model.Etbarra, 
                Etgraf = model.Etgraf, 
                Prpret = model.Prpret, 
                Prporta = model.Prporta, 
                Prsitu = model.Prsitu, 
                Prulte = model.Prulte, 
                Prdtul = model.Prdtul, 
                Prcddt = model.Prcddt, 
                Prdata = model.Prdata, 
                Prcdlucr = model.Prcdlucr, 
                Pricms = model.Pricms, 
                Tipo = model.Tipo, 
                DescMax = model.DescMax, 
                Comissao = model.Comissao, 
                EstMinimo = model.EstMinimo, 
                Prcdimp = model.Prcdimp, 
                Prcdimp2 = model.Prcdimp2, 
                Premb = model.Premb, 
                Prentr = model.Prentr, 
                UlVen = model.UlVen, 
                Ultped = model.Ultped, 
                Ultfor = model.Ultfor, 
                Prclas = model.Prclas, 
                Prmesant = model.Prmesant, 
                Ultpreco = model.Ultpreco, 
                Prdesconv = model.Prdesconv, 
                Prpopular = model.Prpopular, 
                Codesta = model.Codesta, 
                Prprinci = model.Prprinci, 
                Codfis = model.Codfis, 
                Secao = model.Secao, 
                Prpis = model.Prpis, 
                Prun = model.Prun, 
                Prncms = model.Prncms, 
                Prvalid = model.Prvalid, 
                Vendatu = model.Vendatu, 
                Vendant = model.Vendant, 
            }; 
        }

        public Produto ToModel()
        {
            return new Produto()
            {
                Prcodi = Prcodi, 
                Prbarra = Prbarra, 
                Prreg = Prreg, 
                Prdesc = Prdesc, 
                Prlote = Prlote, 
                Prpos = Prpos, 
                Prsal = Prsal, 
                Prneutro = Prneutro, 
                Prcdla = Prcdla, 
                Prnola = Prnola, 
                Prcons = Prcons, 
                Prconscv = Prconscv, 
                Prfabr = Prfabr, 
                Prfixa = Prfixa, 
                Prpromo = Prpromo, 
                Vlcomis = Vlcomis, 
                Prestq = Prestq, 
                Prinicial = Prinicial, 
                Prfinal = Prfinal, 
                Prtestq = Prtestq, 
                Prcdse = Prcdse, 
                Prloca = Prloca, 
                Prnose = Prnose, 
                Pretiq = Pretiq, 
                Coddcb = Coddcb, 
                Etbarra = Etbarra, 
                Etgraf = Etgraf, 
                Prpret = Prpret, 
                Prporta = Prporta, 
                Prsitu = Prsitu, 
                Prulte = Prulte, 
                Prdtul = Prdtul, 
                Prcddt = Prcddt, 
                Prdata = Prdata, 
                Prcdlucr = Prcdlucr, 
                Pricms = Pricms, 
                Tipo = Tipo, 
                DescMax = DescMax, 
                Comissao = Comissao, 
                EstMinimo = EstMinimo, 
                Prcdimp = Prcdimp, 
                Prcdimp2 = Prcdimp2, 
                Premb = Premb, 
                Prentr = Prentr, 
                UlVen = UlVen, 
                Ultped = Ultped, 
                Ultfor = Ultfor, 
                Prclas = Prclas, 
                Prmesant = Prmesant, 
                Ultpreco = Ultpreco, 
                Prdesconv = Prdesconv, 
                Prpopular = Prpopular, 
                Codesta = Codesta, 
                Prprinci = Prprinci, 
                Codfis = Codfis, 
                Secao = Secao, 
                Prpis = Prpis, 
                Prun = Prun, 
                Prncms = Prncms, 
                Prvalid = Prvalid, 
                Vendatu = Vendatu, 
                Vendant = Vendant, 
            }; 
        }
    }
}