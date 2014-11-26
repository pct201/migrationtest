<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="SLT_Meeting_Location.aspx.cs" Inherits="SONIC_SLT_SLT_Meeting_Location" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:ValidationSummary ID="valSummay" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    <table cellspacing="1" cellpadding="3" width="100%" border="0">
        <tr>
            <td align="left" valign="top" class="bandHeaderRow">
                SLT Meeting Location
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
         <tr> <td align="center"><img src ="../../Images/SLT_homepage_logo.jpg" alt="SLT_homepage" /> </td> </tr>
          <tr><td > <br /> </td></tr>
          <tr><td> <br /> </td></tr>
        <tr>
            <td align="center">
                <table cellspacing="1" cellpadding="3" width="50%" border="0">
                    <tbody>
                    <tr>
                            <td style="width: 14%" align="left">
                                SONIC Location Code
                            </td>
                            <td style="width: 4%" align="center">
                                :
                            </td>
                            <td style="width: 32%" align="left">
                                <asp:DropDownList ID="ddlRMLocationNumber" runat="server" AutoPostBack="false" Width="170px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvddlRMLocationNumber" runat="Server" ValidationGroup="vsErrorGroup"
                                    ErrorMessage="Please Select SONIC Location Code" SetFocusOnError="true"
                                    Display="none" ControlToValidate="ddlRMLocationNumber" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnnext_Click" CausesValidation="true" ValidationGroup="vsErrorGroup"/>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
