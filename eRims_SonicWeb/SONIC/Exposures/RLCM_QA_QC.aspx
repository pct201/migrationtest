<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RLCM_QA_QC.aspx.cs" Inherits="SONIC_Exposures_RLCM_QA_QC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .ChildGrid {
            padding: 0px;
            width: 30%;
        }
    </style>
    <script type="text/javascript" src="../../JavaScript/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        <%--function SetFROIAllowedTab(FroiType) {

            alert(number[0]);
            if (number[0] === "WC") '<%=clsSession.AllowedTab %>' = "1";
        }--%>

        function ShowPanel(index) {
            var ParentMenuIndex;
            if (index == 1 || index == 2 || index == 3)
                ParentMenuIndex = 1;
            else if (index == 4)
                ParentMenuIndex = 2;
            else if (index == 5 || index == 6 || index == 7 || index == 8)
                ParentMenuIndex = 3;
            else
                ParentMenuIndex = 4;

            SetMenuStyle(index, ParentMenuIndex);

            if (index == 1) {
                document.getElementById("<%=pnlClaimRLCM.ClientID%>").style.display = "";
                document.getElementById("<%=pnlClaimRLCMClaimInfo.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSLTRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureDPD.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureCustomer.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlACIManagementRLCM.ClientID%>").style.display = "none";
            }
            else if (index == 2) {
                document.getElementById("<%=pnlClaimRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMClaimInfo.ClientID%>").style.display = "";
                document.getElementById("<%=pnlClaimRLCMIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSLTRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureDPD.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureCustomer.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlACIManagementRLCM.ClientID%>").style.display = "none";
            }
            else if (index == 3) {
                document.getElementById("<%=pnlClaimRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMClaimInfo.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMIncident.ClientID%>").style.display = "";
                document.getElementById("<%=pnlSLTRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureDPD.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureCustomer.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlACIManagementRLCM.ClientID%>").style.display = "none";
            }
            else if (index == 4) {
                document.getElementById("<%=pnlClaimRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMClaimInfo.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSLTRLCM.ClientID%>").style.display = "";
                document.getElementById("<%=pnlExposureRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureDPD.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureCustomer.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlACIManagementRLCM.ClientID%>").style.display = "none";
            }
            else if (index == 5) {
                document.getElementById("<%=pnlClaimRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMClaimInfo.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSLTRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureRLCM.ClientID%>").style.display = "";
                document.getElementById("<%=pnlExposureProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureDPD.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureCustomer.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlACIManagementRLCM.ClientID%>").style.display = "none";
            }
            else if (index == 6) {
                document.getElementById("<%=pnlClaimRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMClaimInfo.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSLTRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureProperty.ClientID%>").style.display = "";
                document.getElementById("<%=pnlExposureDPD.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureCustomer.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlACIManagementRLCM.ClientID%>").style.display = "none";
            }
            else if (index == 7) {
                document.getElementById("<%=pnlClaimRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMClaimInfo.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSLTRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureDPD.ClientID%>").style.display = "";
                document.getElementById("<%=pnlExposureCustomer.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlACIManagementRLCM.ClientID%>").style.display = "none";
            }
            else if (index == 8) {
                document.getElementById("<%=pnlClaimRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMClaimInfo.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSLTRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureDPD.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureCustomer.ClientID%>").style.display = "";
                document.getElementById("<%=pnlACIManagementRLCM.ClientID%>").style.display = "none";
            }
            else if (index == 9) {
                document.getElementById("<%=pnlClaimRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMClaimInfo.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlClaimRLCMIncident.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlSLTRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureRLCM.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureProperty.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureDPD.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlExposureCustomer.ClientID%>").style.display = "none";
                document.getElementById("<%=pnlACIManagementRLCM.ClientID%>").style.display = "";
            }
}

