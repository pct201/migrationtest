<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="SLT_Wall_ByLocation.aspx.cs" Inherits="SONIC_SLT_SLT_Wall_ByLocation" %>

<%@ Register Src="~/Controls/Navigation/Navigation.ascx" TagName="ctrlPaging" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script type="text/javascript"  src="<%=AppConfig.SiteURL%>JavaScript/JFunctions.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="<%=AppConfig.SiteURL%>JavaScript/Date_Validation.js"></script>
    <script language="javascript" type="text/javascript">
        function openWindow(strURL) {
            oWnd = window.open(strURL, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=500,height=300");
            oWnd.moveTo(260, 180);
            return false;
        }

        function ExpandNotes(bExpand, index) {
            var intMsgLen = document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + index + "_hdMessageLength").value;
            if (bExpand) {
                if (intMsgLen >= 3500)
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + index + "_dvMainMessage").style.height = "400px";
                else
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + index + "_dvMainMessage").style.height = "";
                document.getElementById("imgMinus" + index).style.display = "block";
                document.getElementById("imgPlus" + index).style.display = "none";
            }
            else {
                if (intMsgLen >= 2500)
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + index + "_dvMainMessage").style.height = "200px";
                else
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + index + "_dvMainMessage").style.height = "";
                document.getElementById("imgMinus" + index).style.display = "none";
                document.getElementById("imgPlus" + index).style.display = "block";
            }
        }

        function ExpandNotesComment(bExpand, index, parentIndex) {
            var intMsgLen = document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + parentIndex + "_rptPostsComments_ctl0" + index + "_hdCommentMsgLength").value;

            if (bExpand) {
                if (intMsgLen >= 3500)
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + parentIndex + "_rptPostsComments_ctl0" + index + "_dvCommentMessage").style.height = "400px";
                else
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + parentIndex + "_rptPostsComments_ctl0" + index + "_dvCommentMessage").style.height = "";
                document.getElementById("imgMinusComment" + index).style.display = "block";
                document.getElementById("imgPlusComment" + index).style.display = "none";
            }
            else {
                if (intMsgLen >= 2500)
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + parentIndex + "_rptPostsComments_ctl0" + index + "_dvCommentMessage").style.height = "200px";
                else
                    document.getElementById("ctl00_ContentPlaceHolder1_rptPosts_ctl0" + parentIndex + "_rptPostsComments_ctl0" + index + "_dvCommentMessage").style.height = "";
                document.getElementById("imgMinusComment" + index).style.display = "none";
                document.getElementById("imgPlusComment" + index).style.display = "block";
            }
        }
    </script>
    <div>
        <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
            HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
            ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        <asp:ValidationSummary ID="valSummay" runat="server" ValidationGroup="vsErrorGroupRLCM"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Verify the following field(s):" />
    </div>
    <div id="dvThreads" runat="server">
        <table cellpadding="0" cellspacing="0" width="100%" align="center">
            <tr>
                <td width="100%" class="Spacer" style="height: 15px;">
                </td>
            </tr>
            <tr>
                <td class="ghc" align="left">
                    SLT Module
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 15px;">
                </td>
            </tr>
            <tr>
                <td align="left">
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <img src ="../../Images/SLT_homepage_logo.jpg" alt="SLT_homepage" height="50px" width="100px"/>
                            </td>
                            <td valign="top" align="center">
                                <uc:ctrlPaging ID="ctrlPageWallPost" runat="server" OnGetPage="GetPage" />
                            </td>
                            <%--<td width="30%" align="right" valign="top">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td align="right" valign="middle">
                                            Show Entire Thread for All Posts :&nbsp;
                                        </td>
                                        <td width="35%" align="left" valign="top">
                                            <asp:RadioButtonList ID="rdbThredType" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="true" OnSelectedIndexChanged="rdbThredType_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                </table>
                            </td>--%>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr id="trCommentDate" runat="server">
                
                <td width="100%">
                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left" width="80%" >&nbsp; Sonic Location Code :
                                    <%--<asp:DropDownList ID="ddlRMLocationNumber" runat="server" AutoPostBack="false" width="250px" SkinID="Default">
                                    </asp:DropDownList>--%>
                                <asp:LinkButton ID="lnkRMLocationNumber" runat="server" Text="" OnClick="lnkRMLocationNumber_Click" />
                                <%--<asp:RequiredFieldValidator ID="rfvddlRMLocationNumber" runat="Server" ValidationGroup="vsErrorGroupRLCM"
                                    ErrorMessage="Please Select SONIC Location Code" SetFocusOnError="true"
                                    Display="none" ControlToValidate="ddlRMLocationNumber" InitialValue="0"></asp:RequiredFieldValidator>--%>
                                <%--&nbsp;&nbsp;<asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnnext_Click" CausesValidation="true" ValidationGroup="vsErrorGroupRLCM"/>--%>
                            </td>
                            <%--<td align="right" valign="middle">
                                Comment Date Order :&nbsp;
                            </td>
                            <td align="left" valign="top">
                                <asp:RadioButtonList ID="rdbCommentDateOrder" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="true" OnSelectedIndexChanged="rdbThredType_SelectedIndexChanged">
                                    <asp:ListItem Text="Asc" Selected="True" Value="A"></asp:ListItem>
                                    <asp:ListItem Text="Desc" Value="D" ></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td width="15px">
                                &nbsp;
                            </td>--%>
                            <td width="20%" valign="middle">
                                &nbsp;&nbsp;<b>Posts Found :</b>&nbsp;<asp:Label ID="lblNumber" runat="server" Font-Bold="true"
                                    Text="0"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" height="10px">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="0" style="border-left: solid 1px Silver; border-right: solid 1px Silver;
                        border-top: solid 1px Silver;" width="99%">
                        <tr>
                            <td align="center">
                                <asp:Repeater ID="rptPosts" runat="server" OnItemDataBound="rptPosts_ItemDataBound" 
                                    OnItemCommand="rptPosts_ItemCommand">
                                    <ItemTemplate>
                                        <table width="100%" cellpadding="4" cellspacing="1" border="0" style="font-size: 11px;
                                            font-family: Verdana;">
                                            <tr>
                                                <td align="left" style="color: Gray; padding-left: 5px;">
                                                    &nbsp;Posted By:
                                                    <%# Eval("First_Name") + ", " + Eval("Last_Name")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;On:&nbsp;<%#clsGeneral.FormatDBNullDateTimeToMilitaryDateTime(Eval("Update_Date"))%></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding-left: 5px;">
                                                    <table cellpadding="3" cellspacing="1" width="98%" id="tblNotes" runat="server">
                                                        <tr style="height: 20px;">
                                                            <td align="left" width="90%" style="font-weight: bold;word-wrap: normal; word-break: break-all;">
                                                                Topic:
                                                                <%#Eval("Topic") %>
                                                            </td>
                                                            <td align="right" valign="middle" runat="server" id="tdExpandControls">
                                                                <img id="imgPlus<%#Container.ItemIndex %>" alt="" src="../../Images/plus.jpg" style="cursor: pointer;"
                                                                    onclick='javascript:ExpandNotes(true,"<%#Container.ItemIndex %>");' />
                                                                <img id="imgMinus<%#Container.ItemIndex %>" alt="" src="../../Images/minus.jpg" style="cursor: pointer;
                                                                    display: none;" onclick='javascript:ExpandNotes(false,"<%#Container.ItemIndex %>");' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <div id="dvMainMessage" runat="server" style="overflow-y: auto; font-size: 11px;
                                                                    font-family: Verdana;">
                                                                    <%#Eval("Message") %></div>
                                                                <asp:HiddenField ID="hdMessageLength" runat="server" Value="0" />
                                                                <asp:HiddenField ID="hdnIndex" runat="server" Value="<%#Container.ItemIndex %>" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <table width="100%" cellpadding="2" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left" width="60%">
                                                                &nbsp;&nbsp;<asp:Label ID="lblAttchment" runat="server" Text="Attachment : "></asp:Label><asp:LinkButton
                                                                    ID="lnkAttchment" runat="server" Visible="false"></asp:LinkButton><br />
                                                                <asp:Image ID="imgAttachment" runat="server" Width="150" Height="150" Visible="false" />
                                                            </td>
                                                           <%-- <td align="right" valign="bottom">
                                                                <asp:Label ID="lblShowThread" runat="server" Text="Show Entire Thread :"></asp:Label>&nbsp;<asp:HiddenField
                                                                    ID="hdnPKMainWall" runat="server" Value='<%#Eval("PK_Main_Wall") %>' />
                                                            </td>
                                                            <td width="10%" align="left" valign="bottom">
                                                                <asp:RadioButtonList ID="rdbThredTypeComment" runat="server" RepeatDirection="Horizontal"
                                                                    CellPadding="0" CellSpacing="0" AutoPostBack="true" OnSelectedIndexChanged="rdbThredTypeComment_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                    <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>--%>
                                                            <%--td valign="bottom">
                                                                <asp:Button ID="btnComment" runat="server" SkinID="btnGen" Text="Comment..." CommandName="btnComment"
                                                                    CommandArgument='<%#Eval("PK_Main_Wall") %>' />&nbsp;&nbsp;
                                                            </td>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="border-bottom: solid 3px #808080; height: 5px;">
                                                    <asp:Repeater ID="rptPostsComments" runat="server" OnItemDataBound="rptPostsComments_ItemDataBound">
                                                        <ItemTemplate>
                                                            <table width="95%" cellpadding="4" cellspacing="1" border="0" style="font-size: 11px;
                                                                font-family: Verdana; background-color: #EDF2F8;">
                                                                <tr>
                                                                    <td align="left" style="color: Gray; padding-left: 5px; border-top: solid 1px Silver;">
                                                                        Posted By:
                                                                        <%# Eval("First_Name") + ", " + Eval("Last_Name")%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;On:&nbsp;<%#clsGeneral.FormatDBNullDateTimeToDisplay(Eval("Update_Date"))%></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="padding-left: 5px;">
                                                                        <table cellpadding="3" cellspacing="1" width="98%" id="Table1" runat="server">
                                                                            <tr style="height: 20px;">
                                                                                <td align="left" width="90%" style="font-weight: bold;">
                                                                                    RE:
                                                                                    <%#Eval("Topic") %>
                                                                                </td>
                                                                                <td align="right" valign="middle" runat="server" id="trExpandControls">
                                                                                    <img id="imgPlusComment<%#Container.ItemIndex %>" alt="" src="../Images/plus.jpg"
                                                                                        style="cursor: pointer;" onclick='javascript:ExpandNotesComment(true,"<%#Container.ItemIndex %>","<%#((HiddenField)Container.Parent.Parent.FindControl("hdnIndex")).Value%>");' />
                                                                                    <img id="imgMinusComment<%#Container.ItemIndex %>" alt="" src="../Images/minus.jpg"
                                                                                        style="cursor: pointer; display: none;" onclick='javascript:ExpandNotesComment(false,"<%#Container.ItemIndex %>","<%#((HiddenField)Container.Parent.Parent.FindControl("hdnIndex")).Value%>");' />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <div id="dvCommentMessage" runat="server" style="overflow-y: auto; font-size: 11px;
                                                                                        font-family: Verdana;">
                                                                                        <%#Eval("Message") %></div>
                                                                                    <asp:HiddenField ID="hdCommentMsgLength" runat="server" Value="0" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        &nbsp;<asp:Label ID="lblAttchmentComment" runat="server" Text="Attachment : "></asp:Label><asp:LinkButton
                                                                            ID="lnkAttchmentComment" runat="server" Visible="false"></asp:LinkButton><br />
                                                                        <asp:Image ID="imgAttachmentComment" runat="server" Width="150" Height="150" Visible="false" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 15px;">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnGen" OnClick="btnSearch_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" Text="  Add  " SkinID="btnGen" OnClick="btnAdd_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnBack" runat="server" Text=" Back " SkinID="btnGen" OnClick="btnBack_Click" />
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 15px;">
                </td>
            </tr>
        </table>
    </div>
    <div id="dvSearch" runat="server" visible="false">
        <table cellpadding="1" cellspacing="0" width="100%" align="center">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="ghc" align="center">
                    Wall Search
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table cellpadding="5" cellspacing="0" border="0" width="70%">
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="15%">
                                Poster Last Name
                            </td>
                            <td align="center" width="5%">
                                :
                            </td>
                            <td align="left" colspan="4">
                                <asp:TextBox ID="txtPosterLastName" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Poster First Name
                            </td>
                            <td align="center" width="5%">
                                :
                            </td>
                            <td align="left" colspan="4">
                                <asp:TextBox ID="txtPosterFirstName" runat="server" Width="170px" MaxLength="50"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="15%">
                                Date of Post From
                            </td>
                            <td align="center" width="5%">
                                :
                            </td>
                            <td align="left">
                              <%--  <asp:TextBox ID="txtDatePostFrom" runat="server" Width="170px" MaxLength="50" SkinID="txtDate"></asp:TextBox>
                                <img alt="" onclick="return showCalendarControl(<%=txtDatePostFrom.ClientID %>, 'mm/dd/y','Date of Post From');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                    align="absmiddle" />
                                <asp:RegularExpressionValidator ID="revIssueDateFrom" runat="server" ControlToValidate="txtDatePostFrom"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="Please Enter Valid Date of Post From" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>--%>
                                  <asp:TextBox ID="txtDatePostFrom" runat="server" Width="180px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtDatePostFrom.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="../../Images/iconPicDate.gif"
                                    align="middle" id="img2" />
                                <cc1:maskededitextender ID="MaskedEditExtender1" runat="server" AcceptNegative="Left"
                                    DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                    OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDatePostFrom"
                                    CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                </cc1:maskededitextender>
                                <br />
                                <asp:RegularExpressionValidator ID="revtxtDatePostFrom" runat="server" ControlToValidate="txtDatePostFrom"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage=" Date of Post From is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td align="left" width="14%">
                                Date of Post To
                            </td>
                            <td align="center" width="2%">
                                :
                            </td>
                            <td align="left">
                              <%--  <asp:TextBox ID="txtDatePostTo" runat="server" Width="150px" MaxLength="50" SkinID="txtDate"></asp:TextBox>
                                <img alt="" onclick="return showCalendarControl(<%=txtDatePostTo.ClientID %>, 'mm/dd/y','Date of Post To');"
                                    onmouseover="javascript:this.style.cursor='hand';" src="<%=AppConfig.SiteURL%>JavaScript/iconPicDate.gif"
                                    align="absmiddle" />
                                <asp:RegularExpressionValidator ID="revIssueDateTo" runat="server" ControlToValidate="txtDatePostTo"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="Please Enter Valid Date of Post To" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvCompDate" runat="server" ControlToValidate="txtDatePostTo"
                                    ValidationGroup="vsErrorGroup" ErrorMessage="Date of Post From must be Less than or equal to Date of Post To"
                                    Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDatePostFrom" Display="none">
                                </asp:CompareValidator>--%>
                                <asp:TextBox ID="txtDatePostTo" runat="server" Width="180px" SkinID="txtDate"
                                    MaxLength="10"></asp:TextBox>
                                <img onclick="return showCalendar('<%= txtDatePostTo.ClientID %>', 'mm/dd/y');"
                                    onmouseover="javascript:this.style.cursor='hand';" alt="" src="../../Images/iconPicDate.gif"
                                    align="middle" id="img1" />
                                <cc1:maskededitextender ID="MaskedEditExtender2" runat="server" AcceptNegative="Left"
                                    DisplayMoney="Left" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true"
                                    OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtDatePostTo"
                                    CultureName="en-US" AutoComplete="true" AutoCompleteValue="05/23/1964">
                                </cc1:maskededitextender>
                                <br />
                                <asp:RegularExpressionValidator ID="rfvtxtDatePostTo" runat="server" ControlToValidate="txtDatePostTo"
                                    ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                    ErrorMessage="  Date of Post To is Not Valid Date" Display="none" ValidationGroup="vsErrorGroup"
                                    SetFocusOnError="true">
                                </asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="cvCompDate" runat="server" ControlToValidate="txtDatePostTo"
                                    ValidationGroup="vsErrorGroup" ErrorMessage="Date of Post From must be Less than or equal to Date of Post To"
                                    Type="Date" Operator="GreaterThanEqual" ControlToCompare="txtDatePostFrom" Display="none">
                                </asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Topic
                            </td>
                            <td align="center" width="5%" valign="top">
                                :
                            </td>
                            <td align="left" colspan="4">
                                <asp:TextBox ID="txtTopic" runat="server" MaxLength="250" Width="520px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                Post Text
                            </td>
                            <td align="center" width="5%" valign="top">
                                :
                            </td>
                            <td align="left" colspan="4">
                                <asp:TextBox ID="txtPostText" TextMode="MultiLine" Rows="4" runat="server" MaxLength="4000"
                                    Width="520px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" class="Spacer" style="height: 15px;" colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                <asp:Button ID="btnSearchResult" runat="server" Text="Search" SkinID="btnGen" OnClick="btnSearchResult_Click"
                                    CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" class="Spacer" style="height: 15px;" colspan="6">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" class="Spacer" style="height: 15px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
