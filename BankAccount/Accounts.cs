using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class Accounts
    {
        private List<Account> accounts = new List<Account>();

        public Accounts()
        {
            accounts.Add(new Account("12", "ca", "om", "12", 12, "2@"));
        }

        //Create account code 
        public void Create()
        {
            CreateMenu();
            Console.SetCursorPosition(18, 5);
            string firstName = Console.ReadLine();
            Console.SetCursorPosition(17, 6);
            string lastName = Console.ReadLine();
            Console.SetCursorPosition(15, 7);
            string address = Console.ReadLine();
            Console.SetCursorPosition(13, 8);
            int phoneNo = int.Parse(Console.ReadLine()); //Check if int hahah
            Console.SetCursorPosition(13, 9);
            string email = Console.ReadLine();
            while (!email.Contains("@"))
            {
                Console.SetCursorPosition(1, 12);
                Console.WriteLine("Invalid email address. Would you like to try again? ");
                Console.Clear();
                Create();
            }
            Confirmation(firstName, lastName, address, phoneNo, email);
        }

        private void Confirmation(string firstName, string lastName, string address, int phoneNo, string email)
        {
            Console.SetCursorPosition(1, 12);
            Console.Write("Is this information correct (y/n)? ");
            string choice = Choice();
            while (!ChoiceIsValid(choice))
            {
                InvalidChoice();
                choice = Choice();
            }

            if (choice.Equals("n"))
            {
                Create();
            } else
            {
                CreateAccount(firstName, lastName, address, phoneNo, email);
            }
        }

        private void CreateAccount(string firstName, string lastName, string address, int phoneNo, string email)
        {
            string accountNo = GenerateAccountNo();
            accounts.Add(new Account(accountNo, firstName, lastName, address, phoneNo, email));
            Console.SetCursorPosition(1, 16);
            Console.WriteLine("Account created! Details will be provided via email");
            Console.SetCursorPosition(1, 18);
            Console.WriteLine("Account number is: " + accountNo);
            Console.SetCursorPosition(1, 19);
            ClearConsole();
        }

        private string GenerateAccountNo()
        {
            Random r = new Random();
            string accountNo = r.Next(100000, 99999999).ToString();

            foreach (Account account in accounts)
            {
                while (account.checkExists(accountNo))
                {
                    accountNo = r.Next(100000, 99999999).ToString();
                }
            }
            return accountNo;
        }

        //Search account code 
        public void Search()
        {
            SearchMenu();
            Console.SetCursorPosition(22, 5);
            string accountNo = Console.ReadLine();
            Account account = GetAccount(accountNo);
            if (account != null)
            {
                Console.WriteLine("ACCOUNT FOUND!");
                account.ShowDetails();
            }
            else
            {
                Console.WriteLine("ACCOUNT NOT FOUND!");
            };
            searchAgain();
        }

        public void searchAgain()
        {
            Console.Write("Would you like to search for another account (y/n)? ");
            string choice = Console.ReadLine().ToLower();

            while (!(choice.Equals("y") || choice.Equals("n")))
            {
                Console.WriteLine("Please enter a valid selection ");
                Console.Write("Would you like to search for another account (y/n)? ");
                choice = Console.ReadLine().ToLower();
            }

            if (choice.Equals("y"))
            {
                Search();
            }
        }

        //Deposit account code 
        public void Deposit()
        {
            DepositMenu();
            Console.SetCursorPosition(22, 5);
            string accountNo = Console.ReadLine();
            Account account = GetAccount(accountNo);

            if(account != null) { 
                DepositAccountFound(account);
            }
            else
            {
                DepositAccountNotFound();
            }
        }

        public void DepositAccountFound(Account account)
        {
            Console.SetCursorPosition(1, 9);
            Console.WriteLine("Account found...Please enter amount");
            Console.SetCursorPosition(16, 6);
            double depositAmt = double.Parse(Console.ReadLine());
            account.Deposit(depositAmt);
            Console.SetCursorPosition(1, 10);
            Console.WriteLine("Deposit successful!");
            Console.SetCursorPosition(1, 11);
            ClearConsole();
        }

        public void DepositAccountNotFound()
        {
            AccountNotFound();
            string choice = Choice();
            while (!ChoiceIsValid(choice))
            {
                InvalidChoice();
                choice = Choice();
            }
            Console.Clear();
            if (choice.Equals("y"))
            {
                Deposit();
            }
        }

        //Withdraw code 
        public void Withdraw()
        {
            WithdrawMenu();
            Console.SetCursorPosition(22, 5);
            string accountNo = Console.ReadLine();
            Account account = GetAccount(accountNo);
            if(account != null)
            {
                WithdrawAccountFound(account);
            }
            else
            {
                WithdrawAccountNotFound();
            }
        }

        private void WithdrawAccountFound(Account account)
        {
            Console.SetCursorPosition(1, 9);
            Console.WriteLine("Account found...Please enter amount");
            Console.SetCursorPosition(16, 6);
            double amount = Double.Parse(Console.ReadLine());
            account.Withdraw(amount);
            Console.SetCursorPosition(1, 10);
            Console.WriteLine("Withdraw successful!");
            Console.SetCursorPosition(1, 11);
            ClearConsole();
        }

        private void WithdrawAccountNotFound()
        {
            AccountNotFound();
            string choice = Choice();
            while (!ChoiceIsValid(choice))
            {
                InvalidChoice();
                choice = Choice();
            }
            Console.Clear();
            if (choice.Equals("y"))
            {
                Withdraw();
            }
        }

        //Statements code 
        public void Statement()
        {
            StatementMenu();
            string accountNo = Console.ReadLine();
            Account account = GetAccount(accountNo);

            if(account != null)
            {

            }
            else
            {

            }


        }

        private Account GetAccount(string accountNo)
        {
            foreach (Account account in accounts)
            {
                if (account.checkExists(accountNo))
                {
                    return account;
                }
            }
            return null;
        }

        private string Choice()
        {
            return Console.ReadLine().ToLower();
        }

        private bool ChoiceIsValid(string choice)
        {
            while (choice.Equals("y") || choice.Equals("n"))
            {
                return true;
            }
            return false;
        }

        private void InvalidChoice()
        {
            Console.WriteLine("Please enter a valid selection");
            Console.WriteLine("Is this information correct (y/n) ?");
        }

        private void AccountNotFound()
        {
            Console.SetCursorPosition(1, 9);
            Console.WriteLine("Account not found!");
            Console.SetCursorPosition(1, 10);
            Console.Write("Retry (y/n)? ");
        }

        private void ClearConsole()
        {
            Console.ReadKey(); //User selects enter
            Console.Clear(); //Clear console
        }

        private void CreateMenu()
        {
            Console.WriteLine(" ________________________________________________________ ");
            Console.WriteLine(" |                 CREATE A NEW ACCOUNT                 | ");
            Console.WriteLine(" |______________________________________________________| ");
            Console.WriteLine(" |                  ENTER THE DETAILS                   | ");
            Console.WriteLine(" |                                                      | ");
            Console.WriteLine(" |    First Name:                                       | ");
            Console.WriteLine(" |    Last Name:                                        | ");
            Console.WriteLine(" |    Address:                                          | ");
            Console.WriteLine(" |    Phone:                                            | ");
            Console.WriteLine(" |    Email:                                            | ");
            Console.WriteLine(" |______________________________________________________| ");
            Console.WriteLine();
        }

        private void SearchMenu()
        {
            Console.WriteLine(" ________________________________________________________ ");
            Console.WriteLine(" |                 SEARCH A NEW ACCOUNT                 | ");
            Console.WriteLine(" |______________________________________________________| ");
            Console.WriteLine(" |                  ENTER THE DETAILS                   | ");
            Console.WriteLine(" |                                                      | ");
            Console.WriteLine(" |    Account Number:                                   | ");
            Console.WriteLine(" |______________________________________________________| ");
            Console.WriteLine();
        }

        private void DepositMenu()
        {
            Console.WriteLine(" ________________________________________________________ ");
            Console.WriteLine(" |                       DEPOSIT                        | ");
            Console.WriteLine(" |______________________________________________________| ");
            Console.WriteLine(" |                  ENTER THE DETAILS                   | ");
            Console.WriteLine(" |                                                      | ");
            Console.WriteLine(" |    Account Number:                                   | ");
            Console.WriteLine(" |    Amount : $                                        | ");
            Console.WriteLine(" |______________________________________________________| ");
            Console.WriteLine();
        }

        private void WithdrawMenu()
        {
            Console.WriteLine(" ________________________________________________________ ");
            Console.WriteLine(" |                      WITHDRAW                        | ");
            Console.WriteLine(" |______________________________________________________| ");
            Console.WriteLine(" |                  ENTER THE DETAILS                   | ");
            Console.WriteLine(" |                                                      | ");
            Console.WriteLine(" |    Account Number:                                   | ");
            Console.WriteLine(" |    Amount : $                                        | ");
            Console.WriteLine(" |______________________________________________________| ");
            Console.WriteLine();
        }

        private void StatementMenu()
        {
            Console.WriteLine(" ________________________________________________________ ");
            Console.WriteLine(" |                      STATEMENT                       | ");
            Console.WriteLine(" |______________________________________________________| ");
            Console.WriteLine(" |                  ENTER THE DETAILS                   | ");
            Console.WriteLine(" |                                                      | ");
            Console.WriteLine(" |    Account Number:                                   | ");
            Console.WriteLine(" |______________________________________________________| ");
            Console.WriteLine();
        }
    }
}
