using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;

public partial class SONIC_Sedgwick_ClaimSearch : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindOffice();
            if (Session["dtClaimReviewGroupSearch"] != null)
            {
                //get the data table from session
                DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
                //check datatable have atleast one row
                if (dtSearch.Rows.Count > 0)
                {
                    DataRow drSearch = dtSearch.Rows[0];

                    //get the values from each column of row
                    decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
                    lblYear.Text = drSearch["Year"].ToString();
                    lblQuarter.Text = drSearch["Quarter"].ToString();
                    ddlSedgwickClaimOffice.SelectedValue = FK_LU_Sedgwick_Field_Office.ToString();
                    BindState(FK_LU_Sedgwick_Field_Office);
                }
            }

            //FIll Sonic Locaition Number Dropdown
            ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true);
            ddlRMLocationNumber.Style.Remove("font-size");

            //fill Location dba Dropdown
            ComboHelper.FIllLocationdba_LegalEntity(new DropDownList[] { ddlLocationdba }, 0, true);
        }
    }

    private void BindOffice()
    {
        if (clsSession.UserID != "")
        {
            DataTable dtYears = LU_Sedgwick_Field_Office.SelectAll(Convert.ToDecimal(clsSession.UserID)).Tables[0];
            ddlSedgwickClaimOffice.DataSource = dtYears;
            ddlSedgwickClaimOffice.DataTextField = "Fld_Desc";
            ddlSedgwickClaimOffice.DataValueField = "PK_LU_Sedgwick_Field_Office";
            ddlSedgwickClaimOffice.DataBind();
        }
        ddlSedgwickClaimOffice.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    private void BindState(decimal? FK_LU_Sedgwick_Field_Office)
    {
        if (FK_LU_Sedgwick_Field_Office > 0)
        {
            DataTable dtState = LU_Sedgwick_Field_Office_State.SelectAllStateByFK_LU_Sedgwick_Field_Office(FK_LU_Sedgwick_Field_Office).Tables[0];
            ddlState.DataSource = dtState;
            ddlState.DataTextField = "FLD_state";
            ddlState.DataValueField = "PK_ID";
            ddlState.DataBind();
        }
        ddlState.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    #region Dropdown's Selcted Value change Events

    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        /// update all other dropdown according to RM location number selected
        ddlLocationdba.SelectedValue = ddlRMLocationNumber.SelectedValue;
    }
    protected void ddlLocationdba_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to dba selected
        ddlRMLocationNumber.SelectedValue = ddlLocationdba.SelectedValue;
    }
    protected void ddlSedgwickClaimOffice_SelectedIndexChanged(object sender, EventArgs a)
    {
        if (ddlSedgwickClaimOffice.SelectedValue.ToString() != "0")
            BindState(Convert.ToDecimal(ddlSedgwickClaimOffice.SelectedValue));
    }

    #endregion
    /// <summary>
    /// Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // create an object for datatable
        DataTable dtSearch = new DataTable();

        // columns for search values
        DataColumn FK_LU_Sedgwick_Field_Office = new DataColumn("FK_LU_Sedgwick_Field_Office", typeof(decimal));
        DataColumn State_PK_ID = new DataColumn("State_PK_ID", typeof(Int32));
        DataColumn Origin_Claim_Number = new DataColumn("Origin_Claim_Number", typeof(string));
        DataColumn dcAssociatedFirstReport = new DataColumn("AssociatedFirstReport", typeof(int));
        DataColumn dcClaimType = new DataColumn("ClaimType", typeof(string));
        DataColumn dcClaimStatus = new DataColumn("ClaimStatus", typeof(string));
        DataColumn dcLocationNumber = new DataColumn("LocationNumber", typeof(decimal));
        DataColumn dcDateFromAccident = new DataColumn("DateFromAccident", typeof(DateTime));
        DataColumn dcDateToAccident = new DataColumn("DateToAccident", typeof(DateTime));
        DataColumn dcLT_Med_Only_FlagForWC = new DataColumn("LT_Med_Only_FlagForWC", typeof(string));
        DataColumn dcLT_Med_Only_FlagForNS = new DataColumn("LT_Med_Only_FlagForNS", typeof(string));

        // add columns in datatable
        dtSearch.Columns.Add(FK_LU_Sedgwick_Field_Office);
        dtSearch.Columns.Add(State_PK_ID);
        dtSearch.Columns.Add(Origin_Claim_Number);
        dtSearch.Columns.Add(dcAssociatedFirstReport);
        dtSearch.Columns.Add(dcClaimType);
        dtSearch.Columns.Add(dcClaimStatus);
        dtSearch.Columns.Add(dcLocationNumber);
        dtSearch.Columns.Add(dcDateFromAccident);
        dtSearch.Columns.Add(dcDateToAccident);
        dtSearch.Columns.Add(dcLT_Med_Only_FlagForWC);
        dtSearch.Columns.Add(dcLT_Med_Only_FlagForNS);
        //create a row with all search values 
        DataRow drSearch = dtSearch.NewRow();
        drSearch["FK_LU_Sedgwick_Field_Office"] = (ddlSedgwickClaimOffice.SelectedIndex > 0) ? Convert.ToDecimal(ddlSedgwickClaimOffice.SelectedValue) : 0;
        drSearch["State_PK_ID"] = (ddlState.SelectedIndex > 0) ? Convert.ToInt32(ddlState.SelectedValue) : 0;
        //drSearch["WC_FR_Number"] = (ddlQuarter.SelectedIndex > 0) ? Convert.ToInt32(ddlQuarter.SelectedValue) : 0;
        drSearch["Origin_Claim_Number"] = Convert.ToString(txtClaimNumber.Text.ToString());
        drSearch["AssociatedFirstReport"] = Convert.ToInt32((txtFirstReportNumber.Text != "") ? txtFirstReportNumber.Text : "0");
        if (chklClaimType.Items[0].Selected && chklClaimType.Items[1].Selected)
            drSearch["ClaimType"] = "";
        else
            drSearch["ClaimType"] = (chklClaimType.SelectedValue != "") ? chklClaimType.SelectedValue : "";

        drSearch["ClaimStatus"] = rdoClaim.SelectedValue;
        drSearch["LocationNumber"] = (ddlRMLocationNumber.SelectedIndex > 0) ? Convert.ToDecimal(ddlRMLocationNumber.SelectedValue) : 0;
        drSearch["DateFromAccident"] = clsGeneral.FormatDateToStore(txtFromDate.Text);
        drSearch["DateToAccident"] = clsGeneral.FormatDateToStore(txtToDate.Text);
        drSearch["LT_Med_Only_FlagForWC"] = rblLT_Med_Only_FlagForWC.SelectedValue;
        drSearch["LT_Med_Only_FlagForNS"] = rblLT_Med_Only_FlagForNS.SelectedValue;
        // add the row in datatable
        dtSearch.Rows.Add(drSearch);

        // store the table in session and redirect to search result page
        Session["dtClaimReviewWorkSheetGroupSearch"] = dtSearch;
        Session["dtClaimReviewWorkSheetSearch"] = dtSearch;
        Response.Redirect("ClaimReviewWorksheetSearchGrid.aspx", true);
        //Response.Redirect("ClaimSearchGrid.aspx", true);
    }
    /// <summary>
    /// Back Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        DataTable dtSearch = (DataTable)Session["dtClaimReviewGroupSearch"];
        //check datatable have atleast one row
        if (dtSearch.Rows.Count > 0)
        {
            DataRow drSearch = dtSearch.Rows[0];

            //get the values from each column of row
            decimal FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
            lblYear.Text = drSearch["Year"].ToString();
            lblQuarter.Text = drSearch["Quarter"].ToString();
            Response.Redirect("ClaimSearchGrid.aspx?Id=" + Encryption.Encrypt(Convert.ToString(drSearch["FK_LU_Sedgwick_Field_Office"])) + "&Year=" + Encryption.Encrypt(drSearch["Year"].ToString()) + "&Quarter=" + Encryption.Encrypt(drSearch["Quarter"].ToString()), true);
        }
        else
        { 
            Response.Redirect("ClaimSearchGrid.aspx");
        }
    }
}