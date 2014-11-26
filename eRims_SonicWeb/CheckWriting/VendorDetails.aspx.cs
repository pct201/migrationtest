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
public partial class VendorDetails : System.Web.UI.Page
{
    #region Private Variables
    int m_intVendorDetailsId = 0;
    int m_intRetval = -1;
    public int m_intPreventAdd = 0;
    public RIMS_Base.Biz.CVendor m_objVendorDetails;
    List<RIMS_Base.CVendor> lstVendorDetails = null;
    public RIMS_Base.Biz.CVendor m_objVendorType;
    List<RIMS_Base.CVendor> lstVendorType = null;
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
    public string m_strFolderName = "Vendor";
    public string m_strCustomFileName = string.Empty;
    public string m_strFileName = string.Empty;
    public string m_strGlobalPath = string.Empty;
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //if (fvVendorDetails.CurrentMode != FormViewMode.ReadOnly)
            //{
            //    PostBackTrigger pt = new PostBackTrigger();
            //    pt.ControlID = ((Button)fvVendorDetails.FindControl("btnAddAttachment")).ClientID;
            //    UpdatePanelTriggerCollection n = new UpdatePanelTriggerCollection();

            //    pnlVendorDetail.Triggers.Insert(0, pt);
            //}

            m_strGlobalPath = Page.ResolveUrl(ConfigurationManager.AppSettings["UploadPath"] + "/Vendor/");
            dvSearch.Visible = true;
            dvAttachDetails.Visible = false;
            if (!IsPostBack)
            {
                btnDelete.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvVendorDetails','Delete');");
                btnRemove.Attributes.Add("onclick", "return OMSCheckSelected1('chkItem','gvAttachmentDetails','Delete');");
                if (SetUserRights() == true)
                {
                    mvVendorDetails.ActiveViewIndex = 0;

                    gvVendorDetails.PageSize = 10;

                    gvVendorDetails.DataSource = BindVendorDetails();
                    gvVendorDetails.DataBind();

                    ddlPage.DataBind();
                    ddlPage.SelectedValue = "10";
                    lblPageInfo.Text = "Page 1 of " + gvVendorDetails.PageCount.ToString();
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
                lstRightDetails = m_objRightDetails.GetRights(17, Convert.ToInt32(Session["UserRoleId"].ToString()));
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
                gvVendorDetails.PageIndex = 0;
                txtPageNo.Text = "1";
            }
            else if (Convert.ToInt32(txtPageNo.Text) > gvVendorDetails.PageCount)
            {
                gvVendorDetails.PageIndex = gvVendorDetails.PageCount;
                txtPageNo.Text = gvVendorDetails.PageCount.ToString();
            }
            else
            {
                gvVendorDetails.PageIndex = Convert.ToInt32(txtPageNo.Text) - 1;
            }
            lblPageInfo.Text = "Page " + txtPageNo.Text.ToString() + " of " + gvVendorDetails.PageCount.ToString();
            gvVendorDetails.DataSource = BindVendorDetails();
            gvVendorDetails.DataBind();
            lblVendorDetailsTotal.Text = "Total Vendor Details:" + lstVendorDetails.Count.ToString();

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
            if (gvVendorDetails.PageIndex <= gvVendorDetails.PageCount)
            {
                gvVendorDetails.PageIndex = gvVendorDetails.PageIndex + 1;
                GeneralSorting();
                //gvVendorDetails.DataSource = BindVendorDetails();
                //gvVendorDetails.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvVendorDetails.PageIndex + 1) + " of " + gvVendorDetails.PageCount.ToString();
                lblVendorDetailsTotal.Text = "Total Vendor Details:" + lstVendorDetails.Count.ToString();
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
            if (gvVendorDetails.PageIndex <= gvVendorDetails.PageCount)
            {
                gvVendorDetails.PageIndex = gvVendorDetails.PageIndex - 1;
                GeneralSorting();
                //gvVendorDetails.DataSource = BindVendorDetails();
                //gvVendorDetails.DataBind();
                lblPageInfo.Text = "Page " + Convert.ToString(gvVendorDetails.PageIndex + 1) + " of " + gvVendorDetails.PageCount.ToString();
                lblVendorDetailsTotal.Text = "Total Vendor Details:" + lstVendorDetails.Count.ToString();
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
            m_objVendorDetails = new RIMS_Base.Biz.CVendor();
            m_intRetval = m_objVendorDetails.DeleteVendor(Request.Form["chkItem"].ToString());
            if (m_intRetval <= 0)
            {
                mvVendorDetails.ActiveViewIndex = 0;
                gvVendorDetails.DataSource = BindVendorDetails();
                gvVendorDetails.DataBind();
            }
            lblVendorDetailsTotal.Text = "Total Vendor Details:" + lstVendorDetails.Count.ToString();
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
            mvVendorDetails.ActiveViewIndex = 1;
            Bindfv(FormViewMode.Insert);
            btnRemove.Visible = false;
            btnMail.Visible = false;
            //((Button)fvBankDetails.FindControl("btnSave")).Attributes.Add("onclick", "return Test();");
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
            m_objVendorDetails = new RIMS_Base.Biz.CVendor();
            lstVendorDetails = new List<RIMS_Base.CVendor>();
            lstVendorDetails = m_objVendorDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            gvVendorDetails.DataSource = lstVendorDetails;
            gvVendorDetails.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvVendorDetails.PageCount.ToString();
            lblVendorDetailsTotal.Text = "Total Vendor Details:" + lstVendorDetails.Count.ToString();
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
                m_objVendorDetails = new RIMS_Base.Biz.CVendor();
                if (fvVendorDetails.CurrentMode == FormViewMode.Insert)
                {
                    m_objVendorDetails.PK_Vendor_ID = 0;
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "lblMsg", "var a=document.getElementById('" + lblMessage.ClientID + "');a.innerText=String.format('Duplicate {0} corrective action found, please correct it.','" + txtLocale.Text + "');alert(a.innerText);", true);
                }
                else
                {
                    m_objVendorDetails.PK_Vendor_ID = Convert.ToInt32(((Label)fvVendorDetails.FindControl("lblVendorDetailsId")).Text);
                }
                m_objVendorDetails.Vendor_Tax_Id = ((TextBox)fvVendorDetails.FindControl("txtTaxIdNo")).Text;
                m_objVendorDetails.Vendor_Name = ((TextBox)fvVendorDetails.FindControl("txtVendorName")).Text.Replace("'", "''");
                m_objVendorDetails.Address_1 = ((TextBox)fvVendorDetails.FindControl("txtAddress1")).Text;
                m_objVendorDetails.Address_2 = ((TextBox)fvVendorDetails.FindControl("txtAddress2")).Text;
                m_objVendorDetails.State = ((DropDownList)fvVendorDetails.FindControl("ddlState")).SelectedValue;
                m_objVendorDetails.City = ((TextBox)fvVendorDetails.FindControl("txtCity")).Text;
                m_objVendorDetails.Phone = ((TextBox)fvVendorDetails.FindControl("txtPhone")).Text;
                m_objVendorDetails.Vendor_Type = ((DropDownList)fvVendorDetails.FindControl("ddlType")).SelectedItem.Text;
                m_objVendorDetails.Zip_Code = ((TextBox)fvVendorDetails.FindControl("txtZip")).Text;
                m_objVendorDetails.Facsimile = ((TextBox)fvVendorDetails.FindControl("txtFaxNo")).Text;
                m_objVendorDetails.Updated_By = Session["UserID"].ToString();
                m_objVendorDetails.Update_Date = System.DateTime.Now.Date;
                m_intRetval = m_objVendorDetails.InsertUpdateVendor(m_objVendorDetails);
                if (m_intRetval >= 0)
                {
                    mvVendorDetails.ActiveViewIndex = 0;
                    gvVendorDetails.DataSource = BindVendorDetails();
                    gvVendorDetails.DataBind();
                }

            }
            else
            {
                ViewState["PreventAdd"] = "N";
                mvVendorDetails.ActiveViewIndex = 0;
                gvVendorDetails.DataSource = BindVendorDetails();
                gvVendorDetails.DataBind();
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

            mvVendorDetails.ActiveViewIndex = 0;
            gvVendorDetails.DataSource = BindVendorDetails();
            gvVendorDetails.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void gvVendorDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "Sort")
            {
                dvSearch.Visible = false;
                mvVendorDetails.ActiveViewIndex = 1;
                m_intVendorDetailsId = Convert.ToInt32(e.CommandArgument.ToString());
            }
            if (e.CommandName == "EditItem")
            {
                dvSearch.Visible = false;
                Bindfv(FormViewMode.Edit);
                //((GridView)fvVendorDetails.FindControl("gvAttachmentDetails")).DataSource = BindAttachmentDetails();
                //((GridView)fvVendorDetails.FindControl("gvAttachmentDetails")).DataBind();
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
                //((GridView)fvVendorDetails.FindControl("gvAttachmentDetails")).DataSource = BindAttachmentDetails();
                //((GridView)fvVendorDetails.FindControl("gvAttachmentDetails")).DataBind();
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
    protected void gvVendorDetails_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            lstVendorDetails = new List<RIMS_Base.CVendor>();
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

            lstVendorDetails = BindVendorDetails();
            if (ViewState["SortExp"] != null)
                lstVendorDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CVendor>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
            gvVendorDetails.DataSource = lstVendorDetails;
            gvVendorDetails.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void fvVendorDetails_DataBound(object sender, EventArgs e)
    {
        try
        {
            if (fvVendorDetails.CurrentMode != FormViewMode.ReadOnly)
            {

                ((DropDownList)fvVendorDetails.FindControl("ddlState")).DataSource = GetState();
                ((DropDownList)fvVendorDetails.FindControl("ddlState")).DataTextField = "FLD_state";
                ((DropDownList)fvVendorDetails.FindControl("ddlState")).DataValueField = "FLD_abbreviation";
                ((DropDownList)fvVendorDetails.FindControl("ddlState")).DataBind();
                m_lstCommon = new ListItem("--Select State--", "0");
                ((DropDownList)fvVendorDetails.FindControl("ddlState")).Items.Insert(0, m_lstCommon);
                //((DropDownList)fvVendorDetails.FindControl("ddlState")).Items.Insert(0, "--Select State--");

                ((DropDownList)fvVendorDetails.FindControl("ddlType")).DataSource = GetVendorType();
                ((DropDownList)fvVendorDetails.FindControl("ddlType")).DataTextField = "FLD_Desc";
                ((DropDownList)fvVendorDetails.FindControl("ddlType")).DataValueField = "FLD_Desc";
                ((DropDownList)fvVendorDetails.FindControl("ddlType")).DataBind();
                m_lstCommon = new ListItem("--Select Vendor Type--", "0");
                ((DropDownList)fvVendorDetails.FindControl("ddlType")).Items.Insert(0, m_lstCommon);
                //((DropDownList)fvVendorDetails.FindControl("ddlType")).Items.Insert(0, "--Select Vendor Type--");

                ((DropDownList)fvVendorDetails.FindControl("ddlAttachType")).DataSource = GetAttachmentType();
                ((DropDownList)fvVendorDetails.FindControl("ddlAttachType")).DataTextField = "FLD_Desc";
                ((DropDownList)fvVendorDetails.FindControl("ddlAttachType")).DataValueField = "FLD_Code";
                ((DropDownList)fvVendorDetails.FindControl("ddlAttachType")).DataBind();
                ((DropDownList)fvVendorDetails.FindControl("ddlAttachType")).SelectedIndex = 0;
                //m_lstCommon = new ListItem("--Select Attachment Type--", "0");
                //((DropDownList)fvVendorDetails.FindControl("ddlAttachType")).Items.Insert(0, m_lstCommon);


            }

            if (fvVendorDetails.CurrentMode == FormViewMode.Edit)
            {
                ((DropDownList)fvVendorDetails.FindControl("ddlState")).SelectedValue = lstVendorDetails[0].State.ToString();
                ((DropDownList)fvVendorDetails.FindControl("ddlType")).SelectedValue = lstVendorDetails[0].Vendor_Type.ToString();
            }
            if (fvVendorDetails.CurrentMode == FormViewMode.ReadOnly)
            {
                gvAttachmentDetails.Columns[0].Visible = false;
            }
            else
            {
                gvAttachmentDetails.Columns[0].Visible = true;
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
            gvVendorDetails.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            gvVendorDetails.DataSource = BindVendorDetails();
            gvVendorDetails.DataBind();
            lblPageInfo.Text = "Page 1 of " + gvVendorDetails.PageCount.ToString();
            txtPageNo.Text = "1";
            lblVendorDetailsTotal.Text = "Total Vendor Details:" + lstVendorDetails.Count.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        dvSearch.Visible = false;
        if (fvVendorDetails.CurrentMode == FormViewMode.Insert)
        {
            if (ViewState["PreventAdd"].ToString() == "N")
            {
                m_objVendorDetails = new RIMS_Base.Biz.CVendor();
                if (fvVendorDetails.CurrentMode == FormViewMode.Insert)
                {
                    m_objVendorDetails.PK_Vendor_ID = 0;
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "lblMsg", "var a=document.getElementById('" + lblMessage.ClientID + "');a.innerText=String.format('Duplicate {0} corrective action found, please correct it.','" + txtLocale.Text + "');alert(a.innerText);", true);
                }
                else
                {
                    m_objVendorDetails.PK_Vendor_ID = Convert.ToInt32(((Label)fvVendorDetails.FindControl("lblVendorDetailsId")).Text);
                }
                m_objVendorDetails.Vendor_Tax_Id = ((TextBox)fvVendorDetails.FindControl("txtTaxIdNo")).Text;
                m_objVendorDetails.Vendor_Name = ((TextBox)fvVendorDetails.FindControl("txtVendorName")).Text;
                m_objVendorDetails.Address_1 = ((TextBox)fvVendorDetails.FindControl("txtAddress1")).Text;
                m_objVendorDetails.Address_2 = ((TextBox)fvVendorDetails.FindControl("txtAddress2")).Text;
                m_objVendorDetails.State = ((DropDownList)fvVendorDetails.FindControl("ddlState")).SelectedValue;
                m_objVendorDetails.City = ((TextBox)fvVendorDetails.FindControl("txtCity")).Text;
                m_objVendorDetails.Phone = ((TextBox)fvVendorDetails.FindControl("txtPhone")).Text;
                m_objVendorDetails.Vendor_Type = ((DropDownList)fvVendorDetails.FindControl("ddlType")).SelectedItem.Text;
                m_objVendorDetails.Zip_Code = ((TextBox)fvVendorDetails.FindControl("txtZip")).Text;
                m_objVendorDetails.Facsimile = ((TextBox)fvVendorDetails.FindControl("txtFaxNo")).Text;
                m_objVendorDetails.Updated_By = Session["UserID"].ToString();
                m_objVendorDetails.Update_Date = System.DateTime.Now.Date;
                m_intRetval = m_objVendorDetails.InsertUpdateVendor(m_objVendorDetails);
                ((Label)fvVendorDetails.FindControl("lblVendorDetailsId")).Text = m_intRetval.ToString();
                ViewState["PreventAdd"] = "Y";
            }
            if (m_intRetval >= 0 || ViewState["PreventAdd"].ToString() == "Y")
            {
                dvAttachDetails.Visible = true;

                AddAttachment();
                if (m_intRetval >= 0)
                {
                    //((GridView)fvVendorDetails.FindControl("gvAttachmentDetails")).DataSource = BindAttachmentDetails();
                    //((GridView)fvVendorDetails.FindControl("gvAttachmentDetails")).DataBind();
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
                //((GridView)fvVendorDetails.FindControl("gvAttachmentDetails")).DataSource = BindAttachmentDetails();
                //((GridView)fvVendorDetails.FindControl("gvAttachmentDetails")).DataBind();
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
                //((ImageButton)e.Row.FindControl("imgbtnMail")).Attributes.Add("onclick", "javascript:return openMailWindow('../ErimsMail.aspx?AttMod=Vendor&AttName=" + ((ImageButton)e.Row.FindControl("imgbtnMail")).CommandArgument.ToString() + "');");
            }
            //if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            //{
            //    gvAttachmentDetails.EmptyDataText = "Yash";
            //}
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
            dvSearch.Visible = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvVendorDetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
            else
            {
                Image sortImage = new Image();
                sortImage.ImageUrl = "~/Images/up-arrow.gif";
                sortImage.AlternateText = "Descending Order";
                e.Row.Cells[1].Controls.Add(sortImage);
            }
        }
    }
    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in gvVendorDetails.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = gvVendorDetails.Columns.IndexOf(field);
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
    private List<RIMS_Base.CVendor> BindVendorDetails()
    {
        try
        {
            m_objVendorDetails = new RIMS_Base.Biz.CVendor();
            lstVendorDetails = new List<RIMS_Base.CVendor>();
            lstVendorDetails = null;
            if (txtSearch.Text != string.Empty)
            {
                lstVendorDetails = m_objVendorDetails.Get_Search_Data(ddlSearch.SelectedValue, txtSearch.Text.Trim());
            }
            else
            {
                lstVendorDetails = m_objVendorDetails.GetAll();
            }
            lblVendorDetailsTotal.Text = "Total Vendor Details:" + lstVendorDetails.Count.ToString();
            return lstVendorDetails;
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
            lstAttachment = m_objAttachment.GetAll(0, Convert.ToInt32(((Label)fvVendorDetails.FindControl("lblVendorDetailsId")).Text), "Vendor");
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
    /// Get All Vendor Type.
    /// </summary>
    private List<RIMS_Base.CVendor> GetVendorType()
    {
        try
        {
            m_objVendorType = new RIMS_Base.Biz.CVendor();
            lstVendorType = new List<RIMS_Base.CVendor>();
            lstVendorType = m_objVendorType.GetAllVendorType();
            return lstVendorType;
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
                fvVendorDetails.ChangeMode(FormViewMode.Insert);
            else if (fvMode == FormViewMode.Edit)
                fvVendorDetails.ChangeMode(FormViewMode.Edit);
            else if (fvMode == FormViewMode.ReadOnly)
                fvVendorDetails.ChangeMode(FormViewMode.ReadOnly);
            if (fvMode != FormViewMode.Insert)
            {
                dvAttachDetails.Visible = true;
                m_objVendorDetails = new RIMS_Base.Biz.CVendor();
                lstVendorDetails = new List<RIMS_Base.CVendor>();
                lstVendorDetails = m_objVendorDetails.GetorByID(m_intVendorDetailsId);
                fvVendorDetails.DataSource = lstVendorDetails;
            }
            fvVendorDetails.DataBind();
            //((Button)fvVendorDetails.FindControl("btnSave")).Attributes.Add("onclick","return Temp("+((RequiredFieldValidator)fvVendorDetails.FindControl("rfvAttachType")).ClientID+");");
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

            //((FileUpload)fvVendorDetails.FindControl("uplCommon")).fi
            m_strPath = Server.MapPath(ConfigurationManager.AppSettings["UploadPath"]);

            if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName)))
            {
                Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName);
            }
            //if (!(Directory.Exists(m_strPath + "\\" + m_strFolderName + "\\Photos")))
            //{
            //    Directory.CreateDirectory(m_strPath + "\\" + m_strFolderName + "\\Photos");
            //}
            m_strFileName = GetCustomFileName() + ((FileUpload)fvVendorDetails.FindControl("uplCommon")).FileName.ToString();
            //m_strPath = m_strPath + "\\" + m_strFolderName + "\\Photos\\" + ufFile.GetName().ToString();
            m_strPath = m_strPath + "\\" + m_strFolderName + "\\" + m_strFileName;

            //m_strFileName = ufFile.GetName().ToString();
            ((FileUpload)fvVendorDetails.FindControl("uplCommon")).SaveAs(m_strPath);


        }
        catch (Exception ex)
        {
            //Log.Append("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:" + ex.Message);
            //Common.reportError("Error in UploadPhotoImages Method of ConditionAssessment's PhotoGraphs:", ex.Message);
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
            //Log.Append("Error in GetCustomFileName Method of ConditionAssessment's PhotoGraph:" + ex.Message);
            //Common.reportError("Error in GetCustomFileName Method of ConditionAssessment's PhotoGraph:", ex.Message);
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
            m_objAttachment.Attachment_Table = "Vendor";
            m_objAttachment.Foreign_Key = Convert.ToInt32(((Label)fvVendorDetails.FindControl("lblVendorDetailsId")).Text);
            m_objAttachment.FK_Attachment_Type = Convert.ToInt32(((DropDownList)fvVendorDetails.FindControl("ddlAttachType")).SelectedValue);
            m_objAttachment.Attachment_Description = ((TextBox)fvVendorDetails.FindControl("txtDescription")).Text;
            m_objAttachment.Attachment_Name = m_strFileName;
            m_objAttachment.Updated_By = Session["UserID"].ToString();
            m_objAttachment.Update_Date = System.DateTime.Now.Date;
            m_intRetval = m_objAttachment.InsertUpdateAttachment(m_objAttachment);
            ((TextBox)fvVendorDetails.FindControl("txtDescription")).Text = string.Empty;
            ((DropDownList)fvVendorDetails.FindControl("ddlAttachType")).SelectedValue = "1";

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
            lstVendorDetails = new List<RIMS_Base.CVendor>();
            lstVendorDetails = BindVendorDetails();
            if (ViewState["SortExp"] != null && ViewState["sortDirection"] != null)
            {
                lstVendorDetails.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CVendor>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
                strSortExp = ViewState["SortExp"].ToString();
            }

            gvVendorDetails.DataSource = lstVendorDetails;
            gvVendorDetails.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    #endregion






    protected void gvVendorDetails_RowDataBound(object sender, GridViewRowEventArgs e)
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
}
