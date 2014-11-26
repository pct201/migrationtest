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

public partial class Administrator_Recipient : clsBasePage
{
    #region Properties

    public decimal RecipientID
    {
        get { return ((this.ViewState["RecipientID"] != null) ? Convert.ToDecimal(ViewState["RecipientID"]) : -1); }
        set { this.ViewState["RecipientID"] = value; }
    }

    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (UserAccessType != AccessType.Full_Access)
        //    Response.Redirect("../Search/NoRights.aspx", false);

        if (!IsPostBack)
        {
            this.mvRecipient.ActiveViewIndex = 0;
            FillRecipientGrid();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            mvRecipient.ActiveViewIndex = 1;
            RecipientID = -1;
            this.txtContactNo.Text = "";
            this.txtEmail.Text = "";
            this.txtRecipientFirstName.Text = "";
            this.txtRecipientLastName.Text = "";
            this.txtRecipientMiddleName.Text = "";

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void gvRecipient_RowEditing(object sender, GridViewEditEventArgs e)
    {

        RecipientID = Convert.ToDecimal(this.gvRecipient.DataKeys[e.NewEditIndex].Value);
        mvRecipient.ActiveViewIndex = 1;
        LoadRecipientByID();
    }

    protected void gvRecipient_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        try
        {
            Tatva_Recipient.DeleteByPK(Convert.ToDecimal(gvRecipient.DataKeys[e.RowIndex].Value));
            FillRecipientGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            this.mvRecipient.ActiveViewIndex = 0;
            Tatva_Recipient objRecipinet = new Tatva_Recipient();

            objRecipinet.PK_Recipient_ID = this.RecipientID;
            objRecipinet.FirstName = txtRecipientFirstName.Text.Trim();
            objRecipinet.LastName = txtRecipientLastName.Text.Trim();
            objRecipinet.MidleName = txtRecipientMiddleName.Text.Trim();
            objRecipinet.Phone = txtContactNo.Text.Trim();
            objRecipinet.Email = txtEmail.Text.Trim();
            objRecipinet.Updated_By = Session["UserName"].ToString();
            objRecipinet.Update_Date = System.DateTime.Now.Date;
            objRecipinet.InsertUpdate();
            Response.Redirect("Recipient.aspx", false);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btncance_Click(object sender, EventArgs e)
    {
        this.mvRecipient.ActiveViewIndex = 0;
        Response.Redirect("Recipient.aspx", false);
    }

    #endregion

    #region Methods

    private void FillRecipientGrid()
    {
        try
        {
            DataSet dsRecipient = new DataSet();
            dsRecipient = Tatva_Recipient.SelectAll();

            gvRecipient.DataSource = dsRecipient;
            gvRecipient.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadRecipientByID()
    {
        try
        {
            Tatva_Recipient objRecipient = new Tatva_Recipient(RecipientID);
            txtContactNo.Text = objRecipient.Phone;
            txtEmail.Text = objRecipient.Email;
            txtRecipientFirstName.Text = objRecipient.FirstName;
            txtRecipientLastName.Text = objRecipient.LastName;
            txtRecipientMiddleName.Text = objRecipient.MidleName;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion
}
