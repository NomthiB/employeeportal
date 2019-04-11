using EmployeeApplication.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmployeeApplication.DataModel.DataAccess
{
    internal partial class EmployeeDataAccess:DatabaseAccess
    {
        public EmployeeDataAccess() : base() { }

        public Employee GetEmployee(int pEmployeeID)
        {
            clearParameters();
            addParameter("@pEmployeeID", SqlDbType.Int, pEmployeeID);

            DataTable lRawData = ExecuteDataSet("prcGet_Employee").Tables[0];

            if (lRawData.Rows.Count > 1) throw new Exception("prcGet_Employee returned " + lRawData.Rows.Count + " rows. Expecting one row.");
            else if (lRawData.Rows.Count == 1) return new Employee(lRawData.Rows[0]);
            else return null;
        }

        public List<Employee> ListEmployee()
        {
            List<Employee> lObjectList = new List<Employee>();
            clearParameters();

            DataTable lRawData = ExecuteDataSet("prcList_Employee").Tables[0];

            foreach (DataRow lRow in lRawData.Rows)
            {
                lObjectList.Add(new Employee(lRow));
            }

            return lObjectList;
        }

        public bool DeleteEmployee(int pEmployeeID, bool pHardDelete)
        {
            clearParameters();
            addParameter("@pEmployeeID", SqlDbType.Int, pEmployeeID);
            addParameter("@pHardDelete", SqlDbType.Bit, pHardDelete);

            object lResult = ExecuteScalar("prcDelete_Employee");
            return Convert.ToBoolean(lResult);
        }

        public int InsertEmployee(Employee pEmployee)
        {
            clearParameters();
            addParameter("@pFirstName", SqlDbType.VarChar, pEmployee.FirstName);
            addParameter("@pLastName", SqlDbType.VarChar, pEmployee.LastName);
            addParameter("@pEmail", SqlDbType.VarChar, pEmployee.Email);
            addParameter("@pCellNumber", SqlDbType.VarChar, pEmployee.CellNumber);
            addParameter("@pLandLine", SqlDbType.VarChar,pEmployee.LandLine);
            addParameter("@pAddressLine1", SqlDbType.VarChar, pEmployee.AddressLine1);
            addParameter("@pAddressLine2", SqlDbType.VarChar, pEmployee.AddressLine2);
            addParameter("@pPostalCode", SqlDbType.VarChar, pEmployee.PostalCode);
            addParameter("@pFacebook", SqlDbType.VarChar, pEmployee.Facebook );
            addParameter("@pLinkedIn", SqlDbType.VarChar, pEmployee.LinkedIn);
            addParameter("@pTwitterHandle", SqlDbType.VarChar, pEmployee.TwitterHandle);
            addParameter("@pInstagramHandle", SqlDbType.VarChar, pEmployee.InstagramHandle );

            object lResult = ExecuteScalar("prcInsert_Employee");

            int lObjectID;
            if (Int32.TryParse(lResult.ToString(), out lObjectID)) return lObjectID;
            else return -1;
        }

        public bool UpdateEmployee(Employee pEmployee)
        {
            clearParameters();
            addParameter("@pEmployeeID", SqlDbType.Int, pEmployee.EmployeeID);
            addParameter("@pFirstName", SqlDbType.VarChar, pEmployee.FirstName);
            addParameter("@pLastName", SqlDbType.VarChar, pEmployee.LastName);
            addParameter("@pEmail", SqlDbType.VarChar, pEmployee.Email);
            addParameter("@pCellNumber", SqlDbType.VarChar, pEmployee.CellNumber);
            addParameter("@pLandLine", SqlDbType.VarChar, pEmployee.LandLine);
            addParameter("@pAddressLine1", SqlDbType.VarChar, pEmployee.AddressLine1);
            addParameter("@pAddressLine2", SqlDbType.VarChar, pEmployee.AddressLine2);
            addParameter("@pPostalCode", SqlDbType.VarChar, pEmployee.PostalCode);
            addParameter("@pFacebook", SqlDbType.VarChar, pEmployee.Facebook );
            addParameter("@pLinkedIn", SqlDbType.VarChar, pEmployee.LinkedIn );
            addParameter("@pTwitterHandle", SqlDbType.VarChar, pEmployee.TwitterHandle );
            addParameter("@pInstagramHandle", SqlDbType.VarChar, pEmployee.InstagramHandle);
            addParameter("@pActive", SqlDbType.Bit, pEmployee.Active);


            object lResult = ExecuteScalar("prcUpdate_Employee");
            return Convert.ToBoolean(lResult);
        }
    }
}