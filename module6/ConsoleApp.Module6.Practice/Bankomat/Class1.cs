using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Bank
    {
        private static int nextAccountId = 1;

        public Account CreateAccount(Client client, decimal initialBalance)
        {
            var account = new Account(nextAccountId++, client, initialBalance);
            client.Account = account;
            return account;
        }
    }

    public class Client
    {
        public int Id { get; }
        public string Password { get; set; }
        public Account Account { get; set; }

        public Client(int id, string password)
        {
            Id = id;
            Password = password;
        }
    }

    public class Account
    {
        public int AccountNumber { get; }
        public Client Owner { get; }
        public decimal Balance { get; private set; }

        public Account(int accountNumber, Client owner, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool TryWithdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
