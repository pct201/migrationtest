using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Controls_SonicClaimNotes_SonicNotes : System.Web.UI.UserControl
{

    #region " Properties "
    public string CurrentClaimType
    {
        get { return Convert.ToString(ViewState["CurrentClaimType"]); }
        set { ViewState["CurrentClaimType"] = value; }
    }

    public long PK_WC_CI_ID
    {
        get { return Convert.ToInt64(ViewState["PK_WC_CI_ID"]); }
        set { ViewState["PK_WC_CI_ID"] = value; }
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

    public long Location_ID
    {
        get { return Convert.ToInt64(ViewState["Location_ID"]); }
        set { ViewState["Location_ID"] = value; }
    }

    public bool IsAddVisible
    {
        get { return Convert.ToBoolean(ViewState["IsAddVisible"]); }
        set { ViewState["IsAddVisible"] = value; }
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
    public long WzID
    {
        get { return Convert.ToInt64(ViewState["wz_id"]); }
        set { ViewState["wz_id"] = value; }
    }
    #endregion

    #region " PageEvents "
    protected void Page_Load(object sender, EventArgs e)
    {
        ctrlPageSonicNotes.GetPage += new Controls_Navigation_Navigation.dlgGetPage(ctrlPageSonicNotes_GetPage);
        if (IsAddVisible)
        {
            btnNotesAdd.Visible = true;
            gvNotes.Columns[4].Visible = true;
        }
        else
        {
            if (gvNotes.Rows.Count == 0)
            {
                gvNotes.DataBind();
                btnView.Visible = false;
                btnPrint.Visible = false;
            }
            btnNotesAdd.Visible = false;
            gvNotes.Columns[4].Visible = false;
        }
    }

    protected void ctrlPageSonicNotes_GetPage()
    {
        if (CurrentClaimType == "ALClaim")
        {
            BindGridSonicNotes(PK_AL_CI_ID, CurrentClaimType);
        }
        if (CurrentClaimType == "WCClaim")
        {
            BindGridSonicNotes(PK_WC_CI_ID, CurrentClaimType);
        }
        if (CurrentClaimType == "PropertyClaim")
        {
            BindGridSonicNotes(PK_Property_CI_ID, CurrentClaimType);
        }
        if (CurrentClaimType == "PLClaim")
        {
            BindGridSonicNotes(PK_PL_CI_ID, CurrentClaimType);
        }
        if (CurrentClaimType == "DPDClaim")
        {
            BindGridSonicNotes(PK_DPD_Claims_ID, CurrentClaimType);
        }
    }
    #endregion

    #region " Methods "
    /// <summary>
    /// Bind Grid Sonic Note
    /// </summary>
    public void BindGridSonicNotes(decimal FK_Table, string Table_Name)
    {
        CurrentPage = ctrlPageSonicNotes.CurrentPage;
        PageSize = ctrlPageSonicNotes.PageSize;

        long Pk_Claim = 0;

        if (CurrentClaimType == "ALClaim")
        {
            Pk_Claim = PK_AL_CI_ID;
        }
        else if (CurrentClaimType == "WCClaim")
        {
            Pk_Claim = PK_WC_CI_ID;
        }
        else if (CurrentClaimType == "PropertyClaim")
        {
            Pk_Claim = PK_Property_CI_ID;
        }
        else if (CurrentClaimType == "PLClaim")
        {
            Pk_Claim = PK_PL_CI_ID;
        }
        else if (CurrentClaimType == "DPDClaim")
        {
            Pk_Claim = PK_DPD_Claims_ID;
        }

        DataSet dsNotes = Claim_Notes.SelectByFK_Table(Pk_Claim, CurrentClaimType, CurrentPage, PageSize);
        DataTable dtNotes = dsNotes.Tables[0];
        ctrlPageSonicNotes.TotalRecords = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][0]) : 0;
        ctrlPageSonicNotes.CurrentPage = (dsNotes.Tables.Count >= 2) ? Convert.ToInt32(dsNotes.Tables[1].Rows[0][2]) : 0;
        ctrlPageSonicNotes.RecordsToBeDisplayed = dsNotes.Tables[0].Rows.Count;
        ctrlPageSonicNotes.SetPageNumbers();
        gvNotes.DataSource = dtNotes;
        gvNotes.DataBind();

        btnView.Visible = dtNotes.Rows.Count > 0;
        btnPrint.Visible = dtNotes.Rows.Count > 0;
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
            clsGeneral.Claim_Tables claimtype = (clsGeneral.Claim_Tables)(Enum.Parse(typeof(clsGeneral.Claim_Tables), CurrentClaimType));
            if (claimtype == clsGeneral.Claim_Tables.ALClaim)
            {
                if (IsAddVisible)
                    Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_AL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.ALClaim.ToString());
                else
                    Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_AL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.ALClaim.ToString() + "&page=AP_AL" + "&loc=" + Encryption.Encrypt(Location_ID.ToString()) + "&op=" + StrOperation);
            }
            if (claimtype == clsGeneral.Claim_Tables.PLClaim)
            {
                Response.Redirect("ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_PL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.PLClaim.ToString());
            }
            if (claimtype == clsGeneral.Claim_Tables.PropertyClaim)
            {
                Response.Redirect("ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_Property_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.PropertyClaim.ToString() + "&wz_id=" + Encryption.Encrypt(WzID.ToString()));
            }
            if (claimtype == clsGeneral.Claim_Tables.WCClaim)
            {
                Response.Redirect("ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_WC_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.WCClaim.ToString());
            }
            if (claimtype == clsGeneral.Claim_Tables.DPDClaim)
            {
                if (IsAddVisible)
                    Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_DPD_Claims_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.DPDClaim.ToString());
                else
                    Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_DPD_Claims_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.DPDClaim.ToString() + "&page=AP_DPD" + "&loc=" + Encryption.Encrypt(Location_ID.ToString()) + "&op=" + StrOperation);
            }
        }
        else if (e.CommandName == "Remove")
        {
            // Delete record
            Claim_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            clsGeneral.Claim_Tables claimtype = (clsGeneral.Claim_Tables)(Enum.Parse(typeof(clsGeneral.Claim_Tables), CurrentClaimType));
            if (claimtype == clsGeneral.Claim_Tables.ALClaim)
            {
                BindGridSonicNotes(PK_AL_CI_ID, clsGeneral.Claim_Tables.ALClaim.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(6);", true);
            }
            else if (claimtype == clsGeneral.Claim_Tables.PLClaim)
            {
                BindGridSonicNotes(PK_PL_CI_ID, clsGeneral.Claim_Tables.PLClaim.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(6);", true);
            }
            else if (claimtype == clsGeneral.Claim_Tables.PropertyClaim)
            {
                BindGridSonicNotes(PK_Property_CI_ID, clsGeneral.Claim_Tables.PropertyClaim.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(3);", true);
            }
            else if (claimtype == clsGeneral.Claim_Tables.WCClaim)
            {
                BindGridSonicNotes(PK_WC_CI_ID, clsGeneral.Claim_Tables.WCClaim.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(7);", true);
            }
            else if (claimtype == clsGeneral.Claim_Tables.DPDClaim)
            {
                BindGridSonicNotes(PK_DPD_Claims_ID, clsGeneral.Claim_Tables.DPDClaim.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(4);", true);
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
        clsGeneral.Claim_Tables claimtype = (clsGeneral.Claim_Tables)(Enum.Parse(typeof(clsGeneral.Claim_Tables), CurrentClaimType));
        if (claimtype == clsGeneral.Claim_Tables.ALClaim)
        {
            Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_AL_CI_ID.ToString()) + "&tbl=" + claimtype.ToString());
        }
        else if (claimtype == clsGeneral.Claim_Tables.PLClaim)
        {
            Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_PL_CI_ID.ToString()) + "&tbl=" + claimtype.ToString());
        }
        else if (claimtype == clsGeneral.Claim_Tables.PropertyClaim)
        {
            Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_Property_CI_ID.ToString()) + "&tbl=" + claimtype.ToString());
        }
        else if (claimtype == clsGeneral.Claim_Tables.WCClaim)
        {
            Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_WC_CI_ID.ToString()) + "&tbl=" + claimtype.ToString());
        }
        else if (claimtype == clsGeneral.Claim_Tables.DPDClaim)
        {
            Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_DPD_Claims_ID.ToString()) + "&tbl=" + claimtype.ToString());
        }
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
        clsGeneral.Claim_Tables claimtype = (clsGeneral.Claim_Tables)(Enum.Parse(typeof(clsGeneral.Claim_Tables), CurrentClaimType));
        if (claimtype == clsGeneral.Claim_Tables.ALClaim)
        {
            if (IsAddVisible)
                Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_AL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.ALClaim.ToString());
            else
                Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_AL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.ALClaim.ToString() + "&page=AP_AL" + "&loc=" + Encryption.Encrypt(Location_ID.ToString()) + "&op=" + StrOperation);
        }
        else if (claimtype == clsGeneral.Claim_Tables.PLClaim)
        {
            Response.Redirect("ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_PL_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.PLClaim.ToString());
        }
        else if (claimtype == clsGeneral.Claim_Tables.PropertyClaim)
        {
            Response.Redirect("ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_Property_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.PropertyClaim.ToString() + "&wz_id=" + Encryption.Encrypt(Convert.ToString(WzID)));
        }
        else if (claimtype == clsGeneral.Claim_Tables.WCClaim)
        {
            Response.Redirect("ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_WC_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.WCClaim.ToString());
        }
        else if (claimtype == clsGeneral.Claim_Tables.DPDClaim)
        {
            if (IsAddVisible)
                Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_DPD_Claims_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.DPDClaim.ToString());
            else
                Response.Redirect(AppConfig.SiteURL + "SONIC/ClaimInfo/ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_DPD_Claims_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.DPDClaim.ToString() + "&page=AP_DPD" + "&loc=" + Encryption.Encrypt(Location_ID.ToString()) + "&op=" + StrOperation);
        }
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
        clsGeneral.Claim_Tables claimtype = (clsGeneral.Claim_Tables)(Enum.Parse(typeof(clsGeneral.Claim_Tables), CurrentClaimType));
        if (claimtype == clsGeneral.Claim_Tables.ALClaim)
        {
            clsPrintClaimNotes.PrintSelectedSonicNotes(strPK, clsGeneral.Claim_Tables.ALClaim.ToString(), PK_AL_CI_ID);
        }
        else if (claimtype == clsGeneral.Claim_Tables.PLClaim)
        {
            clsPrintClaimNotes.PrintSelectedSonicNotes(strPK, clsGeneral.Claim_Tables.PLClaim.ToString(), PK_PL_CI_ID);
        }
        else if (claimtype == clsGeneral.Claim_Tables.PropertyClaim)
        {
            clsPrintClaimNotes.PrintSelectedSonicNotes(strPK, clsGeneral.Claim_Tables.PropertyClaim.ToString(), PK_Property_CI_ID);
        }
        else if (claimtype == clsGeneral.Claim_Tables.WCClaim)
        {
            clsPrintClaimNotes.PrintSelectedSonicNotes(strPK, clsGeneral.Claim_Tables.WCClaim.ToString(), PK_WC_CI_ID);
        }
        else if (claimtype == clsGeneral.Claim_Tables.DPDClaim)
        {
            clsPrintClaimNotes.PrintSelectedSonicNotes(strPK, clsGeneral.Claim_Tables.DPDClaim.ToString(), PK_DPD_Claims_ID);
        }
    }
    //protected void GetPage()
    //{
    //    BindGridSonicNotes(PK_WC_CI_ID, clsGeneral.Claim_Tables.WCClaim.ToString(), ctrlPageSonicNotes.CurrentPage, ctrlPageSonicNotes.PageSize);
    //}
    #endregion
}