using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    /* 
        * 6.	Задача на взаимодействие между классами. Разработать систему «Платежи». 
        * Клиент имеет Счет в банке и Банковскую карту (КК). Клиент может оплатить Заказ, сделать платеж на другой Счет, 
        * заблокировать КК и аннулировать Счет. Администратор может заблокировать КК за превышение платежа.
    */

    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public CreditCard CreditCard { get; set; }
    }

    public class CreditCard
    {
        public string CardNumber { get; set; }
        public bool IsBlocked { get; set; }
    }

    public class Payment
    {
        public decimal Amount { get; set; }
        public Account Sender { get; set; }
        public Account Receiver { get; set; }
    }

    public class System
    {
        public void MakePayment(Account sender, Account receiver, decimal amount)
        {
            if (sender.CreditCard.IsBlocked)
            {
                Console.WriteLine("Оплата не произведена. Кредитная карта заблокирована.");
                return;
            }

            if (sender.Balance < amount)
            {
                Console.WriteLine("Оплата не произведена. Недостаточно средств.");
                return;
            }

            sender.Balance -= amount;
            receiver.Balance += amount;

            Console.WriteLine($"Выплата {amount} от {sender.AccountNumber} для {receiver.AccountNumber} выполнена.");
        }

        public void BlockCard(Account account)
        {
            account.CreditCard.IsBlocked = true;
            Console.WriteLine($"Кредитная карта {account.CreditCard.CardNumber} заблокирована.");
        }
    }

    public class Program
    {
        public static void Main()
        {
            System paymentSystem = new System();

            Account account1 = new Account
            {
                AccountNumber = "12345678",
                Balance = 1000,
                CreditCard = new CreditCard { CardNumber = "1111-2222-3333-4444" }
            };

            Account account2 = new Account
            {
                AccountNumber = "87654321",
                Balance = 500,
                CreditCard = new CreditCard { CardNumber = "4444-3333-2222-1111" }
            };

            paymentSystem.MakePayment(account1, account2, 200);
            paymentSystem.BlockCard(account1);
            paymentSystem.MakePayment(account1, account2, 200);
        }
    }
}
