<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="MonthlyAllocationSubmission.aspx.cs"
    Inherits="Administrator_MonthlyAllocationSubmission" Title="eRIMS Sonic :: Monthly Allocation Submission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function CheckDate(sender, args)
        {
            var d = new Date();            
            var curr_month = d.getMonth();
            var curr_year = d.getFullYear();
            args.IsValid = false;            
            curr_month = curr_month + 1;            
                        
            if (parseInt(document.getElementById('<%=ddlYear.ClientID%>').value) < curr_year )
                args.IsValid = true;
            else if((curr_year == document.getElementById('<%=ddlYear.ClientID%>').value) && (document.getElementById('<%=ddlMonth.ClientID%>').value < curr_month ))
                args.IsValid = true;

            return args.IsValid;
        }        
    </script>

    <div>
        <asp:UpdateProgress runat="server" ID="upProgress" DisplayAfter="100">
            <ProgressTemplate>
                <div class="UpdatePanelloading" id="divProgress" style="width: 100%;">
                    <table id="ProgressTable" cellpadding="0" cellspacing="0" border="0" style="width: 100%;
                        height: 100%;">
                        <tr align="center" valign="middle">
                            <td class="LoadingText" align="center" valign="middle">
                                <img src="../Images/indicator.gif" alt="Loading" />&nbsp;&nbsp;&nbsp;Please Wait..
                            </td>
                        </tr>
                    </table>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <asp:ValidationSummary ID="vsError" runat="server" ValidationGroup="vsErrorGroup"
        ShowMessageBox="true" ShowSummary="false" HeaderText="Please Verify following fields." />
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="bandHeaderRow">
                <b>&nbsp;Monthly Allocation Submission</b>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnl" runat="server" Style="padding-left: 100px; padding-top: 10px;">
                    <asp:UpdatePanel runat="server" ID="updMontlyAllocation" RenderMode="Inline" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table width="60%" align="center">
                                <tr>
                                    <td colspan="3" align="left">
                                        <asp:Label ID="lblError" runat="server" ForeColor="red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Month<span class="mf">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList runat="Server" ID="ddlMonth" SkinID="ddlExposure">
                                            <asp:ListItem Value="0" Text="-- Select --">
                                            </asp:ListItem>
                                            <asp:ListItem Value="1" Text="January">
                                            </asp:ListItem>
                                            <asp:ListItem Value="2" Text="February">
                                            </asp:ListItem>
                                            <asp:ListItem Value="3" Text="March">
                                            </asp:ListItem>
                                            <asp:ListItem Value="4" Text="April">
                                            </asp:ListItem>
                                            <asp:ListItem Value="5" Text="May">
                                            </asp:ListItem>
                                            <asp:ListItem Value="6" Text="June">
                                            </asp:ListItem>
                                            <asp:ListItem Value="7" Text="July">
                                            </asp:ListItem>
                                            <asp:ListItem Value="8" Text="August">
                                            </asp:ListItem>
                                            <asp:ListItem Value="9" Text="September">
                                            </asp:ListItem>
                                            <asp:ListItem Value="10" Text="October">
                                            </asp:ListItem>
                                            <asp:ListItem Value="11" Text="November">
                                            </asp:ListItem>
                                            <asp:ListItem Value="12" Text="December">
                                            </asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvMonth" ControlToValidate="ddlMonth" Display="None"
                                            runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Month.">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Year<span class="mf">*</span>
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlYear" runat="server" SkinID="ddlExposure">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvddlYear" ControlToValidate="ddlYear" Display="None"
                                            runat="server" InitialValue="0" Text="*" ValidationGroup="vsErrorGroup" ErrorMessage="Please select Year.">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" Width="50px"
                                            ValidationGroup="vsErrorGroup" />
                                        <asp:CustomValidator ID="csmvbtnGo" runat="server" ValidationGroup="vsErrorGroup"
                                            ErrorMessage="This procedure can only be run for past months." Display="None"
                                            ClientValidationFunction="CheckDate">
                                        </asp:CustomValidator>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
