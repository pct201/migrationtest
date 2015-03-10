<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptLocationsLeaseandPolicyDates.aspx.cs" Inherits="COIReports_rptLocationsLeaseandPolicyDates" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .ReportTable-td {
            border-left: none;
            border-right: 1px solid black;
            border-top: 1px solid black;
            border-bottom: 1px solid black;
            /*border: 1px solid red;*/
        }

        .ReportTable-td-first {
            border: 1px solid black;
        }
    </style>
    <table width="100%" cellpadding="0" cellspacing="2">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr>
            <td align="left" class="ghc" colspan="2">Locations - Lease and Policy Dates</td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td width="2%">&nbsp;
            </td>
            <td align="center">
                <asp:UpdatePanel ID="upReport" runat="server">
                    <ContentTemplate>
                        <table width="83%" align="center" style="text-align: left;" cellpadding="2" cellspacing="3" border="0">
                            <tr>
                                <td>Sublease Agreement
                                </td>
                                <td align="right">:
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rdbSubleaseAgreement" runat="server">
                                        <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr valign="top" align="left">
                                <td>Region
                                </td>
                                <td align="right">:
                                </td>
                                <td align="left" colspan="4">
                                    <asp:ListBox ID="lstRegion" runat="server" SelectionMode="Multiple" Width="250px" OnSelectedIndexChanged="lstRegion_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
                                </td>
                            </tr>
                            <tr valign="top" align="left">
                                <td>Market
                                </td>
                                <td align="right">:
                                </td>
                                <td align="left" colspan="4">
                                    <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" Width="250px" ></asp:ListBox>
                                </td>
                            </tr>
                            <tr valign="top" align="left">
                                <td>Location
                                </td>
                                <td align="right">:
                                </td>
                                <td align="left" colspan="4">
                                    <asp:ListBox ID="lstLocation" runat="server" SelectionMode="Multiple" Width="250px"></asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Building Status
                                </td>
                                <td align="right" valign="top">:
                                </td>
                                <td align="left" valign="top">
                                    <asp:ListBox ID="lstBuildingStatus" runat="server" Width="170px" Rows="4" SelectionMode="Multiple">
                                        <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                        <asp:ListItem Text="InActive" Value="Inactive"></asp:ListItem>
                                        <asp:ListItem Text="Disposed" Value="Disposed"></asp:ListItem>
                                    </asp:ListBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">Insured Active
                                </td>
                                <td align="left" valign="top">:</td>
                                <td>
                                    <asp:RadioButtonList ID="rdbInsuredActive" runat="server">
                                        <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center">
                                    <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click" CausesValidation="true" />
                                    &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnShowReport" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
                    <ProgressTemplate>
                        <div class="UpdatePanelloading" id="divProgress" style="width: 100%; position: fixed;">
                            <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                                <tr align="center" valign="middle">
                                    <td class="LoadingText" align="center" valign="middle">
                                        <img src="../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table id="tblReport" runat="server" style="height: 1000px" cellpadding="3" cellspacing="3">
        <tr valign="middle">
            <td align="right" width="100%">
                <asp:LinkButton ID="lbtExportToExcel" runat="server" Text="Export To Excel"
                    OnClick="lbtExportToExcel_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;"></td>
        </tr>
        <tr id="trGrid" runat="server">
            <td align="left" valign="top">
                <div style="overflow: scroll; width: 990px; height: 1000px;" id="dvGrid" runat="server">
                    <asp:GridView ID="gvReport" EnableTheming="false" DataKeyNames="dba" runat="server"
                        AutoGenerateColumns="false" Width="1334px" HorizontalAlign="Left" GridLines="None"
                        ShowHeader="true" ShowFooter="true" EmptyDataText="No Record Found" CellPadding="2"
                        CellSpacing="2">
                        <HeaderStyle CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                        <FooterStyle ForeColor="Black" Font-Bold="true" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <table width="1334px" cellpadding="4" cellspacing="0" border="0" style="font-weight: bold;" id="tblHeader" runat="server">
                                        <tr class="HeaderStyle">
                                            <td align="left" colspan="2">Sonic Automotive
                                            </td>
                                            <td align="center" colspan="2">Locations - Lease and Policy Dates
                                            </td>
                                            <td align="right">
                                                <%=DateTime.Now.ToString()  %>
                                            </td>
                                        </tr>
                                        <tr class="HeaderStyle">
                                            <td align="left" width="410px">D/B/A Location Name
                                            </td>
                                            <td align="left" width="100px">Region
                                            </td>
                                            <td align="left" width="200px">SubtenantDBA
                                            </td>
                                            <td align="left" width="300px">Lease Expiration Date
                                            </td>
                                            <td align="left" width="300px">COI Dates
                                            </td>
                                            <td align="left" width="324px">Limits and Coverage
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <table width="1334px" cellpadding="0" cellspacing="0" id="tblRow" runat="server">
                                        <tr>
                                            <td align="left" width="410px" class="ReportTable-td-first" valign="top">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <asp:Label ID="Label25" runat="server" Text='<%# GetValue((string)Eval("dba")) %>'></asp:Label>
                                                            <%--<asp:Label ID="lblLocation" runat="server" Text='<%# Eval("dba") %>'></asp:Label>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;&nbsp;&nbsp;                                                             
                                                            <asp:Label ID="lblBuildingNumber" runat="server" Text="Building Number/Address:" Font-Bold="true"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Server.HtmlDecode (Eval("FullAddress").ToString()) %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left" width="100px" valign="top" class="ReportTable-td">
                                                <asp:Label ID="lblRegion" runat="server" Text='<%# Eval("FK_COI_Region") %>'></asp:Label>
                                            </td>
                                            <td align="left" width="200px" valign="top" class="ReportTable-td">
                                                <asp:Label ID="lblSubtenantDBA" runat="server" Text='<%# GetValue((string)Eval("Subtenant_DBA")) %>'></asp:Label>
                                                <%--<asp:Label ID="lblSubtenantDBA" runat="server" Text='<%# Eval("Subtenant_DBA") %>'></asp:Label>--%>
                                            </td>
                                            <td align="left" width="300px" class="ReportTable-td" valign="top">
                                                <table cellpadding="3" cellspacing="3">                                                    
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px" valign="top">Sublease Commencement Date :</td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubleaseCommencementDate" runat="server" Text='<%# Eval("Sublease_Commencement_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="font-weight: bold; margin-left: 15px">Sublease Expiration Date :</td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblSubleaseExpirationDate" runat="server" Text='<%# Eval("Sublease_Expiration_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left" width="300px" class="ReportTable-td" valign="top">
                                                <table cellpadding="3" cellspacing="3">                                                    
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px" valign="top">Date Requested :</td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblDate_Requested" runat="server" Text='<%# Eval("Date_Requested") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" valign="top" style="font-weight: bold; margin-left: 15px">Date Recieved :</td>
                                                                    <td align="left" valign="top">
                                                                        <asp:Label ID="lblIssue_Date" runat="server" Text='<%# Eval("Issue_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left" width="324px" class="ReportTable-td">
                                                <table cellpadding="3" cellspacing="3" width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblCoverage" runat="server" Font-Bold="true" Text="General Liability Policy"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table cellpadding="3" cellspacing="3">
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Required :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblgeneralRequired" runat="server" Text='<%# Eval("General_Required") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Effective Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblGeneralEffectiveDate" runat="server" Text='<%# Eval("General_Effective_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Expiration Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblGeneralExpirationDate" runat="server" Text='<%# Eval("General_Expiration_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Has Risk :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label26" runat="server" Text='<%# Eval("GeneralRisk") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="lblCoverage2" runat="server" Font-Bold="true" Text="Automobile Liability Policy"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table cellpadding="3" cellspacing="3">
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Required :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Automobile_Required") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Effective Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Auto_Effective_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Expiration Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Auto_Expiration_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Has Risk :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label27" runat="server" Text='<%# Eval("AutoRisk") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Excess Liability Policy"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table cellpadding="3" cellspacing="3">
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Required :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Excess_Required") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Effective Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("Excess_Effective_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Expiration Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("Excess_Expiration_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Has Risk :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label28" runat="server" Text='<%# Eval("ExcessRisk") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label9" runat="server" Font-Bold="true" Text="Workers Compensation/Employer Liability Policy"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table cellpadding="3" cellspacing="3">
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Required :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("WC_Required") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Effective Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("WC_Effective_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Expiration Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("Wc_Expiration_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Has Risk :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label29" runat="server" Text='<%# Eval("WcRisk") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label13" runat="server" Font-Bold="true" Text="Property Policy"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table cellpadding="3" cellspacing="3">
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Required :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("Property_Required") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Effective Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label15" runat="server" Text='<%# Eval("Property_Effective_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Expiration Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label16" runat="server" Text='<%# Eval("Property_Expiration_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Has Risk :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label30" runat="server" Text='<%# Eval("PropertyRisk") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label17" runat="server" Font-Bold="true" Text="Professional Liability Policy"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table cellpadding="3" cellspacing="3">
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Required :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label18" runat="server" Text='<%# Eval("Professional_Required") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Effective Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label19" runat="server" Text='<%# Eval("Professional_Effective_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Expiration Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label20" runat="server" Text='<%# Eval("Professional_Expiration_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Has Risk :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label31" runat="server" Text='<%# Eval("ProfessionaRisk") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label21" runat="server" Font-Bold="true" Text="Other Liability Policy"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table cellpadding="3" cellspacing="3">
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Required :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label22" runat="server" Text='<%# Eval("Liquor_Required") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Effective Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label23" runat="server" Text='<%# Eval("Other_Effective_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Expiration Date :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label24" runat="server" Text='<%# Eval("Other_Expiration_Date") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" style="font-weight: bold; margin-left: 15px">Has Risk :</td>
                                                                    <td align="left">
                                                                        <asp:Label ID="Label32" runat="server" Text='<%# Eval("OtherRisk") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button runat="server" ID="btnBack" OnClick="btnBack_Click" Text="Back" />
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 10px;"></td>
        </tr>
    </table>
</asp:Content>

