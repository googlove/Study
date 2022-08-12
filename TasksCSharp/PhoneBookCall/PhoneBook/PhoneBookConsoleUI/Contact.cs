using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneBookConsoleUI
{
    public class Contact
    {//This is the Contact Class and Contains the properties and methods for each contact
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }  
        //Since The PhoneNumber is Unique to the contact it will be used ase the key
        public string StreetAddress { get; set; } 
		public string PersonalNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; } 
        public string Zip { get; set; }       
        public string EmailAddress { get; set; } 
        //Add Logic to ensure a valid email address format is entered
        public string DateOfBirth { get; set; }  
        //Add Logic to ensure Date Of Birth is in the format MM/DD/YYYY                
        //regex.Match(DateOfBirth);
        //This is the regex pattern for the Date of Birth
        //Regex regex = new Regex(@"^\d{1,2}/\d{1,2}/\d{4}$", RegexOptions.IgnorePatternWhitespace);     
    }
}
