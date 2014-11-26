<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Provider.aspx.cs" Inherits="AIG_Provider" Title="Provider" %>
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
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_rfvAttachType").enabled =true;
            document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_rfvUpload").enabled =true;
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_txtFax").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_txtFax").value="";
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_txtTeleNo").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_txtTeleNo").value="";
            
            return true;
        }
        function ValSave()
        {
            
            document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_rfvAttachType").enabled =false;
            document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_rfvUpload").enabled =false;
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_txtFax").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_txtFax").value="";
            if(document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_txtTeleNo").value=="___-___-____")
                document.getElementById("ctl00_ContentPlaceHolder1_fvProvider_txtTeleNo").value="";
            return true;
        }
        
        
    </script>

    <asp:ScriptManager ID="smProvider" EnablePageMethods="true" runat="server">
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
                                                <asp:ListItem Value="Name">Name</asp:ListItem>
                                                <asp:ListItem Value="Tax_Id">Tax Id</asp:ListItem>
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
                                <asp:Label ID="lblProviderTotal" runat="server"></asp:Label>
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
                <asp:MultiView ID="mvProvider" runat="server">
                    <asp:View ID="vwProviderList" runat="server">
                        <table width="100%">
                            <tr>
                                <td>
                                    <table width="100%" style="text-align: right;">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" ToolTip="Click here to delete Provider Details"
                                                    OnClick="btnDelete_Click" />
                                                <asp:Button ID="btnAddNew" runat="server" Text="Add New" ToolTip="Add new Provider Details"
                                                    OnClick="btnAddNew_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvProvider" runat="server" AutoGenerateColumns="false" DataKeyNames="PK_Provider_ID"
                                                    Width="100%" AllowPaging="True" AllowSorting="True" OnRowCommand="gvProvider_RowCommand"
                                                    OnSorting="gvProvider_Sorting">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <input name="chkItem" type="checkbox" value='<%# Eval("PK_Provider_ID")%>' onclick="javascript:UnCheckHeader('gvProvider')" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="10px" />
                                                            <HeaderTemplate>
                                                                <input id="chkHeader" name="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                            </HeaderTemplate>
                                                            <HeaderStyle Width="10px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Tax_Id" HeaderText="Tax Id" SortExpression="Tax_Id">
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City">
                                                        </asp:BoundField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Provider_ID")%>'
                                                                    runat="server" Text="Edit" ToolTip="Edit the Provider Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Provider_ID")%>'
                                                                    ToolTip="View the Provider Details" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataRowStyle ForeColor="#7f7f7f" HorizontalAlign="Center" />
                                                    <EmptyDataTemplate>
                                                        Currently There Is No Provider.
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
                    <asp:View ID="vwProvider" runat="server">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:FormView ID="fvProvider" runat="server" Width="100%" OnDataBound="fvProvider_DataBound">
                                        <ItemTemplate>
                                            <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                text-align: left;">
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                            font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                            <tr>
                                                                <td class="ghc">
                                                                    Provider 
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
                                                                    Provider Name
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; height: 26px;" class="ic">
                                                                    <asp:Label ID="lblProviderName" runat="server" Text='<%#Eval("Name") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Address(1)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblAddress1" runat="server" Text='<%#Eval("Address_1") %>'></asp:Label>
                                                                    <asp:Label ID="lblProviderId" runat="server" Text='<%#Eval("PK_Provider_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    City
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>'></asp:Label></td>
                                                            </tr>
                                                           
                                                            <tr>
                                                                <td class="lc">
                                                                    Zip Code
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:Label ID="lblZip" runat="server" Text='<%#Eval("Zip_Code") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Facsimile
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:Label ID="lblFax" runat="server" Text='<%#Eval("Facsimile") %>'></asp:Label></td>
                                                            </tr>
                                                            
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%" style="text-align: left;">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Provider Tax Id
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblTaxId" runat="server" Text='<%#Eval("Tax_Id") %>'></asp:Label></td>
                                                            </tr>
                                                                                          <tr>
                                                                <td class="lc">
                                                                    Address(2)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblAddress2" runat="server" Text='<%#Eval("Address_2") %>'></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    State
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblState" runat="server" Text='<%#Eval("State") %>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="lc">
                                                                    Telephone Number
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:Label ID="lblTeleNo" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
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
                                                                    Provider
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    Provider Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; " class="ic">
                                                                    <asp:TextBox ID="txtProviderName" runat="server" MaxLength="50"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvProviderName" ControlToValidate="txtProviderName"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Provider Name."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:Label ID="lblProviderId" runat="server" Text='<%#Eval("PK_Provider_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="lc">
                                                                    Address(1)<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtAddress1" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAddress1" ControlToValidate="txtAddress1" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Address(1)."
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
                                                                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
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
                                                                    <asp:TextBox ID="txtZip" runat="server" MaxLength="5" onkeypress="return numberOnly(event);"></asp:TextBox>
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
                                                                    Facsimile (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:TextBox ID="txtFax" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskPhone" runat="server" TargetControlID="txtFax"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revFax" ControlToValidate="txtFax" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Facsimile in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                           
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Provider Tax Id<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtProviderTaxId" runat="server" onkeypress="return numberOnly(event);"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtProviderTaxId" ControlToValidate="txtProviderTaxId" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Provider Tax Id."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Address(2)<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAddress2" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAddress2" ControlToValidate="txtAddress2" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Address(2)."
                                                                        Display="none"></asp:RequiredFieldValidator>
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
                                                                    <asp:DropDownList ID="ddlState" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the State."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Telephone(xxx-xxx-xxxx)<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:TextBox ID="txtTeleNo" runat="server" MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RequiredFieldValidator ID="rfvHomePhone" ControlToValidate="txtTeleNo" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Telephone."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
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
                                                    <td colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 24.3%">
                                                                    Select File to Attach
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
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="btnAddAttachment" runat="server" Text="Add Attachment" ValidationGroup="vsErrorGroup"
                                                            SkinID="btnGen" OnClick="btnAddAttachment_Click" OnClientClick="javascript:ValAttach();" />
                                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                            OnClick="btnSave_Click" OnClientClick="javascript:ValSave();" />
                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
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
                                                                    Provider
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%; height: 26px;" class="lc">
                                                                    Provider Name<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%; " class="ic">
                                                                    <asp:TextBox ID="txtProviderName" runat="server" MaxLength="50" Text='<%#Eval("Name") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvProviderName" ControlToValidate="txtProviderName"
                                                                        runat="server" InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Provider Name."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:Label ID="lblProviderId" runat="server" Text='<%#Eval("PK_Provider_ID")%>'
                                                                        Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="lc">
                                                                    Address(1)<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td class="ic">
                                                                    <asp:TextBox ID="txtAddress1" runat="server" Text='<%#Eval("Address_1") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAddress1" ControlToValidate="txtAddress1" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Address(1)."
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
                                                                    <asp:TextBox ID="txtCity" runat="server" Text='<%#Eval("City") %>'></asp:TextBox>
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
                                                                    <asp:TextBox ID="txtZip" runat="server" Text='<%#Eval("Zip_Code") %>' MaxLength="5" onkeypress="return numberOnly(event);"></asp:TextBox>
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
                                                                    Facsimile (xxx-xxx-xxxx)
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:TextBox ID="txtFax" runat="server" MaxLength="12" Text='<%#Eval("Facsimile") %>' onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="mskPhone" runat="server" TargetControlID="txtFax"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RegularExpressionValidator ID="revFax" ControlToValidate="txtFax" runat="server"
                                                                        ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Facsimile in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                           
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Provider Tax Id<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtProviderTaxId" runat="server" onkeypress="return numberOnly(event);" Text='<%#Eval("Tax_Id") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtProviderTaxId" ControlToValidate="txtProviderTaxId" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Provider Tax Id."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td style="width: 50%;" class="lc">
                                                                    Address(2)<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="width: 50%;" class="ic">
                                                                    <asp:TextBox ID="txtAddress2" runat="server" Text='<%#Eval("Address_2") %>'></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvAddress2" ControlToValidate="txtAddress2" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Address(2)."
                                                                        Display="none"></asp:RequiredFieldValidator>
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
                                                                    <asp:DropDownList ID="ddlState" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" runat="server"
                                                                        InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select the State."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 21px" class="lc">
                                                                    Telephone(xxx-xxx-xxxx)<span class="mf">*</span>
                                                                </td>
                                                                <td align="Center" class="lc">
                                                                    :
                                                                </td>
                                                                <td style="height: 21px" class="ic">
                                                                    <asp:TextBox ID="txtTeleNo" runat="server" Text='<%#Eval("Phone") %>' MaxLength="12" onkeypress="return noPhoneFax(event);"></asp:TextBox>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTeleNo"
                                                                        Mask="999-999-9999" MaskType="Number" AutoComplete="False" ClearMaskOnLostFocus="false">
                                                                    </cc1:MaskedEditExtender>
                                                                    <asp:RequiredFieldValidator ID="rfvHomePhone" ControlToValidate="txtTeleNo" runat="server"
                                                                        InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Telephone."
                                                                        Display="none"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTeleNo"
                                                                        runat="server" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Telephone in xxx-xxx-xxxx format."
                                                                        Display="none" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$"></asp:RegularExpressionValidator>
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
                                                    <td colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="lc" style="width: 24.3%">
                                                                    Select File to Attach
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
                                                    <td colspan="2" align="center">
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
                                        <asp:BoundField DataField="Attachment_Type" HeaderText="Attachment Type" SortExpression="Attachment_Type">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Attachment_Description" HeaderText="Attachment Description"
                                            SortExpression="Attachment_Description"></asp:BoundField>
                                        <asp:BoundField DataField="Attachment_Name1" HeaderText="File Name" SortExpression="Attachment_Name1">
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
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" />
                                <asp:Button ID="btnMail" runat="server" Text="Mail" OnClientClick="javascript:return OpenWMail('gvAttachmentDetails','Provider');" />
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


