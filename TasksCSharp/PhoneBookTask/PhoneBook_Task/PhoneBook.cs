using System;
using System.Collections.Generic;


    internal abstract class PhoneBook
    {
        protected string FirstName { get; private set; }
        protected string LastName { get; private set; }
        protected int PhoneNumber { get; private set; }
        protected string Address { get; set; }
        protected string CompanyAddress { get; set; }
        protected int Nip { get; private set; }
        protected string CompanyName { get; }

        protected PhoneBook(string firstName, string lastName, string phoneNumber, List<PhoneBook> phoneBook)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneCheck(phoneNumber, phoneBook);
        }

        protected PhoneBook(string firstName, string lastName, string phoneNumber, string nip, string companyName, List<PhoneBook> phoneBook)
        {
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            NipCheck(nip);
            PhoneCheck(phoneNumber, phoneBook);
        }

        private void ErrorMessage(string error)
        {
            Console.WriteLine("Error ! " + error);
        }

#pragma warning disable 659
        public override bool Equals(object obj)
#pragma warning restore 659
        {
            if (obj == null) return false;
            return obj.ToString() == LastName || obj.ToString() == PhoneNumber.ToString() || obj.ToString() == CompanyName;
        }

        private void PhoneCheck(string phone, List<PhoneBook> phoneBook)
        {
            while (true)
            {
                if (phoneBook?.Find(f =>
                        phone != null && f.PhoneNumber == int.Parse(phone)) != null)
                {
                    Console.Clear();
                    ErrorMessage("Phone number is already exists !\nPlease, enter another phone number.");
                    phone = Console.ReadLine();

                }
                else if (phone == null || phone.Length != 9)
                {
                    Console.Clear();
                    ErrorMessage("Phone must be 9 characters length !");
                    Console.Write("Enter phone number : ");
                    phone = Console.ReadLine();
                }
                else if (!int.TryParse(phone, out var result))
                {
                    Console.Clear();
                    ErrorMessage("Phone must contain only numbers !");
                    Console.Write("Enter phone number : ");
                    phone = Console.ReadLine();
                }
                else
                {
                    PhoneNumber = result;
                    return;
                }
            }
        }

        private void NipCheck(string nip)
        {
            while (true)
            {
                if (nip == null || nip.Length != 10)
                {
                    Console.Clear();
                    Console.WriteLine("NIP correction : ");
                    ErrorMessage("Nip must contain 10 characters !");
                    Console.Write("Enter company NIP : ");
                    nip = Console.ReadLine();
                }
                else
                {
                    if (!int.TryParse(nip, out var result))
                    {
                        Console.Clear();
                        Console.WriteLine("NIP correction :");
                        ErrorMessage("NIP must contain numbers only !");
                        Console.WriteLine("Enter company NIP : ");
                        nip = Console.ReadLine();
                    }
                    else
                    {
                        Nip = result;
                        return;
                    }
                }
            }
        }

        public void Update(List<PhoneBook> phoneBook)
        {
            Console.WriteLine("What would you like to change ?\n1. First name\n2. Last name\n3. Phone number\n4. Address\n5. Return to main menu");
            switch (int.TryParse(Console.ReadLine(), out var choose) ? choose : 0)
            {
                case 0:
                    Console.WriteLine("Update failed ! Incorrect data input !");
                    break;
                case 1:
                    Console.Write("First name : ");
                    FirstName = Console.ReadLine();
                    break;

                case 2:
                    Console.Write("Last name : ");
                    LastName = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Phone number : ");
                    PhoneCheck(Console.ReadLine(), phoneBook);
                    break;
                case 4:
                    Console.Write("Address : ");
                    Address = Console.ReadLine();
                    break;
                case 5:
                    return;
            }
        }
    }
