using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Account> accounts = new List<Account>();

    static void Main()
    {
        InitializeAccounts();

        Console.WriteLine("Welcome to the ATM!");
        Console.WriteLine("Please enter your card number: ");
        string cardNumber = Console.ReadLine();

        Console.WriteLine("Please enter your PIN: ");
        string pin = Console.ReadLine();

        Account currentAccount = AuthenticateUser(cardNumber, pin);

        if (currentAccount != null)
        {
            Console.WriteLine($"Welcome, {currentAccount.FirstName} {currentAccount.LastName}!");

            int option = 0;

            do
            {
                PrintOptions();

                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            CheckBalance(currentAccount);
                            break;
                        case 2:
                            Deposit(currentAccount);
                            break;
                        case 3:
                            Withdraw(currentAccount);
                            break;
                        case 4:
                            Console.WriteLine("Thank you for using the ATM. Have a great day!");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            } while (option != 4);
        }
        else
        {
            Console.WriteLine("Authentication failed. Please check your card number and PIN.");
        }
    }

    static void InitializeAccounts()
    {
        accounts.Add(new Account("Angeles", "Kyle Charles", "1234567890123456", "1234", 1000.0));
        accounts.Add(new Account("Justine", "Panopio", "9876543210987654", "5678", 500.0));
        // Add more accounts if needed
    }

    static Account AuthenticateUser(string cardNumber, string pin)
    {
        return accounts.FirstOrDefault(account => account.CardNumber == cardNumber && account.Pin == pin);
    }

    static void PrintOptions()
    {
        Console.WriteLine("\nChoose an option:");
        Console.WriteLine("1. Check Balance");
        Console.WriteLine("2. Deposit");
        Console.WriteLine("3. Withdraw");
        Console.WriteLine("4. Exit");
    }

    static void CheckBalance(Account account)
    {
        Console.WriteLine($"Your current balance is ${account.Balance}");
    }

    static void Deposit(Account account)
    {
        Console.WriteLine("Enter the amount to deposit: ");
        if (double.TryParse(Console.ReadLine(), out double amount))
        {
            account.Balance += amount;
            Console.WriteLine($"Deposit successful. Your new balance is ${account.Balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount. Please enter a valid number.");
        }
    }

    static void Withdraw(Account account)
    {
        Console.WriteLine("Enter the amount to withdraw: ");
        if (double.TryParse(Console.ReadLine(), out double amount))
        {
            if (amount <= account.Balance)
            {
                account.Balance -= amount;
                Console.WriteLine($"Withdrawal successful. Your new balance is ${account.Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient funds. Please enter a valid amount.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount. Please enter a valid number.");
        }
    }
}

class Account
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CardNumber { get; set; }
    public string Pin { get; set; }
    public double Balance { get; set; }

    public Account(string firstName, string lastName, string cardNumber, string pin, double balance)
    {
        FirstName = firstName;
        LastName = lastName;
        CardNumber = cardNumber;
        Pin = pin;
        Balance = balance;
    }
}

