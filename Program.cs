using BusinessLayer;
using System;
using System.Data;

namespace ContactsConsoleApp
{
    internal class Program
    {
        static void testFindContact(int ID)
        {
            clsContact contact = clsContact.Find(ID);

            if (contact != null)
            {
                Console.WriteLine($"Contact ID : {contact.ID}");
                Console.WriteLine($"First Name : {contact.FirstName}");
                Console.WriteLine($"Last Name : {contact.LastName}");
                Console.WriteLine($"Email : {contact.Email}");
                Console.WriteLine($"Phone : {contact.Phone}");
                Console.WriteLine($"Address : {contact.Address}");
                Console.WriteLine($"DateOfBirth : {contact.DateOfBirth}");
                Console.WriteLine($"Country ID : {contact.CountryID}");
                Console.WriteLine($"ImagePath : {contact.ImagePath}");
                Console.WriteLine("----------------------------------------------------------");
            }
            else
            {
                Console.WriteLine($"Contact [{ID}] Not Found!");
            }
        }
        static void testAddNewContact()
        {
            clsContact contact = new clsContact()
            {
                FirstName = "Ahmad11",
                LastName = "Yassin",
                Email = "Ahmad11@gmail.com",
                Phone = "002115",
                Address = "Syria",
                DateOfBirth = new  DateTime(2000,1,3),
                CountryID = 7,
                ImagePath = ""
            };

            if (contact.Save())
            {
                Console.WriteLine($"Contact Added Successfully With Id = {contact.ID}");
            }
            else
            {
                Console.WriteLine("Can't Save");
            }
        }
        static void testUpdateContact(int contactID)
        {
            clsContact contact = clsContact.Find(contactID);
           
            if (contact != null)
            {
                contact.FirstName = "Yassin";
                contact.LastName = "Ahmad";
                contact.Email = "Yasssin@hotmail.com";
                contact.Phone= "0111111";
                contact.Address = "Egypt";
                contact.DateOfBirth = DateTime.Now;
                contact.CountryID= 4;
                contact.ImagePath= "C:\\Desktop";
                if (contact.Save())
                {
                    Console.WriteLine($"Contact Updated Successfully With Id = {contact.ID}");
                }
            }
            else
            {
                Console.WriteLine($"Contact [{contact.ID}] Not Found!");
            }



        }
        static void testDeleteContact(int contactID)
        {
            if (clsContact.DeleteContact(contactID))
            {
                Console.WriteLine("Contact Deleted Successfully.");            
            }
            else
            {
                Console.WriteLine("Faild To Delete Contact.");
            }

            
        }
        static void ListContact()
        {
            DataTable dataTable = clsContact.GetAllContact();
            Console.WriteLine("\t\tContact Data");
            Console.WriteLine("-------------------------------------------\n");
            Console.WriteLine("ID\t\t\tFirstName\t\tEmail\n");
            
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]}\t\t\t{row["FirstName"]}\t\t\t{row["Email"]}");
            }

        }
        static void testIsContactExist(int contactID)
        {
            if (clsContact.IsContactExist(contactID))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
      
        ////////////////////////////////////////////////////
     
        static void testFindCountryByID(int ID)
        {
            clsCountry Country = clsCountry.Find(ID);
            if (Country != null)
            {
                Console.WriteLine(Country.Name);
            }
            else
            {
                Console.WriteLine("Country [" + ID + "] Not found!");
            }
        }
        static void testFindCountryByName(string CountryName)
        {
            clsCountry Country1 = clsCountry.Find(CountryName);

            if (Country1 != null)
            {
                Console.WriteLine("Country [" + CountryName + "] isFound with ID = " + Country1.ID);

            }

            else
            {
                Console.WriteLine("Country [" + CountryName + "] Is Not found!");
            }
        }
        static void testIsCountryExistByID(int ID)
        {
            if (clsCountry.IsCountryExist(ID))

                Console.WriteLine("Yes, Country is there.");
            else
                Console.WriteLine("No, Country Is not there.");
        }
        static void testIsCountryExistByName(string CountryName)
        {
            if (clsCountry.IsCountryExist(CountryName))
                Console.WriteLine("Yes, Country is there.");
            else
                Console.WriteLine("No, Country Is not there.");
        }
        static void testAddNewCountry()
        {
            clsCountry Country = new clsCountry();
            Country.Name = "EGYPY";
            Country.Code = "EGP";
            Country.PhoneCode = "20";

            if (Country.Save())
            {
                Console.WriteLine("Country Added Successfully with id=" + Country.ID);
            }
        }
        static void testUpdateCountry(int ID)
        {
            clsCountry Country = clsCountry.Find(ID);

            if (Country != null)
            {
                Country.Name = "Syria";
                Country.Code = "SYP";
                Country.PhoneCode = "963";

                if (Country.Save())
                {
                    Console.WriteLine("Country updated Successfully ");
                }
            }
            else
            {
                Console.WriteLine("Country is you want to update is Not found!");
            }
        }
        static void testDeleteCountry(int ID)
        {
            if (clsCountry.IsCountryExist(ID))
            {
                if (clsCountry.DeleteCountry(ID))
                    Console.WriteLine("Country Deleted Successfully.");
                else
                    Console.WriteLine("Faild to delete Country.");
            }
            else
            {
                Console.WriteLine("Faild to delete: The Country with id = " + ID + " is not found");
            }

        }
        static void ListCountries()
        {
            DataTable dataTable = clsCountry.GetAllCountries();

            Console.WriteLine("Coutries Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["CountryID"]},  {row["CountryName"]}");
            }
        }
        
        ////////////////////////////////////////////////////
        
        static void Main(string[] args)
        {
            //testFindContact(10);
            //testAddNewContact();
            //testUpdateContact(18);
            //testDeleteContact(1);
            //ListContact();
            //testIsContactExist(2);
            //testIsContactExist(100);

           ////////////////////////////////////////////////////
            //testFindCountryByID(1);
            //testFindCountryByID(100);
            //testFindCountryByName("United States");
            //testFindCountryByName("UK");

            //testIsCountryExistByID(1);
            //testIsCountryExistByID(100);

            //testIsCountryExistByName("United States");
            //testIsCountryExistByName("UK");

            //testAddNewCountry();
            //testUpdateCountry(8);
            //testDeleteCountry(7);
            ListCountries();

              
            Console.ReadLine();
        }
    }
}
