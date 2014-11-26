<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PolicyCoverage.aspx.cs" Inherits="Policy_PolicyCoverage"
    MasterPageFile="~/Default.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript">
        function ValAttach()
        {
            document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyCovDetails_rfvAttachType").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyCovDetails_rfvUpload").enabled =true;
            return true;
        }
        function ValSave()
        {
            document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyCovDetails_rfvAttachType").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_fvPolicyCovDetails_rfvUpload").enabled =false;
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
                 if(document.forms[0].elements[i].name !="ctl00$ContentPlaceHolder1$gvPolicyCovDetails$ctl01$chkHeader")
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
                    if(document.forms[0].elements[i].name =="ctl00$ContentPlaceHolder1$gvPolicyCovDetails$ctl01$chkHeader")
                    {
                        chk = document.forms[0].elements[i];
                        chk.checked = false;
                    }
                }
            }
            else if (flag == 0)
            {
               if((document.forms[0].elements[i].type=='checkbox'))
                    if(document.forms[0].elements[i].name =="ctl00$ContentPlaceHolder1$gvPolicyCovDetails$ctl01$chkHeader")
                        document.forms[0].elements[i].checked = true;               
            }
        }
    }
    
    </script>

    <div style="width: 100%;">
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
            <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
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
                                                    <asp:ListItem Value="Policy_Coverage">Policy Coverage</asp:ListItem>
                                                    <asp:ListItem Value="Other_Policy_Type">Other Liability Coverage Type</asp:ListItem>
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
                                    <asp:Label ID="lblPolicyCovTotal" runat="server"></asp:Label>
                                </td>
                                <td style="width: 80%;" align="right">
                                    <table width="100%">
                                        <tr>
                                            <td class="lc">
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
                    <asp:MultiView ID="mvPolicyCovDetails" runat="server">
                        <asp:View ID="vwPolicyCovList" runat="server">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <table width="100%" style="text-align: right;">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Vendor Details"
                                                        OnClick="btnDelete_Click" />
                                                    <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Vendor Details"
                                                        OnClick="btnAddNew_Click" ValidationGroup="vsErrorGroup" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvPolicyCovDetails" runat="server" AutoGenerateColumns="false"
                                                        DataKeyNames="PK_Policy_Coverage_Id" Width="100%" AllowPaging="True" AllowSorting="True"
                                                        OnRowCommand="gvPolicyCovDetails_RowCommand" OnSorting="gvPolicyCovDetails_Sorting">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <input name="chkItem" type="checkbox" value='<%# Eval("PK_Policy_Coverage_Id")%>'
                                                                        onclick="javascript:ErimsUnCheckHeader()" />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="10px" />
                                                                <HeaderTemplate>
                                                                    <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                                </HeaderTemplate>
                                                                <HeaderStyle Width="10px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="PolicyNumber" HeaderText="Policy" SortExpression="PolicyNumber">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Policy_Coverage" HeaderText="Policy Coverage" SortExpression="Policy_Coverage">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Other_Policy_Type" HeaderText="Other Liability Coverage Type"
                                                                SortExpression="Other_Policy_Type"></asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Policy_Coverage_Id")%>'
                                                                        runat="server" Text="Edit" ToolTip="Edit the Policy Coverage Details" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Policy_Coverage_Id")%>'
                                                                        ToolTip="View the Policy Coverage Details" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                        <EmptyDataTemplate>
                                                            Currently There Is No Policy Coverage.
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
                        <asp:View ID="vwPolicyCovDetails" runat="server">
                            <asp:FormView ID="fvPolicyCovDetails" runat="server" Width="100%" OnDataBound="fvPolicyCovDetails_DataBound">
                                <ItemTemplate>
                                    <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                        text-align: left;">
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                    font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                    <tr>
                                                        <td class="ghc">
                                                            Policy Coverage
                                                            <asp:Label ID="lblPolicyCovDetailsId" runat="server" Text='<%#Eval("PK_Policy_Coverage_Id")%>'
                                                                Height="0px" Width="0px" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Policy</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblPolicy" runat="server" Text='<%# Eval("PolicyNumber") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Policy Coverage Description</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblPolCovDesc" runat="server" Text='<%# Eval("Policy_Coverage") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Policy Limits and Deductibles
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Policy Deductible/Self Insured Retention Per Claim
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblPolDeduct" runat="server" Text='<%# Eval("Policy_Deductible") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Policy Limit Each Occurrence
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblPolLimit" runat="server" Text='<%# Eval("Occurrence_Limit") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Policy Limit General Aggregate
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblPolLimitGen" runat="server" Text='<%# Eval("Aggregate_Limit") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;
                                            </td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            General Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Rented Premises Damage Limit
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblGLRentDamage" runat="server" Text='<%# Eval("GL_Rent_Damage") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Medical Expense Limit
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblGLMedical" runat="server" Text='<%# Eval("GL_Medical") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Products and Completed Operations Limit
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblGLProducts" runat="server" Text='<%# Eval("GL_Products") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;
                                            </td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Auto Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Personal Injury Protection Limit
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblALPIP" runat="server" Text='<%# Eval("AL_PIP") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Medical Payment Limit
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblALMedical" runat="server" Text='<%# Eval("AL_Medical") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Uninsured Motorist Coverage
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblALUninsure" runat="server" Text='<%# Eval("AL_Uninsured") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Underinsured Motorist Coverage
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblALUnderInsured" runat="server" Text='<%# Eval("AL_Underinsured") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Umbrella/Excess Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Umbrella / Excess Liability Limit</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblUmbrella" runat="server" Text='<%# Eval("Umbrella") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;
                                            </td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Other Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Other Liability Coverage Type</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblOtherPolicy" runat="server" Text='<%# Eval("Other_Policy_Type") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;</td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Policy Features
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Specific Feature</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblPolFeature1" runat="server" Text='<%# Eval("PolFeature1") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Deductible</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblDeduct1" runat="server" Text='<%# Eval("Deductible_1") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Limit
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblLimit1" runat="server" Text='<%# Eval("Limit_1") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Specific Feature</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblPolFeature2" runat="server" Text='<%# Eval("PolFeature2") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Deductible</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblDeduct2" runat="server" Text='<%# Eval("Deductible_2") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Limit</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblLimit2" runat="server" Text='<%# Eval("Limit_2") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Specific Feature</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblPolFeature3" runat="server" Text='<%# Eval("PolFeature3") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Deductible</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblDeduct3" runat="server" Text='<%# Eval("Deductible_3") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Limit</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblLimit3" runat="server" Text='<%# Eval("Limit_3") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Specific Feature</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblPolFeature4" runat="server" Text='<%# Eval("PolFeature4") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Deductible</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblDeduct4" runat="server" Text='<%# Eval("Deductible_4") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Limit</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblLimit4" runat="server" Text='<%# Eval("Limit_4") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Specific Feature</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblPolFeature5" runat="server" Text='<%# Eval("PolFeature5") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Deductible</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblDeduct5" runat="server" Text='<%# Eval("Deductible_5") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Limit</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblLimit5" runat="server" Text='<%# Eval("Limit_5") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Specific Feature</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblPolFeature6" runat="server" Text='<%# Eval("PolFeature6") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                Deductible</td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:Label ID="lblDeduct6" runat="server" Text='<%# Eval("Deductible_6") %>'></asp:Label>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Limit
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:Label ID="lblLimit6" runat="server" Text='<%# Eval("Limit_6") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" align="center">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                    OnClick="btnSave_Click" Enabled="false" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <InsertItemTemplate>
                                    <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                        text-align: left;">
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                    font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                    <tr>
                                                        <td class="ghc">
                                                            Policy Coverage
                                                            <asp:Label ID="lblPolicyCovDetailsId" runat="server" Height="0px" Width="0px" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblPolicyNo" runat="server" Text="Policy"></asp:Label><span class="mf">*</span></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlPolicy" runat="Server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvPolicy" InitialValue="0" ControlToValidate="ddlPolicy"
                                                    runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Policy."
                                                    Display="None">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Policy Coverage Description<span class="mf">*</span></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:TextBox ID="txtPolCovDesc" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvPolDesc" InitialValue="" ControlToValidate="txtPolCovDesc"
                                                    runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Policy Coverage Description."
                                                    Display="None">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Policy Limits and Deductibles
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblPolicyDeductible" Text="Policy Deductible/Self Insured Retention Per Claim"
                                                    runat="Server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtPolicyDeductible" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblPolicyLimitOccurence" runat="server" Text="Policy Limit Each Occurrence"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtPolLimit" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblPolicyLimitGenAggregate" Text="Policy Limit General Aggregate"
                                                    runat="Server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtPolLimitGen" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;
                                            </td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            General Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblRentedPremiseDamageLimit" runat="Server" Text="Rented Premises Damage Limit"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtGLRentDamage" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblMedicalExpLimit" Text="Medical Expense Limit" runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtGLMedical" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblProdOperationsLimit" Text="Products and Completed Operations Limit"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtGLProducts" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;
                                            </td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Auto Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblPersonalInjuryProtectionLimot" Text="Personal Injury Protection Limit"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtALPIP" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblMedicalPayLimit" Text="Medical Payment Limit" runat="Server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtALMedical" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblUninsuredMotoristCoverage" Text="Uninsured Motorist Coverage" runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:RadioButtonList runat="server" ID="rblUnisuredMotoristCoverage">
                                                    <asp:ListItem Text="Yes" Value="Y">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblUnderInsuredMotoristCoverage" Text="Underinsured Motorist Coverage"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:RadioButtonList runat="server" ID="rblUnderInsuredMotoristCoverage">
                                                    <asp:ListItem Text="Yes" Value="Y">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Umbrella/Excess Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblUmbrellaLiabilityLimit" Text="Umbrella / Excess Liability Limit"
                                                    runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtUmbrellaLiabilityLimit" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;
                                            </td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Other Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblOtherLiabilityCoverageType" Text="Other Liability Coverage Type"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:TextBox ID="txtOtherLiabilityCoverageType" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;</td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Policy Features
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature1" Text="Specific Feature1" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature1" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible1" Text="Deductible1" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct1" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblLimit1" runat="server" Text="Limit1"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit1" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature2" Text="Specific Feature2" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature2" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible2" Text="Deductible2" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct2" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label Text="Limit2" runat="server" ID="lblLimit2"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit2" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature3" Text="Specific Feature3" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature3" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible3" Text="Deductible3" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct3" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblLimit3" runat="server" Text="Limit3"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit3" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature4" Text="Specific Feature4" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature4" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible4" Text="Deductible4" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct4" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblLimit4" Text="Limit4" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit4" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature5" Text="Specific Feature5" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature5" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible5" Text="Deductible5" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct5" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblLimit5" Text="Limit5" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit5" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature6" Text="Specific Feature6" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature6" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible6" Text="Deductible6" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct6" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblLimit6" Text="Limit6" runat="Server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit6" runat="server" onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
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
                                            <td align="left" colspan="6">
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
                                            <td colspan="6">
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
                                            <td colspan="6">
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
                                            <td colspan="6" align="center" class="ic">
                                                <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                    SkinID="btnGen" OnClientClick="javascript:ValAttach();" OnClick="btnAddAttachment_Click" />
                                                <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                    OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" />
                                                <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </InsertItemTemplate>
                                <EditItemTemplate>
                                    <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                        text-align: left;">
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                    font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                    <tr>
                                                        <td class="ghc">
                                                            Policy Coverage
                                                            <asp:Label ID="lblPolicyCovDetailsId" runat="server" Text='<%#Eval("PK_Policy_Coverage_Id")%>'
                                                                Height="0px" Width="0px" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblPolicyNo" runat="server" Text="Policy"></asp:Label><span class="mf">*</span></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlPolicy" runat="Server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvPolicy" InitialValue="0" ControlToValidate="ddlPolicy"
                                                    runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Policy."
                                                    Display="None">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                Policy Coverage Description<span class="mf">*</span></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:TextBox ID="txtPolCovDesc" runat="server" Text='<%# Eval("Policy_Coverage") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvPolDesc" InitialValue="" ControlToValidate="txtPolCovDesc"
                                                    runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Policy Coverage Description."
                                                    Display="None">
                                                </asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Policy Limits and Deductibles
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblPolicyDeductible" Text="Policy Deductible/Self Insured Retention Per Claim"
                                                    runat="Server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtPolicyDeductible" runat="server" Text='<%# Eval("Policy_Deductible") %>'
                                                    onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblPolicyLimitOccurence" runat="server" Text="Policy Limit Each Occurrence"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtPolLimit" runat="server" Text='<%# Eval("Occurrence_Limit") %>'
                                                    onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblPolicyLimitGenAggregate" Text="Policy Limit General Aggregate"
                                                    runat="Server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtPolLimitGen" runat="server" Text='<%# Eval("Aggregate_Limit") %>'
                                                    onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;
                                            </td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            General Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblRentedPremiseDamageLimit" runat="Server" Text="Rented Premises Damage Limit"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtGLRentDamage" runat="server" Text='<%# Eval("GL_Rent_Damage") %>'
                                                    onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblMedicalExpLimit" Text="Medical Expense Limit" runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtGLMedical" runat="server" Text='<%# Eval("GL_Medical") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblProdOperationsLimit" Text="Products and Completed Operations Limit"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtGLProducts" runat="server" Text='<%# Eval("GL_Products") %>'
                                                    onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;
                                            </td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Auto Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblPersonalInjuryProtectionLimit" Text="Personal Injury Protection Limit"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtALPIP" runat="server" Text='<%# Eval("AL_PIP") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblMedicalPayLimit" Text="Medical Payment Limit" runat="Server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtALMedical" runat="server" Text='<%# Eval("AL_Medical") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblUninsuredMotoristCoverage" Text="Uninsured Motorist Coverage" runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:RadioButtonList runat="server" ID="rblUnisuredMotoristCoverage">
                                                    <asp:ListItem Text="Yes" Value="Y">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblUnderInsuredMotoristCoverage" Text="Underinsured Motorist Coverage"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:RadioButtonList runat="server" ID="rblUnderInsuredMotoristCoverage">
                                                    <asp:ListItem Text="Yes" Value="Y">
                                                    </asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Umbrella/Excess Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblUmbrellaLiabilityLimit" Text="Umbrella / Excess Liability Limit"
                                                    runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtUmbrellaLiabilityLimit" runat="server" Text='<%# Eval("Umbrella") %>'
                                                    onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;
                                            </td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Other Liability
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblOtherLiabilityCoverageType" Text="Other Liability Coverage Type"
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:TextBox ID="txtOtherLiabilityCoverageType" runat="server" Text='<%# Eval("Other_Policy_Type") %>'></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                &nbsp;</td>
                                            <td class="lc">
                                                &nbsp;</td>
                                            <td class="ic" style="width: 25%">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <table cellspacing="1" style="background-color: #7f7f7f; color: White; font-weight: Bolder;
                                                    font-family: Tahoma; font-size: 10pt; text-align: left;" width="100%">
                                                    <tr>
                                                        <td class="ghc">
                                                            Policy Features
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature1" Text="Specific Feature1" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature1" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible1" Text="Deductible1" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct1" runat="server" Text='<%# Eval("Deductible_1") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblLimit1" runat="server" Text="Limit1"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit1" runat="server" Text='<%# Eval("Limit_1") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature2" Text="Specific Feature2" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature2" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible2" Text="Deductible2" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct2" runat="server" Text='<%# Eval("Deductible_2") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label Text="Limit2" runat="server" ID="lblLimit2"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit2" runat="server" Text='<%# Eval("Limit_2") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature3" Text="Specific Feature3" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature3" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible3" Text="Deductible3" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct3" runat="server" Text='<%# Eval("Deductible_3") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblLimit3" runat="server" Text="Limit3"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit3" runat="server" Text='<%# Eval("Limit_3") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature4" Text="Specific Feature4" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature4" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible4" Text="Deductible4" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct4" runat="server" Text='<%# Eval("Deductible_4") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblLimit4" Text="Limit4" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit4" runat="server" Text='<%# Eval("Limit_4") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature5" Text="Specific Feature5" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature5" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible5" Text="Deductible5" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct5" runat="server" Text='<%# Eval("Deductible_5") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblLimit5" Text="Limit5" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit5" runat="server" Text='<%# Eval("Limit_5") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblSpecificFeature6" Text="Specific Feature6" runat="server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                <asp:DropDownList ID="ddlSpecificFeature6" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblDeductible6" Text="Deductible6" runat="Server"></asp:Label></td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtDeduct6" runat="server" Text='<%# Eval("Deductible_6") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                            <td class="lc" style="width: 25%">
                                                <asp:Label ID="lblLimit6" Text="Limit6" runat="Server"></asp:Label>
                                            </td>
                                            <td class="lc">
                                                :</td>
                                            <td class="ic" style="width: 25%">
                                                $<asp:TextBox ID="txtLimit6" runat="server" Text='<%# Eval("Limit_6") %>' onKeyPress="return(currencyFormat(this,',','.',event))"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
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
                                            <td align="left" colspan="6">
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
                                            <td colspan="6">
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
                                            <td colspan="6">
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
                                            <td colspan="6" align="center" class="ic">
                                                <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                    SkinID="btnGen" OnClientClick="javascript:ValAttach();" OnClick="btnAddAttachment_Click" />
                                                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                    OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </EditItemTemplate>
                            </asp:FormView>
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
                            <tr>
                                <td>
                                    <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                                    <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','PolicyCoverage');" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
