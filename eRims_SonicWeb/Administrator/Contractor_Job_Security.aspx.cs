using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Data.SqlClient;

public partial class Administrator_Contractor_Job_Security : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Contractor_Job_Security
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Contractor_Job_Security"]);
        }
        set { ViewState["PK_Contractor_Job_Security"] = value; }
    }

    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal FK_Contractor_Security
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Contractor_Security"]);
        }
        set { ViewState["FK_Contractor_Security"] = value; }
    }

    /// <summary>
    /// Denotes the Operation (Edit/view)
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    #endregion

    # region "Page Events"
    /// <summary>
    /// Handles Page Load Event
    /// </summary>    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PK_Contractor_Job_Security = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_Contractor_Security = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            //used to fill RM Location Number Dropdown
            //ComboHelper.FillLocationdba(new DropDownList[] { ddlLocation }, 0, true, true);
            //ComboHelper.FillProjectNumberFromLocation(new DropDownList[] { ddlProjectNumber }, Convert.ToInt32(ddlLocation.SelectedValue), true);
            //Bind Region Dropdown
            FillProjectsListBox(new ListBox[] { lstProjects }, false);
            FillLocationListBox(new ListBox[] { lstLocations }, false);

            //fill project number from location 

            // if (PK_Contractor_Job_Security > 0)
            //{
            if (Request.QueryString["op"] != null)
            {
                StrOperation = Request.QueryString["op"];
            }
            else
                StrOperation = "edit";

            if (StrOperation == "view")
            {
                dvView.Style["display"] = "inline";
                dvEdit.Style["display"] = "none";
                btnSave.Visible = false;
                btnEdit.Visible = true;
                BindDetailsForView();
            }
            else
            {
                BindDetailsForEdit();
                dvView.Style["display"] = "none";
                dvEdit.Style["display"] = "inline";
                btnSave.Visible = true;
                btnEdit.Visible = false;
            }
            //}
            //else
            //{
            //    // don't show div for view mode
            //    dvView.Style["display"] = "none";
            //    dvEdit.Style["display"] = "inline";
            //    btnEdit.Visible = false;
            //    btnSave.Visible = true;
            //    btnAuditTrail.Visible = false;
            //}


        }
    }

    #endregion

    #region "Events"

    /// <summary>
    /// Handles Back Button click Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        //if (StrOperation == "view")
        //    Response.Redirect("Contractor_Security.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_Contractor_Security)));
        //else
        Response.Redirect("Contractor_Security.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_Contractor_Security)));
    }

    /// <summary>
    /// Handles Edit Button click Event -Edit Contractor Job Security Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // if (PK_Contractor_Job_Security > 0)
        Response.Redirect("Contractor_Job_Security.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_Contractor_Job_Security)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_Contractor_Security)));
    }

    /// <summary>
    /// Handles Save Button click Event -Save Contractor Job Security Information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnBack.Visible = true;
        btnSave.Visible = true;
        btnEdit.Visible = false;

        Contractor_Job_Security objContractor_Job_Security = new Contractor_Job_Security(PK_Contractor_Job_Security);
        decimal _retval;
        //if (rdoProject_Location.SelectedValue=="Projects")
        if (chkBoxProject.Checked)
        {
            if (lstProjects.GetSelectedIndices().Length > 0)
            {
                foreach (ListItem objLstProjects in lstProjects.Items)
                {
                    if (objLstProjects.Selected == true)
                    {
                        //adding Region Value to database
                        objContractor_Job_Security.PK_Contractor_Job_Security = PK_Contractor_Job_Security;
                        objContractor_Job_Security.FK_Contractor_Security = FK_Contractor_Security;
                        //objContractor_Job_Security.FK_Facility_Construction_Project = Convert.ToInt32(ddlProjectNumber.SelectedValue);
                        objContractor_Job_Security.FK_Facility_Construction_Project = Convert.ToDecimal(objLstProjects.Value.ToString());
                        objContractor_Job_Security.Access = rdoProjectAccess.SelectedValue;
                        objContractor_Job_Security.Updated_By = clsSession.UserID;
                        objContractor_Job_Security.Update_Date = DateTime.Now;
                        if (PK_Contractor_Job_Security > 0)
                        {
                            _retval = objContractor_Job_Security.Update();
                        }
                        else
                        {
                            _retval = objContractor_Job_Security.Insert();
                            // PK_Contractor_Job_Security = _retval;
                        }
                    }
                }
            }
        }
        if(chkBoxLocation.Checked)
        {
            objContractor_Job_Security = new Contractor_Job_Security(PK_Contractor_Job_Security);
            if (lstLocations.GetSelectedIndices().Length>0)
            {
                foreach (ListItem objLstLocations in lstLocations.Items)
                {
                    if (objLstLocations.Selected == true)
                    {
                        //adding Region Value to database
                        objContractor_Job_Security.PK_Contractor_Job_Security = PK_Contractor_Job_Security;
                        objContractor_Job_Security.FK_Contractor_Security = FK_Contractor_Security;
                        //objContractor_Job_Security.FK_Facility_Construction_Project = Convert.ToInt32(ddlProjectNumber.SelectedValue);
                        objContractor_Job_Security.FK_LU_Location_ID = Convert.ToDecimal(objLstLocations.Value.ToString());
                        objContractor_Job_Security.Access = rdoLocationAccess.SelectedValue;
                        objContractor_Job_Security.Updated_By = clsSession.UserID;
                        objContractor_Job_Security.Update_Date = DateTime.Now;
                        if (PK_Contractor_Job_Security > 0)
                        {
                            _retval = objContractor_Job_Security.Update();
                        }
                        else
                        {
                            _retval = objContractor_Job_Security.Insert();
                            // PK_Contractor_Job_Security = _retval;
                        }
                    }
                }
            }
        }
            if (PK_Contractor_Job_Security > 0)
            {
                //_retval = objContractor_Job_Security.Update();
                //if (_retval == -2)
                //{
                //    //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The selected Utility Type and Sonic Location Code already exist in the Utility Provider table');ShowPanel(1);", true);
                //    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('This Project Details Record Exists.');", true);
                //}
                //else
                //{
                //Response.Redirect("Contractor_Job_Security.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_Contractor_Job_Security)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_Contractor_Security)));
                //BindDetailsForView();
                Response.Redirect("Contractor_Security.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_Contractor_Security)));
                //}
            }
            else
            {
                //_retval = objContractor_Job_Security.Insert();
                //if (_retval == -2)
                //{
                //    //Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The selected Contractor Job Security already exist in the Contractor Job Security');", true);
                //    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('This Project Details Record Exists.');", true);
                //}
                //else
                //{
                //PK_Contractor_Job_Security = _retval;
                //Response.Redirect("Contractor_Job_Security.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_Contractor_Job_Security)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_Contractor_Security)));
                //BindDetailsForView();
                Response.Redirect("Contractor_Security.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_Contractor_Security)));

                //}
            }
        }   

    //  /// <summary>
    //  /// Handles Location Selected Change Event 
    //  /// </summary>
    //  /// <param name="sender"></param>
    //  /// <param name="e"></param>
    //  protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    //  {
    //      //fill project number from location 
    //      ComboHelper.FillProjectNumberFromLocation(new DropDownList[] { ddlProjectNumber }, Convert.ToInt32(ddlLocation.SelectedValue), true);
    //  }

    // /// <summary>
    // /// Handles Project Number Selected Change Event 
    // /// </summary>
    // /// <param name="sender"></param>
    // /// <param name="e"></param>
    // protected void ddlProjectNumber_SelectedIndexChanged(object sender, EventArgs e)
    // {
    //DataTable dtpn = Contractor_Job_Security.SelectByProjectNoFacility_construction_Project(Convert.ToInt32(ddlProjectNumber.SelectedValue)).Tables[0];
    //     if (dtpn.Rows.Count > 0)
    //     {
    //         DataRow drProjectNo = dtpn.Rows[0];
    //         txtProject_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(drProjectNo["Estimated_Start_Date"]);
    //         CtrlMultiLineLabelProject_Description.Text = Convert.ToString(drProjectNo["Project_Description"]);
    //     }
    // }
    #endregion

    #region Methods

    /// <summary>
    /// Binds Page Controls for Edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnBack.Visible = true;
        btnSave.Visible = false;
        btnEdit.Visible = true;
        //BindDropdown();
        Contractor_Job_Security objContractor_Job_Security = new Contractor_Job_Security(PK_Contractor_Job_Security);
        //ComboHelper.FillProjectNumberFromLocation(new DropDownList[] { ddlProjectNumber }, Convert.ToInt32(objContractor_Job_Security.LU_Location_ID), true);
        //ddlLocation.SelectedValue = Convert.ToString(objContractor_Job_Security.LU_Location_ID);
        //ddlProjectNumber.SelectedValue = Convert.ToString(objContractor_Job_Security.FK_Facility_Construction_Project);
        //txtProject_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objContractor_Job_Security.Estimated_Start_Date);
        //CtrlMultiLineLabelProject_Description.Text = objContractor_Job_Security.Project_Description;
        //if (objContractor_Job_Security.Access == "Read Only")
        //    rdoAccess.SelectedValue = "R";
        //else if (objContractor_Job_Security.Access == "Read/Write")
        //    rdoAccess.SelectedValue = "RW";

    }
    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnSave.Visible = false;
        btnBack.Visible = true;
        btnEdit.Visible = true;
        lblError.Visible = false;
        Contractor_Job_Security objContractor_Job_Security = new Contractor_Job_Security(PK_Contractor_Job_Security);

        //lblLocation.Text = Convert.ToString(objContractor_Job_Security.Locationdba);
        //lblProject_Number.Text = Convert.ToString(objContractor_Job_Security.Project_Number);
        //lblProject_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objContractor_Job_Security.Estimated_Start_Date);
        //lblProject_Description.Text = objContractor_Job_Security.Project_Description;

        DataSet dsProjects = Contractor_Job_Security.SelectByFKContactorSecurity(Convert.ToInt32(FK_Contractor_Security), "Title", "");
        string ProjectsName = string.Empty;
        if (dsProjects.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drProjects in dsProjects.Tables[0].Rows)
            {
                ProjectsName += drProjects["Project_Numberlbl"].ToString() + ",";
            }
        }
        lblProject_Number.Text = ProjectsName.ToString().TrimEnd(Convert.ToChar(","));

        //if (objContractor_Job_Security.Access == "Read Only")
        //    lblAccess.Text = "Read Only";
        //else if (objContractor_Job_Security.Access == "Read/Write")
        //    lblAccess.Text = "Read/Write";
        //else { lblAccess.Text = ""; }
    }

    /// <summary>
    /// Bind List Projects
    /// </summary>
    public void FillProjectsListBox(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Contractor_Job_Security.SelectByProjectNotAccess(FK_Contractor_Security);
        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "Project_Number";
            lstToFill.DataValueField = "PK_Facility_construction_Project";
            lstToFill.DataSource = dsData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            //lstToFill.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
    }

    public void FillLocationListBox(ListBox[] LstBox, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.Contractor_Job_Security.SelectByLocationNotAccess(FK_Contractor_Security);
        foreach (ListBox lstToFill in LstBox)
        {
            lstToFill.Items.Clear();
            lstToFill.DataTextField = "dba";
            lstToFill.DataValueField = "PK_LU_Location_ID";
            lstToFill.DataSource = dsData;
            lstToFill.DataBind();
            //check require to add "-- select --" at first item of dropdown.
            //lstToFill.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
    }


    #endregion

}