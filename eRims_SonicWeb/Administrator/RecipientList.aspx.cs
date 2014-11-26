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

public partial class Administrator_RecipientList : clsBasePage
{
    #region Properties

    public decimal RecipientListID
    {
        get { return ((this.ViewState["RecipientListID"] != null) ? Convert.ToDecimal(this.ViewState["RecipientListID"]) : -1); }
        set { this.ViewState["RecipientListID"] = value; }
    }

    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (UserAccessType != AccessType.Full_Access)
        //    Response.Redirect("../Search/NoRights.aspx", false);

        lblMessage.Text = "";
        if (!IsPostBack)
        {
            mvRecipientList.ActiveViewIndex = 0;
            FillRecipinetListGrid();
        }
    }

    protected void gvRecipientList_Sorted(object sender, EventArgs e)
    {

    }

    protected void gvRecipientList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            RecipientListID = Convert.ToDecimal(gvRecipientList.DataKeys[e.NewEditIndex].Value);
            this.mvRecipientList.ActiveViewIndex = 1;
            LoadRecipientListRecord();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvRecipientList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Tatva_RecipientList.DeleteByPK(Convert.ToDecimal(gvRecipientList.DataKeys[e.RowIndex].Value));
            FillRecipinetListGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gvRecipientList_Sorting(object sender, GridViewSortEventArgs e)
    {
        //FillRecipinetListGrid();
        gvRecipientList.Sort(e.SortExpression, e.SortDirection);
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.mvRecipientList.ActiveViewIndex = 1;
        RecipientListID = -1;
        this.txtListName.Text = "";
        FillRecipinetGrid();
    }

    protected void Save_Click(object sender, EventArgs e)
    {

        try
        {
            Tatva_RecipientList objRecipientList = new Tatva_RecipientList();
            if (!objRecipientList.CheckListNameExist(txtListName.Text.Trim(), RecipientListID))
            {
                objRecipientList.Pk_RecipientList_ID = RecipientListID;
                objRecipientList.ListName = this.txtListName.Text.Trim();
                objRecipientList.Updated_By = Session["UserName"].ToString();
                objRecipientList.Update_Date = System.DateTime.Now.Date;
                RecipientListID = objRecipientList.InsertUpdate();

                mvRecipientList.ActiveViewIndex = 0;
                Tatva_RecipientListMatrix.DeleteByFK_RecipientList(RecipientListID);
                SaveRecipientList();
                Response.Redirect("RecipientList.aspx", false);
            }
            else
            {
                lblMessage.Text = "Recipient List Name already exist. Please specify different List Name.";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("RecipientList.aspx", false);
    }

    #endregion

    #region Methods

    private void LoadRecipientListRecord()
    {

        Tatva_RecipientList objRecipientList = new Tatva_RecipientList(RecipientListID);
        this.txtListName.Text = objRecipientList.ListName;
        FillRecipinetGrid();
    }

    private void FillRecipinetListGrid()
    {

        try
        {
            DataSet dsRecipinetList = new DataSet();
            dsRecipinetList = Tatva_RecipientList.SelectAll();
            gvRecipientList.DataSource = dsRecipinetList.Tables[0];
            gvRecipientList.DataBind();

            dsRecipinetList.Dispose();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillRecipinetGrid()
    {

        try
        {
            DataSet dsRecipient = new DataSet();
            dsRecipient = Tatva_RecipientListMatrix.SelectAllRecordWithRecipientList(RecipientListID);

            gvRecipients.DataSource = dsRecipient.Tables[0];
            gvRecipients.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void SaveRecipientList()
    {
        Tatva_RecipientListMatrix objRecipientListMatrix = new Tatva_RecipientListMatrix();

        foreach (GridViewRow gvrRecipeint in gvRecipients.Rows)
        {
            if (((CheckBox)gvrRecipeint.FindControl("chkSelect")).Checked)
            {
                objRecipientListMatrix.FK_RecipientList = RecipientListID;
                objRecipientListMatrix.FK_Recipient = Convert.ToDecimal(gvRecipients.DataKeys[gvrRecipeint.RowIndex].Value);
                objRecipientListMatrix.Updated_By = Session["UserName"].ToString();
                objRecipientListMatrix.Updated_Date = System.DateTime.Now.Date;
                objRecipientListMatrix.Insert();
            }
        }
    }

    #endregion
}
