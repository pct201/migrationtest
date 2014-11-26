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

public partial class Administrator_WCAllocation : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_Worker_Comp_id
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Worker_Comp_id"]);
        }
        set { ViewState["PK_Worker_Comp_id"] = value; }
    }
    /// <summary>
    /// Denotes Sort Field to sort all records by
    /// </summary>
    private string SortBy
    {
        get { return (!clsGeneral.IsNull(ViewState["SortBy"]) ? ViewState["SortBy"].ToString() : string.Empty); }
        set { ViewState["SortBy"] = value; }
    }

    /// <summary>
    /// Denotes ascending or descending order
    /// </summary>
    private string SortOrder
    {
        get { return (!clsGeneral.IsNull(ViewState["SortOrder"]) ? ViewState["SortOrder"].ToString() : string.Empty); }
        set { ViewState["SortOrder"] = value; }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SortOrder = "asc";
            SortBy = "Year desc, Region, Cause";
            //Bind WC Allocation Grid
            BindGrid();
            //Fill Region Location
            ComboHelper.FillRegion(new DropDownList[] { ddlRegion } , true);

        }
    }
    /// <summary>
    /// Binds the grid 
    /// </summary>
    private void BindGrid()
    {
        DataSet dsWC = Workers_comp_charges.SelectAll(SortBy + " " + SortOrder);
        
        // bind the grid.
        gvworkers_comp_charges.DataSource = dsWC;
        gvworkers_comp_charges.DataBind();
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        PK_Worker_Comp_id = 0;
        divViewWCList.Style.Add("display", "none");
        divModifyWC.Style.Add("display", "");
        DivEditWC.Style.Add("display", "");
        DivViewWC.Style.Add("display", "none");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave.Visible = true;
        Workers_comp_charges objWCCharge = new Workers_comp_charges(PK_Worker_Comp_id);
        objWCCharge.Worker_Comp_id = PK_Worker_Comp_id;

        // set value of object
        objWCCharge.Year = Convert.ToInt32(txtYear.Text.ToString().Trim());
        objWCCharge.Region = ddlRegion.SelectedValue.ToString();
        objWCCharge.Charge = Convert.ToDecimal(txtCharge.Text.ToString().Trim());
        objWCCharge.Cause = ddlCause.SelectedValue.ToString();
        if (PK_Worker_Comp_id > 0)
            objWCCharge.Update();
        else
            objWCCharge.Insert();
        BindGrid();
        btnCancel_Click(null, null);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnSave.Visible = true;
        txtYear.Text = "";
        ddlCause.SelectedValue = "0";
        ddlRegion.SelectedValue = "0";
        txtCharge.Text = "";
        divViewWCList.Style.Add("display", "");
        divModifyWC.Style.Add("display", "none");
        DivEditWC.Style.Add("display", "none");
        DivViewWC.Style.Add("display", "none");
    }
    private void EditRecord(Decimal PK_ID)
    {
        if (PK_ID > 0)
        {
            divViewWCList.Style.Add("display", "none");
            divModifyWC.Style.Add("display", "");
            DivEditWC.Style.Add("display", "");
            DivViewWC.Style.Add("display", "none");
            PK_Worker_Comp_id = Convert.ToInt32(PK_ID);
            btnSave.Visible = true;
            Workers_comp_charges objWCC = new Workers_comp_charges(PK_ID);
            txtYear.Text = Convert.ToString(objWCC.Year);
            txtCharge.Text = clsGeneral.GetStringValue(objWCC.Charge);
            ddlCause.SelectedValue = objWCC.Cause;
            ddlRegion.SelectedValue = objWCC.Region;
            //ListItem lst = ddlRegion.Items.FindByValue(objWCC.Region);
            //if (lst != null)
            //    lst.Selected = true;
        }
    }
    private void ViewRecord(Decimal PK_ID)
    {
        if (PK_ID > 0)
        {
            divViewWCList.Style.Add("display", "none");
            divModifyWC.Style.Add("display", "");
            DivEditWC.Style.Add("display", "none");
            DivViewWC.Style.Add("display", "");
            btnSave.Visible = false;
            Workers_comp_charges objWCC = new Workers_comp_charges(PK_ID);
            lblYear.Text = Convert.ToString(objWCC.Year);
            lblCharge.Text = clsGeneral.GetStringValue(objWCC.Charge);
            lblCause.Text = objWCC.Cause;
            lblRegion.Text = objWCC.Region;
        }
    }
    protected void gvworkers_comp_charges_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            int Index = Convert.ToInt32(e.CommandArgument.ToString());
            int PK_ID = (gvworkers_comp_charges.DataKeys[Index].Values["Worker_Comp_id"] != null ? Convert.ToInt32(gvworkers_comp_charges.DataKeys[Index].Values["Worker_Comp_id"]) : 0);
            EditRecord(Convert.ToDecimal(PK_ID));
        }
        else if (e.CommandName == "View")
        {
            int Index = Convert.ToInt32(e.CommandArgument.ToString());
            int PK_ID = (gvworkers_comp_charges.DataKeys[Index].Values["Worker_Comp_id"] != null ? Convert.ToInt32(gvworkers_comp_charges.DataKeys[Index].Values["Worker_Comp_id"]) : 0);
            ViewRecord(Convert.ToDecimal(PK_ID));
        }
        else if (e.CommandName == "Delete")
        {
            int Index = Convert.ToInt32(e.CommandArgument.ToString());
            decimal PK_ID = (gvworkers_comp_charges.DataKeys[Index].Values["Worker_Comp_id"] != null ? Convert.ToDecimal(gvworkers_comp_charges.DataKeys[Index].Values["Worker_Comp_id"]) : 0);
            Workers_comp_charges.DeleteByPK(PK_ID);
            BindGrid();
        }
    }
    protected void gvworkers_comp_charges_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // check for the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            // if sort field already available
            if (String.Empty != SortBy)
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
                e.Row.Cells[0].Controls.Add(sortImage);
            }
        }
        
        
        // check for the header row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button lnkEdit = (Button)e.Row.FindControl("lnkEdit");
            Button lnkView = (Button)e.Row.FindControl("lnkView");
            Button lnkDelete = (Button)e.Row.FindControl("lnkDelete");
            if (lnkEdit != null) lnkEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
            if (lnkView != null) lnkView.CommandArgument = Convert.ToString(e.Row.RowIndex);
            if (lnkDelete != null) lnkDelete.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }

    protected void gvworkers_comp_charges_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    protected void gvworkers_comp_charges_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvworkers_comp_charges_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCharge = (Label)e.Row.FindControl("lblCharge");
            if (lblCharge != null)
                lblCharge.Text = "$ " + clsGeneral.GetStringValue(DataBinder.Eval(e.Row.DataItem, "Charge"));
        }
    }
    protected void gvworkers_comp_charges_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortOrder = (SortBy == e.SortExpression) ? (SortOrder == "asc" ? "desc" : "asc") : "asc";
        SortBy = e.SortExpression;
        BindGrid();
    }

    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 intCol = GetSortColumnIndex(SortBy);
        if (intCol == -1)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();
        string strSortOrder = SortOrder == "asc" ? SortDirection.Ascending.ToString() : SortDirection.Descending.ToString();

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
        headerRow.Cells[intCol].Controls.Add(sortImage);
    }
    private int GetSortColumnIndex(object strSortExp)
    {
        int intRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvworkers_comp_charges.Columns)
        {

            if (field.SortExpression.ToString() == strSortExp.ToString())
            {
                intRet = gvworkers_comp_charges.Columns.IndexOf(field);
            }
        }
        return intRet;
    }
}
