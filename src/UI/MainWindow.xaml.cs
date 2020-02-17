using Core.Entities;
using DAL;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        private readonly MainContext _context = new MainContext();
        public MainWindow()
        {
            InitializeComponent();            
            //var connStringBuilder = new SqliteConnectionStringBuilder();
            //connStringBuilder.DataSource = "./conta.db";
            //using (var connection = new SqliteConnection(connStringBuilder.ConnectionString))
            //{                
            //    //Create a table (drop if already exists first):                                                
            //    var createTableCmd = connection.CreateCommand();
            //    createTableCmd.CommandText = "CREATE TABLE IF NOT EXISTS Contas(Id INTEGER PRIMARY KEY AUTOINCREMENT,NomeEmpresa VARCHAR(255),DataDeVencimento text,valor DECIMAL(10,2))";
            //    createTableCmd.ExecuteNonQuery();
            //}
        }
        public List<Conta> MapContas(SqliteCommand command)
        {
            var contas = new List<Conta>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    contas.Add(new Conta
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        DataDeVencimento = reader["DataDeVencimento"].ToString(),
                        NomeEmpresa = reader["NomeEmpresa"].ToString(),
                        Valor = decimal.Parse(reader["valor"].ToString())
                    });
                }
            }
            return contas;
        }
        public void OnSearch(object sender,TextChangedEventArgs e)
        {
            string query = $"SELECT * FROM Contas WHERE NomeEmpresa LIKE %{this.txtSearchBox}%";
            

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
