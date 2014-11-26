<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClaimNumberPopup.aspx.cs"
    Inherits="SONIC_ClaimInfo_ClaimNumberPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        function ClosePopup(EmpName) {
            //            parent.parent.document.getElementById('hdnEmpval').value = EmpId;
            //            parent.parent.document.getElementById('hdnEmpName').value = EmpName;
            //            parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_HdnEmployeeID').value = EmpId;
            parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtClaimNumber').value = EmpName;
            //            parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_btnAssName').click();
            parent.parent.GB_hide();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="1" cellspacing="1" border="0">
                        <tr>
                            <td style="width: 14%">
                                Sonic DBA
                            </td>
                            <td style="width: 2%">
                                :
                            </td>
                            <td style="width: 46%">
                                <asp:DropDownList ID="ddlSonicDBA" runat="server" Width="250px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 14%">
                                Claim Number
                            </td>
                            <td style="width: 2%">
                                :
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtClaimNumber" runat="server" Width="145px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
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
            <tr runat="server" id="trGrid" style="display: block;">
                <td align="center">
                    <asp:GridView ID="gvClaimNumber" runat="server" AutoGenerateColumns="false" Width="80%"
                        AllowSorting="false" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvClaimNumber_PageIndexChanging"
                        OnRowDataBound="gvClaimNumber_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Origin Claim Number">
                                <ItemStyle HorizontalAlign="left" Width="15%" />
                                <ItemTemplate>
                                    <a href="#" runat="server" id="ClaimNumber">
                                        <%#Eval("Origin_Claim_Number")%></a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location d/b/a ">
                                <ItemStyle HorizontalAlign="left" Width="20%" />
                                <ItemTemplate>
                                    <a href="#" runat="server" id="ClaimLocation">
                                        <%#Eval("dba")%></a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
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
                        <PagerSettings Mode="NumericFirstLast" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
