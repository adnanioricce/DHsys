using Core.Entities.Catalog;
using Core.Entities.Legacy;

namespace Core.Interfaces.Catalog
{
    public interface IDrugProdutoMediator
    {
        /// <summary>
        /// Inserts a Drug and Produto entity on local and source database from a Produto object
        /// </summary>
        /// <param name="produto">The <see cref="Core.Entities.LegacyScaffold.Produto">Produto</see> entity object to save</param>
        void CreateDrugFrom(Produto produto);
        /// <summary>
        /// Updates a Drug and it's Produto entity on local and source database from a drug object
        /// </summary>
        /// <param name="drug"></param>
        void UpdateDrugFrom(Drug drug);

        /// <summary>
        /// Inserts a Drug and Produto entity on local and source database from a Drug object
        /// </summary>
        /// <param name="drug">the <see cref="Core.Entities.Catalog.Drug">Drug</see> entity object to save</param>
        void CreateDrugFrom(Drug drug);
    }
}