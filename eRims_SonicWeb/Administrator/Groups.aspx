<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Groups.aspx.cs"
    Inherits="SONIC_Exposures_Administrator_Groups" Title="eRIMS Sonic :: Groups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
function AddNewGroup()
{
    
    document.getElementById('<%=trGroupAdd.ClientID %>').style.display="block";
    document.getElementById('<%=trGroupView.ClientID %>').style.display="none";
    document.getElementById('<%=lnkCancel.ClientID %>').style.display="inline";
}
function CheckValidation()
{    
    if(Page_ClientValidate("vsError"))
    {
        var chkText = '';
        var chktable = document.getElementById('<%=chkRights.ClientID %>');
        var chktr = chktable.getElementsByTagName('tr');
        
        for(var i=0; i<chktr.length; i++)
        {
            var chktd = chktr[i].getElementsByTagName('td');
            for(var j=0; j<chktd.length; j++)
            {
               var chkinput = chktd[j].getElementsByTagName('input');
               var chklabel= chktd[j].getElementsByTagName('label');                             
               for(k=0;k<chkinput.length;k++)
                {                    
                    var chkopt = chkinput[k];                    
                    if(chkopt.checked)
                    {
                        chkText = chkText + chklabel[k].innerText + ',';
                    }
                } 
            }            
        }  
        if(chkText == '')
        {
            alert('Please select at least one right!');
            return false;
        }   
        else
        {
            return true;
        }   
    }
    else
    {
        return false;   
    }
}
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields :" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsError" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <asp:UpdatePanel runat="server" ID="updGroup">
        <contenttemplate>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
    <td colspan="4">&nbsp;</td>
</tr>
<tr>
    <td class="bandHeaderRow" colspan="4" align="left">Administrator :: Groups
    </td>
</tr>
<tr>
    <td colspan="4">&nbsp;<asp:Label runat="server" ID="lblError" SkinID="lblError" EnableViewState="false"></asp:Label></td>
</tr>
<tr>
    <td style="width:20%">&nbsp;</td>
    <td colspan="2" align="center">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="left" >
                <asp:Label runat="server" Text="Click To View Details" ID="lblmsg"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
               <asp:GridView ID="gvGroups" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="gvGroups_RowCommand" OnRowCreated="gvGroups_RowCreated" OnRowEditing="gvGroups_RowEditing">
                <Columns>
                <asp:TemplateField HeaderText="Group Name">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkView" Text='<%# Eval("Group_Name") %>' CommandName="View"></asp:LinkButton>
                    <asp:HiddenField runat="Server" ID="hdnGroupID" Value='<%# Eval("PK_Group_ID") %>' />
                </ItemTemplate>
                </asp:TemplateField>     
                <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkEdit" Text="Edit" CommandName="Edit"></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>   
                <asp:TemplateField HeaderText="Remove">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkRemove" Text="Remove" CommandName="Remove" OnClientClick="return confirm('Are you sure to delete?');"></asp:LinkButton>
                </ItemTemplate>
                </asp:TemplateField>   
               </Columns>
               <EmptyDataTemplate>
                <table cellpadding="4" cellspacing="0" width="100%" >
                    <tr>
                        <td width="100%" align="center" style="border:1px solid #cccccc;">
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
    <td style="width:20%">&nbsp;</td>
</tr>
<tr>
    <td colspan="4">&nbsp;</td>
</tr>
<tr>
    <td style="width:20%">&nbsp;</td>
    <td colspan="2">
        <asp:LinkButton runat="server" ID="lnkAddNew" Text="Add New" style="display:inline;" OnClick="lnkAddNew_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton runat="server" ID="lnkCancel" Text="Cancel" style="display:none;" OnClick="lnkCancel_Click"></asp:LinkButton>
    </td>
    <td style="width:20%">&nbsp;</td>
</tr>
<tr runat="server" id="trGroupAdd" style="display:none;">
    <td style="width:20%">&nbsp;</td>
    <td colspan="2">
        <table cellpadding="3" cellspacing="1" border="0" width="100%">
        <tr>
            <td style="width:18%" align="left">Group Name</td>
            <td style="width:4%" align="center">:</td>
            <td colspan="4" align="left">
                <asp:TextBox runat="server" ID="txtGroupName"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvGroupName" ValidationGroup="vsError" ErrorMessage="Please Enter Group Name"
                Display="none" ControlToValidate="txtGroupName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td valign="top" align="left">Rights</td>
            <td valign="top" align="center">:</td>
            <td colspan="4" align="left">
                <asp:CheckBoxList runat="server" ID="chkRights" RepeatColumns="3" RepeatDirection="horizontal">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button runat="server" ID="btnAdd" Text="Add" ValidationGroup="vsError" CausesValidation="false" OnClick="btnAdd_Click" OnClientClick="return CheckValidation();" />
            </td>
        </tr>
        </table>
    </td>
    <td style="width:20%">&nbsp;</td>
</tr>
<tr runat="server" id="trGroupView" style="display:none;">
    <td style="width:20%">&nbsp;</td>
    <td colspan="2">
        <table cellpadding="3" cellspacing="1" border="0" width="100%">
        <tr>
            <td style="width:18%" align="left">Group Name</td>
            <td style="width:4%">:</td>
            <td colspan="4" align="left"><asp:Label runat="server" ID="lblGroupName"></asp:Label></td>
        </tr>
        <tr>
            <td valign="top" align="left">Rights</td>
            <td valign="top">:</td>
            <td colspan="4" align="left">
                <asp:CheckBoxList runat="server" ID="chkRightsView" Enabled="false" RepeatColumns="3" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
            </td>
        </tr>
        </table>
    </td>
    <td style="width:20%">&nbsp;</td>
</tr>
<tr>
    <td colspan="4">&nbsp;</td>
</tr>
</table>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
