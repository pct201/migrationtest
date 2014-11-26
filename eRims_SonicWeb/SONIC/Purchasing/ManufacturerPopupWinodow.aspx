<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManufacturerPopupWinodow.aspx.cs"
    Inherits="SONIC_Purchasing_ManufacturerPopupWinodow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manufacturer</title>

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
            }       
            window.close();
        }       

        function trapKey(e,id)
        {
            var key = e.keyCode;        
            if(key== 13)
            {      
                document.getElementById(id).click();
                e.keyCode=0;
            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        </div>
        <table cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td>
                    <asp:Panel ID="pnlSearch" runat="server">
                        <div id="dvEdit" runat="server">
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td class="loc">
                                        &nbsp;</td>
                                </tr>
                                <tr class="ghc" align="left">
                                    <td runat="server" id="tdMainTitle">
                                        Manufacturer Search</td>
                                </tr>
                                <tr>
                                    <td class="loc">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="loc">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td valign="middle" align="center">
                                        <table width="100%">
                                            <tr>
                                                <td class="lc" style="width: 50%;" align="right">
                                                    Manufacturer Name</td>
                                                <td class="ic" style="width: 50%;" align="left">
                                                    <asp:TextBox ID="txtManufacture" runat="server" MaxLength="50"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="btnSearch" runat="server" Text="SEARCH" OnClick="btnSearch_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="loc" colspan="2">
                                                    <asp:GridView ID="gvManufacturer" runat="server" Width="100%" AutoGenerateColumns="false"
                                                        PageSize="10" EnableViewState="true" AllowPaging="true" OnRowDataBound="gvManufacturer_RowDataBound"
                                                        OnPageIndexChanging="gvManufacturer_PageIndexChanging">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Manufacturer Search result" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <a href='#' id="lnkmanufacturer" runat="server">
                                                                        <%# Eval("Fld_Desc")%>
                                                                    </a>
                                                                </ItemTemplate>
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
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="80%" colspan="2" class="cc">
                                                    <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRegisterScript" runat="server"></asp:Label></td>
                                </tr>
                                <input type="hidden" id="hdnID" runat="server" />
                                <input type="hidden" id="hdnLblID" runat="server" />
                            </table>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlAdd" runat="server" Visible="false">
                        <div id="dvView" runat="server">
                            <table cellspacing="0" cellpadding="0" class="tablebackground" width="100%">
                                <tr>
                                    <td class="loc">
                                        &nbsp;</td>
                                </tr>
                                <tr class="ghc" align="left">
                                    <td runat="server" id="td1">
                                        Manufacturer Add</td>
                                </tr>
                                <tr>
                                    <td class="loc">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="loc">
                                        <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td valign="middle" align="center">
                                        <table width="100%">
                                            <tr>
                                                <td class="lc" style="width: 50%;" align="right">
                                                    Manufacturer</td>
                                                <td class="ic" style="width: 50%;" align="left">
                                                    <asp:TextBox ID="txtAddManufacture" runat="server" MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvManufacture" runat="server" Display="None" ErrorMessage="Please Enter Manufacturer"
                                                        ValidationGroup="vsErrorGroup" ControlToValidate="txtAddManufacture" SetFocusOnError="true" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="loc" colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="80%" colspan="2" class="cc">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup"
                                                        CausesValidation="true" OnClick="btnSave_Click" />
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                &nbsp;
                            </table>
                        </div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
