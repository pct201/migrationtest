using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using aspPDF;
public partial class CheckWriting_Pdf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        aspPDF.EASYPDF pdf = new aspPDF.EASYPDF();
        pdf.Create();
        pdf.AddText("Hello World from .NET");
        pdf.AddGraphicPos(60, 12, Server.MapPath("../Images/copyonly.gif"));
        
        pdf.AddTextPos(10,111, "Yash Barot As Engginer**************************************************************************************************");
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment; filename=MyPDF.PDF");
        Response.BinaryWrite((byte[])pdf.SaveVariant());
    }
}
