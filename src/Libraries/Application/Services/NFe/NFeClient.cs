using System;
using System.Threading.Tasks;
using Core.Interfaces.NFe;
using Core.Models.XML;

namespace Application.Services.NFe
{
    public class NFeClient : INFeClient
    {
                
        public Task<xNFe> GetNFeObject(string nfeKey,string cnpj)        
        {            
            throw new NotImplementedException();            
        }        
    }
}