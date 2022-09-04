using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class User
    {
        private string userName;
        private string password;
        
        //Access
        private Accounts accounts;

        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            this.accounts = new Accounts();
        }

        public void Use()
        {
            BankMenu();
            string choice;
            Console.SetCursorPosition(25, 14);
            while (!(choice = ReadChoice()).Equals("7"))
            {
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        accounts.Create();
                        ResetMenu();
                        break;
                    case "2":
                        Console.Clear();
                        accounts.Search();
                        ResetMenu();
                        break;
                    case "3":
                        Console.Clear();
                        accounts.Deposit();
                        ResetMenu();
                        break;
                    case "4":
                        Console.Clear();
                        accounts.Withdraw();
                        ResetMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }
        }

        private string ReadChoice()
        {
            string choice = Console.ReadLine();
            return choice;
        }

        public bool IsUser(string username, string password)
        {
            if(username.Equals(this.userName) && password.Equals(this.password))
            {
                return true;
            }
            return false;
        }

        private void ResetMenu()
        {
            BankMenu();
            Console.SetCursorPosition(25, 14);
        }
        private void BankMenu()
        {
            Console.WriteLine(" ________________________________________________________");
            Console.WriteLine(" |                                                      |");
            Console.WriteLine(" |       WELCOME TO SIMPLE BANK MANAGEMENT SYSTEM       |");
            Console.WriteLine(" |______________________________________________________|");
            Console.WriteLine(" |                                                      |");
            Console.WriteLine(" |    1. Create new account                             |");
            Console.WriteLine(" |    2. Search an account                              |");
            Console.WriteLine(" |    3. Deposit                                        |");
            Console.WriteLine(" |    4. Withdraw                                       |");
            Console.WriteLine(" |    5. View account statements                        |");
            Console.WriteLine(" |    6. Delete account                                 |");
            Console.WriteLine(" |    7. Exit                                           |");
            Console.WriteLine(" |______________________________________________________|");
            Console.WriteLine(" |                                                      |");
            Console.WriteLine(" |    Enter your choice:                                |");
            Console.WriteLine(" |______________________________________________________|");
            Console.WriteLine();
        }
    }
}
