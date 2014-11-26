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

public partial class Liability_LiabilityReserveWorksheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        setVisible();
    }
    private void setVisible()
    {
        claimid.Style.Add("display", "none");
        Owner.Style.Add("display", "none");
        attachment.Style.Add("display", "none");

        if (Request.QueryString["id"] != null)
        {
            switch (Convert.ToInt32(Request.QueryString["id"].ToString()))
            {
                case 1:
                    claimid.Style.Add("display", "block");
                    break;
                case 2:
                    Owner.Style.Add("display", "block");
                    break;
                case 3:
                    attachment.Style.Add("display", "block");
                    break;

                default:
                    claimid.Style.Add("display", "block");
                    break;
            }
        }
        else
        { claimid.Style.Add("display", "block"); }
    }
   
    protected void Save_Click(object sender, EventArgs e)
    {
        Response.Redirect("Subrogation.aspx");
    }
}
