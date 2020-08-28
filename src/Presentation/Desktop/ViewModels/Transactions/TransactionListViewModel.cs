using AutoMapper;
using Core.Entities.Financial;
using Core.Interfaces.Financial;
using Desktop.Models.Financial;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Desktop.ViewModels.Transactions
{
    public class TransactionListViewModel : ViewModelBase
    {
        private readonly ITransactionService _transacionService;
        private readonly IMapper _mapper;
        //used internally to update front transaction to show on UI
        private IEnumerable<Transaction> BackTransactions = new List<Transaction>();
        public ObservableCollection<TransactionModel> FrontTransactions { get; set; } = new ObservableCollection<TransactionModel>();
        public RelayCommand LoadCommand { get; set; }
        public RelayCommand<DateTimeOffset> GetTransactionsByDateCommand { get; set; }
        public TransactionListViewModel(ITransactionService transactionService,
            IMapper mapper)
        {
            _transacionService = transactionService;
            _mapper = mapper;
            LoadCommand = new RelayCommand(async () => await Load());
            GetTransactionsByDateCommand = new RelayCommand<DateTimeOffset>(ExecuteGetTransactionsByDate);
        }
        public async Task Load()
        {
            BackTransactions = await _transacionService.GetTodayTransactionsAsync();
            foreach(var transaction in BackTransactions)
            {
                FrontTransactions.Add(_mapper.Map<Transaction,TransactionModel>(transaction));
            }
        }
        public void ExecuteGetTransactionsByDate(DateTimeOffset date)
        {            
            var transactionsByDate = BackTransactions.Where(t => t.CreatedAt.Day == date.Day);
            var nextCollection = new ObservableCollection<TransactionModel>();
            foreach (var transaction in transactionsByDate)
            {
                nextCollection.Add(_mapper.Map<Transaction,TransactionModel>(transaction));
            }
            FrontTransactions = nextCollection;
        }        
    }
}
