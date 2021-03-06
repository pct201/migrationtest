<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="RptBordereau.aspx.cs"
    Inherits="ERReports_Bordereau" Title="eRIMS Sonic :: Bordereau Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>

    <asp:validationsummary id="vsErrSum" validationgroup="vsError" runat="server" showmessagebox="true"
        showsummary="false" headertext="Verify the following fields" borderwidth="1"
        bordercolor="DimGray" cssclass="errormessage" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;"></td>
        </tr>
        <tr>
            <td width="100%" class="ghc">&nbsp;&nbsp;Bordereau Report
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;"></td>
        </tr>
        <tr>
            <td align="left">
                <table cellpadding="3" cellspacing="0" width="50%" align="center">
                    <tr>
                        <td width="28%" align="left">Start Date
                        </td>
                        <td width="4%" align="center">:
                        </td>
                        <td>
                            <asp:textbox runat="server" id="txtStartDate" width="170px" skinid="txtDate"></asp:textbox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtStartDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="middle" />
                            <asp:requiredfieldvalidator id="rfvStartDate" runat="server" controltovalidate="txtStartDate"
                                errormessage="Please enter Start Date" validationgroup="vsError" display="none" />
                            <asp:rangevalidator id="revDate" controltovalidate="txtStartDate" minimumvalue="01/01/1753"
                                maximumvalue="12/31/9999" type="Date" errormessage="Start Date is not valid."
                                runat="server" setfocusonerror="true" validationgroup="vsError" display="none" />
                        </td>
                    </tr>
                    <tr>
                        <td width="28%" align="left">End Date
                        </td>
                        <td width="4%" align="center">:
                        </td>
                        <td>
                            <asp:textbox runat="server" id="txtEndDate" width="170px" skinid="txtDate"></asp:textbox>
                            <img alt="Date Opened" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtEndDate', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../Images/iconPicDate.gif"
                                align="middle" />
                            <asp:requiredfieldvalidator id="rfvEndDate" runat="server" controltovalidate="txtEndDate"
                                errormessage="Please enter End Date" validationgroup="vsError" display="none" />
                            <asp:rangevalidator id="revEndDate" controltovalidate="txtEndDate" minimumvalue="01/01/1753"
                                maximumvalue="12/31/9999" type="Date" errormessage="End Date is not valid." runat="server"
                                setfocusonerror="true" validationgroup="vsError" display="none" />
                            <asp:comparevalidator id="cvDate" runat="server" controltovalidate="txtEndDate" controltocompare="txtStartDate"
                                type="Date" errormessage="End Date must be greater than or equal to Start Date"
                                operator="GreaterThanEqual" setfocusonerror="true" validationgroup="vsError"
                                display="none"></asp:comparevalidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">Region
                        </td>
                        <td align="center">:
                        </td>
                        <td align="left">
                            <asp:dropdownlist id="drpRegion" runat="server" skinid="ddlSONIC" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">Market
                        </td>
                        <td align="center">:
                        </td>
                        <td align="left">
                            <asp:dropdownlist id="ddlMarket" runat="server" skinid="ddlSONIC" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;
                        </td>
                        <td align="left">
                            <asp:button id="btnGenerateReport" runat="server" text="Generate Report" onclick="btnGenerateReport_Click"
                                causesvalidation="true" validationgroup="vsError" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;"></td>
        </tr>
        <tr>
            <td align="center">
                <table cellpadding="1" cellspacing="1" width="1000px">
                    <tr>
                        <td align="right">
                            <asp:linkbutton id="lnkExport" runat="server" text="Export To Excel" onclick="lnkExport_Click"
                                visible="false" />
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 5px;"></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <div style="display: none; text-align: left;" id="divReport_Grid" runat="server"
                                width="999px">
                                <asp:gridview id="gvReport" runat="server" width="100%" emptydatatext="No Records Found"
                                    onrowcreated="gvReport_RowCreated" enabletheming="false" gridlines="None" showfooter="true"
                                    autogeneratecolumns="false" onrowdatabound="gvReport_RowDataBound">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" VerticalAlign="top" />
                                    <RowStyle BackColor="White" VerticalAlign="top" />
                                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="true" HorizontalAlign="left" />
                                    <AlternatingRowStyle BackColor="White" VerticalAlign="top" />
                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <table cellpadding="4" cellspacing="0" width="100%" style="font-weight: bold;" id="tblHeader"
                                                                runat="server">
                                                                <tr valign="top">
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label22" runat="server" Width="120px" Text='Claim Number' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="lblH1" runat="server" Width="120px" Text='Type of Allegation' />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="Label23" runat="server" Width="200px" Text='Complainant/ Plaintiff' />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label1" runat="server" Width="300px" Text='Claim Description' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label2" runat="server" Width="120px" Text='Carrier' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label3" runat="server" Width="120px" Text='Type of Claim' />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="LblOtherType" runat="server" Width="200px" Text='Other Type Description' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label4" runat="server" Width="120px" Text='Policy Number' />
                                                                    </td>
                                                                    <td style="width: 120px;" align="right">
                                                                        <asp:Label ID="Label5" runat="server" Width="120px" Text='Deductible' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label6" runat="server" Width="120px" Text='Date of Alleged Wrongful Act' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label7" runat="server" Width="120px" Text='Date Claim Opened' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label8" runat="server" Width="120px" Text='Policy Effective Date' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label9" runat="server" Width="120px" Text='Policy Expiration Date' />
                                                                    </td>
                                                                    <td style="width: 150px;" align="right">
                                                                        <asp:Label ID="Label10" runat="server" Width="150px" Text='Estimated Demand Exposure' />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label11" runat="server" Width="300px" Text='Claim Status/Comments' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label12" runat="server" Width="120px" Text='Internal Counsel' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label13" runat="server" Width="120px" Text='Internal Counsel Phone' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label16" runat="server" Width="120px" Text='Location Code' />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="Label17" runat="server" Width="200px" Text='Sonic Location Name' />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="Label18" runat="server" Width="200px" Text='Location d/b/a' />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="Label14" runat="server" Width="200px" Text='Entity' />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label15" runat="server" Width="120px" Text='Defense Attorney' />
                                                                    </td>
                                                                    <td style="width: 650px;">
                                                                        <div>
                                                                            <table runat="server" id="tblPAInfo" style="font-weight: bold; border-collapse: collapse"
                                                                                cellspacing="0" cellpadding="4" border="0">
                                                                                    <tr valign="top">
                                                                                        <td colspan="4">
                                                                                            Plaintiff Attorney Information
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr valign="top">
                                                                                        <td style="width: 150px" align="left">
                                                                                            <span style="display: inline-block; width: 150px">Firm</span>
                                                                                        </td>
                                                                                        <td style="width: 150px" align="left">
                                                                                            <span style="display: inline-block; width: 150px">Name</span>
                                                                                        </td>
                                                                                        <td style="width: 200px" align="left">
                                                                                            <span style="display: inline-block; width: 200px">Address</span>
                                                                                        </td>
                                                                                        <td style="width: 150px" align="left">
                                                                                            <span style="display: inline-block; width: 150px">Phone Number</span>
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
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="left" style="background-color: White; height: 25px; color: Black;" width="100%">
                                                            <b>
                                                                <asp:Label ID="lblRegion" runat="server"><%#Eval("Region")%></asp:Label>
                                                            </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvClaimData" runat="server" ShowHeader="false" Width="100%" OnRowDataBound="gvClaimData_RowDataBound"
                                                                CellPadding="4" GridLines="None" CssClass="GridClass" AutoGenerateColumns="false"
                                                                EnableTheming="false" ShowFooter="true">
                                                                <FooterStyle BackColor="white" ForeColor="Black" Font-Bold="true" />
                                                                <RowStyle CssClass="RowStyle" VerticalAlign="top" />
                                                                <AlternatingRowStyle CssClass="AlterRowStyle" VerticalAlign="top" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblClaim_Number" runat="server" Width="120px" Text='<%#Eval("Claim_Number")%>' />
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            Total
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl1" runat="server" Width="120px" Text='<%#Eval("Type_of_Allegation")%>' />
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblTotal" runat="server" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="200px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblComplainant_Plaintiff" runat="server" Width="200px" Text='<%#Eval("Complainant_Plaintiff")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="300px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl2" runat="server" Width="300px" Text='<%#Eval("Claim_Description")%>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl15" runat="server" Width="120px" Text='<%#Eval("Carrier")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl16" runat="server" Width="120px" Text='<%#Eval("Type_Of_Claim")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="200px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl1Claim_Type_Other" runat="server" Width="200px" Text='<%#Eval("Claim_Type_Other")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl3" runat="server" Width="120px" Text='<%#Eval("Primary_Insurance_Policy_Number")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl4" runat="server" Width="120px" Text='<%#clsGeneral.GetStringValue(Eval("Primary_Deductable")) %>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl5" runat="server" Width="120px" Text='<%# Eval("Date_Alleged_Wrongful_Act") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Date_Alleged_Wrongful_Act"))) : ""%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl6" runat="server" Width="120px" Text='<%# Eval("Claim_Open_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Claim_Open_Date"))) : ""%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl7" runat="server" Width="120px" Text='<%# Eval("Primary_Policy_Effective_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Primary_Policy_Effective_Date"))) : ""%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl8" runat="server" Width="120px" Text='<%# Eval("Primary_Policy_Expiration_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Primary_Policy_Expiration_Date"))) : ""%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="150px" HorizontalAlign="right" />
                                                                        <FooterStyle Width="150px" HorizontalAlign="right" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl9" runat="server" Width="150px" Text='<%# Eval("Estimated_Demand_Exposure") != DBNull.Value ? "$ " + clsGeneral.GetStringValue(Eval("Estimated_Demand_Exposure")) : "" %>' /></ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblTotalExposure" runat="server" Width="150px" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="300px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl10" runat="server" Width="300px" Text='<%#Eval("Claim_Status_Comments")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl11" runat="server" Width="120px" Text='<%#Eval("Internal_Counsel")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl12" runat="server" Width="120px" Text='<%#Eval("Legal_Telephone")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Sonic_Location_Code" runat="server" Width="120px" Text='<%#Eval("Sonic_Location_Code")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="200px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="legal_entity" runat="server" Width="200px" Text='<%#Eval("legal_entity")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="200px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="dba" runat="server" Width="200px" Text='<%#Eval("dba")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="200px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Entity" runat="server" Width="200px" Text='<%#Eval("Entity")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemStyle Width="120px" HorizontalAlign="left" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl14" runat="server" Width="120px" Text='<%#Eval("Firm")%>' /></ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Width="650px">
                                                                        <ItemTemplate>
                                                                            <asp:GridView ID="grdDetail" runat="server" EnableTheming="false" AutoGenerateColumns="false"
                                                                                CellPadding="4" CellSpacing="0" ShowHeader="false" ShowFooter="false" GridLines="None">
                                                                                <%--GridLines="Horizontal" BorderColor="Black" BorderStyle="NotSet"--%>
                                                                                <RowStyle BackColor="#EAEAEA" Font-Names="Tahoma" Font-Size="8pt" VerticalAlign="Top" />
                                                                                <AlternatingRowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" VerticalAlign="Top" />
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Firm" runat="server" Width="150px" Text='<%#Eval("Firm")%>' /></ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Name" runat="server" Width="150px" Text='<%#Eval("Name")%>' /></ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle Width="200px" HorizontalAlign="left" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Address_1" runat="server" Width="200px" Text='<%#Eval("Full_Address")%>' /></ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemStyle Width="150px" HorizontalAlign="left" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Telephone" runat="server" Width="150px" Text='<%#Eval("Telephone")%>' /></ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="100%" align="left">
                                                            <table cellpadding="4" cellspacing="0" width="100%" style="font-weight: bold; color: White;background-color:#507CD1"
                                                                id="tblFooter" runat="server">
                                                                <tr>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label22" runat="server" Width="120px" Text="Total" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="lblFTotal" runat="server" Width="120px"  />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="Label23" runat="server" Width="200px" />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label1" runat="server" Width="300px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label2" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label3" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="LblOtherType" runat="server" Width="200px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label4" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;" align="right">
                                                                        <asp:Label ID="Label5" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label6" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label7" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label8" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label9" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 150px;" align="right">
                                                                        <asp:Label ID="lblFTotalExposure" runat="server" Width="150px" />
                                                                    </td>
                                                                    <td style="width: 300px;">
                                                                        <asp:Label ID="Label11" runat="server" Width="300px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label12" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label13" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label16" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="Label17" runat="server" Width="200px" />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="Label18" runat="server" Width="200px" />
                                                                    </td>
                                                                    <td style="width: 200px;">
                                                                        <asp:Label ID="Label14" runat="server" Width="200px" />
                                                                    </td>
                                                                    <td style="width: 120px;">
                                                                        <asp:Label ID="Label15" runat="server" Width="120px" />
                                                                    </td>
                                                                    <td style="width: 650px;background-color:#507CD1" colspan="4">
                                                                            <%--<table style="border-collapse: collapse;" cellspacing="0" cellpadding="4" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 150px;" align="left">
                                                                                            <span style="display: inline-block; width: 150px"></span>
                                                                                        </td>
                                                                                        <td style="width: 150px;" align="left">
                                                                                            <span style="display: inline-block; width: 150px"></span>
                                                                                        </td>
                                                                                        <td style="width: 200px;" align="left">
                                                                                            <span style="display: inline-block; width: 200px"></span>
                                                                                        </td>
                                                                                        <td style="width: 150px;" align="left">
                                                                                            <span style="display: inline-block; width: 150px"></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>--%>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:gridview>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 15px;"></td>
        </tr>
    </table>
</asp:Content>
