<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignPopUp.aspx.cs" Inherits="Diary_AssignPopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Assign Claim</title>
    <script type="text/javascript" language="javascript">
    function IsMultipleChecked()
    {
    
        var isChecked;
        var mulCheck=0;
        for(i=0;i<document.forms[0].elements.length;i++)
        {
            if((document.forms[0].elements[i].type=='checkbox') && (document.forms[0].elements[i].name !="chkHeader"))
            {
                if(document.forms[0].elements[i].checked  == true)
                       {
                            isChecked= true;
                            mulCheck=mulCheck+1;
                       }
            }
        }   
	    if(!isChecked)
	    {
	        alert('Please select any record.');
	        return false;
	    }
	    if(mulCheck>1)
	    {
	        alert('No Multiple Selection Allowed.');
	        return false;
	    }
		    
    } 
    
        function Close(btn)
        {
            window.opener.document.getElementById(btn).click();
            self.close();
        }
    </script>
</head>
<body>
    <form id="assign" runat="server">
        <div style="display:none;">
        <asp:Label ID="lblScript" runat="server" ></asp:Label>
        </div>
        <div>
        
            <table width="100%">
                <tr>
                    <td>
                        <table width="100%" style="border: 1pt; border-color: #7f7f7f; border-style: solid;">
                            <tr>
                                <td colspan="3" class="ghc" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;"
                                    align="left">
                                    Assign Claim
                                </td>
                            </tr>
                            <tr>
                                <td class="lc" valign="top">
                                Notes
                                </td>
                                <td class="lc" valign="top">
                                    :
                                </td>
                                <td class="ic" valign="top">
                                    
                                    <asp:TextBox ID="txtNote" runat="server" MaxLength="4000" TextMode="MultiLine" Width="500px"
                                        Height="100px">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="false" DataKeyNames=""
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <input name="chkItem" type="checkbox" value='<%# Eval("Pk_Security_ID")%>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="10px" />                                                
                                                <HeaderStyle Width="10px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="User_Name" HeaderText="User Name" SortExpression="">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="First_Name" HeaderText="First Name" SortExpression="">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Last_Name" HeaderText="Last Name" SortExpression=""
                                                ></asp:BoundField>
                                            <asp:BoundField DataField="Cost_Center" HeaderText="Entity" SortExpression="">
                                            </asp:BoundField>
                                            
                                        </Columns>
                                        <PagerSettings Visible="False" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3">
                                <asp:Button ID="btnAddDiary" runat="server" Text="Assign Diary" OnClick="btnAddDiary_Click" OnClientClick="javascript:return IsMultipleChecked();" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
    
</body>

</html>
