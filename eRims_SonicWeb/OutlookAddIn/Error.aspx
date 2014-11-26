<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error"
    MasterPageFile="~/OutlookAddIn/Default.master" Theme="Default"  Title=" Risk Insurance Management System :: Error Page" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <div style="height: 125px;">
        &nbsp;
    </div>
    <h3 align="Center">
        <asp:Label ID="lblMsg" runat="server">Error</asp:Label>
        <br />
        <br />
        <a href="javascript:history.go(-1);">Back</a>
    </h3>
    <div style="height: 125px;">
        &nbsp;
    </div>
    <div style="height: 50px;" runat="server" id="dvErrorXML" align="Center">
        <a href="<%=AppConfig.SiteURL%>Error.xml" style="color: White;">Error.XML</a>
    </div>
</asp:Content>
