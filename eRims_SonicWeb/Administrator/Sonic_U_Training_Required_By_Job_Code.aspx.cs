using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Sonic_U_Training_Required_By_Job_Code : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Sonic_U_Training_Required_By_Job_Code
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Sonic_U_Training_Required_By_Job_Code"]);
        }
        set { ViewState["PK_Sonic_U_Training_Required_By_Job_Code"] = value; }
    }

    public decimal PK_LU_Job_Code
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Job_Code"]);
        }
        set { ViewState["PK_LU_Job_Code"] = value; }
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
            //Bind Training Grid Function
            BindGrid();
            //Bind Drop Down
            BindDropDown();
            drpTrainingClassSearch.Enabled = false;
            trTrainingAdd.Visible = false;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Bind Training Grid
    /// </summary>
    private void BindGrid()
    {
        decimal? FK_Code, fk_Class;

        if (drpJobCodeSearch.SelectedIndex > 0)
        {
            FK_Code = Convert.ToDecimal(drpJobCodeSearch.SelectedItem.Value);
        }
        else
        {
            FK_Code = null;
        }

        if (drpTrainingClassSearch.SelectedIndex > 0)
        {
            fk_Class = Convert.ToDecimal(drpTrainingClassSearch.SelectedItem.Value);
        }
        else
        {
            fk_Class = null;
        }

        DataSet dsTraining = Sonic_U_Training_Required_By_Job_Code.Search(FK_Code, fk_Class);
        gvTraining.DataSource = dsTraining;
        gvTraining.DataBind();
    }

    /// <summary>
    /// Bind Drop Down
    /// </summary>
    private void BindDropDown()
    {
        ComboHelper.FillJobCode_New(new DropDownList[] { drpJobCodeSearch }, true);
        ComboHelper.FillJobCode_SelectRemaining(new DropDownList[] { drpJobCode }, true);
        ComboHelper.FillTrainingClassName(new DropDownList[] { drpTrainingClassSearch }, true);
    }

    /// <summary>
    /// Used to Clear the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_Sonic_U_Training_Required_By_Job_Code = 0;
        if (drpJobCode.Items.Count > 0)
            drpJobCode.SelectedIndex = 0;
        drpJobCodeSearch.SelectedIndex = 0;
        drpTrainingClassSearch.SelectedIndex = 0;
    }

    #endregion

    #region "Event"

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {

        ComboHelper.FillJobCode_SelectRemaining(new DropDownList[] { drpJobCode }, true);

        if(drpJobCode.Items.Count == 1)
        {
            ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:alert('All Job Codes have already assigned training at least one or more, so please click on edit to make change on Job Code Class requirement.');", true);
            return;
        }
        
        
        //bind Grid 
        gvTrainingEdit.DataSource = Sonic_U_Training_Required_By_Job_Code.SelectRecords();
        gvTrainingEdit.DataBind();
        
        //ComboHelper.FillDistinctJobCode(new DropDownList[] { drpJobCode }, true);
        drpJobCodeSearch.SelectedIndex = 0;
        drpTrainingClassSearch.SelectedIndex = 0;
        trTraining.Visible = false;
        trTrainingAdd.Visible = true;
        lblJobCode.Visible = false;
        spn.Visible = true;
        drpJobCode.Visible = true;
        btnAddNew.Visible = false;
        btnSave.Text = "Save";
    }

    /// <summary>
    /// Save Button CLick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "CheckValidation();", true);

        string strInsertXML, strUpdateXML;
        strInsertXML = strUpdateXML = "<ImportXML>";

        foreach (GridViewRow gr in gvTrainingEdit.Rows)
        {
            Label lblPK_Sonic_U_Training_Required_By_Job_Code = (Label)gr.FindControl("lblPK_Sonic_U_Training_Required_By_Job_Code");
            Label lblPK_Sonic_U_Training_Classes = (Label)gr.FindControl("lblPK_Sonic_U_Training_Classes");
            DropDownList drpRequirement_Type = (DropDownList)gr.FindControl("drpRequirement_Type");
            RadioButtonList rdoActive = (RadioButtonList)gr.FindControl("rdoActive");

            if (drpJobCode.SelectedIndex > 0)
            {
                if (Convert.ToDecimal(drpRequirement_Type.SelectedItem.Value) > 0)
                {
                    //XML Insert
                    strInsertXML += "<Section><FK_LU_Training_Requirement_Type>" + Convert.ToDecimal(drpRequirement_Type.SelectedItem.Value) + "</FK_LU_Training_Requirement_Type>" +
                                     "<FK_Sonic_U_Training_Classes>" + Convert.ToDecimal(lblPK_Sonic_U_Training_Classes.Text) + "</FK_Sonic_U_Training_Classes>" +
                                     "<FK_lu_job_code>" + drpJobCode.SelectedItem.Value + "</FK_lu_job_code><Active>" + rdoActive.SelectedItem.Value + "</Active></Section>";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(lblPK_Sonic_U_Training_Required_By_Job_Code.Text))
                {
                    //XML Update
                    strUpdateXML += "<Section><PK_Sonic_U_Training_Required_By_Job_Code>" + Convert.ToDecimal(lblPK_Sonic_U_Training_Required_By_Job_Code.Text) + "</PK_Sonic_U_Training_Required_By_Job_Code>" +
                                   "<FK_LU_Training_Requirement_Type>" + Convert.ToDecimal(drpRequirement_Type.SelectedItem.Value) + "</FK_LU_Training_Requirement_Type>" +
                                   "<Active>" + rdoActive.SelectedItem.Value + "</Active>" +
                                   "</Section>";
                }
                else
                {
                    if (Convert.ToDecimal(drpRequirement_Type.SelectedItem.Value) > 0)
                    {
                        //XML Insert
                        strInsertXML += "<Section><FK_LU_Training_Requirement_Type>" + Convert.ToDecimal(drpRequirement_Type.SelectedItem.Value) + "</FK_LU_Training_Requirement_Type>" +
                                         "<FK_Sonic_U_Training_Classes>" + Convert.ToDecimal(lblPK_Sonic_U_Training_Classes.Text) + "</FK_Sonic_U_Training_Classes>" +
                                         "<FK_lu_job_code>" + PK_LU_Job_Code + "</FK_lu_job_code><Active>" + rdoActive.SelectedItem.Value + "</Active></Section>";
                    }
                }
            }
        }

        strInsertXML += "</ImportXML>";
        strUpdateXML += "</ImportXML>";

        Sonic_U_Training_Required_By_Job_Code.ImportXML(strInsertXML, strUpdateXML);

        //show hide grid
        trTraining.Visible = true;
        trTrainingAdd.Visible = false;
        btnAddNew.Visible = true;
        ClearControls();
        BindGrid();
    }

    /// <summary>
    /// Button Cancel CLick
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        trTraining.Visible = true;
        trTrainingAdd.Visible = false;
        btnAddNew.Visible = true;
        lblJobCode.Visible = false;
        spn.Visible = true;
        drpJobCode.Visible = true;
        ClearControls();
        //PK_LU_Job_Code = 0;
        BindGrid();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdoSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoSearch.SelectedItem.Value == "JobCode")
        {
            drpTrainingClassSearch.Enabled = false;
            drpJobCodeSearch.Enabled = true;
            drpTrainingClassSearch.SelectedIndex = 0;
        }
        else if (rdoSearch.SelectedItem.Value == "Class")
        {
            drpJobCodeSearch.Enabled = false;
            drpTrainingClassSearch.Enabled = true;
            drpJobCodeSearch.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// Drop Down Requirement Selected Index Changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpRequirement_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList drpRequirement_Type = (DropDownList)sender;
        GridViewRow row = (GridViewRow)drpRequirement_Type.NamingContainer;
        RadioButtonList rdoActive = (RadioButtonList)row.FindControl("rdoActive");

        if (drpRequirement_Type.SelectedIndex > 0)
        {
            rdoActive.Enabled = true;
        }
        else
        {
            rdoActive.Enabled = false;
        }
    }

    /// <summary>
    /// Drop Down Training Class Search Selected Index Changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    #endregion

    #region "Grid Events"
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTraining_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            //BindDropDown();
            string[] strArgs = e.CommandArgument.ToString().Split(':');
            string strPK_Sonic_U_Training_Required_By_Job_Code = strArgs[0];
            PK_LU_Job_Code = Convert.ToDecimal(strArgs[1]);
            string strCode = "";

            //bind TrainingEdit Grid
            DataSet dsTrainingEdit = new DataSet();
            dsTrainingEdit = Sonic_U_Training_Required_By_Job_Code.SelectByJobCode(PK_LU_Job_Code);
            DataTable dtTrainingEdit = new DataTable();
            DataTable dtCode = new DataTable();
            dtTrainingEdit = dsTrainingEdit.Tables[0];
            dtCode = dsTrainingEdit.Tables[1];

            if (dtCode != null && dtCode.Rows.Count > 0)
            {
                strCode = Convert.ToString(dsTrainingEdit.Tables[1].Rows[0]["Code"]);
            }

            gvTrainingEdit.DataSource = dtTrainingEdit;
            gvTrainingEdit.DataBind();
            trTraining.Visible = false;
            btnAddNew.Visible = false;
            trTrainingAdd.Visible = true;
            //drpJobCode.SelectedIndex = 0;
            drpJobCode.Visible = string.IsNullOrEmpty(strCode) ? true : false;
            spn.Visible = string.IsNullOrEmpty(strCode) ? true : false;
            lblJobCode.Visible = true;
            
            lblJobCode.Text = string.IsNullOrEmpty(strCode) ? "" : strCode;
            btnSave.Text = "Update";
        }
    }

    /// <summary>
    /// Page Index Change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTraining_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTraining.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }

    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTrainingEdit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrainingEdit.PageIndex = e.NewPageIndex; //Page new index call
        //bind Grid 
        gvTrainingEdit.DataSource = Sonic_U_Training_Required_By_Job_Code.SelectRecords();
        gvTrainingEdit.DataBind();
    }

    /// <summary>
    /// Grid gvTrainingEdit RowDataBound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTrainingEdit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //bind Drop downs
            DropDownList drpRequirement_Type = (e.Row.FindControl("drpRequirement_Type") as DropDownList);
            ComboHelper.FillRequirement_Type(new DropDownList[] { drpRequirement_Type }, true);
            string strRequirementType = (e.Row.FindControl("lblRequirement_Type") as Label).Text;
            clsGeneral.SetDropdownValue(drpRequirement_Type, strRequirementType, true);

            RadioButtonList rdoActive = (RadioButtonList)e.Row.FindControl("rdoActive");
            HiddenField hdnActive = (HiddenField)e.Row.FindControl("hdnActive");
            rdoActive.SelectedValue = Convert.ToString(hdnActive.Value);

            if (drpRequirement_Type.SelectedIndex > 0)
            {
                rdoActive.Enabled = true;
            }
            else
            {
                rdoActive.Enabled = false;
            }
        }
    }

    #endregion


}
