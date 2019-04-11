using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmployeeApplication.DataModel.Entities
{
    [Serializable]
    public class Employee:Base
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public string LandLine { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string TwitterHandle { get; set; }
        public string InstagramHandle { get; set; }
        
        public bool Active { get; set; }
        public Employee() : base()
        {
            EmployeeID = -1;
            FirstName = "";
            LastName = "";
            Email = "";
            CellNumber = "";
            LandLine = null;
            AddressLine1 = "";
            AddressLine2 = "";
            PostalCode = "";
            Facebook = null;
            LinkedIn = null;
            TwitterHandle = null;
            InstagramHandle = null;
            Active = false;
        }

        public Employee(DataRow pData) : base(pData)
        {
            EmployeeID = GetInteger(pData, "EmployeeID");
            FirstName = GetString(pData, "FirstName");
            LastName = GetString(pData, "LastName");
            Email = GetString(pData, "Email");
            CellNumber = GetString(pData, "CellNumber");
            LandLine = GetString(pData, "LandLine");
            AddressLine1 = GetString(pData, "AddressLine1");
            AddressLine2 = GetString(pData, "AddressLine2");
            PostalCode = GetString(pData, "PostalCode");
            Facebook = GetString(pData, "Facebook");
            LinkedIn = GetString(pData, "LinkedIn");
            TwitterHandle = GetString(pData, "TwitterHandle");
            InstagramHandle = GetString(pData, "InstagramHandle");
            Active = GetBoolean(pData, "Active");
        }

       
    }
}