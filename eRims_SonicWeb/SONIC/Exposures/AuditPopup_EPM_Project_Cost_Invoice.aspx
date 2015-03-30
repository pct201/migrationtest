<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AuditPopup_EPM_Project_Cost_Invoice.aspx.cs" Inherits="SONIC_Exposures_AuditPopup_EPM_Project_Cost_Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>eRIMS Sonic :: Project Cost Audit Trail</title>
    <script language="javascript" type="text/javascript">
        function showAudit(divHeader, divGrid) {
            var divheight, i;

            divHeader.style.width = window.screen.availWidth - 325 + "px";
            divGrid.style.width = window.screen.availWidth - 325 + "px";

            divheight = divGrid.style.height;
            i = divheight.indexOf('px');

            if (i > -1)
                divheight = divheight.substring(0, i);
            if (divheight > (window.screen.availHeight - 450) && divGrid.style.height != "") {
                divGrid.style.height = window.screen.availHeight - 450;
            }
        }

        function ChangeScrollBar(f, s) {
            s.scrollTop = f.scrollTop;
            s.scrollLeft = f.scrollLeft;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" align="left">
            <tr>
                <td align="left">
                    <asp:Label ID="lbltable_Name" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td align="right">
                    <a href="javascript:window.close();">Close Window</a>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="overflow: hidden; width: 650px;" id="dvHeader" runat="server">
                        <table cellpadding="4" cellspacing="0" style="width: 2067px; border-collapse: collapse;">
                            <tbody>
                                <tr style="background-color: #95B3D7; color: White; font-size: 12px; font-weight: bold;"
                                    align="left">
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Audit DateTime</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">PK EPM Project Cost Invoice</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">EPM Project Identification</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Invoice Number</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Invoice Date</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Invoice Amount</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Invoice Charges RM</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Invoice Charges CD RE</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Invoice Charges Store</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Vendor</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Vendor Address</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Vendor City</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Vendor State</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Vendor Zip Code</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Vendor_Contact</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Vendor Telephone</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Vendor Email</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 100px;">Updated_By</span>
                                    </th>
                                    <th class="cols">
                                        <span style="display: inline-block; width: 117px;">Update_Date</span>
                                    </th>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="overflow: scroll; width: 2067px; height: 400px;" id="dvGrid" runat="server">
                        <asp:GridView ID="gvProjectCost" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            EnableTheming="True" EmptyDataText="No records found!" ShowHeader="false">
                            <RowStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Audit_DateTime">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblAudit_DateTime" runat="server" Text='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>'
                                            ToolTip='<%# Convert.ToDateTime(Eval("Audit_DateTime")).ToString("yyyy-MM-dd HH:mm")%>' CssClass="TextClip"
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PK_EPM_Project_Cost_Invoice">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPK_EPM_Project_Cost_Invoice" runat="server" Text='<%#Eval("PK_EPM_Project_Cost_Invoice")%>' CssClass="TextClip"
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FK_EPM_Identification">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFK_EPM_Identification" runat="server" Text='<%#Eval("FK_EPM_Identification")%>' CssClass="TextClip"
                                            Width="100px" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice_Number">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoice_Number" runat="server" Text='<%# string.Format("{0:C2}",Eval("Invoice_Number"))%>' CssClass="TextClip"
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoice_Date" runat="server" Text='<%#Eval("Invoice_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Invoice_Date"))) : ""%>'
                                            Width="100px" style="word-wrap:normal;word-break:break-all"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice_Amount">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoice_Amount" runat="server" Text='<%# string.Format("{0:C2}",Eval("Invoice_Amount"))%>'
                                            Width="100px" style="word-wrap:normal;word-break:break-all" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice_Charges_RM">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoice_Charges_RM" runat="server" Text='<%# string.Format("{0:C2}",Eval("Invoice_Charges_RM"))%>'
                                            Width="100px" style="word-wrap:normal;word-break:break-all" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice_Charges_CD_RE">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoice_Charges_CD_RE" runat="server" Text='<%# string.Format("{0:C2}",Eval("Invoice_Charges_CD_RE"))%>'
                                            Width="100px" style="word-wrap:normal;word-break:break-all" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Invoice_Charges_Store">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInvoice_Charges_Store" runat="server" Text='<%# string.Format("{0:C2}",Eval("Invoice_Charges_Store"))%>'
                                            Width="100px" style="word-wrap:normal;word-break:break-all" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor" runat="server" Text='<%#Eval("Vendor")%>' CssClass="TextClip"
                                            Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor_Address">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor_Address" runat="server" Text='<%#Eval("Vendor_Address")%>'
                                            Width="100px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor_City" runat="server" Text='<%#Eval("Vendor_City")%>'
                                            Width="100px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor_State">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor_State" runat="server" Text='<%#Eval("Vendor_State")%>'
                                            Width="100px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor_City">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor_City" runat="server" Text='<%#Eval("Vendor_Zip_Code")%>'
                                            Width="100px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor_Contact">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor_Contact" runat="server" Text='<%#Eval("Vendor_Contact")%>'
                                            Width="100px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor_Telephone">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor_Telephone" runat="server" Text='<%#Eval("Vendor_Telephone")%>'
                                            Width="100px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vendor_Email">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblVendor_Email" runat="server" Text='<%#Eval("Vendor_Email")%>'
                                            Width="100px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Updated_By">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdated_By" runat="server" Text='<%#Eval("Updated_By")%>' Width="100px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update_Date">
                                    <ItemStyle CssClass="cols" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUpdate_Date" runat="server" Text='<%#Eval("Update_Date") != DBNull.Value ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(Eval("Update_Date"))) : ""%>'
                                            Width="100px" CssClass="TextClip"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
