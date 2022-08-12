using System;

namespace PhoneBookConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to your Phone Book App");    
            
            //Ask the user to select an option   
            string userSelection;
            bool stopAppliction = false;
            bool phoneBookCreated = false;
            while (stopAppliction == false)
            {
                ConsoleLogging.DisplayMenu();
                Console.WriteLine();
                Console.Write("Please enter your selection: ");
                userSelection = Console.ReadLine();                
                switch (userSelection) 
                {
                    case "1":
                        Contact c = User.CreateContact();                      
                        PhoneBook.ContactList.Add(c);
                        phoneBookCreated = true;
                        break;
                    case "2":
                        if (phoneBookCreated)
                        {
                            User.ReadAllContacts();
                        }
                        else
                        { Console.WriteLine("Sorry You Need to Add a Contact First" ); }                        
                        break;
                    case "3":
                        if (phoneBookCreated)
                        {   //NOTE - This Requires the User to enter the entire Contact Information
                            //Add Logic to allow the user to select and update only the fields they want to change
                            PhoneBook.ContactList.Remove(User.MatchContact());
                            Console.WriteLine("The Contact Has been Removed, Enter the Updated Contact Information");
                            Contact updatedContact= User.CreateContact();
                            PhoneBook.ContactList.Add(updatedContact);
                            phoneBookCreated = true;
                        }
                        else
                        { Console.WriteLine("Sorry You Need to Add a Contact First"); }
                        break;
                    case "4":
                        if (phoneBookCreated)
                        {
                            PhoneBook.ContactList.Remove(User.MatchContact());
                            Console.WriteLine("The Contact Has been Removed from your List.");
                        }
                        else
                        { Console.WriteLine("Sorry You Need to Add a Contact First"); }
                        break;
                    case "5":
                        stopAppliction = true;
                        break;                 
                }
                                        
            }
            Console.WriteLine("Thanks for using the Phone Book App");
        }  
    }
}
