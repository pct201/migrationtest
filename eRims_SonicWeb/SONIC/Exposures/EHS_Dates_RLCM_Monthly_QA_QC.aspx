<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="EHS_Dates_RLCM_Monthly_QA_QC.aspx.cs" Inherits="SONIC_Exposures_EHS_Dates_RLCM_Monthly_QA_QC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <script language="javascript" type="text/javascript">

        function ExpandCollapse(img_id) {
            var div, img;
            div = document.getElementById(img_id.replace('img', 'col'));
            img = document.getElementById(img_id);

            if (div.style.display == "none") {
                div.style.display = "";
                img.src = '<%=AppConfig.ImageURL%>' + "/up-arrow.gif";
            } else {
                div.style.display = "none";
                img.src = '<%=AppConfig.ImageURL%>' + "/down-arrow.gif";
            }
        }


        function Redirect(url) {
            //window.location.href = url;
            window.open(url)
            return false;
        }

        function OpenUserEHSDates(id, RLCM) {
            var oWnd = window.open('<%=AppConfig.SiteURL%>SONIC/Exposures/User_Added_EHS_Dates.aspx?id=' + id + '&RLCM=' + RLCM, "Erims", "location=0,status=0,scrollbars=1,menubar=0,resizable=1,toolbar=0,width=860,height=300");
            oWnd.moveTo(450, 300);
            return false;
        }

        function RedirectToCalendar() {

            window.location.href = '<%=AppConfig.SiteURL%>SONIC/Exposures/EHS_Dates_Calendar.aspx?RLCM=<%=Encryption.Encrypt(Convert.ToString(PK_RLCM))%>';
            return false;
        }
    </script>

    <div>
        <div>
            &nbsp;
        </div>
        <div class="bandHeaderRow">
            RLCM Monthly QA/QC EHS Dates
        </div>
        <div>
            &nbsp;
        </div>
        <table cellpadding="2" cellspacing="2" width="100%">
            <tr>
                <td width="100%" valign="bottom"></td>
            </tr>
            <tr>
                <td>
                    <table id="tableContent" class="tblGrid" border="0" cellpadding="3" cellspacing="2" width="100%" runat="server"></table>
                    <asp:Label ID="lblMsg" runat="server" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 15px;" class="Spacer"></td>
            </tr>
            <tr>
                <td style="height: 15px;" class="Spacer"></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnBack" runat="server" OnClientClick='JavaScript:return RedirectToCalendar();' Text="Back to Calendar" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

