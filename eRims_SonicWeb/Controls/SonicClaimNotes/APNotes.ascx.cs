using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Controls_SonicClaimNotes_APNotes : System.Web.UI.UserControl
{
    #region " Properties "
    public string CurrentClaimType
    {
        get { return Convert.ToString(ViewState["CurrentClaimType"]); }
        set { ViewState["CurrentClaimType"] = value; }
    }

    public long PK_AL_CI_ID
    {
        get { return Convert.ToInt64(ViewState["PK_AL_CI_ID"]); }
        set { ViewState["PK_AL_CI_ID"] = value; }
    }

    public long PK_Property_CI_ID
    {
        get { return Convert.ToInt64(ViewState["PK_Property_CI_ID"]); }
        set { ViewState["PK_Property_CI_ID"] = value; }
    }

    public long PK_PL_CI_ID
    {
        get { return Convert.ToInt64(ViewState["PK_PL_CI_ID"]); }
        set { ViewState["PK_PL_CI_ID"] = value; }
    }

    public long PK_DPD_Claims_ID
    {
        get { return Convert.ToInt64(ViewState["PK_DPD_Claims_ID"]); }
        set { ViewState["PK_DPD_Claims_ID"] = value; }
    }

    public long PK_COI_Claims_ID
    {
        get { return Convert.ToInt64(ViewState["PK_COI_Claims_ID"]); }
        set { ViewState["PK_COI_Claims_ID"] = value; }
    }

    public long Location_ID
    {
        get { return Convert.ToInt64(ViewState["Location_ID"]); }
        set { ViewState["Location_ID"] = value; }
    }

    public string StrOperation
    {
        get { return Convert.ToString(ViewState["StrOperation"]); }
        set { ViewState["StrOperation"] = value; }
    }

    public int CurrentPage
    {
        get { return Convert.ToInt32(ViewState["CurrentPage"]); }
        set { ViewState["CurrentPage"] = value; }
    }
    public int PageSize
    {
        get { return Convert.ToInt32(ViewState["PageSize"]); }
        set { ViewState["PageSize"] = value; }
    }

    public int FK_Table
    {
        get { return ViewState["FK_Table"] == null ? 0 : Convert.ToInt32(ViewState["FK_Table"]); }
        set { ViewState["FK_Table"] = value; }
    }

    #endregion

    #region " PageEvents "
    protected void Page_Load(object sender, EventArgs e)
    {
        ctrlPageSonicNotes.GetPage += new Controls_Navigation_Navigation.dlgGetPage(ctrlPageSonicNotes_GetPage);
        if (StrOperation == "edit")
        {
            
            if (FK_Table > 0)
            {
                btnNotesAdd.Visible = true;
                btnView.Visible = true;
                btnPrint.Visible = true;
            }
            else
            {
                btnNotesAdd.Visible = false;
                btnView.Visible = false;
                btnPrint.Visible = false;
            }
            gvNotes.Columns[4].Visible = true;
        }
        else
        {
            if (gvNotes.Rows.Count == 0)
            {
                
                btnView.Visible = false;
                btnPrint.Visible = false;
            }
            btnNotesAdd.Visible = false;
            gvNotes.Columns[4].Visible = false;
        }
    }

    protected void ctrlPageSonicNotes_GetPage()
    {
        if (CurrentClaimType == "AP_AL_FROIs")
        {
            BindGridSonicNotes(FK_Table, CurrentClaimType);
        }
        if (CurrentClaimType == "AP_DPD_FROIs")
        {
            BindGridSonicNotes(FK_Table, CurrentClaimType);
        }
        //if (CurrentClaimType == "PropertyClaim")
        //{
        //    BindGridSonicNotes(PK_Property_CI_ID, CurrentClaimType);
        //}
        //if (CurrentClaimType == "PLClaim")
        //{
        //    BindGridSonicNotes(PK_PL_CI_ID, CurrentClaimType);
        //}
        //if (CurrentClaimType == "DPDClaim")
        //{
        //    BindGridSonicNotes(PK_DPD_Claims_ID, CurrentClaimType);
        //}
        //if (CurrentClaimType == "COIClaim")
        //{
        //    BindGridSonicNotes(PK_COI_Claims_ID, CurrentClaimType);
        //}
    }
    #endregion

    #region " Methods "
    /// <summary>
    /// Bind Grid Sonic Note
    /// </summary>
    public void BindGridSonicNotes(decimal FK_Table_1, string Table_Name)
    {
        CurrentPage = ctrlPageSonicNotes.CurrentPage;
        PageSize = ctrlPageSonicNotes.PageSize;

        long Pk_Claim = 0;

        //if (CurrentClaimType == "AP_AL_FROIs")
        //{
        //    Pk_Claim = PK_AL_CI_ID;
        //}
        //else if (CurrentClaimType == "AP_DPD_FROIs")
        //{
        //    Pk_Claim = PK_DPD_Claims_ID;
        //}

        Pk_Claim = (long)FK_Table_1;

        DataSet dsNotes = clsAP_Notes.SelectByFK_Table(Pk_Claim, CurrentClaimType, CurrentPage, PageSize);
        DataTable dtNotes = dsNotes.Tables[0];
        ctrlPageSonicNotes.TotalRecords = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][0]) : 0;
        ctrlPageSonicNotes.CurrentPage = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][2]) : 0;
        ctrlPageSonicNotes.RecordsToBeDisplayed = dsNotes.Tables[0].Rows.Count;
        ctrlPageSonicNotes.SetPageNumbers();
        gvNotes.DataSource = dtNotes;
        gvNotes.DataBind();

        btnView.Visible = dtNotes.Rows.Count > 0;
        btnPrint.Visible = dtNotes.Rows.Count > 0;
        FK_Table = Convert.ToInt32(FK_Table_1);
        if (FK_Table_1 > 0 && StrOperation == "edit")
        {
            btnNotesAdd.Visible = true;
        }
        else
        {
            btnNotesAdd.Visible = false;
        }

    }

    public void BindEmptyGrid()
    {
        gvNotes.DataSource = new DataTable();
        gvNotes.DataBind();
        btnView.Visible = false;
        btnPrint.Visible = false;
        btnNotesAdd.Visible = false;
    }
    #endregion

    #region " GridEvents"
    /// <summary>
    /// Grid Notes Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "EditRecord")
        {
            //Get the Claim Note ID
            clsGeneral.AP_Tables claimtype = (clsGeneral.AP_Tables)(Enum.Parse(typeof(clsGeneral.AP_Tables), CurrentClaimType));
            //if (claimtype == clsGeneral.AP_Tables.AP_AL_FROIs)
            //{
                Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/ClaimNotesAP.aspx?loc=" + Location_ID + "&id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Table.ToString()) + "&tbl=" + claimtype.ToString() + "&op=" + StrOperation);
            //}
        }
        else if (e.CommandName == "Remove")
        {
            // Delete record
            clsAP_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            clsGeneral.AP_Tables claimtype = (clsGeneral.AP_Tables)(Enum.Parse(typeof(clsGeneral.AP_Tables), CurrentClaimType));
            if (claimtype == clsGeneral.AP_Tables.AP_AL_FROIs)
            {
                BindGridSonicNotes(FK_Table, CurrentClaimType);
                ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(6);", true);
            }
        }
    }
    #endregion

    #region " Control Events "
    /// <summary>
    /// Add New Note Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNotesAdd_Click(object sender, EventArgs e)
    {

        Response.Redirect("..//ClaimInfo//ClaimNotesAP.aspx?loc=" + Location_ID + "&FK_Claim=" + Encryption.Encrypt(FK_Table.ToString()) + "&tbl=" + CurrentClaimType);
    }

    /// <summary>
    /// Button Click Event to View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnView_Click(object sender, EventArgs e)
    {
        string strPK = "";
        foreach (GridViewRow gRow in gvNotes.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');
        //if (IsAddVisible)
        //       Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/ClaimNotesAP.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_AL_CI_ID.ToString()) + "&tbl=" + "AP_AL_FROIs");
        //else
        Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/ClaimNotesAP.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(FK_Table.ToString()) + "&tbl=" + CurrentClaimType + "&loc=" + Location_ID.ToString() + "&op=" + StrOperation);
        //Response.Redirect("..//ClaimInfo//ClaimNotesAP.aspx?loc=" + Location_ID + "&FK_Claim=" + Encryption.Encrypt(FK_Table.ToString()) + "&tbl=" + CurrentClaimType);

    }

    /// <summary>
    /// Button Print Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string strPK = "";
        foreach (GridViewRow gRow in gvNotes.Rows)
        {
            if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
                strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
        }
        strPK = strPK.TrimEnd(',');
        
        clsPrintClaimNotesAP.PrintSelectedSonicNotes(strPK, CurrentClaimType, FK_Table);
        

    }
   
    #endregion
}