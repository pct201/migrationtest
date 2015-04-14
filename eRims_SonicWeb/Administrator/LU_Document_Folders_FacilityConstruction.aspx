<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="LU_Document_Folders_FacilityConstruction.aspx.cs" Inherits="Administrator_LU_Document_Folders_FacilityConstruction" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function AddNewGroup() {
            document.getElementById('<%=trStatusAdd.ClientID %>').style.display = "block";
            document.getElementById('<%=lnkCancel.ClientID %>').style.display = "inline";
        }

        function CheckValidation() {
            if (Page_ClientValidate("vsError")) {
            }
        }

        //Functions for Mover control - Contractot type
        function CheckListItemLocation() {
            var lstLocation = document.getElementById('<%=lstContractorType.ClientID %>');

            if (lstLocation.length <= 0) {
                alert('No record!');
                return false;
            }
            if (lstLocation.selectedIndex < 0) {
                alert('Please select at least one Contractor Type field(s)');
                return false;
            }
        }

        function CheckListItemSelected() {
            var lstSelected = document.getElementById('<%=lstAllowAccessCT.ClientID %>');
            if (lstSelected.length <= 0) {
                alert('No records');
                return false;
            }
            if (lstSelected.selectedIndex < 0) {
                alert('Please select at least one Contractor Type field(s)');
                return false;
            }
        }
        function CheckListItemSelectedAll() {
            var lstSelected = document.getElementById('<%=lstAllowAccessCT.ClientID %>');
            if (lstSelected.length <= 0)
            { alert('No records'); return false; }
        }

        function confirmDelete() {
            if (confirm("Are you sure you want to delete this record?") == true)
                return true;
            else
                return false;
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsError" CssClass="errormessage"></asp:ValidationSummary>
    </div>

    <div runat="Server" id="grid">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td colspan="4">&nbsp;
                </td>
            </tr>
            <tr>
                <td class="bandHeaderRow" align="left" colspan="4">Administrator :: Facility Construction Document Folder Maintenance
                </td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td style="width: 50%">&nbsp;
                </td>
                <td align="right" valign="top" colspan="3">
                    <asp:Button ID="lnkAddNew" runat="server" Text="Add" OnClick="lnkAddNew_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 5px"></td>
            </tr>
            <tr>
                <td style="width: 50%">&nbsp;Total Records :
                    <asp:Label ID="lblNumber" runat="server"></asp:Label>
                </td>

                <td align="right" valign="top" colspan="3">
                    <uc:ctrlPaging ID="ctrlPageProperty" runat="server" OnGetPage="GetPage" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 5px"></td>
            </tr>
            <tr>
                <td colspan="4">
                    <table cellpadding="0" cellspacing="0" border="0" style="text-align: right; width: 100%;">
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="height: 5px;"></td>
                        </tr>
                        <tr>
                            <td style="text-align: left;">
                                <asp:GridView ID="gvInspection_Area" runat="server" Width="100%" AutoGenerateColumns="false"
                                    EnableViewState="true" AllowPaging="true" OnRowCommand="gvInspection_Area_RowCommand"
                                    OnPageIndexChanging="gvInspection_Area_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Folder" HeaderStyle-HorizontalAlign="Left">
                                            <ItemStyle Width="65%" />
                                            <ItemTemplate>
                                                <%#Eval("Folder_Name")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Status">
                                                        <ItemStyle Width="25%" />
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblActive" Text='<%#(Eval("Active").ToString() == "Y" ? "Active" : "In Active") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="">
                                            <ItemStyle Width="11%" />
                                            <ItemTemplate>
                                                <asp:Button ID="lnkEdit" CommandName="EditRecord" CommandArgument='<%#Eval("PK_LU_FC_Document_Folder")%>'
                                                    runat="server" Text="Edit" ToolTip="Edit the Document Folder Details" />
                                                <asp:Button ID="btnDelete" CommandName="DeleteRecord" CommandArgument='<%#Eval("PK_LU_FC_Document_Folder")%>'
                                                    runat="server" Text="Delete" ToolTip="Delete the Document Folder Details" OnClientClick="return confirmDelete();" />
                                                <%--<asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="EditRecord"
                                                                CommandArgument='<%#Eval("PK_LU_FC_Document_Folder") %>'></asp:LinkButton>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <table cellpadding="4" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                                    <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>



    <div runat="server" id="trStatusAdd" style="display: none;">
        <table width="100%" cellpadding="3" cellspacing="1" border="0">
            <tr>
                <td class="bandHeaderRow" colspan="6" align="left">Administrator :: Facility Construction Document Folder Maintenance
                </td>
            </tr>
            <tr>
                <td style="width: 24%;" align="left">&nbsp;&nbsp;Folder Name<span style="color: Red;">*</span>
                </td>
                <td style="width: 5%;" align="center">&nbsp;&nbsp;:
                </td>
                <td align="left" width="70%" colspan="4">
                    <asp:TextBox ID="txtDescription" runat="server" Width="89%" MaxLength="25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ValidationGroup="vsError"
                        SetFocusOnError="true" ErrorMessage="Please Enter Folder Name" Display="none"
                        ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                </td>
                <%--<td align="left" width="15%">&nbsp;
                    </td>
                    <td align="center" width="4%">&nbsp;
                    </td>
                    <td width="36%">
                        
                    </td>--%>
            </tr>

            <tr>
                <td colspan="6">
                    <table width="100%" cellpadding="2" cellspacing="2">
                        <tr valign="top">
                            <td style="width: 25%">Contractor Types Allowed Access
                            </td>
                            <td style="width: 3%;" align="center">:
                            </td>
                            <td style="width: 72%">
                                <table width="100%">
                                    <tr>
                                        <td align="left" style="width: 250px">Available
                                                <asp:ListBox ID="lstContractorType" runat="server" Rows="10" SelectionMode="Multiple"
                                                    Width="250px"></asp:ListBox>
                                        </td>
                                        <td valign="middle" align="center" style="width: 125px">
                                            <table width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btnSelectFields" runat="server" Text=">" Width="50px" OnClick="btnSelectFields_Click"
                                                            Enabled="false" OnClientClick="javascript:return CheckListItemLocation();" ValidationGroup="vsErrorAvailFieldss" />
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btnSelectAllFields" runat="server" Text=">>" Width="50px" Enabled="false"
                                                            OnClick="btnSelectAllFields_Click" />
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btnDeselectFields" runat="server" Text="<" Width="50px" OnClick="btnDeselectFields_Click"
                                                            Enabled="false" OnClientClick="javascript:return CheckListItemSelected();" ValidationGroup="vsErrorSelectFieldss" />
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btnDeselectAllFields" runat="server" Text="<<" Width="50px" OnClientClick="javascript:return CheckListItemSelectedAll();"
                                                            Enabled="false" OnClick="btnDeselectAllFields_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="left">Selected<br />
                                            <asp:ListBox ID="lstAllowAccessCT" runat="server" Rows="10" SelectionMode="Multiple"
                                                Width="250px"></asp:ListBox>

                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top"></td>
                <td align="center" valign="top"></td>
                <td colspan="4" align="left" valign="top"></td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" ValidationGroup="vsError"
                        Text="Save" CausesValidation="false" OnClientClick="return CheckValidation();"></asp:Button>
                    &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="lnkCancel" OnClick="lnkCancel_Click" runat="server"
                                                Text="Cancel"></asp:Button>
                </td>
            </tr>



        </table>
    </div>




    <%--  <asp:UpdatePanel runat="server" ID="updStatus">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="bandHeaderRow" align="left" colspan="4">Administrator :: Facility Construction Document Folder Maintenance
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                    
                    <tr id="grid1" runat="server"> 
                        <td style="width: 5%">&nbsp;
                        </td>
                        <td align="center" colspan="2">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    
                                    <tr>
                                        <td style="width: 50%">&nbsp;
                                        </td>
                                        <td></td>
                                        <td align="right" valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 50%">
                                        </td>
                                        <td></td>
                                        <td align="right" valign="top">
                                            <uc:ctrlPaging ID="ctrlPageProperty" runat="server" OnGetPage="GetPage" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="3">
                                            
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 5%">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%">&nbsp;
                        </td>
                        <td colspan="2">
                            
                            <asp:LinkButton Style="display: inline" ID="lnkAddNew" OnClick="lnkAddNew_Click"
                                runat="server" Text="Add New"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                    Style="display: none" ID="lnkCancel" OnClick="lnkCancel_Click" runat="server"
                                    Text="Cancel"></asp:LinkButton></td>
                        <td style="width: 5%">&nbsp;
                        </td>
                    </tr>
                    <tr style="display: none" id="trStatusAdd" runat="server">
                        <td style="width: 5%">&nbsp;
                        </td>
                        <td colspan="2">
                            <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 25%" align="left">&nbsp;&nbsp;Folder Name<span class="mf">*</span>
                                        </td>
                                        <td style="width: 4%" align="center">:
                                        </td>
                                        <td align="left" colspan="4">
                                           


                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <table width="100%" cellpadding="2" cellspacing="2">
                                                <tr valign="top">
                                                    <td style="width: 25%">Contractor Types Allowed Access
                                                    </td>
                                                    <td style="width: 3%;" align="center">:
                                                    </td>
                                                    <td style="width: 72%">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left" style="width: 250px">Available
                                                <asp:ListBox ID="lstContractorType" runat="server" Rows="10" SelectionMode="Multiple"
                                                    Width="250px"></asp:ListBox>
                                                                </td>
                                                                <td valign="middle" align="center" style="width: 125px">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Button ID="btnSelectFields" runat="server" Text=">" Width="50px" OnClick="btnSelectFields_Click"
                                                                                    Enabled="false" OnClientClick="javascript:return CheckListItemLocation();" ValidationGroup="vsErrorAvailFieldss" />
                                                                                <br />
                                                                                <br />
                                                                                <asp:Button ID="btnSelectAllFields" runat="server" Text=">>" Width="50px" Enabled="false"
                                                                                    OnClick="btnSelectAllFields_Click" />
                                                                                <br />
                                                                                <br />
                                                                                <asp:Button ID="btnDeselectFields" runat="server" Text="<" Width="50px" OnClick="btnDeselectFields_Click"
                                                                                    Enabled="false" OnClientClick="javascript:return CheckListItemSelected();" ValidationGroup="vsErrorSelectFieldss" />
                                                                                <br />
                                                                                <br />
                                                                                <asp:Button ID="btnDeselectAllFields" runat="server" Text="<<" Width="50px" OnClientClick="javascript:return CheckListItemSelectedAll();"
                                                                                    Enabled="false" OnClick="btnDeselectAllFields_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td align="left">Selected<br />
                                                                    <asp:ListBox ID="lstAllowAccessCT" runat="server" Rows="10" SelectionMode="Multiple"
                                                                        Width="250px"></asp:ListBox>
                                                                   
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td align="center" colspan="6">
                                            <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>

                                       <td align="center" colspan="6">
                                            <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" ValidationGroup="vsError"
                                                Text="Save" CausesValidation="false" OnClientClick="return CheckValidation();"></asp:Button>
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="lnkCancel" OnClick="lnkCancel_Click" runat="server"
                                                Text="Cancel" ></asp:Button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="width: 5%">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
