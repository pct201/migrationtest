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
using System.Collections.Generic;
using ERIMS.DAL;

public partial class SONIC_ClaimInfo_rptExecutiveRiskData : clsBasePage
{
    #region Varibale

    int EmpSearch_retVal = -1;

    public string Operation
    {
        set { ViewState["op"] = value; }
        get { return clsGeneral.IsNull(ViewState["op"]) ? "" : ViewState["op"].ToString(); }

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
        if (!IsPostBack)
        {
            BindCombos();
            txtClaimNo.Text = txtClaimNo.Text.ToString().Replace("__-_____-__", "");
            Operation = string.IsNullOrEmpty(Request.QueryString["p"]) ? "" : Request.QueryString["p"].ToString();

        }
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Button Click Event - back Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        divGrid.Style["display"] = "none";
        divSearch.Style["display"] = "block";
        ClearAllControl();
        btnMainBack.Visible = false;
        btnGenerateReport.Visible = false;
    }

    /// <summary>
    /// Button Generate Report click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenerateReport_Click(object sender, EventArgs e)
    {

        gvSearch.GridLines = GridLines.Both;
        // export grid data into excel sheet
        GridViewExportUtil.ExportGrid("Executive_Risk_Data_" + DateTime.Now.ToString("MM_dd_yyyy") + ".xls", gvSearch);

        // reset the grid lines and borders

        gvSearch.GridLines = GridLines.None;

    }

    #endregion

    #region Grid Event

    /// <summary>
    /// Gridview Row Databound Event - Search
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        Label lblPK_Executive_Risk = (Label)e.Row.FindControl("lblPK_Executive_Risk");

        #region  Defence Attroney

