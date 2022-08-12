using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBookConsoleUI
{
    public static class User
    {  
        public static Contact CreateContact()
        //This method creates a New Contact
        {
            Console.WriteLine();
            Contact c = new Contact();
            Console.WriteLine("Enter Contact Information:");           
            Console.Write("First Name: ");
            c.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            c.LastName = Console.ReadLine();
			Console.Write("Patronymic: ");
            c.Patronymic = Console.ReadLine();
            Console.Write("Phone Number: ");
            c.PhoneNumber = Console.ReadLine();
			Console.Write("Personal tel. Number: ");
            c.PersonalNumber = Console.ReadLine();
            Console.Write("Street Address: ");
            c.StreetAddress = Console.ReadLine();          
            Console.Write("City: ");
            c.City = Console.ReadLine();
            Console.Write("State: ");
            c.State = Console.ReadLine();
            Console.Write("Zip: ");
            c.Zip = Console.ReadLine();
            Console.Write("Email Address: ");
            c.EmailAddress = Console.ReadLine();
            Console.Write("Date of Birth (MM/DD/YYYY): ");
            c.DateOfBirth = Console.ReadLine();
            return c;
        }
        public static void ReadAllContacts()
        {// This Method Reads all the Contacts in the List and calls the ConsoleLogging.DisplayContact Method to display them
            Console.WriteLine();
            Console.WriteLine("Contact List:");
            foreach (var contact in PhoneBook.ContactList)
            {
                ConsoleLogging.DisplayContact(contact);
            }
        }

        public static Contact MatchContact()
        {
            //This Method Asks the User to input a vaild Phone Number from the list and returns the matching Contact            
            Console.Write("Enter the Phone Number of the Contact: ");
            string contactphonenumber = Console.ReadLine();
            bool contactfound = false;
            while (contactfound == false)
            {
                foreach (var contact in PhoneBook.ContactList)
                {
                    if (contact.PhoneNumber == contactphonenumber)
                    {
                        contactfound = true;
                        return contact;
                    }
                }
                Console.WriteLine("Sorry that Phone Number is not in your Contact List.");
                Console.WriteLine("Here is List of All Your Contacts");
                User.ReadAllContacts();
                Console.Write("Reenter the Phone Number of the Contact:");
                contactphonenumber = Console.ReadLine();
            }
            return new Contact(); //Note - This Return was required but should never be executed - A valid contact will be returned
        }          
    }
 }
