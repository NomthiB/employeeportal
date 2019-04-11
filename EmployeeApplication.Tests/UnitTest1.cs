using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeApplication;
using EmployeeEdit = EmployeeApplication.Forms.EditEmployee;
using EmployeeApplication.DataModel.Entities;

namespace EmployeeApplication.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmailAddressValidationTest()
        {
            string incorrectEmail = "incorrect.com";
            string correctEmail = "ingo@gmail.com";
            string ErrorMessage = "";
            bool Results = EmployeeEdit.IsValidEmail(incorrectEmail, out ErrorMessage);
            bool secondResults = EmployeeEdit.IsValidEmail(correctEmail, out ErrorMessage);

            Assert.AreEqual(Results, false);
            Assert.AreEqual(secondResults, true);
        }

        [TestMethod]
        public void URLValidationTest()
        {
            string FalseURI = "info@gmail.com";
            string ActualURI = "https://www.zoho.com/crm/";
            string ErrorMessage = "";
            bool Results = EmployeeEdit.IsValidURI(FalseURI, out ErrorMessage);
            bool SecondResults = EmployeeEdit.IsValidURI(ActualURI, out ErrorMessage);

            Assert.AreEqual(Results, false);
            Assert.AreEqual(SecondResults, true);
        }
    }
}
