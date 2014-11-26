<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchPopup.aspx.cs" Inherits="ExecutiveRisk_SearchPopup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
        function SetValue(ID, strValue, otherField)
        {
            var txtID=document.getElementById('hdnID').value;            
            var hdnValueID = txtID.replace('txt','hdn');            
            var lblID = document.getElementById('hdnLblID').value;
            if(txtID != '')
            {
                window.opener.document.getElementById(txtID).value =strValue;
                window.opener.document.getElementById(hdnValueID).value = ID;                
                if (!(window.opener.document.getElementById("ctl00_ContentPlaceHolder1_hdnEntityName") == null))
                    window.opener.document.getElementById("ctl00_ContentPlaceHolder1_hdnEntityName").value = strValue;
            }
            if(lblID != '')
            {
                var ctrl = window.opener.document.getElementById(lblID);                
                if(ctrl.type =="text")
                    window.opener.document.getElementById(lblID).value =otherField;
                else                
                    window.opener.document.getElementById(lblID).innerHTML =otherField;
            }
            
            if (!(window.opener.document.getElementById("ctl00_ContentPlaceHolder1_btnReload") == null))
                window.opener.document.getElementById("ctl00_ContentPlaceHolder1_btnReload").click();                    
            
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="Spacer" style="height: 10px;">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:GridView ID="gvSearch" runat="server" Width="100%" AutoGenerateColumns="false" PageSize="20"
                        EnableViewState="true" AllowPaging="true" OnRowDataBound="gvSearch_RowDataBound" 
                        OnPageIndexChanging="gvSearch_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Entity">
                                <ItemStyle Width="100%" HorizontalAlign="left" />
                                <ItemTemplate>
                                    <a href='#' id="lnkEntity" runat="server"><%# Eval("Entity") %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 30px;">
                </td>
            </tr>
            <input type="hidden" id="hdnID" runat="server" />
            <input type="hidden" id="hdnLblID" runat="server" />
        </table>
    </div>
    </form>
</body>
</html>
