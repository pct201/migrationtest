<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditFocusArea.aspx.cs" Inherits="SONIC_SLTSafetyWalk_EditFocusArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Edit Focus Area</title>
     <script language="javascript" type="text/javascript">
         function ClosePopup() {
             parent.parent.AskfForLogoff = false;
             parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_btnhdnReload').click();
             parent.parent.GB_hide();
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="3" cellspacing="1" border="0">
                        <tr>
                            <td style="width: 22%">Focus Area
                            </td>
                            <td style="width: 4%">:
                            </td>
                            <td style="width: 28%">
                                <asp:TextBox ID="txtFocusArea" runat="server" Width="145px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="Spacer" style="height: 10px;"></td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
