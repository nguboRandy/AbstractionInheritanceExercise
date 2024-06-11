using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionExerciseBankAccount
{
    internal class Program
    {
        abstract class bankAccount
        {
            protected string accountNumber;
            protected double accountBalance = 4500;
            protected string accountName;

            public abstract void DisplayBalance();
        }



        class savingsAccount : bankAccount
        {
            public  savingsAccount(string ac)
            {
                accountNumber = ac;
            }

            public void interestRate()
            {
                Console.WriteLine($"The interest rate for savings account {accountNumber} is 0.05%");

            }

            public void withdraw(double wAmnt)
            {
                accountBalance -= wAmnt;
            }

            public void deposit(double dipAmnt)
            {
                accountBalance += dipAmnt;
            }

            public override void DisplayBalance()
            {
                accountName = "Savings Account";
                Console.WriteLine($"The balance for the savings account {accountName} is {accountBalance}");
            }

        }


        class checkAccount: bankAccount
        {
            double debitOrder = 300;

            public checkAccount(string ac)
            {
                accountNumber = ac;
                

            }

            public void payDebit()
            {
               accountBalance -= debitOrder;
            }

            public override void DisplayBalance()
            {
                accountName = "Check Account";
                Console.WriteLine("Balance after running debit order of R300 for {0} is: {1}", accountName, accountBalance);
            }


        }

        public int MainMenu()
        {
            Console.WriteLine("Enter which Account you want to access below:");
            Console.WriteLine("==============Press 1 for Savings Account");
            Console.WriteLine("==============Press 2 for Debit Order ");
            Console.WriteLine("==============Press 99 to exit");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }


        public void SavingsMenu(string ac)
        {
            savingsAccount mySavings = new savingsAccount(ac);
            mySavings.DisplayBalance();


            Console.WriteLine("============================");
            Console.WriteLine("Enter deposit ammount:");
            double dep = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter withdrawal ammount:");
            double wid = double.Parse(Console.ReadLine());

            Console.WriteLine("============================");
            mySavings.deposit(dep);
            mySavings.withdraw(wid);
            mySavings.interestRate();


            Console.WriteLine("============================");
            mySavings.DisplayBalance();
            Console.WriteLine("============================");
        }



        public void CheckAccountMenu(string ac)
        {
            checkAccount myCheck = new checkAccount(ac);
            Console.WriteLine("=============================");
            myCheck.payDebit();
            myCheck.DisplayBalance();
            Console.WriteLine("==============================");

        }



        static void Main(string[] args)
        {

            
            Console.WriteLine("Enter Account Number for your Account:");
            string accNum = Console.ReadLine();
            Program bank = new Program();


            int choice = bank.MainMenu();

            if (choice == 1)
            {
                bank.SavingsMenu(accNum);
            }
            else if (choice == 2)
            {
                bank.CheckAccountMenu(accNum);
            }
            else
            {
                Environment.Exit(0);
            }
            Console.ReadLine();


        }
    }
}
