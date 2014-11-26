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
public partial class Admin_COISearch : clsBasePage
{
    #region "Page Events"
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                //Bind dropdowns in the pages for search
                BindDropdowns();
            }
            if (!(clsGeneral.IsNull(Request.QueryString["a"])))
            {
                btnAddNew.Visible = false;
            }
            txtInsured.Focus();
            if (App_Access == AccessType.NotAssigned || App_Access == AccessType.View_Only)
                btnAddNew.Visible = false;
        }
    }
    #endregion

    #region "Controls Events"
    /// <summary>
    /// Search button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // get the search value from the controls entered by the user
        GetSearchValues();

        //redirect to List page which will perform search procedure
        if (clsGeneral.IsNull(Request.QueryString["a"]))
            Response.Redirect("COIList.aspx");
        else
            Response.Redirect("COIList.aspx?a=1");
    }
    // button Add Click Event
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        //open COI page in add mode
        Response.Redirect("COIAddEdit.aspx");
    }
    #endregion

    #region "Methods"
    /// <summary>
    /// Binds Dropdown for State
    /// </summary>
    private void BindDropdowns()
    {
        //Bind State Dropdown list
        DataTable dtStates = COI_State.SelectAll().Tables[0];
        drpState.DataSource = dtStates;
        drpState.DataTextField = "FLD_state";
        drpState.DataValueField = "PK_Id";
        drpState.DataBind();
        drpState.Items.Insert(0, "--Select--");

        ComboHelper.FillLocationdbaList(new ListBox[] { lstLocationCode }, 0);
        ComboHelper.FillLocationdbaOnlyListBox(new ListBox[] { lstLocationDBA }, 0, false,false);
        lstLocationDBA.Style.Remove("font-size");
    }

    /// <summary>
    /// Stores the user entered value in session that can be used in next page for searching
    /// </summary>
    private void GetSearchValues()
    {
        //create datatable for storing all values
        DataTable dtCOISearch = new DataTable();

        //add columns for each value in data table
        DataColumn dcInsured = new DataColumn("strInsuredName");
        dcInsured.DataType = Type.GetType("System.String");
        dtCOISearch.Columns.Add(dcInsured);

        DataColumn dcAddress = new DataColumn("strAddress");
        dcAddress.DataType = Type.GetType("System.String");
        dtCOISearch.Columns.Add(dcAddress);

        DataColumn dcCity = new DataColumn("strCity");
        dcCity.DataType = Type.GetType("System.String");
        dtCOISearch.Columns.Add(dcCity);

        DataColumn dcState = new DataColumn("intState");
        dcState.DataType = Type.GetType("System.Int32");
        dtCOISearch.Columns.Add(dcState);

        DataColumn dcIssueDateFrom = new DataColumn("dtIssueDateFrom");
        dcIssueDateFrom.DataType = Type.GetType("System.DateTime");
        dtCOISearch.Columns.Add(dcIssueDateFrom);

        DataColumn dcIssueDateTo = new DataColumn("dtIssueDateTo");
        dcIssueDateTo.DataType = Type.GetType("System.DateTime");
        dtCOISearch.Columns.Add(dcIssueDateTo);

        DataColumn dcLocationNum = new DataColumn("strLocationNum");
        dcLocationNum.DataType = Type.GetType("System.String");
        dtCOISearch.Columns.Add(dcLocationNum);

        DataColumn dcGeneralPolicy = new DataColumn("strGeneralPolicyNum");
        dcGeneralPolicy.DataType = Type.GetType("System.String");
        dtCOISearch.Columns.Add(dcGeneralPolicy);

        DataColumn dcAutoPolicy = new DataColumn("strAutoPolicyNum");
        dcAutoPolicy.DataType = Type.GetType("System.String");
        dtCOISearch.Columns.Add(dcAutoPolicy);

        DataColumn dcExcessPolicy = new DataColumn("strExcessPolicyNum");
        dcExcessPolicy.DataType = Type.GetType("System.String");
        dtCOISearch.Columns.Add(dcExcessPolicy);

        DataColumn dcWCPolicy = new DataColumn("strWCPolicyNum");
        dcWCPolicy.DataType = Type.GetType("System.String");
        dtCOISearch.Columns.Add(dcWCPolicy);

        DataColumn dcPropertyPolicy = new DataColumn("strPropertyPolicyNum");
        dcPropertyPolicy.DataType = Type.GetType("System.String");
        dtCOISearch.Columns.Add(dcPropertyPolicy);

        DataColumn dcLocationdba = new DataColumn("strLocationdba");
        dcLocationdba.DataType = Type.GetType("System.String");
        dtCOISearch.Columns.Add(dcLocationdba);

        DataColumn dcLocationCode = new DataColumn("strLocationCode");
        dcLocationCode.DataType = Type.GetType("System.String");
        dtCOISearch.Columns.Add(dcLocationCode);

        // add a row in data table
        DataRow drCOISearch = dtCOISearch.NewRow();

        // store values in each column from the page controls
        drCOISearch["strInsuredName"] = txtInsured.Text.Trim().Replace("'", "");
        drCOISearch["strAddress"] = txtAddress.Text.Trim().Replace("'", "");
        drCOISearch["strCity"] = txtCity.Text.Trim().Replace("'", "");
        drCOISearch["intState"] = (drpState.SelectedIndex == 0) ? 0 : Convert.ToInt32(drpState.SelectedValue);
        if (txtIssueDateFrom.Text != String.Empty)
            drCOISearch["dtIssueDateFrom"] = Convert.ToDateTime(txtIssueDateFrom.Text);
        if (txtIssueDateTo.Text != String.Empty)
            drCOISearch["dtIssueDateTo"] = Convert.ToDateTime(txtIssueDateTo.Text);    
        drCOISearch["strGeneralPolicyNum"] = txtGenPolicyNumber.Text.Trim().Replace("'", "");
        drCOISearch["strAutoPolicyNum"] = txtAutoPolicyNumber.Text.Trim().Replace("'", "");
        drCOISearch["strExcessPolicyNum"] = txtExcessPolicyNumber.Text.Trim().Replace("'", "");
        drCOISearch["strWCPolicyNum"] = txtWCPolicyNumber.Text.Trim().Replace("'", "");
        drCOISearch["strPropertyPolicyNum"] = txtPropertyPolicyNumber.Text.Trim().Replace("'", "");
        drCOISearch["strLocationCode"] = GetCommaSeparatedValues(lstLocationCode);
        drCOISearch["strLocationdba"] = GetCommaSeparatedValues(lstLocationDBA);

        dtCOISearch.Rows.Add(drCOISearch);

        //store the whole data table in a session
        Session["dtCOISearch"] = dtCOISearch;
    }

    /// <summary>
    /// Get Comma Separated values
    /// </summary>
    /// <param name="lst"></param>
    /// <returns></returns>
    private string GetCommaSeparatedValues(ListBox lst)
    {
        string strRegion = string.Empty;
        foreach (ListItem itmRegion in lst.Items)
        {
            if (itmRegion.Selected)
                strRegion = strRegion + itmRegion.Value + ",";
        }
        strRegion = strRegion.TrimEnd(',');
        return strRegion;
    }

    #endregion
}
