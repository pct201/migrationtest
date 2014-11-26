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
using System.IO;
using RIMS_Base.Biz;
public partial class Employee_Claimant : System.Web.UI.Page
{
    #region Private Variables
    int m_intClaimantDetailsId = 0;
    int m_intRetval = -1;
    public int m_intPreventAdd = 0;
    public RIMS_Base.Biz.CClaimant m_objClaimantDetails;
    List<RIMS_Base.CClaimant> lstClaimantDetails = null;
    List<RIMS_Base.CClaimant> lstautoClaimantID = null;
    public RIMS_Base.Biz.CRolePermission m_objRightDetails;
    List<RIMS_Base.CRolePermission> lstRightDetails = null;
    public RIMS_Base.Biz.CGeneral m_objAttachmentType;
    List<RIMS_Base.CGeneral> lstAttachmentType = null;
    public RIMS_Base.Biz.CGeneral m_objState;
    List<RIMS_Base.CGeneral> lstState = null;
    public RIMS_Base.Biz.CAttachment m_objAttachment;
    List<RIMS_Base.CAttachment> lstAttachment = null;
    ListItem m_lstCommon;
    string strSortExp = string.Empty;

    public string m_strPath = string.Empty;
    public string m_strFolderName = "Claimant";
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/Claimant/");
            dvSearch.Visible = true;
            dvAttachDetails.Visible = false;
            if (!IsPostBack)
            {
                if (SetUserRights() == true)
                {
                    ddlSearch.Attributes.Add("onmouseover", "javascript:getValue();");
                    //BindTooltip();
                    btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvClaimantDetails','Delete');");
                    btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");
                    mvClaimantDetails.ActiveViewIndex = 0;

                    gvClaimantDetails.PageSize = 10;
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                    gvClaimantDetails.DataSource = BindClaimantDetails();
                    gvClaimantDetails.DataBind();

                    ddlPage.DataBind();
                    ddlPage.SelectedValue = "10";
                    lblPageInfo.Text = "Page 1 of " + gvClaimantDetails.PageCount.ToString();
                    txtPageNo.Text = "1";
                    ViewState["PreventAdd"] = "N";

                  
                }
            }
         


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected bool SetUserRights()
    {
        try
        {

            m_objRightDetails = new CRolePermission();
            if (Session["UserRoleId"] != null)
            {
                lstRightDetails = m_objRightDetails.GetRights(26, Convert.ToInt32(Session["UserRoleId"].ToString()));
                ViewState["Add"] = lstRightDetails[0].PAdd.ToString();
                ViewState["Edit"] = lstRightDetails[0].PEdit.ToString();
                ViewState["Delete"] = lstRightDetails[0].PDelete.ToString();
                ViewState["View"] = lstRightDetails[0].PView.ToString();
                if (ViewState["Add"].ToString() == "True")
                {
                    btnAddNew.Enabled = true;
                }
                else
                {
                    btnAddNew.Enabled = false;
                }
                if (ViewState["Delete"].ToString() == "True")
                {
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                }
                return true;
            }
            else
            {
                Response.Redirect("../Signin.aspx", false);
                return false;
            }

        }
        catch (Exception ex)
        {
            throw;
        }

    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtPageNo.Text.ToString().Trim() == string.Empty || Convert.ToInt32(txtPageNo.Text) < 1)
            {
                gvClaimantDetails.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvClaimantDetails.PageCount)
            {
                gvClaimantDetails.PageIndex = gvClaimantDetails.PageCount;
                txtPageNo.Text = gvClaimantDetails.PageCount.ToString();
            }
            else
            {
                gvClaimantDetails.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvClaimantDetails.PageCount.ToString();
            gvClaimantDetails.DataSource = BindClaimantDetails();
            gvClaimantDetails.DataBind();
            lblClaimantTotal.Text = "Total Claimant Details:" + lstClaimantDetails.Count.ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvClaimantDetails.PageIndex <= gvClaimantDetails.PageCount)
            {
                gvClaimantDetails.PageIndex = gvClaimantDetails.PageIndex + 1;
                GeneralSorting();

                lblPageInfo.Text = "Page " + Convert.ToString(gvClaimantDetails.PageIndex + 1) + " of " + gvClaimantDetails.PageCount.ToString();
                lblClaimantTotal.Text = "Total Claimant Details:" + lstClaimantDetails.Count.ToString();
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvClaimantDetails.PageIndex <= gvClaimantDetails.PageCount)
            {
                gvClaimantDetails.PageIndex = gvClaimantDetails.PageIndex - 1;
                GeneralSorting();
                lblPageInfo.Text = "Page " + Convert.ToString(gvClaimantDetails.PageIndex + 1) + " of " + gvClaimantDetails.PageCount.ToString();
                lblClaimantTotal.Text = "Total Claimant Details:" + lstClaimantDetails.Count.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            m_objClaimantDetails = new RIMS_Base.Biz.CClaimant();
            m_intRetval = m_objClaimantDetails.DeleteClaimant(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                mvClaimantDetails.ActiveViewIndex = 0;
                gvClaimantDetails.DataSource = BindClaimantDetails();
                gvClaimantDetails.DataBind();
            }
            lblClaimantTotal.Text = "Total Claimant Details:" + lstClaimantDetails.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        try
        {
            dvSearch.Visible = false;
            mvClaimantDetails.ActiveViewIndex = 1;
            Bindfv(FormViewMode.Insert);

            //m_objClaimantDetails = new RIMS_Base.Biz.CClaimant();
            //lstautoClaimantID = new List<RIMS_Base.CClaimant>();

            //lstautoClaimantID = m_objClaimantDetails.GetClaimantAutopopulate();
            //((TextBox)fvClaimantDetails.FindControl("txtClaimantId")).Text = lstautoClaimantID[0].Claimant_Id;

            
            btnRemove.Visible = false;
            btnMail.Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            m_objClaimantDetails = new RIMS_Base.Biz.CClaimant();
            lstClaimantDetails = new List<RIMS_Base.CClaimant>();
            lstClaimantDetails = m_objClaimantDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            gvClaimantDetails.DataSource = lstClaimantDetails;
            gvClaimantDetails.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvClaimantDetails.PageCount.ToString();
            lblClaimantTotal.Text = "Total Claimant Details:" + lstClaimantDetails.Count.ToString();
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
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objClaimantDetails = new RIMS_Base.Biz.CClaimant();
                if (fvClaimantDetails.CurrentMode == FormViewMode.Insert)
                {
                    m_objClaimantDetails.PK_Claimant_Id = 0;
                }
                else
                {
                    m_objClaimantDetails.PK_Claimant_Id = Convert.ToInt32(((Label)fvClaimantDetails.FindControl("lblClaimantDetailsId")).Text);
                }
                m_objClaimantDetails.First_Name = ((TextBox)fvClaimantDetails.FindControl("txtFirstName")).Text.Replace("'", "''");
                m_objClaimantDetails.Last_Name = ((TextBox)fvClaimantDetails.FindControl("txtLastName")).Text.Replace("'", "''");
                m_objClaimantDetails.Claimant_Address_1 = ((TextBox)fvClaimantDetails.FindControl("txtAddress1")).Text.Replace("'", "''");
                m_objClaimantDetails.Claimant_Address_2 = ((TextBox)fvClaimantDetails.FindControl("txtAddress2")).Text.Replace("'", "''");
                m_objClaimantDetails.Claimant_State = ((DropDownList)fvClaimantDetails.FindControl("ddlState")).SelectedValue;
                m_objClaimantDetails.Claimant_City = ((TextBox)fvClaimantDetails.FindControl("txtCity")).Text.Replace("'", "''");
                m_objClaimantDetails.Claimant_Cell_Phone = ((TextBox)fvClaimantDetails.FindControl("txtCellPhone")).Text;
                m_objClaimantDetails.Drivers_License_State = ((DropDownList)fvClaimantDetails.FindControl("ddlDriverState")).SelectedItem.Text;
                m_objClaimantDetails.Claimant_Zip_Code = ((TextBox)fvClaimantDetails.FindControl("txtZip")).Text;
                m_objClaimantDetails.Claimant_Home_Phone = ((TextBox)fvClaimantDetails.FindControl("txtHomePhone")).Text;
                m_objClaimantDetails.Claimant_Id = ((TextBox)fvClaimantDetails.FindControl("txtClaimantId")).Text;
                m_objClaimantDetails.Middle_Name = ((TextBox)fvClaimantDetails.FindControl("txtMiddleName")).Text.Replace("'", "''");
                m_objClaimantDetails.Drivers_License_Number = ((TextBox)fvClaimantDetails.FindControl("txtDriverLicenseNumber")).Text;
                m_objClaimantDetails.Social_Security_Number = RIMS_Base.Biz.CGeneral.Encrypt(((TextBox)fvClaimantDetails.FindControl("txtSSN")).Text, true);
                if (((TextBox)fvClaimantDetails.FindControl("txtDOB")).Text != string.Empty)
                    m_objClaimantDetails.Date_Of_Birth = Convert.ToDateTime(((TextBox)fvClaimantDetails.FindControl("txtDOB")).Text);
                m_objClaimantDetails.Updated_By = Session["UserID"].ToString();
                m_objClaimantDetails.Update_Date = System.DateTime.Now.Date;
                m_intRetval = m_objClaimantDetails.InsertUpdateClaimant(m_objClaimantDetails);
                if (m_intRetval >= 0)
                {
                    mvClaimantDetails.ActiveViewIndex = 0;
                    gvClaimantDetails.DataSource = BindClaimantDetails();
                    gvClaimantDetails.DataBind();
                }

            }
            else
            {
                ViewState["PreventAdd"] = "N";
                mvClaimantDetails.ActiveViewIndex = 0;
                gvClaimantDetails.DataSource = BindClaimantDetails();
                gvClaimantDetails.DataBind();
            }
            dvSearch.Visible = true;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {

            mvClaimantDetails.ActiveViewIndex = 0;
            gvClaimantDetails.DataSource = BindClaimantDetails();
            gvClaimantDetails.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvClaimantDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ViewState["Edit"].ToString() == "True")
            {
                ((Button)(e.Row.FindControl("btnEdit"))).Enabled = true;
            }
            else
            {
                ((Button)(e.Row.FindControl("btnEdit"))).Enabled = false;
            }
            if (ViewState["View"].ToString() == "True")
            {
                ((Button)(e.Row.FindControl("btnView"))).Enabled = true;
            }
            else
            {
                ((Button)(e.Row.FindControl("btnView"))).Enabled = false;
            }
        }
    }
    protected void gvClaimantDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort")
            {
                dvSearch.Visible = false;
                mvClaimantDetails.ActiveViewIndex = 1;
                m_intClaimantDetailsId = Convert.ToInt32(e.CommandArgument.ToString());
            }
            if (e.CommandName == "EditItem")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.Edit);
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }

            }
            else if (e.CommandName == "View")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.ReadOnly);
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                btnRemove.Visible = false;
                btnMail.Visible = false;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvClaimantDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstClaimantDetails = new List<RIMS_Base.CClaimant>();
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;
            // Changes the sort direction 
            else
            {
                if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                    ViewState["sortDirection"] = SortDirection.Descending;
                else
                    ViewState["sortDirection"] = SortDirection.Ascending;
            }
            ViewState["SortExp"] = strSortExp = e.SortExpression;

            lstClaimantDetails = BindClaimantDetails();
            if (ViewState["SortExp"] != null)
                lstClaimantDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CClaimant>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvClaimantDetails.DataSource = lstClaimantDetails;
            gvClaimantDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void fvClaimantDetails_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (fvClaimantDetails.CurrentMode != FormViewMode.ReadOnly)
            {
                ((TextBox)fvClaimantDetails.FindControl("txtCurrentDate")).Text = DateTime.Now.ToShortDateString();
                ((DropDownList)fvClaimantDetails.FindControl("ddlState")).DataSource = GetState();
                ((DropDownList)fvClaimantDetails.FindControl("ddlState")).DataTextField = "FLD_state";
                ((DropDownList)fvClaimantDetails.FindControl("ddlState")).DataValueField = "FLD_abbreviation";
                ((DropDownList)fvClaimantDetails.FindControl("ddlState")).DataBind();
                m_lstCommon = new ListItem("--Select State--", "0");
                ((DropDownList)fvClaimantDetails.FindControl("ddlState")).Items.Insert(0, m_lstCommon);


                ((DropDownList)fvClaimantDetails.FindControl("ddlDriverState")).DataSource = GetState();
                ((DropDownList)fvClaimantDetails.FindControl("ddlDriverState")).DataTextField = "FLD_state";
                ((DropDownList)fvClaimantDetails.FindControl("ddlDriverState")).DataValueField = "FLD_abbreviation";
                ((DropDownList)fvClaimantDetails.FindControl("ddlDriverState")).DataBind();
                m_lstCommon = new ListItem("--Select State--", "0");
                ((DropDownList)fvClaimantDetails.FindControl("ddlDriverState")).Items.Insert(0, m_lstCommon);


                ((DropDownList)fvClaimantDetails.FindControl("ddlAttachType")).DataSource = GetAttachmentType();
                ((DropDownList)fvClaimantDetails.FindControl("ddlAttachType")).DataTextField = "FLD_Desc";
                ((DropDownList)fvClaimantDetails.FindControl("ddlAttachType")).DataValueField = "FLD_Code";
                ((DropDownList)fvClaimantDetails.FindControl("ddlAttachType")).DataBind();
                m_lstCommon = new ListItem("--Select Attachment Type--", "0");
                ((DropDownList)fvClaimantDetails.FindControl("ddlAttachType")).Items.Insert(0, m_lstCommon);
                ((DropDownList)fvClaimantDetails.FindControl("ddlAttachType")).SelectedValue = "1";



            }

            if (fvClaimantDetails.CurrentMode == FormViewMode.Edit)
            {
                ((DropDownList)fvClaimantDetails.FindControl("ddlState")).SelectedValue = lstClaimantDetails[0].Claimant_State.ToString();
                ((DropDownList)fvClaimantDetails.FindControl("ddlDriverState")).SelectedItem.Text = lstClaimantDetails[0].Drivers_License_State.ToString();
            }
            if (fvClaimantDetails.CurrentMode == FormViewMode.ReadOnly)
            {
                gvAttachmentDetails.Columns[0].Visible = false;
            }
            else
            {
                gvAttachmentDetails.Columns[0].Visible = true;
            }

            if (fvClaimantDetails.CurrentMode == FormViewMode.ReadOnly)
            {
                ((Label)fvClaimantDetails.FindControl("lblSSN")).Text = RIMS_Base.Biz.CGeneral.Decrypt(lstClaimantDetails[0].Social_Security_Number, true);
            }
            if (fvClaimantDetails.CurrentMode == FormViewMode.Edit)
            {
                ((TextBox)fvClaimantDetails.FindControl("txtSSN")).Text = RIMS_Base.Biz.CGeneral.Decrypt(lstClaimantDetails[0].Social_Security_Number, true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvClaimantDetails.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvClaimantDetails.DataSource = BindClaimantDetails();
            gvClaimantDetails.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvClaimantDetails.PageCount.ToString();
            txtPageNo.Text = "1";
            lblClaimantTotal.Text = "Total Claimant Details:" + lstClaimantDetails.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        dvSearch.Visible = false;
        if (fvClaimantDetails.CurrentMode == FormViewMode.Insert)
        {
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objClaimantDetails = new RIMS_Base.Biz.CClaimant();
                if (fvClaimantDetails.CurrentMode == FormViewMode.Insert)
                {
                    m_objClaimantDetails.PK_Claimant_Id = 0;
                }
                else
                {
                    m_objClaimantDetails.PK_Claimant_Id = Convert.ToInt32(((Label)fvClaimantDetails.FindControl("lblClaimantDetailsId")).Text);
                }
                m_objClaimantDetails.First_Name = ((TextBox)fvClaimantDetails.FindControl("txtFirstName")).Text;
                m_objClaimantDetails.Last_Name = ((TextBox)fvClaimantDetails.FindControl("txtLastName")).Text;
                m_objClaimantDetails.Claimant_Address_1 = ((TextBox)fvClaimantDetails.FindControl("txtAddress1")).Text;
                m_objClaimantDetails.Claimant_Address_2 = ((TextBox)fvClaimantDetails.FindControl("txtAddress2")).Text;
                m_objClaimantDetails.Claimant_State = ((DropDownList)fvClaimantDetails.FindControl("ddlState")).SelectedValue;
                m_objClaimantDetails.Claimant_City = ((TextBox)fvClaimantDetails.FindControl("txtCity")).Text;
                m_objClaimantDetails.Claimant_Cell_Phone = ((TextBox)fvClaimantDetails.FindControl("txtCellPhone")).Text;
                m_objClaimantDetails.Drivers_License_State = ((DropDownList)fvClaimantDetails.FindControl("ddlDriverState")).SelectedItem.Text;
                m_objClaimantDetails.Claimant_Zip_Code = ((TextBox)fvClaimantDetails.FindControl("txtZip")).Text;
                m_objClaimantDetails.Claimant_Home_Phone = ((TextBox)fvClaimantDetails.FindControl("txtHomePhone")).Text;
                m_objClaimantDetails.Claimant_Id = ((TextBox)fvClaimantDetails.FindControl("txtClaimantId")).Text;
                m_objClaimantDetails.Middle_Name = ((TextBox)fvClaimantDetails.FindControl("txtMiddleName")).Text;
                m_objClaimantDetails.Drivers_License_Number = ((TextBox)fvClaimantDetails.FindControl("txtDriverLicenseNumber")).Text;
                m_objClaimantDetails.Social_Security_Number = RIMS_Base.Biz.CGeneral.Encrypt(((TextBox)fvClaimantDetails.FindControl("txtSSN")).Text, true);
                m_objClaimantDetails.Date_Of_Birth = Convert.ToDateTime(((TextBox)fvClaimantDetails.FindControl("txtDOB")).Text);
                m_objClaimantDetails.Updated_By = Session["UserID"].ToString();
                m_objClaimantDetails.Update_Date = System.DateTime.Now.Date;
                m_intRetval = m_objClaimantDetails.InsertUpdateClaimant(m_objClaimantDetails);
                ((Label)fvClaimantDetails.FindControl("lblClaimantDetailsId")).Text = m_intRetval.ToString();
                ViewState["PreventAdd"] = "Y";
            }
            if (m_intRetval >= 0 || ViewState["PreventAdd"].ToString() == "Y")
            {
                dvAttachDetails.Visible = true;

                AddAttachment();
                if (m_intRetval >= 0)
                {
                    gvAttachmentDetails.DataSource = BindAttachmentDetails();
                    gvAttachmentDetails.DataBind();
                    if (lstAttachment.Count > 0)
                    {
                        btnRemove.Visible = true;
                        btnMail.Visible = true;
                    }
                    else
                    {
                        btnRemove.Visible = false;
                        btnMail.Visible = false;
                    }
                }
            }
        }
        else
        {
            dvAttachDetails.Visible = true;
            AddAttachment();
            if (m_intRetval >= 0)
            {
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }

            }

        }



    }
    protected void gvAttachmentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgbtnDwnld")).Attributes.Add("onclick", "javascript:return openWindow('" + m_strGlobalPath + ((ImageButton)e.Row.FindControl("imgbtnDwnld")).CommandArgument.ToString() + "');");
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Claimant&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_intRetval = m_objAttachment.DeleteAttachment(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                gvAttachmentDetails.DataSource = BindAttachmentDetails();
                gvAttachmentDetails.DataBind();
                if (lstAttachment.Count > 0)
                {
                    btnRemove.Visible = true;
                    btnMail.Visible = true;
                }
                else
                {
                    btnRemove.Visible = false;
                    btnMail.Visible = false;
                }
            }
            dvAttachDetails.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvClaimantDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
        }
    }
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvClaimantDetails.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvClaimantDetails.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 iCol = GetSortColumnIndex(strSortExp);
        if (-1 == iCol)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();

        if (SortDirection.Ascending.ToString() == ViewState["sortDirection"].ToString())
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }
    #endregion
    #region Private Methods
    /// <summary>
    /// Get the All Vendor's Details
    /// </summary>
    private List<RIMS_Base.CClaimant> BindClaimantDetails()
    {
        try
        {
            m_objClaimantDetails = new RIMS_Base.Biz.CClaimant();
            lstClaimantDetails = new List<RIMS_Base.CClaimant>();
            lstClaimantDetails = null;
            if (txtSearch.Text != string.Empty)
            {
                lstClaimantDetails = m_objClaimantDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            }
            else
            {
                lstClaimantDetails = m_objClaimantDetails.GetAll();
            }
            lblClaimantTotal.Text = "Total Claimant Details:" + lstClaimantDetails.Count.ToString();
            return lstClaimantDetails;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    /// <summary>
    /// Bind The Attachment Details.
    /// </summary>
    /// <returns></returns>
    private List<RIMS_Base.CAttachment> BindAttachmentDetails()
    {
        try
        {
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            lstAttachment = new List<RIMS_Base.CAttachment>();
            lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(((Label)fvClaimantDetails.FindControl("lblClaimantDetailsId")).Text), "Claimant");
            return lstAttachment;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    /// <summary>
    /// Get All State.
    /// </summary>
    private List<RIMS_Base.CGeneral> GetState()
    {
        try
        {
            m_objState = new RIMS_Base.Biz.CGeneral();
            lstState = new List<RIMS_Base.CGeneral>();
            lstState = m_objState.GetAllState();
            return lstState;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    /// <summary>
    /// Get All Attachment Type.
    /// </summary>
    private List<RIMS_Base.CGeneral> GetAttachmentType()
    {
        try
        {
            m_objAttachmentType = new RIMS_Base.Biz.CGeneral();
            lstAttachmentType = new List<RIMS_Base.CGeneral>();
            lstAttachmentType = m_objAttachmentType.GetAttachamentType();
            return lstAttachmentType;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }
    /// <summary>
    /// Bind the Formview Templates.
    /// </summary>
    /// <param name="fvMode"></param>
    private void Bindfv(FormViewMode fvMode)
    {
        try
        {

            if (fvMode == FormViewMode.Insert)
                fvClaimantDetails.ChangeMode(FormViewMode.Insert);
            else if (fvMode == FormViewMode.Edit)
                fvClaimantDetails.ChangeMode(FormViewMode.Edit);
            else if (fvMode == FormViewMode.ReadOnly)
                fvClaimantDetails.ChangeMode(FormViewMode.ReadOnly);
            if (fvMode != FormViewMode.Insert)
            {
                dvAttachDetails.Visible = true;
                m_objClaimantDetails = new RIMS_Base.Biz.CClaimant();
                lstClaimantDetails = new List<RIMS_Base.CClaimant>();
                lstClaimantDetails = m_objClaimantDetails.GetClaimantByID(m_intClaimantDetailsId);
                fvClaimantDetails.DataSource = lstClaimantDetails;

            }
            fvClaimantDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
        }

    }
    /// <summary>
    /// Upload Documents
    /// </summary>
    private void UploadDocuments()
    {
        try
        {
            m_strPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"]);

            if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName)))
            {
                Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName);
            }
            m_strFileName = GetCustomFileName() + ((FileUpload)fvClaimantDetails.FindControl("uplCommon")).FileName.ToString();
            m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;
            ((FileUpload)fvClaimantDetails.FindControl("uplCommon")).SaveAs(m_strPath);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Get Custom File Name.
    /// </summary>
    /// <returns></returns>
    private string GetCustomFileName()
    {
        try
        {
            m_strCustomFileName = System.DateTime.Now.ToString("MMddyyhhmmss");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_strCustomFileName;
    }
    /// <summary>
    /// Insert Attachment in Database.
    /// </summary>
    /// <returns>Integer</returns>
    private int AddAttachment()
    {
        try
        {
            UploadDocuments();
            m_objAttachment = new RIMS_Base.Biz.CAttachment();
            m_objAttachment.Attachment_Table = "Claimant";
            m_objAttachment.Foreign_Key = Convert.ToInt32(((Label)fvClaimantDetails.FindControl("lblClaimantDetailsId")).Text);
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(((DropDownList)fvClaimantDetails.FindControl("ddlAttachType")).SelectedValue);
            m_objAttachment.Attachment_Description = ((TextBox)fvClaimantDetails.FindControl("txtDescription")).Text;
            m_objAttachment.Attachment_Name = m_strFileName;
            m_objAttachment.Updated_By = Session["UserID"].ToString();
            m_objAttachment.Update_Date = System.DateTime.Now.Date;
            m_intRetval = m_objAttachment.InsertUpdateAttachment(m_objAttachment);
            ((TextBox)fvClaimantDetails.FindControl("txtDescription")).Text = string.Empty;
            ((DropDownList)fvClaimantDetails.FindControl("ddlAttachType")).SelectedValue = "1";

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_intRetval;
    }
    private void GeneralSorting()
    {
        try
        {
            lstClaimantDetails = new List<RIMS_Base.CClaimant>();
            lstClaimantDetails = BindClaimantDetails();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
                lstClaimantDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CClaimant>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvClaimantDetails.DataSource = lstClaimantDetails;
            gvClaimantDetails.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    #endregion  
}
