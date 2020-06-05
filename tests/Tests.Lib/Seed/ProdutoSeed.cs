using Core.Entities.Legacy;

namespace Tests.Lib.Seed
{
    public class ProdutoSeed
    {
        public static Produto BaseCreateProdutoEntity(){
            return new Produto
            {
                Prcodi = "123456",
                Prbarra = "1234567890123",
                Prdesc = "Dipirona GTS 5mg",
                Pricms = 18,
                EstMinimo = 1,
                Prestq = 3,
                Premb = 1,
                Prncms = "3000333333",
                Prfabr = 4.24,
                Prcons = 12.50,
                DescMax = 20,
                Prprinci = "some principle",
                Secao = "",
                Ultfor = "Fornecedor"
            };
        }
    }
}