//Used to set Menu Style
function SetMenuStyle(index, parentIndex) {
    for (j = 1; j <= 4; j++) {//set parent menu
        var tbRLCM = document.getElementById("RLCM_QA_QCMenu" + j);
        if (j == parentIndex) {
            tbRLCM.className = "LeftMenuSelected";
            tbRLCM.onmouseover = function () { this.className = 'LeftMenuSelected'; }
            tbRLCM.onmouseout = function () { this.className = 'LeftMenuSelected'; }
        }
        else {
            tbRLCM.className = "LeftMenuStatic";
            tbRLCM.onmouseover = function () { this.className = 'LeftMenuHover'; }
            tbRLCM.onmouseout = function () { this.className = 'LeftMenuStatic'; }
        }
    }

    var i;
    for (i = 1; i <= 9; i++) {//set submenu 

        if (i != 4 && i != 9) {
            var tb = document.getElementById("SubMenu" + i);
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
}

function ShowHideSubMenu(id) {
    if (id == "ctl00_ContentPlaceHolder1_imgMinusClaims") {//minus click hide submenu
        document.getElementById('<%=trSubMenuClaim.ClientID%>').style.display = "none";
        document.getElementById('<%=imgMinusClaims.ClientID%>').style.display = "none";
        document.getElementById('<%=imgPlusClaims.ClientID%>').style.display = "";
    }
    else if (id == "ctl00_ContentPlaceHolder1_imgPlusClaims") {//plus click show submenu
        document.getElementById('<%=trSubMenuClaim.ClientID%>').style.display = "";
        document.getElementById('<%=imgMinusClaims.ClientID%>').style.display = "";
        document.getElementById('<%=imgPlusClaims.ClientID%>').style.display = "none";
    }
    if (id == "ctl00_ContentPlaceHolder1_imgMinusExposure") {//minus click hide submenu
        document.getElementById('<%=trSubMenuExposure.ClientID%>').style.display = "none";
        document.getElementById('<%=imgMinusExposure.ClientID%>').style.display = "none";
        document.getElementById('<%=imgPlusExposure.ClientID%>').style.display = "";
    }
    else if (id == "ctl00_ContentPlaceHolder1_imgPlusExposure") {//plus click show submenu
        document.getElementById('<%=trSubMenuExposure.ClientID%>').style.display = "";
        document.getElementById('<%=imgMinusExposure.ClientID%>').style.display = "";
        document.getElementById('<%=imgPlusExposure.ClientID%>').style.display = "none";
    }

}

function SetFROIAllowedTab(Hyperlink, PK_RLCM_QA_QC, gridRow) {

    if (Hyperlink) {
        var number = Hyperlink.split("&");
        //e.preventDefault();
        if (number.length > 0) {
            var Jsondata = {};
            if (Hyperlink.indexOf("FirstReport") > -1) {
                Jsondata.WizardID = number[1].substring(number[1].indexOf("=") + 1);
                Jsondata.Type = "FirstReport";
                Jsondata.ClaimType = "";
            }
            else {
                Jsondata.WizardID = number[0].substring(number[0].indexOf("=") + 1);
                Jsondata.Type = "Claim";
                Jsondata.ClaimType = number[0].substring(number[0].indexOf("/", 5) + 1, number[0].indexOf("?", 5));
            }

            $.ajax({

                type: "POST",
                url: "RLCM_QA_QC.aspx/SetSessionTab",
                //data: '{ strWizardID: "' + WizardID + '" }',
                //data: { "Hyperlink": Jsondata.WizardID, "Type": Jsondata.Type },
                data: "{'Hyperlink':'" + Jsondata.WizardID + "', 'Type':'" + Jsondata.Type + "', 'ClaimType':'" + Jsondata.ClaimType + "'}",
                contentType: "application/json; charset=utf-8",
                async: false,
                dataType: "json",
                success: function (response) {
                    window.open(Hyperlink, "_blank");
                    var hv = $("#" + '<%= hdnISRLCMUser.ClientID %>').val();
                    if (hv == "1") {
                        var rowData = gridRow.parentNode.parentNode;
                        var checkbox = $(rowData).find("input:checkbox")[0];
                        if (typeof checkbox != "undefined") {
                            checkbox.checked = true;
                            return true;
                        }
                    }
                },
                failure: function (response) {

                },
                error: function (xhr, status, error) {
                    alert(xhr.responseText);
                }
            });
        }
    }
}


$(document).ready(function () {

    $('a').each(function () {

        if ($(this).text().trim() == 'N/A' || $(this).text().trim() == 'Monthly Review Complete') {
            $(this).css('cursor', 'default').css('text-decoration', 'none').css('pointer-events', 'none').css('color', 'WindowText');
            $(this).removeAttr("href");
            $(this).on("onclick", function (e) {
                e.preventDefault();
            });
        }

        if ($(this).text().trim() == 'N/A') {            
            $(this).closest('tr').find("[type='checkbox']").hide();
            
        }

        if ($(this).text().trim() == 'Monthly Review Complete') {
            $(this).closest('tr').find("[type='checkbox']").attr('onclick', '').unbind('click');
        }

    });

});


    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    </div>
    <div align="center" style="width: 100%">
        <asp:Panel ID="pnlSearch" runat="server">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr style="height: 20px;" align="left">
                    <td class="PropertyInfoBG" style="padding-left: 20px;">RLCM Monthly QA/QC - Search Filter
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="2" cellspacing="2" width="80%">
                <tr>
                    <td align="left" class="lc">RLCM<span id="Span3" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlRLCM" runat="server" Width="180px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvRLCM" Display="none" runat="server" ControlToValidate="ddlRLCM"
                            ErrorMessage="Please Select RLCM." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="lc">Month<span id="Span1" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlMonth" runat="server" Width="180px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMonth" Display="none" runat="server" ControlToValidate="ddlMonth"
                            ErrorMessage="Please Select Month." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
                    <td align="left" class="lc">Year<span id="Span2" style="color: Red;" runat="server">*</span>
                    </td>
                    <td align="right" class="lc" valign="top">:
                    </td>
                    <td align="left" class="lc">
                        <asp:DropDownList ID="ddlYear" runat="server" Width="180px" SkinID="ddlSONIC">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvYear" Display="none" runat="server" ControlToValidate="ddlYear"
                            ErrorMessage="Please Select Year." Text="*" ValidationGroup="vsErrorGroup" InitialValue="0">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="vsErrorGroup" CausesValidation="true" OnClick="btnSubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlGrid" runat="server" Visible="false">
            <asp:HiddenField ID="hdnISRLCMUser" runat="server" Value="0" />
            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                <tr>
                    <td class="Spacer" style="height: 15px;" colspan="2"></td>
                </tr>
                <tr>
                    <td class="Spacer" style="height: 15px;" colspan="2">
                        <table cellpadding="3" cellspacing="1" border="0" style="background-color: Black;" width="100%">
                            <tr class="PropertyInfoBG">
                                <td align="left" style="width: 15%">
                                    <asp:Label ID="lblHeaderRLCM" Text="RLCM" runat="server"></asp:Label>
                                </td>
                                <td align="left" style="width: 15%">
                                    <asp:Label ID="lblHeaderMonth" Text="Month" runat="server"></asp:Label>
                                </td>
                                <td align="left" style="width: 15%">
                                    <asp:Label ID="lblHeaderYear" Text="Year" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr style="background-color: White;">
                                <td align="left">
                                    <asp:Label ID="lblRLCM" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblMonth" runat="server"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblYear" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="Spacer" style="height: 15px;" colspan="2"></td>
                </tr>
                <tr>
                    <td class="leftMenu">
                        <table cellpadding="2" cellspacing="1" width="100%">
                            <tr>
                                <td style="height: 18px;" class="Spacer"></td>
                            </tr>
                            <%--  <tr>
                                <td width="100%" align="left">
                                    <asp:Menu ID="mnuRLCM_QA_QC" runat="server" DataSourceID="dsRLCM_QA_QCMenu" StaticEnableDefaultPopOutImage="false" Width="100%">
                                        <StaticItemTemplate>
                                            <table cellpadding="5" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left" width="100%">
                                                        <span id="RLCM_QA_QCMenu<#Container.ItemIndex+1%>" onclick="javascript:ShowPanel(<#Container.ItemIndex+1%>);"
                                                            class="LeftMenuStatic">
                                                            <#Eval("Text")%>
                                                        </span>
                                                        <asp:Label ID="MenuAsterisk" runat="server" Text="*" Style="color: Red; display: none"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </StaticItemTemplate>
                                    </asp:Menu>
                                    <asp:SiteMapDataSource ID="dsRLCM_QA_QCMenu" runat="server" SiteMapProvider="EX-RLCM_QA_QCMenuProvider"
                                        ShowStartingNode="false" />
                                </td>
                            </tr>--%>
                            <tr>
                                <td align="right" valign="top" width="12%">
                                    <img id="imgPlusClaims" runat="server" src="../../Images/plus.jpg" style="cursor: pointer; display: none;"
                                        height="15" onclick="ShowHideSubMenu(this.id);" />
                                    <img id="imgMinusClaims" runat="server" src="../../Images/minus.jpg" style="cursor: pointer;"
                                        height="15" onclick="ShowHideSubMenu(this.id);" />
                                </td>
                                <td align="left" valign="top">
                                    <span id="RLCM_QA_QCMenu1" onclick="javascript:void(1);" class="LeftMenuStatic">Claims</span><%--ShowPanel(1); //If the user clicks on the word Claims or the word Exposures, nothing happens :: 3427--%>
                                </td>
                            </tr>
                            <tr id="trSubMenuClaim" runat="server">
                                <td>&nbsp;
                                </td>
                                <td align="left" valign="top">
                                    <table cellpadding="2" cellspacing="1" width="100%" border="0">
                                        <tr>
                                            <td width="10%" valign="top" align="right">
                                                <img id="imgredMark1" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                            </td>
                                            <td align="left" valign="top" width="90%">
                                                <span id="SubMenu1" onclick="javascript:ShowPanel(1);" class="LeftMenuStatic">FROI</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <img id="imgredMark2" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                            </td>
                                            <td align="left" valign="top">
                                                <span id="SubMenu2" onclick="javascript:ShowPanel(2);" class="LeftMenuStatic">Claim Information</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <img id="imgredMark3" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                            </td>
                                            <td align="left" valign="top">
                                                <span id="SubMenu3" onclick="javascript:ShowPanel(3);" class="LeftMenuStatic">Incident Investigation</span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td align="left">
                                    <span id="RLCM_QA_QCMenu2" onclick="javascript:ShowPanel(4);" class="LeftMenuStatic">SLT
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <img id="imgPlusExposure" runat="server" src="../../Images/plus.jpg" style="cursor: pointer; display: none;"
                                        height="15" onclick="ShowHideSubMenu(this.id);" />
                                    <img id="imgMinusExposure" runat="server" src="../../Images/minus.jpg" style="cursor: pointer;"
                                        height="15" onclick="ShowHideSubMenu(this.id);" />
                                </td>
                                <td align="left">
                                    <span id="RLCM_QA_QCMenu3" onclick="javascript:void(5);" class="LeftMenuStatic">Exposure<%--ShowPanel(5);--%>
                                    </span>
                                </td>
                            </tr>
                            <tr id="trSubMenuExposure" runat="server">
                                <td>&nbsp;
                                </td>
                                <td align="left" valign="top">
                                    <table cellpadding="2" cellspacing="1" width="100%" border="0">
                                        <tr>
                                            <td width="3%" valign="top" align="right">
                                                <img id="img1" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                            </td>
                                            <td align="left" valign="top" width="97%">
                                                <span id="SubMenu5" onclick="javascript:ShowPanel(5);" class="LeftMenuStatic">EHS</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <img id="img2" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                            </td>
                                            <td align="left" valign="top">
                                                <span id="SubMenu6" onclick="javascript:ShowPanel(6);" class="LeftMenuStatic">Property Security</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <img id="img3" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                            </td>
                                            <td align="left" valign="top">
                                                <span id="SubMenu7" onclick="javascript:ShowPanel(7);" class="LeftMenuStatic">DPD Thefts</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="right">
                                                <img id="img4" runat="server" alt="" src="~/Images/SLT_Menu_Icon.JPG" height="12" />
                                            </td>
                                            <td align="left" valign="top">
                                                <span id="SubMenu8" onclick="javascript:ShowPanel(8);" class="LeftMenuStatic">Customer Thefts</span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td align="left">
                                    <span id="RLCM_QA_QCMenu4" onclick="javascript:ShowPanel(9);" class="LeftMenuStatic">ACI Management
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;" class="Spacer"></td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="width: 5px">&nbsp;
                                </td>
                                <td style="width: 800px; height: 500px;" valign="top" class="dvContainer">
                                    <asp:Panel ID="pnlClaimRLCM" runat="server" Width="100%">
                                        <div class="bandHeaderRow">
                                            RLCM FROI Monthly QA/QC
                                        </div>
                                        <asp:GridView ID="gvClaimRLCM" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found." OnRowDataBound="gvRLCM_RowDataBound" BorderWidth="1px" GridLines="Both">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblModule" runat="server" Text='<%# Eval("Module")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="System" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSystem" runat="server" Text='<%# Eval("System") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Task" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="40%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTask" runat="server" Text='<%# Eval("Task")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Identifier &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status&nbsp;&nbsp;&nbsp;&nbsp;Request Deleted"
                                                    ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle CssClass="ChildGrid" />
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" width="100%" style="vertical-align: top;">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="gvChildGrid" dontUseScrolls="true" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" ShowHeader="False" OnRowDataBound="gvChildGrid_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Identifier" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <%--<asp:LinkButton ID="lblIdentifier_Link" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_RLCM_QA_QC") %>'
                                                                                    Text='<%# Eval("Number")%>'></asp:LinkButton> || --%>
                                                                                    <a href="#" onclick="javascript:SetFROIAllowedTab('<%# Eval("Hyperlink")%>','<%# Eval("PK_RLCM_QA_QC")%>',this)" id="lnkIdentifier"><%# Eval("Number")%></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="5%" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkStatus" runat="server" CssClass="checkbox" onclick="return false"></asp:CheckBox>
                                                                                    <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("PK_RLCM_QA_QC")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Request Deleted" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="45%" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkRequest_Deleted" runat="server" Visible='<%#ProcessMyDataItem(Eval("RequestDeletedVisible")) %>' CssClass="checkbox" ></asp:CheckBox>                                                                                    
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>                                                                            
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <table width="80%">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-left: 35px" width="100%">
                                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnSave_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" ValidationGroup="vsErrorGroup" OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlClaimRLCMClaimInfo" runat="server" Width="100%">
                                        <div class="bandHeaderRow">
                                            RLCM Claim Information Monthly QA/QC 
                                        </div>
                                        <asp:GridView ID="gvClaimInfo" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found." OnRowDataBound="gvRLCM_RowDataBound" BorderWidth="1px" GridLines="Both">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClaimInfoModule" runat="server" Text='<%# Eval("Module")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="System" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClaimInfoSystem" runat="server" Text='<%# Eval("System") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Task" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="40%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClaimInfoTask" runat="server" Text='<%# Eval("Task")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClaimInfoCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Identifier &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status" ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle CssClass="ChildGrid" />
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="gvClaimInfoChildGrid" dontUseScrolls="true" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" ShowHeader="False" OnRowDataBound="gvChildGrid_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Identifier" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="70%" />
                                                                                <ItemTemplate>
                                                                                    <%--<asp:LinkButton ID="lblIdentifier_Link" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_RLCM_QA_QC") %>'
                                                                                    Text='<%# Eval("Number")%>'></asp:LinkButton> || --%>
                                                                                    <a href="#" onclick="javascript:SetFROIAllowedTab('<%# Eval("Hyperlink")%>','<%# Eval("PK_RLCM_QA_QC")%>',this)" id="lnkIdentifier"><%# Eval("Number")%></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkStatus" runat="server" CssClass="checkbox" onclick="return false"></asp:CheckBox>
                                                                                    <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("PK_RLCM_QA_QC")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <table width="80%">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-left: 35px" width="100%">
                                                    <asp:Button ID="btnClaimInfoSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnSave_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnClaimInfoCancel" runat="server" Text="Cancel" ValidationGroup="vsErrorGroup" OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlClaimRLCMIncident" runat="server" Width="100%">
                                        <div class="bandHeaderRow">
                                            RLCM Incident Investigation Monthly QA/QC 
                                        </div>
                                        <asp:GridView ID="gvClaimIncident" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found." OnRowDataBound="gvRLCM_RowDataBound" BorderWidth="1px" GridLines="Both">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClaimIncidentModule" runat="server" Text='<%# Eval("Module")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="System" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClaimIncidentSystem" runat="server" Text='<%# Eval("System") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Task" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="40%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClaimIncidentTask" runat="server" Text='<%# Eval("Task")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClaimIncidentCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Identifier &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status" ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle CssClass="ChildGrid" />
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="gvClaimIncidentChildGrid" dontUseScrolls="true" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" ShowHeader="False" OnRowDataBound="gvChildGrid_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Identifier" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="70%" />
                                                                                <ItemTemplate>
                                                                                    <%--<asp:LinkButton ID="lblIdentifier_Link" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_RLCM_QA_QC") %>'
                                                                                    Text='<%# Eval("Number")%>'></asp:LinkButton> || --%>
                                                                                    <a href="#" onclick="javascript:SetFROIAllowedTab('<%# Eval("Hyperlink")%>','<%# Eval("PK_RLCM_QA_QC")%>',this)" id="lnkIdentifier"><%# Eval("Number")%></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkStatus" runat="server" CssClass="checkbox" onclick="return false"></asp:CheckBox>
                                                                                    <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("PK_RLCM_QA_QC")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <table width="80%">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-left: 35px" width="100%">
                                                    <asp:Button ID="btnClaimIncidentSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnSave_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnClaimIncidentCancel" runat="server" Text="Cancel" ValidationGroup="vsErrorGroup" OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlSLTRLCM" runat="server" Width="100%">
                                        <div class="bandHeaderRow">
                                            RLCM SLT Monthly QA/QC 
                                        </div>
                                        <asp:GridView ID="gvSLTRLCM" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found." OnRowDataBound="gvSLTRLCM_RowDataBound" BorderWidth="1px" GridLines="Both">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSLTModule" runat="server" Text='<%# Eval("Module")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="System" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSLTSystem" runat="server" Text='<%# Eval("System") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Task" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="40%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSLTTask" runat="server" Text='<%# Eval("Task")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSLTCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Identifier &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status" ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle CssClass="ChildGrid" />
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="gvSLTChildGrid" dontUseScrolls="true" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" ShowHeader="False" OnRowDataBound="gvSLTChildGrid_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Identifier" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="70%" />
                                                                                <ItemTemplate>
                                                                                    <%--<asp:LinkButton ID="lblIdentifier_Link" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_RLCM_QA_QC") %>'
                                                                                    Text='<%# Eval("Number")%>'></asp:LinkButton> || --%>
                                                                                    <a href="#" onclick="javascript:SetFROIAllowedTab('<%# Eval("Hyperlink")%>','<%# Eval("PK_RLCM_QA_QC")%>',this)" id="lnkIdentifier"><%# Eval("Number")%></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkSLTStatus" runat="server" CssClass="checkbox" onclick="return false"></asp:CheckBox>
                                                                                    <asp:HiddenField ID="hdnSLTStatus" runat="server" Value='<%# Eval("PK_RLCM_QA_QC")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <table width="80%">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-left: 35px" width="100%">
                                                    <asp:Button ID="btnSLTSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnSLTSave_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnSLTCancel" runat="server" Text="Cancel" ValidationGroup="vsErrorGroup" OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlExposureRLCM" runat="server" Width="100%">
                                        <div class="bandHeaderRow">
                                            RLCM EHS Monthly QA/QC 
                                        </div>
                                        <asp:GridView ID="gvExposureRLCM" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found." OnRowDataBound="gvExposureRLCM_RowDataBound" BorderWidth="1px" GridLines="Both">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureModule" runat="server" Text='<%# Eval("Module")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="System" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureSystem" runat="server" Text='<%# Eval("System") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Task" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="40%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureTask" runat="server" Text='<%# Eval("Task")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Identifier &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status" ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle CssClass="ChildGrid" />
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="gvExposureChildGrid" dontUseScrolls="true" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" ShowHeader="False" OnRowDataBound="gvExposureChildGrid_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Identifier" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="70%" />
                                                                                <ItemTemplate>
                                                                                    <%--<asp:LinkButton ID="lblIdentifier_Link" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_RLCM_QA_QC") %>'
                                                                                    Text='<%# Eval("Number")%>'></asp:LinkButton> || --%>
                                                                                    <a href="#" onclick="javascript:SetFROIAllowedTab('<%# Eval("Hyperlink")%>','<%# Eval("PK_RLCM_QA_QC")%>',this)" id="lnkIdentifier"><%# Eval("Number")%></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkExposureStatus" runat="server" CssClass="checkbox" onclick="return false"></asp:CheckBox>
                                                                                    <asp:HiddenField ID="hdnExposureStatus" runat="server" Value='<%# Eval("PK_RLCM_QA_QC")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <table width="80%">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-left: 35px" width="100%">
                                                    <asp:Button ID="btnExposureSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnExposureSave_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnExposureCancel" runat="server" Text="Cancel" ValidationGroup="vsErrorGroup" OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlExposureProperty" runat="server" Width="100%">
                                        <div class="bandHeaderRow">
                                            RLCM Property Security Monthly QA/QC 
                                        </div>
                                        <asp:GridView ID="gvExposurePropSec" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found." OnRowDataBound="gvExposureRLCM_RowDataBound" BorderWidth="1px" GridLines="Both">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposurePropSecModule" runat="server" Text='<%# Eval("Module")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="System" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposurePropSecSystem" runat="server" Text='<%# Eval("System") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Task" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="40%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposurePropSecTask" runat="server" Text='<%# Eval("Task")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposurePropSecCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Identifier &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status" ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle CssClass="ChildGrid" />
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="gvExposurePropSecChildGrid" dontUseScrolls="true" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" ShowHeader="False" OnRowDataBound="gvExposureChildGrid_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Identifier" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="70%" />
                                                                                <ItemTemplate>
                                                                                    <%--<asp:LinkButton ID="lblIdentifier_Link" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_RLCM_QA_QC") %>'
                                                                                    Text='<%# Eval("Number")%>'></asp:LinkButton> || --%>
                                                                                    <a href="#" onclick="javascript:SetFROIAllowedTab('<%# Eval("Hyperlink")%>','<%# Eval("PK_RLCM_QA_QC")%>',this)" id="lnkIdentifier"><%# Eval("Number")%></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkExposureStatus" runat="server" CssClass="checkbox" onclick="return false"></asp:CheckBox>
                                                                                    <asp:HiddenField ID="hdnExposureStatus" runat="server" Value='<%# Eval("PK_RLCM_QA_QC")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <table width="80%">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-left: 35px" width="100%">
                                                    <asp:Button ID="btnExposurePropSecSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnExposureSave_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                    <asp:Button ID="Button2" runat="server" Text="Cancel" ValidationGroup="vsErrorGroup" OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlExposureDPD" runat="server" Width="100%">
                                        <div class="bandHeaderRow">
                                            RLCM DPD Thefts Monthly QA/QC 
                                        </div>
                                        <asp:GridView ID="gvExposureDPD" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found." OnRowDataBound="gvExposureRLCM_RowDataBound" BorderWidth="1px" GridLines="Both">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureDPDModule" runat="server" Text='<%# Eval("Module")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="System" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureDPDSystem" runat="server" Text='<%# Eval("System") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Task" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="40%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureDPDTask" runat="server" Text='<%# Eval("Task")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureDPDCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Identifier &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status" ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle CssClass="ChildGrid" />
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="gvExposureDPDChildGrid" dontUseScrolls="true" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" ShowHeader="False" OnRowDataBound="gvExposureChildGrid_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Identifier" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="70%" />
                                                                                <ItemTemplate>
                                                                                    <%--<asp:LinkButton ID="lblIdentifier_Link" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_RLCM_QA_QC") %>'
                                                                                    Text='<%# Eval("Number")%>'></asp:LinkButton> || --%>
                                                                                    <a href="#" onclick="javascript:SetFROIAllowedTab('<%# Eval("Hyperlink")%>','<%# Eval("PK_RLCM_QA_QC")%>',this)" id="lnkIdentifier"><%# Eval("Number")%></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkExposureStatus" runat="server" CssClass="checkbox" onclick="return false"></asp:CheckBox>
                                                                                    <asp:HiddenField ID="hdnExposureStatus" runat="server" Value='<%# Eval("PK_RLCM_QA_QC")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <table width="80%">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-left: 35px" width="100%">
                                                    <asp:Button ID="btnExposureDPDSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnExposureSave_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnCancelDPD" runat="server" Text="Cancel" ValidationGroup="vsErrorGroup" OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlExposureCustomer" runat="server" Width="100%">
                                        <div class="bandHeaderRow">
                                            RLCM Customer Thefts Monthly QA/QC 
                                        </div>
                                        <asp:GridView ID="gvExposureCustomer" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found." OnRowDataBound="gvExposureRLCM_RowDataBound" BorderWidth="1px" GridLines="Both">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureCustomerModule" runat="server" Text='<%# Eval("Module")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="System" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureCustomerSystem" runat="server" Text='<%# Eval("System") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Task" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="40%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureCustomerTask" runat="server" Text='<%# Eval("Task")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblExposureCustomerCategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Identifier &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status" ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle CssClass="ChildGrid" />
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="gvExposureCustomerChildGrid" dontUseScrolls="true" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" ShowHeader="False" OnRowDataBound="gvExposureChildGrid_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Identifier" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="70%" />
                                                                                <ItemTemplate>
                                                                                    <%--<asp:LinkButton ID="lblIdentifier_Link" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_RLCM_QA_QC") %>'
                                                                                    Text='<%# Eval("Number")%>'></asp:LinkButton> || --%>
                                                                                    <a href="#" onclick="javascript:SetFROIAllowedTab('<%# Eval("Hyperlink")%>','<%# Eval("PK_RLCM_QA_QC")%>',this)" id="lnkIdentifier"><%# Eval("Number")%></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkExposureStatus" runat="server" CssClass="checkbox" onclick="return false"></asp:CheckBox>
                                                                                    <asp:HiddenField ID="hdnExposureStatus" runat="server" Value='<%# Eval("PK_RLCM_QA_QC")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <table width="80%">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-left: 35px" width="100%">
                                                    <asp:Button ID="btnExposureCustomerSave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnExposureSave_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnExposureCustomerCancel" runat="server" Text="Cancel" ValidationGroup="vsErrorGroup" OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlACIManagementRLCM" runat="server" Width="100%">
                                        <div class="bandHeaderRow">
                                            RLCM ACI Management Monthly QA/QC 
                                        </div>
                                        <asp:GridView ID="gvACIManagementRLCM" runat="server" AutoGenerateColumns="false" Width="100%" EmptyDataText="No Record Found." OnRowDataBound="gvACIManagementRLCM_RowDataBound" BorderWidth="1px" GridLines="Both">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Module" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblACIModule" runat="server" Text='<%# Eval("Module")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="System" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblACISystem" runat="server" Text='<%# Eval("System") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Task" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="40%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblACITask" runat="server" Text='<%# Eval("Task")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblACICategory" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Identifier &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status" ItemStyle-HorizontalAlign="left" HeaderStyle-BackColor="#95B3D7" ItemStyle-BackColor="White">
                                                    <ItemStyle CssClass="ChildGrid" />
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="gvACIChildGrid" dontUseScrolls="true" runat="server" AutoGenerateColumns="false" GridLines="Both" Width="100%" ShowHeader="False" OnRowDataBound="gvACIChildGrid_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Identifier" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="70%" />
                                                                                <ItemTemplate>
                                                                                    <%--<asp:LinkButton ID="lblIdentifier_Link" runat="server" CommandName="gvEdit" CommandArgument='<%# Eval("PK_RLCM_QA_QC") %>'
                                                                                    Text='<%# Eval("Number")%>'></asp:LinkButton> || --%>
                                                                                    <a href="#" onclick="javascript:SetFROIAllowedTab('<%# Eval("Hyperlink")%>','<%# Eval("PK_RLCM_QA_QC")%>',this)" id="lnkIdentifier"><%# Eval("Number")%></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" ItemStyle-BackColor="White">
                                                                                <ItemStyle Width="30%" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkACIStatus" runat="server" CssClass="checkbox" onclick="return false"></asp:CheckBox>
                                                                                    <asp:HiddenField ID="hdnACIStatus" runat="server" Value='<%# Eval("PK_RLCM_QA_QC")%>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <table width="80%">
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-left: 35px" width="100%">
                                                    <asp:Button ID="btnACISave" runat="server" Text="Save" ValidationGroup="vsErrorGroup" OnClick="btnACISave_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnACICancel" runat="server" Text="Cancel" ValidationGroup="vsErrorGroup" OnClick="btnCancel_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>

</asp:Content>

