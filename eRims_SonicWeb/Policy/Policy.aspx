<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Policy.aspx.cs" Inherits="Policy_Policy"
    MasterPageFile="~/Default.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <link href="../App_Themes/Default/stylecal.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript">
        function ValAttach()
        {
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_rfvAttachType").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_rfvUpload").enabled =true;
            return true;
        }
        
        function ValSave()
        {
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_rfvAttachType").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_rfvUpload").enabled =false;
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
        function openWindowState()
        {
            var strURL;
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtStates").value!="")
            {
                strURL="StatePopUp.aspx?SelStates=" +document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyDetails_txtStates").value;
            }
            else
            {
                strURL="StatePopUp.aspx?SelStates=0";
            }
            oWnd=window.open(strURL,"Erims","location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260,180);
            return false;
        }
        
    </script>

    <script type="text/javascript">
    function ErimsUnCheckHeader()
    {
        var i,flag=0;
        var chk;  
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox'))
            {
                 if(document.forms[0].elements[i].name !="ctl00$ContentPlaceHolder1$gvPolicyDetails$ctl01$chkHeader")
                    {
                    
                    if(document.forms[0].elements[i].checked  == false)
                        {  flag = 1;}
                        }
            }
        }    	
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if ( flag == 1)
            {
                if((document.forms[0].elements[i].type=='checkbox'))
                {
                    if(document.forms[0].elements[i].name =="ctl00$ContentPlaceHolder1$gvPolicyDetails$ctl01$chkHeader")
                    {
                        chk = document.forms[0].elements[i];
                        chk.checked = false;
                    }
                }
            }
            else if (flag == 0)
            {
               if((document.forms[0].elements[i].type=='checkbox'))
                    if(document.forms[0].elements[i].name =="ctl00$ContentPlaceHolder1$gvPolicyDetails$ctl01$chkHeader")
                        document.forms[0].elements[i].checked = true;               
            }
        }
    }
    
    </script>

    <div style="width: 100%;">
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
                                                    <asp:ListItem Value="Policy_Number">Policy Number</asp:ListItem>
                                                    <asp:ListItem Value="Policy_Prefix">Policy Prefix</asp:ListItem>
                                                    <asp:ListItem Value="Carrier">Carrier</asp:ListItem>
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
                                    <asp:Label ID="lblPolicyTotal" runat="server"></asp:Label>
                                </td>
                                <td style="width: 80%;" align="right">
                                    <table width="100%">
                                        <tr>
                                            <td class="lc" align="right">
                                                No. of Records per page :
                                                <asp:DropDownList ID="ddlPage" runat="server" DataSourceID="xdsPaging" DataTextField="Text"
                                                    DataValueField="Value" AutoPostBack="True" SkinID="dropGen" OnSelectedIndexChanged="ddlPage_SelectedIndexChanged">
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
                    <asp:MultiView ID="mvPolicyDetails" runat="server">
                        <asp:View ID="vwPolicyList" runat="server">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%" style="text-align: right;">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Vendor Details"
                                                        OnClick="btnDelete_Click" />
                                                    <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Vendor Details"
                                                        OnClick="btnAddNew_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvPolicyDetails" runat="server" AutoGenerateColumns="false" DataKeyNames="Pk_Policy_Id"
                                                        Width="100%" AllowPaging="True" AllowSorting="True" OnRowCommand="gvPolicyDetails_RowCommand"
                                                        OnSorting="gvPolicyDetails_Sorting">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <input name="chkItem" type="checkbox" value='<%# Eval("Pk_Policy_Id")%>' onclick="javascript:ErimsUnCheckHeader()" />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10px" />
                                                                <HeaderTemplate>
                                                                    <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                                </HeaderTemplate>
                                                                <HeaderStyle Width="10px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PolicyType" HeaderText="Policy Type" SortExpression="PolicyType">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Carrier" HeaderText="Insurance Carrier" SortExpression="Carrier">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Policy_Number" HeaderText="Policy Number" SortExpression="Policy_Number">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="PolicyStatus" HeaderText="Policy Status" SortExpression="PolicyStatus">
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("Pk_Policy_Id")%>'
                                                                        runat="server" Text="Edit" ToolTip="Edit the Policy Details" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("Pk_Policy_Id")%>'
                                                                        ToolTip="View the Policy Details" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                        <EmptyDataTemplate>
                                                            Currently There Is No Policy.
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
                        <asp:View ID="vwVendorDetails" runat="server">
                            <table width="100%">
                                <%--<tr>
                                    <td class="lc">
                                        Vendor
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td align="center">
                                        <asp:FormView ID="fvPolicyDetails" runat="server" Width="100%" OnDataBound="fvPolicyDetails_DataBound">
                                            <ItemTemplate>
                                                <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                    text-align: left;">
                                                    <tr>
                                                        <td colspan="2">
                                                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                <tr>
                                                                    <td class="ghc">
                                                                        Policy
                                                                        <asp:Label ID="lblPolicyDetailsId" runat="server" Text='<%#Eval("Pk_Policy_Id")%>'
                                                                            Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%" style="text-align: left;">
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Type</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblPolType" runat="server" Text='<%# Eval("PolicyType") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        <asp:Label ID="lblPolNo" runat="server" Text='<%# Eval("Policy_Number") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        NCCI Classification Code<br>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblNCCI" runat="server" Text='<%# Eval("NCCI_Classification_Code") %>'></asp:Label></td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Coverage Code<br>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblCovCode" runat="server" Text='<%# Eval("CovCode") %>'></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Insurance Carrier</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblCarrier" runat="server" Text='<%# Eval("Carrier") %>'></asp:Label></td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Underwriter</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblUnderWriter" runat="server" Text='<%# Eval("Underwriter") %>'></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Begin Date</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDtPolBegin" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Policy_Begin_Date", "{0:MM/dd/yyyy}")%>'>></asp:Label></td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Expiration Date</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDtPolExp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Policy_Expiration_Date", "{0:MM/dd/yyyy}")%>'>></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        States Covered</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 75%;" colspan="4">
                                                                        <asp:Label ID="lblStateCov" runat="server" Text='<%# Eval("States_Covered") %>'></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Status</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblPolStatus" runat="server" Text='<%# Eval("PolicyStatus") %>'></asp:Label></td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Annual Premium</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        $<asp:Label ID="lblPolAnnPremium" runat="server" Text='<%# Eval("Annual_Premium") %>'></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Client Id Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblClientIdNo" runat="server" Text='<%# Eval("Client_Id") %>'></asp:Label></td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Client Location Code</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblClientLocCode" runat="server" Text='<%# Eval("Client_Location_Code") %>'></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Contract End Date</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDtContEnd" runat="server" Text='<%# Eval("Contract_End_Date") %>'></asp:Label></td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Contract Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblContNo" runat="server" Text='<%# Eval("Contract_Number") %>'></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Contract Start Date</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDtContStart" runat="server" Text='<%# Eval("Contract_Start_Date") %>'></asp:Label></td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Employer Federal Id Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblEmpFedId" runat="server" Text='<%# Eval("Employer_Fed_Id_No") %>'></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Employer SIC Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblEmpSICNo" runat="server" Text='<%# Eval("Employer_SIC") %>'></asp:Label></td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Deductible?</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDeductable" runat="server" Text='<%# Eval("Deductible") %>'></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Division of AIG</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblDivAIG" runat="server" Text='<%# Eval("Division_AIG") %>'></asp:Label></td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Prefix</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblPoPrefix" runat="server" Text='<%# Eval("Policy_Prefix") %>'></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Insured Name ISO Catastrophe Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblISO" runat="server" Text='<%# Eval("Insured_ISO_Cat") %>'></asp:Label></td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Coverage Layer Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:Label ID="lblPolLayerNo" runat="server" Text='<%# Eval("Layer_Number") %>'></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Coverage Description</td>
                                                                    <td valign="top" class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 75%;" colspan="4">
                                                                        <asp:TextBox ID="txtCovDesc" Width="600px" runat="server" ReadOnly="True" TextMode="MultiLine"
                                                                            Text='<%# Eval("Coverage_Description") %>'></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" valign="top">
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
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                        </td>
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
                                                                        Policy
                                                                        <asp:Label ID="lblPolicyDetailsId" runat="server" Text='<%#Eval("Pk_Policy_Id")%>'
                                                                            Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="100%" style="text-align: left;">
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Type<span class="mf">*</span></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:DropDownList ID="ddlPolType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPolType_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvPolType" InitialValue="0" ControlToValidate="ddlPolType"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Policy Type."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Number<span class="mf">*</span></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        <asp:TextBox ID="txtPolNo" runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvPolNo" InitialValue="" ControlToValidate="txtPolNo"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Enter Policy Number."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        NCCI Classification Code<br>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtNCCI" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Coverage Code<span class="mf">*</span><br>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:DropDownList ID="ddlCovCode" runat="server">
                                                                            <asp:ListItem Text="--Select Coverage Code--" Value="0"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvCovCode" InitialValue="0" ControlToValidate="ddlCovCode"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Coverage Code."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Insurance Carrier</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtCarrier" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Underwriter</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtUnderWriter" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Begin Date<span class="mf">*</span></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtDtPolBegin" runat="server"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtPolBegin', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtPolBegin"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvPolBegin" runat="server" ControlToValidate="txtDtPolBegin"
                                                                            InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Enter Policy Begin Date."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Expiration Date<span class="mf">*</span></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtDtPolExp" runat="server"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtPolExp', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtPolExp"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvPolExp" runat="server" ControlToValidate="txtDtPolExp"
                                                                            InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Enter Policy Expiration Date."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtDtPolExp"
                                                                            ValidationGroup="vsErrorGroup" ErrorMessage="Policy Expiry Date Must Be Greater Than Begin Date."
                                                                            Type="Date" Operator="GreaterThan" ControlToCompare="txtDtPolBegin" Display="none">
                                                                        </asp:CompareValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        States Covered</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 75%;" colspan="4">
                                                                        <asp:TextBox ID="txtStates" runat="server" ReadOnly="true"></asp:TextBox>
                                                                        <asp:Button ID="btnStates" runat="server" Text="V" SkinID="btnGen" />
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Status<span class="mf">*</span></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:DropDownList ID="ddlPolStatus" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvPolStatus" InitialValue="0" ControlToValidate="ddlPolStatus"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Policy Status."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Annual Premium<span class="mf">*</span></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        $<asp:TextBox ID="txtPolAnnPremium" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvPolAnnPremium" runat="server" ControlToValidate="txtPolAnnPremium"
                                                                            EnableClientScript="true" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Enter Policy Annual Premium."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Client Id Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtClientId" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Client Location Code</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtClientLocCode" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Contract End Date</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtDtContEnd" runat="server"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtContEnd', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <br />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtContEnd"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CompareValidator ID="cvCompServiceDate" runat="server" ControlToValidate="txtDtContEnd"
                                                                            ValidationGroup="vsErrorGroup" ErrorMessage="Contract End Date Must Be Greater Than Start Date."
                                                                            Type="Date" Operator="GreaterThan" ControlToCompare="txtDtContStart" Display="none">
                                                                        </asp:CompareValidator>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Contract Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtContNo" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Contract Start Date</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtDtContStart" runat="server"></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtContStart', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtContStart"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Employer Federal Id Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtFedNo" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Employer SIC Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtEmpSICNo" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Deductible?</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:RadioButtonList ID="rdbLstDeduct" runat="server">
                                                                            <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Division of AIG</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtDivAIG" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Prefix</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtPolPrefix" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Insured Name ISO Catastrophe Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtISO" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Coverage Layer Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtLayerNo" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Coverage Description</td>
                                                                    <td valign="top" class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 75%;" colspan="4">
                                                                        <asp:TextBox ID="txtCovDesc" Width="600px" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" valign="top">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
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
                                                    <tr>
                                                        <td align="left">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Attachment Type
                                                                    </td>
                                                                    <td class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:DropDownList ID="ddlAttachType" runat="server" SkinID="dropGen">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                                                                            runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Attachment Type."
                                                                            Display="none"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="lc" style="width: 24.3%">
                                                                        Attachment Description</td>
                                                                    <td align="Center" valign="top" class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" align="left" style="width: 75.7%;">
                                                                        <asp:TextBox ID="txtDescription" runat="server" Width="694px" Height="90px" TextMode="MultiLine">
                                                                        </asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="lc" style="width: 24.3%">
                                                                        Attachment Filename
                                                                    </td>
                                                                    <td align="Center" class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 75.7%">
                                                                        <asp:FileUpload ID="uplCommon" runat="server" Width="300px" />
                                                                        <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="uplCommon"
                                                                            InitialValue="" Display="None" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">
                                                                        
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                                SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" />
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                                OnClientClick="javascript:ValSave();" OnClick="btnSave_Click" />
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </InsertItemTemplate>
                                            <EditItemTemplate>
                                                <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                    text-align: left;">
                                                    <tr>
                                                        <td colspan="2">
                                                            <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                font-weight: Bolder; font-family: Tahoms; font-size: 10pt;">
                                                                <tr>
                                                                    <td class="ghc">
                                                                        Policy
                                                                        <asp:Label ID="lblPolicyDetailsId" runat="server" Text='<%#Eval("Pk_Policy_Id")%>'
                                                                            Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%" style="text-align: left;">
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Type<span class="mf">*</span></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:DropDownList ID="ddlPolType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPolType_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvPolType" InitialValue="0" ControlToValidate="ddlPolType"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Policy Type."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Number<span class="mf">*</span></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        <asp:TextBox ID="txtPolNo" runat="server" Text='<%# Eval("Policy_Number") %>'></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvPolNo" InitialValue="" ControlToValidate="txtPolNo"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Enter Policy Number."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        NCCI Classification Code<br>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtNCCI" runat="server" Text='<%# Eval("NCCI_Classification_Code") %>'></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Coverage Code<span class="mf">*</span><br>
                                                                    </td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:DropDownList ID="ddlCovCode" runat="server">
                                                                            <asp:ListItem Text="--Select Coverage Code--" Value="0"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvCovCode" InitialValue="0" ControlToValidate="ddlCovCode"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Coverage Code."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Insurance Carrier</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtCarrier" runat="server" Text='<%# Eval("Carrier") %>'></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Underwriter</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtUnderWriter" runat="server" Text='<%# Eval("Underwriter") %>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Begin Date<span class="mf">*</span></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtDtPolBegin" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Policy_Begin_Date", "{0:MM/dd/yyyy}")%>'></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtPolBegin', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="mskExDtRecBegin" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtPolBegin"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvPolBegin" runat="server" ControlToValidate="txtDtPolBegin"
                                                                            InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Enter Policy Begin Date."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Expiration Date<span class="mf">*</span>
                                                                        <asp:CompareValidator ID="cvCompServiceDate" runat="server" ControlToValidate="txtDtPolExp"
                                                                            ValidationGroup="vsErrorGroup" ErrorMessage="Policy Expiry Date Must Be Greater Than Begin Date."
                                                                            Type="Date" Operator="GreaterThan" ControlToCompare="txtDtPolBegin" Display="none">
                                                                        </asp:CompareValidator></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtDtPolExp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Policy_Expiration_Date", "{0:MM/dd/yyyy}")%>'></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtPolExp', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtPolExp"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:RequiredFieldValidator ID="rfvPolExp" runat="server" ControlToValidate="txtDtPolExp"
                                                                            InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Enter Policy Expiration Date."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        States Covered</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" colspan="4">
                                                                        <asp:TextBox ID="txtStates" runat="server" Text='<%# Eval("States_Covered") %>' ReadOnly="true"></asp:TextBox>
                                                                        <asp:Button ID="btnStates" runat="server" Text="V" SkinID="btnGen" />
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Status<span class="mf">*</span></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:DropDownList ID="ddlPolStatus" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvPolStatus" InitialValue="0" ControlToValidate="ddlPolStatus"
                                                                            runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Policy Status."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Annual Premium<span class="mf">*</span></td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtPolAnnPremium" runat="server" Text='<%# Eval("Annual_Premium") %>'
                                                                            onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="rfvPolAnnPremium" runat="server" ControlToValidate="txtPolAnnPremium"
                                                                            InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Enter Policy Annual Premium."
                                                                            Display="None">
                                                                        </asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Client Id Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtClientId" runat="server" Text='<%# Eval("Client_Id") %>'></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Client Location Code</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtClientLocCode" runat="server" Text='<%# Eval("Client_Location_Code") %>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Contract End Date</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtDtContEnd" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Contract_End_Date", "{0:MM/dd/yyyy}")%>'></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtContEnd', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" /><br />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtContEnd"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtDtContEnd"
                                                                            ValidationGroup="vsErrorGroup" ErrorMessage="Contract End Date Must Be Greater Than Start Date."
                                                                            Type="Date" Operator="GreaterThan" ControlToCompare="txtDtContStart" Display="none">
                                                                        </asp:CompareValidator>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Contract Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtContNo" runat="server" Text='<%# Eval("Contract_Number") %>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Contract Start Date</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtDtContStart" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Contract_Start_Date", "{0:MM/dd/yyyy}")%>'></asp:TextBox>
                                                                        <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_fvPolicyDetails_txtDtContStart', 'mm/dd/y');"
                                                                            onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                                                            align="absmiddle" /><br />
                                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptNegative="Left"
                                                                            DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                                                            OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDtContStart"
                                                                            CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                                                        </cc1:MaskedEditExtender>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Employer Federal Id Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtFedNo" runat="server" Text='<%# Eval("Employer_Fed_ID_No") %>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Employer SIC Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtEmpSICNo" runat="server" Text='<%# Eval("Employer_SIC") %>'></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Deductible?</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:RadioButtonList ID="rdbLstDeduct" runat="server">
                                                                            <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Division of AIG</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtDivAIG" runat="server" Text='<%# Eval("Division_AIG") %>'></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Prefix</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtPolPrefix" runat="server" Text='<%# Eval("Policy_Prefix") %>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Insured Name ISO Catastrophe Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtISO" runat="server" Text='<%# Eval("Insured_ISO_Cat") %>'></asp:TextBox>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Policy Coverage Layer Number</td>
                                                                    <td class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:TextBox ID="txtLayerNo" runat="server" Text='<%# Eval("Layer_Number") %>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Coverage Description</td>
                                                                    <td valign="top" class="lc">
                                                                        :</td>
                                                                    <td class="ic" style="width: 75%;" colspan="4">
                                                                        <asp:TextBox ID="txtCovDesc" Width="600px" runat="server" TextMode="MultiLine" Text='<%# Eval("Coverage_Description") %>'></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6" valign="top">
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
                                                    <tr>
                                                        <td align="left" colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="lc" style="width: 25%;">
                                                                        Attachment Type
                                                                    </td>
                                                                    <td align="center" class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        <asp:DropDownList ID="ddlAttachType" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvAttachType" ControlToValidate="ddlAttachType"
                                                                            runat="server" InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the Attachment Type."
                                                                            Display="none"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="lc" style="width: 25%;">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;</td>
                                                                    <td class="ic" style="width: 25%;">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="lc" style="width: 24.3%">
                                                                        Attachment Description</td>
                                                                    <td align="center" valign="top" class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" align="left" style="width: 75.7%;">
                                                                        <asp:TextBox ID="txtDescription" runat="server" Width="650px" Height="90px" TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td class="lc" style="width: 24.3%">
                                                                        Attachment Filename
                                                                    </td>
                                                                    <td align="center" class="lc">
                                                                        :
                                                                    </td>
                                                                    <td class="ic" style="width: 75.7%">
                                                                        <asp:FileUpload ID="uplCommon" runat="server" Width="300px" />
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
                                                            <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                                SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" />
                                                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                                OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" />
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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
                                        DataKeyNames="PK_Attachment_ID" Width="100%" AllowPaging="FALSE" AllowSorting="FALSE"
                                        OnRowDataBound="gvAttachmentDetails_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <input name="chkItem" type="checkbox" value='<%# Eval("PK_Attachment_ID")%>' onclick="javascript:javascript:UnCheckHeader('gvAttachmentDetails')" />
                                                </ItemTemplate>
                                                <ItemStyle Width="10px" />
                                                <HeaderTemplate>
                                                    <input id="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                </HeaderTemplate>
                                                <HeaderStyle Width="10px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" SortExpression="Attachment_Type">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"
                                                SortExpression="Attachment_Description"></asp:BoundField>
                                            <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" SortExpression="Attachment_Name">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Icon">
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
                                        <PagerSettings Visible="False" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                    <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Policy');" />
                </td>
            </tr>
        </table>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
