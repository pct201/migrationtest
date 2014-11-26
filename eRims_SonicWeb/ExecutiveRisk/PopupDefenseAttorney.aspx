<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupDefenseAttorney.aspx.cs" Inherits="ExecutiveRisk_PopupDefenseAttorney" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management System</title>
</head>
<body>
    <form id="form1" runat="server">
     <div class="bandHeaderRow">
        Defense Attorney</div>
    <div>
        <table cellpadding="2" cellspacing="1" width="100%">
            <tr id="trGrid" runat="server">
                <td align="left" colspan="2">
                    <asp:GridView ID="gvDefenseAttorney" runat="server" AutoGenerateColumns="false" Width="100%"
                        DataKeyNames="PK_LU_Executive_Risk_Defense_Attorney" EmptyDataText="No Record Found" AllowSorting="true"
                        AllowPaging="true"  OnPageIndexChanging="gvDefenseAttorney_PageIndexChanging" OnRowDataBound="gvDefenseAttorney_RowDataBound" PageSize="20">
                        <Columns>
                            <asp:TemplateField HeaderText="Name" 
                                HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="30%" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkName" runat="server" CssClass="acher" CommandArgument='<% #Eval("PK_LU_Executive_Risk_Defense_Attorney") %>'
                                        Text='<% #Eval("Name") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Firm" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="30%" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkFirm" runat="server" CssClass="acher" CommandArgument='<% #Eval("PK_LU_Executive_Risk_Defense_Attorney") %>'
                                        Text='<% #Eval("Firm") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address" HeaderStyle-HorizontalAlign="Left">
                                <ItemStyle Width="40%" HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkAddress" runat="server" CssClass="acher" CommandArgument='<% #Eval("PK_LU_Executive_Risk_Defense_Attorney") %>'
                                        Text=' <%# clsGeneral.FormatAddress(Eval("Address_1"),Eval("Address_2"),Eval("City"),Eval("State"),Eval("Zip_Code")) %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClientClick="javascript:window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtFirm').focus();self.close();" ></asp:Button>
                </td>
            </tr>
        </table>
    </div>
    
    <script type="text/javascript">

        function SelectValue(strPK_LU_Executive_Risk_Defense_Attorney, strFirm, strName, strAddress_1, strAddress_2, strCity, strFK_State, strZip_Code, strTelephone, strE_Mail, strPanel, strNotes) {
          
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtFirm').value = strFirm;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtName').value = strName;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtAddress1').value = strAddress_1;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtAddress2').value = strAddress_2;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtCity').value = strCity;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_drpState').value = strFK_State;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtZipcode').value = strZip_Code;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtTelephone').value = strTelephone;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtEmail').value = strE_Mail;
                if (strPanel == "Y")
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_rdoPanel_0').checked = true;
                else
                    window.opener.document.getElementById('ctl00_ContentPlaceHolder1_rdoPanel_1').checked = true;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtNotes_txtNote').value = strNotes;
                window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtFirm').focus();

            self.close();
        }

        function disableDeleteBackSpace() {
            debugger;
            var keyCode = (event.which) ? event.which : event.keyCode;

            if ((keyCode == 8) || (keyCode == 46))
                event.returnValue = false;
            else if (keyCode == 9)
                event.returnValue = true;
            else
                event.returnValue = false;
        }
    </script>

    </form>
</body>
</html>
