<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="ViewEnvironmental.aspx.cs"
    Inherits="SONIC_Exposures_ViewEnvironmental" Title="eRIMS Sonic :: Exposures :: Environmental Data" %>

<%@ Register Src="~/Controls/ExposuresTab/ExposuresTab.ascx" TagName="CtlTab" TagPrefix="uc" %>
<%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox" TagPrefix="uc" %>
<%@ Register Src="~/Controls/ExposureInfo/ExposureInfo.ascx" TagName="ctrlExposureInfo"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/Attchment-Environment/Attachment.ascx" TagName="ctrlAttachment"
    TagPrefix="uc" %>
<%@ Register Src="~/Controls/AttchmentDetails-Environment/AttachmentDetails.ascx"
    TagName="ctrlAttachmentDetails" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
        
        function SetSelectedNode(SelectedNodeId)
        {
            var arrLinks = document.getElementById('<%=trvMenu.ClientID%>').getElementsByTagName('a');
            var i=0;
            
            for(i=0;i<arrLinks.length;i++)
            {
                arrLinks[i].className = 'leftmenu';
                arrLinks[i].style.color = '';
            }
            
            document.getElementById(SelectedNodeId).style.color = '#266591';
        }

        function ToggleNode(SelectedNodeId,NodeNumber)
        {               
            TreeView_ToggleNode(ctl00_ContentPlaceHolder1_trvMenu_Data,1,document.getElementById('ctl00_ContentPlaceHolder1_trvMenun'+NodeNumber),' ',document.getElementById('ctl00_ContentPlaceHolder1_trvMenun'+NodeNumber+'Nodes'))
        }

        function OutsideToggleNode(SelectedNodeId,NodeNumber)
        {
            // If Node is not explanded then Expand Node.
            if(document.getElementById('ctl00_ContentPlaceHolder1_trvMenun'+NodeNumber+'Nodes').style.display != 'block')
            {                   
                TreeView_ToggleNode(ctl00_ContentPlaceHolder1_trvMenu_Data,1,document.getElementById('ctl00_ContentPlaceHolder1_trvMenun'+NodeNumber),' ',document.getElementById('ctl00_ContentPlaceHolder1_trvMenun'+NodeNumber+'Nodes'))
            }                        
        }         
         
         function ShowPanel(index)
         {       
                document.getElementById("<%=pnlEnvironmentSummary.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewEquipment.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewInAdvertentRelease.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewEquipmentAttachment.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewEquipmentRecommendation.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewPermit.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewPermitAttachments.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewPermitRecommendations.ClientID%>").style.display="none";                                    
                document.getElementById("<%=pnlViewAudit.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewAuditAttachments.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewAuditRecommendations.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewSPCC.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewSPCCAttachments.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewSPCCRecommendations.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewPhase.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewPhaseAttachments.ClientID%>").style.display="none";
                document.getElementById("<%=pnlViewPhaseRecommendations.ClientID%>").style.display="none";
                
                if(document.getElementById("<%=btnEquipmentBackToEdit.ClientID%>") != null && document.getElementById("<%=btnEquipmentBackToEdit.ClientID%>") != 'undefine')
                    document.getElementById("<%=btnEquipmentBackToEdit.ClientID%>").style.display="none";
                
                //check if index is 0 than display Enviroment View Section.
                if(index == 0)
                {                    
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + index);
                    document.getElementById("<%=pnlEnvironmentSummary.ClientID%>").style.display="block";
                                    if(document.getElementById("<%=btnEquipmentBackToEdit.ClientID%>") != null && document.getElementById("<%=btnEquipmentBackToEdit.ClientID%>") != 'undefine')
                                        document.getElementById("<%=btnEquipmentBackToEdit.ClientID%>").style.display = "block";

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
                else if(index == 1)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 1));
                    document.getElementById("<%=pnlViewEquipment.ClientID%>").style.display="block";
                }
                //check if index is 2 than display  Section.
                else if(index == 2)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 1));
                    document.getElementById("<%=pnlViewInAdvertentRelease.ClientID%>").style.display="block";
                }
                //check if index is 3 than display  Section.
                else if(index == 3)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 1));
                    document.getElementById("<%=pnlViewEquipmentAttachment.ClientID%>").style.display="block";
                }
                //check if index is 4 than display  Section.
                else if(index == 4)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 1));
                    document.getElementById("<%=pnlViewEquipmentRecommendation.ClientID%>").style.display="block";
                }
                //check if index is 5 than display  Section.
                else if(index == 5)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 2));
                    document.getElementById("<%=pnlViewPermit.ClientID%>").style.display="block";
                }
                //check if index is 6 than display  Section.
                else if(index == 6)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 2));                        
                    document.getElementById("<%=pnlViewPermitAttachments.ClientID%>").style.display="block";
                }
                //check if index is 7 than display  Section.
                else if(index == 7)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 2));
                    document.getElementById("<%=pnlViewPermitRecommendations.ClientID%>").style.display="block";
                }
                //check if index is 8 than display  Section.
                else if(index == 8)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 3));
                    document.getElementById("<%=pnlViewAudit.ClientID%>").style.display="block";
                }
                //check if index is 9 than display  Section.
                else if(index == 9)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 3));
                    document.getElementById("<%=pnlViewAuditAttachments.ClientID%>").style.display="block";
                }
                //check if index is 10 than display  Section.
                else if(index == 10)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 3));
                    document.getElementById("<%=pnlViewAuditRecommendations.ClientID%>").style.display="block";
                }
                //check if index is 11 than display  Section.
                else if(index == 11)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 4));
                    document.getElementById("<%=pnlViewSPCC.ClientID%>").style.display="block";
                }
                //check if index is 12 than display  Section.
                else if(index == 12)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 4));
                    document.getElementById("<%=pnlViewSPCCAttachments.ClientID%>").style.display="block";
                }
                //check if index is 13 than display  Section.
                else if(index == 13)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 4));
                    document.getElementById("<%=pnlViewSPCCRecommendations  .ClientID%>").style.display="block";
                }
                //check if index is 14 than display  Section.
                else if(index == 14)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 5));
                    document.getElementById("<%=pnlViewPhase.ClientID%>").style.display="block";
                }
                //check if index is 15 than display  Section.
                else if(index == 15)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 5));
                    document.getElementById("<%=pnlViewPhaseAttachments.ClientID%>").style.display="block";
                }
                //check if index is 16 than display  Section.
                else if(index == 16)
                {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut' + (index + 5));
                    document.getElementById("<%=pnlViewPhaseRecommendations.ClientID%>").style.display="block";
                }
                //check if index is 0 than display Enviroment View Section.
                else if (index == 17) {
                    SetSelectedNode('ctl00_ContentPlaceHolder1_trvMenut22');
                    if (document.getElementById("<%=btnEquipmentBackToEdit.ClientID%>") != null && document.getElementById("<%=btnEquipmentBackToEdit.ClientID%>") != 'undefine')
                        document.getElementById("<%=btnEquipmentBackToEdit.ClientID%>").style.display = "block";

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
                          
    </script>

    <script type="text/javascript" language="javascript">
     function AuditPopUp(id)
     {
        var winHeight = window.screen.availHeight - 300;
        var winWidth = window.screen.availWidth - 200;
        
        obj= window.open("AuditPopup_Environmental.aspx?id=" + id,'AuditPopUp','width=' + winWidth +',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');        
        obj.focus();
        return false;
     }
     
     function ShowAuditPopUp(url)
     {
        var winHeight = window.screen.availHeight - 300;
        var winWidth = window.screen.availWidth - 200;
        
        obj= window.open(url,'AuditPopUp','width=' + winWidth +',height=' + winHeight + ',left=' + (window.screen.width - winWidth) / 2 + ',top=' + (window.screen.height - winHeight) / 2 + ',sizable=no,titlebar=no,location=0,status=0,scrollbars=1,menubar=0');        
        obj.focus();
        return false;
        
     }
    </script>

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
                                        <div style="width: 200px; height: 500px; overflow: auto;">
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
                                        <div id="dvEdit" runat="server" style="width: 100%;">
                                            <asp:Panel ID="pnlEnvironmentSummary" runat="server">
                                                <div class="bandHeaderRow">
                                                    Environmental Data</div>
                                                <asp:UpdatePanel ID="updEnvironment" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                    <ContentTemplate>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr runat="server" id="M1">
                                                                <td class="boldPoint">
                                                                    Equipment
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="M2">
                                                                <td align="left" valign="middle">
                                                                    <asp:GridView ID="gvEquipment" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                        DataKeyNames="PK_Enviro_Equipment_ID" Width="100%" OnRowEditing="gvEquipment_RowEditing">
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
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="M3">
                                                                <td class="boldPoint">
                                                                    Permits
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="M4">
                                                                <td align="left" valign="top">
                                                                    <asp:GridView ID="gvPermit" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                        OnRowEditing="gvPermit_RowEditing" Width="100%" DataKeyNames="PK_Enviro_Permit_ID">
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
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="M5">
                                                                <td class="boldPoint">
                                                                    Audits/Inspections
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="M6">
                                                                <td align="left" valign="top">
                                                                    <asp:GridView ID="gvAudit" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                        DataKeyNames="PK_Enviro_Inspection_ID" OnRowEditing="gvAudit_RowEditing" Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Last Date">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbtAuditLast_Date" runat="server" Text='<%#string.Format("{0:MM/dd/yyyy}",Eval("Last_date")) %>'
                                                                                        CommandName="Edit"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField ItemStyle-Width="20%" HeaderText="Next Date">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lbtAuditNext_Date" runat="server" Text='<%#string.Format("{0:MM/dd/yyyy}",Eval("Next_Date")) %>'
                                                                                        CommandName="Edit"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="M7">
                                                                <td class="boldPoint">
                                                                    SPCC
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="M8">
                                                                <td align="left" valign="top">
                                                                    <asp:GridView ID="gvSPCC" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                        OnRowEditing="gvSPCC_RowEditing" DataKeyNames="PK_Enviro_SPCC_ID" Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Date">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lblSPCC_LastDate" runat="server" Text='<%#string.Format("{0:MM/dd/yyyy}",Eval("Last_Date")) %>'
                                                                                        CommandName="Edit">
                                                                                    </asp:LinkButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="M9">
                                                                <td class="boldPoint">
                                                                    Phase I
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" id="M10">
                                                                <td align="left" valign="top">
                                                                    <asp:GridView ID="gvPhaseI" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                        DataKeyNames="PK_Enviro_Phase1_ID" OnRowEditing="gvPhaseI_RowEditing" Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Date">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lblPhase_LastDate" runat="server" Text='<%#string.Format("{0:MM/dd/yyyy}",Eval("Last_Date")) %>'
                                                                                        CommandName="Edit">
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
                                                                <td class="boldPoint" style="height: 25px">
                                                                    EPA IDs
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    <asp:GridView ID="gvEPAID" runat="server" AutoGenerateColumns="false" EmptyDataText="No records found!"
                                                                        Width="100%">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="Type" HeaderText="Type" ItemStyle-Width="30%" />
                                                                            <asp:BoundField DataField="ID_Number" HeaderText="ID" ItemStyle-Width="30%" />
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                             </table>
                                                            </td>
                                                        </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </asp:Panel>
                                            <asp:UpdatePanel ID="updViewEquipment" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                <ContentTemplate>
                                                    <asp:Panel ID="pnlViewEquipment" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Equipment</div>
                                                        <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" cellspacing="1" cellpadding="3">
                                                                        <tr>
                                                                            <td style="width: 18%" align="left">
                                                                                Identification
                                                                            </td>
                                                                            <td style="width: 4%" align="center">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%" align="left">
                                                                                <asp:Label ID="lblEquipment_Identification" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td style="width: 18%" align="left">
                                                                                Type
                                                                            </td>
                                                                            <td style="width: 4%" align="center">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%" align="left">
                                                                                <asp:Label ID="lblEquipment_Type" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table id="tblViewTypeInfo" runat="server" width="100%" cellspacing="1" cellpadding="3">
                                                                        <tr>
                                                                            <td style="width: 18%" align="left">
                                                                                Contents
                                                                            </td>
                                                                            <td align="center" width="4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" width="28%">
                                                                                <asp:Label ID="lblEquipment_Contents" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td align="left" width="18%">
                                                                                Contents – Other
                                                                            </td>
                                                                            <td align="center" width="4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" width="28%">
                                                                                <asp:Label ID="lblEquipment_ContactsOther" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 18%" align="left">
                                                                                Capacity(Gallons)
                                                                            </td>
                                                                            <td style="width: 4%" align="center">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%" align="left">
                                                                                <asp:Label ID="lblEquipment_Capacity" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td style="width: 18%" align="left">
                                                                                Status
                                                                            </td>
                                                                            <td style="width: 4%" align="center">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%" align="left">
                                                                                <asp:Label ID="lblEquipment_Status" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Material
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEuipment_Material" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                Material-Other
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_MaterialOther" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Construction
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_Construction" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                Construction-Other
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_ConstructionOther" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Release Equipement Present?
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_Release_Present" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                Release Equipement Description
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                :
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <uc:ctrlMultiLineTextBox ID="lblEquipment_Release_Description" runat="server" ControlType="Label">
                                                                                </uc:ctrlMultiLineTextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" cellspacing="1" cellpadding="3">
                                                                        <tr>
                                                                            <td align="left">
                                                                                Overfill Protection
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:Label ID="lblEquipment_Overfill_Protection" runat="server">
                                                                                </asp:Label>
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
                                                                                <asp:Label ID="lblEquipment_LeakDetection" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td style="width: 18%" align="left">
                                                                                Leak Detection Type
                                                                            </td>
                                                                            <td style="width: 4%" align="center">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%" align="left">
                                                                                <asp:Label ID="lblEquipment_LeakDetection_Type" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Insurer
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:Label ID="lblEquipment_Insurer" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Single Event Coverage
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_SingleEvent" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                Multiple Event/Total Coverage
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_Total_Coverage" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Coverage Start Date
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblCoverage_Start_Date" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                Coverage End Date
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblCoverage_End_Date" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table id="tblViewOilWater" runat="server" width="100%" cellspacing="1" cellpadding="3">
                                                                        <tr>
                                                                            <td align="left" width="18%">
                                                                                Flows to POTW
                                                                            </td>
                                                                            <td align="center" width="4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" width="28%">
                                                                                <asp:Label ID="lblFlowsToPOTW" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td align="left" width="18%">
                                                                                Date of Last Service
                                                                            </td>
                                                                            <td align="center" width="4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" width="28%">
                                                                                <asp:Label ID="lblDate_Last_Service" runat="server">
                                                                                </asp:Label>
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
                                                                                <asp:Label ID="lblTCLP_File" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td align="left" width="18%">
                                                                                Date of Last TCLP
                                                                            </td>
                                                                            <td align="center" width="4%">
                                                                                :
                                                                            </td>
                                                                            <td align="left" width="28%">
                                                                                <asp:Label ID="lblDate_Of_Last_TCLP" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table cellspacing="1" cellpadding="3">
                                                                        <tr>
                                                                            <td style="width: 18%" align="left">
                                                                                Installation Date
                                                                            </td>
                                                                            <td style="width: 4%" align="center">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%" align="left">
                                                                                <asp:Label ID="lblEquipment_Installation_Date" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td style="width: 18%" align="left">
                                                                                Removal Date
                                                                            </td>
                                                                            <td style="width: 4%" align="center">
                                                                                :
                                                                            </td>
                                                                            <td style="width: 28%" align="left">
                                                                                <asp:Label ID="lblEquipment_Removal_Date" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Closure Date
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:Label ID="lblEquipment_Closure_Date" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Last Inspection Date
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_Last_Inspection_Date" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                Next Inspection Date
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_Next_Inspection_Date" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Inspection Company
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:Label ID="lblEquipmnet_Inspection_Company" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Inspection Company<br />
                                                                                Contact Name
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEqupment_Inspection_Contact_Name" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                Inspection Company<br />
                                                                                Contact Telephone Number<br />
                                                                                (XXX-XXX-XXXX)
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_Inspection_Company_Telephone" runat="server">
                                                                                </asp:Label>
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
                                                                                <asp:Label ID="lblEquipment_Registration_Required" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                Registration Number
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_Registration_Number" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Certificate Number
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:Label ID="lblEquipment_Certificate_Number" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Permit Begin Date
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_Permit_Begin_Date" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                Permit End Date
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblEquipment_End_Date" runat="server">
                                                                                </asp:Label>
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
                                                                                <asp:Label ID="lblEquipment_Other_Reporting_Requirements" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                Description of Other Reporting Requirements
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                :
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <uc:ctrlMultiLineTextBox ID="lblEquipment_Other_Reporting_Desc" runat="server" ControlType="Label">
                                                                                </uc:ctrlMultiLineTextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                Next Report Date
                                                                            </td>
                                                                            <td align="center">
                                                                                :
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <asp:Label ID="lblEquipment_NextReportDate" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" valign="top">
                                                                                Notes
                                                                            </td>
                                                                            <td align="center" valign="top">
                                                                                :
                                                                            </td>
                                                                            <td align="left" colspan="4">
                                                                                <uc:ctrlMultiLineTextBox ID="lblEquipment_Notes" runat="server" ControlType="Label">
                                                                                </uc:ctrlMultiLineTextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnEquipmentBack" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                            <asp:Button ID="btnEquipmentAuditView" runat="server" Text="View Audit Trail" Visible="false" />
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewInAdvertentRelease" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Inadvertent Release Control and Countermeasures Plan</div>
                                                        <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Plan Identification
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:Label ID="lblPlan_ID" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Effective Date
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblPlan_Effective_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%">
                                                                        Expiration Date
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblPlan_Expiration_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Last Revision Date
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPlan_Revision_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Vendor
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPlan_Vendor" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Vendor Contact Name
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPlan_Vendor_Contact" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Vendor Contact Telephone Number (XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPlan_Phone" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnViewInAdvertentBack" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                            <asp:Button ID="btnViewInAdvertentReleaseAuditTrial" runat="server" Text="View Audit Trail"
                                                                Visible="false" />
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewEquipmentAttachment" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Attachment Details</div>
                                                        <table width="100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="center">
                                                                        <uc:ctrlAttachmentDetails ID="AttachDetailViewEquipment" runat="server"></uc:ctrlAttachmentDetails>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnAttachmentback" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewEquipmentRecommendation" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Recommendations
                                                        </div>
                                                        <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td valign="top" align="left" width="100%">
                                                                        <asp:GridView ID="gvViewEquipmentRecommendation" runat="server" EmptyDataText="No record found!"
                                                                            AutoGenerateColumns="false" DataKeyNames="PK_Enviro_Equipment_Recommendations_ID"
                                                                            OnRowEditing="gvViewEquipmentRecommendation_RowEditing" Width="100%">
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
                                                                                <asp:TemplateField ItemStyle-Width="20%" HeaderText="Status">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lblStatus" runat="server" Text='<%#Eval("status") %>' CommandName="Edit"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="30%" HeaderText="Assigned To">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lblAssignedTo" runat="server" Text='<%#Eval("Assigned_to") %>'
                                                                                            CommandName="Edit" CommandArgument='<%# Eval("PK_Enviro_Equipment_Recommendations_ID")%>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <asp:Panel ID="pnlViewEquipmentIndRecommendation" runat="server" Visible="false">
                                                            <div class="bandHeaderRow">
                                                                Individual Recommendation</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Date of visit
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:Label ID="lblIndivial_Recommendation_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Number
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:Label ID="lblIndivial_Recommendation_Number" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Made by
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblIndivial_Recommendation_Made_by" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%">
                                                                        Status
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblIndivial_Recommendation_status" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Title
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblIndivial_Recommendation_Title" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Detailed Recommendation Description
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblIndivial_Recommendation_description"
                                                                            ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Name
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblIndivial_Recommendation_Assigned_to" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Due date
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblIndivial_Recommendation_Due_date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Telephone(XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblIndivial_Recommendation_Assigned_to_phone" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To E-mail
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblIndivial_Recommendation_Assigned_to_email" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Estimated Cost $
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblEstimatedCost" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Final Cost $
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblFinalCost" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Resolution
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblIndivial_Recommendation_Resolution"
                                                                            ControlType="label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Date Closed
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblIndivial_Recommendation_Date_Closed" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnEquipmentRecommendationBack" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                            <asp:Button ID="btnEquipmentRecommendationAudit" runat="server" Text="View Audit Trail"
                                                                Visible="false" />
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewPermit" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Permits
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Type
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:Label ID="lblPermit_Type" runat="server"></asp:Label>
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
                                                                    <asp:Label ID="lblPermit_required" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    Application Regulation Number
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:Label ID="lblPermit_Application_number" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Certificate number
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblPermit_Certificate_number" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    Filing date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblPermit_Filing_date" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Permit Begin Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblPermit_Permit_Begin_date" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    Permit End Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblPermit_Permit_End_Date" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Last Inspection date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblPermit_Last_Inspection_date" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    Next Inspection Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblPermit_Next_Inspection_Date" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Next Report Date
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:Label ID="lblPermit_Next_Report_Date" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%" valign="top">
                                                                    Notes
                                                                </td>
                                                                <td align="center" width="4%" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblPermit_Notes" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnPermitBack" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                            <asp:Button ID="btnPermitAudit" runat="server" Text="View Audit Trail" Visible="false" />
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewPermitAttachments" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Attachments
                                                        </div>
                                                        <table width="100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="center">
                                                                        <uc:ctrlAttachmentDetails ID="AttachDetailViewPermit" runat="server" Visible="true">
                                                                        </uc:ctrlAttachmentDetails>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnAttachDetailViewPermit" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewPermitRecommendations" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Recommendations
                                                        </div>
                                                        <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td valign="top" align="left" width="100%">
                                                                        <asp:GridView ID="gvViewPermitRecommendation" runat="server" EmptyDataText="No record found!"
                                                                            AutoGenerateColumns="false" DataKeyNames="PK_Enviro_Equipment_Recommendations_ID"
                                                                            OnRowEditing="gvViewPermitRecommendation_RowEditing" Width="100%">
                                                                            <Columns>
                                                                                <asp:TemplateField ItemStyle-Width="20%" HeaderText="Recommendation Number">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lblPermit_Number" runat="server" Text='<%#Eval("Number") %>'
                                                                                            CommandName="Edit"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="30%" HeaderText="Title">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lblPermit_Title" runat="server" Text='<%#Eval("title") %>' CommandName="Edit"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="20%" HeaderText="Status">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lblPermit_Status" runat="server" Text='<%#Eval("status") %>'
                                                                                            CommandName="Edit"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="30%" HeaderText="Assigned To">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lblPermit_AssignedTo" runat="server" Text='<%#Eval("Assigned_to") %>'
                                                                                            CommandName="Edit" CommandArgument='<%# Eval("PK_Enviro_Equipment_Recommendations_ID")%>'></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <asp:Panel ID="pnlViewPermitIndRecommendation" runat="server" Visible="false">
                                                            <div class="bandHeaderRow">
                                                                Recommendations Detail
                                                            </div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Date of visit
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:Label ID="lblPermit_Indivial_Recommendation_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Number
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:Label ID="lblPermit_Indivial_Recommendation_Number" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Made by
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblPermit_Indivial_Recommendation_Made_by" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%">
                                                                        Status
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblPermit_Indivial_Recommendation_status" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Title
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPermit_Indivial_Recommendation_Title" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Detailed Recommendation Description
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblPermit_Indivial_Recommendation_description"
                                                                            ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Name
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPermit_Indivial_Recommendation_Assigned_to" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Due date
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPermit_Indivial_Recommendation_Due_date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Telephone(XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPermit_Indivial_Recommendation_Assigned_to_phone" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To E-mail
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPermit_Indivial_Recommendation_Assigned_to_email" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Estimated Cost $
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPermitEstimatedCost" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Final Cost $
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPermitFinalCost" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Resolution
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblPermit_Indivial_Recommendation_Resolution"
                                                                            ControlType="label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Date Closed
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPermit_Indivial_Recommendation_Date_Closed" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnPermitRecommendationBack" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                            <asp:Button ID="btnPermitRecommendationAudit" runat="server" Text="View Audit Trail"
                                                                Visible="false" />
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewAudit" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Audit/Inspections
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Frequency
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <asp:Label ID="lblAudit_Frequency" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Last Inspection Date
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:Label ID="lblAudit_Last_Date" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    Next Inspection Date
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:Label ID="lblAudit_Next_Date" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Next Report Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblAudits_Next_Report_Date" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    Cost
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblAudit_Cost" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Notes
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblAudit_Notes" ControlType="label" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnAuditback" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                            <asp:Button ID="btnAuditView" runat="server" Text="View Audit Trail" Visible="false" />
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewAuditAttachments" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Attachments
                                                        </div>
                                                        <table width="100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="center">
                                                                        <uc:ctrlAttachmentDetails ID="AttachDetailViewAudit" runat="server" Visible="true">
                                                                        </uc:ctrlAttachmentDetails>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnAttachDetailViewAudit" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewAuditRecommendations" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Recommendations
                                                        </div>
                                                        <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td valign="top" align="left" width="100%">
                                                                        <asp:GridView ID="gvViewAuditRecommendation" runat="server" EmptyDataText="No record found!"
                                                                            AutoGenerateColumns="false" DataKeyNames="PK_Enviro_Equipment_Recommendations_ID"
                                                                            OnRowEditing="gvViewAuditRecommendation_RowEditing" Width="100%">
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
                                                                                <asp:TemplateField ItemStyle-Width="20%" HeaderText="Status">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lblAudit_Status" runat="server" Text='<%#Eval("status") %>' CommandName="Edit"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ItemStyle-Width="30%" HeaderText="Assigned To">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lblAudit_AssignedTo" runat="server" Text='<%#Eval("Assigned_to") %>'
                                                                                            CommandName="Edit"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <asp:Panel ID="pnlViewAuditIndRecommendation" runat="server" Visible="false">
                                                            <div class="bandHeaderRow">
                                                                Recommendations Detail
                                                            </div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Date of visit
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:Label ID="lblAudit_Indivial_Recommendation_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Number
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:Label ID="lblAudit_Indivial_Recommendation_Number" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Made by
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblAudit_Indivial_Recommendation_Made_by" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%">
                                                                        Status
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblAudit_Indivial_Recommendation_status" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Title
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblAudit_Indivial_Recommendation_Title" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Detailed Recommendation Description
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblAudit_Indivial_Recommendation_description"
                                                                            ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Name
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblAudit_Indivial_Recommendation_Assigned_to" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Due date
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblAudit_Indivial_Recommendation_Due_date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Telephone(XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblAudit_Indivial_Recommendation_Assigned_to_phone" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To E-mail
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblAudit_Indivial_Recommendation_Assigned_to_email" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Estimated Cost $
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblAuditEstimatedCost" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Final Cost $
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblAuditFinalCost" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Resolution
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblAudit_Indivial_Recommendation_Resolution"
                                                                            ControlType="label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Date Closed
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblAudit_Indivial_Recommendation_Date_Closed" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnAuditIndBack" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                            <asp:Button ID="btnAuditIndAudit" runat="server" Text="View Audit Trail" Visible="false" />
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewSPCC" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            SPCC Information
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Plan Preparer
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:Label runat="server" ID="lblPreparer">
                                                                    </asp:Label>
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    Telephone
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" style="width: 28%">
                                                                    <asp:Label runat="server" ID="lblphone">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Plan Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label runat="server" ID="lblPlan_date">
                                                                    </asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    Next Review Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label runat="server" ID="lblPlan_Next_Date">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Next Report Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label runat="server" ID="lblPlan_Next_Report_Date">
                                                                    </asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    Cost
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label runat="server" ID="lblPlan_Cost">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Notes
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblPlan_Notes" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnSPCCBack" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                            <asp:Button ID="btnSPCCAudit" runat="server" Text="View Audit Trail" Visible="false" />
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewSPCCAttachments" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Attachments
                                                        </div>
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="center">
                                                                    <uc:ctrlAttachmentDetails ID="PlanAttachmentDetails" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnPlanAttachmentDetails" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewSPCCRecommendations" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Recommendations
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" valign="top" style="width: 100%;">
                                                                    <asp:GridView ID="gvPlanRecommendation" runat="server" EmptyDataText="No record found!"
                                                                        AutoGenerateColumns="false" DataKeyNames="PK_Enviro_Equipment_Recommendations_ID"
                                                                        OnRowEditing="gvPlanRecommendation_RowEditing" Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Number">
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
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Panel ID="pnlViewSPCCIndRecommendation" runat="server" Visible="false">
                                                            <div class="bandHeaderRow">
                                                                Individual Recommendation</div>
                                                            <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Date of visit
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:Label ID="lblPlan_Indivial_Recommendation_Date" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Number
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:Label ID="lblPlan_Indivial_Recommendation_Number" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Made by
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblPlan_Indivial_Recommendation_Made_by" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%">
                                                                        Status
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblPlan_Indivial_Recommendation_status" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Title
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPlan_Indivial_Recommendation_Title" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Detailed Recommendation Description
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblPlan_Indivial_Recommendation_description"
                                                                            ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Name
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPlan_Indivial_Recommendation_Assigned_to" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Due date
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPlan_Indivial_Recommendation_Due_date" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Telephone(XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPlan_Indivial_Recommendation_Assigned_to_phone" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To E-mail
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPlan_Indivial_Recommendation_Assigned_to_email" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Estimated Cost $
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblSPCEstimatedCost" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Final Cost $
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblSPCFinalCost" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Resolution
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblPlan_Indivial_Recommendation_Resolution"
                                                                            ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Date Closed
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPlan_Indivial_Recommendation_Date_Closed" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnSPCCIndBack" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                            <asp:Button ID="btnSPCCIndAudit" runat="server" Text="View Audit Trail" Visible="false" />
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewPhase" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Phase I Information
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Assessor
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:Label ID="lblPhase_Assessor" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    Telephone
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:Label ID="lblPhase_phone" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" width="18%">
                                                                    Report Date
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:Label ID="lblPhase_date" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left" width="18%">
                                                                    Next Review Date
                                                                </td>
                                                                <td align="center" width="4%">
                                                                    :
                                                                </td>
                                                                <td align="left" width="28%">
                                                                    <asp:Label ID="lblPhase_Next_Date" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    Next Report Date
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblPhase_Next_Report_Date" runat="server"></asp:Label>
                                                                </td>
                                                                <td align="left">
                                                                    Cost
                                                                </td>
                                                                <td align="center">
                                                                    :
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblPhase_Cost" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top">
                                                                    Notes
                                                                </td>
                                                                <td align="center" valign="top">
                                                                    :
                                                                </td>
                                                                <td align="left" colspan="4">
                                                                    <uc:ctrlMultiLineTextBox runat="server" ID="lblPhase_Notes" ControlType="Label" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnPhase1Back" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                            <asp:Button ID="btnPhase1Audit" runat="server" Text="View Audit Trail" Visible="false" />
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewPhaseAttachments" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Attachments
                                                        </div>
                                                        <table width="100%">
                                                            <tr>
                                                                <td width="100%">
                                                                    <uc:ctrlAttachmentDetails ID="PhaseAttachmentDetails" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnPhaseAttachmentDetails" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Panel ID="pnlViewPhaseRecommendations" runat="server" Width="100%">
                                                        <div class="bandHeaderRow">
                                                            Recommendations
                                                        </div>
                                                        <table cellpadding="3" cellspacing="1" border="0" width="100%">
                                                            <tr>
                                                                <td align="left" valign="top" style="width: 100%;">
                                                                    <asp:GridView ID="gvPhaseRecommendation" runat="server" EmptyDataText="No record found!"
                                                                        AutoGenerateColumns="false" Width="100%" DataKeyNames="PK_Enviro_Equipment_Recommendations_ID"
                                                                        OnRowEditing="gvPhaseRecommendation_RowEditing">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Number">
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
                                                                        Date of visit
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:Label ID="lblPhase_Indivial_Recommendation_Date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Number
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%" colspan="4">
                                                                        <asp:Label ID="lblPhase_Indivial_Recommendation_Number" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" width="18%">
                                                                        Recommendation Made by
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblPhase_Indivial_Recommendation_Made_by" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left" width="18%">
                                                                        Status
                                                                    </td>
                                                                    <td align="center" width="4%">
                                                                        :
                                                                    </td>
                                                                    <td align="left" width="28%">
                                                                        <asp:Label ID="lblPhase_Indivial_Recommendation_status" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Title
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPhase_Indivial_Recommendation_Title" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Detailed Recommendation Description
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblPhase_Indivial_Recommendation_description"
                                                                            ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Name
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPhase_Indivial_Recommendation_Assigned_to" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Due date
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPhase_Indivial_Recommendation_Due_date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To Telephone(XXX-XXX-XXXX)
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPhase_Indivial_Recommendation_Assigned_to_phone" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Assigned To E-mail
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPhase_Indivial_Recommendation_Assigned_to_email" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Estimated Cost $
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPhaseEstimatedCost" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="left">
                                                                        Final Cost $
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPhaseFinalCost" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top">
                                                                        Resolution
                                                                    </td>
                                                                    <td align="center" valign="top">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <uc:ctrlMultiLineTextBox runat="server" ID="lblPhase_Indivial_Recommendation_Resolution"
                                                                            ControlType="Label" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        Date Closed
                                                                    </td>
                                                                    <td align="center">
                                                                        :
                                                                    </td>
                                                                    <td align="left" colspan="4">
                                                                        <asp:Label ID="lblPhase_Indivial_Recommendation_Date_Closed" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <div style="width: 100%;" align="center">
                                                            <asp:Button ID="btnPhaseBack" runat="server" Text="Edit" OnCommand="BackToSummary">
                                                            </asp:Button>
                                                            <asp:Button ID="btnPhaseAudit" runat="server" Text="View Audit Trail" Visible="false" />
                                                        </div>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="gvEquipment" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                    <asp:AsyncPostBackTrigger ControlID="gvPermit" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                    <asp:AsyncPostBackTrigger ControlID="gvAudit" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                    <asp:AsyncPostBackTrigger ControlID="gvSPCC" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                    <asp:AsyncPostBackTrigger ControlID="gvPhaseI" EventName="RowEditing" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div>
                                            <table width="100%">
                                                <tr>
                                                    <td align="center">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                                                            <ContentTemplate>
                                                                <asp:Button ID="btnEquipmentBackToEdit" runat="server" Text="Edit" OnCommand="BackToSummary"
                                                                    Visible="false"></asp:Button>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="gvEquipment" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                                <asp:AsyncPostBackTrigger ControlID="gvPermit" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                                <asp:AsyncPostBackTrigger ControlID="gvAudit" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                                <asp:AsyncPostBackTrigger ControlID="gvSPCC" EventName="RowEditing"></asp:AsyncPostBackTrigger>
                                                                <asp:AsyncPostBackTrigger ControlID="gvPhaseI" EventName="RowEditing" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
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
        //used to get height of scrollbar and add to total screen height +  scollbar height
        function getScrollHeight()
        {
           var h = window.pageYOffset ||
                   document.body.scrollTop ||
                   document.documentElement.scrollTop;
            document.getElementById('divProgress').style.height= screen.height + h;
            document.getElementById('ProgressTable').style.height= screen.height + h;
        }
    </script>

    <script language="javascript" type="text/javascript">
        window.onscroll=getScrollHeight;
    </script>

</asp:Content>
