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
using ERIMS.DAL;

public partial class Management_EmployeePopup : System.Web.UI.Page
{
    #region "Page load"

    #region Property

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int Sonic_Location_Code
    {
        get
        {
            return clsGeneral.GetInt(ViewState["Sonic_Location_Code"]);
        }
        set { ViewState["Sonic_Location_Code"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["pk"]))
            {
                clsAci_Lu_Location lu = new clsAci_Lu_Location(Convert.ToDecimal(Request.QueryString["pk"]));
                Sonic_Location_Code = Convert.ToInt32(lu.Fld_Code);
            }
            BindGrid();
        }
    }
    #endregion

    #region "Methods"
    /// <summary>
    /// Bind Grid functionality
    /// </summary>
    public void BindGrid()
    {
        DataSet dsEmployeeFilter = Employee.SelectEmployeeByDBALocation(txtFirstName.Text.ToString(), txtLastName.Text.ToString(), Convert.ToString(rdlstAndOr.SelectedValue), Convert.ToInt32(Sonic_Location_Code));
        dsEmployeeFilter.Tables[0].DefaultView.RowFilter = "Active_Inactive_Leave='Active'";
        gvAssociateName.DataSource = dsEmployeeFilter.Tables[0].DefaultView;
        gvAssociateName.DataBind();
    }
    #endregion

    #region "Click events"
    /// <summary>
    /// Submit Button CLick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    #endregion

    #region "Grid events"

    /// <summary>
    /// Grid Paging Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAssociateName_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssociateName.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    /// <summary>
    /// RowDataBound event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvAssociateName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //find anchor Tag in grid control
            HtmlAnchor HA = e.Row.FindControl("AssociateName") as HtmlAnchor;
            //check HtmlAnchor is null or not
            if (HA != null)
            {
                HA.Attributes.Add("onclick", "ClosePopup(" + DataBinder.Eval(e.Row.DataItem, "PK_Employee_ID") + ",'" + DataBinder.Eval(e.Row.DataItem, "First_Name").ToString().Replace("'", "\\'") + "'" + ",'" + DataBinder.Eval(e.Row.DataItem, "Last_Name").ToString().Replace("'", "\\'") + "'" + ",'" + DataBinder.Eval(e.Row.DataItem, "Employee_Home_Phone").ToString().Replace("'", "\\'") + "'" + ",'" + DataBinder.Eval(e.Row.DataItem, "Email").ToString().Replace("'", "\\'") + "');");
            }

        }
    }
    #endregion
}