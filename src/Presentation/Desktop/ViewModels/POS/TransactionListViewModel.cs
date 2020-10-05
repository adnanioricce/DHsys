﻿using AutoMapper;
using Core.Entities.Financial;
using Core.Interfaces.Financial;
using Desktop.Models.POS;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Desktop.ViewModels.POS
{
    public class TransactionListViewModel : ViewModelBase
    {
        private readonly ITransactionService _transacionService;
        private readonly IMapper _mapper;
        //used internally to update front transaction to show on UI
        private IEnumerable<POSOrder> BackTransactions = new List<POSOrder>();
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
            var transactions = _transacionService.GetTodayTransactionsAsync();
            await foreach(var transaction in transactions)
            {
                BackTransactions.Append(transaction);
                FrontTransactions.Add(_mapper.Map<POSOrder,TransactionModel>(transaction));
            }
        }
        public void ExecuteGetTransactionsByDate(DateTimeOffset date)
        {            
            var transactionsByDate = BackTransactions.Where(t => t.CreatedAt.Day == date.Day);
            var nextCollection = new ObservableCollection<TransactionModel>();
            foreach (var transaction in transactionsByDate)
            {
                nextCollection.Add(_mapper.Map<POSOrder,TransactionModel>(transaction));
            }
            FrontTransactions = nextCollection;
        }        
    }
}
