using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;

public partial class ExecutiveRisk_PopupDefenseAttorney : System.Web.UI.Page
{
    #region "Properties"

    #endregion

    #region "Page Event"
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
        }
    }
    #endregion

    #region " Controls Events "


    #endregion

    #region "Methods"

    /// <summary>
    /// Performs search and binds the grid
    /// </summary>
    private void BindGrid()
    {
        DataSet dsAttorney = clsLU_Executive_Risk_Defense_Attorney.SelectAll();
        DataTable dtAttorneyData = dsAttorney.Tables[0];

        dtAttorneyData.DefaultView.RowFilter = "Active = 'Y'";

        // bind the grid.
        gvDefenseAttorney.DataSource = dtAttorneyData.DefaultView;
        gvDefenseAttorney.DataBind();
    }

    #endregion

    #region " GridView Events "

    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDefenseAttorney_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDefenseAttorney.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }

    /// <summary>
    /// Handle Row Data Bound event is selected row data in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDefenseAttorney_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strPK_LU_Executive_Risk_Defense_Attorney = "";
                string strFirm = "", strName = "", strAddress_1 = "", strAddress_2 = "", strCity = "", strFK_State = "", strZip_Code = "";
                string strTelephone = "", strE_Mail = "", strPanel = "", strNotes = "";
                LinkButton lnkdba = ((LinkButton)(e.Row.FindControl("lnkFirm")));
                LinkButton lnkBuildingNumber = ((LinkButton)(e.Row.FindControl("lnkName")));
                LinkButton lnkAddress = ((LinkButton)(e.Row.FindControl("lnkAddress")));


                strFirm = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Firm"));
                strName = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Name"));
                strAddress_1 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_1"));
                strAddress_2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Address_2"));
                strCity = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "City"));
                strFK_State = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FK_State"));
                if (strFK_State == "")
                    strFK_State = "0";
                strZip_Code = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Zip_Code"));
                strTelephone = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Telephone"));
                strE_Mail = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "E_Mail"));
                
                strPanel = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Panel"));
                strNotes = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Notes"));
                strPK_LU_Executive_Risk_Defense_Attorney = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PK_LU_Executive_Risk_Defense_Attorney"));


                string strJSFunction = "SelectValue('" + strPK_LU_Executive_Risk_Defense_Attorney.ToString().Replace("'", "\\'")
                    + "','" + strFirm.ToString().Replace("'", "\\'")
                    + "','" + strName.ToString().Replace("'", "\\'")
                    + "','" + strAddress_1.ToString().Replace("'", "\\'")
                    + "','" + strAddress_2.ToString().Replace("'", "\\'")
                    + "','" + strCity.ToString().Replace("'", "\\'")
                    + "','" + strFK_State.ToString().Replace("'", "\\'")
                    + "','" + strZip_Code.ToString().Replace("'", "\\'")
                    + "','" + strTelephone.ToString().Replace("'", "\\'")
                    + "','" + strE_Mail.ToString().Replace("'", "\\'")
                    + "','" + strPanel.ToString().Replace("'", "\\'")
                    + "','" + strNotes.ToString().Replace("'", "\\'")
                    + "');";

                lnkdba.Attributes.Add("onclick", strJSFunction);
                lnkBuildingNumber.Attributes.Add("onclick", strJSFunction);
                lnkAddress.Attributes.Add("onclick", strJSFunction);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion
}