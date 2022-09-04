﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class Account
    {
        //fields to be generated by code 
        private string accountNo; //a unique 6-8 digit account number
        private double balance; //initially set to 0 

        //fields generated via user input 
        private string firstName, lastName, address, email;
        private int phoneNo;

        public Account(string accountNo, string firstName, string lastName,
                       string address, int phoneNo, string email)
        {
            this.accountNo = accountNo;
            this.balance = 0;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phoneNo = phoneNo;
            this.email = email;
        }
        public bool checkExists(string accountNo)
        {
            if (accountNo.Equals(this.accountNo))
            {
                return true;
            }
            return false;
        }

        public void ShowDetails()
        {
            Console.WriteLine(this.accountNo);
            Console.WriteLine(this.balance);
            Console.WriteLine(this.firstName);
            Console.WriteLine(this.lastName);
            Console.WriteLine(this.address);
            Console.WriteLine(this.phoneNo);
            Console.WriteLine(this.email);
        }

        public void Deposit(double amount)
        {
            this.balance += amount;
        }

        public void Withdraw(double amount)
        {
            this.balance -= amount;
        }
    }
}
