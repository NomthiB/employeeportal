<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Scripts/layout.css" rel="stylesheet" />
    <div class="gradientbackground" >
      <h1>Welcome to the Employee Management Portal</h1>
        <div id="container">
            <p id="welcome">
                <br />Manage all your employee details in one place with a few simple clicks.
                <br /><br />The employee portal gives you access to all your employee details and allows you to maanage them all in one place 
                <b></b>
                <br />
            </p>
            <ul id="actions">
                <li>
                    <h2>1. View Employee Details</h2>
                    <p>You can click on the <b>View Employees</b> link and be able to view a list of all the employees. </p>
                    <p>You can also export the list of employees to excel <img src="../Icons/excel.png" /></p>
                    <img src="../Icons/employees.png" />
                </li>
                <li>
                    <h2>2. Add New Employees</h2>
                    <p>New employee joined the team? Simply add new employee deatails at the touch of a button from the Employee details page.</p>
                    <p>Click the <b>Add Employees</b> link to add new employee information. </p>
                    <img src="../Icons/employee.png" />
                </li>
                <li>
                    <h2>3. Update and save existing employees</h2>
                    <p>New social media account? An employee changed addresses? No worries. The employee portal allows you to view and edit existing employees.</p>
                    <p> Navigate to the <b>View Employees</b> link , select the<img src="../Icons/edit-small.png" /> and update the details as you wish.</p>
                    <img src="../Icons/edit.png" />
                </li>
            </ul>
</div>
    </div>
    
</asp:Content>
