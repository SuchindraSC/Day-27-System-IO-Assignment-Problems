using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace AddressBookFileIO
{
    class AddressBookBuilder
    {
        public List<ContactDetails> contactDetailsList;
        int searchforCity = 0;
        int searchforState = 0;
        public List<ContactDetails> searchingContacts = new List<ContactDetails>();
        public List<ContactDetails> viewingContacts = new List<ContactDetails>();
        List<ContactDetails> SortedList = new List<ContactDetails>();
        public static Dictionary<string, List<ContactDetails>> addressBook = new Dictionary<string, List<ContactDetails>>();
        public void AddContact()
        {
            string AddressBookName;
            contactDetailsList = new List<ContactDetails>();
            while (true)
            {
                Console.WriteLine("Enter Name Of Address Book\n");
                AddressBookName = Console.ReadLine();
                if (addressBook.Count > 0)
                {
                    if (addressBook.ContainsKey(AddressBookName))
                    {
                        Console.WriteLine("Address Book With This Name Already Exists");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Enter Number Of Contacts You Want To Add: ");
            int numberofContactstobeAdded = int.Parse(Console.ReadLine());
            while (numberofContactstobeAdded > 0)
            {
                ContactDetails contact = new ContactDetails();
                while (true)
                {
                    Console.WriteLine("Enter The First Name: ");
                    string firstName = Console.ReadLine();
                    if (contactDetailsList.Count > 0)
                    {
                        var name = contactDetailsList.Find(name => name.firstName.Equals(firstName));
                        if (name != null)
                        {
                            Console.WriteLine("Entered First Name Already Exists");
                        }
                        else
                        {
                            contact.firstName = firstName;
                            break;
                        }
                    }
                    else
                    {
                        contact.firstName = firstName;
                        break;
                    }
                }

                Console.WriteLine("Enter The Last Name: ");
                contact.lastName = Console.ReadLine();
                Console.WriteLine("Enter The Address: ");
                contact.address = Console.ReadLine();
                Console.WriteLine("Enter The City: ");
                contact.city = Console.ReadLine();
                Console.WriteLine("Enter The State: ");
                contact.state = Console.ReadLine();
                Console.WriteLine("Enter The Zip Code: ");
                contact.zipCode = int.Parse(Console.ReadLine());

                while (true)
                {
                    Console.WriteLine("Enter The Phone Number: ");
                    string phoneNo = Console.ReadLine();
                    if (phoneNo.Length == 13 && phoneNo.Contains(" "))
                    {
                        contact.phoneNumber = phoneNo;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You Entered Invalid Phone Number. Please Enter A Valid Phone Number ");
                    }
                }
                while(true)
                { 
                    Console.WriteLine("Enter The Email-ID: ");
                    string emailID = Console.ReadLine();
                    if (emailID.Contains("@"))
                    {
                        contact.emailid = emailID;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter A Valid Email ID");
                    }
                }
                contactDetailsList.Add(contact);
                numberofContactstobeAdded--;
            }
            addressBook.Add(AddressBookName, contactDetailsList);
            Console.WriteLine("#############CONTACT DETAILS ADDED SUCCESSFULLY#################");
        }
        public void ViewContactPerson()
        {
            if (addressBook.Count > 0)
            {
                foreach (KeyValuePair<string, List<ContactDetails>> addressBookDictionary in addressBook)
                {
                    Console.WriteLine($"{addressBookDictionary.Key}");
                    Console.WriteLine("############################");
                    foreach (var addBook in addressBookDictionary.Value)
                    {
                        Print(addBook);
                    }
                }
            }
            else
            {
                Console.WriteLine("Your Address Book Is Empty");
            }
        }
        public void Print(ContactDetails Names)
        {
            Console.WriteLine("First Name: " + Names.firstName);
            Console.WriteLine("Last Name: " + Names.lastName);
            Console.WriteLine("Address: " + Names.address);
            Console.WriteLine("City: " + Names.city);
            Console.WriteLine("State: " + Names.state);
            Console.WriteLine("Phone Number: " + Names.phoneNumber);
            Console.WriteLine("Email Id: " + Names.emailid);
        }

        public void editingDetails()
        {
            int flag;

            if (contactDetailsList.Count > 0)
            {
                Console.WriteLine("Enter The Name Of Person You Want To Edit: ");
                string toEditdetails = Console.ReadLine();
                foreach (var details in contactDetailsList)
                {
                    if (toEditdetails.ToLower() == details.firstName.ToLower())
                    {
                        while (true)
                        {
                            flag = 0;
                            Console.WriteLine("Enter Option You Want To Edit: ");
                            Console.WriteLine("1. First Name\n2. Last Name\n3. Address\n4. City\n5. State\n6. Zip Code\n7. Phone Number\n8. Email Id\n9. Exit");
                            int options = int.Parse(Console.ReadLine());
                            switch (options)
                            {
                                case 1:
                                    Console.WriteLine("Enter The New First Name You Want To Add: ");
                                    details.firstName = Console.ReadLine();
                                    Console.WriteLine("#########Successfull EDITED############");
                                    break;
                                case 2:
                                    Console.WriteLine("Enter The New Last Name You Want To Add: ");
                                    details.lastName = Console.ReadLine();
                                    Console.WriteLine("#########Successfull EDITED############");
                                    break;
                                case 3:
                                    Console.WriteLine("Enter The New Address You Want To Add: ");
                                    details.address = Console.ReadLine();
                                    Console.WriteLine("#########Successfull EDITED############");
                                    break;
                                case 4:
                                    Console.WriteLine("Enter The New City You Want To Add: ");
                                    details.city = Console.ReadLine();
                                    Console.WriteLine("#########Successfull EDITED############");
                                    break;
                                case 5:
                                    Console.WriteLine("Enter The New State You Want To Add: ");
                                    details.state = Console.ReadLine();
                                    Console.WriteLine("#########Successfull EDITED############");
                                    break;
                                case 6:
                                    Console.WriteLine("Enter The New Zip Code You Want To Add: ");
                                    details.zipCode = int.Parse(Console.ReadLine());
                                    Console.WriteLine("#########Successfull EDITED############");
                                    break;
                                case 7:
                                    Console.WriteLine("Enter The New Phone Number You Want To Add: ");
                                    details.phoneNumber = Console.ReadLine();
                                    Console.WriteLine("#########Successfull EDITED############");
                                    break;
                                case 8:
                                    Console.WriteLine("Enter The New Email Id You Want To Add: ");
                                    details.emailid = Console.ReadLine();
                                    Console.WriteLine("#########Successfull EDITED############");
                                    break;
                                case 9:
                                    Console.WriteLine("You Exited");
                                    flag = 1;
                                    break;
                            }
                            if (flag == 1)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entered Name Is Not In Address Book Contact List");
                    }
                }
            }
            else
            {
                Console.WriteLine("Your Address Book Contact List Is Empty");
            }
        }
        public void DeleteContact()
        {
            int flag = 0;
            Console.WriteLine("Enter Name Of A Address Book In Which You Want To Delete A Person: ");
            string delAddressBookName = Console.ReadLine();
            Console.WriteLine("Enter Name Of Person You Want To Delete: ");
            string deleteName = Console.ReadLine();
            if (addressBook.Count > 0)
            {
                if (addressBook.ContainsKey(delAddressBookName))
                {
                    foreach (KeyValuePair<string, List<ContactDetails>> dictionary in addressBook)
                    {
                        if (dictionary.Key.Equals(delAddressBookName))
                        {
                            foreach (var item in dictionary.Value)
                            {
                                if (deleteName.ToLower() == item.firstName.ToLower())
                                {
                                    dictionary.Value.Remove(item);
                                    Console.WriteLine("#################Deleted################");
                                    Console.WriteLine("You Deleted " + item.firstName + "Contact From Selected Address Book");
                                    flag = 1;
                                    break;
                                }
                            }
                            if (flag == 0)
                            {
                                Console.WriteLine("he Name Entered Is Not In Selected Address Book");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Address Book Is Not Found");
                }
            }
            else
            {
                Console.WriteLine("Address Book Is Empty");
            }
        }

        public void SearchDetails()
        {
            string personName;
            Console.WriteLine("1. Search by city name\n2.Search By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to search:");
                    string cityName = Console.ReadLine();
                    Console.WriteLine("Enter the name of person you want to search:");
                    personName = Console.ReadLine();
                    SearchByCityName(cityName, personName);
                    break;
                case 2:
                    Console.WriteLine("Enter the state of city in which you want to search:");
                    string stateName = Console.ReadLine();
                    Console.WriteLine("Enter the name of person you want to search:");
                    personName = Console.ReadLine();
                    SearchByStateName(stateName, personName);
                    break;
                default:
                    return;

            }

        }
        public void SearchByCityName(string cityName, string personName)
        {
            if (addressBook.Count > 0)
            {

                foreach (KeyValuePair<string, List<ContactDetails>> dict in addressBook)
                {
                    searchingContacts = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.state.Equals(cityName));


                }
                if (searchingContacts.Count > 0)
                {
                    foreach (var item in searchingContacts)
                    {
                        Print(item);
                    }
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }

        public void SearchByStateName(string stateName, string personName)
        {
            if (addressBook.Count > 0)
            {

                foreach (KeyValuePair<string, List<ContactDetails>> dict in addressBook)
                {
                    searchingContacts = dict.Value.FindAll(x => x.firstName.Equals(personName) && x.state.Equals(stateName));

                }
                if (searchingContacts.Count > 0)
                {
                    foreach (var x in searchingContacts)
                    {
                        Print(x);
                    }
                }
                else
                {
                    Console.WriteLine("Person not found");
                }
            }
            else
            {
                Console.WriteLine("Adress Book Is Empty");
            }

        }
        public void ViewDetailsByStateOrCity()
        {

            Console.WriteLine("1. View by city name\n2.View By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to view:");
                    string cityName = Console.ReadLine();
                    ViewByCityName(cityName, "view");
                    break;
                case 2:
                    Console.WriteLine("Enter the name of state in which you want to view:");
                    string stateName = Console.ReadLine();
                    ViewByStateName(stateName, "view");
                    break;
                default:
                    return;

            }

        }

        public void CountByStateOrCity()
        {

            Console.WriteLine("1.Count by city name\n2.Count By state name\nEnter your option:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter the name of city in which you want to count persons:");
                    string cityName = Console.ReadLine();
                    ViewByCityName(cityName, "count");
                    break;
                case 2:
                    Console.WriteLine("Enter the name of state in which you want to count persons:");
                    string stateName = Console.ReadLine();
                    ViewByStateName(stateName, "count");
                    break;
                default:
                    return;

            }

        }

        public void ViewByCityName(string cityName, string check)
        {
            if (addressBook.Count > 0)
            {

                foreach (KeyValuePair<string, List<ContactDetails>> dict in addressBook)
                {
                    viewingContacts = dict.Value.FindAll(x => x.state.Equals(cityName));
                }
                if (check.Equals("view"))
                {
                    if (viewingContacts.Count > 0)
                    {
                        foreach (var x in viewingContacts)
                        {
                            Print(x);
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Details found ");
                    }
                }
                else
                {
                    searchforCity = viewingContacts.Count;
                    Console.WriteLine("The total persons in " + cityName + " are: " + searchforCity);
                }

            }
            else
            {
                Console.WriteLine("Adress Book Is Empty");
            }
        }

        public void ViewByStateName(string stateName, string check)
        {
            if (addressBook.Count > 0)
            {

                foreach (KeyValuePair<string, List<ContactDetails>> dict in addressBook)
                {
                    viewingContacts = dict.Value.FindAll(x => x.state.Equals(stateName));
                }
                if (check.Equals("view"))
                {
                    if (viewingContacts.Count > 0)
                    {
                        foreach (var x in viewingContacts)
                        {
                            Print(x);
                        }

                    }
                    else
                    {
                        Console.WriteLine("No Details found ");
                    }
                }
                else
                {
                    searchforState = viewingContacts.Count;
                    Console.WriteLine("The total persons in " + stateName + "are: " + searchforState);
                }
            }
            else
            {
                Console.WriteLine("Adress book is empty");
            }
        }
        public void SortEntries()
        {
            Console.WriteLine("1.Sort by person name\n2.Sort by city name\n3.Sort by state name\n4.Sort by zipcode\nEnter Your option");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    SortList("name");
                    break;
                case 2:
                    SortList("city");
                    break;
                case 3:
                    SortList("state");
                    break;
                case 4:
                    SortList("zipcode");
                    break;

            }
        }
        public void SortList(string check)
        {
            if (addressBook.Count > 0)
            {
                foreach (KeyValuePair<string, List<ContactDetails>> dict in addressBook)
                {
                    switch (check)
                    {
                        case "name":
                            SortedList = dict.Value.OrderBy(x => x.firstName).ToList();
                            break;
                        case "city":
                            SortedList = dict.Value.OrderBy(x => x.city).ToList();
                            break;
                        case "state":
                            SortedList = dict.Value.OrderBy(x => x.state).ToList();
                            break;
                        case "zipcode":
                            SortedList = dict.Value.OrderBy(x => x.zipCode).ToList();
                            break;
                    }

                    Console.WriteLine($"**********AFTER SORTING" + dict.Key + "**********");
                    foreach (var addressBook in SortedList)
                    {
                        Print(addressBook);
                    }
                }
            }
            else
            {
                Console.WriteLine("Address Book is Empty");
            }

        }
        public void ReadFromFile()
        {
            string filePath = @"C:\Users\ADVANCED\Desktop\Day 27 Assignment Problems\AddressBookFileIO\AddressBookFileIO\AddressBook.txt";

            StreamReader readFile = new StreamReader(filePath);
            using (readFile)
            {
                string datainFile;
                while ((datainFile = readFile.ReadLine()) != null)
                {
                    Console.WriteLine(datainFile);
                }
            }

        }

        public void WriteToFile()
        {
            string filePath = @"C:\Users\ADVANCED\Desktop\Day 27 Assignment Problems\AddressBookFileIO\AddressBookFileIO\AddressBook.txt";
            if (addressBook.Count > 0)
            {
                File.WriteAllText(filePath, string.Empty);
                foreach (KeyValuePair<string, List<ContactDetails>> dict in addressBook)
                {
                    File.AppendAllText(filePath, $"{dict.Key}\n");
                    foreach (var addressBook in dict.Value)
                    {
                        string text = $"{addressBook.firstName},{addressBook.lastName},{addressBook.address},{addressBook.city},{addressBook.state},{addressBook.zipCode},{addressBook.phoneNumber},{addressBook.emailid}\n";
                        File.AppendAllText(filePath, text);
                    }
                }
                    Console.WriteLine("successfully stored in file");
            }
            else
            {
                Console.WriteLine("Address Book is Empty");
            }
        }
    }
}
