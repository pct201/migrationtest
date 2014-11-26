<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WarningAndMessages.aspx.cs" Inherits="Admin_WarningAndMessages" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Risk Insurance Management System</title>
    <script type="text/javascript">
        function RedirectBack(op)
        {
            if(op == "edit")
                window.close()
            else
            {    
                var COI = document.getElementById('hdnCOIID').value;
                window.opener.location.href =  "COIAddEdit.aspx?op=" + op + '&id=' + COI;
                window.close();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" width="650px" align="center">
            <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td align="left" class="heading">Warnings and Messages</td>
        </tr>
        <tr>
            <td width="100%" class="Spacer" style="height: 25px;">
            </td>
        </tr>
        <tr>
            <td class="dvContent">
                <table cellpadding="2" cellspacing="1" width="100%">
                    <tr>
                        <td class="tblGrid" align="left">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr ><td align="left" class="bandHeaderRow" style="height:22px;">COI</td></tr>
                                <tr><td class="Spacer" style="height:5px;"></td></tr>
                                <tr>
                                    <td>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left" valign="top">Cancellation Notice under 30 Days</td>
                                                <td width="2%" align="center" valign="top">:</td>
                                                <td width="26%" align="left" valign="top"><asp:RadioButton ID="rdoCancellation" runat="server" />
                                                </td>
                                                <td width="2%">&nbsp;</td>
                                                <td width="20%" align="left" valign="top">Insurance is Primary and Non-Contributory with any Other Insurance – Wording Not Provided</td>
                                                <td width="2%" align="center" valign="top">:</td>
                                                <td width="26%" align="left" valign="top"><asp:RadioButton ID="rdoPrimary" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">All Locations not on Certificate</td>
                                                <td align="center" valign="top">:</td>
                                                <td align="left" valign="top"><asp:RadioButton ID="rdoAllLocations" runat="server" />
                                                </td>
                                                <td>&nbsp;</td>
                                                <td align="left" valign="top">Original or Signed Certificate not Provided</td>
                                                <td align="center" valign="top">:</td>
                                                <td align="left" valign="top"><asp:RadioButton ID="rdoCertificate" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Insured Name on Policies and Certificates not same as Franchise Entity Business Name</td>
                                                <td align="center" valign="top">:</td>
                                                <td align="left" colspan="5" valign="top"><asp:RadioButton ID="rdoInsuredName" runat="server" />
                                                </td>
                                                
                                            </tr>
                                        </table>
                                    </td>
                                 </tr>
                                 <tr><td class="Spacer" style="height:5px;"></td></tr>
                                 <tr ><td align="left" class="bandHeaderRow" style="height:22px;">Insurance Companies</td></tr>
                                 <tr><td class="Spacer" style="height:5px;"></td></tr>
                                 <tr>
                                    <td>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left">AM Best Rating A- or Better</td>
                                                <td width="2%" align="center">:</td>
                                                <td align="left"><asp:RadioButton ID="rdoAMBestRating" runat="server" />
                                                </td>                                                
                                            </tr>
                                        </table>
                                    </td>
                                 </tr>
                                 <tr><td class="Spacer" style="height:5px;"></td></tr>
                                 <tr ><td align="left" class="bandHeaderRow" style="height:22px;">Locations</td></tr>
                                 <tr><td class="Spacer" style="height:5px;"></td></tr>
                                 <tr>
                                    <td>
                                        <table cellpadding="3" cellspacing="1" width="100%">
                                            <tr>
                                                <td width="20%" align="left" valign="top">Ordinance or Law</td>
                                                <td width="2%" align="center" valign="top">:</td>
                                                <td width="26%" align="left" valign="top"><asp:RadioButton ID="rdoOrdinance" runat="server" />
                                                </td>
                                                <td width="2%">&nbsp;</td>
                                                <td width="20%" align="left" valign="top">Waiver of Subrogation</td>
                                                <td width="2%" align="center" valign="top">:</td>
                                                <td width="26%" align="left" valign="top"><asp:RadioButton ID="rdoWaiver" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Insured Perils – Special Form</td>
                                                <td align="center" valign="top">:</td>
                                                <td align="left" valign="top"><asp:RadioButton ID="rdoInsuredPerils" runat="server" />
                                                </td>
                                                <td>&nbsp;</td>
                                                <td align="left" valign="top">100% Replacement Cost Values</td>
                                                <td align="center" valign="top">:</td>
                                                <td align="left" valign="top"><asp:RadioButton ID="rdoReplcament" runat="server" /></td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">Evidence of Property on Acord 24, 27 or 28</td>
                                                <td align="center" valign="top">:</td>
                                                <td align="left" valign="top"><asp:RadioButton ID="rdoPropertyOnAcord" runat="server" />
                                                </td>
                                                <td>&nbsp;</td>
                                                <td align="left" valign="top">Additional Insured not Provided</td>
                                                <td align="center" valign="top">:</td>
                                                <td align="left" valign="top"><asp:RadioButton ID="rdoAdditionalInsured" runat="server" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                 </tr>
                                 <tr><td class="Spacer" style="height:25px;"></td></tr>
                                 <tr>
                                    <td align="center">
                                    <asp:Button ID="btnAccept" runat="server" Text="Accept" OnClientClick="javascript:RedirectBack('view');" />&nbsp;&nbsp;
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClientClick="javascript:RedirectBack('edit');" />
                                    </td>
                                 </tr>
                                 <tr><td class="Spacer" style="height:25px;"></td></tr>
                            </table>
                         </td>
                     </tr>                     
                </table>
            </td>
        </tr>
        <tr><td class="Spacer" style="height:25px;"></td></tr>
        </table>
        <input type="hidden" id="hdnCOIID" runat="server" />
    </div>
    </form>
</body>
</html>
