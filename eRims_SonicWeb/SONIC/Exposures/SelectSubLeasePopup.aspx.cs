using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using ERIMS.DAL;

public partial class SONIC_Exposures_SelectSubLeasePopup : System.Web.UI.Page
{
    #region "Page Events"

    /// <summary>
    /// Handles page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!IsPostBack)
        {
            // binds the grid
            BindGrid();
        }
    }
    #endregion

    #region "Methods"

    /// <summary>
    /// Binds the grid
    /// </summary>
    private void BindGrid()
    {
        // get the OwnerShip ID from the querystring
        int Fk_Building_Id = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["loc"]));

        // get the SubLease records by the OwnerShip id 
        DataTable dtSubLease = clsBuilding_Ownership_Sublease.GetSubLeaseByBuilding(Fk_Building_Id).Tables[0];

        // bind the grid
        gvSubLease.DataSource = dtSubLease;
        gvSubLease.DataBind();
    }
    #endregion

    #region " Gridview Events"

    protected void gvSubLease_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "SelectSubLease")
        {
            RE_Subtenant ObjRE_Subtenant = new RE_Subtenant();
            ObjRE_Subtenant.FK_RE_Information = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["PK_RE"]));
            ObjRE_Subtenant.Subtenant_DBA = Convert.ToString(e.CommandArgument);
            ObjRE_Subtenant.Update_Date = DateTime.Now;
            ObjRE_Subtenant.Updated_By = clsSession.UserID;
            int intRet = ObjRE_Subtenant.Insert();
            if (intRet > 0)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:CloseWindow();", true);
            }
            else
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('Lease record already exists for the subtenant.');", true);
        }
    }

    #endregion
}