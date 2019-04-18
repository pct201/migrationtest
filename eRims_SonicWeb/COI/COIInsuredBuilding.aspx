<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="COIInsuredBuilding.aspx.cs" Inherits="COI_COIInsuredBuilding" %>

<%@ Register Src="~/Controls/COIInfo/COIInfo.ascx" TagName="ctrlCOIInfo" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript" src="../JavaScript/JFunctions.js"></script>
    <script type="text/javascript">
        function SetMenuStyle(index) {
            var i;
            for (i = 1; i <= 1; i++) {
                var tb = document.getElementById("Menu" + i);
                if (i == index) {
                    tb.className = "LeftMenuSelected";
                    tb.onmouseover = function () { this.className = 'LeftMenuSelected'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuSelected'; }
                }
                else {
                    tb.className = "LeftMenuStatic";
                    tb.onmouseover = function () { this.className = 'LeftMenuHover'; }
                    tb.onmouseout = function () { this.className = 'LeftMenuStatic'; }
                }
            }
        }      

        function SetFocusOnFirstControl(index) {
            switch (index) {
                case 1:
                    document.getElementById('ctl00_ContentPlaceHolder1_txtBuildingNumber').focus(); break;                
                default:
                    break;
            }
        }

        function ShowPanel(index) {

            SetMenuStyle(index);
            var i;
            var op = '<%=StrOperation%>';

            if (op == "view") {             
                ShowPanelView(index);
            }
            else {
                document.getElementById('<%=dvEdit.ClientID%>').style.display = "block";
                document.getElementById('<%=dvSave.ClientID%>').style.display = "block";
                document.getElementById('<%=dvBack.ClientID%>').style.display = "none";
                if (index == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "block";                              
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_Panel1").style.display = "none";                    
                }
                SetFocusOnFirstControl(index);
            }
        }

        function ShowPanelView(index) {
            SetMenuStyle(index);

            document.getElementById('<%=dvView.ClientID%>').style.display = "block";
            document.getElementById('<%=dvSave.ClientID%>').style.display = "none";
            document.getElementById('<%=dvBack.ClientID%>').style.display = "block";
            if (index == 1) {
                document.getElementById("ctl00_ContentPlaceHolder1_Panel2").style.display = "block";                
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_Panel2").style.display = "none";               
            }
        }       

        function ValSave() {
            if (Page_ClientValidate("vsErrorGroup"))
                return true;
            else
                return false;
        }      

        function ValidateFields(sender, args) {
            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDs.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgs.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDs.ClientID%>').value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);
                    switch (ctrl.type) {
                        case "textarea":
                        case "text": if (ctrl.value == '') bEmpty = true; break;
                        case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                    }
                    if (bEmpty && focusCtrlID == "") focusCtrlID = ctrlIDs[i];
                    if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                }
                if (msg.length > 0) {
                    sender.errormessage = msg;
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div style="width: 100%" id="contmain">
        <table cellpadding="0" cellspacing="0" width="100%" align="left">
            <tr>
                <td style="height: 15px;" colspan="3" class="Spacer">
                </td>
            </tr>
            <tr>
                <td width="100%" colspan="3">
                    <uc:ctrlCOIInfo id="ucCtrlCOIInfo" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="Spacer" style="height: 5px;" colspan="3" width="100%">
                </td>
            </tr>
            <tr>
                <td class="leftMenu" valign="top" style="padding-left: 5px;">
                    <table cellpadding="3" cellspacing="2" width="180px">
                        <tr>
                            <td style="height: 10px;" class="Spacer">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%">
                                <span id="Menu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">COI Insured Building
                                </span>&nbsp;<span id="MenuAsterisk1" runat="server" style="color: Red;display:none;">*</span>
                            </td>
                        </tr>                        
                    </table>
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td valign="top" width="100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td class="dvContainer">
                                <div id="dvEdit" runat="server">
                                    <asp:UpdatePanel runat="server" ID="updStatus">
                                        <ContentTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td class="tblGrid" align="left">
                                                <asp:Panel ID="Panel1" runat="server" Style="display: block; height: 100%">
                                                    <div class="bandHeaderRow">
                                                        COI Insured Building</div>
                                                    <table cellpadding="3" cellspacing="1" width="100%">                                                       
                                                        <tr>
                                                            <td width="18%" align="left">
                                                                Building Number &nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td width="2%" align="center">
                                                                :
                                                            </td>
                                                            <td width="28%" align="left">
                                                                <%--<asp:TextBox ID="txtBuildingNumber" Width="200px" runat="server" MaxLength="50"
                                                                    ></asp:TextBox>--%>
                                                                <asp:DropDownList ID="drpBuildingNumber" runat="server" Width="205px" SkinID="Default"
                                                                    AutoPostBack="true" OnSelectedIndexChanged="drpBuildingNumber_SelectedIndexChanged">
                                                                </asp:DropDownList>                                                                
                                                            </td>
                                                            <td width="2%">
                                                                &nbsp;
                                                            </td>
                                                            <td width="18%" align="left">
                                                                 &nbsp;
                                                            </td>
                                                            <td width="2%" align="center">
                                                                 &nbsp;
                                                            </td>
                                                            <td width="28%" align="left">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Address 1&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtAddress1" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Address 2&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtAddress2" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                City&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtCity" Width="200px" runat="server" MaxLength="50"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                               State&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                               <asp:DropDownList ID="drpState" runat="server" Width="205px" SkinID="Default">
                                                                </asp:DropDownList>      
                                                            </td>
                                                        </tr>                                                       
                                                        <tr>
                                                            <td align="left">
                                                                Zip Code&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtZipCode" runat="server" Width="200px" MaxLength="10" onKeyPress="javascript:return FormatZipCode(event,this.id);"
                                                                    ></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="revZipCode" runat="server" ErrorMessage="Please enter Valid Zip Code"
                                                                    Display="none" ControlToValidate="txtZipCode" ValidationExpression="\b[0-9]{5}-[0-9]{4}\b|\b[0-9]{5}\b"
                                                                    ValidationGroup="vsErrorGroup" SetFocusOnError="true" />
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;
                                                            </td>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;
                                                            </td>
                                                        </tr>                                                       
                                                        <tr>
                                                            <td style="height: 10px;" class="Spacer" colspan="7" align="center">
                                                              <asp:Label ID="lblError" runat="server" SkinID="lblError" EnableViewState="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                </div>                               
                                <div id="dvView" runat="server" style="display: none;">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td class="tblGrid" align="left">
                                                <asp:Panel ID="Panel2" runat="server" Style="display: block; height: 100%">
                                                    <div class="bandHeaderRow">
                                                        COI Insured Building</div>
                                                    <table cellpadding="5" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td width="20%" align="left" valign="top">
                                                              Building Number
                                                            </td>
                                                            <td width="2%" align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td width="26%" align="left" valign="top">
                                                                <asp:Label ID="lblBuildingNumber" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="2%" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td width="20%" align="left" valign="top">
                                                               &nbsp;
                                                            </td>
                                                            <td width="2%" align="center" valign="top">
                                                                &nbsp;
                                                            </td>
                                                            <td width="26%" align="left" valign="top">
                                                               &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Address 1
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                Address 2
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                City
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                State
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblState" runat="server" Width="235px"></asp:Label>
                                                            </td>
                                                        </tr>                                                       
                                                        <tr>
                                                            <td align="left">
                                                                Zip Code
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblZipCode" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                 &nbsp;
                                                            </td>
                                                            <td align="center">
                                                                &nbsp;
                                                            </td>
                                                            <td align="left">
                                                                &nbsp;
                                                            </td>
                                                        </tr>                                                       
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>                               
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 5px;" class="Spacer">
                    &nbsp;
                </td>
                <td>
                    <div id="dvSave" runat="server" style="display: none;">
                        <table cellpadding="0" cellspacing="0" width="100%">                           
                            <tr>
                                <td class="Spacer" style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnSave" runat="server" SkinID="Save" CausesValidation="true"
                                        OnClick="btnSave_Click" OnClientClick="return ValSave();" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnReturn" runat="server" SkinID="Revert&Return" CausesValidation="false"
                                        OnClick="btnReturn_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="dvBack" runat="server" style="display: none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td class="Spacer" style="height: 20px;">
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnBack" runat="server" SkinID="Back" OnClick="btnReturn_Click" CausesValidation="false" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Spacer" style="height: 10px;">
                                </td>
                            </tr>                             
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="Spacer" colspan="3" style="height: 20px;">
               
                </td>
            </tr>          
        </table>
    </div>
    <asp:CustomValidator ID="CustomValidator" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
        Display="None" ValidationGroup="vsErrorGroup" />
    <input id="hdnControlIDs" runat="server" type="hidden" />
    <input id="hdnErrorMsgs" runat="server" type="hidden" />
</asp:Content>

