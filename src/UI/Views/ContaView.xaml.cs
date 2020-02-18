using Core.Entities;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI.Views
{
    /// <summary>
    /// Interação lógica para ContaView.xam
    /// </summary>
    public partial class ContaView : Page
    {
        private readonly Repository<Conta> _contaRepository = new Repository<Conta>(new MainContext());
        public ContaView()
        {
            InitializeComponent();
        }
        public void OnSearch(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSearchBox.Text))
            {
                string query = $"SELECT * FROM Contas WHERE NomeEmpresa LIKE %{this.txtSearchBox}%";
                var contas = _contaRepository.Query()
                .Where(c => EF.Functions.Like(c.NomeEmpresa, "%" + txtSearchBox.Text + "%"))
                .ToList();
                this._dataGrid.ItemsSource = contas;
            }
            else
            {
                this._dataGrid.ItemsSource = _contaRepository.GetAll();
            }
        }
    }
}
