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
public partial class Admin_Search : System.Web.UI.Page
{

    #region "Variables"
    /// <summary>
    /// Contains the records for the top grid
    /// </summary>
    DataTable dtSearchResultTop = null;

    /// <summary>
    /// Contains the records for the bottom grid
    /// </summary>
    DataTable dtSearchResultTopBottom = null;
    #endregion"

    #region "Properties"
    /// <summary>
    /// denotes integer to map to the enum for Tables indicating for which table to search the result 
    /// </summary>
    private int intTable
    {
        get { return Convert.ToInt32(ViewState["intTable"]); }
        set { ViewState["intTable"] = value; }
    }

    /// <summary>
    /// Foriegn key for COI for Policy tables
    /// </summary>
    private int FK_COIs
    {
        get { return Convert.ToInt32(ViewState["Fk_COIs"]); }
        set { ViewState["Fk_COIs"] = value; }
    }

    private string strSortBy
    {
        get { return Convert.ToString(ViewState["strSortBy"]); }
        set { ViewState["strSortBy"] = value; }
    }

    private string strSortOrder
    {
        get { return Convert.ToString(ViewState["strSortOrder"]); }
        set { ViewState["strSortOrder"] = value; }
    }

    private string strSortByBottomGrid
    {
        get { return Convert.ToString(ViewState["strSortByBottomGrid"]); }
        set { ViewState["strSortByBottomGrid"] = value; }
    }

