using DataAccessLayer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class clsContact
    {
        public clsContact()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;
            this.ImagePath = "";

            _Mode = enMode.Add;
        }
        private clsContact(stContact stContact)
        {
            this.ID = stContact.ID;
            this.FirstName = stContact.FirstName;
            this.LastName = stContact.LastName;
            this.Email = stContact.Email;
            this.Phone = stContact.Phone;
            this.Address = stContact.Address;
            this.DateOfBirth = stContact.DateOfBirth;
            this.CountryID = stContact.CountryID;
            this.ImagePath = stContact.ImagePath;

            _Mode = enMode.Update;
        }
        private clsContact(int ID, string FirstName, string LastName, string Email,
            string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;

            _Mode = enMode.Update;

        }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }
        private enMode _Mode { get; set; }
        private bool _AddNewContact()
        {
            stContact contact = new stContact();

            contact.ID = this.ID;
            contact.FirstName = this.FirstName;
            contact.LastName = this.LastName;
            contact.Email = this.Email;
            contact.Phone = this.Phone;
            contact.Address = this.Address;
            contact.DateOfBirth = this.DateOfBirth;
            contact.CountryID = this.CountryID;
            contact.ImagePath = this.ImagePath;

            this.ID = clsContactDataAccess.AddNewContact(contact);

            return this.ID != -1;
        }
        private bool _UpdateContact()
        {
            stContact contact = new stContact();

            contact.ID = this.ID;
            contact.FirstName = this.FirstName;
            contact.LastName = this.LastName;
            contact.Email = this.Email;
            contact.Phone = this.Phone;
            contact.Address = this.Address;
            contact.DateOfBirth = this.DateOfBirth;
            contact.CountryID = this.CountryID;
            contact.ImagePath = this.ImagePath;

            return  clsContactDataAccess.UpdateContact(contact);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                {
                     if (_AddNewContact())
                     {
                            _Mode = enMode.Update;
                            return true;
                     }
                     else
                     {
                            return false;
                     }
                }
                case enMode.Update:
                {
                        return _UpdateContact();
                }
            }
            
            return false;
        }
        public static clsContact Find(int ID)
        {
            stContact Contact = new stContact();

            if(clsContactDataAccess.FindContactByID(ID, ref Contact))
            {
                return new clsContact(Contact);
            }

            return null;
        }
        public static bool DeleteContact(int contactID)
        {
            return clsContactDataAccess.DeleteContact(contactID);
        }
        public static DataTable GetAllContact()
        {
            return clsContactDataAccess.GetAllContact();
        }
        public static bool IsContactExist(int contactID)
        {
            return clsContactDataAccess.IsContactExist(contactID);
        }
    }
}