        Label lblDefence_Attorney = (Label)e.Row.FindControl("lblDefenceAttorney");
        if (lblDefence_Attorney != null && lblPK_Executive_Risk != null)
        {
            DataSet dsDefence_Attorney = Defense_Attorney.SelectByFK_Executive_Risk(Convert.ToDecimal(lblPK_Executive_Risk.Text.Trim()));
            if (dsDefence_Attorney.Tables.Count > 0 && dsDefence_Attorney.Tables[0].Rows.Count > 0)
            {
                lblDefence_Attorney.Text = "";
                for (int i = 0; i < dsDefence_Attorney.Tables[0].Rows.Count; i++)
                {
                    lblDefence_Attorney.Text += (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Firm"]) != "" ? (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Firm"]) + ", ") : "");
                    lblDefence_Attorney.Text += (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Name"]) != "" ? (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Name"]) + ", ") : "");
                    lblDefence_Attorney.Text += (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Address_1"]) != "" ? (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Address_1"]) + ", ") : "");
                    lblDefence_Attorney.Text += (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Telephone"]) != "" ? (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Telephone"]) + ", ") : "");
                    lblDefence_Attorney.Text += (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["E_Mail"]) != "" ? (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["E_Mail"]) + ", ") : "");
                    lblDefence_Attorney.Text += (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Panel"]) == "Y" ? "Yes" : "No");
                    lblDefence_Attorney.Text += "<br style='mso-data-placement:same-cell;' /><br style='mso-data-placement:same-cell;' />";
                }
                lblDefence_Attorney.Text = lblDefence_Attorney.Text.Substring(0, lblDefence_Attorney.Text.Length - 88);
            }
        }

        #endregion

        #region PlatiniffAttorney

        Label lblPlatiniffAttorney = (Label)e.Row.FindControl("lblPlatiniffAttorney");
        if (lblPlatiniffAttorney != null && lblPK_Executive_Risk != null)
        {
            DataSet dsDefence_Attorney = Plaintiff_Attorney.SelectByFK_Executive_Risk(Convert.ToDecimal(lblPK_Executive_Risk.Text.Trim()));
            if (dsDefence_Attorney.Tables.Count > 0 && dsDefence_Attorney.Tables[0].Rows.Count > 0)
            {
                lblPlatiniffAttorney.Text = "";
                for (int i = 0; i < dsDefence_Attorney.Tables[0].Rows.Count; i++)
                {
                    lblPlatiniffAttorney.Text += (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Firm"]) != "" ? (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Firm"]) + ", ") : "");
                    lblPlatiniffAttorney.Text += (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Name"]) != "" ? (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Name"]) + ", ") : "");
                    lblPlatiniffAttorney.Text += (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Address_1"]) != "" ? (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Address_1"]) + ", ") : "");
                    lblPlatiniffAttorney.Text += (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Telephone"]) != "" ? (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Telephone"]) + ", ") : "");
                    lblPlatiniffAttorney.Text += (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["E_Mail"]) != "" ? (Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["E_Mail"]) + ", ") : "");
                    lblPlatiniffAttorney.Text += "<br style='mso-data-placement:same-cell;' /><br style='mso-data-placement:same-cell;' />";
                }
                lblPlatiniffAttorney.Text = lblPlatiniffAttorney.Text.Substring(0, lblPlatiniffAttorney.Text.Length - 88);
            }
        }

        #endregion

        #region Type Of Allegation

        Label lblType_of_Allegation = (Label)e.Row.FindControl("lblType_of_Allegation");
        if (lblType_of_Allegation != null && lblPK_Executive_Risk != null)
        {
            DataSet dsDefence_Attorney = clsExecutive_Risk_Allegation.SelectType_ER_AllegationByFK_Executive_Risk(Convert.ToDecimal(lblPK_Executive_Risk.Text.Trim()));
            if (dsDefence_Attorney.Tables.Count > 0 && dsDefence_Attorney.Tables[0].Rows.Count > 0)
            {
                lblType_of_Allegation.Text = "";
                for (int i = 0; i < dsDefence_Attorney.Tables[0].Rows.Count; i++)
                {
                    lblType_of_Allegation.Text += Convert.ToString(dsDefence_Attorney.Tables[0].Rows[i]["Fld_Desc"]) + ",";
                    lblType_of_Allegation.Text += "<br style='mso-data-placement:same-cell;' />";
                }
                lblType_of_Allegation.Text = lblType_of_Allegation.Text.Substring(0, lblType_of_Allegation.Text.Length - 45);
            }
        }

        #endregion


    }


    protected void gvSearch_RowCreated(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow rowHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            Literal newCells = new Literal();
            newCells.Text = "Executive Risk Data ";
            TableHeaderCell headerCell = new TableHeaderCell();
            headerCell.Controls.Add(newCells);
            headerCell.ColumnSpan = gvSearch.Columns.Count - 1;
            headerCell.Style["text-align"] = "center";
            rowHeader.Cells.Add(headerCell);
            newCells = new Literal();
            newCells.Text = DateTime.Now.ToString("MM/dd/yyyy");
            headerCell = new TableHeaderCell();
            headerCell.Controls.Add(newCells);
            headerCell.Style["text-align"] = "right";
            rowHeader.Cells.Add(headerCell);
            rowHeader.Visible = true;
            gvSearch.Controls[0].Controls.AddAt(0, rowHeader);
        }

    }

    #endregion

    #region Search Process

    /// <summary>
    /// BUtton Searck Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// This method is added for export Girdview To Excel which contains SubGridview.
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    /// <summary>
    /// method to Bind Grid
    /// </summary>
    private void BindGrid()
    {
        divGrid.Style["display"] = "block";
        divSearch.Style["display"] = "none";

        btnMainBack.Visible = true;
        btnGenerateReport.Visible = true;

        string strExecutiveRisk = "", strClaimNumber = "", strDateofLossFrom = "", strDateofLossTo = "";
        int? intClaimStatus = null;
        decimal? decFK_Entity = null, decFK_Risk_Type = null;

        strClaimNumber = txtClaimNo.Text.Trim();
        strDateofLossFrom = txtOCFrom.Text.Trim();
        strDateofLossTo = txtOCTo.Text.Trim();
        if (rbtnOCFrom.SelectedIndex > 0)
        {
            intClaimStatus = Convert.ToInt32(rbtnOCFrom.SelectedValue);
        }

        if (ddlEntity.SelectedIndex > 0)
            decFK_Entity = Convert.ToDecimal(ddlEntity.SelectedValue);
        if (ddlExecutiveRisk.SelectedIndex > 0)
            decFK_Risk_Type = Convert.ToDecimal(ddlExecutiveRisk.SelectedValue);

        DataSet dsExecutiveData = Executive_Risk.ExecutiveRiskData(strExecutiveRisk, strClaimNumber, strDateofLossFrom, strDateofLossTo, intClaimStatus, decFK_Entity, decFK_Risk_Type);
        if (dsExecutiveData.Tables.Count > 0 && dsExecutiveData.Tables[0].Rows.Count > 0)
        {
            gvSearch.DataSource = dsExecutiveData.Tables[0];
            gvSearch.DataBind();
            gvSearch.Style["width"] = "4650px";
        }
        else
        {
            gvSearch.DataSource = null;
            gvSearch.DataBind();
            gvSearch.Style["width"] = "998px";
            btnGenerateReport.Visible = false;
        }
    }


    /// <summary>
    /// Bind Combos
    /// </summary>
    private void BindCombos()
    {
        //used to fill RM Location Number Dropdown
        ComboHelper.FillLocationdba(new DropDownList[] { ddlRMLocationNumber }, 0, true);
        ddlRMLocationNumber.Style.Remove("font-size");
        //used to fill Legal Entity Dropdown
        //ComboHelper.FillLocationLegal_Entity(new DropDownList[] { ddlLegalEntity }, 0, true);
        //used to fill dba Dropdown
        ComboHelper.FillLocationdbaOnly(new DropDownList[] { ddlLocationdba }, 0, true);
        ddlLocationdba.Style.Remove("font-size");
        //objGeneral= new RIMS_Base.Biz.CGeneral();
        //lstGeneral = new List<RIMS_Base.CGeneral>();
        //lstGeneral= objGeneral.GetAllEntity();
        DataTable dtEntity = Entity.SelectForExecutiveRisk().Tables[0];
        ddlEntity.DataSource = dtEntity;
        ddlEntity.DataTextField = "Entity";
        ddlEntity.DataValueField = "PK_LU_Location_ID";
        ddlEntity.DataBind();
        ddlEntity.Items.Insert(0, new ListItem("--Select Entity--", "0"));

        // Binds the type dropdown
        DataTable dtType = Type_Of_ER_Claim.SelectAll().Tables[0];
        ddlExecutiveRisk.DataSource = dtType;
        ddlExecutiveRisk.DataTextField = "Fld_Desc";
        ddlExecutiveRisk.DataValueField = "PK_Type_Of_ER_Claim";
        ddlExecutiveRisk.DataBind();
        ddlExecutiveRisk.Items.Insert(0, "--Select Type of Claim--");
    }



    /// <summary>
    /// Clear All Controls
    /// </summary>
    private void ClearAllControl()
    {

        rbtnOCFrom.Items[0].Selected = false;
        rbtnOCFrom.Items[1].Selected = false;
        rbtnOCFrom.Items[2].Selected = false;
        txtClaimNo.Text = "";
        txtOCFrom.Text = "";
        txtOCTo.Text = "";
        ddlRMLocationNumber.SelectedIndex = 0;
        //ddlLegalEntity.SelectedIndex = 0;
        ddlLocationdba.SelectedIndex = 0;
        ddlEntity.SelectedIndex = 0;
        ddlExecutiveRisk.SelectedIndex = 0;
    }

    #endregion

    #region "Selected Index Change Evnet"

    /// <summary>
    /// Handles event when RM location number dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRMLocationNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to RM location number selected
        //ddlLegalEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ddlLocationdba.SelectedValue = ddlRMLocationNumber.SelectedValue;
        ListItem lstItm = ddlEntity.Items.FindByValue(ddlLocationdba.SelectedValue);
        if (lstItm != null)
            ddlEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
        else
            ddlEntity.SelectedValue = "0";
    }

    /// <summary>
    /// Handles event when Leagal entity dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void ddlLegalEntity_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    // update all other dropdown according to entity selected
    //    ddlRMLocationNumber.SelectedValue = ddlLegalEntity.SelectedValue;
    //    ddlLocationdba.SelectedValue = ddlLegalEntity.SelectedValue;
    //    ddlEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
    //}

    /// <summary>
    /// Handles event when dba dropdown selection changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlLocationdba_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to dba selected
        ddlRMLocationNumber.SelectedValue = ddlLocationdba.SelectedValue;
        //ddlLegalEntity.SelectedValue = ddlLocationdba.SelectedValue;
        ddlEntity.SelectedValue = ddlRMLocationNumber.SelectedValue;
    }

    /// <summary>
    /// Dropdown Selected Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlEntity_SelectedIndexChanged(object sender, EventArgs e)
    {
        // update all other dropdown according to dba selected
        ddlRMLocationNumber.SelectedValue = ddlEntity.SelectedValue;
        //ddlLegalEntity.SelectedValue = ddlEntity.SelectedValue;
        ddlLocationdba.SelectedValue = ddlEntity.SelectedValue;
    }

    #endregion
}