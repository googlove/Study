using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    public static class PhoneBook
    {
        //This Class Creates a List of all the contacts called the ContactList
        public static List<Contact> ContactList { get; set; } = new List<Contact>();
    }
}
