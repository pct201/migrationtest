<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Mandatory_Field_Management.aspx.cs" Inherits="Administrator_Mandatory_Field_Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" align="left" class="ghc">
                Mandatory Field Management
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="3" cellspacing="3" width="450px" align="center" border="0">
                    <tr>
                        <td width="30%" align="right">
                            Select Module &nbsp;
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpModules" runat="server" SkinID="Default" Width="250px" AutoPostBack="true"
                                OnSelectedIndexChanged="drpModules_SelectedIndexChanged">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Select Sub-Module &nbsp;
                        </td>
                        <td align="center">
                            : &nbsp;
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpSubModules" runat="server" SkinID="Default" Width="250px"
                                AutoPostBack="true" OnSelectedIndexChanged="drpSubModules_SelectedIndexChanged">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Select Screen &nbsp;
                        </td>
                        <td align="center">
                            : &nbsp;
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpScreen" runat="server" SkinID="Default" Width="250px" AutoPostBack="true"
                                OnSelectedIndexChanged="drpScreen_SelectedIndexChanged">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="100%" cellpadding="2" cellspacing="2">
                    <tr valign="top">
                        <td style="width: 20%">
                            &nbsp;
                        </td>
                        <td style="width: 80%">
                            <table width="100%" border="0">
                                <tr>
                                    <td align="center" style="width: 250px">
                                        <b>Non-Mandatory fields</b>
                                        <asp:ListBox ID="lstNonMandatory_fields" runat="server" Rows="15" SelectionMode="Multiple"
                                            Width="250px"></asp:ListBox>
                                    </td>
                                    <td valign="middle" align="center" style="width: 85px">
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
                                    <td align="left" style="width: 250px">
                                        <center>
                                            <b>Mandatory fields</b>
                                        </center>
                                        <asp:ListBox ID="lstMandatory_fields" runat="server" Rows="15" SelectionMode="Multiple" 
                                            Width="250px"></asp:ListBox>
                                        <input type="hidden" id="hdnNotNullFields" runat="server" />
                                    </td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" Text=" Save " OnClick="btnSave_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        //Functions for Mover control - FROI E-Mail Recipients
        function CheckListItemLocation() {
            var lstLocation = document.getElementById('<%=lstNonMandatory_fields.ClientID %>');

            if (lstLocation.length <= 0) {
                alert('No record!');
                return false;
                }
                if (lstLocation.selectedIndex < 0) {
                    alert('Please select at least one Non-Mandatory field(s)');
                    return false;
                }            
        }
        function CheckListItemSelected() {
            var lstSelected = document.getElementById('<%=lstMandatory_fields.ClientID %>');
            if (lstSelected.length <= 0) {
                alert('No records');
                return false;
            }
            if (lstSelected.selectedIndex < 0) {
                alert('Please select at least one Mandatory field(s)');
                return false;
            }
        }
        function CheckListItemSelectedAll() {
            var lstSelected = document.getElementById('<%=lstMandatory_fields.ClientID %>');
            if (lstSelected.length <= 0)
            { alert('No records'); return false; }
        }
        function CheckLocationField(source, arguments) {
            var lstSelected = document.getElementById('<%=lstMandatory_fields.ClientID %>');
            if (lstSelected.length <= 0) {
                arguments.IsValid = false;
                return arguments.IsValid;
            }
            else {
                arguments.IsValid = true;
                return arguments.IsValid;
            }
        }
    </script>
</asp:Content>