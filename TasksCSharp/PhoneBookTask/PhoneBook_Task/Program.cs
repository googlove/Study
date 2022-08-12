using System.Collections.Generic;
using System.Linq;
using static System.Console;


    internal static class Program
    {
        private static void Main()
        {
            List<PhoneBook> phoneBook = new List<PhoneBook>();
            while (true)
            {
                Clear();
                WriteLine(
                    "Welcome in phone book !\n1. Create new record\n2. Show records\n3. Search\n4. Update phone book\n5. Exit");
                switch (int.TryParse(ReadLine(), out var chose) ? chose : 0)
                {
                    case 0:
                        WriteLine("Enter ony number from list !");
                        break;
                    case 1:
                        CreateNewRecord(ref phoneBook);
                        ReadLine();
                        break;
                    case 2:
                        ShowAllRecords(phoneBook);
                        ReadLine();
                        break;
                    case 3:
                        SearchRecord(phoneBook);
                        ReadLine();
                        break;
                    case 4:
                        WriteLine("Enter data to continue (First Name or Last Name or Phone number");
                        SearchAndUpdate(phoneBook, ReadLine());
                        break;
                    case 5:
                        return;
                    default:
                        WriteLine("Enter only number from list !");
                        ReadLine();
                        break;
                }
            }
        }

        private static void SearchRecord(List<PhoneBook> phoneBook)
        {
            Clear();
            WriteLine("Search by :\n1. Last Name\n2. Company Name\n3. Phone Number");
            switch (int.TryParse(ReadLine(), out var chose) ? chose : 0)
            {
                case 0:
                    WriteLine("Enter ony number from list !");
                    break;
                case 1:
                    Clear();
                    Write("Enter last name : ");
                    Search(phoneBook, ReadLine());
                    break;
                case 2:
                    Clear();
                    Write("Enter company name : ");
                    Search(phoneBook, ReadLine());
                    break;
                case 3:
                    Clear();
                    Write("Enter phone number : ");
                    Search(phoneBook, ReadLine());
                    break;
                default:
                    WriteLine("Enter only number from list !");
                    break;
            }
        }

        private static void Search(List<PhoneBook> phoneBook, string searchBy)
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            foreach (var record in phoneBook.Where(record => record.Equals(searchBy)))
            {
                WriteLine($"[{record.GetType()}]\n" + record + "\n");
            }
        }

        private static void SearchAndUpdate(List<PhoneBook> phoneBook, string searchBy)
        {
            Clear();
            // ReSharper disable once SuspiciousTypeConversion.Global
            foreach (var record in phoneBook.Where(record => record.Equals(searchBy)))
            {
                WriteLine($"[{record.GetType()}]\n" + record + "\n");
                record.Update(phoneBook);
            }
        }

        private static void CreateNewRecord(ref List<PhoneBook> phoneBook)
        {
            Clear();
            WriteLine("1. Individual\n2. Company");
            switch (int.TryParse(ReadLine(), out var chose) ? chose : 0)
            {
                case 0:
                    WriteLine("Enter ony number from list !");
                    break;
                case 1:
                    WriteLine(
                        "Enter data in that order : FirstName-LastName-Phone(9 numbers)-Address (if you want)");
                    List<string> data = new List<string>(ReadLine()?.Split('-'));
                    if (data.Count == 3 || data.Count == 4)
                        phoneBook.Add(new Individual(data, phoneBook));
                    else
                        WriteLine("Error ! Not all important variables entered !");
                    break;
                case 2:
                    WriteLine(
                        "Enter data in that order :\n[Important]FirstName-LastName-Phone(9 numbers)-CompanyNIP(10 characters)-CompanyName-Address{Not important]");
                    data = new List<string>(ReadLine()?.Split('-'));
                    if (data.Count == 5 || data.Count == 6)
                        phoneBook.Add(new Company(data, phoneBook));
                    else
                        WriteLine("Error ! Not all important variables entered !");
                    break;
                default:
                    WriteLine("Enter only number from list !");
                    break;
            }

        }

        private static void ShowAllRecords(List<PhoneBook> phoneBook)
        {
            Clear();
            WriteLine("All records :");
            if (phoneBook == null) { WriteLine("Phone book is empty"); return; }
            foreach (var record in phoneBook)
            {
                WriteLine($"[{record.GetType()}]\n" + record + "\n");
            }
        }
    }
