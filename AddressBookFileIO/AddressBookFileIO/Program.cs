using System;

namespace AddressBookFileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("##################Welcome to the Address Book Program################");
            AddressBookBuilder adressbook = new AddressBookBuilder();
            while (true)
            {
                Console.WriteLine("*********************************************************");
                Console.WriteLine("1. Add Member to Contact list \n2. View Members in Contact List\n3. Edit members Contacts lists\n4. Delete members Contacts list\n5. Search Details\n6. Count\n7. SortEntries\n8. Read From File\n9. Write To File\n10. Exit");
                Console.WriteLine("Enter an option:");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        adressbook.AddContact();
                        break;
                    case 2:
                        adressbook.ViewContactPerson();
                        break;
                    case 3:
                        adressbook.editingDetails();
                        break;
                    case 4:
                        adressbook.DeleteContact();
                        break;
                    case 5:
                        adressbook.SearchDetails();
                        break;
                    case 6:
                        adressbook.CountByStateOrCity();
                        break;
                    case 7:
                        adressbook.SortEntries();
                        break;
                    case 8:
                        adressbook.ReadFromFile();
                        break;
                    case 9:
                        adressbook.WriteToFile();
                        break;
                    case 10:
                        Console.WriteLine("Exited");
                        return;
                }

            }

        }
    }
}
