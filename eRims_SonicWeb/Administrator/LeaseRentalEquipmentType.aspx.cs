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


public partial class Administrator_LeaseRentalEquipmentType : clsBasePage
{
    #region :Properties"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_LU_Equipment_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Equipment_Type"]);
        }
        set { ViewState["PK_LU_Equipment_Type"] = value; }
    }
    #endregion

    #region"Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Is Page Post Back
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid();
        }
    }
    #endregion

    #region "GridEvent"
    /// <summary>
    /// Lr Equipment Type row command event in view,edit,remove mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLREquipmentType_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        //Edit mode
        if (e.CommandName == "Edit")
        {

            int Index = Convert.ToInt32(e.CommandArgument);
            trLREquipmentTypeAdd.Style.Add("display", "block");
            //trLREquipmentTypeView.Style.Add("display", "none");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            Label lbldesc = (Label)gvLREquipmentType.Rows[Index].FindControl("lbldesc");

           // LinkButton lnkvv = (LinkButton)gvLREquipmentType.Rows[Index].FindControl("lnkView");
            HiddenField hdnLREquipmentID = (HiddenField)gvLREquipmentType.Rows[Index].FindControl("hdnLREquipmentID");
            PK_LU_Equipment_Type = Convert.ToInt32(hdnLREquipmentID.Value);
            txtLREquipmentType.Text = lbldesc.Text;
            txtLREquipmentType.Focus();
        }
    }
    /// <summary>
    /// LREquipment row created event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLREquipmentType_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton LnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
          
            if (LnkEdit != null)
            {
                LnkEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }
        }
    }
    protected void gvLREquipmentType_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    /// <summary>
    /// Page index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvLREquipmentType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLREquipmentType.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid(); //Bind Grid Function
    }
    #endregion

    #region "Event"
    /// <summary>
    /// Add new link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        PK_LU_Equipment_Type = 0;
        trLREquipmentTypeAdd.Style.Add("display", "block");
        //trLREquipmentTypeView.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "inline");
        txtLREquipmentType.Text = "";
        txtLREquipmentType.Focus();  
    }
    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trLREquipmentTypeAdd.Style.Add("display", "none");
        //trLREquipmentTypeView.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        txtLREquipmentType.Text = "";
    }
    /// <summary>
    /// Add button to click event save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        LU_Equipment_Type objGroup = new LU_Equipment_Type(PK_LU_Equipment_Type);
        objGroup.PK_LU_Equipment_Type = PK_LU_Equipment_Type;
        objGroup.Fld_Desc = txtLREquipmentType.Text;
        if (PK_LU_Equipment_Type > 0)
        {
           PK_LU_Equipment_Type = objGroup.Update();
            // Used to Check Duplicate User ID?
            if (PK_LU_Equipment_Type == -2)
            {
                lblError.Text = "Lease/Rental Equipment Type Name already exists.";
                //claer Control
                ClearControls();
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {            
            PK_LU_Equipment_Type = objGroup.Insert();
            // Used to Check Duplicate User ID?
            if (PK_LU_Equipment_Type == -2)
            {
                lblError.Text = "Lease/Rental Equipment Type Name already exists.";
                //claer Control
                ClearControls();
                return;
            }           
        }
        //claer Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind LREquipment Type Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_Equipment_Type.SelectAll();

        //Apply Dataset to Grid
        gvLREquipmentType.DataSource = dsGroup;
        gvLREquipmentType.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        //txtLREquipmentType.Text = "";        
        PK_LU_Equipment_Type = 0;
    }
    #endregion
   
}
