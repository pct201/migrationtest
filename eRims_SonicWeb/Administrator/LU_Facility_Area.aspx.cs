using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_LU_Facility_Area : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Facility_Area
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Facility_Area"]);
        }
        set { ViewState["PK_LU_Facility_Area"] = value; }
    }

    #endregion

    #region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid();
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
        PK_LU_Facility_Area = 0;
        trStatusAdd.Style.Add("display", "");
        lnkCancel.Style.Add("display", "");
        txtFacilityArea.Text = "";
        
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtFacilityArea);
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
        txtFacilityArea.Text = "";
        
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        clsLU_Facility_Area objLU_Facility_Area = new clsLU_Facility_Area();
        objLU_Facility_Area.Description = txtFacilityArea.Text.Trim();
        objLU_Facility_Area.PK_LU_Facility_Area = PK_LU_Facility_Area;
        

        if (PK_LU_Facility_Area > 0)
        {
            _retVal = objLU_Facility_Area.Update();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Facility Area that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtFacilityArea);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Facility_Area.Insert();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Facility Area that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtFacilityArea);
                return;
            }
            PK_LU_Facility_Area = _retVal;
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

    protected void gvFacility_Area_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvFacility_Area.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvFacility_Area_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Facility_Area = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            clsLU_Facility_Area objclsLU_Facility_Area = new clsLU_Facility_Area(PK_LU_Facility_Area);
            txtFacilityArea.Text = Convert.ToString(objclsLU_Facility_Area.Description);
            
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtFacilityArea);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind CRM Brand Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = clsLU_Facility_Area.SelectAll();
        //Apply Dataset to Grid
        gvFacility_Area.DataSource = dsGroup;
        gvFacility_Area.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Facility_Area = 0;
    }

    #endregion
}