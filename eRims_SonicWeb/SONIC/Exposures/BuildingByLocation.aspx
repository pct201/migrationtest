<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuildingByLocation.aspx.cs" Inherits="SONIC_Exposures_BuildingByLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>>Risk Insurance Management System :: Asset Management</title>
    <script src="../../JavaScript/jquery-1.5.min.js"></script>
     <script language="javascript" type="text/javascript">
         function ClosePopup() {
             parent.parent.document.getElementById('ctl00_ContentPlaceHolder1_btnhdnReload').click();
             parent.parent.GB_hide();
         }

         function ClosePopup() {             
             parent.parent.GB_hide();             
         }

         

         $(document).ready(function (element) {
             $("#gvBuildingEdit input[id*='chkSelect']:checkbox").click(function () {
                  //Get number of checkboxes in list either checked or not checked
                   var totalCheckboxes = $("#gvBuildingEdit input[id*='chkSelect']:checkbox").size();
                  //Get number of checked checkboxes in list
                  var checkedCheckboxes = $("#gvBuildingEdit input[id*='chkSelect']:checkbox:checked").size();

                 //Check / Uncheck top checkbox if all the checked boxes in list are checked
                 $("#gvBuildingEdit input[id*='chkHeaderSelect']:checkbox").attr('checked', totalCheckboxes == checkedCheckboxes);
        });

             $("#gvBuildingEdit input[id*='chkHeaderSelect']:checkbox").click(function () {
                  //Check/uncheck all checkboxes in list according to main checkbox 
                 $("#gvBuildingEdit input[id*='chkSelect']:checkbox").attr('checked', $(this).is(':checked'));
        });
          });

         
         function CheckCopy() {                 
                 var checkedCheckboxes = $("#gvBuildingEdit input[id*='chkSelect']:checkbox:checked").size();
                 if (checkedCheckboxes == 0) {
                     alert("Please Select atleast one Building to be copied");
                     return false;
                 }
                 else {                     
                     return confirm("Are you sure you want to COPY the data from Building <displayed building number> to Building <selected building number> at Location <dba> overwriting any existing data for Building <selected building number>?");                     
                 }


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
                             <HeaderTemplate>
                                 <asp:CheckBox runat="server" ID="chkHeaderSelect" />
                             </HeaderTemplate>
                             <ItemTemplate>
                                 <asp:CheckBox runat="server" ID="chkSelect" />
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Building Number">
                            <ItemStyle Width="25%" HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# Eval("Building_Number")%>
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
             </td>
         </tr>
         <tr><td></td></tr>
         <tr>
             <td align="center">
                 <asp:Button runat="server" ID="btnCopy" Text="Copy To" OnClientClick="return CheckCopy();" />
                 &nbsp;
                 <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClientClick="ClosePopup();" />
             </td>
         </tr>
         <tr><td></td></tr>
     </table>
    </form>
</body>
</html>
