using System;
using System.Threading.Tasks;
using ACBr.Net.NFSe;
using Core.Interfaces.NFe;
using Core.Models.XML;
namespace Application.Services.NFe
{
    public class NFeClient : INFeClient
    {
        private readonly ACBrNFSe aCBrNFSe;        

        public Task<xNFe> GetNFeObject(DateTime startDate, DateTime endDate, string nfeKey, int page, string cnpj)
        {
            //var response = aCBrNFSe.ConsultaNFSe(startDate, endDate, nfeKey, page, cnpj);
            //response.
            throw new NotImplementedException();
        }
    }
}