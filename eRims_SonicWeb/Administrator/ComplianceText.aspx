<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ComplianceText.aspx.cs"
    Inherits="Administration_ComplianceText" Title="Maintenance :: Compliance Text" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 5px;" class="heading" align="left">
                COI Compliance Text
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 20px;">
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="dvEdit" runat="server" style="display: none;">
                    <table cellpadding="3" cellspacing="2" width="48%">
                        <tr>
                            <td align="left" width="20%">
                                Compliance Text<span class="msg1">*</span>
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtComplianceText" runat="server" MaxLength="50"></asp:TextBox>
                                <asp:HiddenField ID="hdnPK" runat="server" Value="0" />
                                <asp:RequiredFieldValidator ID="rdq" runat="server" ErrorMessage="Please enter Compliance screen descriptor text"
                                    Display="None" ControlToValidate="txtComplianceText" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="15%">
                                Turn On
                            </td>
                            <td align="center" width="4%">
                                :
                            </td>
                            <td align="left">
                                <asp:RadioButton ID="rdoOn" runat="Server" Text="On" GroupName="ONOFF" />
                                <asp:RadioButton ID="rdoOff" runat="Server" Text="Off" GroupName="ONOFF" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="15%">
                            </td>
                            <td align="center" width="4%">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnSave" SkinID="Save" runat="server" OnClick="btnSave_Click" ValidationGroup="vsErrorGroup" />&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click"
                                    CausesValidation="false" />&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvCOICompliance" runat="server" Width="100%" OnRowCommand="gvCOICompliance_RowCommand"
                    OnRowDataBound="gvCOICompliance_RowDataBound" OnRowCreated="gvCOICompliance_RowCreated">
                    <Columns>
                        <asp:TemplateField HeaderText="Compliance Screen Descriptor Text">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="35%" HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <%#Eval("Compliance_Text")%>
                                <input type="hidden" id="hdnID" runat="server" value='<%#Eval("PK_Compliance")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Turned On">
                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblTurnedOn" runat="server" Text=''></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit ">
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="lnkEdit" runat="server" Text="Edit" CommandName="EditCOM" CommandArgument='<%#Eval("PK_Compliance")%>'
                                                CausesValidation="false" Width="50px" />&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblMsg" runat="server" Text="No records found" SkinID="Message"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
