<%@ Page Title="eRIMS Sonic :: FROI Recap Report" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptFROIRecap.aspx.cs" Inherits="SONIC_ClaimInfo_rptFROIRecap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Date_Validation.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery-1.5.min.js"></script>
    <script type="text/javascript" language="javascript" src="../../JavaScript/jquery.maskedinput.js"></script>

    <script language="javascript" type="text/javascript">
        function MakeStaticHeader(gridId, gridHeader, gridContent, height, width, headerHeight, isFooter) {
            var tbl = document.getElementById(gridId);
            if (tbl) {
                var DivHR = document.getElementById(gridHeader);
                var DivMC = document.getElementById(gridContent);
                //var DivFR = document.getElementById('DivFooterRow');

                //*** Set divheaderRow Properties ****
                DivHR.style.height = headerHeight + 'px';
                DivHR.style.width = (parseInt(width) - 16) + 'px';
                DivHR.style.position = 'relative';
                DivHR.style.top = '0px';
                DivHR.style.zIndex = '10';
                DivHR.style.verticalAlign = 'top';

                //*** Set divMainContent Properties ****
                DivMC.style.width = width + 'px';
                DivMC.style.height = height + 'px';
                DivMC.style.position = 'relative';
                DivMC.style.top = -headerHeight + 'px';
                DivMC.style.zIndex = '1';

                //*** Set divFooterRow Properties ****
                //DivFR.style.width = (parseInt(width) - 16) + 'px';
                //DivFR.style.position = 'relative';
                //DivFR.style.top = -headerHeight + 'px';
                //DivFR.style.verticalAlign = 'top';
                //DivFR.style.paddingtop = '2px';

                //if (isFooter) {
                //    var tblfr = tbl.cloneNode(true);
                //    tblfr.removeChild(tblfr.getElementsByTagName('tbody')[0]);
                //    var tblBody = document.createElement('tbody');
                //    tblfr.style.width = '100%';
                //    tblfr.cellSpacing = "0";
                //    tblfr.border = "0px";
                //    tblfr.rules = "none";
                //    //*****In the case of Footer Row *******
                //    tblBody.appendChild(tbl.rows[tbl.rows.length - 1]);
                //    tblfr.appendChild(tblBody);
                //    DivFR.appendChild(tblfr);
                //}
                //****Copy Header in divHeaderRow****
                DivHR.appendChild(tbl.cloneNode(true));
            }
        }



        function OnScrollDiv(Scrollablediv, DivHeaderRow) {
            document.getElementById(DivHeaderRow).scrollLeft = Scrollablediv.scrollLeft;
            //document.getElementById('DivFooterRow').scrollLeft = Scrollablediv.scrollLeft;
        }


    </script>

    <asp:UpdatePanel ID="upReport" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlReportCriteria" runat="server">
                <table width="100%">
                    <tr>
                        <td align="left" class="ghc">FROI Recap Report
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" class="Spacer" style="height: 10px;"></td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table width="80%" border="0">
                                <tr>
                                    <td align="left" valign="top" width="24%">Region<span class="mf">*</span>
                                    </td>
                                    <td width="2%" align="center" valign="top">:</td>
                                    <td align="left">
                                        <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                            AutoPostBack="True" Width="250px" OnSelectedIndexChanged="lstRegions_SelectedIndexChanged"></asp:ListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top">Sonic Location Code<span class="mf">*</span>
                                    </td>
                                    <td width="2%" align="center" valign="top">:</td>
                                    <td align="left">
                                        <asp:ListBox ID="lstRMLocationNumber" runat="server" SelectionMode="Multiple" ToolTip="Select Sonic Location Code"
                                            AutoPostBack="false" Width="250px"></asp:ListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">Date of Incident Begin 
                                    </td>
                                    <td align="center">:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtIncidentBeginDate" runat="server" SkinID="txtDate" Width="170px"></asp:TextBox>
                                        <img alt="Incident Begin Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIncidentBeginDate', 'mm/dd/y');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                        <asp:RangeValidator ID="revStartRangeDate" ControlToValidate="txtIncidentBeginDate"
                                            MinimumValue="01/01/1753" MaximumValue="12/31/9999" Type="Date" ErrorMessage="Incident Begin Date is not valid."
                                            runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                    </td>
                                    <td align="left">Date of Incident End
                                    </td>
                                    <td align="center">:
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtIncidentEndDate" runat="server" SkinID="txtDate" Width="170px"></asp:TextBox>
                                        <img alt="Incident End Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtIncidentEndDate', 'mm/dd/y');"
                                            onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                            align="middle" />
                                        <asp:RangeValidator ID="revDate" ControlToValidate="txtIncidentEndDate" MinimumValue="01/01/1753"
                                            MaximumValue="12/31/9999" Type="Date" ErrorMessage="Incident End Date is not valid."
                                            runat="server" ValidationGroup="vsErrorGroup" Display="none" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">First Report Category 
                                    </td>
                                    <td align="center">:
                                    </td>
                                    <td align="left">
                                        <asp:ListBox runat="server" ID="lstCategory" Width="195px" SelectionMode="Multiple">
                                            <asp:ListItem>NS</asp:ListItem>
                                            <asp:ListItem>WC</asp:ListItem>
                                            <asp:ListItem>AL</asp:ListItem>
                                            <asp:ListItem>DPD</asp:ListItem>
                                            <asp:ListItem>PL</asp:ListItem>
                                            <asp:ListItem>Property</asp:ListItem>
                                        </asp:ListBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="100"></td>
                                    <td align="left" valign="top" width="10"></td>
                                    <td align="left" colspan="3" valign="top">
                                        <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click" CausesValidation="true" ValidationGroup="vsErrorGroup" />
                                        &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlReport" runat="server" Visible="false">
                <table width="100%">
                    <tr>
                        <td class="Spacer">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h3 style="text-decoration: underline">FROI Recap Report</h3>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td width="15%">Date
                                    </td>
                                    <td width="2%">:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">Region(s)
                                    </td>
                                    <td width="2%">:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRegion" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">Location(s)
                                    </td>
                                    <td width="2%">:
                                    </td>
                                    <td style="word-wrap: normal; word-break: break-all;">
                                        <asp:Label ID="lblLocationDBA" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">Date Of Incident Begin
                                    </td>
                                    <td width="2%">:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIncidentBeginDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">Date Of Incident End
                                    </td>
                                    <td width="2%">:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblIncidentEndDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">First Report Category
                                    </td>
                                    <td width="2%">:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFirstRepotCategory" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Spacer">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <table id="tblUtility" runat="server" width="100%" align="center">
                                <tr valign="middle">
                                    <td align="right" width="100%" style="padding-right:10px;">
                                        <asp:LinkButton ID="lnkExportToExcel" runat="server" Text="Export To Excel" OnClick="lnkExportToExcel_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlAL_FR" runat="server" Visible="false">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <h5>AL FROI</h5>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="overflow: hidden;" id="AL_DivHeaderRow">
                                            </div>
                                            <div style="overflow: scroll;" onscroll="OnScrollDiv(this,'AL_DivHeaderRow')" id="AL_DivMainContent">
                                                <asp:GridView ID="gvAL_FR" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                                    CellSpacing="0" Width="1500px" GridLines="Both" ShowFooter="false" EmptyDataText="No Record Found !">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" />
                                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <FooterStyle ForeColor="Black" Font-Bold="true" />
                                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Location">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("dba") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location Number">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Sonic_Location_Code") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FROI Number">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("AL_FR_Number") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Loss">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Loss"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description of Loss">
                                                            <ItemStyle Width="250px" />
                                                            <ItemTemplate>
                                                                <%#Eval("Description_Of_Loss")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Vehicle SubType</br>Vehicle Make</br>Vehicle Model</br>Vehicle Year">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Vehicle") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Were Policed Notified?">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Were_Police_Notified") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Is there a Security Video</br>Surveillance System?">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Security_Video_System") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comments">
                                                            <ItemTemplate>
                                                                <%# Eval("Comments") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="Spacer">&nbsp;
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlDPD_FR" runat="server" Visible="false">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <h5>DPD FROI</h5>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="overflow: hidden;" id="DPD_DivHeaderRow">
                                            </div>
                                            <div style="overflow: scroll;" onscroll="OnScrollDiv(this,'DPD_DivHeaderRow')" id="DPD_DivMainContent">
                                                <asp:GridView ID="gvDPD_FR" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                                    CellSpacing="0" Width="1500px" GridLines="Both" ShowFooter="false" EmptyDataText="No Record Found !">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" />
                                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <FooterStyle ForeColor="Black" Font-Bold="true" />
                                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Location">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("dba") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location Number">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Sonic_Location_Code") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FROI Number">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("DPD_FR_Number") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Loss">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Loss"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Cause Of Loss">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Cause_Of_Loss") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Loss Description">
                                                            <ItemStyle Width="250px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Loss_Description") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Vehicle Make</br>Vehicle Model</br>Vehicle Year</br>Invoice Value">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Vehicle") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Were Policed Notified?">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Were_Police_Notified") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Is there a Security Video</br>Surveillance System?">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Security_Video_System") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Recovered</br>Damage Amount</br>Recovered Amount">
                                                            <ItemStyle Width="150px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Recovered") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comments">
                                                            <ItemTemplate>
                                                                <%# Eval("Comments") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlNS_FR" runat="server" Visible="false">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <h5>NS FROI</h5>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="overflow: hidden;" id="NS_DivHeaderRow">
                                            </div>
                                            <div style="overflow: scroll;" onscroll="OnScrollDiv(this,'NS_DivHeaderRow')" id="NS_DivMainContent">
                                                <asp:GridView ID="gvNS_FR" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                                    CellSpacing="0" Width="1300px" GridLines="Both" ShowFooter="false" EmptyDataText="No Record Found !">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" />
                                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <FooterStyle ForeColor="Black" Font-Bold="true" />
                                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Location">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("dba") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location Number">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Sonic_Location_Code") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FROI Number">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("WC_FR_Number") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Associate Name">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Associate_Name") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Loss">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Incident"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description Of Incident">
                                                            <ItemStyle Width="300px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Description_Of_Incident") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Taken By Emergency Transportation?">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Taken_By_Emergency_Transportation") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comments">
                                                            <ItemTemplate>
                                                                <%# Eval("Comments") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlPL_FR" runat="server" Visible="false">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <h5>PL FROI</h5>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="overflow: hidden;" id="PL_DivHeaderRow">
                                            </div>
                                            <div style="overflow: scroll;" onscroll="OnScrollDiv(this,'PL_DivHeaderRow')" id="PL_DivMainContent">
                                                <asp:GridView ID="gvPL_FR" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                                    CellSpacing="0" Width="1300px" GridLines="Both" ShowFooter="false" EmptyDataText="No Record Found !">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" />
                                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <FooterStyle ForeColor="Black" Font-Bold="true" />
                                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Location">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("dba") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location Number">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Sonic_Location_Code") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FROI Number">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("PL_FR_Number") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Loss">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_of_Loss"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description Of Loss">
                                                            <ItemStyle Width="300px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Description_of_Loss") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Were Police Notified?">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Were_Police_Notified") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comments">
                                                            <ItemTemplate>
                                                                <%# Eval("Comments") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlProperty_FR" runat="server" Visible="false">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <h5>Property FROI</h5>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="overflow: hidden;" id="Property_DivHeaderRow">
                                            </div>
                                            <div style="overflow: scroll;" onscroll="OnScrollDiv(this,'Property_DivHeaderRow')" id="Property_DivMainContent">
                                                <asp:GridView ID="gvProperty_FR" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                                    CellSpacing="0" Width="1500px" GridLines="Both" ShowFooter="false" EmptyDataText="No Record Found !">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" />
                                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <FooterStyle ForeColor="Black" Font-Bold="true" />
                                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Location">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("dba") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location Number">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Sonic_Location_Code") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FROI Number">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Property_FR_Number") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Loss">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_of_Loss"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Type Of Loss">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Type_of_Loss") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description Of Loss">
                                                            <ItemStyle Width="300px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Description_of_Loss") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Estimated Cost">
                                                            <ItemStyle Width="180px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Estimated_Cost") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Is There a Security Video Surveillance System?">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Security_Video_Surveillance") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comments">
                                                            <ItemTemplate>
                                                                <%# Eval("Comments") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlWC_FR" runat="server" Visible="false">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <h5>WC FROI</h5>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="overflow: hidden;" id="WC_DivHeaderRow">
                                            </div>
                                            <div style="overflow: scroll;" onscroll="OnScrollDiv(this,'WC_DivHeaderRow')" id="WC_DivMainContent">
                                                <asp:GridView ID="gvWC_FR" runat="server" AutoGenerateColumns="true" CellPadding="5"
                                                    CellSpacing="0" Width="1300px" GridLines="Both" ShowFooter="false" EmptyDataText="No Record Found !">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="HeaderStyle" />
                                                    <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <AlternatingRowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <FooterStyle ForeColor="Black" Font-Bold="true" />
                                                    <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Location">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("dba") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Location Number">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Sonic_Location_Code") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FROI Number">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("WC_FR_Number") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Associate Name">
                                                            <ItemStyle Width="120px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Associate_Name") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Loss">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%#clsGeneral.FormatDBNullDateToDisplay(Eval("Date_Of_Incident"))%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description Of Incident">
                                                            <ItemStyle Width="300px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Description_Of_Incident") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Taken By Emergency Transportation?">
                                                            <ItemStyle Width="100px" />
                                                            <ItemTemplate>
                                                                <%# Eval("Taken_By_Emergency_Transportation") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comments">
                                                            <ItemTemplate>
                                                                <%# Eval("Comments") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>

                    <tr>
                        <td align="center">
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkExportToExcel" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
        <ProgressTemplate>
            <div class="UpdatePanelloading" id="divProgress" style="width: 100%; position: fixed;">
                <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%; height: 100%;">
                    <tr align="center" valign="middle">
                        <td class="LoadingText" align="center" valign="middle">
                            <img src="../../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                        </td>
                    </tr>
                </table>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>

