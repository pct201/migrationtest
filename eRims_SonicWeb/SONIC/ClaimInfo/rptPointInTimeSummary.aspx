<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptPointInTimeSummary.aspx.cs" 
Inherits="SONIC_ClaimInfo_rptPointInTimeSummary" Title="eRIMS Sonic :: Point-in-Time Summary Report"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
<script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
<script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
<script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>

<asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="vsErrorGroup"/>
    <table width="100%">
        <tr>
            <td align="left" class="ghc">
               Point-in-Time Summary Report
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="80%" align="center" cellpadding="0" cellspacing="8">
                    <tr>
                        <td width="150" align="left">
                            Comparison Dates<span class="mf">*</span>
                        </td>
                        <td width="4">
                            :</td>
                        <td width="4" align="left">
                            First :</td>
                        <td width="150">
                            <asp:TextBox runat="server" ID="txtCompDate1" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCompDate1', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="rfvDateFrom1" runat="server" ControlToValidate="txtCompDate1"
                                ErrorMessage="Please enter First Comparison Date" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />
                            <asp:RangeValidator ID="revDateFrom1" ControlToValidate="txtCompDate1" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="First Comparison Date is not valid"
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                        </td>
                        <td width="4" align="right">
                            Second :</td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtCompDate2" Width="100px" SkinID="txtDate"></asp:TextBox>
                            <img alt="Prior Valuation Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtCompDate2', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCompDate2"
                                ErrorMessage="Please enter Second Comparison Date" SetFocusOnError="true" ValidationGroup="vsErrorGroup"
                                Display="none" />
                            <asp:RangeValidator ID="RangeValidator1" ControlToValidate="txtCompDate2" MinimumValue="01/01/1753"
                                MaximumValue="12/31/9999" Type="Date" ErrorMessage="Second Comparison Date is not valid"
                                runat="server" SetFocusOnError="true" ValidationGroup="vsErrorGroup" Display="none" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Date" ControlToValidate="txtCompDate2" ControlToCompare="txtCompDate1" 
                            Operator="GreaterThanEqual" ErrorMessage="Comparison Date Second must be greater than Comparison Date First" Display="None" SetFocusOnError="true" ValidationGroup="vsErrorGroup" />    
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="150">
                            Accident Year<span class="mf">*</span></td>
                        <td valign="top" width="4">
                            :</td>
                        <td align="left" colspan="4">
                            <asp:ListBox ID="lsbPolicyYear" runat="server" SelectionMode="Multiple" Rows="4"
                                ToolTip="" AutoPostBack="false" Width="150px"></asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlsbPlicyYear" runat="server" ErrorMessage="Please Select Accident Year." ValidationGroup="vsErrorGroup"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lsbPolicyYear" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="150" valign="top" align="left">
                            Claim Type<span class="mf">*</span></td>
                        <td width="4" valign="top">
                            :</td>
                        <td colspan="4" align="left">
                            <asp:ListBox ID="lsbClaimType" runat="server" SelectionMode="Multiple" Rows="4" ToolTip=""
                                AutoPostBack="false" Width="150px">
                                <asp:ListItem Value="W" Text="Workers Compensation"></asp:ListItem>
                                <asp:ListItem Value="A" Text="Auto Loss"></asp:ListItem>                                
                                <asp:ListItem Value="P" Text="Premises Loss"></asp:ListItem>
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="rfvlsbClaimType" runat="server" ErrorMessage="Please Select Claim Type." ValidationGroup="vsErrorGroup"
                                Font-Bold="true" Display="none" Text="*" ControlToValidate="lsbClaimType" SetFocusOnError="false"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="150" align="left">
                        </td>
                        <td valign="top" width="4">
                        </td>
                        <td colspan="4" align="left">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click" CausesValidation="true" ValidationGroup="vsErrorGroup"/>
                            &nbsp;<asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                CausesValidation="false" OnClick="btnClearCriteria_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlReport" runat="server" Visible="false">
        <table width="90%" align="center">
           <tr>
                <td align="center">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <table id="tblUtility" runat="server" width="100%" align="center">
                        <tr valign="middle">
                            <td align="right" width="100%">
                                <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel" OnClick="lbtExportToExcel_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%-- <tr>
                <td>
                    <asp:Label ID="lblHeader" Text="Summary Points-in-Time Report" runat="server">
                    </asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td align="left" colspan="2">
                    <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvReport_RowDataBound"
                        Width="100%" EnableTheming="false" HorizontalAlign="Left" EmptyDataText="No Record found !"
                        CssClass="GridClass" GridLines="None" ShowFooter="true" OnRowCreated="gvReport_RowCreated">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" Font-Bold="true" />
                        <RowStyle BackColor="White" HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" />
                        <FooterStyle CssClass="FooterStyle" />                        
                        <Columns>
                            <asp:TemplateField>
                                <ItemStyle BackColor="White" />
                                <HeaderTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; font-weight: bold;" id="tblHeader" runat="server">
                                                                <tr valign="middle">
                                                                    <td align="left" valign="middle">
                                                                        Claim Type</td>
                                                                    <td width="150px" align="right">
                                                                        &nbsp;</td>
                                                                    <td width="120px" align="right">
                                                                        <asp:Label ID="lblDate1" runat="server"></asp:Label><br />
                                                                        Total Dollars</td>
                                                                    <td width="120px" align="right">
                                                                        <asp:Label ID="lblDate2" runat="server"></asp:Label><br />
                                                                        Total Dollars</td>
                                                                    <td width="120px" align="right">
                                                                        <asp:Label ID="Label2" runat="server">Difference</asp:Label></td>
                                                                    <td width="120px" align="center">
                                                                        <asp:Label ID="Label3" runat="server" Text="Claim Count"></asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                        <tr>
                                            <td align="left" style="height:25px;" valign="middle">
                                                <asp:Label ID="lblPolicyYear" runat="server" Text='<%# "Accident Year - " + Eval("AccidentYear")%>'
                                                    Font-Bold="true">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:GridView ID="gvSubReport" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    CellPadding="4" GridLines="None" CssClass="GridClass" EnableTheming="false" HorizontalAlign="Left"
                                                    EmptyDataText="No Record Found !" EmptyDataRowStyle-HorizontalAlign="Left" ShowHeader="false"
                                                    ShowFooter="true">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" />
                                                    <RowStyle HorizontalAlign="Left" CssClass="RowStyle" />
                                                    <AlternatingRowStyle HorizontalAlign="left" CssClass="AlterRowStyle" />
                                                    <FooterStyle ForeColor="Black" Font-Bold="true" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table align="left" border="0" cellpadding="0" cellspacing="0" style="width: 100%;
                                                                    border-collapse: collapse;" id="tblDetails" runat="server">
                                                                    <tr>
                                                                        <td colspan="6">
                                                                            <asp:Label ID="lblClaimType" runat="server" Text='<%# "Claim Type - " + Eval("ClaimType") %>'></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;
                                                                        </td>
                                                                        <td width="150px" align="right">
                                                                            Incurred :</td>
                                                                        <td width="120px" align="right">
                                                                            <asp:Label ID="lblInc1" runat="server" Text='<%#Eval("Incurred_1","{0:C2}") %>'></asp:Label></td>
                                                                        <td width="120px" align="right">
                                                                            <asp:Label ID="lblInc2" runat="server" Text='<%#Eval("Incurred_2","{0:C2}") %>'></asp:Label></td>
                                                                        <td width="120px" align="right">
                                                                            <asp:Label ID="lblIncD" runat="server" Text='<%#Eval("Incurred_D","{0:C2}") %>'></asp:Label></td>
                                                                        <td width="120px" align="center">
                                                                            <asp:Label ID="lblClaimCount" runat="server" Text='<%#Eval("ClaimCount") %>'></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;
                                                                        </td>
                                                                        <td align="right">
                                                                            Paid :</td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPaid1" runat="server" Text='<%#Eval("Paid_1","{0:C2}") %>'></asp:Label></td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPaid2" runat="server" Text='<%#Eval("Paid_2","{0:C2}") %>'></asp:Label></td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblPaidD" runat="server" Text='<%#Eval("Paid_D","{0:C2}") %>'></asp:Label></td>
                                                                        <td align="center">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;
                                                                        </td>
                                                                        <td align="right">
                                                                            Outstanding :</td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblOut1" runat="server" Text='<%#Eval("OutStanding_1","{0:C2}") %>'></asp:Label></td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblOut2" runat="server" Text='<%#Eval("OutStanding_2","{0:C2}") %>'></asp:Label></td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblOutD" runat="server" Text='<%#Eval("Out_D","{0:C2}") %>'></asp:Label></td>
                                                                        <td align="center">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <table align="left" border="0" cellpadding="0" cellspacing="0" style="width: 100%;
                                                                    font-weight: bold; color: Black;" id="tblFooter" runat="server">
                                                                    <tr>
                                                                        <td colspan="6">
                                                                            <asp:Label ID="lblClaimType" runat="server" Text="Total Accident Year :"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;
                                                                        </td>
                                                                        <td width="150px" align="right">
                                                                            Incurred :</td>
                                                                        <td width="120px" align="right">
                                                                            <asp:Label ID="lblSubInc1" runat="server"></asp:Label></td>
                                                                        <td width="120px" align="right">
                                                                            <asp:Label ID="lblSubInc2" runat="server"></asp:Label></td>
                                                                        <td width="120px" align="right">
                                                                            <asp:Label ID="lblSubIncD" runat="server"></asp:Label></td>
                                                                        <td width="120px" align="center">
                                                                            <asp:Label ID="lblSubClaimCount" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;
                                                                        </td>
                                                                        <td align="right">
                                                                            Paid :</td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblSubPaid1" runat="server"></asp:Label></td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblSubPaid2" runat="server"></asp:Label></td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblSubPaidD" runat="server"></asp:Label></td>
                                                                        <td align="right">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>&nbsp;
                                                                        </td>
                                                                        <td align="right">
                                                                            Outstanding :</td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblSubOut1" runat="server"></asp:Label></td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblSubOut2" runat="server"></asp:Label></td>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblSubOutD" runat="server"></asp:Label></td>
                                                                        <td align="center">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <table align="left" border="0" cellpadding="0" cellspacing="0" width="100%" style="font-weight: bold;
                                                                background-color: #507CD1; color: #ffffff;" id="tblFooter" runat="server">
                                                                <tr>
                                                                    <td colspan="6" align="left">
                                                                        <asp:Label ID="lblClaimType" runat="server" Text="Report Grand Total "></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                    <td width="150px" align="right">
                                                                        Incurred :</td>
                                                                    <td width="120px" align="right">
                                                                        <asp:Label ID="lblGTInc1" runat="server"></asp:Label></td>
                                                                    <td width="120px" align="right">
                                                                        <asp:Label ID="lblGTInc2" runat="server"></asp:Label></td>
                                                                    <td width="120px" align="right">
                                                                        <asp:Label ID="lblGTIncD" runat="server"></asp:Label></td>
                                                                    <td width="120px" align="center">
                                                                        <asp:Label ID="lblGTClaimCount" runat="server"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                    <td align="right">
                                                                        Paid :</td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblGTPaid1" runat="server"></asp:Label></td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblGTPaid2" runat="server"></asp:Label></td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblGTPaidD" runat="server"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>&nbsp;
                                                                    </td>
                                                                    <td align="right">
                                                                        Outstanding :</td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblGTOut1" runat="server"></asp:Label></td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblGTOut2" runat="server"></asp:Label></td>
                                                                    <td align="right">
                                                                        <asp:Label ID="lblGTOutD" runat="server"></asp:Label></td>
                                                                    <td align="center">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table width="100%">
        <tr>
            <td class="Spacer" style="height: 15px;">
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 50px;">
            </td>
        </tr>
    </table>
</asp:Content>

