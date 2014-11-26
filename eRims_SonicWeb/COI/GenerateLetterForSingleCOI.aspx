<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateLetterForSingleCOI.aspx.cs"
    Inherits="COI_GenerateLetterForSingleCOI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Risk Insurance Management System</title>

    <script type="text/javascript">
function PrintLetter()
{   
    objLetter = document.getElementById('dvLetters');    
    objPrint = document.getElementById('dvPrint');
    objPrint.innerHTML = objLetter.innerHTML;
    document.title = '';        
    window.print();    
    objPrint.innerHTML = '';             
    return false;
}
function PrintEnvelopes()
{   
    objEnv = document.getElementById('dvEnvelopes');
    objPrint = document.getElementById('dvPrint');
    objPrint.innerHTML = objEnv.innerHTML;
    document.title = '';    
    window.print();       
    objPrint.innerHTML = '';               
    return false;    
}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="noPrint">
            &nbsp;</div>
        <div style="text-align: center; font-size: 11pt; font-family: Times New Roman; display: none;"
            class="noPrint" id="dvLinks" runat="server">
            <br /><br />
            <asp:Label SkinID="messageOrNote" EnableViewState="false" ID="lblMessage" runat="Server"></asp:Label>
            <div style="text-align: center;">            
                <br /><br />
                <asp:LinkButton ID="lnkPrintLetters" runat="server" OnClick="lnkPrintLetters_Click">Print Letters</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkPrintEnvelopes" runat="server" OnClick="lnkPrintEnvelopes_Click">Print Envelopes</asp:LinkButton>
            </div>
        </div>
        <div class="noPrint" id="dvWarningMsg" runat="server" style="display: none;">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="100%" align="center">
                        <br /><br />
                        <span class="msg1">This COI does not have any warnings or messages to trigger a letter.</span>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <br /><br />
                        <input type="button" value="OK" onclick="window.close();" />
                    </td>
                </tr>
            </table>
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
    </form>
</body>
</html>