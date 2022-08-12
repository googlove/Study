using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    public class ConsoleLogging
    {
        public static void DisplayMenu()
        {  //This method Displays the User Selection Menu 
            Console.WriteLine();
            Console.WriteLine("Here is a List of Available Actions");
            Console.WriteLine("1 - Create a Contact");
            Console.WriteLine("2 - List all Contacts");
            Console.WriteLine("3 - Update a Contact");
            Console.WriteLine("4 - Delete a Contact");
            Console.WriteLine("5 - End Application");
        }

        public static void DisplayContact(Contact c)
        {   //This method Formats and Displays the Contact Information
            //
            Console.WriteLine();            
            Console.WriteLine($"Name:           {c.FirstName} {c.LastName} {c.Patronymic}");
            Console.WriteLine($"Phone Number:   {c.PhoneNumber}");
			Console.WriteLine($"Personal tel.Number:   {c.PersonalNumber}");
            Console.WriteLine($"Street Address: {c.StreetAddress}");
            Console.WriteLine($"City, ST, Zip:  {c.City}, {c.State} {c.Zip}");
            Console.WriteLine($"email Address:  {c.EmailAddress}");
            Console.WriteLine($"Date of Birth:  {c.DateOfBirth}");
            Console.WriteLine();
        }
    }
}
