<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SonicLocationInfo.ascx.cs"
    Inherits="Controls_SonicLocationInfo_SonicLocationInfo" %>
<asp:GridView ID="gvLocation" runat="server" Width="100%" AutoGenerateColumns="false"
    Style="background-color: Black; margin: 1% 0 1% 0;" border="1" CellPadding="3"
    CellSpacing="1" BackColor="Black">
    <HeaderStyle HorizontalAlign="Left" />
    <RowStyle HorizontalAlign="Left" />
    <Columns>
        <asp:TemplateField HeaderText="Location ID">
            <HeaderStyle CssClass="PropertyInfoBG" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:Label ID="lblRMLocationNumber" runat="server" Text='<%#Eval("Sonic_Location_Code")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sonic Location d/b/a">
            <HeaderStyle CssClass="PropertyInfoBG" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:Label ID="lbldba" runat="server" Text='<%#Eval("dba")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City">
            <HeaderStyle CssClass="PropertyInfoBG" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="State">
            <HeaderStyle CssClass="PropertyInfoBG" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:Label ID="lblState" runat="server" Text='<%#Eval("StateName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Zip">
            <HeaderStyle CssClass="PropertyInfoBG" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:Label ID="lblZipCode" runat="server" Text='<%#Eval("Zip_Code") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Meeting Date">
            <HeaderStyle CssClass="PropertyInfoBG" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:Label ID="lblMeeting_Date" runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
