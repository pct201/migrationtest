using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DashBoard_EmployeeDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["PreviousPage"] = Request.UrlReferrer;//Saves the Previous page url in ViewState
            if (Request.QueryString["AssociateStatus"] != null)
            {
                if (Request.QueryString["AssociateStatus"].ToString() == "AssociateToTrain")
                    gvEmployeeDetail.Columns[2].Visible = false;
                else if(Request.QueryString["AssociateStatus"].ToString() == "AssociateTrained")
                    gvEmployeeDetail.Columns[2].Visible = true;
            }

            if (Session["EmployeeDetails"] != null)
            {
                gvEmployeeDetail.DataSource = Session["EmployeeDetails"];
                gvEmployeeDetail.DataBind();
            }
        }
    }
    protected void Back_Click(object sender, EventArgs e)
    {
        if (ViewState["PreviousPage"] != null)	//Check if the ViewState contains Previous page URL
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }
    }
}