<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Learning_Program_Items_Report.aspx.cs" Inherits="SONIC_Exposures_Learning_Program_Items_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <br />
    <br />

    <div>
        <asp:GridView ID="gvLearning_Program" runat="server" EmptyDataText="No Records Found" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="Training Classes">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="100%" HorizontalAlign="left" />
                    <ItemTemplate>
                        <%# Eval("LearningProgramTitle") %> 
                            </a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <br />

</asp:Content>

