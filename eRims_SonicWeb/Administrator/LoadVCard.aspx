<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoadVCard.aspx.cs" Inherits="Administrator_LoadVCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Load VCard</title>
    <style type="text/css">
        .box {
            width: 500px;
            height: 200px;
            position: fixed;
            margin-left: -150px; /* half of width */
            margin-top: -150px; /* half of height */
            top: 50%;
            left: 30%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript">
            var validFilesTypes = ["vcf"];

            function CheckExtension(file) {
                /*global document: false */
                var filePath = file.value;
                var ext = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
                var isValidFile = false;

                for (var i = 0; i < validFilesTypes.length; i++) {
                    if (ext == validFilesTypes[i]) {
                        isValidFile = true;
                        break;
                    }
                }

                if (!isValidFile) {
                    file.value = null;
                    alert("Invalid File. Please select VCARD(.vcf) file.");
                }

                return isValidFile;
            }

            function valueSave() {
                var retVal = true;
                retVal = confirm("Would you like to update the existing Contractor?");
                if (retVal == true)
                    __doPostBack(document.getElementById('<%=btnUpload.ClientID%>').name, "UpdateDetails");
                else {
                    alert('Import Cancelled');

                    self.close();
                }

            }
        </script>
        <div>
            <asp:ValidationSummary ID="vsError" runat="server" ShowSummary="false" ShowMessageBox="true"
                HeaderText="Verify the following fields:" BorderWidth="1" BorderColor="DimGray"
                EnableClientScript="true" ValidationGroup="vsErrorGroup" CssClass="errormessage"></asp:ValidationSummary>
        </div>
        <table width="100%" class="box">
            <tr>
                <td>Please select VCard
                </td>
                <td>
                    <asp:FileUpload ID="fluVcard" runat="server" onchange="return CheckExtension(this);" />
                    <asp:RequiredFieldValidator ID="rfvUpload" runat="server" ControlToValidate="fluVcard"
                        InitialValue="" Display="None" Text="*" ErrorMessage="Please Select File to Upload." ValidationGroup="vsErrorGroup">                                                                        
                    </asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" ValidationGroup="vsErrorGroup" />
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
