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
/// <summary>
/// By : Ravi Gupta
/// 
/// Purpose: 
/// This page is used to show Group information
/// 
/// Functionality:
///
/// 1) List all groups. Clicking on Group Name display all group Information.
/// 2) Clicking on Edit Link open a Record in Edit MOde.
/// 3) CLicking on Remove Link will remove the record.
/// 2) Clicking on Add New Record will add new Record.
/// 
/// </summary>
public partial class SONIC_Exposures_Administrator_Groups : clsBasePage
{
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_Group_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Group_ID"]);
        }
        set { ViewState["PK_Group_ID"] = value; }
    }
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Is Page Post Back
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid();
            //bind Rights
            BindAllRights();
        }
    }
    #endregion
    
    #region Methods
    /// <summary>
    /// Bind Group Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = Group.SelectAll();

        //Apply Dataset to Grid
        gvGroups.DataSource = dsGroup;
        gvGroups.DataBind();
    }

    /// <summary>
    /// Used to BInd Rights.
    /// </summary>
    private void BindAllRights()
    {
        DataSet dsRights = Right.SelectAll();
        chkRights.DataSource = dsRights;
        chkRights.DataTextField = "Right_Name";
        chkRights.DataValueField = "PK_Right_ID";
        chkRights.DataBind();
        
       
    }

    /// <summary>
    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        txtGroupName.Text = "";
        chkRights.ClearSelection();
        PK_Group_ID = 0;
    }
    #endregion

    #region Add New group
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int intRightCunt = 0;
        int intRtnGroupID;
        
        Group objGroup = new Group(PK_Group_ID);
        objGroup.PK_Group_ID = PK_Group_ID;
        objGroup.Group_Name = txtGroupName.Text;
        if (PK_Group_ID > 0)
        {
            PK_Group_ID = objGroup.Update();
            // Used to Check Duplicate User ID?
            if (PK_Group_ID == -2)
            {
                lblError.Text = "Group Name already exists.";
                //claer Control
                ClearControls();
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            PK_Group_ID = objGroup.Insert();
            // Used to Check Duplicate User ID?
            if (PK_Group_ID == -2)
            {
                lblError.Text = "Group Name already exists.";
                //claer Control
                ClearControls();
                return;
            }
        }
        //deleting values from Assoc_Right_Group table
        Assoc_Right_Group.DeleteByGroupID(PK_Group_ID);
        //Inserting values to Assoc_Right_Group table
        for (intRightCunt = 0; intRightCunt < chkRights.Items.Count; intRightCunt++)
        {
            if (chkRights.Items[intRightCunt].Selected == true)
            {
                Assoc_Right_Group objRight_Group = new Assoc_Right_Group();
                objRight_Group.FK_Group_ID = PK_Group_ID;
                objRight_Group.FK_Right_ID = Convert.ToInt32(chkRights.Items[intRightCunt].Value);
                objRight_Group.Insert();
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

    #region Grid Events
    protected void gvGroups_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //check Datarow type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton LnkRemove = (LinkButton)e.Row.FindControl("lnkRemove");
            LinkButton LnkView = (LinkButton)e.Row.FindControl("lnkView");
            LinkButton LnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            
            if (LnkRemove != null)
            {
                LnkRemove.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }
            if (LnkView != null)
            {
                LnkView.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }
            if (LnkEdit != null)
            {
                LnkEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }
        }
    }
    protected void gvGroups_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvGroups_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "View")
        {
            int intI, intJ = 0;
            int Index = Convert.ToInt32(e.CommandArgument);
            trGroupAdd.Style.Add("display", "none");
            trGroupView.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            LinkButton lnkvv = (LinkButton)gvGroups.Rows[Index].FindControl("lnkView");
            HiddenField hdnGroupID = (HiddenField)gvGroups.Rows[Index].FindControl("hdnGroupID");
            lblGroupName.Text = lnkvv.Text;
            DataSet dsRights = Right.SelectAll();
            chkRightsView.DataSource = dsRights;
            chkRightsView.DataTextField = "Right_Name";
            chkRightsView.DataValueField = "PK_Right_ID";
            chkRightsView.DataBind();
            DataSet dsGroupRight = Assoc_Right_Group.SelectByGroupID(Convert.ToInt32(hdnGroupID.Value));
            //Loop for Rights associated with selected Group from Database
            for (intI = 0; intI < dsGroupRight.Tables[0].Rows.Count; intI++)
            {
                //loop for Rights that that are Binded with CHeckboxlist
                for (intJ = 0; intJ < chkRightsView.Items.Count; intJ++)
                {
                    //used  to check the wthear the Rights in Checkbox list is equal to database value. if yes than selec that checkbox listItem else Uncheck.
                    if (chkRightsView.Items[intJ].Value.ToString() == dsGroupRight.Tables[0].Rows[intI]["FK_Right_ID"].ToString())
                    {
                        chkRightsView.Items[intJ].Selected = true;
                    }
                }
            }
        }
        //Check Command Name
        if (e.CommandName == "Remove")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            HiddenField hdnGroupID = (HiddenField)gvGroups.Rows[Index].FindControl("hdnGroupID");
            //used to check PK id. if greater than 0 than delete record
            int intGroupAssocUser = 0;
            Assoc_User_Group objAUG = new Assoc_User_Group();
            intGroupAssocUser= objAUG.GetUserAssociateWithGroup(Convert.ToInt32(hdnGroupID.Value));
            if (intGroupAssocUser > 0)
            {
                ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "alert('This group is already assigned to user(s).');", true);
            }
            else
            {
                if (Convert.ToInt32(hdnGroupID.Value) > 0)
                {
                    Group.DeleteByPK(Convert.ToInt32(hdnGroupID.Value));
                }
            }
            //Bind Grid
            BindGrid();
            trGroupAdd.Style.Add("display", "none");
            trGroupView.Style.Add("display", "none");
        }
        //Check Command Name
        if (e.CommandName == "Edit")
        {
            int intI, intJ = 0;
            int Index = Convert.ToInt32(e.CommandArgument);
            trGroupAdd.Style.Add("display", "block");
            trGroupView.Style.Add("display", "none");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            LinkButton lnkvv = (LinkButton)gvGroups.Rows[Index].FindControl("lnkView");
            HiddenField hdnGroupID = (HiddenField)gvGroups.Rows[Index].FindControl("hdnGroupID");
            PK_Group_ID = Convert.ToInt32(hdnGroupID.Value);
            txtGroupName.Text = lnkvv.Text;
            DataSet dsRights = Right.SelectAll();
            chkRights.DataSource = dsRights;
            chkRights.DataTextField = "Right_Name";
            chkRights.DataValueField = "PK_Right_ID";
            chkRights.DataBind();
            DataSet dsGroupRight = Assoc_Right_Group.SelectByGroupID(Convert.ToInt32(hdnGroupID.Value));
            //Loop for Rights associated with selected Group from Database
            for (intI = 0; intI < dsGroupRight.Tables[0].Rows.Count; intI++)
            {
                //loop for Rights that that are Binded with CHeckboxlist
                for (intJ = 0; intJ < chkRights.Items.Count; intJ++)
                {
                    //used  to check the wthear the Rights in Checkbox list is equal to database value. if yes than selec that checkbox listItem else Uncheck.
                    if (chkRights.Items[intJ].Value.ToString() == dsGroupRight.Tables[0].Rows[intI]["FK_Right_ID"].ToString())
                    {
                        chkRights.Items[intJ].Selected = true;
                    }
                }
            }
        }
    }
    #endregion

    #region Cancel Button
    /// <summary>
    /// button Cancel event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trGroupAdd.Style.Add("display", "none");
        trGroupView.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        txtGroupName.Text = "";
        chkRights.ClearSelection();
    }
    /// <summary>
    /// Add new Link click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        PK_Group_ID = 0;
        trGroupAdd.Style.Add("display", "block");
        trGroupView.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "inline");
    }
    #endregion

}
