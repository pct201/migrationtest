using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;


public partial class Administrator_LU_Facility_Specific_Location : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_Facility_Specific_Location
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Facility_Specific_Location"]);
        }
        set { ViewState["PK_LU_Facility_Specific_Location"] = value; }
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
            //Bind Grid Function
            BindGrid();
            Bindddl();
        }
    }

    #endregion

    #region "Event"

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        _PK_LU_Facility_Specific_Location = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        ddlFK_LU_Facility_Area.SelectedIndex = -1;
        txtDescription.Text = "";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(ddlFK_LU_Facility_Area);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trStatusAdd.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        txtDescription.Text = "";
        ddlFK_LU_Facility_Area.SelectedIndex = -1;
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        clsLU_Facility_Specific_Location objLU_Facility_Specific_Location = new clsLU_Facility_Specific_Location();
        objLU_Facility_Specific_Location.Description = txtDescription.Text.Trim();
        objLU_Facility_Specific_Location.PK_LU_Facility_Specific_Location = _PK_LU_Facility_Specific_Location;
        
        if(ddlFK_LU_Facility_Area.SelectedIndex > -1)
            objLU_Facility_Specific_Location.FK_LU_Facility_Area = Convert.ToDecimal(ddlFK_LU_Facility_Area.SelectedValue);


        if (_PK_LU_Facility_Specific_Location > 0)
        {
            _retVal = objLU_Facility_Specific_Location.Update();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Facility Area and Description that you are trying to add already exists in the LU_Facility_Specific_Location table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Facility_Specific_Location.Insert();
            // Used to Check Duplicate Media ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Facility Area and Description that you are trying to add already exists in the LU_Facility_Specific_Location table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
                return;
            }
            _PK_LU_Facility_Specific_Location = _retVal;
        }
        //claer Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion

    #region "Grid Event"
    /// <summary>
    /// Page Index Change Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLU_Facility_Specific_Location_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLU_Facility_Specific_Location.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    /// <summary>
    /// Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLU_Facility_Specific_Location_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_Facility_Specific_Location = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database

            clsLU_Facility_Specific_Location objLU_Facility_Specific_Location = new clsLU_Facility_Specific_Location(_PK_LU_Facility_Specific_Location);
            txtDescription.Text = objLU_Facility_Specific_Location.Description.ToString();
            if (objLU_Facility_Specific_Location.FK_LU_Facility_Area != null)
                ddlFK_LU_Facility_Area.SelectedValue =  Convert.ToString(objLU_Facility_Specific_Location.FK_LU_Facility_Area);
            else
                ddlFK_LU_Facility_Area.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDescription);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind CRM Department Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsLU_Facility_Specific_Location = clsLU_Facility_Specific_Location.SelectAll();
        //Apply Dataset to Grid
        gvLU_Facility_Specific_Location.DataSource = dsLU_Facility_Specific_Location;
        gvLU_Facility_Specific_Location.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_Facility_Specific_Location = 0;
    }

    //Bind Dropdown
    private void Bindddl()
    {
        ddlFK_LU_Facility_Area.Items.Clear();
        DataSet ds = clsLU_Facility_Area.SelectAll();
        ddlFK_LU_Facility_Area.DataSource = ds.Tables[0];
        ddlFK_LU_Facility_Area.DataTextField = "Description";
        ddlFK_LU_Facility_Area.DataValueField = "PK_LU_Facility_Area";
        ddlFK_LU_Facility_Area.DataBind();
        ddlFK_LU_Facility_Area.Items.Insert(0, "--SELECT--");
    }


    #endregion
}