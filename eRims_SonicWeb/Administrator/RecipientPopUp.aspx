<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecipientPopUp.aspx.cs" Inherits="Administrator_RecipientPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Risk Insurance Management System</title>
</head>
<body style="background-color: Transparent;">
    <form id="form1" runat="server">
    <script type="text/javascript">
        function selectRecord(arg) {
            var test = arg.split(",");
            if (window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignTo').value == "")
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignTo').value = test[0];
            else
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignTo').value = window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignTo').value + ',' + test[0];

            if (window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignToID').value == "")
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignToID').value = test[1];
            else
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignToID').value = window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignToID').value + ',' + test[1];
            self.close();
        }
        function clearRecipients() {
            if (window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignTo') != null)
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignTo').value = "";
            if (window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignToID').value != null)
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtIAssignToID').value = "";
        }
    </script>
    <div>
        <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;
            text-align: left;">
            <tr>
                <td class="ghc">
                    Recipient
                </td>
            </tr>
            <tr style="height: 30px;">
                <td class="ic" valign="middle">
                <div style="overflow-x: none; overflow-y: scroll; text-align: left; height: 400px;"
                                    id="dvSearchResult" runat="server">
                    <asp:GridView ID="dgUsers" runat="server" AutoGenerateColumns="false" OnRowDataBound="dgUsers_RowDataBound"
                        AllowSorting="true" Width="100%" OnSorting="dgUsers_Sorting" OnRowCreated="dgUsers_RowCreated">
                        <HeaderStyle Font-Bold="true" Font-Size="Medium" />
                        <Columns>
                            <asp:TemplateField HeaderText="" SortExpression="" Visible="false" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblPK_Recipient_ID" runat="server" CommandArgument='<% #Eval("PK_Recipient_ID") %>'
                                        Text='<% #Eval("PK_Recipient_ID") %>' CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Select">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" runat="server" Text="" Checked="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="First Name" SortExpression="FirstName" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnFirstName" runat="server" CommandArgument='<% #Eval("FirstName") %>'
                                        Text='<% #Eval("FirstName") %>' CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Midle Name" SortExpression="MidleName" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblMidleName" runat="server" CommandArgument='<% #Eval("MidleName") %>'
                                        Text='<% #Eval("MidleName") %>' CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name" SortExpression="LastName" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnLastName" runat="server" CommandArgument='<% #Eval("LastName") %>'
                                        Text='<% #Eval("LastName") %>' CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" SortExpression="Email" HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnEmail" runat="server" CommandArgument='<% #Eval("Email") %>'
                                        Text='<% #Eval("Email") %>' CssClass="acher"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Add Selected" 
                        onclick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
