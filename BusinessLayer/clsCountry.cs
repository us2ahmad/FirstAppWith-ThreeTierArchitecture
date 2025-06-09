using DataAccessLayer;
using System.Data;

namespace BusinessLayer
{
    public class clsCountry
    {
        public clsCountry()
        {
            this.ID = -1;
            this.Name = "";
            this.Code = "";
            this.PhoneCode = "";
            _Mode = enMode.Add;
        }
        private clsCountry(int ID, string Name,string Code , string PhoneCode)
        {
            this.ID = ID;
            this.Name = Name;
            this.Code = Code;
            this.PhoneCode = PhoneCode;

            _Mode = enMode.Update;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }
        private enMode _Mode { get; set; }
        private bool _AddNewCounty()
        {
            this.ID = clsCountryDataAccess.AddNewCountry(this.Name, this.Code, this.PhoneCode);

            return this.ID != -1;
        }
        private bool _UpdateCounty()
        {
            return clsCountryDataAccess.UpdateCountry(this.ID, this.Name, this.Code, this.PhoneCode);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                {
                    if (_AddNewCounty())
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
                        return _UpdateCounty();
                }
            }

            return false;
        }
        public static clsCountry Find(int ID)
        {
            string CountryName = "", Code = "", PhoneCode = "";

            if (clsCountryDataAccess.FindCountryByID(ID, ref CountryName, ref Code,ref PhoneCode))
            {
                return new clsCountry(ID, CountryName, Code,PhoneCode);
            }

            return null;
        }
        public static clsCountry Find(string CountryName)
        {
            int ID = -1;
            string Code = "", PhoneCode = "";

            if (clsCountryDataAccess.FindCountryByName(ref ID, ref CountryName, ref Code, ref PhoneCode))
            {
                return new clsCountry(ID, CountryName, Code, PhoneCode);
            }
            return null;
        }
        public static bool DeleteCountry(int CountryID)
        {
            return clsCountryDataAccess.DeleteCountry(CountryID);
        }
        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }
        public static bool IsCountryExist(int CountryID)
        {
            return clsCountryDataAccess.IsCountryExist(CountryID);
        }
        public static bool IsCountryExist(string CountryName)
        {
            return clsCountryDataAccess.IsCountryExist(CountryName);
        }
    }
}
