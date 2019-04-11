using EmployeeApplication.DataModel.DataAccess;
using EmployeeApplication.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApplication.DataModel.Controllers
{
    public partial class EmployeeController
    {
        private EmployeeDataAccess _employeeDataAccess;
        private EmployeeDataAccess employeeDataAccess
        {
            get { return _employeeDataAccess ?? (_employeeDataAccess = new EmployeeDataAccess()); }
        }
        public EmployeeController() { }
        public Employee GetEmployee(int pEmployeeID)
        {
            return employeeDataAccess.GetEmployee(pEmployeeID);
        }

        public List<Employee> ListEmployee()
        {
            return employeeDataAccess.ListEmployee();
        }

        public bool DeleteEmployee(int pEmployeeID, bool pHardDelete)
        {
            return employeeDataAccess.DeleteEmployee(pEmployeeID, pHardDelete);
        }
        //public bool DeactivateEmployee(int pEmployeeID)
        //{
        //    return employeeDataAccess.DeactivateEmployee(pEmployeeID);
        //}

        public int InsertEmployee(Employee pEmployee)
        {
            return employeeDataAccess.InsertEmployee(pEmployee);
        }

        public bool UpdateEmployee(Employee pEmployee)
        {
            return employeeDataAccess.UpdateEmployee(pEmployee);
        }
    }
}