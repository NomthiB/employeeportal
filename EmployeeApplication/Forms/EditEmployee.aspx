<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="EmployeeApplication.Forms.EditEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadWindowManager ID="AlertWindowManager" runat="server" ReloadOnShow="False" AutoSize="True" Height="150" Width="100" VisibleOnPageLoad="false" Visible="true" />
    <telerik:RadToolBar 
        ID="ItemToolBar" 
        runat="server" 
        Style="z-index: 950" Width="100%" 
        EnableRoundedCorners="true" 
        EnableImageSprites="true" 
        EnableShadows="true" 
        OnButtonClick="ItemToolBar_ButtonClick">
        <Items>                                
            <telerik:RadToolBarButton  ToolTip="Save employee" Value="save" ImageUrl="../Icons/save.png" Width="50px" Height="50px" ValidationGroup="EmployeeDetails"  />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton  ToolTip="Delete employee" Value="delete" ImageUrl="../Icons/delete.png" Width="50px" Height="50px" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton  ToolTip="Add new employee" Value="add" ImageUrl="../Icons/add.png" Width="50px" Height="50px" />
        </Items>                           
    </telerik:RadToolBar>

    <table>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
                Name
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadTextBox ID="NameTextBox" runat="server" Width="200px" ValidationGroup="EmployeeDetails" ></telerik:RadTextBox>
                <asp:RequiredFieldValidator  ID="NameRequiredFieldValidator" runat="server" ErrorMessage="*Required Field" ControlToValidate="NameTextBox" ValidationGroup="EmployeeDetails" />
            </td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
                Surname
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadTextBox ID="SurnameTextBox" runat="server" Width="200px" ValidationGroup="EmployeeDetails"  ></telerik:RadTextBox>
                <asp:RequiredFieldValidator  ID="SurnameRequiredFieldValidator" runat="server" ErrorMessage="*Required Field" ControlToValidate="SurnameTextBox"  ValidationGroup="EmployeeDetails" />
            </td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
                Email
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadTextBox ID="EmailTextBox" runat="server" Width="200px" ValidationGroup="EmployeeDetails"  ></telerik:RadTextBox>
                <asp:RequiredFieldValidator  ID="EmailFieldValidator" runat="server" ErrorMessage="*Required Field" ControlToValidate="EmailTextBox" ValidationGroup="EmployeeDetails"  />
            </td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
                Mobile
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadMaskedTextBox RenderMode="Lightweight" ID="MobilemMaskedTextBox" runat="server" ValidationGroup="EmployeeDetails" 
                    Width="200px" LabelWidth="120px" Mask="(###) ###-####">
                </telerik:RadMaskedTextBox>
                <asp:RequiredFieldValidator  ID="MobileRequiredFieldValidator" runat="server" ErrorMessage="*Required Field" ControlToValidate="MobilemMaskedTextBox" ValidationGroup="EmployeeDetails"  />
            </td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
                Landline
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadMaskedTextBox RenderMode="Lightweight" ID="LandlineMaskedTextBox" runat="server" 
                    Width="200px" LabelWidth="120px" Mask="(###) ###-####">
                </telerik:RadMaskedTextBox>
            </td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
                Street
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadTextBox ID="StreetTextBox" runat="server" Width="200px" ></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
                Suburb
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadTextBox ID="SuburbTextBox" runat="server" Width="200px" ></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
                Postal Code
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadTextBox ID="PostalCodeTextBox" runat="server" Width="200px" ></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
                <img src="../Icons/facebook.png" />   
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadTextBox ID="FacebookTextBox" runat="server" Width="200px" ></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
               <img src="../Icons/instagram.png" /> 
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadTextBox ID="InstagramTextBox" runat="server" Width="200px" ></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
               <img src="../Icons/linkedin.png" /> 
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadTextBox ID="LinkedInTextBox" runat="server" Width="200px" ></telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="width:120px; white-space:nowrap;">
               <img src="../Icons/twitter.png" /> 
            </td>
            <td>&nbsp;</td>
            <td>
                <telerik:RadTextBox ID="TwitterTextBox" runat="server" Width="200px" ></telerik:RadTextBox>
            </td>
        </tr>

    </table>
    
</asp:Content>
