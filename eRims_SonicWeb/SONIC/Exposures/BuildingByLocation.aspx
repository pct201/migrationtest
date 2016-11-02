<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuildingByLocation.aspx.cs" Inherits="SONIC_Exposures_BuildingByLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Risk Insurance Management System :: Asset Management</title>
    <script src="../../JavaScript/jquery-1.5.min.js"></script>
     <script language="javascript" type="text/javascript">
         function ClosePopup() {
             window.close();
         }

         function ClosePopupBuilding() {             
             window.close();
             window.parent().close();
             window.location.href = "<%# AppConfig.SiteURL%>Exposures/Asset_Protection.aspx";
         }        

        // $(document).ready(function (element) {
        //     $("#gvBuildingEdit input[id*='chkSelect']:checkbox").click(function () {
        //          //Get number of checkboxes in list either checked or not checked
        //           var totalCheckboxes = $("#gvBuildingEdit input[id*='chkSelect']:checkbox").size();
        //          //Get number of checked checkboxes in list
        //          var checkedCheckboxes = $("#gvBuildingEdit input[id*='chkSelect']:checkbox:checked").size();

        //         //Check / Uncheck top checkbox if all the checked boxes in list are checked
        //         $("#gvBuildingEdit input[id*='chkHeaderSelect']:checkbox").attr('checked', totalCheckboxes == checkedCheckboxes);
        //});

        //     $("#gvBuildingEdit input[id*='chkHeaderSelect']:checkbox").click(function () {
        //          //Check/uncheck all checkboxes in list according to main checkbox 
        //         $("#gvBuildingEdit input[id*='chkSelect']:checkbox").attr('checked', $(this).is(':checked'));
        //});
        //  });

         //var checkedCheckboxes = $("#gvBuildingEdit input[id*='chkSelect']:checkbox:checked").size();
         //if (checkedCheckboxes == 0) {
         //    alert("Please Select atleast one Building to be copied");
         //    return false;
         //}
         //else {

         //    var checked = $("#gvBuildingEdit input[id*='chkSelect']:checkbox:checked");

         //    return confirm("Are you sure you want to COPY the data from Building <displayed building number> to Building <selected building number> at Location <dba> overwriting any existing data for Building <selected building number>?");                     
         //}
         
         ////Copy funtionality
         function OpenCopyPopup(element) {

             var FK_Building_IdTo = document.getElementById(element.replace("lnkSelect", "hdnSelect")).value;             
             var BuildingToNumber = document.getElementById(element.replace("lnkSelect", "lblBuildingNumber")).innerText;
             var BuildingFromNumber = document.getElementById("hdnBuildingNumber").value;             
             var IsCopyId = document.getElementById(element.replace("lnkSelect", "hdnIsCopyId")).value;
             var Location = document.getElementById("hdnLocationId").value;
             var Locationdba = document.getElementById("hdnLocationdba").value;
             
             document.getElementById("hdnBuildingNumberTo").value = BuildingToNumber;

             var Copy = "";

             if (parseInt(IsCopyId) > 0)
                Copy = " overwriting any existing data for Building " + BuildingToNumber + "?";


             return confirm("Are you sure you want to COPY the data from Building " + BuildingFromNumber + " to Building " + BuildingToNumber + " at Location " + Locationdba + Copy);
             
             }
            

    </script>    
</head>
<body>
    <form id="form1" runat="server">
     <table width="100%" align="left">
         <tr>
             <td align="left">
             </td>
         </tr>
         <tr>
             <td align="left">
                 <asp:GridView ID="gvBuildingEdit" runat="server" EmptyDataText="No Records Found" OnRowDataBound="gvBuildingEdit_RowDataBound"
                     AutoGenerateColumns="false" Width="100%">
                     <Columns>
                         <asp:TemplateField>
                             <ItemStyle Width="5%" HorizontalAlign="Center" />                             
                             <ItemTemplate>
                                 <asp:LinkButton runat="server" ID="lnkSelect" Text="Select" OnClientClick="return OpenCopyPopup(this.id);" OnClick="lnkSelect_Click" />
                                 <asp:HiddenField runat="server" ID="hdnSelect" Value='<%# Eval("PK_Building_ID") %>' >                                     
                                </asp:HiddenField>
                                 <asp:HiddenField ID="hdnIsCopyId" runat="server" Value='<%# Eval("IsCopyId") %>' />
                             </ItemTemplate>
                         </asp:TemplateField>                         
                         <asp:TemplateField HeaderText="Building Number">
                            <ItemStyle Width="25%" HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="lblBuildingNumber" Text='<%# Eval("Building_Number")%>'  runat="server"></asp:Label>                                                              
                            </ItemTemplate>
                        </asp:TemplateField>                       
                        <asp:TemplateField HeaderText="Occupancy">
                            <ItemStyle Width="40%" />
                            <ItemTemplate>
                                <asp:Label ID="lblOccupancy" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                     </Columns>
                 </asp:GridView>
                 <asp:HiddenField ID="hdnLocationId" runat="server" />                 
                 <asp:HiddenField ID="hdnLocationdba" runat="server" />
                 <asp:HiddenField ID="hdnBuildingNumber" runat="server" />
                 <asp:HiddenField ID="hdnBuildingNumberTo" runat="server" />
                 <asp:HiddenField ID="hdnPK_AP_Property_Security" runat="server" />
             </td>
         </tr>
         <tr><td></td></tr>
         <tr>
             <td align="center">                 
                 <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClientClick="window.close();" />
             </td>
         </tr>
         <tr><td></td></tr>
     </table>
    </form>
</body>
</html>
