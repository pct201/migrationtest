<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Environmental.aspx.cs"
    Inherits="Exposures_Environmental" Title="Exposures :: Environmental Data" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attchment-Environment/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/AttchmentDetails-Environment/AttachmentDetails.ascx"
    TagName="ctrlAttachmentDetails" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript">

        function CheckIsNumeric(source, arguments) {
            if (trim(arguments.Value) != '')
                arguments.IsValid = IsNumericNoAlert(RemoveCommas(arguments.Value));
        }

        // Show Hide Fields of Equipment Information
        function ChangeEquipmentType() {
            var EquipType = document.getElementById('<%=ddlEquiepmentType.ClientID%>');
            var tblType = document.getElementById('<%=tblTypeInfo.ClientID %>');
            var Oilwater = document.getElementById('<%=tblOilWater.ClientID %>');
            var valCapacity = document.getElementById('<%=csmvCapacity.ClientID %>');

            var valLast_Service = document.getElementById('<%=rgvDate_of_Last_Service.ClientID %>');
            var valLast_TCLP = document.getElementById('<%=rgvDate_of_Last_TCLP.ClientID %>');

            // disable Validation 
            ValidatorEnable(valCapacity, false);
            //ValidatorEnable(valstatus, false);
            ValidatorEnable(valLast_Service, false);
            ValidatorEnable(valLast_TCLP, false);

            // Check Equipment Type and as per Type show hide Fields and enable-disable Validation
            if (EquipType.selectedIndex == 1 || EquipType.selectedIndex == 2) {
                tblType.style.display = 'block';
                Oilwater.style.display = 'none';
                ValidatorEnable(valCapacity, true);
                //ValidatorEnable(valstatus, true);
            }
            else if (EquipType.selectedIndex == 3) {
                Oilwater.style.display = 'block';
                tblType.style.display = 'none';
                ValidatorEnable(valLast_Service, true);
                ValidatorEnable(valLast_TCLP, true);
            }
            else {
                Oilwater.style.display = 'none';
                tblType.style.display = 'none';
            }
        }

        // Set Selected Node Color-Style 
        function SetSelectedNode(SelectedNodeId) {
            var arrLinks = document.getElementById('<%=trvMenu.ClientID%>').getElementsByTagName('a');
            var i = 0;

            // Set Default css Class for All tree nodes.
            for (i = 0; i < arrLinks.length; i++) {
                arrLinks[i].className = 'leftmenu';
                arrLinks[i].style.color = '';
            }

            // set Font Color for Selected Node
            document.getElementById(SelectedNodeId).style.color = '#266591';
        }

        function ToggleNode(SelectedNodeId, NodeNumber) {
            // Expand-Collapse Node.
            TreeView_ToggleNode(ctl00_ContentPlaceHolder1_trvMenu_Data, 1, document.getElementById('ctl00_ContentPlaceHolder1_trvMenun' + NodeNumber), ' ', document.getElementById('ctl00_ContentPlaceHolder1_trvMenun' + NodeNumber + 'Nodes'));
        }

        function OutsideToggleNode(SelectedNodeId, NodeNumber) {
            // If Node is not explanded then Expand Node.
            if (document.getElementById('ctl00_ContentPlaceHolder1_trvMenun' + NodeNumber + 'Nodes').style.display != 'block') {
                TreeView_ToggleNode(ctl00_ContentPlaceHolder1_trvMenu_Data, 1, document.getElementById('ctl00_ContentPlaceHolder1_trvMenun' + NodeNumber), ' ', document.getElementById('ctl00_ContentPlaceHolder1_trvMenun' + NodeNumber + 'Nodes'))
            }
        }
        //Show panel
        function ShowPanel(index) {
           
            document.getElementById("<%=pnlEnvironmentSummary.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlEquipment.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlInAdvertentRelease.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlEquipmentAttachment.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlEquipmentAttachmentDetail.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlEquipmentRecommendations.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlPermitInformation.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlPermitAttachment.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlPermitAttachmentDetail.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlPermitRecommendations.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlAudit.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlAuditAttachment.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlAuditAttachmentDetail.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlAuditRecommendations.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlSPCC.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlSPCCAttachment.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlSPCCAttachmentDeatil.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlSPCCRecommendations.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlPhaseI.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlPhaseAttachment.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlPhaseAttachementDetail.ClientID%>").style.display = "none";
            document.getElementById("<%=pnlPhaseRecommendations.ClientID%>").style.display = "none";

            //check if index is 0 than display Enviroment View Section.
            if (index == 0) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + index);
                document.getElementById("<%=pnlEnvironmentSummary.ClientID%>").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_M1").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_M2").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_M3").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_M4").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_M5").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_M6").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_M7").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_M8").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_M9").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_M10").style.display = "block";
            }
            //check if index is 1 than display Equipment Section.
            else if (index == 1) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 1));
                document.getElementById("<%=pnlEquipment.ClientID%>").style.display = "block";
            }
            //check if index is 2 than display  Section.
            else if (index == 2) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 1));
                document.getElementById("<%=pnlInAdvertentRelease.ClientID%>").style.display = "block";
            }
            //check if index is 3 than display  Section.
            else if (index == 3) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 1));
                document.getElementById("<%=pnlEquipmentAttachment.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlEquipmentAttachmentDetail.ClientID%>").style.display = "block";
            }
            //check if index is 4 than display  Section.
            else if (index == 4) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 1));
                document.getElementById("<%=pnlEquipmentRecommendations.ClientID%>").style.display = "block";
            }
            //check if index is 5 than display  Section.
            else if (index == 5) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 2));
                document.getElementById("<%=pnlPermitInformation.ClientID%>").style.display = "block";
            }
            //check if index is 6 than display  Section.
            else if (index == 6) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 2));
                document.getElementById("<%=pnlPermitAttachment.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlPermitAttachmentDetail.ClientID%>").style.display = "block";
            }
            //check if index is 7 than display  Section.
            else if (index == 7) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 2));
                document.getElementById("<%=pnlPermitRecommendations.ClientID%>").style.display = "block";
            }
            //check if index is 8 than display  Section.
            else if (index == 8) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 3));
                document.getElementById("<%=pnlAudit.ClientID%>").style.display = "block";
            }
            //check if index is 9 than display  Section.
            else if (index == 9) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 3));
                document.getElementById("<%=pnlAuditAttachment.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlAuditAttachmentDetail.ClientID%>").style.display = "block";
            }
            //check if index is 10 than display  Section.
            else if (index == 10) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 3));
                document.getElementById("<%=pnlAuditRecommendations.ClientID%>").style.display = "block";
            }
            //check if index is 11 than display  Section.
            else if (index == 11) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 4));
                document.getElementById("<%=pnlSPCC.ClientID%>").style.display = "block";
            }
            //check if index is 12 than display  Section.
            else if (index == 12) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 4));
                document.getElementById("<%=pnlSPCCAttachment.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlSPCCAttachmentDeatil.ClientID%>").style.display = "block";
            }
            //check if index is 13 than display  Section.
            else if (index == 13) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 4));
                document.getElementById("<%=pnlSPCCRecommendations.ClientID%>").style.display = "block";
            }
            //check if index is 14 than display  Section.
            else if (index == 14) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 5));
                document.getElementById("<%=pnlPhaseI.ClientID%>").style.display = "block";
            }
            //check if index is 15 than display  Section.
            else if (index == 15) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 5));
                document.getElementById("<%=pnlPhaseAttachment.ClientID%>").style.display = "block";
                document.getElementById("<%=pnlPhaseAttachementDetail.ClientID%>").style.display = "block";
            }
            //check if index is 16 than display  Section.
            else if (index == 16) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 5));
                document.getElementById("<%=pnlPhaseRecommendations.ClientID%>").style.display = "block";
            }
            //check if index is 0 than display Enviroment View Section.
            else if (index == 17) {
                SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut22');
                document.getElementById("<%=pnlEnvironmentSummary.ClientID%>").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_M1").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_M2").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_M3").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_M4").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_M5").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_M6").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_M7").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_M8").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_M9").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_M10").style.display = "none";

                
                document.getElementById("ctl00_ContentPlaceHolder1_trEPA").style.display = "block";
            }
        }
        function ValidateFields(sender, args) {
            var msg = '';
            var index;
            index = sender.id.replace('ctl00_ContentPlaceHolder1_CustomValidator', '').trim();
            var ctrlIDs = document.getElementById('ctl00_ContentPlaceHolder1_hdnControlIDs' + index).value.split(',');
            var Messages = document.getElementById('ctl00_ContentPlaceHolder1_hdnErrorMsgs' + index).value.split(',');
            if (document.getElementById('ctl00_ContentPlaceHolder1_hdnControlIDs' + index).value != "") {
                var i = 0;
                for (i = 0; i < ctrlIDs.length; i++) {
                    var bEmpty = false;
                    var ctrl = document.getElementById(ctrlIDs[i]);

                    if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_ddlContents' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_ddlStatus' ||
                    ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtConents_Other' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtCapacity' ||
                    ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_ddlMaterial' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtMaterial_Other' ||
                    ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_ddlConstruction' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtConstructionOther' ||
                    ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtRelease_Equipment_Description') {
                        if (document.getElementById("<%=tblTypeInfo.ClientID%>").style.display != "none") {
                            switch (ctrl.type) {
                                case "textarea":
                                case "text": if (ctrl.value == '') bEmpty = true; break;
                                case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                                case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                            }
                            if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                        }
                    }
                    else if (ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtDate_of_Last_Service' || ctrlIDs[i] == 'ctl00_ContentPlaceHolder1_txtDate_of_Last_TCLP') {
                        if (document.getElementById("<%=tblOilWater.ClientID%>").style.display != "none") {
                            switch (ctrl.type) {
                                case "textarea":
                                case "text": if (ctrl.value == '') bEmpty = true; break;
                                case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                                case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                            }
                            if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                        }
                    }
                    else {
                        switch (ctrl.type) {
                            case "textarea":
                            case "text": if (ctrl.value == '') bEmpty = true; break;
                            case "select-one": if (ctrl.selectedIndex == 0) bEmpty = true; break;
                            case "select-multiple": if (ctrl.selectedIndex == -1) bEmpty = true; break;
                        }
                        if (bEmpty) msg += (msg.length > 0 ? "- " : "") + Messages[i] + "\n";
                    }
                }
                if (msg.length > 0) {
                    sender.errormessage = msg;
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
            else
                args.IsValid = true;
        }

        function ValidateFieldsEPA(sender, args) {

            var msg = '';
            var ctrlIDs = document.getElementById('<%=hdnControlIDEPA.ClientID%>').value.split(',');
            var Messages = document.getElementById('<%=hdnErrorMsgsEPA.ClientID%>').value.split(',');
            var focusCtrlID = "";
            if (document.getElementById('<%=hdnControlIDEPA.ClientID%>').value != "") {
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
    <script type="text/javascript" language="javascript">
        function AuditPopUp(id) {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open("AuditPopup_Environmental.aspx?id=" + id, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;
        }
        function ShowAuditPopUp(url) {
            var winHeight = window.screen.availHeight - 300;
            var winWidth = window.screen.availWidth - 200;

            obj = window.open(url, 'AuditPopUp', 'width=' + winWidth + ',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');
            obj.focus();
            return false;

        }
    </script>
    <div>
        <asp:ValidationSummary ID="valSummaryEquipment" runat="server" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false" ValidationGroup="valEquipment" />
        <asp:ValidationSummary ID="valSummaryInadvertentRelease" runat="server" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false" ValidationGroup="InadvertentRelease" />
        <asp:ValidationSummary ID="valSummaryEquipmentRecommendation" HeaderText="Verify the following fields:"
            runat="server" ValidationGroup="EquipmentRecommendation" ShowMessageBox="true"
            ShowSummary="false" />
        <asp:ValidationSummary ID="valSummaryPermit" runat="server" HeaderText="Verify the following fields:"
            ValidationGroup="valPermitInformation" ShowMessageBox="true" ShowSummary="false" />
        <asp:ValidationSummary ID="valSummarypermitRecommendation" runat="server" ValidationGroup="PermitRecommendation"
            HeaderText="Verify the following fields:" ShowMessageBox="true" ShowSummary="false" />
        <asp:ValidationSummary ID="valSummaryAudit" runat="server" ValidationGroup="valAuditInfo"
            ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields:" />
        <asp:ValidationSummary ID="valSummaryAuditRecommendation" runat="server" ValidationGroup="AuditRecommendation"
            ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields:" />
        <asp:ValidationSummary ID="valSummarySPCC" runat="server" ShowMessageBox="true" ShowSummary="false"
            HeaderText="verify the following fields:" ValidationGroup="valSPCCInfo" />
        <asp:ValidationSummary ID="valSummaryPlanInfo" runat="server" ValidationGroup="valPlanInfo"
            ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields:" />
        <asp:ValidationSummary ID="valSummaryPhase1" runat="server" ValidationGroup="valPhase1"
            ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following fields:" />
        <asp:ValidationSummary ID="valSummaryPhaseAttachment" runat="server" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false" ValidationGroup="valPhaseAttachement" />
        <asp:ValidationSummary ID="valSummaryEPA" runat="server" HeaderText="Verify the following fields:"
            ShowMessageBox="true" ShowSummary="false" ValidationGroup="valEPA" />
    </div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" style="height: 50px;" valign="bottom" colspan="2">
                <uc:CtlTab runat="server" ID="Tab"></uc:CtlTab>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" colspan="2">
                            <uc:ctrlExposureInfo ID="ucExposureInfo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 15px;" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="leftMenu">
                            <table cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 18px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="100%">
                                        <div style="width: 205px; height: 500px; overflow: auto;">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%" align="center">
                                                <tr>
                                                    <td valign="top" style="width: 100%">
                                                        <asp:TreeView ExpandDepth="0" ID="trvMenu" runat="server" NodeWrap="true" ShowLines="false"
                                                            DataSourceID="dsSiteMap" CssClass="leftmenu">
                                                            <SelectedNodeStyle CssClass="leftmenu_active" ForeColor="Green" />
                                                            <DataBindings>
                                                                <asp:TreeNodeBinding DataMember="siteMapNode" TextField="title" NavigateUrlField="url" />                                                                                                                                   
                                                            </DataBindings>                                  
                                                        </asp:TreeView>
                                                        <asp:SiteMapDataSource ID="dsSiteMap" runat="server" ShowStartingNode="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 5px;" class="Spacer">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblSubmitMessage" SkinID="lblError"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="50">
                                            <ProgressTemplate>
                                                <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                                                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                                                        height: 100%;">
                                                        <tr align="center" valign="middle">
                                                            <td class="LoadingText" align="center" valign="middle">
                                                                <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 794px" valign="top" class="dvContainer">
                                        <asp:Panel ID="pnlEnvironmentSummary" runat="server">
                                            <div class="bandHeaderRow">
                                                Environmental Data</div>
                                            <asp:UpdatePanel ID="updEnvironment" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                <ContentTemplate>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr runat="server" id="M1">
                                                            <td colspan="2" class="boldPoint">
                                                                Equipment
                                                            </td>
                                                        </tr>
                                                        <tr  runat="server" id="M2">
                                                            <td align="left" valign="top" style="width: 10%;">
                                                                <asp:LinkButton ID="btnAddEquipment" runat="server" Text="--Add--" OnClick="btnAddEquipment_Click"></asp:LinkButton>
                                                            </td>
                                                            <td align="left" valign="middle">
                                                                <asp:GridView ID="gvEquipment" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                    DataKeyNames="PK_Enviro_Equipment_ID" OnRowDeleting="gvEquipment_RowDeleting"
                                                                    Width="100%" OnRowEditing="gvEquipment_RowEditing">
                                                                    <EmptyDataRowStyle VerticalAlign="Top" />
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="Identification">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtIdentification" runat="server" Text='<%#Eval("Identification") %>'
                                                                                    CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="status">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtstatus" runat="server" Text='<%#Eval("status") %>' CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="Type">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbttype" runat="server" Text='<%#Eval("type") %>' CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="Remove">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtDeleteEquipment" runat="server" Text="Remove" CommandName="Delete"
                                                                                    OnClientClick="return confirm('Are you sure your want to delete this Equipment?');"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr  runat="server" id="M3">
                                                            <td colspan="2" class="boldPoint">
                                                                Permits
                                                            </td>
                                                        </tr>
                                                        <tr  runat="server" id="M4">
                                                            <td align="left" valign="top">
                                                                <asp:LinkButton ID="lbtAddPermits" runat="server" Text="--Add--" OnClick="lbtAddPermits_Click"></asp:LinkButton>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:GridView ID="gvPermit" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                    OnRowEditing="gvPermit_RowEditing" OnRowDeleting="gvPermit_RowDeleting" DataKeyNames="PK_Enviro_Permit_ID"
                                                                    Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="Permit">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtIdentification" runat="server" Text='<%#Eval("type") %>' CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="Begin Date">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtBegin_date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Begin_date")) %>'
                                                                                    CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="End Date">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtEnd_date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("End_date")) %>'
                                                                                    CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="Remove">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtDeletePermit" runat="server" Text="Remove" CommandName="Delete"
                                                                                    OnClientClick="return confirm('Are you sure your want to delete this Permit?');"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr  runat="server" id="M5">
                                                            <td colspan="2" class="boldPoint">
                                                                Audits/Inspections
                                                            </td>
                                                        </tr>
                                                        <tr  runat="server" id="M6">
                                                            <td align="left" valign="top">
                                                                <asp:LinkButton ID="lbtAuditsAdd" runat="server" Text="--Add--" OnClick="lbtAuditsAdd_Click"></asp:LinkButton>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:GridView ID="gvAudit" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                    OnRowDeleting="gvAudit_RowDeleting" DataKeyNames="PK_Enviro_Inspection_ID" OnRowEditing="gvAudit_RowEditing"
                                                                    Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Last Date">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtAuditLast_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Last_date")) %>'
                                                                                    CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Next Date">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtAuditNext_Date" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Next_Date")) %>'
                                                                                    CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Remove">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtDeleteAudit" runat="server" Text="Remove" CommandName="Delete"
                                                                                    OnClientClick="return confirm('Are you sure your want to delete this Audit/Inspection?');"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr  runat="server" id="M7">
                                                            <td colspan="2" class="boldPoint">
                                                                SPCC
                                                            </td>
                                                        </tr>
                                                        <tr  runat="server" id="M8">
                                                            <td align="left" valign="top">
                                                                <asp:LinkButton ID="lbtAddSPCC" runat="server" Text="--Add--" OnClick="lbtAddSPCC_Click"></asp:LinkButton>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:GridView ID="gvSPCC" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                    OnRowEditing="gvSPCC_RowEditing" OnRowDeleting="gvSPCC_RowDeleting" DataKeyNames="PK_Enviro_SPCC_ID"
                                                                    Width="100%">
                                                                    <EmptyDataRowStyle Width="100%" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblSPCC_LastDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Last_Date")) %>'
                                                                                    CommandName="Edit">
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblSPCC_Remove" runat="server" Text="Remove" CommandName="Delete"
                                                                                    OnClientClick="return confirm('Are you sure your want to delete this SPCC?');">
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr  runat="server" id="M9">
                                                            <td colspan="2" class="boldPoint">
                                                                Phase I
                                                            </td>
                                                        </tr>
                                                        <tr  runat="server" id="M10">
                                                            <td align="left" valign="top">
                                                                <asp:LinkButton ID="lbtAddPhase" runat="server" Text="--Add--" OnClick="lbtAddPhase_Click"></asp:LinkButton>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:GridView ID="gvPhaseI" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                    DataKeyNames="PK_Enviro_Phase1_ID" OnRowEditing="gvPhaseI_RowEditing" OnRowDeleting="gvPhaseI_RowDeleting"
                                                                    Width="100%">
                                                                    <EmptyDataRowStyle Width="100%" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblPhase_LastDate" runat="server" Text='<%#clsGeneral.FormatDBNullDateToDisplay(Eval("Last_Date")) %>'
                                                                                    CommandName="Edit">
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblPhase_Remove" runat="server" Text="Remove" CommandName="Delete"
                                                                                    OnClientClick="return confirm('Are you sure your want to delete this Phase I ?');">
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr id="trEPA" runat="server">
                                                            <td colspan="2" width="100%">
                                                                <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                    <tr>
                                                                        <td colspan="2" class="boldPoint" style="height: 25px">
                                                                            EPA IDs
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top" style="width:10%">
                                                                            <asp:LinkButton ID="lblEPAIDlAdd" runat="server" Text="--Add--" OnClick="lblEPAIDlAdd_Click"></asp:LinkButton>
                                                                        </td>
                                                                        <td align="left" valign="top" style="width:90%">
                                                                            <asp:GridView ID="gvEPAID" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                                OnRowEditing="gvEPAID_RowEditing" OnRowDeleting="gvEPAID_RowDeleting" Width="100%"
                                                                                DataKeyNames="PK_Enviro_Permit_ID">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Type">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lblEPAType" runat="server" Text='<%#Eval("Type") %>' CommandName="Edit"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="ID">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lblEPANumber" runat="server" Text='<%#Eval("ID_Number") %>' CommandName="Edit"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Remove">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lblDelete" runat="server" Text="Remove" CommandName="Delete"
                                                                                                OnClientClick="return confirm('Are you sure you want to delete this EPA ID?');"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Panel ID="pnlEPAID" runat="server" Visible="false">
                                                        <table width="100%">
                                                            <tr>
                                                                <td style="width: 10%;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 90%;" class="dvContainer">
                                                                    <div class="bandHeaderRow">
                                                                        EPA IDs</div>
                                                                    <table width="100%" cellspacing="1" cellpadding="3">
                                                                        <tr>
                                                                            <td style="width: 14%">
                                                                                Type&nbsp;<span id="Span142" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 27%">
                                                                                <asp:TextBox ID="txtEPAType" runat="server" MaxLength="50" Width="170px"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 14%">
                                                                                ID&nbsp;<span id="Span143" style="color: Red; display: none;" runat="server">*</span>
                                                                            </td>
                                                                            <td style="width: 4%">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 27%">
                                                                                <asp:TextBox ID="txtEPAID_Number" runat="server" MaxLength="50" Width="170px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6" align="center">
                                                                                <asp:Button ID="btnEPISave" runat="server" ValidationGroup="valEPA" Text="Save" OnClick="btnEPISave_Click" />
                                                                                <asp:Button ID="btnEPICancel" runat="server" Text="Cancel" OnClick="btnEPICancel_Click" />
                                                                                <asp:Button ID="btnEPIAudit" runat="server" Text="View Audit Trail" Visible="false" />
                                                                                <asp:CustomValidator ID="CustomValidator12" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFieldsEPA"
                                                                                    Display="None" ValidationGroup="valEPA" />
                                                                                <input id="hdnControlIDEPA" runat="server" type="hidden" />
                                                                                <input id="hdnErrorMsgsEPA" runat="server" type="hidden" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnEquipmentSaveView" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnPermit_Save" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnAudit_Save" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnPlan_Save" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="btnPhase_Save" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </asp:Panel>
                                        <asp:UpdatePanel ID="updEquipment" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlEquipment" runat="server" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Equipment</div>
                                                    <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="height: 20px" class="Spacer" colspan="6">
                                                                    <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width: 18%" align="left">
                                                                                    Identification&nbsp;<span id="Span1" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td style="width: 4%" align="center">
                                                                                    :
                                                                                </td>
                                                                                <td style="width: 28%" align="left">
                                                                                    <asp:TextBox ID="txtIdentification" runat="server" Width="170px" ToolTip="Identification"
                                                                                        MaxLength="50" EnableViewState="true"></asp:TextBox>
                                                                                    <%--<asp:RequiredFieldValidator ID="rfvIdentification" runat="server" ControlToValidate="txtIdentification"
                                                                                        SetFocusOnError="true" ErrorMessage="Identification must not be Empty." Display="None"
                                                                                        ValidationGroup="valEquipment">
                                                                                    </asp:RequiredFieldValidator>--%>
                                                                                </td>
                                                                                <td style="width: 18%" align="left">
                                                                                    Type&nbsp;<span id="Span2" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td style="width: 4%" align="center">
                                                                                    :
                                                                                </td>
                                                                                <td style="width: 28%" align="left">
                                                                                    <asp:DropDownList ID="ddlEquiepmentType" runat="server" SkinID="ddlExposure" EnableViewState="true">
                                                                                        <asp:ListItem Text="--SELECT--" Value="0"></asp:ListItem>
                                                                                        <asp:ListItem Text="Above Ground Storage Tank" Value="Above Ground Storage Tank"></asp:ListItem>
                                                                                        <asp:ListItem Text="Underground Storage Tank" Value="Underground Storage Tank"></asp:ListItem>
                                                                                        <asp:ListItem Text="Oil Water Seperator" Value="Oil Water Seperator"></asp:ListItem>
                                                                                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <%--<asp:RequiredFieldValidator ID="rfvEquiepmentType" runat="server" ControlToValidate="ddlEquiepmentType"
                                                                                        SetFocusOnError="true" InitialValue="0" ErrorMessage="Type must not be Empty."
                                                                                        Display="None" ValidationGroup="valEquipment">
                                                                                    </asp:RequiredFieldValidator>--%>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                    <table style="display: none" id="tblTypeInfo" cellspacing="1" cellpadding="3" width="100%"
                                                                        runat="server">
                                                                        <%--<tbody>--%>
                                                                            <tr>
                                                                                <td style="width: 18%" align="left">
                                                                                    Contents&nbsp;<span id="Span131" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center" width="4%">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" width="28%">
                                                                                    <asp:DropDownList ID="ddlContents" runat="server" SkinID="ddlExposure" EnableViewState="true">
                                                                                        <asp:ListItem Value="">--Select---</asp:ListItem>
                                                                                        <asp:ListItem Value="Diesel Fuel">Diesel Fuel</asp:ListItem>
                                                                                        <asp:ListItem Value="Gasoline">Gasoline</asp:ListItem>
                                                                                        <asp:ListItem Value="Heating Oil">Heating Oil</asp:ListItem>
                                                                                        <asp:ListItem Value="Hydraulic Fluid">Hydraulic Fluid</asp:ListItem>
                                                                                        <asp:ListItem Value="kerosene">kerosene</asp:ListItem>
                                                                                        <asp:ListItem Value="New Oil">New Oil</asp:ListItem>
                                                                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                                                                        <asp:ListItem Value="Propane">Propane</asp:ListItem>
                                                                                        <asp:ListItem Value="Waste Oil">Waste Oil</asp:ListItem>
                                                                                        <asp:ListItem Value="Waste Water">Waste Water</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td align="left" width="18%">
                                                                                    Contents – Other&nbsp;<span id="Span132" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center" width="4%">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" width="28%">
                                                                                    <asp:TextBox ID="txtConents_Other" runat="server" Width="170px" MaxLength="50" EnableViewState="true"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 18%" align="left">
                                                                                    Capacity(Gallons)&nbsp;<span id="Span133" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td style="width: 4%" align="center">
                                                                                    :
                                                                                </td>
                                                                                <td style="width: 28%" align="left">
                                                                                    <asp:TextBox ID="txtCapacity" runat="server" Width="170px" MaxLength="11"></asp:TextBox>
                                                                                    <asp:CustomValidator ID="csmvCapacity" runat="server" ControlToValidate="txtCapacity"
                                                                                        SetFocusOnError="true" ClientValidationFunction="CheckIsNumeric" Display="None"
                                                                                        ValidationGroup="valEquipment" ErrorMessage="Capacity(Gallons) is not valid Number."> 
                                                                                    </asp:CustomValidator>
                                                                                </td>
                                                                                <td style="width: 18%" align="left">
                                                                                    Status&nbsp;<span id="Span134" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td style="width: 4%" align="center">
                                                                                    :
                                                                                </td>
                                                                                <td style="width: 28%" align="left">
                                                                                    <asp:DropDownList ID="ddlStatus" runat="server" SkinID="ddlExposure" EnableViewState="true">
                                                                                        <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                                                                                        <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                                                                        <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
                                                                                        <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <%--<asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus"
                                                                                        SetFocusOnError="true" Enabled="false" Display="None" InitialValue="" ErrorMessage="Please Select Status."
                                                                                        ValidationGroup="valEquipment">
                                                                                    </asp:RequiredFieldValidator>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Material&nbsp;<span id="Span135" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="ddlMaterial" runat="server" SkinID="ddlExposure" EnableViewState="true">
                                                                                        <asp:ListItem Text="---Select---" Value=""></asp:ListItem>
                                                                                        <asp:ListItem Value="FiberGlass/FRP">FiberGlass/FRP</asp:ListItem>
                                                                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                                                                        <asp:ListItem Value="Steel - Bar">Steel - Bar</asp:ListItem>
                                                                                        <asp:ListItem Value="Steel - Coated">Steel - Coated</asp:ListItem>
                                                                                        <asp:ListItem Value="Steel - FRP Clad">Steel - FRP Clad</asp:ListItem>
                                                                                        <asp:ListItem Value="Unknown">Unknown</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td align="left">
                                                                                    Material-Other&nbsp;<span id="Span136" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtMaterial_Other" runat="server" Width="170px" MaxLength="50" EnableViewState="true"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Construction&nbsp;<span id="Span137" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="ddlConstruction" runat="server" SkinID="ddlExposure" EnableViewState="true">
                                                                                        <asp:ListItem Text="---Select---" Value=""> </asp:ListItem>
                                                                                        <asp:ListItem Value="Belly Tank">Belly Tank</asp:ListItem>
                                                                                        <asp:ListItem Value="Day Tank">Day Tank</asp:ListItem>
                                                                                        <asp:ListItem Value="Diked">Diked</asp:ListItem>
                                                                                        <asp:ListItem Value="Double Wall">Double Wall</asp:ListItem>
                                                                                        <asp:ListItem Value="Other">Other</asp:ListItem>
                                                                                        <asp:ListItem Value="Single Wall">Single Wall</asp:ListItem>
                                                                                        <asp:ListItem Value="Unknown">Unknown</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td align="left">
                                                                                    Construction-Other&nbsp;<span id="Span138" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtConstructionOther" runat="server" Width="170px" MaxLength="50"
                                                                                        EnableViewState="true"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Release Equipment Present?
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:RadioButtonList ID="rdoRelease_Equipment_Present" runat="server" SkinID="YesNoTypeNullSelection">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Release Equipment Description&nbsp;<span id="Span139" style="color: Red; display: none;"
                                                                                        runat="server">*</span>
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <uc:ctrlMultiLineTextBox ID="txtRelease_Equipment_Description" runat="server" ControlType="TextBox">
                                                                                    </uc:ctrlMultiLineTextBox>
                                                                                </td>
                                                                            </tr>
                                                                        <%--</tbody>--%>
                                                                    </table>
                                                                    <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Overfill Protection
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:RadioButtonList ID="rdoOverfill_Protection" runat="server" SkinID="YesNoTypeNullSelection">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 18%" align="left">
                                                                                    Leak Detection
                                                                                </td>
                                                                                <td style="width: 4%" align="center">
                                                                                    :
                                                                                </td>
                                                                                <td style="width: 28%" align="left">
                                                                                    <asp:RadioButtonList ID="rdoLeak_Detection" runat="server" SkinID="YesNoTypeNullSelection">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td style="width: 18%" align="left">
                                                                                    Leak Detection Type&nbsp;<span id="Span3" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td style="width: 4%" align="center">
                                                                                    :
                                                                                </td>
                                                                                <td style="width: 28%" align="left">
                                                                                    <asp:TextBox ID="txtLeak_Detection_Type" runat="server" EnableViewState="true" MaxLength="50"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Insurer&nbsp;<span id="Span4" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:TextBox ID="txtInsurer" runat="server" Width="170px" MaxLength="50" EnableViewState="true"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Single Event Coverage&nbsp;<span id="Span5" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtSingle_Event_Coverage" runat="server" Width="170px" MaxLength="11"></asp:TextBox>
                                                                                    <asp:CustomValidator ID="csmvSingle_Event_Coverage" runat="server" ControlToValidate="txtSingle_Event_Coverage"
                                                                                        SetFocusOnError="true" ClientValidationFunction="CheckIsNumeric" Display="None"
                                                                                        ErrorMessage="Singel Event Data must be Numeric." ValidationGroup="valEquipment">
                                                                                    </asp:CustomValidator>
                                                                                </td>
                                                                                <td align="left">
                                                                                    Multiple Event/Total Coverage&nbsp;<span id="Span6" style="color: Red; display: none;"
                                                                                        runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtMultiple_Event_Total_Coverage" runat="server" Width="170px" MaxLength="11"></asp:TextBox>
                                                                                    <asp:CustomValidator ID="csmvMultiple_Event_Total_Coverage" runat="server" ControlToValidate="txtMultiple_Event_Total_Coverage"
                                                                                        SetFocusOnError="true" ClientValidationFunction="CheckIsNumeric" Display="None"
                                                                                        ErrorMessage="Multiple Event/Total Coverage must be Numeric." ValidationGroup="valEquipment">
                                                                                    </asp:CustomValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Coverage Start Date&nbsp;<span id="Span7" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtCoverage_Start_Date" runat="server" Width="170px" MaxLength="10"
                                                                                        EnableViewState="true" SkinID="txtdate"></asp:TextBox>
                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCoverage_Start_Date', 'mm/dd/y');"
                                                                                        alt="Coverage Start Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                    <asp:RangeValidator ID="rgvCoverage_Start_Date" ControlToValidate="txtCoverage_Start_Date"
                                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                                        ErrorMessage="Coverage Start Date is not a valid date." runat="server" ValidationGroup="valEquipment"
                                                                                        Display="none" />
                                                                                </td>
                                                                                <td align="left">
                                                                                    Coverage End Date&nbsp;<span id="Span8" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtCoverage_End_Date" runat="server" Width="170px" MaxLength="10"
                                                                                        EnableViewState="true" SkinID="txtdate"></asp:TextBox>
                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCoverage_End_Date', 'mm/dd/y');"
                                                                                        alt="Coverage End Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                    <asp:RangeValidator ID="rgvCoverage_End_Date" ControlToValidate="txtCoverage_End_Date"
                                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                                        ErrorMessage="Coverage End Date is not a valid date." runat="server" ValidationGroup="valEquipment"
                                                                                        Display="none" />
                                                                                    <asp:CompareValidator ID="cmpvCoverage_End_Date" runat="server" ControlToValidate="txtCoverage_End_Date"
                                                                                        SetFocusOnError="true" ValidationGroup="valEquipment" ControlToCompare="txtCoverage_Start_Date"
                                                                                        Type="date" Operator="GreaterThanEqual" Display="None" ErrorMessage="Coverage End Date must be greater than or equal to Coverage Start Date">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                    <table style="display: none; width: 100%" id="tblOilWater" cellspacing="1" cellpadding="3"
                                                                        runat="server">
                                                                        <%--<tbody>--%>
                                                                            <tr>
                                                                                <td align="left" width="18%">
                                                                                    Flows to POTW
                                                                                </td>
                                                                                <td align="center" width="4%">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" width="28%">
                                                                                    <asp:RadioButtonList ID="rdoFlows_to_POTW" runat="server" SkinID="YesNoTypeNullSelection">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td align="left" colspan="3">
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td align="left" width="18%">
                                                                                                    Date of Last Service&nbsp;<span id="Span140" style="color: Red; display: none;" runat="server">*</span>
                                                                                                </td>
                                                                                                <td align="center" width="5%">
                                                                                                    :
                                                                                                </td>
                                                                                                <td align="left" width="28%">
                                                                                                    <asp:TextBox ID="txtDate_of_Last_Service" runat="server" Width="170px" MaxLength="10"
                                                                                                        EnableViewState="true" SkinID="txtdate"></asp:TextBox>
                                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_of_Last_Service', 'mm/dd/y');"
                                                                                                        alt="Date of Last Service" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                                    <asp:RangeValidator ID="rgvDate_of_Last_Service" ControlToValidate="txtDate_of_Last_Service"
                                                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                                                        ErrorMessage="Date of Last Service is not a valid date." runat="server" ValidationGroup="valEquipment"
                                                                                                        Display="none" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    TCLP on File
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:RadioButtonList ID="rdoTCLP_on_File" runat="server" SkinID="YesNoTypeNullSelection">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td align="left" width="18%">
                                                                                                    Date of Last TCLP&nbsp;<span id="Span141" style="color: Red; display: none;" runat="server">*</span>
                                                                                                </td>
                                                                                                <td align="center" width="5%">
                                                                                                    :
                                                                                                </td>
                                                                                                <td align="left" width="28%">
                                                                                                    <asp:TextBox ID="txtDate_of_Last_TCLP" runat="server" Width="170px" MaxLength="10"
                                                                                                        SkinID="txtdate" EnableViewState="true"></asp:TextBox>
                                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtDate_of_Last_TCLP', 'mm/dd/y');"
                                                                                                        alt="Date of Last TCLP" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                                    <asp:RangeValidator ID="rgvDate_of_Last_TCLP" ControlToValidate="txtDate_of_Last_TCLP"
                                                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                                                        ErrorMessage="Date of Last TCLP is not a valid date." runat="server" ValidationGroup="valEquipment"
                                                                                                        Display="none" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        <%--</tbody>--%>
                                                                    </table>
                                                                    <table width="100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width: 18%" align="left">
                                                                                    Installation Date&nbsp;<span id="Span9" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td style="width: 4%" align="center">
                                                                                    :
                                                                                </td>
                                                                                <td style="width: 28%" align="left">
                                                                                    <asp:TextBox ID="txtInstallation_Date" runat="server" Width="170px" MaxLength="10"
                                                                                        SkinID="txtdate" EnableViewState="true"></asp:TextBox>
                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtInstallation_Date', 'mm/dd/y');"
                                                                                        alt="Installation Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                    <asp:RangeValidator ID="rgvInstallation_Date" ControlToValidate="txtInstallation_Date"
                                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                                        ErrorMessage="Installation Date is not a valid date." runat="server" ValidationGroup="valEquipment"
                                                                                        Display="none" />
                                                                                </td>
                                                                                <td style="width: 18%" align="left">
                                                                                    Removal Date&nbsp;<span id="Span10" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td style="width: 4%" align="center">
                                                                                    :
                                                                                </td>
                                                                                <td style="width: 28%" align="left">
                                                                                    <asp:TextBox ID="txtRemoval_Date" runat="server" Width="170px" MaxLength="10" SkinID="txtdate"
                                                                                        EnableViewState="true"></asp:TextBox>
                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtRemoval_Date', 'mm/dd/y');"
                                                                                        alt="Removal Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                    <asp:RangeValidator ID="rgvRemoval_Date" ControlToValidate="txtRemoval_Date" MinimumValue="01/01/1753"
                                                                                        SetFocusOnError="true" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Removal Date is not a valid date."
                                                                                        runat="server" ValidationGroup="valEquipment" Display="none" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Closure Date&nbsp;<span id="Span11" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:TextBox ID="txtClosure_Date" runat="server" Width="170px" Rows="10" SkinID="txtdate"
                                                                                        EnableViewState="true"></asp:TextBox>
                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtClosure_Date', 'mm/dd/y');"
                                                                                        alt="Closure Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                    <asp:RangeValidator ID="rgvClosure_Date" ControlToValidate="txtClosure_Date" MinimumValue="01/01/1753"
                                                                                        SetFocusOnError="true" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Closure Date is not a valid date."
                                                                                        runat="server" ValidationGroup="valEquipment" Display="none" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Last Inspection Date&nbsp;<span id="Span12" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtLast_Inspection_Date" runat="server" Width="170px" MaxLength="10"
                                                                                        SkinID="txtdate" EnableViewState="true"></asp:TextBox>
                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtLast_Inspection_Date', 'mm/dd/y');"
                                                                                        alt="Last Inspection Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                    <asp:RangeValidator ID="rgvLast_Inspection_Date" ControlToValidate="txtLast_Inspection_Date"
                                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                                        ErrorMessage="Last Inspection Date is not a valid date." runat="server" ValidationGroup="valEquipment"
                                                                                        Display="none" />
                                                                                </td>
                                                                                <td align="left">
                                                                                    Next Inspection Date&nbsp;<span id="Span13" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtNext_Inspection_Date" runat="server" Width="170px" MaxLength="10"
                                                                                        SkinID="txtdate" EnableViewState="true"></asp:TextBox>
                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNext_Inspection_Date', 'mm/dd/y');"
                                                                                        alt="Next Inspection Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                    <asp:RangeValidator ID="rgvNext_Inspection_Date" ControlToValidate="txtNext_Inspection_Date"
                                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                                        ErrorMessage="Next Inspection Date is not a valid date." runat="server" ValidationGroup="valEquipment"
                                                                                        Display="none" />
                                                                                    <asp:CompareValidator ID="cmpvInpection_Date" runat="server" ControlToValidate="txtNext_Inspection_Date"
                                                                                        SetFocusOnError="true" ValidationGroup="valEquipment" ControlToCompare="txtLast_Inspection_Date"
                                                                                        Type="date" Operator="GreaterThanEqual" Display="None" ErrorMessage="Next Inspection Date must be greater than or equal to Last Inspection Date.">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Inspection Company&nbsp;<span id="Span14" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:TextBox ID="txtInspection_Company" runat="server" Width="170px" EnableViewState="true"
                                                                                        MaxLength="50"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Inspection Company<br />
                                                                                    Contact Name&nbsp;<span id="Span15" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtInspection_Contact" runat="server" Width="170px" MaxLength="50"
                                                                                        EnableViewState="true"></asp:TextBox>
                                                                                </td>
                                                                                <td align="left">
                                                                                    Inspection Company<br />
                                                                                    Contact Telephone Number<br />
                                                                                    (XXX-XXX-XXXX)&nbsp;<span id="Span16" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtInspection_Phone" runat="server" Width="170px" MaxLength="12"
                                                                                        EnableViewState="true" SkinID="txtphone"></asp:TextBox>
                                                                                    <asp:RegularExpressionValidator ID="revInspection_Phone" runat="server" ControlToValidate="txtInspection_Phone"
                                                                                        SetFocusOnError="true" Display="None" ErrorMessage="Inspection Company Contact Telephone Number must be in (XXX-XXX-XXXX) format."
                                                                                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ValidationGroup="valEquipment" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Registration Required
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:RadioButtonList ID="rdoRegistration_Required" runat="server" SkinID="YesNoTypeNullSelection">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td align="left">
                                                                                    Registration Number&nbsp;<span id="Span17" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtRegistration_Number" runat="server" Width="170px" EnableViewState="true"
                                                                                        MaxLength="50"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Certificate Number&nbsp;<span id="Span18" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:TextBox ID="txtCertificate_Number" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Permit Begin Date&nbsp;<span id="Span19" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtPermit_Begin_Date" runat="server" Width="170px" Rows="10" SkinID="txtdate"
                                                                                        EnableViewState="true"></asp:TextBox>
                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Begin_Date', 'mm/dd/y');"
                                                                                        alt="Permit Begin Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                    <asp:RangeValidator ID="rgvPermit_Begin_Date" ControlToValidate="txtPermit_Begin_Date"
                                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                                        ErrorMessage="Permit Begin Date is not a valid date." runat="server" ValidationGroup="valEquipment"
                                                                                        Display="none" />
                                                                                </td>
                                                                                <td align="left">
                                                                                    Permit End Date&nbsp;<span id="Span20" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtPermit_End_Date" runat="server" Width="170px" MaxLength="10"
                                                                                        SkinID="txtdate" EnableViewState="true"></asp:TextBox>
                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_End_Date', 'mm/dd/y');"
                                                                                        alt="Permit End Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                    <asp:RangeValidator ID="rgvPermit_End_Date" ControlToValidate="txtPermit_End_Date"
                                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                                        ErrorMessage="Permit End Date is not a valid date." runat="server" ValidationGroup="valEquipment"
                                                                                        Display="none" />
                                                                                    <asp:CompareValidator ID="cmpvPermit_Date" runat="server" ControlToValidate="txtPermit_End_Date"
                                                                                        SetFocusOnError="true" ValidationGroup="valEquipment" ControlToCompare="txtPermit_Begin_Date"
                                                                                        Type="date" Operator="GreaterThanEqual" Display="None" ErrorMessage="Permit End Date must be greater than or equal to Permit Start Date">
                                                                                    </asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Other Reporting Requirements?
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:RadioButtonList ID="rdoOther_Req" runat="server" SkinID="YesNoTypeNullSelection">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Description of Other Reporting Requirements&nbsp;<span id="Span21" style="color: Red;
                                                                                        display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <uc:ctrlMultiLineTextBox ID="txtOther_Req_Descr" runat="server" ControlType="TextBox">
                                                                                    </uc:ctrlMultiLineTextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    Next Report Date&nbsp;<span id="Span22" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <asp:TextBox ID="txtNext_Report_Date" runat="server" Width="170px" MaxLength="10"
                                                                                        EnableViewState="true" SkinID="txtdate"></asp:TextBox>
                                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtNext_Report_Date', 'mm/dd/y');"
                                                                                        alt="Next Report Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                                    <asp:RangeValidator ID="rgvNext_Report_Date" ControlToValidate="txtNext_Report_Date"
                                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                                        ErrorMessage="Next Report Date is not a valid date." runat="server" ValidationGroup="valEquipment"
                                                                                        Display="none" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" valign="top">
                                                                                    Notes&nbsp;<span id="Span23" style="color: Red; display: none;" runat="server">*</span>
                                                                                </td>
                                                                                <td align="center" valign="top">
                                                                                    :
                                                                                </td>
                                                                                <td align="left" colspan="4">
                                                                                    <uc:ctrlMultiLineTextBox ID="txtNotes" runat="server" ControlType="TextBox"></uc:ctrlMultiLineTextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="6">
                                                                                    <asp:Button ID="btnEquipmentSaveView" OnClick="btnEquipmentSaveView_Click" runat="server"
                                                                                        CausesValidation="true" Text="Save & Next" ValidationGroup="valEquipment"></asp:Button>
                                                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                                        Display="None" ValidationGroup="valEquipment" />
                                                                                    <input id="hdnControlIDs1" runat="server" type="hidden" />
                                                                                    <input id="hdnErrorMsgs1" runat="server" type="hidden" />
                                                                                    <asp:Button ID="btnEquipmentAuditView" runat="server" Text="View Audit Trail" Visible="false" />
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlInAdvertentRelease" runat="server" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Inadvertent Release Control and Countermeasures Plan</div>
                                                    <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Plan Identification&nbsp;<span id="Span24" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" colspan="4">
                                                                    <asp:TextBox ID="txtPlan_ID" runat="server" Width="170px" MaxLength="50" EnableViewState="true"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Effective Date&nbsp;<span id="Span25" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:TextBox ID="txtPlan_Effective_Date" runat="server" Width="170px" MaxLength="10"
                                                                        SkinID="txtdate" EnableViewState="true"></asp:TextBox>
                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPlan_Effective_Date', 'mm/dd/y');"
                                                                        alt="Plan Effective Date " src="../../Images/iconPicDate.gif" align="middle" />
                                                                    <asp:RangeValidator ID="rgvPlan_Effective_Date" ControlToValidate="txtPlan_Effective_Date"
                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                        ErrorMessage="Effective Date is not a valid date." runat="server" ValidationGroup="InadvertentRelease"
                                                                        Display="none" />
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    Expiration Date&nbsp;<span id="Span26" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:TextBox ID="txtPlan_Expiration_Date" runat="server" Width="170px" MaxLength="10"
                                                                        EnableViewState="true" SkinID="txtdate"></asp:TextBox>
                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPlan_Expiration_Date', 'mm/dd/y');"
                                                                        alt="Expiration Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                    <asp:RangeValidator ID="rgvPlan_Expiration_Date" ControlToValidate="txtPlan_Expiration_Date"
                                                                        SetFocusOnError="true" EnableViewState="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999"
                                                                        Type="Date" ErrorMessage="Expiration Date is not a valid date." runat="server"
                                                                        ValidationGroup="InadvertentRelease" Display="none" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Last Revision Date&nbsp;<span id="Span27" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtPlan_Revision_Date" runat="server" Width="170px" MaxLength="10"
                                                                        EnableViewState="true" SkinID="txtdate"></asp:TextBox>
                                                                    <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPlan_Revision_Date', 'mm/dd/y');"
                                                                        alt="Plan Revision Date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                    <asp:RangeValidator ID="rgvPlan_Revision_Date" ControlToValidate="txtPlan_Revision_Date"
                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                        ErrorMessage="Last Revision Date is not a valid date." runat="server" ValidationGroup="InadvertentRelease"
                                                                        Display="none" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Vendor&nbsp;<span id="Span28" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtPlan_Vendor" runat="server" Width="170px" MaxLength="50" EnableViewState="true"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Vendor Contact Name&nbsp;<span id="Span29" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtPlan_Vendor_Contact" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Vendor Contact Telephone Number (XXX-XXX-XXXX)&nbsp;<span id="Span30" style="color: Red;
                                                                        display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox ID="txtPlan_Phone" onkeypress="javascript:return FormatPhone(event,this.id);"
                                                                        runat="server" Width="170px" MaxLength="12" EnableViewState="true"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revtxtPlan_Phone" runat="server" ControlToValidate="txtPlan_Phone"
                                                                        SetFocusOnError="true" Display="None" ErrorMessage="Vendor Contact Telephone Number must be in (XXX-XXX-XXXX) format."
                                                                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ValidationGroup="InadvertentRelease" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="6">
                                                                    <asp:Button ID="btnInadvertentSaveView" OnClick="btnInadvertentSaveView_Click" runat="server"
                                                                        CausesValidation="true" Text="Save & Next" ValidationGroup="InadvertentRelease">
                                                                    </asp:Button>
                                                                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                        Display="None" ValidationGroup="InadvertentRelease" />
                                                                    <input id="hdnControlIDs2" runat="server" type="hidden" />
                                                                    <input id="hdnErrorMsgs2" runat="server" type="hidden" />
                                                                    <asp:Button ID="btnInadvertentAuditView" runat="server" Text="View Audit Trail" Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlEquipmentAttachmentDetail" runat="server">
                                                    <div class="bandHeaderRow">
                                                        Attachment Details</div>
                                                    <table width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td align="center">
                                                                    <uc:ctrlAttachmentDetails ID="EquipmentAttachmentDetail" runat="server" Visible="true">
                                                                    </uc:ctrlAttachmentDetails>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvEquipment" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="gvEquipment" EventName="RowDeleting"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="btnAddEquipment" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Panel ID="pnlEquipmentAttachment" runat="server" Width="100%">
                                            <div class="bandHeaderRow">
                                                Add Attachment
                                            </div>
                                            <table width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td align="center">
                                                            <uc:ctrlAttachment ID="EquipmentAttachment" runat="server"></uc:ctrlAttachment>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnEquipmentAttachmentSave" runat="server" ToolTip="Next" Text="Next"
                                                                OnClientClick="javascript:ShowPanel(4);return false;"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>
                                        <asp:UpdatePanel ID="updEquipmentRecommendations" runat="server" UpdateMode="Conditional"
                                            RenderMode="Inline">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlEquipmentRecommendations" runat="server" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Recommendations</div>
                                                    <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td valign="top" align="left">
                                                                    <asp:LinkButton ID="lnkRecommendation" runat="server" Text="--Add--" OnClick="lnkRecommendation_Click"></asp:LinkButton>
                                                                </td>
                                                                <td valign="top" align="left" colspan="5" style="width: 90%;">
                                                                    <asp:GridView ID="gvEquipmentRecommendation" runat="server" EmptyDataText="No record found"
                                                                        AutoGenerateColumns="false" DataKeyNames="PK_Enviro_Equipment_Recommendations_ID"
                                                                        OnRowEditing="gvEquipmentRecommendation_RowEditing" OnRowDeleting="gvEquipmentRecommendation_RowDeleting"
                                                                        Width="100%">
                                                                        <RowStyle Wrap="true" />
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Recommendation Number">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lblNumber" runat="server" Text='<%#Eval("Number") %>' CommandName="Edit"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="30%" HeaderText="Title">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lblTitle" runat="server" Text='<%#Eval("title") %>' CommandName="Edit"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="10%" HeaderText="Status">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lblStatus" runat="server" Text='<%#Eval("status") %>' CommandName="Edit"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="25%" HeaderText="Assigned To">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lblAssignedTo" runat="server" Text='<%#Eval("Assigned_to") %>'
                                                                                        CommandName="Edit" CommandArgument='<%# Eval("PK_Enviro_Equipment_Recommendations_ID")%>'></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="15%" HeaderText="Remove">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbtEquipmentRecommendationDelete" runat="server" Text="Remove"
                                                                                        CommandName="Delete" OnClientClick="return confirm('Are you sure your want to delete this Equipment Recommendatoin?');"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <asp:Panel ID="pnlAddEquipmentRecommendation" runat="server" Visible="false">
                                                        <div class="bandHeaderRow">
                                                            Individual Recommendation</div>
                                                        <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Date of visit&nbsp;<span id="Span31" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:TextBox ID="txtIndivial_Recommendation_Date" runat="server" Width="170px" SkinID="txtdate"
                                                                            EnableViewState="true" MaxLength="10"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIndivial_Recommendation_Date', 'mm/dd/y');"
                                                                            alt="Date of visit" src="../../Images/iconPicDate.gif" align="middle" />
                                                                        <%--<asp:RequiredFieldValidator ID="rfcIndivial_Recommendation_Date" runat="server" Display="None"
                                                                            ErrorMessage="Date of Visit must not be Empty." ControlToValidate="txtIndivial_Recommendation_Date"
                                                                            SetFocusOnError="true" ValidationGroup="EquipmentRecommendation">
                                                                        </asp:RequiredFieldValidator>--%>
                                                                        <asp:RangeValidator ID="rgvIndivial_Recommendation_Date" ControlToValidate="txtIndivial_Recommendation_Date"
                                                                            SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                            ErrorMessage="Date of visit is not a valid date." runat="server" ValidationGroup="EquipmentRecommendation"
                                                                            Display="none" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Number&nbsp;<span id="Span32" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:TextBox ID="txtIndivial_Recommendation_Number" runat="server" Width="170px"
                                                                            EnableViewState="true" MaxLength="50"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="rfvEquipmentRecommendationNumber" runat="server"
                                                                            Display="None" ErrorMessage="Recommendation Number must not be Empty." ControlToValidate="txtIndivial_Recommendation_Number"
                                                                            SetFocusOnError="true" ValidationGroup="EquipmentRecommendation">
                                                                        </asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Made by&nbsp;<span id="Span33" style="color: Red; display: none;"
                                                                            runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:TextBox ID="txtIndivial_Recommendation_Made_by" runat="server" Width="170px"
                                                                            EnableViewState="true" MaxLength="50"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="rfvEquipmentMadeBy" runat="server" Display="None"
                                                                            ErrorMessage="Recommendation Made By must not be Empty." ControlToValidate="txtIndivial_Recommendation_Made_by"
                                                                            SetFocusOnError="true" ValidationGroup="EquipmentRecommendation">
                                                                        </asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                    <td align="left" width="18%">
                                                                        Status&nbsp;<span id="Span34" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:DropDownList ID="ddlIndivial_Recommendation_status" runat="server" SkinID="ddlStatus"
                                                                            EnableViewState="true">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Title&nbsp;<span id="Span35" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:TextBox ID="txtIndivial_Recommendation_Title" runat="server" Width="170px" MaxLength="50"
                                                                            EnableViewState="true"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="rfvEquipmentTitle" runat="server" Display="None"
                                                                            ErrorMessage="Title must not be Empty." ControlToValidate="txtIndivial_Recommendation_Title"
                                                                            SetFocusOnError="true" ValidationGroup="EquipmentRecommendation">
                                                                        </asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Detailed Recommendation Description&nbsp;<span id="Span36" style="color: Red; display: none;"
                                                                            runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox ID="txtIndivial_Recommendation_description" runat="server"
                                                                            ControlType="TextBox"></uc:ctrlMultiLineTextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Name&nbsp;<span id="Span37" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtIndivial_Recommendation_Assigned_to" runat="server" Width="170px"
                                                                            EnableViewState="true" MaxLength="50"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left">
                                                                        Due date&nbsp;<span id="Span38" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtIndivial_Recommendation_Due_date" runat="server" Width="170px"
                                                                            EnableViewState="true" MaxLength="10" SkinID="txtdate"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIndivial_Recommendation_Due_date', 'mm/dd/y');"
                                                                            alt="Due date" src="../../Images/iconPicDate.gif" align="middle" />
                                                                        <asp:RangeValidator ID="rgvIndivial_Recommendation_Due_date" ControlToValidate="txtIndivial_Recommendation_Due_date"
                                                                            SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                            ErrorMessage="Due Date is not a valid date." runat="server" ValidationGroup="EquipmentRecommendation"
                                                                            Display="none" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Telephone(XXX-XXX-XXXX)&nbsp;<span id="Span39" style="color: Red; display: none;"
                                                                            runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:TextBox ID="txtIndivial_Recommendation_Assigned_to_phone" runat="server" Width="170px"
                                                                            EnableViewState="true" MaxLength="12" SkinID="txtPhone"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revAssignedToPhone" runat="server" ControlToValidate="txtIndivial_Recommendation_Assigned_to_phone"
                                                                            SetFocusOnError="true" Display="None" ErrorMessage="Assigned To Telephone number must be in (XXX-XXX-XXXX) format."
                                                                            ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ValidationGroup="EquipmentRecommendation">
                                                                        </asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To E-mail&nbsp;<span id="Span40" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:TextBox ID="txtIndivial_Recommendation_Assigned_to_email" runat="server" Width="170px"
                                                                            EnableViewState="true" MaxLength="50"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="revAssignedTomail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                            ValidationGroup="EquipmentRecommendation" Display="None" ErrorMessage="Assigned To E-mail is not valid"
                                                                            ControlToValidate="txtIndivial_Recommendation_Assigned_to_email" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Estimated Cost $&nbsp;<span id="Span41" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtEstimatedCost" runat="server" Width="170px" EnableViewState="true"
                                                                            MaxLength="17" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                    </td>
                                                                    <td align="left">
                                                                        Final Cost $&nbsp;<span id="Span42" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtFinalCost" runat="server" Width="170px" EnableViewState="true"
                                                                            MaxLength="17" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Resolution&nbsp;<span id="Span43" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox ID="txtIndivial_Recommendation_Resolution" runat="server"
                                                                            ControlType="TextBox"></uc:ctrlMultiLineTextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Date Closed&nbsp;<span id="Span44" style="color: Red; display: none;" runat="server">*</span>
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:TextBox ID="txtIndivial_Recommendation_Date_Closed" runat="server" Width="170px"
                                                                            EnableViewState="true" SkinID="txtdate"></asp:TextBox>
                                                                        <img onmouseover="javascript:this.style.cursor='hand';" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIndivial_Recommendation_Date_Closed', 'mm/dd/y');"
                                                                            alt="Date Closed" src="../../Images/iconPicDate.gif" align="middle" />
                                                                        <asp:RangeValidator ID="rgvIndivial_Recommendation_Date_Closed" ControlToValidate="txtIndivial_Recommendation_Date_Closed"
                                                                            SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                            ErrorMessage="Date Closed is not a valid date." runat="server" ValidationGroup="EquipmentRecommendation"
                                                                            Display="none" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </asp:Panel>
                                                    <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                        <tr>
                                                            <td align="center" colspan="6">
                                                                <asp:Button ID="btnRecommendationSave" OnClick="btnRecommendationSave_Click" runat="server"
                                                                    CausesValidation="true" Text="View" ValidationGroup="EquipmentRecommendation">
                                                                </asp:Button>
                                                                <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                    Display="None" ValidationGroup="EquipmentRecommendation" />
                                                                <input id="hdnControlIDs3" runat="server" type="hidden" />
                                                                <input id="hdnErrorMsgs3" runat="server" type="hidden" />
                                                                <asp:Button ID="btnEquipmentRevert" runat="server" Text="Revert and Return" OnClick="btnEquipmentRevert_Click"
                                                                    Visible="false"></asp:Button>
                                                                <asp:Button ID="btnRecommendationAudit" runat="server" Text="View Audit Trail" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvEquipment" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="gvEquipment" EventName="RowDeleting"></asp:AsyncPostBackTrigger>
                                                <asp:PostBackTrigger ControlID="btnRecommendationSave"></asp:PostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="btnAddEquipment" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="updPermit" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <asp:Panel runat="server" ID="pnlPermitInformation" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Permits</div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%">
                                                                Type&nbsp;<span id="Span45" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4">
                                                                <asp:TextBox runat="server" ID="txtPermit_Type" Width="170px" MaxLength="50" EnableViewState="true"></asp:TextBox>
                                                                <%--<asp:RequiredFieldValidator ID="rfvPermit_Type" runat="server" ErrorMessage="Type must not be Empty."
                                                                    ControlToValidate="txtPermit_Type" Display="None" ValidationGroup="valPermitInformation"
                                                                    SetFocusOnError="true">
                                                                </asp:RequiredFieldValidator>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%">
                                                                Permit Required?
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%">
                                                                <asp:RadioButtonList runat="server" ID="rdoPermit_required" SkinID="YesNoTypeNullSelection">
                                                                </asp:RadioButtonList>
                                                            </td>
                                                            <td align="left" width="18%">
                                                                Application Regulation Number&nbsp;<span id="Span46" style="color: Red; display: none;"
                                                                    runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%">
                                                                <asp:TextBox runat="server" ID="txtPermit_Application_number" Width="170px" MaxLength="50"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Certificate number&nbsp;<span id="Span47" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPermit_Certificate_number" Width="170px" MaxLength="50"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                Filing date&nbsp;<span id="Span48" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPermit_Filing_date" Width="170px" MaxLength="10"
                                                                    SkinID="txtdate"></asp:TextBox>
                                                                <asp:RangeValidator ID="rgvPermit_Filing_date" ControlToValidate="txtPermit_Filing_date"
                                                                    SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                    ErrorMessage="Permit Filling Date is not Valid Date" runat="server" ValidationGroup="valPermitInformation"
                                                                    Display="none" />
                                                                <img alt="Filing date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Filing_date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Permit Begin Date&nbsp;<span id="Span49" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPermit_Permit_Begin_date" Width="170px" MaxLength="10"
                                                                    SkinID="txtdate"></asp:TextBox>
                                                                <asp:RangeValidator ID="rgvPermit_Permit_Begin_date" ControlToValidate="txtPermit_Permit_Begin_date"
                                                                    SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                    ErrorMessage="Permit Begin Date is not Valid Date" runat="server" ValidationGroup="valPermitInformation"
                                                                    Display="none" />
                                                                <img alt="Permit Begin Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Permit_Begin_date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                            </td>
                                                            <td align="left">
                                                                Permit End Date&nbsp;<span id="Span50" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPermit_Permit_End_Date" Width="170px" MaxLength="10"
                                                                    SkinID="txtdate"></asp:TextBox>
                                                                <img alt="Permit Begin Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Permit_End_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RangeValidator ID="rgvPermit_Permit_End_Date" ControlToValidate="txtPermit_Permit_End_Date"
                                                                    SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                    ErrorMessage="Permit End Date is not Valid Date" runat="server" ValidationGroup="valPermitInformation"
                                                                    Display="none" />
                                                                <asp:CompareValidator ID="cmpPermit_PermitDate" runat="server" ControlToCompare="txtPermit_Permit_Begin_date"
                                                                    ControlToValidate="txtPermit_Permit_End_Date" ValidationGroup="valPermitInformation"
                                                                    SetFocusOnError="true" Display="None" ErrorMessage="Permit End Date must be greater than or equal to Permit Start Date"
                                                                    Type="Date" Operator="GreaterThanEqual">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Last Inspection date&nbsp;<span id="Span51" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPermit_Last_Inspection_date" Width="170px" MaxLength="10"
                                                                    SkinID="txtdate"></asp:TextBox>
                                                                <asp:RangeValidator ID="rgvPermit_Last_Inspection_date" ControlToValidate="txtPermit_Last_Inspection_date"
                                                                    SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                    ErrorMessage="Permit Last Inspection Date is not Valid Date" runat="server" ValidationGroup="valPermitInformation"
                                                                    Display="none" />
                                                                <img alt="Last Inspection date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Last_Inspection_date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                            </td>
                                                            <td align="left">
                                                                Next Inspection Date&nbsp;<span id="Span52" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPermit_Next_Inspection_Date" Width="170px" MaxLength="10"
                                                                    SkinID="txtdate"></asp:TextBox>
                                                                <asp:RangeValidator ID="rgvPermit_Next_Inspection_date" ControlToValidate="txtPermit_Next_Inspection_date"
                                                                    SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                    ErrorMessage="Permit Next Inspection Date is not Valid Date" runat="server" ValidationGroup="valPermitInformation"
                                                                    Display="none" />
                                                                <img alt="Next Inspection Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Next_Inspection_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:CompareValidator ID="cmpPermit_InspactionDate" runat="server" ControlToCompare="txtPermit_Last_Inspection_date"
                                                                    ControlToValidate="txtPermit_Next_Inspection_Date" ValidationGroup="valPermitInformation"
                                                                    SetFocusOnError="true" Display="None" ErrorMessage="Next inspection Date must be greater than or equal to last inspection Date"
                                                                    Type="Date" Operator="GreaterThanEqual">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%">
                                                                Next Report Date&nbsp;<span id="Span53" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4">
                                                                <asp:TextBox runat="server" ID="txtPermit_Next_Report_Date" Width="170px" MaxLength="10"
                                                                    SkinID="txtdate"></asp:TextBox>
                                                                <asp:RangeValidator ID="rgvPermit_Next_Report_Date" ControlToValidate="txtPermit_Next_Report_Date"
                                                                    SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                    ErrorMessage="Permit Next Report Date is not Valid Date" runat="server" ValidationGroup="valPermitInformation"
                                                                    Display="none" />
                                                                <img alt="Next Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Next_Report_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%" valign="top">
                                                                Notes&nbsp;<span id="Span54" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4">
                                                                <uc:ctrlMultiLineTextBox runat="server" ID="txtPermit_Notes" ControlType="TextBox" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="6">
                                                                <asp:Button runat="server" ID="btnPermit_Save" Text="Save & Next" OnClick="btnPermit_Save_Click"
                                                                    CausesValidation="true" ValidationGroup="valPermitInformation" />
                                                                <asp:CustomValidator ID="CustomValidator4" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                    Display="None" ValidationGroup="valPermitInformation" />
                                                                <input id="hdnControlIDs4" runat="server" type="hidden" />
                                                                <input id="hdnErrorMsgs4" runat="server" type="hidden" />
                                                                <asp:Button ID="btnPermitAudit" runat="server" Text="View Audit Trail" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlPermitAttachmentDetail" runat="server" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Attachment Details</div>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <uc:ctrlAttachmentDetails ID="PermitAttachmentDetails" runat="server" Visible="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvPermit" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="gvPermit" EventName="RowDeleting"></asp:AsyncPostBackTrigger>
                                                <asp:PostBackTrigger ControlID="btnPermit_RecommendationSave"></asp:PostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="lbtAddPermits" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Panel ID="pnlPermitAttachment" runat="server" Width="100%">
                                            <div class="bandHeaderRow">
                                                Add Attachment</div>
                                            <table width="100%">
                                                <tr>
                                                    <td>
                                                        <uc:ctrlAttachment ID="PermitAttachment" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btnPermitsAttachmentSave" runat="server" Text="Next" ToolTip="Next"
                                                            OnClientClick="javascript:ShowPanel(7);return false;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:UpdatePanel ID="updPermitRecommendation" runat="server" UpdateMode="Conditional"
                                            RenderMode="Inline">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlPermitRecommendations" runat="server" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Recommendations</div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <asp:LinkButton ID="lnkPermitRecommendation" runat="server" Text="--Add--" OnClick="lnkPermitRecommendation_Click"></asp:LinkButton>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 90%;">
                                                                <asp:GridView ID="gvPermitRecommendation" runat="server" EmptyDataText="No record found"
                                                                    AutoGenerateColumns="false" DataKeyNames="PK_Enviro_Equipment_Recommendations_ID"
                                                                    OnRowEditing="gvPermitRecommendation_RowEditing" OnRowDeleting="gvPermitRecommendation_RowDeleting"
                                                                    Width="100%">
                                                                    <RowStyle Wrap="true" />
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Recommendation Number">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblNumber" runat="server" Text='<%#Eval("Number") %>' CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="Title">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblTitle" runat="server" Text='<%#Eval("title") %>' CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="Status">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblStatus" runat="server" Text='<%#Eval("status") %>' CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="25%" HeaderText="Assigned To">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblAssignedTo" runat="server" Text='<%#Eval("Assigned_to") %>'
                                                                                    CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="15%" HeaderText="Remove">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtgvPermitRecommendationDelete" runat="server" Text="Remove"
                                                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure your want to delete this Permit Recommendation?');"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Panel ID="pnlPermitIndRecommendation" runat="server" Visible="false">
                                                        <div class="bandHeaderRow">
                                                            Individual Recommendation</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Date of visit&nbsp;<span id="Span55" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPermit_Indivial_Recommendation_Date" Width="170px"
                                                                        MaxLength="10" SkinID="txtdate"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvtxtPermit_Indivial_Recommendation_Date" runat="server"
                                                                        ControlToValidate="txtPermit_Indivial_Recommendation_Date" Display="none" ErrorMessage="Date of visit is not a valid date."
                                                                        SetFocusOnError="true" ValidationGroup="PermitRecommendation">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                    <asp:RangeValidator ID="rgvPermit_Indivial_Recommendation_Date" ControlToValidate="txtPermit_Indivial_Recommendation_Date"
                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                        ErrorMessage="Date of visit is not a valid date" runat="server" ValidationGroup="PermitRecommendation"
                                                                        Display="none" />
                                                                    <img alt="Date of visit" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Indivial_Recommendation_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Recommendation Number&nbsp;<span id="Span56" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPermit_Indivial_Recommendation_Number" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPermit_Indivial_Recommendation_Number" runat="server"
                                                                        ControlToValidate="txtPermit_Indivial_Recommendation_Number" Display="None" ErrorMessage="Recommendation Number must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="PermitRecommendation"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Recommendation Made by&nbsp;<span id="Span57" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:TextBox runat="server" ID="txtPermit_Indivial_Recommendation_Made_by" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPermit_Indivial_Recommendation_Made_by" runat="server"
                                                                        ControlToValidate="txtPermit_Indivial_Recommendation_Made_by" Display="None"
                                                                        SetFocusOnError="true" ErrorMessage="Recommendation Made by must not be Empty."
                                                                        ValidationGroup="PermitRecommendation"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    Status&nbsp;<span id="Span58" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:DropDownList runat="server" ID="ddlPermit_Indivial_Recommendation_status" SkinID="ddlStatus"
                                                                        EnableViewState="true">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Title&nbsp;<span id="Span59" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPermit_Indivial_Recommendation_Title" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPermit_Indivial_Recommendation_Title" runat="server"
                                                                        ControlToValidate="txtPermit_Indivial_Recommendation_Title" Display="None" ErrorMessage="Title by must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="PermitRecommendation"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Detailed Recommendation Description&nbsp;<span id="Span60" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtPermit_Indivial_Recommendation_description"
                                                                        ControlType="TextBox" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To Name&nbsp;<span id="Span61" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtPermit_Indivial_Recommendation_Assigned_to" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Due date&nbsp;<span id="Span62" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtPermit_Indivial_Recommendation_Due_date" Width="170px"
                                                                        SkinID="txtdate" MaxLength="10"></asp:TextBox>
                                                                    <asp:RangeValidator ID="rgvPermit_Indivial_Recommendation_Due_date" ControlToValidate="txtPermit_Indivial_Recommendation_Due_date"
                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                        ErrorMessage="Due Date is not a valid date." runat="server" ValidationGroup="PermitRecommendation"
                                                                        Display="none" />
                                                                    <img alt="Due date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Indivial_Recommendation_Due_date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To Telephone(XXX-XXX-XXXX)&nbsp;<span id="Span63" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPermit_Indivial_Recommendation_Assigned_to_phone"
                                                                        Width="170px" SkinID="txtPhone" MaxLength="12"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPermit_Indivial_Recommendation_Assigned_to_phone"
                                                                        runat="server" ControlToValidate="txtPermit_Indivial_Recommendation_Assigned_to_phone"
                                                                        SetFocusOnError="true" Display="None" ErrorMessage="Assigned To Telephone number must be in (XXX-XXX-XXXX) format."
                                                                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ValidationGroup="PermitRecommendation">
                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To E-mail&nbsp;<span id="Span64" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPermit_Indivial_Recommendation_Assigned_to_email"
                                                                        Width="170px" MaxLength="50"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPermit_Indivial_Recommendation_Assigned_to_email"
                                                                        runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                        ValidationGroup="PermitRecommendation" Display="None" ErrorMessage="Assigned To E-mail is not valid."
                                                                        SetFocusOnError="true" ControlToValidate="txtPermit_Indivial_Recommendation_Assigned_to_email"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Estimated Cost $&nbsp;<span id="Span65" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtPermitEstimetedCost" runat="server" Width="170px" EnableViewState="true"
                                                                        MaxLength="17" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Final Cost $&nbsp;<span id="Span66" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtPermitFinalCost" runat="server" Width="170px" EnableViewState="true"
                                                                        MaxLength="17" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Resolution&nbsp;<span id="Span67" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtPermit_Indivial_Recommendation_Resolution"
                                                                        ControlType="TextBox" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Date Closed&nbsp;<span id="Span68" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPermit_Indivial_Recommendation_Date_Closed" Width="170px"
                                                                        SkinID="txtdate" MaxLength="10"></asp:TextBox>
                                                                    <asp:RangeValidator ID="rgvPermit_Indivial_Recommendation_Date_Closed" ControlToValidate="txtPermit_Indivial_Recommendation_Date_Closed"
                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                        ErrorMessage="Date Closed is not a valid date." runat="server" ValidationGroup="PermitRecommendation"
                                                                        Display="none" />
                                                                    <img alt="Date Closed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPermit_Indivial_Recommendation_Date_Closed', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button runat="server" ID="btnPermit_RecommendationSave" Text="View" OnClick="btnPermit_RecommendationSave_Click"
                                                                    CausesValidation="true" ValidationGroup="PermitRecommendation" />
                                                                <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                    Display="None" ValidationGroup="PermitRecommendation" />
                                                                <input id="hdnControlIDs5" runat="server" type="hidden" />
                                                                <input id="hdnErrorMsgs5" runat="server" type="hidden" />
                                                                <asp:Button ID="btnPermitRecommendationRevort" runat="server" Text="Revert and Return"
                                                                    OnClick="btnPermitRecommendationRevort_Click" Visible="false"></asp:Button>
                                                                <asp:Button ID="btnPermit_RecommendationAudit" runat="server" Text="View Audit Trail"
                                                                    Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvPermit" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="gvPermit" EventName="RowDeleting"></asp:AsyncPostBackTrigger>
                                                <asp:PostBackTrigger ControlID="btnPermit_RecommendationSave"></asp:PostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="lbtAddPermits" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="updAudit" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <asp:Panel runat="server" ID="pnlAudit" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Audits/Inspections</div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%">
                                                                Frequency&nbsp;<span id="Span69" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4">
                                                                <asp:TextBox runat="server" ID="txtAudit_Frequency" Width="170px" MaxLength="50"
                                                                    EnableViewState="true"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%">
                                                                Last Inspection Date&nbsp;<span id="Span70" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%">
                                                                <asp:TextBox runat="server" ID="txtAudit_Last_Date" Width="170px" MaxLength="10"
                                                                    SkinID="txtdate" EnableViewState="true"></asp:TextBox>
                                                                <img alt="Last Inspection Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAudit_Last_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RangeValidator ID="rgvAudit_Last_Date" runat="server" ControlToValidate="txtAudit_Last_Date"
                                                                    SetFocusOnError="true" ErrorMessage="Last Inspection Date is not valid." Display="None"
                                                                    Type="date" MinimumValue="01/01/1753" MaximumValue="12/31/9999" ValidationGroup="valAuditInfo">
                                                                </asp:RangeValidator>
                                                            </td>
                                                            <td align="left" width="18%">
                                                                Next Inspection Date&nbsp;<span id="Span71" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%">
                                                                <asp:TextBox runat="server" ID="txtAudit_Next_Date" Width="170px" MaxLength="10"
                                                                    EnableViewState="true" SkinID="txtdate"></asp:TextBox>
                                                                <img alt="Next Inspection Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAudit_Next_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RangeValidator ID="rgvAudit_Next_Date" runat="server" ControlToValidate="txtAudit_Next_Date"
                                                                    SetFocusOnError="true" ErrorMessage="Next Inspection Date is not valid." Display="None"
                                                                    Type="date" MinimumValue="01/01/1753" MaximumValue="12/31/9999" ValidationGroup="valAuditInfo">
                                                                </asp:RangeValidator>
                                                                <asp:CompareValidator ID="cmpvAudit_Next_Date" runat="server" ControlToValidate="txtAudit_Next_Date"
                                                                    SetFocusOnError="true" ValidationGroup="valAuditInfo" ControlToCompare="txtAudit_Last_Date"
                                                                    Type="date" Operator="GreaterThanEqual" Display="None" ErrorMessage="Next Inspection Date must be greater than or equal to Last Inspection Date">
                                                                </asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Next Report Date&nbsp;<span id="Span72" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtAudits_Next_Report_Date" Width="170px" MaxLength="10"
                                                                    EnableViewState="true" SkinID="txtdate"></asp:TextBox>
                                                                <img alt="Next Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAudits_Next_Report_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RangeValidator ID="rgvAudits_Next_Report_Date" runat="server" ControlToValidate="txtAudits_Next_Report_Date"
                                                                    SetFocusOnError="true" ErrorMessage="Next Report Date is not valid." Display="None"
                                                                    Type="date" MinimumValue="01/01/1753" MaximumValue="12/31/9999" ValidationGroup="valAuditInfo">
                                                                </asp:RangeValidator>
                                                            </td>
                                                            <td align="left">
                                                                Cost&nbsp;<span id="Span73" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtAudit_Cost" Width="170px" EnableViewState="true"
                                                                    MaxLength="18"></asp:TextBox>
                                                                <asp:CustomValidator ID="cstvAudit_Cost" runat="server" ControlToValidate="txtAudit_Cost"
                                                                    SetFocusOnError="true" ClientValidationFunction="CheckIsNumeric" ValidationGroup="valAuditInfo"
                                                                    ErrorMessage="Not a valid Number" Display="None">
                                                                </asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notes&nbsp;<span id="Span74" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4">
                                                                <uc:ctrlMultiLineTextBox runat="server" ID="txtAudit_Notes" ControlType="TextBox" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="6">
                                                                <asp:Button runat="server" ID="btnAudit_Save" Text="Save & Next" OnClick="btnAudit_Save_Click"
                                                                    ValidationGroup="valAuditInfo" />
                                                                <asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                    Display="None" ValidationGroup="valAuditInfo" />
                                                                <input id="hdnControlIDs6" runat="server" type="hidden" />
                                                                <input id="hdnErrorMsgs6" runat="server" type="hidden" />
                                                                <asp:Button ID="btnInspection_Audit" runat="server" Text="View Audit Trail" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlAuditAttachmentDetail" runat="server" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Attachment Details</div>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <uc:ctrlAttachmentDetails ID="AuditAttachmentDetails" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvAudit" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="gvAudit" EventName="RowDeleting"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="lbtAuditsAdd" EventName="Click" />
                                                <asp:PostBackTrigger ControlID="btnAudit_RecommendationSave"></asp:PostBackTrigger>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Panel ID="pnlAuditAttachment" runat="server" Width="100%">
                                            <div class="bandHeaderRow">
                                                Add Attachment</div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <uc:ctrlAttachment ID="AuditAttachment" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btnAuditAttachmentSave" runat="server" Text="Next" ToolTip="Next"
                                                            OnClientClick="javascript:ShowPanel(10);return false;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:UpdatePanel ID="updAuditRecommendation" runat="server" UpdateMode="Conditional"
                                            RenderMode="Inline">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlAuditRecommendations" runat="server" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Recommendations</div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <asp:LinkButton ID="lnkAddAuditRecommendation" runat="server" Text="--Add--" OnClick="lnkAddAuditRecommendation_Click"> </asp:LinkButton>
                                                            </td>
                                                            <td align="left" valign="top" colspan="5" style="width: 90%;">
                                                                <asp:GridView ID="gvAuditRecommendation" runat="server" EmptyDataText="No record found"
                                                                    AutoGenerateColumns="false" DataKeyNames="PK_Enviro_Equipment_Recommendations_ID"
                                                                    Width="100%" OnRowEditing="gvAuditRecommendation_RowEditing" OnRowDeleting="gvAuditRecommendation_RowDeleting">
                                                                    <RowStyle Wrap="true" />
                                                                    <Columns>
                                                                        <asp:TemplateField ItemStyle-Width="20%" HeaderText="Recommendation Number">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblAudit_Number" runat="server" Text='<%#Eval("Number") %>' CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="30%" HeaderText="Title">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblAudit_Title" runat="server" Text='<%#Eval("title") %>' CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="10%" HeaderText="Status">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblAudit_Status" runat="server" Text='<%#Eval("status") %>' CommandName="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="25%" HeaderText="Assigned To">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lblAudit_AssignedTo" runat="server" Text='<%#Eval("Assigned_to") %>'
                                                                                    CommandName="Edit" CommandArgument='<%# Eval("PK_Enviro_Equipment_Recommendations_ID")%>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField ItemStyle-Width="15%" HeaderText="Remove">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtEquipmentRecommendationDelete" runat="server" Text="Remove"
                                                                                    CommandName="Delete" OnClientClick="return confirm('Are you sure your want to delete this Audit Recommendatoin?');"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Panel ID="pnlAuditIndRecommendations" runat="server" Width="100%" Visible="false">
                                                        <div class="bandHeaderRow">
                                                            Individual Recommendation</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Date of visit&nbsp;<span id="Span75" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtAudit_Indivial_Recommendation_Date" Width="170px"
                                                                        MaxLength="10" EnableViewState="true" SkinID="txtdate"></asp:TextBox>
                                                                    <img alt="Date of visit" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAudit_Indivial_Recommendation_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <%--<asp:RequiredFieldValidator ID="rfvAudit_Indivial_Recommendation_Date" runat="server"
                                                                        ControlToValidate="txtAudit_Indivial_Recommendation_Date" Display="none" ErrorMessage="Date of visit is not a valid date."
                                                                        SetFocusOnError="true" ValidationGroup="AuditRecommendation">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                    <asp:RangeValidator ID="rgvAudit_Indivial_Recommendation_Date" ControlToValidate="txtAudit_Indivial_Recommendation_Date"
                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                        ErrorMessage="Date of visit is not a valid date" runat="server" ValidationGroup="AuditRecommendation"
                                                                        Display="none" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Recommendation Number&nbsp;<span id="Span76" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtAudit_Indivial_Recommendation_Number" Width="170px"
                                                                        MaxLength="50" EnableViewState="true"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvAudit_Indivial_Recommendation_Number" runat="server"
                                                                        ControlToValidate="txtAudit_Indivial_Recommendation_Number" Display="None" ErrorMessage="Recommendation Number must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="AuditRecommendation"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Recommendation Made by&nbsp;<span id="Span77" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:TextBox runat="server" ID="txtAudit_Indivial_Recommendation_Made_by" Width="170px"
                                                                        MaxLength="50" EnableViewState="true"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvAudit_Indivial_Recommendation_Made_by" runat="server"
                                                                        ControlToValidate="txtAudit_Indivial_Recommendation_Made_by" Display="None" ErrorMessage="Recommendation Made by must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="AuditRecommendation"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    Status&nbsp;<span id="Span78" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:DropDownList runat="server" ID="ddlAudit_Indivial_Recommendation_status" SkinID="ddlStatus"
                                                                        EnableViewState="true">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Title&nbsp;<span id="Span79" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtAudit_Indivial_Recommendation_Title" Width="170px"
                                                                        MaxLength="50" EnableViewState="true"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvAudit_Indivial_Recommendation_Title" runat="server"
                                                                        ControlToValidate="txtAudit_Indivial_Recommendation_Title" Display="None" ErrorMessage="Recommendation Title must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="AuditRecommendation"></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Detailed Recommendation Description&nbsp;<span id="Span80" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtAudit_Indivial_Recommendation_description"
                                                                        ControlType="TextBox" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To Name&nbsp;<span id="Span81" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtAudit_Indivial_Recommendation_Assigned_to" Width="170px"
                                                                        MaxLength="50" EnableViewState="true"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Due date&nbsp;<span id="Span82" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtAudit_Indivial_Recommendation_Due_date" Width="170px"
                                                                        SkinID="txtdate" MaxLength="10" EnableViewState="true"></asp:TextBox>
                                                                    <img alt="Due date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAudit_Indivial_Recommendation_Due_date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <asp:RangeValidator ID="rgvAudit_Indivial_Recommendation_Due_date" ControlToValidate="txtAudit_Indivial_Recommendation_Due_date"
                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                        ErrorMessage="Due Date is not a valid date." runat="server" ValidationGroup="AuditRecommendation"
                                                                        Display="none" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To Telephone(XXX-XXX-XXXX)&nbsp;<span id="Span83" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtAudit_Indivial_Recommendation_Assigned_to_phone"
                                                                        MaxLength="12" EnableViewState="true" Width="170px" SkinID="txtPhone"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revAudit_Indivial_Recommendation_Assigned_to_phone"
                                                                        runat="server" ControlToValidate="txtAudit_Indivial_Recommendation_Assigned_to_phone"
                                                                        SetFocusOnError="true" Display="None" ErrorMessage="Assigned To Telephone number must be in (XXX-XXX-XXXX) format."
                                                                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ValidationGroup="AuditRecommendation">
                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To E-mail&nbsp;<span id="Span84" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtAudit_Indivial_Recommendation_Assigned_to_email"
                                                                        MaxLength="50" EnableViewState="true" Width="170px"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revAudit_Indivial_Recommendation_Assigned_to_email"
                                                                        runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                        ValidationGroup="AuditRecommendation" Display="None" ErrorMessage="Assigned To E-mail is not valid."
                                                                        SetFocusOnError="true" ControlToValidate="txtAudit_Indivial_Recommendation_Assigned_to_email"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Estimated Cost $&nbsp;<span id="Span85" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtAuditEstimetedCost" runat="server" Width="170px" EnableViewState="true"
                                                                        MaxLength="17" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Final Cost $&nbsp;<span id="Span86" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtAuditFinalCost" runat="server" Width="170px" EnableViewState="true"
                                                                        MaxLength="17" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Resolution&nbsp;<span id="Span87" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtAudit_Indivial_Recommendation_Resolution"
                                                                        ControlType="TextBox" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Date Closed&nbsp;<span id="Span88" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtAudit_Indivial_Recommendation_Date_Closed" Width="170px"
                                                                        SkinID="txtdate" MaxLength="10" EnableViewState="true"></asp:TextBox>
                                                                    <img alt="Date Closed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtAudit_Indivial_Recommendation_Date_Closed', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <asp:RangeValidator ID="rgvAudit_Indivial_Recommendation_Date_Closed" ControlToValidate="txtAudit_Indivial_Recommendation_Date_Closed"
                                                                        SetFocusOnError="true" MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date"
                                                                        ErrorMessage="Date Closed is not a valid date." runat="server" ValidationGroup="AuditRecommendation"
                                                                        Display="none" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button runat="server" ID="btnAudit_RecommendationSave" Text="View" OnClick="btnAudit_RecommendationSave_Click"
                                                                    CausesValidation="true" ValidationGroup="AuditRecommendation" />
                                                                <asp:CustomValidator ID="CustomValidator7" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                    Display="None" ValidationGroup="AuditRecommendation" />
                                                                <input id="hdnControlIDs7" runat="server" type="hidden" />
                                                                <input id="hdnErrorMsgs7" runat="server" type="hidden" />
                                                                <asp:Button ID="btnAuditRecommendationRevort" runat="server" Text="Revert and Return"
                                                                    OnClick="btnAuditRecommendationRevort_Click" Visible="false"></asp:Button>
                                                                <asp:Button ID="btnAudit_RecommendationAudit" runat="server" Text="View Audit Trail"
                                                                    Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvAudit" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="gvAudit" EventName="RowDeleting"></asp:AsyncPostBackTrigger>
                                                <asp:PostBackTrigger ControlID="btnAudit_RecommendationSave"></asp:PostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="lbtAuditsAdd" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="updSPCC" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                            <ContentTemplate>
                                                <asp:Panel runat="server" ID="pnlSPCC" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        SPCC Information</div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%">
                                                                Plan Preparer&nbsp;<span id="Span89" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" style="width: 28%">
                                                                <asp:TextBox runat="server" ID="txtPreparer" Width="170px" MaxLength="50">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td align="left" width="18%">
                                                                Telephone&nbsp;<span id="Span90" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" style="width: 28%">
                                                                <asp:TextBox runat="server" ID="txtphone" Width="170px" MaxLength="12" SkinID="txtPhone">
                                                                </asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtphone"
                                                                    SetFocusOnError="true" ErrorMessage="Telephone must be in (XXX-XXX-XXXX) format."
                                                                    ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ValidationGroup="valSPCCInfo"
                                                                    Display="None">
                                                                </asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Plan Date&nbsp;<span id="Span91" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPlan_date" Width="170px" SkinID="txtDate" MaxLength="10">
                                                                </asp:TextBox>
                                                                <img alt="Plan Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPlan_date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RangeValidator ID="rgvSPCCPlanDate" runat="server" ControlToValidate="txtPlan_date"
                                                                    SetFocusOnError="true" ErrorMessage="Plan Date is not Valid" Display="None" Type="Date"
                                                                    ValidationGroup="valSPCCInfo" MaximumValue="12/31/9999" MinimumValue="01/01/1753">
                                                                </asp:RangeValidator>
                                                            </td>
                                                            <td align="left">
                                                                Next Review Date&nbsp;<span id="Span92" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPlan_Next_Date" Width="170px" MaxLength="10" SkinID="txtDate">
                                                                </asp:TextBox>
                                                                <img alt="Next Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPlan_Next_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RangeValidator ID="rgvPlan_Next_Date" runat="server" ControlToValidate="txtPlan_Next_Date"
                                                                    SetFocusOnError="true" ErrorMessage="Next Date is not Valid." Display="None"
                                                                    Type="Date" ValidationGroup="valSPCCInfo" MaximumValue="12/31/9999" MinimumValue="01/01/1753">
                                                                </asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Next Report Date&nbsp;<span id="Span93" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPlan_Next_Report_Date" Width="170px" MaxLength="10"
                                                                    SkinID="txtDate">
                                                                </asp:TextBox>
                                                                <img alt="Next Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPlan_Next_Report_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RangeValidator ID="rgvPlan_Next_Report_Date" runat="server" ControlToValidate="txtPlan_Next_Report_Date"
                                                                    SetFocusOnError="true" ErrorMessage="Next Report Date is not Valid." Display="None"
                                                                    Type="Date" ValidationGroup="valSPCCInfo" MaximumValue="12/31/9999" MinimumValue="01/01/1753">
                                                                </asp:RangeValidator>
                                                            </td>
                                                            <td align="left">
                                                                Cost&nbsp;<span id="Span94" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPlan_Cost" Width="170px" MaxLength="18">
                                                                </asp:TextBox>
                                                                <asp:CustomValidator ID="csmvPlan_Cost" runat="server" ControlToValidate="txtPlan_Cost"
                                                                    SetFocusOnError="true" ClientValidationFunction="CheckIsNumeric" ValidationGroup="valSPCCInfo"
                                                                    ErrorMessage="Cost must be Numeric." Display="None">
                                                                </asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notes&nbsp;<span id="Span95" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4">
                                                                <uc:ctrlMultiLineTextBox runat="server" ID="txtPlan_Notes" ControlType="TextBox" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="6">
                                                                <asp:Button runat="server" ID="btnPlan_Save" Text="Save & Next" OnClick="btnPlan_Save_Click"
                                                                    ValidationGroup="valSPCCInfo" />
                                                                <asp:CustomValidator ID="CustomValidator8" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                    Display="None" ValidationGroup="valSPCCInfo" />
                                                                <input id="hdnControlIDs8" runat="server" type="hidden" />
                                                                <input id="hdnErrorMsgs8" runat="server" type="hidden" />
                                                                <asp:Button ID="btnPlan_Audit" runat="server" Text="View Audit Trail" Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlSPCCAttachmentDeatil" runat="server" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Attachment Details</div>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <uc:ctrlAttachmentDetails ID="PlanAttachmentDetails" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvSPCC" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="gvSPCC" EventName="RowDeleting"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="lbtAddSPCC" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Panel ID="pnlSPCCAttachment" runat="server" Width="100%">
                                            <div class="bandHeaderRow">
                                                Add Attachment</div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <uc:ctrlAttachment ID="PlanAttachment" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btnSPCCAttachmentSave" runat="server" Text="Next" ToolTip="Next"
                                                            OnClientClick="javascript:ShowPanel(13);return false;" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:UpdatePanel ID="updSPCCRecommendation" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlSPCCRecommendations" runat="server" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Recommendations</div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <asp:LinkButton ID="lnkPlanRecommendation" runat="server" Text="--Add--" OnClick="lnkPlanRecommendation_Click">
                                                                </asp:LinkButton>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 90%;">
                                                                <asp:GridView ID="gvPlanRecommendation" runat="server" EmptyDataText="No record found"
                                                                    AutoGenerateColumns="false" OnRowDeleting="gvPlanRecommendation_RowDeleting"
                                                                    DataKeyNames="PK_Enviro_Equipment_Recommendations_ID" OnRowEditing="gvPlanRecommendation_RowEditing"
                                                                    Width="100%">
                                                                    <RowStyle Wrap="true" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Number" ItemStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtPlanNumber" runat="server" CommandName="Edit" Text='<%#Eval("Number")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Title" ItemStyle-Width="30%">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtPlanTitle" runat="server" CommandName="Edit" Text='<%#Eval("title")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Staus" ItemStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtPlanstatus" runat="server" CommandName="Edit" Text='<%#Eval("status")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Assigned To" ItemStyle-Width="25%">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtPlanAssigned_to" runat="server" CommandName="Edit" Text='<%#Eval("Assigned_to")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove" ItemStyle-Width="15%">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtPlanDelete" runat="server" CommandName="Delete" Text="Remove"
                                                                                    OnClientClick="return confirm('Are you sure your want to delete this SPCC Recommendatoin?');">
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Panel ID="pnlSPCCIndRecommendation" runat="server" Visible="false">
                                                        <div class="bandHeaderRow">
                                                            Individual Recommendation</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Date of visit&nbsp;<span id="Span96" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPlan_Indivial_Recommendation_Date" Width="170px"
                                                                        SkinID="txtdate" MaxLength="10">
                                                                    </asp:TextBox>
                                                                    <img alt="Date of visit" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPlan_Indivial_Recommendation_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPlan_Indivial_Recommendation_Date" runat="server"
                                                                        ControlToValidate="txtPlan_Indivial_Recommendation_Date" Display="None" ErrorMessage="Date of visit must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="valPlanInfo">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                    <asp:RangeValidator ID="rgvPlan_Indivial_Recommendation_Date" runat="server" ControlToValidate="txtPlan_Indivial_Recommendation_Date"
                                                                        SetFocusOnError="true" Type="Date" Display="None" ErrorMessage="Date of visit is not Valid Date."
                                                                        ValidationGroup="valPlanInfo" MaximumValue="12/31/9999" MinimumValue="01/01/1753">
                                                                    </asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Recommendation Number&nbsp;<span id="Span97" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPlan_Indivial_Recommendation_Number" Width="170px"
                                                                        MaxLength="50">
                                                                    </asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPlan_Indivial_Recommendation_Number" runat="server"
                                                                        ControlToValidate="txtPlan_Indivial_Recommendation_Number" Display="None" ErrorMessage="Recommendation Number must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="valPlanInfo">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Recommendation Made by&nbsp;<span id="Span98" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:TextBox runat="server" ID="txtPlan_Indivial_Recommendation_Made_by" Width="170px"
                                                                        MaxLength="50">
                                                                    </asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPlan_Indivial_Recommendation_Made_by" runat="server"
                                                                        ControlToValidate="txtPlan_Indivial_Recommendation_Made_by" Display="None" ErrorMessage="Recommendation Made by must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="valPlanInfo">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    Status&nbsp;<span id="Span99" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:DropDownList runat="server" ID="ddlPlan_Indivial_Recommendation_status" SkinID="ddlStatus">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Title&nbsp;<span id="Span100" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPlan_Indivial_Recommendation_Title" Width="170px"
                                                                        MaxLength="50">
                                                                    </asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPlan_Indivial_Recommendation_Title" runat="server"
                                                                        ControlToValidate="txtPlan_Indivial_Recommendation_Title" Display="None" ErrorMessage="Recommendation Title must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="valPlanInfo">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Detailed Recommendation Description&nbsp;<span id="Span101" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtPlan_Indivial_Recommendation_description"
                                                                        ControlType="TextBox" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To Name&nbsp;<span id="Span102" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtPlan_Indivial_Recommendation_Assigned_to" Width="170px"
                                                                        MaxLength="50">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Due date&nbsp;<span id="Span103" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtPlan_Indivial_Recommendation_Due_date" Width="170px"
                                                                        MaxLength="10" SkinID="txtdate">
                                                                    </asp:TextBox>
                                                                    <img alt="Due date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPlan_Indivial_Recommendation_Due_date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <asp:RangeValidator ID="rgvPlan_Indivial_Recommendation_Due_date" runat="server"
                                                                        ControlToValidate="txtPlan_Indivial_Recommendation_Due_date" Type="Date" Display="None"
                                                                        SetFocusOnError="true" ErrorMessage="Due Date is not Valid Date." ValidationGroup="valPlanInfo"
                                                                        MaximumValue="12/31/9999" MinimumValue="01/01/1753">
                                                                    </asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To Telephone(XXX-XXX-XXXX)&nbsp;<span id="Span104" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPlan_Indivial_Recommendation_Assigned_to_phone"
                                                                        Width="170px" MaxLength="12" SkinID="txtphone">
                                                                    </asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPlan_Indivial_Recommendation_Assigned_to_phone"
                                                                        runat="server" ControlToValidate="txtPlan_Indivial_Recommendation_Assigned_to_phone"
                                                                        SetFocusOnError="true" Display="None" ErrorMessage="Assigned To Telephone number must be in (XXX-XXX-XXXX) format."
                                                                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ValidationGroup="valPlanInfo">
                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To E-mail&nbsp;<span id="Span105" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPlan_Indivial_Recommendation_Assigned_to_email"
                                                                        Width="170px" MaxLength="50">
                                                                    </asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPlan_Indivial_Recommendation_Assigned_to_email"
                                                                        runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                        ValidationGroup="valPlanInfo" Display="None" ErrorMessage="Assigned To E-mail is not valid."
                                                                        SetFocusOnError="true" ControlToValidate="txtPlan_Indivial_Recommendation_Assigned_to_email"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Estimated Cost $&nbsp;<span id="Span106" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtSPCEstimatedCost" runat="server" Width="170px" EnableViewState="true"
                                                                        MaxLength="17" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Final Cost $&nbsp;<span id="Span107" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtSPCFinalCost" runat="server" Width="170px" EnableViewState="true"
                                                                        MaxLength="17" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Resolution&nbsp;<span id="Span108" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtPlan_Indivial_Recommendation_Resolution"
                                                                        ControlType="TextBox" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Date Closed&nbsp;<span id="Span109" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPlan_Indivial_Recommendation_Date_Closed" Width="170px"
                                                                        MaxLength="10" SkinID="txtdate">
                                                                    </asp:TextBox>
                                                                    <img alt="Date Closed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPlan_Indivial_Recommendation_Date_Closed', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <asp:RangeValidator ID="rgvPlan_Indivial_Recommendation_Date_Closed" runat="server"
                                                                        ControlToValidate="txtPlan_Indivial_Recommendation_Date_Closed" Type="Date" Display="None"
                                                                        SetFocusOnError="true" ErrorMessage="Date Closed is not Valid Date." ValidationGroup="valPlanInfo"
                                                                        MaximumValue="12/31/9999" MinimumValue="01/01/1753">
                                                                    </asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center" width="100%">
                                                                <asp:Button runat="server" ID="btnPlan_RecommendationSave" Text="View" OnClick="btnPlan_RecommendationSave_Click"
                                                                    ValidationGroup="valPlanInfo" />
                                                                <asp:CustomValidator ID="CustomValidator9" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                    Display="None" ValidationGroup="valPlanInfo" />
                                                                <input id="hdnControlIDs9" runat="server" type="hidden" />
                                                                <input id="hdnErrorMsgs9" runat="server" type="hidden" />
                                                                <asp:Button runat="server" ID="btnPlan_RecommendationRevert" Text="Revert & Return"
                                                                    OnClick="btnPlan_RecommendationRevert_Click" Visible="false" />
                                                                <asp:Button ID="btnPlan_RecommendationAudit" runat="server" Text="View Audit Trail"
                                                                    Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvSPCC" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="gvSPCC" EventName="RowDeleting"></asp:AsyncPostBackTrigger>
                                                <asp:PostBackTrigger ControlID="btnPlan_RecommendationSave"></asp:PostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="lbtAddSPCC" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="updPhaseI" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Panel runat="server" ID="pnlPhaseI" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Phase I Information</div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" width="18%">
                                                                Assessor&nbsp;<span id="Span110" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%">
                                                                <asp:TextBox runat="server" ID="txtPhase_Assessor" Width="170px" MaxLength="50"></asp:TextBox>
                                                            </td>
                                                            <td align="left" width="18%">
                                                                Telephone&nbsp;<span id="Span111" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%">
                                                                <asp:TextBox runat="server" ID="txtPhase_phone" Width="170px" MaxLength="12" SkinID="txtphone"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="rfvPhase_phone" runat="server" ControlToValidate="txtPhase_phone"
                                                                    SetFocusOnError="true" ErrorMessage="Telephone must be in (XXX-XXX-XXXX) format."
                                                                    ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ValidationGroup="valPhase1"
                                                                    Display="None">
                                                                </asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" width="18%">
                                                                Report Date&nbsp;<span id="Span112" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%">
                                                                <asp:TextBox runat="server" ID="txtPhase_date" Width="170px" MaxLength="10" SkinID="txtdate"></asp:TextBox>
                                                                <img alt="Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPhase_date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RangeValidator ID="rgvPhase_date" runat="server" ControlToValidate="txtPhase_date"
                                                                    SetFocusOnError="true" ErrorMessage="Report Date is not Valid" Display="None"
                                                                    Type="Date" ValidationGroup="valPhase1" MaximumValue="12/31/9999" MinimumValue="01/01/1753">
                                                                </asp:RangeValidator>
                                                            </td>
                                                            <td align="left" width="18%">
                                                                Next Review Date&nbsp;<span id="Span113" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" width="4%">
                                                                :
                                                            </td>
                                                            <td align="left" width="28%">
                                                                <asp:TextBox runat="server" ID="txtPhase_Next_Date" Width="170px" SkinID="txtdate"
                                                                    MaxLength="10"></asp:TextBox>
                                                                <img alt="Next Review Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPhase_Next_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RangeValidator ID="rgvPhase_Next_Date" runat="server" ControlToValidate="txtPhase_Next_Date"
                                                                    SetFocusOnError="true" ErrorMessage="Next Review Date is not Valid" Display="None"
                                                                    Type="Date" ValidationGroup="valPhase1" MaximumValue="12/31/9999" MinimumValue="01/01/1753">
                                                                </asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                Next Report Date&nbsp;<span id="Span114" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPhase_Next_Report_Date" Width="170px" MaxLength="10"
                                                                    SkinID="txtdate"></asp:TextBox>
                                                                <img alt="Next Report Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPhase_Next_Report_Date', 'mm/dd/y');"
                                                                    onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                    align="middle" />
                                                                <asp:RangeValidator ID="rgvPhase_Next_Report_Date" runat="server" ControlToValidate="txtPhase_Next_Report_Date"
                                                                    SetFocusOnError="true" ErrorMessage="Next Report Date is not Valid" Display="None"
                                                                    Type="Date" ValidationGroup="valPhase1" MaximumValue="12/31/9999" MinimumValue="01/01/1753">
                                                                </asp:RangeValidator>
                                                            </td>
                                                            <td align="left">
                                                                Cost&nbsp;<span id="Span115" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center">
                                                                :
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox runat="server" ID="txtPhase_Cost" Width="170px" MaxLength="18"></asp:TextBox>
                                                                <asp:CustomValidator ID="csmvPhase_Cost" runat="server" ControlToValidate="txtPhase_Cost"
                                                                    SetFocusOnError="true" ClientValidationFunction="CheckIsNumeric" ValidationGroup="valPhase1"
                                                                    ErrorMessage="Cost must be Numeric." Display="None">
                                                                </asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                Notes&nbsp;<span id="Span116" style="color: Red; display: none;" runat="server">*</span>
                                                            </td>
                                                            <td align="center" valign="top">
                                                                :
                                                            </td>
                                                            <td align="left" colspan="4">
                                                                <uc:ctrlMultiLineTextBox runat="server" ID="txtPhase_Notes" ControlType="TextBox" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="6">
                                                                <asp:Button runat="server" ID="btnPhase_Save" Text="Save & Next" OnClick="btnPhase_Save_Click"
                                                                    CausesValidation="true" ValidationGroup="valPhase1" />
                                                                <asp:CustomValidator ID="CustomValidator10" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                    Display="None" ValidationGroup="valPhase1" />
                                                                <input id="hdnControlIDs10" runat="server" type="hidden" />
                                                                <input id="hdnErrorMsgs10" runat="server" type="hidden" />
                                                                <asp:Button ID="btnPhase_Audit" runat="server" Text="View Audit Trail" Visible="false" />
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="pnlPhaseAttachementDetail" runat="server" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Attachment Details
                                                    </div>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <uc:ctrlAttachmentDetails ID="PhaseAttachmentDetails" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvPhaseI" EventName="RowEditing" />
                                                <asp:AsyncPostBackTrigger ControlID="gvPhaseI" EventName="RowDeleting" />
                                                <asp:AsyncPostBackTrigger ControlID="lbtAddPhase" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:Panel ID="pnlPhaseAttachment" runat="server" Width="100%">
                                            <div class="bandHeaderRow">
                                                Add Attachment</div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <uc:ctrlAttachment ID="PhaseAttachment" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btnPhaseAttachmentSave" runat="server" ToolTip="Next" Text="Next"
                                                            OnClientClick="javascript:ShowPanel(16);return false;"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <asp:UpdatePanel ID="updPhaseRecommendations" runat="server" RenderMode="Inline"
                                            UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlPhaseRecommendations" runat="server" Width="100%">
                                                    <div class="bandHeaderRow">
                                                        Recommendations</div>
                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <asp:LinkButton ID="lnkPhaseRecommendation" runat="server" Text="--Add--" OnClick="lnkPhaseRecommendation_Click"></asp:LinkButton>
                                                            </td>
                                                            <td align="left" valign="top" style="width: 90%;">
                                                                <asp:GridView ID="gvPhaseRecommendation" runat="server" EmptyDataText="No record found"
                                                                    AutoGenerateColumns="false" Width="100%" OnRowDeleting="gvPhaseRecommendation_RowDeleting"
                                                                    DataKeyNames="PK_Enviro_Equipment_Recommendations_ID" OnRowEditing="gvPhaseRecommendation_RowEditing">
                                                                    <RowStyle Wrap="true" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Number">
                                                                            <ItemStyle Wrap="true" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtPlanNumber" runat="server" CommandName="Edit" Text='<%#Eval("Number")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Title">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtPlanTitle" runat="server" CommandName="Edit" Text='<%#Eval("title")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Staus">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtPlanstatus" runat="server" CommandName="Edit" Text='<%#Eval("status")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Assigned To">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtPlanAssigned_to" runat="server" CommandName="Edit" Text='<%#Eval("Assigned_to")%>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remove">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbtPlanDelete" runat="server" CommandName="Delete" Text="Remove"
                                                                                    OnClientClick="return confirm('Are you sure your want to delete this Equipment Recommendatoin?');">
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:Panel ID="pnlPhaseIndRecommendations" runat="server" Visible="false">
                                                        <div class="bandHeaderRow">
                                                            Individual Recommendation</div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Date of visit&nbsp;<span id="Span117" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPhase_Indivial_Recommendation_Date" Width="170px"
                                                                        SkinID="txtdate" MaxLength="10"></asp:TextBox>
                                                                    <img alt="Date of visit" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPhase_Indivial_Recommendation_Date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPhase_Indivial_Recommendation_Date" runat="server"
                                                                        ControlToValidate="txtPhase_Indivial_Recommendation_Date" Display="None" ErrorMessage="Date of visit must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="valPhaseAttachement">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                    <asp:RangeValidator ID="rgvPhase_Indivial_Recommendation_Date" runat="server" ControlToValidate="txtPhase_Indivial_Recommendation_Date"
                                                                        SetFocusOnError="true" Type="Date" Display="None" ErrorMessage="Date of visit is not Valid Date."
                                                                        ValidationGroup="valPhaseAttachement" MaximumValue="12/31/9999" MinimumValue="01/01/1753">
                                                                    </asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Recommendation Number&nbsp;<span id="Span118" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPhase_Indivial_Recommendation_Number" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPhase_Indivial_Recommendation_Number" runat="server"
                                                                        ControlToValidate="txtPhase_Indivial_Recommendation_Number" Display="None" ErrorMessage="Recommendation Number must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="valPhaseAttachement">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Recommendation Made by&nbsp;<span id="Span119" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:TextBox runat="server" ID="txtPhase_Indivial_Recommendation_Made_by" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPhase_Indivial_Recommendation_Made_by" runat="server"
                                                                        ControlToValidate="txtPhase_Indivial_Recommendation_Made_by" Display="None" ErrorMessage="Recommendation Made by must not be Empty."
                                                                        SetFocusOnError="true" ValidationGroup="valPhaseAttachement">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    Status&nbsp;<span id="Span120" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:DropDownList runat="server" ID="ddlPhase_Indivial_Recommendation_status" SkinID="ddlStatus">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Title&nbsp;<span id="Span121" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPhase_Indivial_Recommendation_Title" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="rfvPhase_Indivial_Recommendation_Title" runat="server"
                                                                        SetFocusOnError="true" ControlToValidate="txtPhase_Indivial_Recommendation_Title"
                                                                        Display="None" ErrorMessage="Recommendation Title must not be Empty." ValidationGroup="valPhaseAttachement">
                                                                    </asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Detailed Recommendation Description&nbsp;<span id="Span122" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtPhase_Indivial_Recommendation_description"
                                                                        ControlType="TextBox" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To Name&nbsp;<span id="Span123" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtPhase_Indivial_Recommendation_Assigned_to" Width="170px"
                                                                        MaxLength="50"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Due date&nbsp;<span id="Span124" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox runat="server" ID="txtPhase_Indivial_Recommendation_Due_date" Width="170px"
                                                                        SkinID="txtdate" MaxLength="10"></asp:TextBox>
                                                                    <img alt="Due date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPhase_Indivial_Recommendation_Due_date', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To Telephone(XXX-XXX-XXXX)&nbsp;<span id="Span125" style="color: Red; display: none;"
                                                                        runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPhase_Indivial_Recommendation_Assigned_to_phone"
                                                                        SkinID="txtphone" Width="170px" MaxLength="12"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPhase_Indivial_Recommendation_Assigned_to_phone"
                                                                        runat="server" ControlToValidate="txtPhase_Indivial_Recommendation_Assigned_to_phone"
                                                                        SetFocusOnError="true" Display="None" ErrorMessage="Assigned To Telephone number must be in (XXX-XXX-XXXX) format."
                                                                        ValidationExpression="\b[0-9]{3}-[0-9]{3}-[0-9]{4}\b" ValidationGroup="valPhaseAttachement">
                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Assigned To E-mail&nbsp;<span id="Span126" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPhase_Indivial_Recommendation_Assigned_to_email"
                                                                        Width="170px" MaxLength="50"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revPhase_Indivial_Recommendation_Assigned_to_email"
                                                                        runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                        ValidationGroup="valPhaseAttachement" Display="None" ErrorMessage="Assigned To E-mail is not valid."
                                                                        ControlToValidate="txtPhase_Indivial_Recommendation_Assigned_to_email" SetFocusOnError="true"> 
                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Estimated Cost $&nbsp;<span id="Span127" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtPhaseEstimatedCost" runat="server" Width="170px" EnableViewState="true"
                                                                        MaxLength="17" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                </td>
                                                                <td align="left">
                                                                    Final Cost $&nbsp;<span id="Span128" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtPhaseFinalCost" runat="server" Width="170px" EnableViewState="true"
                                                                        MaxLength="17" onpaste="return false" onkeypress="return currencyFormat(this,',','.',event);"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Resolution&nbsp;<span id="Span129" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="txtPhase_Indivial_Recommendation_Resolution"
                                                                        ControlType="TextBox" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Date Closed&nbsp;<span id="Span130" style="color: Red; display: none;" runat="server">*</span>
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:TextBox runat="server" ID="txtPhase_Indivial_Recommendation_Date_Closed" Width="170px"
                                                                        SkinID="txtdate" MaxLength="10"></asp:TextBox>
                                                                    <img alt="Date Closed" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPhase_Indivial_Recommendation_Date_Closed', 'mm/dd/y');"
                                                                        onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                                                        align="middle" />
                                                                    <asp:RangeValidator ID="rgvPhase_Indivial_Recommendation_Date_Closed" runat="server"
                                                                        ControlToValidate="txtPhase_Indivial_Recommendation_Date_Closed" Type="Date"
                                                                        SetFocusOnError="true" Display="None" ErrorMessage="Date Closed is not Valid Date."
                                                                        ValidationGroup="valPhaseAttachement" MaximumValue="12/31/9999" MinimumValue="01/01/1753">
                                                                    </asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center" colspan="3" style="width: 100%;">
                                                                <asp:Button runat="server" ID="btnPhase_RecommendationSave" Text="View" OnClick="btnPhase_RecommendationSave_Click"
                                                                    CausesValidation="true" ValidationGroup="valPhaseAttachement" />
                                                                <asp:CustomValidator ID="CustomValidator11" runat="server" ErrorMessage="" ClientValidationFunction="ValidateFields"
                                                                    Display="None" ValidationGroup="valPhaseAttachement" />
                                                                <input id="hdnControlIDs11" runat="server" type="hidden" />
                                                                <input id="hdnErrorMsgs11" runat="server" type="hidden" />
                                                                <asp:Button runat="server" ID="btnPhase_RecommendationRevert" Text="Revert & Return"
                                                                    OnClick="btnPhase_RecommendationRevert_Click" Visible="false" CausesValidation="false" />
                                                                <asp:Button ID="btnPhase_RecommendationAudit" runat="server" Text="View Audit Trail"
                                                                    Visible="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvPhaseI" EventName="RowEditing" />
                                                <asp:AsyncPostBackTrigger ControlID="gvPhaseI" EventName="RowDeleting" />
                                                <asp:PostBackTrigger ControlID="btnPhase_RecommendationSave" />
                                                <asp:AsyncPostBackTrigger ControlID="lbtAddPhase" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script language="javascript" type="text/javascript">
        //used to get height of scrollbar and add to total screen height +  scrollbar height
        function getScrollHeight() {
            var h = window.pageYOffset ||
           document.body.scrollTop ||
           document.documentElement.scrollTop;
            document.getElementById('divProgress').style.height = screen.height + h;
            document.getElementById('ProgressTable').style.height = screen.height + h;
        }
    </script>
    <script language="javascript" type="text/javascript">
        window.onscroll = getScrollHeight;
    </script>
</asp:Content>
