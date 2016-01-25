<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="AddWall_ByLocation.aspx.cs" Inherits="SONIC_SLT_AddWall_ByLocation" %>

  <%@ Register Src="~/Controls/Notes/Notes.ascx" TagName="ctrlMultiLineTextBox"
    TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../../JavaScript/jquery.min.js"> </script>
    <script language="javascript" type="text/javascript">
        function ValidateAttachmentType(obj, args) {

            var file1 = document.getElementById('<%=fpImage.ClientID%>').value;
            if (file1 == '') {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
            return args.IsValid;

        }

        $(document).ready(function () {
            ShowHideRow();

            $("#<%=rdoFilter_By.ClientID%>").change(function () {
                ShowHideRow();
            });
        });

        function ShowHideRow() {
            var rdoFilter_By = $("#<%=rdoFilter_By.ClientID%> input[type='radio']:checked").val();
            if (rdoFilter_By == 'All_Sonic_Automotive') {
                $("#trRegion").hide(); $("#trMarket").hide();
            }
            else if (rdoFilter_By == 'Location') {
                $("#trRegion").hide(); $("#trMarket").hide(); $("#trLocation").show();
            }
            else if (rdoFilter_By == 'Region') {
                $("#trRegion").show(); $("#trMarket").hide(); $("#trLocation").hide();
            }
            else if (rdoFilter_By == 'Market') {
                $("#trRegion").hide(); $("#trMarket").show(); $("#trLocation").hide();
            }
            else {
                $("#trRegion").hide(); $("#trMarket").hide(); $("#trLocation").hide();
            }
        }

    </script>
    <asp:ValidationSummary ID="valSummary" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="dvContainer">
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td  align="left">
                            <div class="bandHeaderRow" style="text-align: center">
                                <asp:Label ID="lblHeadingMessage" runat="server" Text="Wall Post By Location"></asp:Label></div>
                            <table align="center" cellpadding="5" cellspacing="5" width="70%">
                                <tr>
                                    <td colspan="3">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:RadioButtonList ID="rdoFilter_By" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                            <asp:ListItem Text="Location" Value="Location"></asp:ListItem>
                                            <asp:ListItem Text="Market" Value="Market"></asp:ListItem>
                                            <asp:ListItem Text="Region" Value="Region"></asp:ListItem>
                                            <asp:ListItem Text="All Sonic Automotive" Selected="True" Value="All_Sonic_Automotive"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr id="trRegion">
                                    <td>
                                        Region
                                    </td>
                                     <td>:</td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlRegion" runat="server" SkinID="default" Width="175px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="trMarket">
                                    <td>
                                        Market
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlMarket" runat="server" SkinID="default" Width="175px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="trLocation">
                                    <td>
                                        Location
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlLocationdba" runat="server" SkinID="default" Width="175px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="18%" align="left" valign="top">
                                        Poster
                                    </td>
                                    <td width="2%" align="center" valign="top">
                                        :
                                    </td>
                                    <td width="80%" align="left" valign="top">
                                        <asp:Label ID="lblPoster" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        Date
                                    </td>
                                    <td align="center" valign="top">
                                        :
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        <asp:Label ID="lblTopic" runat="server" Text="Topic"></asp:Label><span class="mf">*</span>
                                    </td>
                                    <td align="center" valign="top">
                                        :
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:TextBox ID="txtTopic" Width="570px" runat="server" MaxLength="250" TabIndex="3"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="revTopic" runat="server" ControlToValidate="txtTopic" ErrorMessage="Please Enter Topic" ValidationGroup="vsErrorGroup" Display="None"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                 <tr>
                                    <td align="left" valign="top">
                                       Type
                                    </td>
                                    <td align="center" valign="top">
                                        :
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:Label ID="lblType" runat="server" Text="Main"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        Message <span class="mf">*</span>
                                    </td>
                                    <td align="center" valign="top">
                                        :
                                    </td>
                                    <td align="left" valign="top">
                                        <uc:ctrlMultiLineTextBox ID="txtMessage" runat="server"  ValidationGroup="vsErrorGroup" IsRequired="true" ControlType="TextBox" RequiredFieldMessage="Please Enter Message"  />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">
                                        Attachment
                                    </td>
                                    <td align="center" valign="top">
                                        :
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:FileUpload ID="fpImage" runat="server" Width="500px" />
                                        <asp:CustomValidator ID="cstFile" runat="Server" ControlToValidate="fpImage" ErrorMessage="Invalid Attachment Type"
                                            Display="None" ValidationGroup="vsErrorGroup" ClientValidationFunction="ValidateAttachmentType"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Spacer" style="height: 10px;">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSave" runat="server" SkinID="Save" CausesValidation="true" ValidationGroup="vsErrorGroup"
                                OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" CssClass="btn"
                                Style="width: 80px;" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer" style="height: 10px;">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>