<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="BuildingInsuranceCOPE.aspx.cs" Inherits="Administrator_BuildingInsuranceCOPE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function IsValidData() {
            for (var i = 1; i <= 25; i++) {
                if ($("#" + "ctl00_ContentPlaceHolder1_rblItem" + i + "_0").is(':checked')) {
                    if ($("#" + "ctl00_ContentPlaceHolder1_txtField" + i).val() == '') {
                        alert("Please enter value for field" + i);
                        return false;
                    }
                } 
            }
            return true;
        }
    </script>
    <asp:UpdatePanel runat="server" ID="updStatus">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%">
                <tbody>
                    <tr>
                        <td colspan="4">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="bandHeaderRow" align="left" colspan="4">
                            <asp:Label ID="lblHeader" runat="server" Text="Administrator :: Building Insurance COPE Descriptors"></asp:Label>                            
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlInsuranceCopeList" runat="server" Visible="true">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%">
                                            <asp:GridView ID="gvBuildingInsuranceCope" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="Item_Number" HeaderText="Item Number" ItemStyle-Width="20%" />
                                                    <asp:BoundField DataField="Item_Descriptor" HeaderText="Item Descriptor" ItemStyle-Width="60%" />
                                                    <asp:BoundField DataField="IsActive" HeaderText="Active" ItemStyle-Width="20%" />
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                            <asp:LinkButton ID="lnkBuildingInsuranceCopeManage" runat="server" OnClick="lnkBuildingInsuranceCopeManage_Click" Text="Building Insurance COPE Field Management"></asp:LinkButton>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlInsuranceCope" runat="server" Visible="false">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 17%"></td>
                                        <td style="width: 65%">
                                            <table width="100%">
                                                <tr>
                                                    
                                                    <td>
                                                        <table width="100%" cellpadding="5" cellspacing="1">
                                                            <tr>
                                                                <td width="12%">Field 1</td>
                                                                <td width="1%">:</td>
                                                                <td width="42%">
                                                                    <asp:TextBox ID="txtField1" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber1" runat="server" /> 
                                                                </td>
                                                                <td width="11%">Active</td>
                                                                <td width="1%">:</td>
                                                                <td width="25%">
                                                                    <asp:RadioButtonList ID="rblItem1" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory1" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 2</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField2" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber2" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem2" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory2" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 3</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField3" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber3" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem3" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory3" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 4</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField4" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber4" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem4" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory4" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 5</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField5" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber5" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem5" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory5" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 6</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField6" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber6" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem6" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory6" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 7</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField7" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber7" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem7" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory7" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 8</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField8" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber8" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem8" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory8" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 9</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField9" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber9" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem9" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory9" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 10</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField10" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber10" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem10" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory10" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 11</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField11" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber11" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem11" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory11" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 12</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField12" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber12" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem12" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory12" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 13</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField13" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber13" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem13" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory13" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 14</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField14" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber14" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem14" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory14" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 15</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField15" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber15" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem15" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory15" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 16</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField16" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber16" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem16" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory16" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 17</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField17" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber17" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem17" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory17" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 18</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField18" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber18" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem18" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory18" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 19</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField19" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber19" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem19" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory19" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 20</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField20" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber20" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem20" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory20" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 21</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField21" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber21" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem21" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory21" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 22</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField22" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber22" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem22" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory22" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 23</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField23" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber23" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem23" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory23" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 24</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField24" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber24" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem24" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory24" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Field 25</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtField25" runat="server" MaxLength="100" Width="340px"></asp:TextBox>
                                                                    <asp:HiddenField Id="hdnItemNumber25" runat="server" /> 
                                                                </td>
                                                                <td>Active</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblItem25" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td colspan="3"></td>
                                                                <td>Mandatory</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rblMandatory25" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center">
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return IsValidData();" />&nbsp;
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                   
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="width: 18%"></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

     
</asp:Content>

