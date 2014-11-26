<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Admin_Search"
    Title="Risk Insurance Management System" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <script src="../JavaScript/Common.js" type="text/javascript"></script>

    <script type="text/javascript">
        function Go_Back_To_CallerForm(id) {
            id = document.getElementById('hdnID2').value;
            var url = window.opener.document.forms[0].action;
            var arrURL = url.split('id=');
           
            if (arrURL.length > 1) {
                var retval = arrURL[0];
                retval += 'id=' + id;
                var i;
                var arrID = arrURL[1].split('&');
                if (arrID.length > 0) {
                    for (i = 1; i < arrID.length; i++) {
                        retval += '&' + arrID[i];
                    }
                    window.opener.location.href = retval;
                    window.close();
                }
                else {
                    alert('error arrID: ' + arrURL[1]);
                    //window.close();
                }
            }
            else {
                if (url.indexOf("?") > 0)
                    window.opener.location.href = url + "&id=" + id + "&op=edit";
                else
                    window.opener.location.href = url + "?id=" + id + "&op=edit";
                window.close();
            }
            //window.close();                  
        }

        function Go_Back_To_CallerFormTopSearch(id) {
            var url = window.opener.document.forms[0].action;
            var arrURL = url.split('id=');
           
            if (arrURL.length > 1) {
                var retval = arrURL[0];
                retval += 'id=' + id;
                var i;
                var arrID = arrURL[1].split('&');
                if (arrID.length > 0) {
                    for (i = 1; i < arrID.length; i++) {
                        retval += '&' + arrID[i];
                    }
                    window.opener.location.href = retval;
                    window.close();
                }
                else {
                    alert('error arrID: ' + arrURL[1]);
                    //window.close();
                }
            }
            else {
                if (url.indexOf("?") > 0)
                    window.opener.location.href = url + "&id=" + id + "&op=edit";
                else
                    window.opener.location.href = url + "?id=" + id + "&op=edit";
                window.close();
            }
            //window.close();
        }
        
        function SetValue(strValue) {
            var txtID = document.getElementById('hdnID').value;

            if (txtID != '') {
                window.opener.document.getElementById(txtID).value = strValue;
                window.close();
            }
        }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="4" cellspacing="2" width="650px" align="center">
        <tr>
            <td colspan="3" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td width="45%" align="left" valign="top">
                <span class="heading">
                    <asp:Label ID="lblTitle" runat="server" Text="Find"></asp:Label></span>
            </td>
            <td align="left">
                <div id="dvName" runat="server" style="display: none;">
                    <table cellpadding="1" cellspacing="1" width="100%">
                        <tr>
                            <td width="25%" align="left">
                                Name
                            </td>
                            <td width="2%" align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="dvCompany" runat="server" style="display: none;">
                    <table cellpadding="1" cellspacing="1" width="100%">
                        <tr>
                            <td width="25%" align="left">
                                Company
                            </td>
                            <td width="2%" align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPolicyCompany" runat="server" MaxLength="254"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="dvPersonalInfo" runat="server" style="display: none;"> 
                    <table cellpadding="1" cellspacing="1" width="100%">
                        <tr id="trCompanyOrName" runat="server">
                            <td width="25%" align="left">
                                <asp:Label ID="lblCompanyOrName" runat="server" Text="Company"></asp:Label>
                            </td>
                            <td width="2%" align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCompanyOrName" runat="server" MaxLength="254"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" align="left">
                                Last Name
                            </td>
                            <td width="2%" align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtLastName" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" align="left">
                                First Name
                            </td>
                            <td width="2%" align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" align="left">
                                Address
                            </td>
                            <td width="2%" align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAddress" runat="server" MaxLength="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" align="left">
                                City
                            </td>
                            <td width="2%" align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCity" runat="server" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" align="left">
                                State
                            </td>
                            <td width="2%" align="center">
                                :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="drpState" runat="server" Width="156px" SkinID="Default" />
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" align="left" valign="top">
                                Zip Code
                            </td>
                            <td width="2%" align="center" valign="middle">
                                :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="txtZipCode" runat="server" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <td valign="bottom" align="left">
                <asp:Button ID="btnGo" runat="server" Text="Go" CssClass="pagingfields" OnClick="btnGo_Click" />
            </td>
        </tr>
        <tr>
            <td class="groupHeaderBar" colspan="3">
            </td>
        </tr>
    </table>
    <div id="tblGrid" runat="server" style="display: none;">
        <table width="650px" align="center">
            <tr>
                <td width="100%" class="Spacer" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td class="dvContainer" align="left">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="100%" align="left">
                                <div id="dvCurrentCOIMsg" runat="server">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%" class="Spacer" style="height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="heading">
                                                Records for current
                                                <asp:Label ID="lblTopRecordsFor" runat="server" Text="COI" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%" class="Spacer" style="height: 10px;">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="left" width="100%">
                                <asp:GridView ID="gvSearchTop"   runat="server" Width="100%" OnRowDataBound="gvSearchTop_RowDataBound"
                                    EnableViewState="true" AllowPaging="true" OnPageIndexChanging="gvSearchTop_PageIndexChanging"
                                    OnSorting="gvSearchTop_Sorting">
                                    <PagerSettings Mode="Numeric" PageButtonCount="10" Position="bottom" />
                                    <RowStyle HorizontalAlign="left" />
                                    <AlternatingRowStyle HorizontalAlign="left" />
                                    <EmptyDataTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No records found."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%">
                                <div id="tblBottom" runat="server" style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="100%" class="Spacer" style="height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="heading">
                                                Records for other
                                                <asp:Label ID="lblBottomRecordsFor" runat="server" Text="COIs"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="100%" class="Spacer" style="height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="left" width="100%">
                                                <asp:GridView ID="gvSearchBottom"   runat="server" Width="100%" OnRowDataBound="gvSearchBottom_RowDataBound"
                                                    OnRowCommand="gvSearchBottom_RowCommand" EnableViewState="true" AllowPaging="true"
                                                    OnPageIndexChanging="gvSearchBottom_PageIndexChanging" OnSorting="gvSearchBottom_Sorting">
                                                    <PagerSettings Mode="Numeric" PageButtonCount="10" Position="bottom" />
                                                    <RowStyle HorizontalAlign="left" />
                                                    <AlternatingRowStyle HorizontalAlign="left" />
                                                    <EmptyDataTemplate>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Label ID="lblMsg" runat="server" SkinID="Message" Text="No records found."></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="Spacer" style="height: 10px">
    </div>
    <input type="hidden" id="hdnID" runat="server" />
    <input type="hidden" id="hdnID2" runat="server" />
    </form>
</body>
</html>
