using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat;

namespace ConsoleApp.Module6.Practice
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Client client = new Client(1, "password123"); // На практике пароль должен храниться безопасно!
            bank.CreateAccount(client, 1000); // начальный баланс

            int attempts = 3;
            while (attempts > 0)
            {
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();
                if (password == client.Password) // На практике следует использовать безопасное сравнение!
                {
                    ShowMenu(client);
                    return;
                }
                else
                {
                    attempts--;
                    Console.WriteLine($"Неверный пароль. Осталось попыток: {attempts}");
                }
            }

            Console.WriteLine("Все попытки ввода пароля исчерпаны.");
        }

        static void ShowMenu(Client client)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Проверить баланс");
                Console.WriteLine("2. Пополнить счет");
                Console.WriteLine("3. Снять деньги");
                Console.WriteLine("4. Выход");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Ваш баланс: {client.Account.Balance}");
                        break;
                    case "2":
                        Console.Write("Введите сумму для пополнения: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            client.Account.Deposit(depositAmount);
                            Console.WriteLine($"Счет пополнен на {depositAmount}. Текущий баланс: {client.Account.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("Неверная сумма.");
                        }
                        break;
                    case "3":
                        Console.Write("Введите сумму для снятия: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        {
                            if (client.Account.TryWithdraw(withdrawAmount))
                            {
                                Console.WriteLine($"Снято {withdrawAmount}. Текущий баланс: {client.Account.Balance}");
                            }
                            else
                            {
                                Console.WriteLine("Недостаточно средств на счету.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверная сумма.");
                        }
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Выберите действие из списка.");
                        break;
                }
            }
        }
    }
}