    private string strSortOrderBottomGrid
    {
        get { return Convert.ToString(ViewState["strSortOrderBottomGrid"]); }
        set { ViewState["strSortOrderBottomGrid"] = value; }
    }

    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        // when first time the page is loaded
        if (!IsPostBack)
        {
            //check whether the table integer is passed in querystring
            if (!clsGeneral.IsNull(Request.QueryString["tbl"]))
            {
                //set table integer
                intTable = Convert.ToInt32(Request.QueryString["tbl"]);

                //display necessary search fields
                DisplaySearchFields((clsGeneral.Tables)intTable);

                //bind dropdowns of the page
                BindDropdowns();

                //if COI Fk is passed in the query string then  set it
                if (!clsGeneral.IsNull(Request.QueryString["coi"]))
                    FK_COIs = Convert.ToInt32(clsGeneral.GetQueryStringID(Request.QueryString["coi"]));
            }

            // check whether the textbox ID of the caller form 
            // is passed for setting the value if required or not
            if (Request.QueryString["txtID"] != null)
            {
                // store the ID in hidden field
                hdnID.Value = Request.QueryString["txtID"].ToString();
            }
            btnGo_Click(null, null);
        }
        else
        {
            btnGo_Click(null, null);
        }
    }
    #endregion

    #region "Methods"

    /// <summary>
    /// Binds Dropdown for State
    /// </summary>
    private void BindDropdowns()
    {
        DataTable dtStates = COI_State.SelectAll().Tables[0];
        drpState.DataSource = dtStates;
        drpState.DataTextField = "FLD_state";
        drpState.DataValueField = "PK_Id";
        drpState.DataBind();
        drpState.Items.Insert(0, "--Select--");
    }

    /// <summary>
    /// Displays the search field according to the table
    /// Also set the controls to be hidden or shown
    /// </summary>
    /// <param name="TblName"></param>
    private void DisplaySearchFields(clsGeneral.Tables TblName)
    {
        switch (TblName)
        {
            case clsGeneral.Tables.Insureds:
            case clsGeneral.Tables.Risk_Profile:
                dvName.Style["Display"] = "block";
                break;
            case clsGeneral.Tables.Producers:
            case clsGeneral.Tables.Insurance_Companies:
            case clsGeneral.Tables.Location:
            case clsGeneral.Tables.Additional_Insured:
            case clsGeneral.Tables.Owners:
            case clsGeneral.Tables.Copies:
                dvPersonalInfo.Style["Display"] = "block";
                break;
            case clsGeneral.Tables.General_Liability_Policies:
            case clsGeneral.Tables.Automobile_Liability_Policies:
            case clsGeneral.Tables.Excess_Liability_Policies:
            case clsGeneral.Tables.WC_Policies:
            case clsGeneral.Tables.Professional_Liability_Policies:
            case clsGeneral.Tables.COI_Liquor_Policies:
                dvCompany.Style["Display"] = "block";
                break;
        }

        switch (TblName)
        {
            case clsGeneral.Tables.Location:
                lblCompanyOrName.Text = "Name";
                break;
            case clsGeneral.Tables.Additional_Insured:
            case clsGeneral.Tables.Owners:
                trCompanyOrName.Style["Display"] = "None";
                break;
        }
    }

    /// <summary>
    /// Stores data tables to variables and also binds both the grids
    /// </summary>
    /// <param name="dsSearch"></param>
    private void BindGrid(DataSet dsSearch)
    {
        //--------- Bind the top grid 
        dtSearchResultTop = dsSearch.Tables[0];
        if (strSortBy == "") strSortBy = dtSearchResultTop.Columns[1].ColumnName.ToString();
        if (strSortOrder == "") strSortOrder = "asc";
        string strSortExpr = strSortBy + " " + strSortOrder;

        dtSearchResultTop.DefaultView.Sort = strSortExpr;
        dtSearchResultTop = dtSearchResultTop.DefaultView.ToTable();
        gvSearchTop.AutoGenerateColumns = true;
        gvSearchTop.DataSource = dtSearchResultTop;
        gvSearchTop.DataBind();
        //--------------------------------

        // check if the Dataset contains the second table
        if (dsSearch.Tables.Count > 1)
        {
            //------------- Bind the bottom grid
            dtSearchResultTopBottom = dsSearch.Tables[1];
            if (strSortByBottomGrid == "") strSortByBottomGrid = dtSearchResultTopBottom.Columns[1].ColumnName.ToString();
            if (strSortOrderBottomGrid == "") strSortOrderBottomGrid = "asc";
            strSortExpr = strSortByBottomGrid + " " + strSortOrderBottomGrid;

            dtSearchResultTopBottom.DefaultView.Sort = strSortExpr;
            dtSearchResultTopBottom = dtSearchResultTopBottom.DefaultView.ToTable();

            gvSearchBottom.AutoGenerateColumns = true;
            gvSearchBottom.DataSource = dtSearchResultTopBottom;
            gvSearchBottom.DataBind();
            tblBottom.Style["Display"] = "block";
            //-----------------------------------
        }

        tblGrid.Style["Display"] = "block";
        FormatGridCells();
    }

    /// <summary>
    /// Set width and alignment for each cell in both the grids
    /// </summary>
    private void FormatGridCells()
    {
        foreach (GridViewRow e in gvSearchTop.Rows)
        {
            if (e.RowType == DataControlRowType.Header || e.RowType == DataControlRowType.DataRow)
            {
                for (int i = 1; i < dtSearchResultTop.Columns.Count; i++)
                {
                    if (dtSearchResultTop.Columns.Count > 2)
                    {
                        string strColumn = dtSearchResultTop.Columns[i].ColumnName;
                        e.Cells[i].Width = (strColumn == "State") ? new Unit("10%") : new Unit("18%");
                    }
                    else
                    { e.Cells[i].Width = new Unit("50%"); }

                    e.Cells[i].VerticalAlign = VerticalAlign.Top;
                }
            }
        }
        if (dtSearchResultTopBottom != null)
        {
            foreach (GridViewRow e in gvSearchBottom.Rows)
            {
                if (e.RowType == DataControlRowType.Header || e.RowType == DataControlRowType.DataRow)
                {
                    for (int i = 1; i < dtSearchResultTopBottom.Columns.Count; i++)
                    {
                        if (dtSearchResultTopBottom.Columns.Count > 2)
                        {
                            string strColumn = dtSearchResultTopBottom.Columns[i].ColumnName;
                            e.Cells[i].Width = (strColumn == "State") ? new Unit("10%") : new Unit("18%");
                        }
                        else
                        { e.Cells[i].Width = new Unit("50%"); }
                        e.Cells[i].VerticalAlign = VerticalAlign.Top;
                    }
                }
            }
        }
    }


    private void BindGrids()
    {
        // call the related DAL method for Search according to 
        // the table in BindGrid method with search fields
        switch ((clsGeneral.Tables)intTable)
        {
            case clsGeneral.Tables.Insureds:
                BindGrid(COI_Insureds.Search(txtName.Text.Trim().Replace("'", "''")));
                dvCurrentCOIMsg.Style["Display"] = "none";
                break;
            case clsGeneral.Tables.Risk_Profile:
                BindGrid(COI_Risk_Profiles.Search(txtName.Text.Trim().Replace("'", "''")));
                dvCurrentCOIMsg.Style["Display"] = "none";
                break;
            case clsGeneral.Tables.Producers:
                BindGrid(COI_Producers.Search(FK_COIs, txtCompanyOrName.Text.Trim().Replace("'", "''"), txtLastName.Text.Trim().Replace("'", "''"), txtFirstName.Text.Trim().Replace("'", "''"), txtAddress.Text.Trim().Replace("'", "''"), txtCity.Text.Trim().Replace("'", "''"), (drpState.SelectedIndex != 0) ? Convert.ToInt32(drpState.SelectedValue) : 0, txtZipCode.Text.Trim().Replace("'", "''")));
                break;
            case clsGeneral.Tables.Insurance_Companies:
                BindGrid(COI_Insurance_Companies.Search(FK_COIs, txtCompanyOrName.Text.Trim().Replace("'", "''"), txtLastName.Text.Trim().Replace("'", "''"), txtFirstName.Text.Trim().Replace("'", "''"), txtAddress.Text.Trim().Replace("'", "''"), txtCity.Text.Trim().Replace("'", "''"), (drpState.SelectedIndex != 0) ? Convert.ToInt32(drpState.SelectedValue) : 0, txtZipCode.Text.Trim().Replace("'", "''")));
                break;
            case clsGeneral.Tables.General_Liability_Policies:
                BindGrid(COI_General_Policies.Search(FK_COIs, txtPolicyCompany.Text.Trim().Replace("'", "''")));
                break;
            case clsGeneral.Tables.Automobile_Liability_Policies:
                BindGrid(COI_Automobile_Policies.Search(FK_COIs, txtPolicyCompany.Text.Trim().Replace("'", "''")));
                break;
            case clsGeneral.Tables.Excess_Liability_Policies:
                BindGrid(COI_Excess_Policies.Search(FK_COIs, txtPolicyCompany.Text.Trim().Replace("'", "''")));
                break;
            case clsGeneral.Tables.WC_Policies:
                BindGrid(COI_WC_Policies.Search(FK_COIs, txtPolicyCompany.Text.Trim().Replace("'", "''")));
                break;
            case clsGeneral.Tables.COI_Liquor_Policies:
                BindGrid(COI_Liquor_Policies.Search(FK_COIs, txtPolicyCompany.Text.Trim().Replace("'", "''")));
                break;
            case clsGeneral.Tables.Location:
                BindGrid(COI_Locations.Search(Convert.ToInt32(Encryption.Decrypt(Request.QueryString["prop"])), txtCompanyOrName.Text.Trim().Replace("'", "''"), txtLastName.Text.Trim().Replace("'", "''"), txtFirstName.Text.Trim().Replace("'", "''"), txtAddress.Text.Trim().Replace("'", "''"), txtCity.Text.Trim().Replace("'", "''"), (drpState.SelectedIndex != 0) ? Convert.ToInt32(drpState.SelectedValue) : 0, txtZipCode.Text.Trim().Replace("'", "''")));
                dvCurrentCOIMsg.Style["Display"] = "none";
                break;
            case clsGeneral.Tables.Additional_Insured:
                BindGrid(COI_AI.Search(Convert.ToInt32(Encryption.Decrypt(Request.QueryString["loc"])), txtLastName.Text.Trim().Replace("'", "''"), txtFirstName.Text.Trim().Replace("'", "''"), txtAddress.Text.Trim().Replace("'", "''"), txtCity.Text.Trim().Replace("'", "''"), (drpState.SelectedIndex != 0) ? Convert.ToInt32(drpState.SelectedValue) : 0, txtZipCode.Text.Trim().Replace("'", "''")));
                lblTopRecordsFor.Text = "Location";
                lblBottomRecordsFor.Text = "Locations";
                break;
            case clsGeneral.Tables.Professional_Liability_Policies:
                BindGrid(COI_Professional_Policies.Search(FK_COIs, txtPolicyCompany.Text.Trim().Replace("'", "''")));
                break;
            case clsGeneral.Tables.Owners:
                BindGrid(COI_Owners.Search(FK_COIs, txtLastName.Text.Trim().Replace("'", "''"), txtFirstName.Text.Trim().Replace("'", "''"), txtAddress.Text.Trim().Replace("'", "''"), txtCity.Text.Trim().Replace("'", "''"), (drpState.SelectedIndex != 0) ? Convert.ToInt32(drpState.SelectedValue) : 0, txtZipCode.Text.Trim().Replace("'", "''")));
                break;
            case clsGeneral.Tables.Copies:
                BindGrid(COI_Copies.Search(FK_COIs, txtCompanyOrName.Text.Trim().Replace("'", "''"), txtLastName.Text.Trim().Replace("'", "''"), txtFirstName.Text.Trim().Replace("'", "''"), txtAddress.Text.Trim().Replace("'", "''"), txtCity.Text.Trim().Replace("'", "''"), (drpState.SelectedIndex != 0) ? Convert.ToInt32(drpState.SelectedValue) : 0, txtZipCode.Text.Trim().Replace("'", "''")));
                break;
        }
    }


    #endregion

    #region "Search"

    protected void btnGo_Click(object sender, EventArgs e)
    {
        BindGrids();
    }
    #endregion

    #region "TOP GRID EVENTS"

    /// <summary>
    /// Add a link for each column and hide the first column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearchTop_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;
            for (int i = 1; i < dtSearchResultTop.Columns.Count; i++)
            {
                HtmlAnchor a = new HtmlAnchor();
                a.InnerHtml = DataBinder.Eval(e.Row.DataItem, dtSearchResultTop.Columns[i].ColumnName).ToString();
                string strID = Encryption.Encrypt(DataBinder.Eval(e.Row.DataItem, dtSearchResultTop.Columns[0].ColumnName).ToString());

                if (Request.QueryString["txtID"] != null)
                {
                    // if it is required to set the value in textbox of caller form then set the value
                    a.HRef = "javascript:SetValue('" + a.InnerHtml + "');";
                }
                else
                {
                    // redirect to caller form with the ID of the currently clicked link
                    a.HRef = "javascript:Go_Back_To_CallerFormTopSearch('" + strID + "');";
                }
                e.Row.Cells[i].Controls.Add(a);
            }
        }
    }

    protected void gvSearchTop_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearchTop.PageIndex = e.NewPageIndex;
        BindGrids();
    }

    protected void gvSearchTop_Sorting(object sender, GridViewSortEventArgs e)
    {
        strSortBy = e.SortExpression;
        strSortOrder = (strSortOrder == "") ? "asc" : (strSortOrder == "asc" ? "desc" : "asc");
        BindGrids();
    }

    #endregion

    #region "BOTTOM GRID EVENTS"
    /// <summary>
    /// Add a link button for each column and hide the first column
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearchBottom_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Visible = false;
            for (int i = 1; i < dtSearchResultTopBottom.Columns.Count; i++)
            {
                LinkButton lnk = new LinkButton();
                lnk.ID = "lnk" + i.ToString();
                lnk.Text = DataBinder.Eval(e.Row.DataItem, dtSearchResultTopBottom.Columns[i].ColumnName).ToString();
                string strID = DataBinder.Eval(e.Row.DataItem, dtSearchResultTopBottom.Columns[0].ColumnName).ToString();
                lnk.CommandName = "CopyRecord";
                lnk.CommandArgument = strID;
                e.Row.Cells[i].Controls.Add(lnk);
            }
        }
    }

    /// <summary>
    /// Insert the duplicate record of clicked link and 
    /// change the COI or Location ID as the current COI or Location
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearchBottom_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "CopyRecord")
        {
            decimal ID = Convert.ToDecimal(e.CommandArgument);
            switch ((clsGeneral.Tables)intTable)
            {
                case clsGeneral.Tables.Producers:
                    COI_Producers objProducer = new COI_Producers(ID);
                    objProducer.FK_COIs = FK_COIs;
                    ID = objProducer.Insert();
                    break;
                case clsGeneral.Tables.Insurance_Companies:
                    COI_Insurance_Companies objCompany = new COI_Insurance_Companies(ID);
                    objCompany.FK_COIs = FK_COIs;
                    ID = objCompany.Insert();
                    break;
                case clsGeneral.Tables.General_Liability_Policies:
                    COI_General_Policies objGeneralPOlicy = new COI_General_Policies(ID);
                    objGeneralPOlicy.FK_COIs = FK_COIs;
                    ID = objGeneralPOlicy.Insert();
                    break;
                case clsGeneral.Tables.Automobile_Liability_Policies:
                    COI_Automobile_Policies objAutoPolicy = new COI_Automobile_Policies(ID);
                    objAutoPolicy.FK_COIs = FK_COIs;
                    ID = objAutoPolicy.Insert();
                    break;
                case clsGeneral.Tables.Excess_Liability_Policies:
                    COI_Excess_Policies objExcessPolicy = new COI_Excess_Policies(ID);
                    objExcessPolicy.FK_COIs = FK_COIs;
                    ID = objExcessPolicy.Insert();
                    break;
                case clsGeneral.Tables.WC_Policies:
                    COI_WC_Policies objWCPolicy = new COI_WC_Policies(ID);
                    objWCPolicy.FK_COIs = FK_COIs;
                    ID = objWCPolicy.Insert();
                    break;
                case clsGeneral.Tables.Additional_Insured:
                    COI_AI objAI = new COI_AI(ID);
                    objAI.FK_Table_Name = Convert.ToInt32(Encryption.Decrypt(Request.QueryString["loc"]));
                    ID = objAI.Insert();
                    break;
                case clsGeneral.Tables.Professional_Liability_Policies:
                    COI_Professional_Policies objProfessional = new COI_Professional_Policies(ID);
                    objProfessional.FK_COIs = FK_COIs;
                    ID = objProfessional.Insert();
                    break;
                case clsGeneral.Tables.Owners:
                    COI_Owners objOwner = new COI_Owners(ID);
                    objOwner.FK_COIs = FK_COIs;
                    ID = objOwner.Insert();
                    break;
                case clsGeneral.Tables.Copies:
                    COI_Copies objCopies = new COI_Copies(ID);
                    objCopies.FK_COIs = FK_COIs;
                    ID = objCopies.Insert();
                    break;
            }
            hdnID2.Value = Encryption.Encrypt(ID.ToString());
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "RedirectToBack", "javascript:Go_Back_To_CallerForm(" + ID + ");", true);
        }
    }

    protected void gvSearchBottom_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearchBottom.PageIndex = e.NewPageIndex;
        BindGrids();
    }

    protected void gvSearchBottom_Sorting(object sender, GridViewSortEventArgs e)
    {
        strSortByBottomGrid = e.SortExpression;
        strSortOrderBottomGrid = (strSortOrderBottomGrid == "") ? "asc" : (strSortOrderBottomGrid == "asc" ? "desc" : "asc");
        BindGrids();
    }
    #endregion
}
