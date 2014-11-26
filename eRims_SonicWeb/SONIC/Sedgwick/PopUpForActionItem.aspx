<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUpForActionItem.aspx.cs"
	Inherits="SONIC_Sedgwick_PopUpForActionItem" %>

<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<script language="javascript" type="text/javascript">
		function SetValue(txtID) {
			document.getElementById("txtDescOfActionItem_txtNote").value = window.opener.document.getElementById(txtID).value;
		}

		function ClosePopup(txtID) {
			window.opener.document.getElementById(txtID).value = document.getElementById("txtDescOfActionItem_txtNote").value;
			window.close();
			return false;
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<div style="text-align: center; padding: 20px;">
		<table cellpadding="4" cellspacing="0" width="100%" border="0">
			<tr>
				<td align="left" valign="top">Action Item </td>
				<td align="center" valign="top">: </td>
				<td align="left">
					<uc:ctrlMultiLineTextBox runat="server" ID="txtDescOfActionItem" MaxLength="500" Width="575" ControlType="TextBox" />
				</td>
			</tr>
			<tr>
				<td colspan="3" align="center">
					<asp:Button ID="btnSave" runat="server" Text="Save" />&nbsp;
					<asp:Button ID="btnCancel" runat="server" OnClientClick="javascript:window.close();" Text="Cancel" />&nbsp; </td>
			</tr>
		</table>
	</div>
	</form>
</body>
</html>
