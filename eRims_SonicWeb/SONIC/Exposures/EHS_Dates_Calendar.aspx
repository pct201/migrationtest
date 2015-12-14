<%@ Page Title="EHS Dates Calendar" Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="EHS_Dates_Calendar.aspx.cs" Inherits="SONIC_Exposures_EHS_Dates_Calendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<style type="text/css">
    .monthblocks{overflow:hidden; width:730px; margin:10px auto;}
    .monthblocks ul{ margin:0; padding:0; list-style:none;}
    .monthblocks ul li{ float:left; margin:20px 40px; padding:0;}
    .monthblocks ul li a{display:block; width:130px; height:50px; line-height:50px; text-align:center; border:2px solid #dadada; font-size:15px; 
    font-family:Arial; color:#333; text-decoration:none; opacity:0.8; filter:alpha(opacity=80); 
    border-radius:6px; -webkit-border-radius:6px; -ms-border-radius:6px;
    box-shadow: 0 1px 5px 0 rgba(0, 0, 0, 0.18); -webkit-box-shadow: 0 1px 5px 0 rgba(0, 0, 0, 0.18); -ms-box-shadow: 0 1px 5px 0 rgba(0, 0, 0, 0.18);}
    .monthblocks ul li a:hover{text-decoration:none; color:#111; opacity:1; filter:alpha(opacity=100);}
    
    .monthblocks ul li a.red{border-color:#fb6666;}
    .monthblocks ul li a.green{border-color:#5fac3d;}
    .monthblocks ul li a.blue{border-color:#5293cb;}
</style>

    <script  type="text/javascript">

        function Redirect(url)
        {
            window.location.href = url;
            return false;
        }

    </script>
    <div>
        <div>
            &nbsp;
        </div>
        <div class="bandHeaderRow">
            RLCM Monthly QA/QC EHS Calendar
        </div>
        <div>
            &nbsp;
        </div>
        <div style="width: 90%; text-align: center; font-size: large;">
            <asp:LinkButton runat="server" ID="lnkbtnLess" ForeColor="Black" OnClick="lnkbtnLess_Click"> <u> < </u> </asp:LinkButton>
            &nbsp;Year :
        <asp:Label ID="lblYear" runat="server"></asp:Label>
            &nbsp; <asp:LinkButton runat="server" ID="lnkbtnGreater" ForeColor="Black" OnClick="lnkbtnGreater_Click"> <u> > </u></asp:LinkButton>
        </div>
        <div>
            &nbsp;
        </div>
        <div class="monthblocks">
            <ul>
                <li><%--<a href="#" class="red">January</a>--%>
                    <asp:LinkButton runat="server" ID="lnkJan">January</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton runat="server" ID="lnkFeb">February</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton runat="server" ID="lnkMar">March</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton runat="server" ID="lnkApril">April</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton runat="server" ID="lnkMay">May</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton runat="server" ID="lnkJune">June</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton runat="server" ID="lnkJuly">July</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton runat="server" ID="lnkAug">August</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton runat="server" ID="lnkSept">September</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton runat="server" ID="lnkOct">October</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton runat="server" ID="lnkNov">November</asp:LinkButton>
                </li>
                <li>
                     <asp:LinkButton runat="server" ID="lnkDec">December</asp:LinkButton>
                </li>
            </ul>
        </div>
        <div>
            &nbsp;
        </div>

    </div>
</asp:Content>