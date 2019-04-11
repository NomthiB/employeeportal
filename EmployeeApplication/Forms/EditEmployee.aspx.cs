using EmployeeApplication.DataModel.Controllers;
using EmployeeApplication.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EmployeeApplication.Forms
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        public int EmployeeID
        {
            get
            {
                if (Session["EmployeeID"] == null) Session["EmployeeID"] = "-1";
                return Convert.ToInt32(Session["EmployeeID"]);
            }
            set
            {
                Session["EmployeeID"] = value.ToString();
            }
        }

        public EmployeeController EmployeeController = new EmployeeController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!Page.IsPostBack)
            {
                EmployeeID = Request.QueryString["EmployeeID"] == null ? -1 : Convert.ToInt32(Request.QueryString["EmployeeID"]);
                if (EmployeeID > 0)
                {
                    LoadEmployeeDetails();
                }
            }
        }

        private void LoadEmployeeDetails()
        {
            Employee employee = EmployeeController.GetEmployee(EmployeeID);
            NameTextBox.Text = employee.FirstName;
            SurnameTextBox.Text = employee.LastName;
            EmailTextBox.Text = employee.Email;
            MobilemMaskedTextBox.Text = employee.CellNumber;
            LandlineMaskedTextBox.Text = employee.LandLine;
            StreetTextBox.Text = employee.AddressLine1;
            SuburbTextBox.Text = employee.AddressLine2;
            PostalCodeTextBox.Text = employee.PostalCode;
            FacebookTextBox.Text = employee.Facebook;
            TwitterTextBox.Text = employee.TwitterHandle;
            InstagramTextBox.Text = employee.InstagramHandle;
            LinkedInTextBox.Text = employee.LinkedIn;

        }

        protected void ItemToolBar_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
        {
            switch (e.Item.Value.ToLower())
            {
                case "save":
                    SaveEmployee();
                    break;
                case "delete":
                    DeleteEmployee();
                    break;
                case "add":
                    ClearEmployeeDetails();
                    break;

            }
        }

        private void ClearEmployeeDetails()
        {
            EmployeeID = -1;
            foreach (Control item in Page.Form.FindControl("ContentPlaceHolder1").Controls)
            {
                if (item is RadTextBox)
                {
                    ((RadTextBox)item).Text = string.Empty;
                }
                if(item is RadMaskedTextBox)
                {
                    ((RadMaskedTextBox)item).Text = string.Empty;
                }
                
            }
        }

        private void DeleteEmployee()
        {
            try
            {
                EmployeeController.DeleteEmployee(EmployeeID, true);
                ClearEmployeeDetails();

                string script = "<script language='javascript'>function f(){radalert('Employee successfully deleted.', 330, 210); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", script);

            }
            catch(Exception exception)
            {
                string exceptionMessage = exception.Message.Replace("\r\n", " ").Replace("\r", "").Replace("\n", "").Replace("'", "\"");
                AlertWindowManager.RadAlert("An error occurred while deleting the employee : " + exceptionMessage, 400, 200, "Error", "");
            }
            
        }

        private void SaveEmployee()
        {
            string validationError = "";
            if(!Validation(out validationError))
            {
                AlertWindowManager.RadAlert(validationError, 400, 200, "Error", "");
                return;
            }
            try
            {
                Employee employee = new Employee();
                employee.FirstName = NameTextBox.Text;
                employee.LastName = SurnameTextBox.Text;
                employee.Email = EmailTextBox.Text;
                employee.CellNumber = MobilemMaskedTextBox.Text;
                employee.LandLine = LandlineMaskedTextBox.Text;
                employee.AddressLine1 = StreetTextBox.Text;
                employee.AddressLine2 = SuburbTextBox.Text;
                employee.PostalCode = PostalCodeTextBox.Text;
                employee.InstagramHandle = InstagramTextBox.Text;
                employee.Facebook = FacebookTextBox.Text;
                employee.TwitterHandle = TwitterTextBox.Text;
                employee.LinkedIn = LinkedInTextBox.Text;
                employee.Active = true;

                if (EmployeeID > 0)
                {
                    employee.EmployeeID = EmployeeID;
                    
                    EmployeeController.UpdateEmployee(employee);
                }
                else
                {
                    EmployeeID = EmployeeController.InsertEmployee(employee);
                }
                string script = "<script language='javascript'>function f(){radalert('Employee successfully saved.', 330, 210); Sys.Application.remove_load(f);}; Sys.Application.add_load(f);</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", script);
            }
            catch (Exception exception)
            {
                string exceptionMessage = exception.Message.Replace("\r\n", " ").Replace("\r", "").Replace("\n", "").Replace("'", "\"");
                AlertWindowManager.RadAlert("An error occurred while saving the employee details : " + exceptionMessage, 400, 200, "Error", "");
            }
        }

        private bool Validation(out string validationError)
        {
            validationError = "";
            bool IsValid = true;
            

            if(!IsValidEmail(EmailTextBox.Text.ToString(),out validationError))
            {
                return false;
            }
            
            if(!IsValidURI(FacebookTextBox.Text.ToString(), out validationError))
            {
                return false;
            }
            if(!IsValidURI(InstagramTextBox.Text.ToString(), out validationError))
            {
                return false;
            }
            if(!IsValidURI(LinkedInTextBox.Text.ToString(), out validationError))
            {
                return false;
            }

            return IsValid;
        }

        public static bool IsValidEmail(string emailAddress, out string validationError)
        {
            validationError = "";
            if (emailAddress != string.Empty)
            {
                try
                {
                    MailAddress Address = new MailAddress(emailAddress);

                    return true;
                }
                catch (FormatException)
                {
                    validationError = "Invalid email address.";
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidURI(string URI,out string validationError)
        {
            validationError = "";
            if (URI != string.Empty)
            {
                if (Uri.IsWellFormedUriString(URI, UriKind.Absolute))
                {
                    return true;
                }
                else
                {
                    validationError = URI + " is an invalid URL.";
                    return false;
                }
            }
            else
            {
                return true;
            }
                    
        }
    }
}