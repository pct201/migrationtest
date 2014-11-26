<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Employee.aspx.cs"
    Inherits="Employee_Employee"   %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript">
        function MinMax(name)
        {
            
            if(name == "attachment")
            {
            
                //alert(document.getElementById("ctl00_ContentPlaceHolder1_fvVendorDetails_txtDescription").style.height);
                if(document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_txtDescription").style.height == "")
                {
                
                    document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_ibtnAttach").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_txtDescription").style.height = "200px";
                    document.getElementById("pnlAttach").style.display = "block";
                }
                else if(document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_txtDescription").style.height == "200px")
                {
                    
                    document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_ibtnAttach").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_txtDescription").style.height="";
                    document.getElementById("pnlAttach").style.display = "none";
                }
            }
            return false;
        }
        function ValAttach()
        {
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_rfvAttachType").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_rfvUpload").enabled =true;
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_txtCellTeleNo").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_txtCellTeleNo").value="";
            return true;
        }
        function ValSave()
        {
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_rfvAttachType").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_rfvUpload").enabled =false;
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_txtCellTeleNo").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvEmployee_txtCellTeleNo").value="";
            return true;
        }
        function openWindow(strURL)
        {
            oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260,180);
            return false;
            
        }
        function openMailWindow(strURL)
        {
            //oWnd=window.open("Mail.aspx?AttName="+ strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
            oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=0,toolbar=0,width=500,height=280");
            oWnd.moveTo(260,180);
            return false;
            
        }
        function openSupWindow()
        {
            //oWnd=window.open("../WorkerCompensation/Employee_Search_Popup.aspx?Page=Supervisor","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd=window.open("../Claim/EmployeePopup.aspx?Page=Supervisor","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=750,height=500");
            oWnd.moveTo(260,180);
            return false;
            
        }
        function openCCWindow()
        {
            oWnd=window.open("CostCenter_Popup.aspx?Page=Employee","Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260,180);
            return false;
            
        }
        function conditionalPostback(sender, args) 
        { 
            var eventTarget = args.EventTarget;
            
            //else
            //{
                return true;
            //} 
        } 
        
    </script>

    <asp:ScriptManager ID="smEmployee" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <%-- <jeffz:AjaxFileUploadHelper runat="server" ID="AjaxFileUploadHelper1" SupportAjaxUpload="true" />

    <asp:UpdatePanel ID="pnlVendorDetail" runat="server" >
    
        
        <ContentTemplate>--%>
    <%--<div style="width: 100%;">--%>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            EnableClientScript="true" ValidationGroup="vsErrorGroup" CssClass="errormessage">
        </asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="true"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    <table width="100%">
        <tr>
            <td>
                <div id="dvSearch" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width: 50%;">
                                &nbsp;
                            </td>
                            <td style="width: 50%;" align="right">
                                <table width="80%">
                                    <tr>
                                        <td class="lc">
                                            Search
                                        </td>
                                        <td class="ic">
                                            <asp:DropDownList ID="ddlSearch" runat="server" SkinID="dropGen">
                                                <asp:ListItem Value="Last_Name">Last Name</asp:ListItem>
                                                <asp:ListItem Value="First_Name">First Name</asp:ListItem>
                                                <asp:ListItem Value="Employee_Id">Employee Id</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td class="ic">
                                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>
                                        <td class="ic">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%;" align="left" class="lc">
                                <asp:Label ID="lblEmployeeTotal" runat="server"></asp:Label>
                            </td>
                            <td style="width: 80%;" align="right" class="lc">
                                <table width="100%">
                                    <tr>
                                        <td class="lc">
                                            No. of Records per page :
                                            <asp:DropDownList ID="ddlPage" SkinID="dropGen" runat="server" DataSourceID="xdsPaging"
                                                DataTextField="Text" DataValueField="Value" AutoPostBack="True" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:XmlDataSource ID="xdsPaging" runat="server" DataFile="~/App_Data/PagingTable.xml">
                                            </asp:XmlDataSource>
                                        </td>
                                        <td class="ic">
                                            <asp:Button ID="btnPrev" runat="server" OnClick="btnPrev_Click" Text=" < " SkinID="btnGen" />
                                        </td>
                                        <td class="lc">
                                            <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
                                        </td>
                                        <td class="ic">
                                            <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text=" > " SkinID="btnGen" />
                                        </td>
                                        <td class="lc">
                                            Go to Page:</td>
                                        <td class="ic">
                                            <asp:TextBox ID="txtPageNo" MaxLength="3" runat="server" Width="20px" onkeypress="return numberOnly(event);"></asp:TextBox>
                                        </td>
                                        <td class="ic">
                                            <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:MultiView ID="mvEmployee" runat="server">
                    <asp:View ID="vwEmployeeList" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <table width="100%" style="text-align: right;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Employee Details"
                                                    OnClick="btnDelete_Click" />
                                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add New Employee Details"
                                                    OnClick="btnAddNew_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Employee_Id"
                                                    Width="100%" AllowPaging="True" AllowSorting="True" OnRowCommand="gvEmployee_RowCommand"
                                                    OnSorting="gvEmployee_Sorting" OnRowCreated="gvEmployee_RowCreated" OnRowDataBound="gvEmployee_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Employee_Id")%>' onclick="javascript:UnCheckHeader('gvEmployee')" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                            <HeaderTemplate>
                                                                <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                            </HeaderTemplate>
                                                            <HeaderStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" DataField="Last_Name" HeaderText="Last Name" SortExpression="Last_Name">
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" DataField="First_Name" HeaderText="First Name" SortExpression="First_Name">
                                                        </asp:BoundField>
                                                        <asp:BoundField  HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" DataField="Employee_Id" HeaderText="Employee Id" SortExpression="Employee_Id">
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Employee_Id")%>'
                                                                    runat="server" Text="Edit" ToolTip="Edit the Employee Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Employee_Id")%>'
                                                                    ToolTip="View the Employee Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        Currently There Is No Employee Details.
                                                    </EmptyDataTemplate>
                                                    <PagerSettings Visible="False" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="vwEmployee" runat="server">
                        <table width="100%">
                            <%--<tr>
                                    <td class="lc">
                                        Vendor
                                    </td>
                                </tr>--%>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:FormView ID="fvEmployee" runat="server" Width="100%" OnDataBound="fvEmployee_DataBound">
                                        <ItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Employee
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Employee Id
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblEmployeeId" runat="server" Text='<%#Eval("Employee_Id") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    First Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblFirstName" runat="server" Text='<%#Eval("First_Name") %>'></asp:Label>
                                                                    <asp:Label ID="lblPkEmployeeId" runat="server" Text='<%#Eval("PK_Employee_Id")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Address Line 1
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblAddress1" runat="server" Text='<%#Eval("Employee_Address_1") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    City
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("Employee_City") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Zip Code
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblZipCode" runat="server" Text='<%#Eval("Employee_Zip_Code") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Cell Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblCellTeleNo" runat="server" Text='<%#Eval("Employee_Cell_Phone") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Marital Status
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblMaritalStatus" runat="server" Text='<%#Eval("MaritalStatus") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    No. Of Dependents
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblNoOfDependents" runat="server" Text='<%#Eval("Number_Of_Dependents") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Death
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblDeathDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Date_Of_Death","{0:MM/dd/yyyy}") %>'></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Last Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblLastName" runat="server" Text='<%#Eval("Last_Name") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Middle Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblMiddleName" runat="server" Text='<%#Eval("Middle_Name") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Address Line 2
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblAddress2" runat="server" Text='<%#Eval("Employee_Address_2") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    State
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblState" runat="server" Text='<%#Eval("FldState") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Home Telephone Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblHomeTeleNo" runat="server" Text='<%#Eval("Employee_Home_Phone") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Social Security Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblSSN" runat="server" Text='<%#Eval("Social_Security_Number") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Sex
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblSex" runat="server" Text='<%#Eval("Sex") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date of Birth
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDOB" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Date_Of_Birth","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Driver's License
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver's License State
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDLS" runat="server" Text='<%#Eval("Drivers_License_State") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver's License Type
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblDLT" runat="server" Text='<%#Eval("Drivers_License_Type") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Restrictions on Driver's License
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblRDS" runat="server" Text='<%#Eval("Drivers_License_Restrictions") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Driver's License Issued
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblDateIssued" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Drivers_License_Issued","{0:MM/dd/yyyy}") %>'></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver's License Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDLN" runat="server" Text='<%#Eval("Drivers_License_Number") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver's License Class
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDLC" runat="server" Text='<%#Eval("Drivers_License_Class") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver's License Endorsements
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDLE" runat="server" Text='<%#Eval("Drivers_License_Endorsements") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Driver's License Expires
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDateLicExpired" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Drivers_License_Expires","{0:MM/dd/yyyy}") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Job Specific Information
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Job Title
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblJobTitle" runat="server" Text='<%#Eval("Job_Title") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Salary
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblSalary" runat="server" Text='<%#Eval("Salary") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor (First Name)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblSupFirstName" runat="server" Text='<%#Eval("SupFirstName") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date of Hire
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblHireDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Hire_Date","{0:MM/dd/yyyy}") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Active Employee
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblActiveEmployee" runat="server" Text='<%#Eval("Inactive") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Entity
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblCostCenter" runat="server" Text='<%#Eval("CCAddress") %>'></asp:Label></td>
                                                            </tr>
                                                           <%-- <tr>
                                                                <td class="lc">
                                                                    Address
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblCCAddress" runat="server" Text='<%#Eval("CCAddress") %>'></asp:Label></td>
                                                            </tr>--%>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Occupation Description
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblOccupationDesc" runat="server" Text='<%#Eval("Occupation_Description") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor (Last Name)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblSupLastName" runat="server" Text='<%#Eval("SupLastName") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor (Middle Name)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblSupMiddleName" runat="server" Text='<%#Eval("SupMiddleName") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Work Telephone Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblWorkTeleNo" runat="server" Text='<%#Eval("Work_Phone") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Job Classification
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblJobClassification" runat="server" Text='<%#Eval("JobClassfication") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Email
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="width: 50%">
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" Enabled="false" /></td>
                                                    <td align="left" style="width: 50%">
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <InsertItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Employee
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%;">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    <div style="display: none">
                                                                        <asp:TextBox ID="txtCurrentDate" runat="Server"></asp:TextBox>
                                                                    </div>
                                                                    Employee Id
                                                                    <%--<span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtEmployeeId" runat="server" MaxLength="12" onkeypress="return numberOnly(event);" TabIndex="1"></asp:TextBox>
                                                                   <%-- <asp:RequiredFieldValidator ID="rfvEmpID" ControlToValidate="txtEmployeeId" EnableClientScript="true"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Employee Id."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:Label ID="lblPkEmployeeId" runat="server" Text='<%#Eval("PK_Employee_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    First Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="30" TabIndex="3"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtFirstName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter First Name."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Address Line 1<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAddress1" runat="server" MaxLength="50" TabIndex="5"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAddress1" ControlToValidate="txtAddress1" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Address Line 1."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    City<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtCity" runat="server" MaxLength="30" TabIndex="7"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="txtCity" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter City."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Zip Code<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtZip" runat="server" MaxLength="5" onkeypress="return numberOnly(event);" TabIndex="9"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvZip" ControlToValidate="txtZip" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Zip Code."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip"
                                                                        ValidationExpression="^\d{5}$" ErrorMessage="Please Enter 5 Digits For Zip."
                                                                        ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Cell Number (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtCellTeleNo" runat="server" MaxLength="12" onkeypress="return numberOnly(event);" TabIndex="11"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskPhone" runat="server" TargetControlID="txtCellTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="txtCellTeleNo" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Cell Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Marital Status 
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:DropDownList ID="ddlMaritalStatus" runat="server" TabIndex="13">
                                                                    </asp:DropDownList>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvGrade" ControlToValidate="ddlMaritalStatus" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Marital Status."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Number Of Dependents
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtNoOfDependents" runat="server" MaxLength="2" onkeypress="return numberOnly(event);" TabIndex="15"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Death
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDeathDate" runat="server" SkinID="txtDate" TabIndex="17"></asp:TextBox>
                                                                    <img runat="server" id="imgDOB" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmployee_txtDeathDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDeathDate" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDeathDate" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDeathDate" runat="server" ControlToValidate="txtDeathDate"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Death)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:CompareValidator ID="cv" runat="server" ControlToValidate="txtDeathDate" ValidationGroup="vsErrorGroup"
                                                                        ErrorMessage="Date of death should not be greater than today's date." Type="Date" Operator="LessThan"
                                                                        ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top" style="width: 50%;">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Last Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="30" TabIndex="2"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="txtLastName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Last Name."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Middle Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtMiddleName" runat="server" MaxLength="30" TabIndex="4"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Address Line 2
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAddress2" runat="server" MaxLength="50" TabIndex="6">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    State<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlState" runat="server" TabIndex="8">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select State."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Home Telephone Number(xxx-xxx-xxxx)
                                                                   <%-- <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtHomeTeleNo" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);" TabIndex="10"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskHomePhone" runat="server" TargetControlID="txtHomeTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvHomePhone" ControlToValidate="txtHomeTeleNo" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Home Telephone Number."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtHomeTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Home Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Social Security Number(xxx-xx-xxxx)<span class="mf">*</span>
                                                                  <%--  <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSSN" MaxLength="11" runat="server" TabIndex="12">
                                                                    </asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskSSN" runat="server" TargetControlID="txtSSN" Mask="999-99-9999"
                                                                        MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                   <%-- <asp:RequiredFieldValidator ID="rfvSSN" ControlToValidate="txtSSN" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Social Security Number."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="revSSN" ControlToValidate="txtSSN" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter SSN in xxx-xx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{2}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Sex
                                                                 <%--   <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:RadioButtonList ID="rdlSex" runat="server" TabIndex="14">
                                                                        <asp:ListItem Text="Male" Value="M" Selected="true"> </asp:ListItem>
                                                                        <asp:ListItem Text="Female" Value="F"> </asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Birth
                                                                  <%--  <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDOB" runat="server" SkinID="txtDate" TabIndex="16"></asp:TextBox>
                                                                    <img runat="server" id="img2" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmployee_txtDOB', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDOB" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDOB" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Birth)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                   <%-- <asp:RequiredFieldValidator ID="rfvDateOfBirth" ControlToValidate="txtDOB" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Date of Birth."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDOB"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Date of birth should not be greater than today's date."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Driver's License
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver's License State
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:DropDownList ID="ddlDLState" runat="server" TabIndex="18">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver's License Type
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlDLType" runat="server" TabIndex="20">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Restrictions on Driver's License
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtRDS" runat="server" MaxLength="30" TabIndex="22"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Driver's License Issued
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDateIssued" runat="server" SkinID="txtDate" TabIndex="24"></asp:TextBox>
                                                                    <img runat="server" id="img1" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmployee_txtDateIssued', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDateIssued" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDateIssued" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDateIssued" runat="server" ControlToValidate="txtDateIssued"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Driver's License Issued)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtDateIssued"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Date Driver's License Issued Should Not Be Greater Than Future Date."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver's License Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDLN" runat="server" MaxLength="20" TabIndex="19"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver's License Class
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDLC" runat="server" MaxLength="5" TabIndex="21"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver's License Endorsements
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDLE" runat="server" MaxLength="30" TabIndex="23"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Driver's License Expires
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDateExpired" runat="server" SkinID="txtDate" TabIndex="25"></asp:TextBox>
                                                                    <img runat="server" id="img5" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmployee_txtDateExpired', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDateExpired" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDateExpired"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDateExpired" runat="server" ControlToValidate="txtDateExpired"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Driver's License Expires)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtDateIssued"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Date Driver's License Issued Should Not Be Greater Than Date Driver's License Expires."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtDateExpired" Display="none"></asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Job Specific Information
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Job Title
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtJobtitle" runat="server" MaxLength="30" TabIndex="26"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Salary
                                                                   <%-- <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    $<asp:TextBox ID="txtSalary" runat="server" MaxLength="12" SkinID="txtAmt" onKeyPress="return(currencyFormat(this,',','.',event))" TabIndex="28"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvSal" ControlToValidate="txtSalary" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Salary."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor (First Name)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSupFirstName" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();" ></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date of Hire
                                                                    <%--<span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtHireDate" runat="server" SkinID="txtDate" TabIndex="30"></asp:TextBox>
                                                                    <img runat="server" id="img6" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmployee_txtHireDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskHireDate" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtHireDate" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHireDate"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date of Hire)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvHireDate" ControlToValidate="txtHireDate" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Hire Date."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtHireDate"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Hire Date Should Not Be Greater Than Future Date."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Active Employee
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtActive" runat="server" MaxLength="1" TabIndex="32"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Entity
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtCostCenter" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();" ></asp:TextBox>
                                                                    <asp:Button ID="btnCC" runat="server" Text="V" SkinID="btnGen" OnClientClick="javascript:return openCCWindow();" TabIndex="34" />
                                                                    <asp:TextBox ID="txtCCId" runat="server" Style="display: none;"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td class="lc">
                                                                    Address
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtCCAddress" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();" TabIndex="38"></asp:TextBox>
                                                                </td>
                                                            </tr>--%>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Occupation Description<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtOccuDesc" runat="server" MaxLength="20" TabIndex="27"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvOccuDesc" ControlToValidate="txtOccuDesc" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Occupation Description."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor (Last Name)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtSupLastName" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();" ></asp:TextBox>
                                                                    <asp:Button ID="btnSup" runat="server" Text="V" SkinID="btnGen" OnClientClick="javascript:return openSupWindow();" TabIndex="29"/>
                                                                    <asp:TextBox ID="txtSupId" runat="server" Style="display: none;"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor (Middle Name)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtSupMiddleName" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();" ></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Work Telephone Number (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtWorkTeleNo" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);" TabIndex="31"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskWorkTele" runat="server" TargetControlID="txtWorkTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revWorkTele" ControlToValidate="txtWorkTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Work Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Job Classification
                                                                 <%--   <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlJobClassification" runat="server" TabIndex="35">
                                                                    </asp:DropDownList>
                                                                   <%-- <asp:RequiredFieldValidator ID="rfvJobClassification" ControlToValidate="ddlJobClassification"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Job Classification."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Email<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" TabIndex="37">
                                                                    </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Email."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <%--<asp:RegularExpressionValidator ID="revMail" ControlToValidate="txtEmail" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Valid Email Address."
                                                                        Display="none" ValidationExpression="^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"></asp:RegularExpressionValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid"
                                                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Attachment
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td style="width: 50%;" align="left">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    Attachment Type
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:DropDownList ID="ddlAttachType" runat="server" TabIndex="39">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Attachment Type."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 50%;">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 24%" valign="top">
                                                                    Attachment Description</td>
                                                                <td align="Center" valign="top" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" align="left" style="width: 76%;" >
                                                                    <asp:ImageButton ID="ibtnAttach" ImageUrl="~/Images/plus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');"  TabIndex="40"/>
                                                                    <div id="pnlAttach" style="display: none;" >
                                                                        <asp:TextBox ID="txtDescription" runat="server" Width="694px" TextMode="MultiLine">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 24%">
                                                                    Select File to Attach
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 76%">
                                                                    <asp:FileUpload ID="uplCommon" runat="server" Width="300px" TabIndex="41" />
                                                                    <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                        InitialValue="" Display="None" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">
                                                                        
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                            SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" TabIndex="42" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" TabIndex="43" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" TabIndex="44" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </InsertItemTemplate>
                                        <EditItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Employee
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    <div style="display: none">
                                                                        <asp:TextBox ID="txtCurrentDate" runat="Server"></asp:TextBox>
                                                                    </div>
                                                                    Employee Id
                                                                    <%--<span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtEmployeeId" runat="server" MaxLength="12" onkeypress="return numberOnly(event);"
                                                                        Text='<%#Eval("Employee_Id") %>' TabIndex="1"></asp:TextBox>
                                                                 <%--   <asp:RequiredFieldValidator ID="rfvEmpID" ControlToValidate="txtEmployeeId" EnableClientScript="true"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Employee Id."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:Label ID="lblPkEmployeeId" runat="server" Text='<%#Eval("PK_Employee_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    First Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtFirstName" runat="server" TabIndex="3" MaxLength="30" Text='<%#Eval("First_Name") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtFirstName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter First Name."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Address Line 1<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAddress1" runat="server" TabIndex="5" MaxLength="50" Text='<%#Eval("Employee_Address_1") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAddress1" ControlToValidate="txtAddress1" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Address Line 1."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    City<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtCity" runat="server" MaxLength="30" TabIndex="7" Text='<%#Eval("Employee_City") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="txtCity" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter City."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Zip Code<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtZip" runat="server" MaxLength="5" onkeypress="return numberOnly(event);"
                                                                        Text='<%#Eval("Employee_Zip_Code") %>' TabIndex="9"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvZip" ControlToValidate="txtZip" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Zip Code."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip"
                                                                        ValidationExpression="^\d{5}$" ErrorMessage="Please Enter 5 Digits For Zip."
                                                                        ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Cell Number (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtCellTeleNo" runat="server" MaxLength="12" onkeypress="return numberOnly(event);"
                                                                        Text='<%#Eval("Employee_Cell_Phone") %>' TabIndex="11"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskPhone" runat="server" TargetControlID="txtCellTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="txtCellTeleNo" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Cell Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Marital Status 
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:DropDownList ID="ddlMaritalStatus" runat="server" TabIndex="13">
                                                                    </asp:DropDownList>
                                                                   <%-- <asp:RequiredFieldValidator ID="rfvGrade" ControlToValidate="ddlMaritalStatus" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Marital Status."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Number Of Dependents
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtNoOfDependents" runat="server" MaxLength="2" onkeypress="return numberOnly(event);"
                                                                        Text='<%#Eval("Number_Of_Dependents") %>' TabIndex="15"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Death
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDeathDate" runat="server" TabIndex="17" SkinID="txtDate" Text='<%#DataBinder.Eval(Container.DataItem,"Date_Of_Death","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                    <img runat="server" id="imgDOB" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmployee_txtDeathDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDeathDate" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDeathDate" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDeathDate" runat="server" ControlToValidate="txtDeathDate"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Death)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:CompareValidator ID="cv" runat="server" ControlToValidate="txtDeathDate" ValidationGroup="vsErrorGroup"
                                                                        ErrorMessage="Date of death should not be greater than today's date." Type="Date" Operator="lessthan"
                                                                        ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Last Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtLastName" runat="server" TabIndex="2" MaxLength="30" Text='<%#Eval("Last_Name") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvLastName" ControlToValidate="txtLastName" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Last Name."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Middle Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtMiddleName" runat="server" TabIndex="4" MaxLength="30" Text='<%#Eval("Middle_Name") %>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Address Line 2
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAddress2" runat="server" TabIndex="6" MaxLength="50" Text='<%#Eval("Employee_Address_2") %>'>
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    State<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlState" runat="server" TabIndex="8">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select State."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Home Telephone Number(xxx-xxx-xxxx)
                                                                    <%--<span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtHomeTeleNo" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);"
                                                                        Text='<%#Eval("Employee_Home_Phone") %>' TabIndex="10"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskHomePhone" runat="server" TargetControlID="txtHomeTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                   <%-- <asp:RequiredFieldValidator ID="rfvHomePhone" ControlToValidate="txtHomeTeleNo" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Home Telephone Number."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtHomeTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Home Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Social Security Number(xxx-xxx-xxxx)
                                                                  <%--  <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSSN" MaxLength="11" TabIndex="12" runat="server" Text='<%#Eval("Social_Security_Number") %>'>
                                                                    </asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskSSN" runat="server" TargetControlID="txtSSN" Mask="999-99-9999"
                                                                        MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                   <%-- <asp:RequiredFieldValidator ID="rfvSSN" ControlToValidate="txtSSN" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Social Security Number."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="revSSN" ControlToValidate="txtSSN" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter SSN in xxx-xx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{2}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Sex
                                                                   <%-- <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:RadioButtonList ID="rdlSex" runat="server" TabIndex="14">
                                                                        <asp:ListItem Text="Male" Value="M" Selected="true"> </asp:ListItem>
                                                                        <asp:ListItem Text="Female" Value="F"> </asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Birth
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDOB" runat="server" TabIndex="17" SkinID="txtDate" Text='<%#DataBinder.Eval(Container.DataItem,"Date_Of_Birth","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                    <img runat="server" id="img2" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmployee_txtDOB', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDOB" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDOB" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Of Birth)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvDateOfBirth" ControlToValidate="txtDOB" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Date of Birth."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDOB"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Date of birth should not be greater than today's date."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Driver's License
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver's License State
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:DropDownList ID="ddlDLState" runat="server" TabIndex="18">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver's License Type
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlDLType" runat="server" TabIndex="20">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Restrictions on Driver's License
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtRDS" runat="server" TabIndex="22" MaxLength="30" Text='<%#Eval("Drivers_License_Restrictions") %>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Driver's License Issued
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtDateIssued" runat="server" TabIndex="24" Text='<%#DataBinder.Eval(Container.DataItem,"Drivers_License_Issued","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                    <img runat="server" id="img3" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmployee_txtDateIssued', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDateIssued" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtDateIssued" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDateIssued" runat="server" ControlToValidate="txtDateIssued"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Driver's License Issued)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="txtDateIssued"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Date Driver's License Issued Should Not Be Greater Than Future Date."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtCurrentDate" Display="none"></asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Driver's License Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDLN" runat="server" TabIndex="19" MaxLength="20" Text='<%#Eval("Drivers_License_Number") %>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver's License Class
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDLC" runat="server" TabIndex="21" MaxLength="5" Text='<%#Eval("Drivers_License_Class") %>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver's License Endorsements
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDLE" runat="server" TabIndex="23" MaxLength="30" Text='<%#Eval("Drivers_License_Endorsements") %>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Driver's License Expires
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDateExpired" runat="server" TabIndex="25" Text='<%#DataBinder.Eval(Container.DataItem,"Drivers_License_Expires","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                    <img runat="server" id="img4" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmployee_txtDateExpired', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskDateExpired" runat="server" AcceptNegative="Left"
                                                                        DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDateExpired"
                                                                        CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revDateExpired" runat="server" ControlToValidate="txtDateExpired"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date Driver's License Expires)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="txtDateIssued"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Date Driver's License Issued Should Not Be Greater Than Date Driver's License Expires."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtDateExpired" Display="none"></asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="lc">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Job Specific Information
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Job Title
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtJobtitle" runat="server" TabIndex="26" MaxLength="30" Text='<%#Eval("Job_Title") %>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Salary
                                                                   <%-- <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    $<asp:TextBox ID="txtSalary" runat="server" MaxLength="12" TabIndex="28" onKeyPress="return(currencyFormat(this,',','.',event))"
                                                                        Text='<%#Eval("Salary") %>' SkinID="txtAmt"></asp:TextBox>
                                                                   <%-- <asp:RequiredFieldValidator ID="rfvSal" ControlToValidate="txtSalary" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Salary."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor (First Name)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSupFirstName" runat="server"  onKeyDown="javascript:return disableDeleteBackSpace();"
                                                                        Text='<%#Eval("SupFirstName") %>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date of Hire
                                                                <%--    <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtHireDate" SkinID="txtDate" TabIndex="30" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Hire_Date","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                                                    <img runat="server" id="img6" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvEmployee_txtHireDate', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                        align="absmiddle" />
                                                                    <cc1:MaskedEditExtender ID="mskHireDate" runat="server" AcceptNegative="Left" DisplayMoney="Left"
                                                                        Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtHireDate" CultureName="en-US"
                                                                        AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHireDate"
                                                                        ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"
                                                                        ErrorMessage="Date Not Valid(Date of Hire)" Display="none" ValidationGroup="vsErrorGroup"></asp:RegularExpressionValidator>
                                                                <%--    <asp:RequiredFieldValidator ID="rfvHireDate" ControlToValidate="txtHireDate" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Hire Date."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtHireDate"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Hire Date Should Not Be Greater Than Future Date."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Active Employee
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtActive" runat="server" TabIndex="32" MaxLength="1" Text='<%#Eval("Inactive") %>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Entity
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtCostCenter" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();"
                                                                        Text='<%#Eval("FK_Cost_Center") %>'></asp:TextBox>
                                                                    <asp:Button ID="btnCC" runat="server" Text="V" TabIndex="34" SkinID="btnGen" OnClientClick="javascript:return openCCWindow();" />
                                                                    <asp:TextBox ID="txtCCId" runat="server" Style="display: none;" Text='<%#Eval("FK_Cost_Center") %>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td class="lc">
                                                                    Address
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtCCAddress" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();"
                                                                        Text='<%#Eval("CCAddress") %>'></asp:TextBox>
                                                                </td>
                                                            </tr>--%>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Occupation Description<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtOccuDesc" runat="server" TabIndex="27" MaxLength="20" Text='<%#Eval("Occupation_Description") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvOccuDesc" ControlToValidate="txtOccuDesc" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Occupation Description."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor (Last Name)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtSupLastName" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();"
                                                                        Text='<%#Eval("SupLastName") %>' ></asp:TextBox>
                                                                    <asp:Button ID="btnSup" runat="server" Text="V" SkinID="btnGen" TabIndex="29" OnClientClick="javascript:return openSupWindow();" />
                                                                    <asp:TextBox ID="txtSupId" runat="server" Style="display: none;" Text='<%#Eval("Supervisor") %>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Supervisor (Middle Name)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtSupMiddleName" runat="server" onKeyDown="javascript:return disableDeleteBackSpace();"
                                                                        Text='<%#Eval("SupMiddleName") %>' ></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Work Telephone Number (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtWorkTeleNo" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);"
                                                                        Text='<%#Eval("Work_Phone") %>' TabIndex="31"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskWorkTele" runat="server" TargetControlID="txtWorkTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revWorkTele" ControlToValidate="txtWorkTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Work Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Job Classification
                                                                   <%-- <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlJobClassification" runat="server" TabIndex="33">
                                                                    </asp:DropDownList>
                                                                 <%--   <asp:RequiredFieldValidator ID="rfvJobClassification" ControlToValidate="ddlJobClassification"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Job Classification."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Email<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtEmail" runat="server" TabIndex="35" MaxLength="50" Text='<%#Eval("Email") %>'>
                                                                    </asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Email."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <%--<asp:RegularExpressionValidator ID="revMail" ControlToValidate="txtEmail" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Valid Email Address."
                                                                        Display="none" ValidationExpression="^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"></asp:RegularExpressionValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                                                        ValidationGroup="vsErrorGroup" Display="None" ErrorMessage="Email Address Is Invalid"
                                                                        SetFocusOnError="True" ToolTip="Email Address Is Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Attachment
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr style="display: none;">
                                                    <td style="width: 50%;" align="left">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    Attachment Type
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 50%;">
                                                                    <asp:DropDownList ID="ddlAttachType" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                                                                        runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Attachment Type."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 50%;">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 22%" valign="top">
                                                                    Attachment Description</td>
                                                                <td align="Center" valign="top" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" align="left" style="width: 78%;">
                                                                    <asp:ImageButton ID="ibtnAttach" TabIndex="36" ImageUrl="~/Images/plus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" />
                                                                    <div id="pnlAttach" style="display: none;">
                                                                        <asp:TextBox ID="txtDescription" runat="server" Width="694px" TextMode="MultiLine">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 22%">
                                                                    Select File to Attach
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 78%">
                                                                    <asp:FileUpload ID="uplCommon" TabIndex="37" runat="server" Width="300px" />
                                                                    <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                        InitialValue="" Display="None" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">
                                                                        
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnAddAttachment" runat="server" TabIndex="38" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                            SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" TabIndex="39" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" />
                                                        <asp:Button ID="btnCancel" runat="server" TabIndex="40" Text="Cancel" OnClick="btnCancel_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </EditItemTemplate>
                                    </asp:FormView>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvAttachDetails" runat="server">
                    <table width="100%">
                        <tr>
                            <td colspan="2">
                                <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                    font-weight: Bolder; font-family: Tahoma; font-size: 10pt;">
                                    <tr>
                                        <td class="ghc">
                                            Attachment Details
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvAttachmentDetails" runat="server" AutoGenerateColumns="false"
                                    DataKeyNames="PK_Attachment_ID" Width="100%" AllowPaging="false" AllowSorting="false"
                                    OnRowDataBound="gvAttachmentDetails_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:UnCheckHeader('gvAttachmentDetails')" />
                                            </ItemTemplate>
                                            <ItemStyle Width="10px" />
                                            <HeaderTemplate>
                                                <input id="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                            </HeaderTemplate>
                                            <HeaderStyle Width="10px" />
                                        </asp:TemplateField>
                                        <%--<asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" SortExpression="Attachment_Type">
                                        </asp:BoundField>--%>
                                        <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"
                                            SortExpression="Attachment_Description"></asp:BoundField>
                                        <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" SortExpression="Attachment_Name1">
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnDwnld" CommandName="Download" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                    runat="server" ImageAlign="Left" ImageUrl="~/Images/download.gif" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Mail">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgbtnMail" CommandName="Mail" CommandArgument='<%# Eval("Attachment_Name")%>'
                                                    runat="server" ImageUrl="~/Images/emailicon.gif" ImageAlign="Left" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        </asp:TemplateField>--%>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="red" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        Currently There Is No Attachment.<br />
                                        Pls Add One Or More Attachment.
                                    </EmptyDataTemplate>
                                    <PagerSettings Visible="False" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnRemove"  runat="server" Text="Remove" OnClick="btnRemove_Click" TabIndex="45" />
                                <asp:Button ID="btnMail" runat="server"  Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Employee');" TabIndex="46" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <%--</div>--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
