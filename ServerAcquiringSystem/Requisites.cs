using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceModul
{
    internal class Requisites
    {
        public int PersonID { get; }
        public int AccountID { get; }
        public int Pincode { get; }
        public int Account { get; }
        public int Balalce { get; }

        public Requisites(int balance, int account)
        {
            this.Balalce = balance;
            this.Account = account;
        }
    }
}
