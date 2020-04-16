using System.ComponentModel;

namespace UI.Models
{
    public class ContaModel : GalaSoft.MvvmLight.ObservableObject
    {
        private string _nomeEmpresa = string.Empty;
        public string NomeEmpresa { get { return _nomeEmpresa; } set { this.Set(nameof(this.NomeEmpresa), ref this._nomeEmpresa, value); } }
        private string _dataDeVencimento = string.Empty;
        public string DataDeVencimento { get { return _dataDeVencimento; } set { this.Set(nameof(this._dataDeVencimento), ref this._dataDeVencimento, value); } }
        private decimal _valor = decimal.Zero;
        public decimal Valor { get { return _valor; } set { this.Set(nameof(this.Valor), ref _valor, value); } }
        private bool _estaPago = false;
        public bool EstaPago { get { return _estaPago; } set { this.Set(nameof(this.EstaPago), ref _estaPago, value); } }
    }
}
