using System.Threading.Tasks;
using Core.Models.XML;

namespace Core.Interfaces.NFe
{
    public interface INFeClient
    {
        Task<xNFe> GetNFeObject(string nfeKey,string cnpj);
    }
}