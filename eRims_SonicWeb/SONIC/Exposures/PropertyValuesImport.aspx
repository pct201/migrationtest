<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="PropertyValuesImport.aspx.cs" Inherits="SONIC_Exposures_PropertyValuesImport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">

        function ValMultiplier() {
            if (document.getElementById('<%=txtMultiplier.ClientID%>').value != '')
                return true;
            else {
                alert("Please Enter Multiplier Value");
                return false;
            }
        }

        function ValFileImport() {
            if (document.getElementById('<%=fpFile.ClientID%>').value != '')
                return true;
            else {
                alert("Please Select File To Import");
                return false;
            }
        }

        function ShowError() {
            alert('Please select Property COPE record first');
            window.location.href = '<%=AppConfig.SiteURL%>Exposure/PropertySearch.aspx';
        }

        function MultiplierFormat(ctrlid, number) {
            var result = CurrencyFormatted(number);
            result = CommaFormatted(result);
            document.getElementById(ctrlid).value = result;
        }

        function CurrencyFormatted(amount) {
            var i = parseFloat(amount);
            if (isNaN(i)) { i = 0.00; }
            var minus = '';
            if (i < 0) { minus = '-'; }
            i = Math.abs(i);
            i = parseInt((i + .005) * 100);
            i = i / 100;
            s = new String(i);
            if (s.indexOf('.') < 0) { s += '.00'; }
            if (s.indexOf('.') == (s.length - 2)) { s += '0'; }
            s = minus + s;
            return s;
        }


        function CommaFormatted(amount) {
            var delimiter = ","; // replace comma if desired
            var a = amount.split('.', 2)
            var d = a[1];
            var i = parseInt(a[0]);
            if (isNaN(i)) { return ''; }
            var minus = '';
            if (i < 0) { minus = '-'; }
            i = Math.abs(i);
            var n = new String(i);
            var a = [];
            while (n.length > 3) {
                var nn = n.substr(n.length - 3);
                a.unshift(nn);
                n = n.substr(0, n.length - 3);
            }
            if (n.length > 0) { a.unshift(n); }
            n = a.join(delimiter);
            if (d.length < 1) { amount = n; }
            else { amount = n + '.' + d; }
            amount = minus + amount;
            return amount;
        }

    </script>

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="100%" class="ghc" colspan="2">
                Values Export/Import
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="5%">
                &nbsp;
            </td>
            <td align="left">
                <b>Property Values Spreadsheet Export</b>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="18%" align="right">
                            Current Value Multiplier
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMultiplier" runat="server" />
                            &nbsp;&nbsp;&nbsp;Percent
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click"
                                OnClientClick="return ValMultiplier();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="5%">
                &nbsp;
            </td>
            <td align="left">
                <b>Values Spreadsheet Import</b>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="18%" align="right">
                            Updated Value Spreadsheet File
                        </td>
                        <td width="4%" align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:FileUpload ID="fpFile" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="btnImport" runat="server" Text="Import" OnClick="btnImport_Click"
                                OnClientClick="return ValFileImport();" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="100%" colspan="2" style="display:none">
                <div style="width: 990px; overflow-x: scroll">
                    <asp:GridView ID="gvBuilding" runat="server" Width="1200px" EnableTheming="false" CellPadding="4" CellSpacing="1" GridLines="Both"
                     ForeColor="#333333" Font-Names="Arial" Font-size="10pt"
                     AutoGenerateColumns="true" EmptyDataText="No Records Found !">
                        <RowStyle BackColor="White" Font-Names="Arial" Font-Size="10pt" VerticalAlign="Top" Height="20px" />
                        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" Font-Names="Arial"
                            Font-Size="10pt" Height="20px"/>
                        <AlternatingRowStyle BackColor="White" Font-Names="Arial" Font-Size="10pt" VerticalAlign="Top" Height="20px"/>
                        <EmptyDataRowStyle BackColor="White" Font-Names="Arial" Font-Size="10pt" Font-Bold="true" HorizontalAlign="Center" Height="20px"/>                       
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        function FormatNumber(e, ctrlID, intMaxAllowedLen, bIsPerfectNumber) {
            var ctrlValue = document.getElementById(ctrlID).value;

            var dotSepetator = ctrlValue.split('.');

            if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.which >= 48 && e.which <= 57)) {
                ctrlValue = ctrlValue.replace('-', '');
                if (ctrlValue.length == 1 && ctrlValue.indexOf('0') > -1) {
                    return false;
                }
                if (dotSepetator.length > 1) {
                    if (dotSepetator[1].length == 2)
                        return false;
                    else
                        return true;
                }

                var intLen = ctrlValue.length;
                if (ctrlValue.indexOf('.') < 0) {
                    if (!bIsPerfectNumber && intLen == intMaxAllowedLen - 2)
                        return false;
                    else if (bIsPerfectNumber && intLen == intMaxAllowedLen)
                        return false;
                    else {
                        return true;
                    }
                }
            }
            else {
                if (e.keyCode == 45) {
                    if (ctrlValue.indexOf("-") > -1) {
                        return false;
                    }
                    else
                        return true;
                }


                if (e.keyCode == 44 || e.which == 44)
                    return false;
                else if (e.which) {
                    if (e.which == 8)
                        return true;
                }

                if (ctrlValue.length == 0) {
                    return false;
                }
                else if (bIsPerfectNumber && (e.keyCode == 46 || e.which == 46)) {
                    return false;
                }
                else {
                    if (ctrlValue.indexOf('.') > 0 && (e.keyCode == 46 || e.which == 46)) {
                        return false;
                    }
                    else if (e.keyCode == 46 || e.which == 46)
                        return true;
                    else
                        return false;
                }
            }
        }

    </script>

</asp:Content>
