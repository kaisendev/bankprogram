using System;

namespace BankProgram
{
    class Program
    {
    
        static void Main(string[] args)
        {
            Person person = new Person("Metro Bank", "John");
            Transaction john = new Transaction(AccountType.Investment_Individual, person);
            john.Withdraw(500);
            john.CheckStatus();
            john.Deposit(3000);
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
         
            public Transaction(AccountType accountType, Person person)
            {
                this.accountType = accountType;
                this.BankName = person.BankName;
                this.OwnerName = person.OwnerName;
                Console.WriteLine($"Initial Balance {balance}");
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
                        if (amountWithrawed > 500) { Console.WriteLine($"Withdraw Limit for {accountType} is $500"); }
                        else
                        {
                            balance -= amount;
                        }
                    }
                    else
                    {
                        balance -= amount;
                    }
                }
               
            }

            public int Transfer(int amount)
            {
                //I'm not sure what functionality the transfer will do,
                //I would just assume it means transfer money
                return balance -= amount;              
            }

            public void CheckStatus()
            {
                Console.WriteLine($"Bank Name: {BankName}");
                Console.WriteLine($"{OwnerName} Your Balance is : " + this.balance);
            }
        }
    }
}
