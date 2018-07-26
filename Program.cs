using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02
{
    public class Program
    {
        static AccountDetails[] Clients = new AccountDetails[2];
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input\n");
             for (int i = 0; i < 2; i++)
              {
                AccountDetails accountDetails = new AccountDetails();

                Console.Write("Account Number ");
                Clients[i] = new AccountDetails();
                Clients[i].AccountNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Amount ");
                Clients[i].Amount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Account Holder ");
                Clients[i].AccountHolder = Console.ReadLine();
                Console.Write("Account Type ");
                Clients[i].AccountType = Console.ReadLine();
            }
            Console.WriteLine("Enter your choice: 1. Display Your Account Details 2. Search by Account ID 3. Deposit 4. Withdraw");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            
                switch (userChoice)
                {
                    case 1:
                        DisplayAccountDetails();
                        break;
                    case 2:
                        SearchById(101);
                        break;
                    case 3:
                        int UpdatedAmount1 = Deposit(1000, 101);
                        Console.WriteLine("Updated amount {0}", UpdatedAmount1);
                        break;
                    case 4:
                        int UpdatedAmount2 = Withdraw(1000, 101);
                        Console.WriteLine("Updated amount {0}", UpdatedAmount2);
                        break;
                    default:
                        Console.WriteLine("Invalid grade");
                        break;
                
            }
            Console.ReadKey(); 
        }
        public static void DisplayAccountDetails()
        {
            Console.WriteLine("Following shows the clients of XYZ Bank");
            for (int i = 0; i < Clients.Length; i++)
                Console.Write("-- Account Number -- Amount -- Account Holder -- Account Type -- {0} {1} {2} {3}", Clients[i].AccountNumber, Clients[i].Amount, Clients[i].AccountHolder, Clients[i].AccountType);
        }

        public static AccountDetails SearchById(int InputAccountNumber)
        {
            AccountDetails SearchOutput = new AccountDetails();
            for (int i = 0; i < 2; i++)
            {
                if (Clients[i].AccountNumber == InputAccountNumber)
                {
                    SearchOutput.AccountNumber = Clients[i].AccountNumber;
                    SearchOutput.Amount = Clients[i].Amount;
                    SearchOutput.AccountHolder = Clients[i].AccountHolder;
                    SearchOutput.AccountType = Clients[i].AccountType;
                    break;
                }
            }
            return SearchOutput;
        }

        public static int Deposit(int DepositAmount, int InputAccountNumber)
        {
            int IncrementedAmount = 0;
            for (int i = 0; i < 2; i++)
            {
                if (Clients[i].AccountNumber == InputAccountNumber)
                {
                    IncrementedAmount = Clients[i].Amount + DepositAmount;
                    break;
                }
            }
            return IncrementedAmount;
        }

        public static int Withdraw(int WithdrawAmount, int InputAccountNumber)
        {
            int DecrementedAmount = 0;
            for (int i = 0; i < 2; i++)
            {
                if (Clients[i].AccountNumber == InputAccountNumber)
                {
                    if (Clients[i].AccountType == "Saving" && Clients[i].Amount - WithdrawAmount < 1000)
                        Console.WriteLine("Insufficient Balance");
                    else if (Clients[i].AccountType == "Current " && Clients[i].Amount - WithdrawAmount < 0)
                        Console.WriteLine("Insufficient Balance");
                    else if (Clients[i].AccountType == "DMAT  " && Clients[i].Amount - WithdrawAmount < -10000)
                        Console.WriteLine("Insufficient Balance");
                    else
                    {
                        Clients[i].Amount = Clients[i].Amount - WithdrawAmount;
                        DecrementedAmount = Clients[i].Amount;
                    }
                    break;
                }
            }
            return DecrementedAmount;
        }


    }

    public class AccountDetails
    {
        public int AccountNumber;
        public int Amount;
        public string AccountHolder;
        public string AccountType;
    }

    
}
