<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="rptRepairAndMaintanance.aspx.cs" Inherits="SONIC_Exposures_rptRepairAndMaintanance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_gvDescription_New td {
            vertical-align: middle;
            padding-left: 3px;
        }

        #ctl00_ContentPlaceHolder1_gvDescription_New th {
            height: 22px;
        }

        .HeaderStyle th {
            vertical-align: bottom;
            text-align: left;
            padding-bottom: 3px;
            padding-left: 3px;
            height: 22px;
        }
        /*.HeaderStyle th {
            text-align: left;
            vertical-align: bottom;
        }*/
        /*td.centerAlign {
            vertical-align: middle!important;
            text-align: center!important;
        }*/
    </style>
    <asp:ValidationSummary ID="valSummary" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="vsErrorGroup" />

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar_new.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/calendar-en.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Calendar.js"></script>

    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            divHeader.style.width = window.screen.availWidth - 225 + "px";
            divGrid.style.width = window.screen.availWidth - 225 + "px";

            divheight = divGrid.style.height;
            i = divheight.indexOf('px');

            if (i > -1)
                divheight = divheight.substring(0, i);
            if (divheight > (window.screen.availHeight - 350) && divGrid.style.height != "") {
                divGrid.style.height = window.screen.availHeight - 350;
            }
        }

        function ChangeScrollBar(f, s) {
            s.scrollTop = f.scrollTop;
            s.scrollLeft = f.scrollLeft;
        }
    </script>

    <table width="100%" cellpadding="0" cellspacing="2">
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr>
            <td align="left" class="ghc" colspan="2">Repair & Maintenance
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 3px;" colspan="2"></td>
        </tr>
        <tr runat="server" id="trCriteria">
            <td width="20%">&nbsp;
            </td>
            <td align="center">
                <table border="0" cellpadding="5" cellspacing="1" width="100%">
                    <tr>
                        <td align="left" valign="top" width="28%">Region
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left" width="70%">
                            <asp:ListBox ID="lstRegions" runat="server" SelectionMode="Multiple" ToolTip="Select Region"
                                AutoPostBack="false" Width="280px" Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" width="28%">Market
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left" width="70%">
                            <asp:ListBox ID="lstMarket" runat="server" SelectionMode="Multiple" ToolTip="Select Market"
                                AutoPostBack="false" Width="280px" Rows="5"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Property COPE Status
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:ListBox runat="server" ID="ddlStatus" SkinID="dropGen" Width="280px" Rows="3"
                                SelectionMode="Multiple">
                                <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                <asp:ListItem Text="InActive" Value="Inactive"></asp:ListItem>
                                <asp:ListItem Text="Disposed" Value="Disposed"></asp:ListItem>
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Building Status
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:ListBox runat="server" ID="ddlBuildingStatus" SkinID="dropGen" Width="280px" Rows="3"
                                SelectionMode="Multiple">
                                <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                                <asp:ListItem Text="Demolished" Value="Demolished"></asp:ListItem>
                                <asp:ListItem Text="Disposed" Value="Disposed"></asp:ListItem>
                                <asp:ListItem Text="Due Diligence" Value="Due Diligence"></asp:ListItem>
                                <asp:ListItem Text="InActive" Value="Inactive"></asp:ListItem>
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Ownership
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:ListBox runat="server" ID="drpOwnership" SkinID="dropGen" Width="280px" Rows="5"
                                SelectionMode="Multiple">                            
                                <asp:ListItem Text="Sonic Owned with Internal Lease" Value="Internal"></asp:ListItem>
                                <asp:ListItem Text="Sonic Owned with Third Party Lease" Value="ThirdParty"></asp:ListItem>
                                <asp:ListItem Text="Sonic Owned" Value="Owned"></asp:ListItem>
                                <asp:ListItem Text="Third Party Owned and Sonic Leased" Value="ThirdPartyLease"></asp:ListItem>
                                <asp:ListItem Text="Third Party Owned and Sonic Leased and Subleased to Third Party"
                                    Value="ThirdPartySublease"></asp:ListItem>
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Property Valuation Date From
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPropertyValuationDateFrom" runat="server" Width="145px" SkinID="txtDate" />
                            <img alt="PV Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPropertyValuationDateFrom', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtPropertyValuationDateFrom"
                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                ErrorMessage="Property Valuation Date From is invalid." Display="none" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="true" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">Property Valuation Date To
                        </td>
                        <td width="2%" align="center" valign="top">:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPropertyValuationDateTo" runat="server" Width="145px" SkinID="txtDate" />
                            <img alt="PV Date" onclick="return showCalendar('ctl00_ContentPlaceHolder1_txtPropertyValuationDateTo', 'mm/dd/y');"
                                onmouseover="javascript:this.style.cursor='hand';" src="../../Images/iconPicDate.gif"
                                align="middle" /><br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPropertyValuationDateTo"
                                ValidationExpression="^(((0?[1-9]|1[012])/(0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[012])/(29|30)|(0?[13578]|1[02])/31)/(19|[2-9]\d)\d{2}|0?2/29/((19|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$"
                                ErrorMessage="Property Valuation Date To is invalid." Display="none" ValidationGroup="vsErrorGroup"
                                SetFocusOnError="true" />
                            <asp:CompareValidator ID="cmpvProperyValuationDate" runat="server" ControlToValidate="txtPropertyValuationDateTo"
                                ControlToCompare="txtPropertyValuationDateFrom" Type="Date" ValidationGroup="vsErrorGroup"
                                Operator="GreaterThanEqual" Display="None" ErrorMessage="Property Valuation Date To Must Be Greater Than Property Valuation Date From."></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td colspan="2" align="left">
                            <asp:Button runat="server" ID="btnShowReport" Text="Show Report" OnClick="btnShowReport_Click"
                                CausesValidation="true" ValidationGroup="vsErrorGroup" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClearCriteria" runat="server" Text="Clear Criteria" ToolTip="Clear All"
                                OnClick="btnClearCriteria_Click" CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0" runat="server" id="tblReport" visible="false">
        <tr valign="middle">
            <td align="right" width="100%">
                <asp:LinkButton Visible="false" ID="lbtExportToExcel" runat="server" Text="Export To Excel"
                    OnClick="lbtExportToExcel_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 5px;"></td>
        </tr>
        <tr class="HeaderStyle">
            <td>
                <table width="100%">
                    <tr>
                        <td align="left" width="20%">Sonic Automotive
                        </td>
                        <td align="center" runat="server" style="margin-left: 0; text-align: center;">Property Repair & Maintenance
                                
                        </td>
                        <td align="left" style="margin-left: 0; text-align: right;" width="20%">
                            <span><%=DateTime.Now.ToString()  %></span>
                        </td>
                    </tr>
                </table>
            </td>

        </tr>
      
        <tr>
            <td>
                <div style="overflow: scroll; width: 997px; height: 398px;">
                    <asp:GridView ID="gvDescription_New" EnableTheming="false" runat="server"
                        AutoGenerateColumns="false" Width="100%" HorizontalAlign="Left" GridLines="Both"
                        ShowHeader="true" ShowFooter="false" EmptyDataText="No Record Found !" CellPadding="0"
                        OnDataBound="gvDescription_New_DataBound">
                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                        <RowStyle CssClass="RowStyle" HorizontalAlign="Left" />
                        <AlternatingRowStyle CssClass="AlterRowStyle" BackColor="White" HorizontalAlign="Left" />
                        <FooterStyle ForeColor="Black" Font-Bold="true" />
                        <EmptyDataRowStyle BackColor="#EAEAEA" HorizontalAlign="Center" Height="22px" />
                        <Columns>
                            <asp:TemplateField HeaderText="Region" ItemStyle-Height="25px" HeaderStyle-Height="55px">
                                <ItemTemplate>
                                    <asp:Label ID="lblRegion" runat="server" Text='<%# Eval("Region") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sonic Location Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Sonic_Location_Code") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Location_Name") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Legal Entity">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Legal_Entity") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Parent Company<br> Legal Entity">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Parent_Company_LE") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Parent Company<br> Legal Entity FEIN">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Parent_Company_LE_FEIN") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Legal Entity<br> (Operations)">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("LE_Operations") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Legal Entity<br> (Operations) FEIN">
                                <ItemTemplate>
                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("LE_Operations_FEIN") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Legal Entity<br> (Properties)">
                                <ItemTemplate>
                                    <asp:Label ID="Label0" runat="server" Text='<%# Eval("LE_Properties") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Legal Entity<br> (Properties) FEIN">
                                <ItemTemplate>
                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("LE_Properties_FEIN") %>' Width="180px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                                
                            <asp:TemplateField HeaderText="Federal Id">
                                <ItemTemplate>
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("Federal_id") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("Location_Status") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Building #">
                                <ItemTemplate>
                                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("Building") %>' Width="120px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Building Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("Building_Status") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 1">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblAddress1" Width="200px"><%# Eval("Address1")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address 2">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblAddress2" Width="200px"><%# Eval("Address2")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="Label16" runat="server" Text='<%# Eval("City") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State">
                                <ItemTemplate>
                                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("State") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("Zip_Code") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="County">
                                <ItemTemplate>
                                    <asp:Label ID="Label19" runat="server" Text='<%# Eval("County") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owned/Leased/Sub Leased/Assigned/ Management Agreement">
                                <ItemTemplate>
                                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("Ownership") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                           
                          <%--  <asp:TemplateField HeaderText="Property Valuation Date">
                                <ItemTemplate>
                                    <asp:Label ID="Label31" runat="server" Text='<%# clsGeneral.FormatDBNullDateToDisplay_Claim(Eval("Property_Valuation_Date")) %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>                      
                            <asp:TemplateField HeaderText="HVAC Repairs">
                                <ItemTemplate>
                                    <asp:Label Width="120px" runat="server" ID="lblHVAC_Repairs" Text='<%# Eval("HVAC_Repairs")%>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HVAC Capital">
                                <ItemTemplate>
                                    <asp:Label Width="120px" runat="server" ID="lblHVAC_Capital" Text='<%# Eval("HVAC_Capital")%>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Roof Repairs">
                                <ItemTemplate>
                                    <asp:Label Width="120px" runat="server" ID="lblRoof_Repairs" Text='<%# Eval("Roof_Repairs")%>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Roof Capital">
                                <ItemTemplate>
                                    <asp:Label Width="120px" runat="server" ID="lblRoof_Capital" Text='<%# Eval("Roof_Capital")%>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Repairs">
                                <ItemTemplate>
                                    <asp:Label Width="120px" runat="server" ID="lblOther_Repairs" Text='<%# Eval("Other_Repairs")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Maintenance Notes">
                                <ItemTemplate>
                                    <asp:Label Width="120px" runat="server" ID="lblMaintenance_Notes" Text='<%# Eval("Maintenance_Notes")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td class="Spacer" style="height: 15px;"></td>
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

