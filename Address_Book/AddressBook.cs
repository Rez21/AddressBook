using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    class AddressBook
    {
        // Constants
        private const int UPDATE_FIRST_NAME = 1;
        private const int UPDATE_LAST_NAME = 2;
        private const int UPDATE_ADDRESS = 3;
        private const int UPDATE_CITY = 4;
        private const int UPDATE_STATE = 5;
        private const int UPDATE_ZIP = 6;
        private const int UPDATE_PHONE_NUMBER = 7;
        private const int UPDATE_EMAIL = 8;

        // Variables
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phoneNumber;
        private string email;
        private int contactSerialNum = 0;
        public string nameOfAddressBook = " ";

        // Object initialisation

        public List<ContactDetails> contactList = new List<ContactDetails>();

        public AddressBook(string name)
        {
            nameOfAddressBook = name;
        }
        public void AddContact()
        {
            // Getting FirstName
            Console.WriteLine("\nEnter The First Name of Contact");
            firstName = Console.ReadLine();

            // Getting lastName
            Console.WriteLine("\nEnter The Last Name of Contact");
            lastName = Console.ReadLine();

            // Getting Address
            Console.WriteLine("\nEnter The Address of Contact");
            address = Console.ReadLine();

            // Getting city name
            Console.WriteLine("\nEnter The City Name of Contact");
            city = Console.ReadLine();

            // Getting state name
            Console.WriteLine("\nEnter The State Name of Contact");
            state = Console.ReadLine();

            // Getting zip of locality
            Console.WriteLine("\nEnter the Zip of Locality of Contact");
            zip = Console.ReadLine();

            // Getting Phone number
            Console.WriteLine("\nEnter The Phone Number of Contact");
            phoneNumber = Console.ReadLine();

            // Getting Email of contact
            Console.WriteLine("\nEnter The Email of Contact");
            email = Console.ReadLine();

            // Creating an instance of contact with given details
            ContactDetails addNewContact = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, email);

            // Checking for duplicates with the equals method
            // Loop continues till the given contact doesnt equal to any available contact
            while (addNewContact.Equals(contactList))
            {
                Console.WriteLine("contact already exists");


                // Giving option to user to re enter or to exit
                Console.WriteLine("Type Y to enter new name or any other key to exit");

                // If user wants to re-enter then taking input from user
                // Else return 
                if ((Console.ReadLine().ToLower() == "y"))
                {
                    Console.WriteLine("Enter new first name");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Enter new last name");
                    lastName = Console.ReadLine();
                    addNewContact = new ContactDetails(firstName, lastName, address, city, state, zip, phoneNumber, email);
                }
                else
                    return;
            }

            // Adding the contact to list
            contactList.Add(addNewContact);
            Console.WriteLine("\nContact Added");

        }
        public void DisplayContactDetails()
        {
            // If the List doesnt have any contacts
            // Else get the name to search for details
            if (contactList.Count() == 0)
                Console.WriteLine("No saved contacts");
            else
            {
                Console.WriteLine("\nEnter the name of candidate to get Details");
                string name = Console.ReadLine().ToLower();


                // Search the contact by name
                contactSerialNum = SearchByName(name);

                // Print the details of the contact after search
                ToString(contactSerialNum);
            }
        }
        public void UpdateContact()
        {
            // If the List have no contacts
            if (contactList.Count() == 0)
            {
                Console.WriteLine("No saved contacts");
                return;
            }

            // Input the name to be updated
            Console.WriteLine("\nEnter the name of candidate to be updated");
            string name = Console.ReadLine();


            // Search the name
            int contactSerialNum = SearchByName(name);

            // To print details of searched contact
            ToString(contactSerialNum);

            // If contact doesnt exist
            if (contactSerialNum < 0)
                return;
            int updateAttributeNum = 0;

            // Getting the attribute to be updated
            Console.WriteLine("\nEnter the row number attribute to be updated or 0 to exit");
            try
            {
                updateAttributeNum = Convert.ToInt32(Console.ReadLine());
                if (updateAttributeNum == 0)
                    return;
            }
            catch
            {
                Console.WriteLine("Invalid entry");
                return;
            }

            // Getting the new value of attribute
            Console.WriteLine("\nEnter the new value to be entered");
            string newValue = Console.ReadLine();

            // Updating selected attribute with selected value
            switch (updateAttributeNum)
            {
                case UPDATE_FIRST_NAME:

                    // Store the firstname of given contact in variable
                    firstName = contactList[contactSerialNum].firstName;

                    // Update the contact with given name
                    contactList[contactSerialNum].firstName = newValue;

                    // If duplicate contact exists with that name then revert the operation
                    if (contactList[contactSerialNum].Equals(contactList))
                    {
                        contactList[contactSerialNum].firstName = firstName;
                        Console.WriteLine("Contact already exists with that name");
                        return;
                    }
                    break;
                case UPDATE_LAST_NAME:

                    // Store the LastName of given contact in variable
                    lastName = contactList[contactSerialNum].firstName;

                    // Update the contact with given name
                    contactList[contactSerialNum].firstName = newValue;

                    // If duplicate contact exists with that name then revert the operation
                    if (contactList[contactSerialNum].Equals(contactList))
                    {
                        contactList[contactSerialNum].lastName = lastName;
                        Console.WriteLine("Contact already exists with that name");
                        return;
                    }
                    break;
                case UPDATE_ADDRESS:
                    contactList[contactSerialNum].address = newValue;
                    break;
                case UPDATE_CITY:
                    contactList[contactSerialNum].city = newValue;
                    break;
                case UPDATE_STATE:
                    contactList[contactSerialNum].state = newValue;
                    break;
                case UPDATE_ZIP:
                    contactList[contactSerialNum].zip = newValue;
                    break;
                case UPDATE_PHONE_NUMBER:
                    contactList[contactSerialNum].phoneNumber = newValue;
                    break;
                case UPDATE_EMAIL:
                    contactList[contactSerialNum].email = newValue;
                    break;
                default:
                    Console.WriteLine("Invalid Entry");
                    return;
            }

            Console.WriteLine("\nUpdate Successful");
        }
        public void RemoveContact()
        {
            // If the List does not have any contacts
            if (contactList.Count() == 0)
            {
                Console.WriteLine("No saved contacts");
                return;
            }

            // Input the name of the contact to be removed
            Console.WriteLine("\nEnter the name of contact to be removed");
            string name = Console.ReadLine().ToLower();

            // Search for the contact
            int contactSerialNum = SearchByName(name);

            // Print the details of contact for confirmation
            ToString(contactSerialNum);

            // If contact doesnt exist then exit
            if (contactSerialNum < 0)
                return;
            // Asking for confirmation to delete contact
            // If user says yes(y) then delete the contact
            Console.WriteLine("Press y to confirm delete or any other key to abort");
            switch (Console.ReadLine().ToLower())
            {
                case "y":
                    contactList.RemoveAt(contactSerialNum);
                    Console.WriteLine("Contact deleted");

                    break;
                default:
                    Console.WriteLine("Deletion aborted");

                    break;
            }
        }
        public void GetAllContacts()
        {
            // If the List does not have any contacts
            if (contactList.Count() == 0)
            {
                Console.WriteLine("\nNo saved contacts");
                return;
            }


            // Display all contact details in list
            foreach (ContactDetails contact in contactList)
                ToString(contactList.IndexOf(contact));
        }
        private void ToString(int contactSerialNum)
        {
            if (contactSerialNum < 0)
            {
                Console.WriteLine("Contact Not found");

                return;
            }

            // Display all the atributes of contact
            int rowNum = 1;
            Console.WriteLine("\nname of contact is {0}", contactList[contactSerialNum].firstName + " " + contactList[contactSerialNum].lastName);
            Console.WriteLine("{0}-firstname is {1}", rowNum++, contactList[contactSerialNum].firstName);
            Console.WriteLine("{0}-lastname is {1}", rowNum++, contactList[contactSerialNum].lastName);
            Console.WriteLine("{0}-address is {1}", rowNum++, contactList[contactSerialNum].address);
            Console.WriteLine("{0}-city is {1}", rowNum++, contactList[contactSerialNum].city);
            Console.WriteLine("{0}-state is {1}", rowNum++, contactList[contactSerialNum].state);
            Console.WriteLine("{0}-zip is {1}", rowNum++, contactList[contactSerialNum].zip);
            Console.WriteLine("{0}-phoneNumber is {1}", rowNum++, contactList[contactSerialNum].phoneNumber);
            Console.WriteLine("{0}-email is {1}", rowNum++, contactList[contactSerialNum].email);
        }
        private int SearchByName(string name)
        {
            // If the list is empty
            if (contactList.Count == 0)
                return -1;
            int numOfContactsSearched = 0;

            // Search if Contacts have the given string in name
            foreach (ContactDetails contact in contactList)
            {
                // Incrementing the no of contacts searched
                numOfContactsSearched++;

                // storing the count of contacts with searched name string
                int numOfConatctsWithNameSearched = 0;

                // If contact name matches exactly then it returns the index of that contact
                if ((contact.firstName + " " + contact.lastName).Equals(name))
                    return contactList.IndexOf(contact);

                // If a part of contact name matches then we would ask them to enter accurately
                if ((contact.firstName + " " + contact.lastName).Contains(name))
                {

                    numOfConatctsWithNameSearched++; // num of contacts having search string
                    Console.WriteLine("\nname of contact is {0}", contact.firstName + " " + contact.lastName);
                }

                // If string is not part of any name then exit
                if (numOfContactsSearched == contactList.Count() && numOfConatctsWithNameSearched == 0)
                    return -1;
            }

            // Ask to enter name accurately
            Console.WriteLine("\nInput the contact name as firstName lastName\n or E to exit");
            name = Console.ReadLine();

            // To exit
            if (name.ToLower() == "e")
                return -1;

            // To continue search with new name
            return SearchByName(name);
        }
    }
}