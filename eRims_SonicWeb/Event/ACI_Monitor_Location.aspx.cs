using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Text;

public partial class Event_ACI_Monitor_Location : System.Web.UI.Page
{
    #region "Properties"

    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string _SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string _SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_ACI_Link_LU_Location
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_ACI_Link_LU_Location"]);
        }
        set { ViewState["PK_ACI_Link_LU_Location"] = value; }
    }

    #endregion

    #region "Page Event"

    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Is Page Post Back
        if (!IsPostBack)
        {
            _SortBy = "Location";
            _SortOrder = "asc";
            //Bind Grid Function
            BindGrid(1, clsSession.NumberOfSearchRows);
            BindDropDownList();
        }
    }

    #endregion

    #region "Event"

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        _PK_ACI_Link_LU_Location = 0;
        pnlDetail.Visible = true;
        pnlGrid.Visible = false;
        drpFK_Building_ID.SelectedIndex = -1;
        drpFK_LU_Location.SelectedIndex = -1;
        txtGroup_ID.Text = string.Empty;

        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtGroup_ID);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlDetail.Visible = false;
        pnlGrid.Visible = true;
        drpFK_Building_ID.SelectedIndex = -1;
        drpFK_LU_Location.SelectedIndex = -1;
        txtGroup_ID.Text = string.Empty;

    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        clsACI_Link_LU_Location objLU_Location = new clsACI_Link_LU_Location();

        decimal _retVal;

        objLU_Location.PK_ACI_Link_LU_Location = _PK_ACI_Link_LU_Location;
        if (txtGroup_ID.Text.Trim() != string.Empty)
            objLU_Location.Group_ID = Convert.ToDecimal(txtGroup_ID.Text.Trim());
        
        if (drpFK_LU_Location.SelectedIndex > 0)
            objLU_Location.FK_LU_Location = Convert.ToDecimal(drpFK_LU_Location.SelectedValue);
        
        if (drpFK_Building_ID.SelectedIndex > 0)
            objLU_Location.FK_Building_ID = Convert.ToDecimal(drpFK_Building_ID.SelectedValue);

        objLU_Location.Updated_By = Convert.ToString(clsSession.UserID);
        
        if (_PK_ACI_Link_LU_Location > 0)
        {
            _retVal = objLU_Location.Update();
        }
        else
        {
            _retVal = objLU_Location.Insert();
        }
        if (_retVal < 0)
        {
            if (_retVal == -2)
            {
                lblError.Text = "The Group ID you are trying to enter already exists";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtGroup_ID);
            }
            else if (_retVal == -3)
            {
                lblError.Text = "The Building for Location you are trying to enter already exists";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(drpFK_LU_Location);
            }
            return;
        }
        else
        {
            _PK_ACI_Link_LU_Location = _retVal;
        }
        //clear Control
        ClearControls();
        //Bind Grid Function
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        //Cancel CLick
        btnCancel_Click(null, null);
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        BindGrid(1, ctrlPageProperty.PageSize);
    }

    protected void GetPage()
    {
        BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
    }

    /// <summary>
    /// Returns the index of the column which contains perticular sort expression
    /// </summary>
    /// <param name="strSortExp">The column on which the sorting is to be performed</param>
    /// <returns>Integer</returns>
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 1;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvGroupID.Columns)
        {
            if (field.SortExpression.ToString() == strSortExp)
            {
                nRet = gvGroupID.Columns.IndexOf(field);
            }
        }
        return nRet;
    }

    /// <summary>
    /// Adds the sorting image beside the column in the grid on which 
    /// sorting has been performed
    /// </summary>
    /// <param name="headerRow">Header Row of the grid</param>
    private void AddSortImage(GridViewRow headerRow)
    {
        Int32 iCol = GetSortColumnIndex(_SortBy);
        if (iCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = _SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

        // check for the order and
        // set the images accordingly 
        if (SortDirection.Ascending.ToString() == strSortOrder)
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }
        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }

    protected void drpFK_LU_Location_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboHelper.FillBuildingByFK_LU_Location(new DropDownList[] { drpFK_Building_ID }, true, drpFK_LU_Location.SelectedIndex > 0 ? Convert.ToDecimal(drpFK_LU_Location.SelectedValue) : 0);
    }

    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    //Get Record into Dataset
    //    DataSet dsCatastrophe = clsLU_Catastrophe.SearchByPaging(txtSearchDesc.Text.Trim().Replace("'", "''"), _SortBy, _SortOrder, 1, ctrlPageProperty.TotalRecords);
    //    DataTable dtCatastrophe = dsCatastrophe.Tables[0];

    //    //Create HTML for the report and wirte into HTML Write object
    //    StringBuilder strHTML = new StringBuilder();
    //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
    //    System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

    //    //Add Header HTML
    //    strHTML.Append("<table cellpadding='0' cellspacing='0' width='100%' border='1'>");
    //    strHTML.Append("<tr align='right' valign='bottom' style='font-weight: bold;'>");
    //    strHTML.Append("<td align='left'>Catastrophe Code</td>");
    //    strHTML.Append("<td align='left'>Description</td>");
    //    strHTML.Append("<td align='left'>Active</td>");
    //    strHTML.Append("</tr>");

    //    if (dtCatastrophe.Rows.Count > 0)
    //    {
    //        for (int i = 0; i < dtCatastrophe.Rows.Count; i++)
    //        {
    //            strHTML.Append("<tr align='left'>");
    //            strHTML.Append("<td>" + Convert.ToString(dtCatastrophe.Rows[i]["Fld_Code"]) + "</td>");
    //            strHTML.Append("<td>" + Convert.ToString(dtCatastrophe.Rows[i]["Fld_Desc"]) + "</td>");
    //            strHTML.Append("<td>" + (Convert.ToString(dtCatastrophe.Rows[i]["Active"]) == "N" ? "No" : "Yes") + "</td>");
    //            strHTML.Append("</tr>");
    //        }
    //    }
    //    else
    //    {
    //        //Add No record found line for year
    //        strHTML.Append("<tr><td colspan='6' align='center'>No Record Found</td></tr>");
    //    }
    //    strHTML.Append("</table>");

    //    //Write HTML in to HtmlWriter
    //    htmlWrite.WriteLine(strHTML.ToString());

    //    HttpContext context = HttpContext.Current;
    //    context.Response.Clear();

    //    context.Response.Write(stringWrite);
    //    context.Response.ContentType = "application/ms-excel";
    //    context.Response.AppendHeader("Content-Disposition", "attachment; filename=Catastrophe.xls");
    //    context.Response.End();
    //}

    #endregion

    #region "Grid Event"

    /// <summary>
    /// Row command event for Edit and update
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvGroupID_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_ACI_Link_LU_Location = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            pnlDetail.Visible = true;
            pnlGrid.Visible = false;

            // get record from database
            clsACI_Link_LU_Location objLocation = new clsACI_Link_LU_Location(_PK_ACI_Link_LU_Location);
            BindDropDownList();
            clsGeneral.SetDropdownValue(drpFK_LU_Location, objLocation.FK_LU_Location, true);

            if (drpFK_LU_Location.SelectedIndex > 0)
            {
                ComboHelper.FillBuildingByFK_LU_Location(new DropDownList[] { drpFK_Building_ID }, true, drpFK_LU_Location.SelectedIndex > 0 ? Convert.ToDecimal(drpFK_LU_Location.SelectedValue) : 0);
            }

            clsGeneral.SetDropdownValue(drpFK_Building_ID, objLocation.FK_Building_ID, true);
            txtGroup_ID.Text = Convert.ToString(objLocation.Group_ID);
            

            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtGroup_ID);
        }
        else if (e.CommandName == "RemoveRecord")
        {
            clsACI_Link_LU_Location.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            BindGrid(ctrlPageProperty.CurrentPage, ctrlPageProperty.PageSize);
        }
    }

    /// <summary>
    /// Handles event when row is created for auto Claim grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvGroupID_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != _SortBy)
            {
                // update sort image beside the column header 
                AddSortImage(e.Row);
            }
            else
            {
                // add sort image beside the column header 
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[1].Controls.Add(sortImage);
            }
        }
    }

    /// <summary>
    /// Handles event when row header link is clicked for sorting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvGroupID_Sorting(object sender, GridViewSortEventArgs e)
    {
        //// update sort field and sort order and bind the grid
        _SortOrder = (_SortBy == e.SortExpression) ? (_SortOrder == "asc" ? "desc" : "asc") : "asc";
        _SortBy = e.SortExpression;
        GetPage();
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Catastrophe Grid
    /// </summary>
    private void BindGrid(int PageNumber, int PageSize)
    {
        //Get Record into Dataset
        DataSet ds = clsACI_Link_LU_Location.SearchByPaging("", _SortBy, _SortOrder, PageNumber, PageSize);

        //Apply Dataset to Grid
        gvGroupID.DataSource = ds.Tables[0];
        gvGroupID.DataBind();

        // set values for paging control,so it shows values as needed.
        ctrlPageProperty.TotalRecords = (ds.Tables.Count >= 2) ? Convert.ToInt32(ds.Tables[1].Rows[0][0]) : 0;
        ctrlPageProperty.CurrentPage = (ds.Tables.Count >= 2) ? Convert.ToInt32(ds.Tables[1].Rows[0][2]) : 0;
        ctrlPageProperty.RecordsToBeDisplayed = ds.Tables[0].Rows.Count;
        ctrlPageProperty.SetPageNumbers();

        lblNumber.Text = (ds.Tables.Count >= 2) ? Convert.ToString(ds.Tables[1].Rows[0][0]) : "0";

        //btnExport.Visible = ds.Tables[0].Rows.Count > 0;
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_ACI_Link_LU_Location = 0;
    }

    /// <summary>
    /// Bind Drop Down Items
    /// </summary>
    private void BindDropDownList()
    {
        ComboHelper.FillLocationDBA_All(new DropDownList[] { drpFK_LU_Location }, 0, true);
        ComboHelper.FillBuildingByFK_LU_Location(new DropDownList[] { drpFK_Building_ID }, true, 0);
    }

    #endregion

}