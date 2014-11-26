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
/// <summary>
/// Date           : 25-10-08
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : This Page is Popup Page used display all a Employee Information.
///                  and also for selecting employee.This page also contain search functionality, that searches
///                 a desire employee by first name or last name.
/// 
/// </summary>
public partial class SONIC_AssociateNamePopup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    /// <summary>
    /// Bind Grid functionality
    /// </summary>
    public void BindGrid()
    {
        //check FirstName Textbox and last name textbox empty or not
        if (txtFirstName.Text != string.Empty || txtLastName.Text != string.Empty)
        {
            DataSet dsEmployeeFilter = Employee.SelectEmployeeByName(txtFirstName.Text.ToString(), txtLastName.Text.ToString(), Convert.ToString(rdlstAndOr.SelectedValue));
            dsEmployeeFilter.Tables[0].DefaultView.RowFilter = "Active_Inactive_Leave='Active'";
            gvAssociateName.DataSource = dsEmployeeFilter.Tables[0].DefaultView;
            gvAssociateName.DataBind();
        }
        else
        {
            DataSet dsEmployee = Employee.SelectAll();
            dsEmployee.Tables[0].DefaultView.RowFilter = "Active_Inactive_Leave='Active'";
            gvAssociateName.DataSource = dsEmployee.Tables[0].DefaultView;
            gvAssociateName.DataBind();
        }
    }
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
    /// Submit Button CLick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //Bind Grid For all data
        BindGrid();
    }
    protected void gvAssociateName_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //find anchor Tag in grid control
            HtmlAnchor HA = e.Row.FindControl("AssociateName") as HtmlAnchor;
            //check HtmlAnchor is null or not
            if (HA != null)
            {
                HA.Attributes.Add("onclick", "ClosePopup(" + DataBinder.Eval(e.Row.DataItem, "PK_Employee_ID") + ",'" + DataBinder.Eval(e.Row.DataItem, "EmployeeName").ToString().Replace("'", "\\'") + "');");
            }

        }
    }
}
