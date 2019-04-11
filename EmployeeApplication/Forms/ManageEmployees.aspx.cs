using EmployeeApplication.DataModel.Controllers;
using EmployeeApplication.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EmployeeApplication.Forms
{
    public partial class ManageEmployees : System.Web.UI.Page
    {
        public EmployeeController EmployeeController = new EmployeeController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void EmployeeList_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            EmployeeList.DataSource = EmployeeController.ListEmployee();

        }

        protected void EmployeeList_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {

                GridDataItem Item = (GridDataItem)e.Item;
                Employee lDataItem = (Employee)e.Item.DataItem;

                RadButton btnViewDeatails = (RadButton)e.Item.FindControl("btnViewDetails");
                if (!object.ReferenceEquals(btnViewDeatails, null)) btnViewDeatails.OnClientClicking = "function(button, args){window.location.replace('/Forms/EditEmployee.aspx?EmployeeID="+ lDataItem.EmployeeID.ToString() + "');}";

            }
        }

        protected void ItemToolBar_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            switch (e.Item.Value.ToLower())
            {
                case "export":
                    EmployeeList.MasterTableView.GetColumn("ViewDetails").Visible = false;
                    EmployeeList.MasterTableView.ExportToExcel();
                    break;
            }
        }
    }
}