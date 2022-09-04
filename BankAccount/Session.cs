using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class Session
    {
        private Accounts accounts;
        private Users users;
        public Session()
        {
            accounts = new Accounts();
            users = new Users();
        }
        public static void Main(string[] args)
        {
            Session session = new Session();
            session.Use();
        }
        private void Use()
        {
            this.WelcomeMenu();
            this.Login();
        }
        private void Login()
        {
            Console.SetCursorPosition(16, 7);
            string username = Console.ReadLine();
            Console.SetCursorPosition(16, 8);
            string password = Console.ReadLine();
            
            users.Login(username, password);
        }

        private void WelcomeMenu()
        {
            Console.WriteLine(" ________________________________________________________");
            Console.WriteLine(" |                                                      |");
            Console.WriteLine(" |      WELCOME TO SIMPLE BANK MANAGEMENT SYSTEM        |");
            Console.WriteLine(" |______________________________________________________|");
            Console.WriteLine(" |                                                      |");
            Console.WriteLine(" |                       SIGN IN                        |");
            Console.WriteLine(" |                                                      |");
            Console.WriteLine(" |    Username:                                         |");
            Console.WriteLine(" |    Password:                                         |");
            Console.WriteLine(" |______________________________________________________|");
            Console.WriteLine();
        }
    }
}
