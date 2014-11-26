<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="PolicySearch.aspx.cs"
    Inherits="Policy_PolicySearch" Title="eRIMS Sonic :: Policy Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <br />

    <script language="javascript" type="text/javascript">
        function CheckNumericVal(Ctl) {
            if (Ctl.value == "" || isNaN(Number(Ctl.value.replace(/,/g, '')) * 1) == true)
                Ctl.innerText = "1";
        }
        function ChkLength() {
            var length;
            var strValue;
            strValue = document.getElementById("ctl00_ContentPlaceHolder1_txtPolicyYear").value;
            if (strValue.length != 0) {
                if (strValue.length > 4 || strValue.length < 4) {
                    alert("Please Insert 4 Digit Policy Year");
                    return false;
                }
            }
            return true;
        }
    </script>

    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:CustomValidator ID="cvErrorMsg" runat="server" ErrorMessage="" EnableClientScript="false"
            ValidationGroup="vsErrorGroup" Display="None"></asp:CustomValidator>
    </div>
    <link href="../App_Themes/Default/Default.css" type="text/css" rel="Stylesheet" />

    <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>

    <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
        <ProgressTemplate>
            <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                    height: 100%;">
                    <tr align="center" valign="middle">
                        <td class="LoadingText" align="center" valign="middle">
                            <img src='<%= AppConfig.ImageURL %>/indicator.gif' alt="Loading" />&nbsp;&nbsp;&nbsp;Please
                            Wait..
                        </td>
                    </tr>
                </table>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="pnlBankDetail" runat="server">
        <ContentTemplate>
            <div id="dvSearch" runat="server" style="display: block; width: 100%;">
                <table cellpadding="2" cellspacing="2" border="0" style="width: 98%;">
                    <tr>
                        <td colspan="6" class="ghc" align="left">
                            Policy Search
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 16%;" align="left" class="lc">
                            Program
                        </td>
                        <td align="center" class="lc" style="width: 2%;">
                            :
                        </td>
                        <td style="width: 32%;" align="left" class="ic">
                            <asp:DropDownList runat="server" ID="ddlProgram" AutoPostBack="true" OnSelectedIndexChanged="ddlProgram_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 16%;" align="left" class="lc">
                            Policy Type
                        </td>
                        <td align="center" class="lc" style="width: 2%;">
                            :
                        </td>
                        <td style="width: 32%;" align="left" class="ic">
                            <asp:DropDownList runat="server" ID="ddlPolicyType">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="lc">
                            Policy Year
                        </td>
                        <td class="lc" align="center">
                            :
                        </td>
                        <td class="ic" align="left">
                            <asp:TextBox runat="server" ID="txtPolicyYear" SkinID="txtGeneral" MaxLength="4"
                                onkeypress="return numberOnly(event);"></asp:TextBox>
                        </td>
                        <td align="left" class="lc">
                            Carrier
                        </td>
                        <td align="center" class="lc">
                            :
                        </td>
                        <td align="left" class="ic">
                            <asp:TextBox runat="server" ID="txtCarrier" SkinID="txtGeneral" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="lc">
                            Location
                        </td>
                        <td align="center" class="lc" >
                            :
                        </td>
                        <td align="left" class="lc">
                            <asp:DropDownList runat="server" ID="ddlLocation">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:Button runat="server" ID="btnSearch" Text="Search" OnClientClick="javascript:return ChkLength();"
                                OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
