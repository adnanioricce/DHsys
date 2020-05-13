using System;
using System.Threading.Tasks;
using Core.Models.XML;

namespace Core.Interfaces.NFe
{
    public interface INFeClient
    {
        Task<xNFe> GetNFeObject(DateTime startDate,DateTime endDate, string nfeKey,int page,string cnpj);
    }
}