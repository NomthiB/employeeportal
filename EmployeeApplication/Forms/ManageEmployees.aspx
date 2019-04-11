<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageEmployees.aspx.cs" Inherits="EmployeeApplication.Forms.ManageEmployees" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadCodeBlock ID ="EmployeeRadCodeBlock" runat="server">
        <script type="text/javascript">
            function clientLoad(toolbar) {
                for (var i = 0; i < toolbar.get_items().get_count() ; i++) {
                    var item = toolbar.get_items().getItem(i);
                    if (item.get_linkElement() != null) {
                        if (item.get_linkElement().className.indexOf('rightAligned') >= 0) {
                            item.get_element().className += " rightAlignedWrapper";
                        }
                    }
                }
            }

            function GetEmployees(sender, eventArgs) {
                var context = eventArgs.get_context();
                var clientlist = document.getElementById('<%= hdnEmployeeList.ClientID %>').value;
                context["EmployeeList"] = clientlist;
            }

        </script>
    </telerik:RadCodeBlock>
    <link href="../Scripts/layout.css" rel="stylesheet" />
        <table class="AdminContent">
            <tr>
                <td class="AdminLeft">
                    <table class="AdminTitleBar">
                        <tr>
                            <td ><img src="../Icons/employees.png" /></td>
                            <td class="AdminTitle">
                                Employees
                                </td>
                        </tr>
                    </table>
                </td>
                <td class="AdminRight">
                    <div class="AdminRightInner">
                    <telerik:RadToolBar 
                        ID="ItemToolBar" 
                        runat="server" 
                        Style="z-index: 950" Width="100%" 
                        EnableRoundedCorners="true" 
                        EnableImageSprites="true" 
                        EnableShadows="true"
                        OnButtonClick="ItemToolBar_ButtonClick">
                            <Items>                                                              
                                <telerik:RadToolBarButton  ToolTip="Export to Excel" ImageUrl="../Icons/excel.png" Value="export" Width="50px" Height="50px" />
                            </Items>
                        </telerik:RadToolBar>
                    </div>
                </td>
            </tr>
        </table>
    <telerik:RadGrid ID="EmployeeList" 
       runat="server"
       width="100%" 
       AutoGenerateColumns="false"
       OnNeedDataSource="EmployeeList_NeedDataSource"           
       AllowPaging="true"  
       PageSize="20" 
       PagerStyle-PageButtonCount="20"     
       AllowSorting="true" 
       OnItemDataBound="EmployeeList_ItemDataBound"
            >
            <ExportSettings ExportOnlyData="true" FileName="Clients" IgnorePaging="true" HideStructureColumns="true" OpenInNewWindow="true"> 
                <Excel Format="Biff" />
                <Csv ColumnDelimiter="VerticalBar" FileExtension="csv" RowDelimiter="NewLine" EncloseDataWithQuotes="false" />            
            </ExportSettings> 
            <MasterTableView DataKeyNames="EmployeeID" ClientDataKeyNames="EmployeeID" CommandItemDisplay="None">
            <Columns>
                   <telerik:GridBoundColumn UniqueName="EmployeeID" DataField="EmployeeID" HeaderText="EmployeeID" Display="false" />
                    <telerik:GridBoundColumn UniqueName="FirstName" DataField="FirstName" HeaderText="Name"  AllowSorting="true" />
                    <telerik:GridBoundColumn UniqueName="LastName" DataField="LastName" HeaderText="Surname" AllowSorting="true"  />                                        
                    <telerik:GridBoundColumn UniqueName="Email" DataField="Email" HeaderText="Email"  /> 
                    <telerik:GridBoundColumn UniqueName="Mobile" DataField="CellNumber" HeaderText="Mobile"  />
                    <telerik:GridBoundColumn UniqueName="LandLine" DataField="LandLine" HeaderText="Landline"  />
                    <telerik:GridBoundColumn UniqueName="AddressLine1" DataField="AddressLine1" HeaderText="Street"  />
                    <telerik:GridBoundColumn UniqueName="AddressLine2" DataField="AddressLine2" HeaderText="Suburb"  />
                    <telerik:GridBoundColumn UniqueName="PostCode" DataField="PostalCode" HeaderText="Post Code"  />
                    <telerik:GridBoundColumn UniqueName="Fcaebook" DataField="Facebook" HeaderText="Facebook"  />
                    <telerik:GridBoundColumn UniqueName="Instagram" DataField="InstagramHandle" HeaderText="Instagram"  />
                    <telerik:GridBoundColumn UniqueName="Twitter" DataField="TwitterHandle" HeaderText="Twitter"  />
                    <telerik:GridBoundColumn UniqueName="LinkedIn" DataField="LinkedIn" HeaderText="LinkedIn"  />
                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Right" UniqueName="ViewDetails">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnViewDetails" runat="server" Image-ImageUrl="~/Icons/edit-small.png" Width="40px" Height="40px" ToolTip="View employee" AutoPostBack="false" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>                                                          
              </Columns>
              <NoRecordsTemplate>
                  <div id="NoContentTitleBar" >
                      <div id="NoContentTitleImage"><div class="ImageIcon32-Exclamation"></div></div>
                      <div id="NoContentTitle"><asp:Literal id="lblTitle" runat="server" Text="No Clients" /></div>
                  </div>
                  <div id="NoContent">        
                        <asp:Literal id="lblMessage" runat="server" Text="There are no clients available, or you have unselected all the client statuses" />
                  </div>
            </NoRecordsTemplate>
            </MasterTableView>
            <ClientSettings>
                <Selecting AllowRowSelect="true"  />
            </ClientSettings>
        </telerik:RadGrid>
    <asp:HiddenField ID="hdnEmployeeList" runat="server" />
</asp:Content>
