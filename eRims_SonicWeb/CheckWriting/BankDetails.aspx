<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="BankDetails.aspx.cs"
    Inherits="BankDetails" Theme="Default"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <script type="text/javascript">
        
    </script>

    <asp:ScriptManager ID="smBankDetail" EnablePageMethods="true" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="pnlBankDetail" runat="server">
        <ContentTemplate>
            <asp:ValidationSummary ID="vsError" runat="server" CssClass="errormessage" ValidationGroup="vsErrorGroup"
                BorderColor="DimGray" BorderWidth="1" HeaderText="Verify the following fields:"
                ShowMessageBox="true" ShowSummary="false"></asp:ValidationSummary>
            <asp:CustomValidator ID="cvErrorMsg" runat="server" ValidationGroup="vsErrorGroup"
                Display="None" EnableClientScript="false" ErrorMessage=""></asp:CustomValidator>
            <table width="100%">
                
                    <tr>
                        <td>
                            <div id="dvSearch" runat="server">
                                <table width="100%">
                                    <tbody>
                                        <tr>
                                            <td style="width: 50%">
                                                &nbsp;
                                            </td>
                                            <td style="width: 50%" align="right">
                                                <table width="80%">
                                                    <tbody>
                                                        <tr>
                                                            <td class="lc">
                                                                Search
                                                            </td>
                                                            <td class="ic">
                                                                <asp:DropDownList ID="ddlSearch" runat="server" SkinID="dropGen">
                                                                    <asp:ListItem Value="Fld_Bank_Name">Bank Name</asp:ListItem>
                                                                    <asp:ListItem Value="Fld_RoutingNo">Routing No</asp:ListItem>
                                                                    <asp:ListItem Value="Fld_AccountNo">Account No</asp:ListItem>
                                                                </asp:DropDownList></td>
                                                            <td class="ic">
                                                                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" Text="Search"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%" class="lc" align="left">
                                                <asp:Label ID="lblBankDetailsTotal" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 80%" align="right">
                                                <table width="100%">
                                                    <tbody>
                                                        <tr>
                                                            <td class="lc">
                                                                No. of Records per page :
                                                                <asp:DropDownList ID="ddlPage" runat="server" SkinID="dropGen" DataSourceID="xdsPaging"
                                                                    OnSelectedIndexChanged="ddlPage_SelectedIndexChanged" AutoPostBack="True" DataValueField="Value"
                                                                    DataTextField="Text">
                                                                </asp:DropDownList>
                                                                <asp:XmlDataSource ID="xdsPaging" runat="server" DataFile="~/App_Data/PagingTable.xml">
                                                                </asp:XmlDataSource>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnPrev" OnClick="btnPrev_Click" runat="server" SkinID="btnGen" Text=" < ">
                                                                </asp:Button>
                                                            </td>
                                                            <td class="lc">
                                                                <asp:Label ID="lblPageInfo" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnNext" OnClick="btnNext_Click" runat="server" SkinID="btnGen" Text=" > ">
                                                                </asp:Button>
                                                            </td>
                                                            <td class="lc">
                                                                Go to Page:</td>
                                                            <td class="ic">
                                                                <asp:TextBox ID="txtPageNo" onkeypress="return numberOnly(event);" runat="server"
                                                                    Width="20px" MaxLength="3"></asp:TextBox>
                                                            </td>
                                                            <td class="ic">
                                                                <asp:Button ID="btnGo" OnClick="btnGo_Click" runat="server" Text="Go"></asp:Button></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:MultiView ID="mvBankDetails" runat="server">
                                <asp:View ID="vwBankList" runat="server">
                                    <table width="100%">
                                        <tbody>
                                            <tr>
                                                <%--commented as not mentioned in new screen, by MR85 on 02/26/2007
                                <td class="tdtv">
                                    &nbsp;<!-- If Tree ? Then Place Here -->
                                </td>--%>
                                                <td>
                                                    <table style="text-align: right" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td class="ic">
                                                                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" runat="server" Text="Delete"
                                                                        ToolTip="Click here to delete Bank Details"></asp:Button>
                                                                    <asp:Button ID="btnAddNew" OnClick="btnAddNew_Click" runat="server" Text="Add New"
                                                                        ToolTip="Add new Bank Details"></asp:Button>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left">
                                                                    <asp:GridView ID="gvBankDetails" runat="server" Width="100%" OnRowCreated="gvBankDetails_RowCreated"
                                                                        OnSorting="gvBankDetails_Sorting" AllowSorting="True" AllowPaging="True" OnPageIndexChanging="gvBankDetails_PageIndexChanging"
                                                                        DataKeyNames="PK_Bank_Details_ID" OnRowCommand="gvBankDetails_RowCommand" AutoGenerateColumns="false"
                                                                        OnDataBound="gvBankDetails_DataBound" OnRowDataBound="gvBankDetails_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <input name="chkItem" type="checkbox" value='<%# Eval("PK_Bank_Details_ID")%>' onclick="javascript:UnCheckHeader('gvBankDetails')" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="10px" />
                                                                                <HeaderTemplate>
                                                                                    <input id="chkHeader" type="checkbox" runat="Server" onclick="javascript:SelectAllCheckboxes(this)" />
                                                                                </HeaderTemplate>
                                                                                <HeaderStyle Width="10px" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Fld_Bank_Name" HeaderText="Bank Name" SortExpression="Fld_Bank_Name">
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Fld_RoutingNo" HeaderText="Routing Number" SortExpression="Fld_RoutingNo">
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Fld_AccountNo" HeaderText="Account Number" SortExpression="Fld_AccountNo">
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="btnEdit" CommandName="EditItem" CommandArgument='<%#Eval("PK_Bank_Details_ID")%>'
                                                                                        runat="server" Text="Edit" ToolTip="Edit the Bank Details" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%#Eval("PK_Bank_Details_ID")%>'
                                                                                        ToolTip="View the Bank Details" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <PagerSettings Visible="False" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </asp:View>
                                <asp:View ID="vwBankDetails" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:FormView ID="fvBankDetails" runat="server" OnDataBound="fvBankDetails_DataBound"
                                                    Width="100%">
                                                    <ItemTemplate>
                                                        <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
                                                            text-align: left;">
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                        font-weight: Bolder; font-family: Tahoma; font-size: 10pt; text-align: left;">
                                                                        <tr>
                                                                            <td class="ghc">
                                                                                Bank Details
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
                                                                                Bank Name
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:Label ID="lblBankName" runat="server" Text='<%#Eval("Fld_Bank_Name") %>'></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 50%;" class="lc">
                                                                                Address1
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:Label ID="lblAddress1" runat="server" Text='<%#Eval("Fld_Address_1") %>'></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                State
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td class="ic">
                                                                                <asp:Label ID="lblState" runat="server" Text='<%#Eval("Fld_State") %>'></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Bank State
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td class="ic">
                                                                                <asp:Label ID="lblBankState" runat="server" Text='<%#Eval("Fld_Bank_State") %>'></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 21px" class="lc">
                                                                                Bank Number1
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%; height: 21px;" class="ic">
                                                                                <asp:Label ID="lblBankNo1" runat="server" Text='<%#Eval("Fld_Bank_No1") %>'></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Routing Number
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:Label ID="lblRoutingNo" runat="server" Text='<%#Eval("Fld_RoutingNo") %>'></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="100%" style="text-align: left;">
                                                                        <tr>
                                                                            <td style="height: 21px" class="lc">
                                                                                Account Number
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="" class="ic">
                                                                                <asp:Label ID="lblAccNo" runat="server" Text='<%#Eval("Fld_AccountNo") %>'></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Address2
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td class="ic">
                                                                                <asp:Label ID="txtAddress2" runat="server" Text='<%#Eval("Fld_Address_2") %>'></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                City
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:Label ID="lblCity" runat="server" Text='<%#Eval("Fld_City") %>'></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Zip
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:Label ID="lblZip" runat="server" Text='<%#Eval("Fld_Zip") %>'></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Bank Number2
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td class="ic">
                                                                                <asp:Label ID="lblBankNo2" runat="server" Text='<%#Eval("Fld_Bank_No2") %>'></asp:Label></td>
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
                                                                <td colspan="2">
                                                                    <table cellspacing="1" width="100%" style="background-color: #7f7f7f; color: White;
                                                                        font-weight: Bolder; font-family: Verdana; font-size: 10pt;">
                                                                        <tr>
                                                                            <td class="ghc">
                                                                                Bank Details
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="width: 50%;" class="lc">
                                                                                Bank Name<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:TextBox ID="txtBankName" runat="server" MaxLength="50" TabIndex="1"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvBankName" ControlToValidate="txtBankName" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Bank Name."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 50%;" class="lc">
                                                                                Address1<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:TextBox ID="txtAddress1" runat="server" MaxLength="50" TabIndex="3"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvAddress1" ControlToValidate="txtAddress1" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Bank Address1."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
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
                                                                                <asp:DropDownList ID="ddlState" runat="server" TabIndex="5">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" runat="server"
                                                                                    InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select State."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Bank State<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td class="ic">
                                                                                <asp:DropDownList ID="ddlBankState" runat="server" TabIndex="7">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvBankState" ControlToValidate="ddlBankState" runat="server"
                                                                                    InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select Bank State."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 21px" class="lc">
                                                                                Bank Number1<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:TextBox ID="txtBankNo1" runat="server" MaxLength="50" TabIndex="9"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvBankNo1" ControlToValidate="txtBankNo1" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Bank Number1."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Routing Number<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:TextBox ID="txtRoutingNo" runat="server" MaxLength="10" TabIndex="11"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvRoutingNo" ControlToValidate="txtRoutingNo" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Routing Number."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="height: 21px" class="lc">
                                                                                Account Number<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="height: 21px" class="ic">
                                                                                <asp:TextBox ID="txtAccountNo" runat="server" MaxLength="50" TabIndex="2"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvAccountNo" ControlToValidate="txtAccountNo" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Account Number."
                                                                                    Display="none"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Address2
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td class="ic">
                                                                                <asp:TextBox ID="txtAddress2" runat="server" MaxLength="50" TabIndex="4"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvAddress2" ControlToValidate="txtAddress2" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Address2."
                                                                                    Display="none"></asp:RequiredFieldValidator>--%>
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
                                                                                <asp:TextBox ID="txtCity" runat="server" MaxLength="50" TabIndex="6"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="txtCity" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter City."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Zip<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:TextBox ID="txtZip" runat="server" MaxLength="5" TabIndex="8" onkeypress="return numberOnly(event);"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvZip" ControlToValidate="txtZip" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Zip."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip"
                                                                                    ValidationExpression="^\d{5}$" ErrorMessage="Please Enter 5 Digits For Zip."
                                                                                    ValidationGroup="vsErrorGroup" Display="Dynamic" Text="*"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Bank Number2<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td class="ic">
                                                                                <asp:TextBox ID="txtBankNo2" runat="server" MaxLength="50" TabIndex="10"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvBankNo2" ControlToValidate="txtBankNo2" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Bank Number2."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 50%" class="ic">
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                                        OnClick="btnSave_Click" TabIndex="12" /></td>
                                                                <td align="left" style="width: 50%" class="ic">
                                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" TabIndex="13" />
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
                                                                        font-weight: Bolder; font-family: Verdana; font-size: 10pt;">
                                                                        <tr>
                                                                            <td class="ghc">
                                                                                Bank Details
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
                                                                                Bank Name<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%; height: 26px;" class="ic">
                                                                                <asp:TextBox ID="txtBankName" runat="server" MaxLength="50" Text='<%#Eval("Fld_Bank_Name") %>' TabIndex="1"></asp:TextBox>
                                                                                <asp:Label ID="lblBankDetailsId" runat="server" Text='<%#Eval("PK_Bank_Details_ID")%>'
                                                                                    Height="0px" Width="0px" Visible="false"></asp:Label>
                                                                                <asp:RequiredFieldValidator ID="rfvBankName" ControlToValidate="txtBankName" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Bank Name."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 50%;" class="lc">
                                                                                Address1<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:TextBox ID="txtAddress1" runat="server" TabIndex="3"  MaxLength="50" Text='<%#Eval("Fld_Address_1") %>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvAddress1" ControlToValidate="txtAddress1" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Bank Address1."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
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
                                                                                <asp:RequiredFieldValidator ID="rfvState" ControlToValidate="ddlState" TabIndex="5" runat="server"
                                                                                    InitialValue="0" ValidationGroup="vsErrorGroup" ErrorMessage="Please Select State."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Bank State<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td class="ic">
                                                                                <asp:DropDownList ID="ddlBankState" runat="server" TabIndex="7">
                                                                                </asp:DropDownList></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 21px" class="lc">
                                                                                Bank Number1<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%; height: 21px;" class="ic">
                                                                                <asp:TextBox ID="txtBankNo1" runat="server" MaxLength="50" Text='<%#Eval("Fld_Bank_No1") %>' TabIndex="9"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvBankNo1" ControlToValidate="txtBankNo1" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Bank Number1."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Routing Number<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:TextBox ID="txtRoutingNo" runat="server" MaxLength="10" TabIndex="11" Text='<%#Eval("Fld_RoutingNo") %>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvRoutingNo" ControlToValidate="txtRoutingNo" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Routing Number."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td style="height: 21px" class="lc">
                                                                                Account Number<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="height: 21px" class="ic">
                                                                                <asp:TextBox ID="txtAccountNo" runat="server" MaxLength="50" TabIndex="2" Text='<%#Eval("Fld_AccountNo") %>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvAccountNo" ControlToValidate="txtAccountNo" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Account Number."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Address2
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td class="ic">
                                                                                <asp:TextBox ID="txtAddress2" TabIndex="4" runat="server" MaxLength="50" Text='<%#Eval("Fld_Address_2") %>'></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvAddress2" ControlToValidate="txtAddress2" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter the Address2."
                                                                                    Display="none"></asp:RequiredFieldValidator>--%>
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
                                                                                <asp:TextBox ID="txtCity"  TabIndex="6" runat="server" MaxLength="50" Text='<%#Eval("Fld_City") %>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="txtCity" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter City."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Zip<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 50%;" class="ic">
                                                                                <asp:TextBox ID="txtZip" runat="server" TabIndex="8" Text='<%#Eval("Fld_Zip") %>' MaxLength="5"
                                                                                    onkeypress="return numberOnly(event);"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvZip" ControlToValidate="txtZip" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Zip."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZip"
                                                                                    ValidationExpression="^\d{5}$" ErrorMessage="Please Enter 5 Digits For Zip."
                                                                                    ValidationGroup="vsErrorGroup" Display="none"></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="lc">
                                                                                Bank Number2<span class="mf">*</span>
                                                                            </td>
                                                                            <td align="Center" class="lc">
                                                                                :
                                                                            </td>
                                                                            <td class="ic">
                                                                                <asp:TextBox ID="txtBankNo2" runat="server" TabIndex="10" MaxLength="50" Text='<%#Eval("Fld_Bank_No2") %>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvBankNo2" ControlToValidate="txtBankNo2" runat="server"
                                                                                    InitialValue="" ValidationGroup="vsErrorGroup" ErrorMessage="Please Enter Bank Number2."
                                                                                    Display="none" Text="*"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" style="width: 50%" class="ic">
                                                                    <asp:Button ID="btnSave" runat="server" TabIndex="12" Text="Save" ValidationGroup="vsErrorGroup"
                                                                        OnClick="btnSave_Click" /></td>
                                                                <td align="left" style="width: 50%" class="ic">
                                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" TabIndex="13" OnClick="btnCancel_Click" /></td>
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
               
            </table>
           
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
