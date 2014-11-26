using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
using BAL;

public partial class SONIC_Sedgwick_ClaimReviewWorkSheetGroupSearch : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindYear();
            BindOffice();
        }
    }

    private void BindYear()
    {
        ddlYear.Items.Clear();
        int intMinYear, intMaxYear;
        intMinYear = 2014;
        intMaxYear = DateTime.Now.Year;
        for (int i = intMaxYear; i >= intMinYear; i--)
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        ddlYear.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    private void BindOffice()
    {
        DataTable dtYears = LU_Sedgwick_Field_Office.SelectAll(Convert.ToDecimal(clsSession.UserID)).Tables[0]; 
        ddlSedgwickClaimOffice.DataSource = dtYears;
        ddlSedgwickClaimOffice.DataTextField = "Fld_Desc";
        ddlSedgwickClaimOffice.DataValueField = "PK_LU_Sedgwick_Field_Office";
        ddlSedgwickClaimOffice.DataBind();
        ddlSedgwickClaimOffice.Items.Insert(0, new ListItem("-- Select --", "0"));
    }

    #region Search Button Click Event
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //// create an object for datatable
        DataTable dtSearch = new DataTable();
        //// columns for search values
        DataColumn FK_LU_Sedgwick_Field_Office = new DataColumn("FK_LU_Sedgwick_Field_Office", typeof(decimal));
        DataColumn Year = new DataColumn("Year", typeof(Int32));
        DataColumn Quarter = new DataColumn("Quarter", typeof(Int32));

        //// add columns in datatable
        dtSearch.Columns.Add(FK_LU_Sedgwick_Field_Office);
        dtSearch.Columns.Add(Year);
        dtSearch.Columns.Add(Quarter);
        //create a row with all search values 

        decimal Tmp_FK_LU_Sedgwick_Field_Office = (ddlSedgwickClaimOffice.SelectedIndex > 0) ? Convert.ToDecimal(ddlSedgwickClaimOffice.SelectedValue) : 0;
        Int32 Tmp_Year = (ddlYear.SelectedIndex > 0) ? Convert.ToInt32(ddlYear.SelectedValue) : 0;
        Int32 Tmp_Quarter = (ddlQuarter.SelectedIndex > 0) ? Convert.ToInt32(ddlQuarter.SelectedValue) : 0;

        DataRow drSearch = dtSearch.NewRow();
        drSearch["FK_LU_Sedgwick_Field_Office"] = Tmp_FK_LU_Sedgwick_Field_Office;
        drSearch["Year"] = Tmp_Year;
        drSearch["Quarter"] = Tmp_Quarter;
        //// add the row in datatable
        dtSearch.Rows.Add(drSearch);

        //if (dtSearch.Rows.Count > 0)
        //{
        //     drSearch = dtSearch.Rows[0];
             //get the values from each column of row
             //decimal Tmp_FK_LU_Sedgwick_Field_Office = Convert.ToDecimal(drSearch["FK_LU_Sedgwick_Field_Office"]);
             //Int32 Tmp_Year = Convert.ToInt32(drSearch["Year"]);
             //Int32 Tmp_Quarter = Convert.ToInt32(drSearch["Quarter"]);
        DataSet dsClaimInfo = Sedgwick_Claim_Group.ClaimReviewWorkSheetGroup_Search_New(Tmp_FK_LU_Sedgwick_Field_Office, Tmp_Year, Tmp_Quarter, "Origin_Claim_Number", "ASC", 1, 10, clsSession.CurrentLoginEmployeeId);

            // selects records depending on paging criteria and search values.
             //DataSet dsClaimInfo = Sedgwick_Claim_Group.Search(Tmp_FK_LU_Sedgwick_Field_Office, Tmp_Year, Tmp_Quarter, "PK_Sedgwick_Claim_Group", "asc", 1, 20);
             Session["dtClaimReviewGroupSearch"] = dtSearch;

             if (dsClaimInfo != null && dsClaimInfo.Tables.Count > 0 && dsClaimInfo.Tables[0].Rows.Count > 0)
             {
                 // store the table in session and redirect to search result page                 
                 dsClaimInfo = null;
                 Response.Redirect("ClaimSearchGrid.aspx?Id=" + Encryption.Encrypt(Convert.ToString(Tmp_FK_LU_Sedgwick_Field_Office)) + "&Year=" + Encryption.Encrypt(Convert.ToString(Tmp_Year)) + "&Quarter=" + Encryption.Encrypt(Convert.ToString(Tmp_Quarter)), true);
             } 
             else
             {   
                 if (App_Access == AccessType.View_Only)
                 {
                     //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('No Claim Review Worksheets exist for Sedgwick Claim Office = '" + ddlSedgwickClaimOffice.SelectedItem.Text.ToString().Trim() + "', Year = '" + Tmp_Year + "' and Quarter = '" + Tmp_Quarter + "');", true);
                     Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "ConfirmRedirectToClaimSearch('" + ddlSedgwickClaimOffice.SelectedItem.Text.ToString().Trim() + "','" + Tmp_Year + "','" + Tmp_Quarter + "',true);", true);
                 }
                 else
                 {
                     Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "ConfirmRedirectToClaimSearch('" + ddlSedgwickClaimOffice.SelectedItem.Text.ToString().Trim() + "','" + Tmp_Year + "','" + Tmp_Quarter + "',false);", true);
                 }
             }
        //}
    }
    #endregion
}