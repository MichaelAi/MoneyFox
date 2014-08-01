﻿using MoneyManager.ViewModels;
using MoneyManager.ViewModels.Data;
using PropertyChanged;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoneyManager.Models
{
    [ImplementPropertyChanged]
    [Table("FinancialTransactions")]
    public class FinancialTransaction
    {
        public FinancialTransaction()
        {
            Date = DateTime.Now;
        }

        private IEnumerable<Account> allAccounts
        {
            get { return new ViewModelLocator().AccountViewModel.AllAccounts; }
        }

        private IEnumerable<Category> allCategories
        {
            get { return new ViewModelLocator().CategoryViewModel.AllCategories; }
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ChargedAccountId { get; set; }

        public int TargetAccountId { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public int CategoryId { get; set; }

        public bool Cleared { get; set; }

        public int Type { get; set; }

        public string Note { get; set; }

        public bool IsRecurrence { get; set; }

        public int ReccuringTransactionId { get; set; }

        [Ignore]
        public Account ChargedAccount
        {
            get { return allAccounts.FirstOrDefault(x => x.Id == ChargedAccountId); }
            set { ChargedAccountId = value.Id; }
        }

        [Ignore]
        public Account TargetAccount
        {
            get { return allAccounts.FirstOrDefault(x => x.Id == TargetAccountId); }
            set { ChargedAccountId = value.Id; }
        }

        [Ignore]
        public Category Category
        {
            get { return allCategories.FirstOrDefault(x => x.Id == CategoryId); }
            set { CategoryId = value.Id; }
        }

        //[Ignore]
        //public RecurringTransaction RecurringTransaction
        //{
        //    get { return App.RecurrenceTransactionViewModel.AllTransactions.FirstOrDefault(x => x.Id == Id); }
        //    set { ReccuringTransactionId = value.Id; }
        //}

        [Ignore]
        public bool ClearTransactionNow
        {
            get
            {
                return Date.Date <= DateTime.Now.Date;
            }
        }
    }
}