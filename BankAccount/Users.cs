using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BankAccount
{
    class Users
    {
        List<User> users = new List<User>();

        public Users()
        {
            //Read in users from txt file
            string[] textFile = File.ReadAllLines("login.txt");
            foreach (string line in textFile)
            {
                string[] split = line.Split('|');
                users.Add(new User(split[0], split[1]));
            }
        }

        public void Login(string userName, string password)
        {
            Console.SetCursorPosition(1, 11);
            User userObject = findUser(userName, password);
            if (userObject != null)
            {
                Console.WriteLine("Valid credentials!... Please enter");
                Console.SetCursorPosition(1, 12);
                Console.ReadKey();
                Console.Clear();
                userObject.Use();
            }
            else
            {
                Console.WriteLine("Invalid login credentials");
            }
        }

        public User findUser(string userName, string password)
        {
            foreach (User user in users)
            {
                if (user.IsUser(userName, password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
