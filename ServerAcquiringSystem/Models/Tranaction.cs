using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceModul.Models
{
    internal class Transaction
    {
        public int TransactionID { get; }
        public int AccountID { get; }
        public DateTime TransactionDate { get; }
        public bool TransactionType { get; }
        public int Amount { get; }
    }
}
