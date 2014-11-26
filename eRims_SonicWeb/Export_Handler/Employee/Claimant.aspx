<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Claimant.aspx.cs"
    Inherits="Employee_Claimant"  %>

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
                if(document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtDescription").style.height == "")
                {
                
                    document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_ibtnAttach").src = "../Images/minus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtDescription").style.height = "200px";
                    document.getElementById("pnlAttach").style.display = "block";
                }
                else if(document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtDescription").style.height == "200px")
                {
                    
                    document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_ibtnAttach").src = "../Images/plus.jpg";
                    document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtDescription").style.height="";
                    document.getElementById("pnlAttach").style.display = "none";
                }
            }
            return false;
        }
        function ValAttach()
        {
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_rfvAttachType").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_rfvUpload").enabled =true;
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtCellPhone").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtCellPhone").value="";
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtHomePhone").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtHomePhone").value="";
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtSSN").value=="___-__-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtSSN").value="";
            return true;
        }
        function ValSave()
        {
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_rfvAttachType").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_rfvUpload").enabled =false;
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtCellPhone").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtCellPhone").value="";
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtHomePhone").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtHomePhone").value="";
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtSSN").value=="___-__-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvClaimantDetails_txtSSN").value="";
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
        function conditionalPostback(sender, args) 
        { 
            var eventTarget = args.EventTarget;
            
            //else
            //{
                return true;
            //} 
        } 
        function getValue()
    {
        //document.form1.TextBox1.value=document.form1.Drp.options[document.form1.Drp.selectedIndex].text;
        document.getElementById("ctl00_ContentPlaceHolder1_txtSearchType").value = document.getElementById("ctl00_ContentPlaceHolder1_ddlSearch").options[document.getElementById("ctl00_ContentPlaceHolder1_ddlSearch").selectedIndex].text; 
    }
        
    </script>

    <asp:ScriptManager ID="smClaimantDetail" EnablePageMethods="true" runat="server">
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
                                                <asp:ListItem Value="Claimant_Id">Claimant Id</asp:ListItem>
                                            </asp:DropDownList>
                                            <div style="display:none;">
                                            <asp:TextBox ID="txtSearchType" Style="z-index: 100; text-align:right;"  runat="server"></asp:TextBox>
                                            
                                            </div>
                                            </td>
                                        <td class="ic">
                                            <asp:TextBox  ID="txtSearch" runat="server"></asp:TextBox></td>
                                        <td class="ic">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%;" align="left" class="lc">
                                <asp:Label ID="lblClaimantTotal" runat="server"></asp:Label>
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
                                            <asp:TextBox ID="txtPageNo" runat="server" Width="20px" onkeypress="return numberOnly(event);" MaxLength="3"></asp:TextBox>
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
                <asp:MultiView ID="mvClaimantDetails" runat="server">
                    <asp:View ID="vwClaimantList" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <table width="100%" style="text-align: right;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Claimant Details"
                                                    OnClick="btnDelete_Click" />
                                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Claimant Details"
                                                    OnClick="btnAddNew_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvClaimantDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Claimant_ID"
                                                    Width="100%" AllowPaging="True" AllowSorting="True" OnRowCommand="gvClaimantDetails_RowCommand"
                                                    OnSorting="gvClaimantDetails_Sorting" OnRowCreated="gvClaimantDetails_RowCreated" OnRowDataBound="gvClaimantDetails_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Claimant_ID")%>' onclick="javascript:UnCheckHeader('gvClaimantDetails')" />
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
                                                        <asp:BoundField HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" DataField="Claimant_Id" HeaderText="Claimant Id" SortExpression="Claimant_Id">
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Claimant_ID")%>'
                                                                    runat="server" Text="Edit" ToolTip="Edit the Claimant Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Claimant_ID")%>'
                                                                    ToolTip="View the Claimant Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        Currently There Is No Claimant.
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
                    <asp:View ID="vwClaimantDetails" runat="server">
                        <table width="100%">
                            <%--<tr>
                                    <td class="lc">
                                        Vendor
                                    </td>
                                </tr>--%>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:FormView ID="fvClaimantDetails" runat="server" Width="100%" OnDataBound="fvClaimantDetails_DataBound">
                                        <ItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Claimant Module
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    Claimant Id
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic">
                                                                    <asp:Label ID="lblClaimantId" runat="server" Text='<%#Eval("Claimant_Id") %>'></asp:Label></td>
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
                                                                    <asp:Label ID="lblClaimantDetailsId" runat="server" Text='<%#Eval("PK_Claimant_ID")%>'
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
                                                                    <asp:Label ID="lblAddress1" runat="server" Text='<%#Eval("Claimant_Address_1") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    City
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("Claimant_City") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Zip Code
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblZip" runat="server" Text='<%#Eval("Claimant_Zip_Code") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Cell Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Claimant_Cell_Phone") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Date Of Birth
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblDOB" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Date_Of_Birth","{0:MM/dd/yyyy}") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Drivers License Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblDLNo" runat="server" Text='<%#Eval("Drivers_License_Number") %>'></asp:Label></td>
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
                                                                    <asp:Label ID="lblAddress2" runat="server" Text='<%#Eval("Claimant_Address_2") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    State
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblState" runat="server" Text='<%#Eval("Claimant_State") %>'></asp:Label>
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
                                                                    <asp:Label ID="lblHomeTelNo" runat="server" Text='<%#Eval("Claimant_Home_Phone") %>'></asp:Label>
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
                                                                    Drivers License State
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblDLState" runat="server" Text='<%#Eval("Drivers_License_State") %>'></asp:Label>
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
                                                                    Claimant Module
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:50%;">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    <div style="display: none">
                                                                        <asp:TextBox ID="txtCurrentDate" runat="Server"></asp:TextBox>
                                                                    </div>Claimant Id
                                                                   <%-- <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic">
                                                                    <asp:TextBox ID="txtClaimantId" runat="server" onkeypress="return numberOnly(event);" TabIndex="1"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvClaimantId" ControlToValidate="txtClaimantId"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Claimant Id."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:Label ID="lblClaimantDetailsId" runat="server" Text='<%#Eval("PK_Claimant_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    First Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic">
                                                                    <asp:TextBox ID="txtFirstName" runat="server" Text='<%# Eval("Claimant_Id")%>' TabIndex="3"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtFirstName" EnableClientScript="true"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter First Name."
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
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtAddress1" runat="server" TabIndex="5"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAddress1" ControlToValidate="txtAddress1" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Address Line 1."
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
                                                                    <asp:TextBox ID="txtCity" runat="server" TabIndex="7"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="txtCity" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the City."
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
                                                                    <asp:TextBox ID="txtZip" runat="server" MaxLength="5" TabIndex="9" onkeypress="return numberOnly(event);"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvZip" ControlToValidate="txtZip" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Zip."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip"
                                                                        ValidationExpression="^\d{5}$" ErrorMessage="Please Enter 5 Digits For Zip."
                                                                        ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Cell Number(xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:TextBox ID="txtCellPhone" runat="server" MaxLength="12" TabIndex="11" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskPhone" runat="server" TargetControlID="txtCellPhone"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="txtCellPhone" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Date Of Birth
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:TextBox ID="txtDOB" runat="server" SkinID="txtDate" TabIndex="13"></asp:TextBox>
                                                                    <img runat="server" id="imgDOB" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvClaimantDetails_txtDOB', 'mm/dd/y');"
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
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDOB"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Date of Birth Should Not Be Greater Than Future Date."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver License Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDriverLicenseNumber" runat="server" TabIndex="15"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top" style="width:50%;">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Last Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtLastName" runat="server" TabIndex="2"></asp:TextBox>
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
                                                                    <asp:TextBox ID="txtMiddleName" runat="server" TabIndex="4"></asp:TextBox>
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
                                                                    <asp:TextBox ID="txtAddress2" runat="server" TabIndex="6"></asp:TextBox>
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
                                                                    <asp:DropDownList ID="ddlState" runat="server" SkinID="dropGen" Width="155px" TabIndex="8">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the State."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Home Telephone Number(xxx-xxx-xxxx)<%--<span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:TextBox ID="txtHomePhone" runat="server" TabIndex="10" MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtHomePhone"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                   <%-- <asp:RequiredFieldValidator ID="rfvHomePhone" ControlToValidate="txtHomePhone" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Home Telephone Number."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtHomePhone"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Home Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Social Security Number(xxx-xx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSSN" MaxLength =11 runat="server" TabIndex="12">
                                                                    </asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtSSN"
                                                                        Mask="999-99-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtSSN"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter SSN in xxx-xx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{2}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Drivers License State
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlDriverState" runat="server" SkinID="dropGen" Width="155px" TabIndex="14">
                                                                    </asp:DropDownList>
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
                                                <tr style="display:none;">
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
                                                                <td class="lc" style="width: 24%;" valign="top">
                                                                    Attachment Description</td>
                                                                <td align="Center" valign="top" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" align="left" style="width:76%;">
                                                                <asp:ImageButton ID="ibtnAttach" TabIndex="16" ImageUrl="~/Images/plus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" />
                                                                    <div id="pnlAttach" style="display:none;">
                                                                    
                                                                    <asp:TextBox ID="txtDescription" runat="server" Width="620px"  TextMode="MultiLine">
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
                                                                    <asp:FileUpload ID="uplCommon" TabIndex="17" runat="server" Width="300px" />
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
                                                        <asp:Button ID="btnAddAttachment" TabIndex="18" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                            SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" />
                                                        <asp:Button ID="btnSave" runat="server" TabIndex="19" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" />
                                                        <asp:Button ID="btnCancel" runat="server" TabIndex="20" Text="Cancel" OnClick="btnCancel_Click" />
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
                                                                    Claimant Module
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:50%;">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    <div style="display: none">
                                                                        <asp:TextBox ID="txtCurrentDate" runat="Server"></asp:TextBox>
                                                                    </div>Claimant Id
                                                                  <%--  <span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic">
                                                                    <asp:TextBox ID="txtClaimantId" onkeypress="return numberOnly(event);" runat="server" Text='<%#Eval("Claimant_ID")%>' TabIndex="1"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvClaimantId" ControlToValidate="txtClaimantId"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Claimant Id."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:Label ID="lblClaimantDetailsId" runat="server" Text='<%#Eval("PK_Claimant_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    First Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic">
                                                                    <asp:TextBox ID="txtFirstName" runat="server" Text='<%#Eval("First_Name")%>' TabIndex="3"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvFirstName" ControlToValidate="txtFirstName" EnableClientScript="true"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter First Name."
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
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtAddress1" runat="server" Text='<%#Eval("Claimant_Address_1")%>' TabIndex="5"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAddress1" ControlToValidate="txtAddress1" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Address Line 1."
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
                                                                    <asp:TextBox ID="txtCity" runat="server" Text='<%#Eval("Claimant_City")%>' TabIndex="7"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="txtCity" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the City."
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
                                                                    <asp:TextBox ID="txtZip" runat="server" MaxLength="5" Text='<%#Eval("Claimant_Zip_Code")%>'
                                                                        onkeypress="return numberOnly(event);" TabIndex="9"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvZip" ControlToValidate="txtZip" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Zip."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip"
                                                                        ValidationExpression="^\d{5}$" ErrorMessage="Please Enter 5 Digits For Zip."
                                                                        ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Cell Number(xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:TextBox ID="txtCellPhone" runat="server" MaxLength="12" Text='<%#Eval("Claimant_Cell_Phone")%>'
                                                                        onkeypress="return noPhoneFax(event);" TabIndex="11"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskPhone" runat="server" TargetControlID="txtCellPhone"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revPhone" ControlToValidate="txtCellPhone" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td  class="lc">
                                                                    Date Of Birth
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td  class="ic">
                                                                    <asp:TextBox ID="txtDOB" runat="server" SkinID="txtDate" Text='<%#DataBinder.Eval(Container.DataItem,"Date_Of_Birth","{0:MM/dd/yyyy}") %>' TabIndex="13"></asp:TextBox>
                                                                    <img runat="server" id="imgDOB" onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvClaimantDetails_txtDOB', 'mm/dd/y');"
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
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDOB"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Birth Date Should Not Be Greater Than Future Date."
                                                                        Type="Date" Operator="LessThan" ControlToCompare="txtCurrentDate" Display="none">
                                                                    </asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Driver License Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtDriverLicenseNumber" runat="server" Text='<%#Eval("Drivers_License_Number")%>' TabIndex="15"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top" style="width:50%;">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Last Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtLastName" runat="server" Text='<%#Eval("Last_Name")%>' TabIndex="2"></asp:TextBox>
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
                                                                    <asp:TextBox ID="txtMiddleName" runat="server" Text='<%#Eval("Middle_Name")%>' TabIndex="4"></asp:TextBox>
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
                                                                    <asp:TextBox ID="txtAddress2" runat="server" Text='<%#Eval("Claimant_Address_2")%>' TabIndex="6"></asp:TextBox>
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
                                                                    <asp:DropDownList ID="ddlState" runat="server" SkinID="dropGen" Width="155px" TabIndex="8">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the State."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Home Telephone Number(xxx-xxx-xxxx)<%--<span class="mf">*</span>--%>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:TextBox ID="txtHomePhone" runat="server" MaxLength="12" Text='<%#Eval("Claimant_Home_Phone")%>'
                                                                        onkeypress="return noPhoneFax(event);" TabIndex="10"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtHomePhone"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvHomePhone" ControlToValidate="txtHomePhone" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Home Telephone Number."
                                                                        Display="none"></asp:RequiredFieldValidator>--%>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtHomePhone"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Home Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Social Security Number(xxx-xx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtSSN"  MaxLength ="11" runat="server" Text='<%#Eval("Social_Security_Number")%>' TabIndex="12">
                                                                    </asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtSSN"
                                                                        Mask="999-99-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtSSN"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter SSN in xxx-xx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{2}-\d{4}$"></asp:RegularExpressionValidator>
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Drivers License State
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:DropDownList ID="ddlDriverState" runat="server" SkinID="dropGen" Width="155px" TabIndex="14">
                                                                    </asp:DropDownList>
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
                                                <tr style="display:none;">
                                                    <td style="width: 50%;" align="left">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 50%;">
                                                                    Attachment Type
                                                                </td>
                                                                <td align="center" class="lc">
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
                                                                <td class="lc" style="width: 24%" valign="top">
                                                                    Attachment Description</td>
                                                                <td align="center" valign="top" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" align="left" style="width: 76%;">
                                                                <asp:ImageButton ID="ibtnAttach" ImageUrl="~/Images/plus.jpg" runat="server" OnClientClick="javascript:return MinMax('attachment');" TabIndex="16" />
                                                                    <div id="pnlAttach" style="display:none;">
                                                                    
                                                                    <asp:TextBox ID="txtDescription" runat="server" Width="620px" TextMode="MultiLine"></asp:TextBox>
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
                                                                <td align="center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic" style="width: 76%">
                                                                    <asp:FileUpload ID="uplCommon" runat="server" Width="300px" TabIndex="17"/>
                                                                    <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                        InitialValue="" Display="None" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">
                                                                        
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" class="ic">
                                                        <asp:Button ID="btnAddAttachment" TabIndex="18" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                            SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" TabIndex="19" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" TabIndex="20" />
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
                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:UnCheckHeader('gvAttachmentDetails')"/>
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
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                                <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Claimant');" />
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
