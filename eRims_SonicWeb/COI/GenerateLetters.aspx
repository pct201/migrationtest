<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="GenerateLetters.aspx.cs"
    Inherits="COI_GenerateLetters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function PrintLetter() {
            objLetter = document.getElementById('dvLetters');
            objPrint = document.getElementById('dvPrint');
            objPrint.innerHTML = objLetter.innerHTML;
            document.title = '';
            window.print();
            objPrint.innerHTML = '';
            return false;
        }
        function PrintEnvelopes() {
            objEnv = document.getElementById('dvEnvelopes');
            objPrint = document.getElementById('dvPrint');
            objPrint.innerHTML = objEnv.innerHTML;
            document.title = '';
            window.print();
            objPrint.innerHTML = '';
            return false;
        }
    </script>

    <div class="noPrint">
        &nbsp;</div>
    <div class="noPrint" id="dvSignature" runat="server">
        <table cellpadding="0" cellspacing="0" width="50%" align="center">
            <tr>
                <td width="30%" align="left">
                    Select a Signature
                </td>
                <td width="4%" align="center">
                    :
                </td>
                <td align="left">
                    <asp:DropDownList ID="drpSignature" runat="server" Width="180px" />
                </td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="rfvSignature" runat="server" ErrorMessage="Please Select a Signature"
                        InitialValue="--Select--" ControlToValidate="drpSignature" SetFocusOnError="true" />
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
                    &nbsp;
                </td>
                <td align="left">
                    <asp:Button ID="btnGenerate" runat="server" CausesValidation="true" Text="Generate Letters"
                        OnClick="btnGenerate_Click" />
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
    </div>
    <div style="text-align: center; font-size: 11pt; font-family: Times New Roman; display: none;"
        class="noPrint" id="dvLinks" runat="server">
        <asp:Label SkinID="messageOrNote" EnableViewState="false" ID="lblMessage" runat="Server"></asp:Label>
        <div style="text-align: center;">
            <%--OnClientClick="javascript:return PrintLetter();"--%>
            <asp:LinkButton ID="lnkPrintLetters" runat="server" OnClick="lnkPrintLetters_Click">Print Letters</asp:LinkButton>
            &nbsp;
            <%--OnClientClick="javascript:return PrintEnvelopes();"--%>
            <asp:LinkButton ID="lnkPrintEnvelopes" runat="server" OnClick="lnkPrintEnvelopes_Click">Print Envelopes</asp:LinkButton>
        </div>
    </div>
    <div style="display: none;" id="dvLetters">
        <asp:Literal ID="litLetter" runat="Server"></asp:Literal>
    </div>
    <div style="display: none;" id="dvEnvelopes">
        <asp:Literal ID="litEnvelopes" runat="Server"></asp:Literal>
    </div>
    <div style="text-align: left; font-size: 12pt; font-family: Times New Roman; color: Black"
        id="dvPrint" class="noScreen">
    </div>
    <div class="noPrint">
        &nbsp;</div>
    <div class="noPrint">
        &nbsp;</div>
</asp:Content>
