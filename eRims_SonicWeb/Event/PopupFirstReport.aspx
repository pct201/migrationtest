<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopupFirstReport.aspx.cs" Inherits="Event_PopupFirstReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type="text/javascript" language="javascript" src="../JavaScript/Validator.js"></script>
        <script lang="javascript" type="text/javascript">
            function ClosePopup(FRNumber, hdnPK, type) {
                if (type == "AL")
                {
                    parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtFK_AL_FR').value = 'AL-'+FRNumber;
                    parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_hdnFK_AL_FR').value = hdnPK;
                    parent.parent.GB_hide();

                }
                else if (type == "DPD") {
                    parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtFK_DPD_FR').value = 'DPD-'+FRNumber;
                    parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_hdnFK_DPD_FR').value = hdnPK;
                    parent.parent.GB_hide();

                }
                else if (type == "PL") {
                    parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtFK_PL_FR').value = 'PL-'+FRNumber;
                    parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_hdnFK_PL_FR').value = hdnPK;
                    parent.parent.GB_hide();

                }
                else if (type == "Property") {
                    parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_txtFK_Property_FR').value = 'Prop-'+FRNumber;
                    parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_hdnFK_Property_FR').value = hdnPK;
                    parent.parent.GB_hide();

                }
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="1" cellspacing="1" border="0">
                        <tr>
                            <td style="width: 14%">
                                Sonic DBA
                            </td>
                            <td style="width: 2%">
                                :
                            </td>
                            <td style="width: 46%">
                                <asp:DropDownList ID="ddlSonicDBA" runat="server" Width="250px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 19%">
                                First Report Number
                            </td>
                            <td style="width: 2%">
                                :
                            </td>
                            <td style="width: 15%">
                                <asp:TextBox ID="txtFirstReportNumber" runat="server" Width="145px" MaxLength="20" onpaste="return false"
                                            onkeypress="return FormatInteger(event);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
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
            <tr runat="server" id="trGrid" style="display: block;">
                <td align="center">
                    <asp:GridView ID="gvFRNumber" runat="server" AutoGenerateColumns="false" Width="80%"
                        AllowSorting="false" AllowPaging="true" PageSize="20" OnPageIndexChanging="gvFRNumber_PageIndexChanging"
                        OnRowDataBound="gvFRNumber_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="First Report Number">
                                <ItemStyle HorizontalAlign="left" Width="15%" />
                                <ItemTemplate>
                                    <a href="#" runat="server" id="FRNumber">
                                        <%#Eval("Prefix") %>-<%#Eval("FR_Number")%>
                                    </a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location d/b/a ">
                                <ItemStyle HorizontalAlign="left" Width="20%" />
                                <ItemTemplate>
                                    <a href="#" runat="server" id="FRLocation">
                                        <%#Eval("dba")%></a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemStyle Width="1%" />
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnPK_ID" runat="server" Value='<%# Eval("PK_ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table cellpadding="4" cellspacing="0" width="100%">
                                <tr>
                                    <td width="100%" align="center" style="border: 1px solid #cccccc;">
                                        <asp:Label ID="lblEmptyHeaderGridMessage" runat="server" Text="No Record Found"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                        <PagerSettings Mode="NumericFirstLast" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
