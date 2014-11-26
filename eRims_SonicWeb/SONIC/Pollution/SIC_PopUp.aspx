<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SIC_PopUp.aspx.cs" Inherits="SONIC_Pollution_SIC_PopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management System</title>
    <script type="text/javascript" language="javascript" src="../../JavaScript/Validator.js"></script>
    <script type="text/javascript" src="../../JavaScript/JFunctions.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
        HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
        ValidationGroup="vsErrorGroup"></asp:ValidationSummary>
    <table cellpadding="1" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" width="100%">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="5%" align="left" valign="top">
                &nbsp;&nbsp;<span class="NormalFontBold">&nbsp;</span>
            </td>
            <td align="right" valign="top" width="85%">
                <table cellpadding="4" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td align="left" style="width: 30%">
                            SIC Level 1 Description
                        </td>
                        <td align="center" style="width: 5%">
                            :
                        </td>
                        <td align="left" style="width: 65%">
                            <asp:DropDownList ID="drpSICLevel1" AutoPostBack="true" OnSelectedIndexChanged="drpSICLevel1_SelectedIndexChanged"
                                runat="server" Width="300px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            SIC Level 2 Description
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpSICLevel2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpSICLevel2_SelectedIndexChanged"
                                Width="300px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            SIC Level 3 Description
                        </td>
                        <td align="center">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="drpSICLevel3" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="drpSICLevel3_SelectedIndexChanged"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="Spacer" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="3">
                            &nbsp;
                            <asp:Button ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click"
                                CausesValidation="true" ValidationGroup="vsErrorGroup"  />
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                CausesValidation="false" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="Spacer" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td colspan="2" class="Spacer" style="height: 5px;">
            </td>
        </tr>
    </table>
     <script type="text/javascript" src="<%=AppConfig.SiteURL %>JavaScript/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("select").each(function () {
                $(this).mouseover(function () {
                    $(this).find("option").each(function () {
                        $(this).attr("title", $(this).text());
                    });
                });
            });
        });

        function SelectValue(PK_LU_SIC, strFld_Code, strFld_Desc, strFld_Desc_Encode) {           
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtSIC').value = strFld_Code;
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_hdnSIC').value = PK_LU_SIC;          
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_lblSIC').innerHTML = strFld_Desc;            
            window.opener.document.getElementById('ctl00_ContentPlaceHolder1_txtSICDesc').value = strFld_Desc_Encode;     
            self.close();
        }

//        function IsValidation() {           
//            var drpSICLevel1 = document.getElementById('drpSICLevel1');
//            var drpSICLevel2 = document.getElementById('drpSICLevel2');
//            var drpSICLevel3 = document.getElementById('drpSICLevel3');
//            if (drpSICLevel1.selectedIndex == 0 && drpSICLevel2.selectedIndex == 0 && drpSICLevel3.selectedIndex == 0) {
//                alert('Select all three levels of description');
//                return false;
//            }
//            else {
//                    if(drpSICLevel1.selectedIndex == 0 || drpSICLevel2.selectedIndex == 0)
//                    {
//                      alert('Select all three levels of description');
//                      return false;
//                    }
//                    else
//                    {
//                        if(drpSICLevel1.selectedIndex == 0 || drpSICLevel3.selectedIndex == 0)
//                        {
//                          alert('Select all three levels of description');
//                          return false;
//                        }
//                        else
//                         {
//                            if(drpSICLevel2.selectedIndex == 0 || drpSICLevel3.selectedIndex == 0)
//                             {
//                               alert('Select all three levels of description');
//                               return false;
//                             }
//                             else
//                             {
//                                 return true;
//                             }
//                         }
//                    }
//                  
//                }
//        }
    </script>
    </form>
</body>
</html>
