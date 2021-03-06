using System;

namespace BankProgram
{
    class Program
    {
    
        static void Main(string[] args)
        {
            Person person = new Person("Metro Bank", "John");
            Transaction john = new Transaction(AccountType.Investment_Individual, person);
            john.InitialBalance();
            john.Withdraw(500);
            john.CheckStatus();
            john.Deposit(3000);
            john.CheckStatus();
            john.Withdraw(600);
            john.CheckStatus();
        }

        enum AccountType
        {
            Checking,
            Investment_Individual,
            Investment_Corporate
        }

        class Person
        {
            public string OwnerName { get; set; }
            public string BankName { get; set; }

            public Person( string bankName, string ownerName)
            {
                this.BankName = bankName;
                this.OwnerName = ownerName;
            }
        }

        class Transaction
        {
            AccountType accountType;
            string BankName;
            string OwnerName;
            int balance = 5000;
            int amountWithrawed = 0;
            int limit = 500;
         
            public Transaction(AccountType accountType, Person person)
            {
                this.accountType = accountType;
                this.BankName = person.BankName;
                this.OwnerName = person.OwnerName;
            }

            public void Deposit(int amount)
            {
                balance += amount;
                Console.WriteLine($"Deposited {amount}");
            }

            public void Withdraw(int amount) 
            {
                
                amountWithrawed = amount;
                if(amount > balance || balance == 0)
                {
                    Console.WriteLine("Insufficient Funds");
                    Console.WriteLine($"Your current Balance is {balance}");
                    return;
                }
                else
                {
                    if (accountType == AccountType.Investment_Individual)
                    {
                        if (amountWithrawed > limit) { Console.WriteLine($"Withdraw Limit for {accountType} is ${limit}"); }
                        else
                        {
                            balance -= amount;
                            Console.WriteLine($"Amount Withdrawed: {amountWithrawed}");
                        }
                    }
                    else
                    {
                        balance -= amount;
                        Console.WriteLine($"Amount Withdrawed: {amountWithrawed}");
                    }
                }             
            }

            public int Transfer(int amount)
            {
                //I'm not sure what functionality the transfer will do,
                //I'm just going to assume it means transfer money
                return balance -= amount;              
            }

            public void CheckStatus()
            {
                Console.WriteLine($"Bank Name: {BankName}");
                Console.WriteLine($"{OwnerName} Your Balance is : {balance}");
            }

            public void InitialBalance()
            {
                Console.WriteLine($"{OwnerName} Initial Balance : {balance}");
            }
        }
    }
}
