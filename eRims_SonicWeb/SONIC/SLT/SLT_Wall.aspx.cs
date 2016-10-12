using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.IO;

public partial class SONIC_SLT_SLT_Wall : clsBasePage
{
    #region properties

    /// <summary>
    /// Data table to store attachment
    /// </summary>
    private DataTable dtAttachments
    {
        get
        {
            if (ViewState["dtAttachments"] != null)
                return (DataTable)ViewState["dtAttachments"];
            else
                return null;
        }
        set
        {
            ViewState["dtAttachments"] = value;
        }
    }

    /// <summary>
    /// Data table to store Sub comments
    /// </summary>
    private DataTable dtComments
    {
        get
        {
            if (ViewState["dtComments"] != null)
                return (DataTable)ViewState["dtComments"];
            else
                return null;
        }
        set
        {
            ViewState["dtComments"] = value;
        }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    /// <summary>
    /// Denotes the UniqueVal whether edit or view
    /// </summary>
    public string UniqueVal
    {
        get { return Convert.ToString(ViewState["UniqueVal"]); }
        set { ViewState["UniqueVal"] = value; }
    }

    private bool IsUserInAdministrativeGroup
    {
        get { if (ViewState["UserGroup"] != null)return Convert.ToBoolean(ViewState["UserGroup"]); else return false; }
        set { ViewState["UserGroup"] = value; }
    }

    private bool IsUserRLCM
    {
        get { if (ViewState["IsUserRLCM"] != null)return Convert.ToBoolean(ViewState["IsUserRLCM"]); else return false; }
        set { ViewState["IsUserRLCM"] = value; }
    }
    #endregion

    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (App_Access == AccessType.Administrative_Access)
                StrOperation = "edit";
            else if (App_Access == AccessType.View_Only)
                StrOperation = "view";

            DataSet dtTemp = Security.SelectGroupByUserID(Convert.ToDecimal(clsSession.UserID));
            if (dtTemp != null && dtTemp.Tables.Count > 0)
            {
                if (dtTemp.Tables[0].Rows.Count > 0)
                {
                    DataRow[] drTmpRows = dtTemp.Tables[0].Select(" Group_Name = 'Administrative' ");
                    if (drTmpRows.Length > 0)
                        IsUserInAdministrativeGroup = true;
                    else
                        IsUserInAdministrativeGroup = false;
                }

                if (dtTemp.Tables[1].Rows.Count > 0)//if RLCM user #Issue 3439 Pt. 5
                    IsUserRLCM = true;
                else
                    IsUserRLCM = false;
            }

            if (IsUserInAdministrativeGroup)//|| IsUserRLCM
                btnAdd.Visible = true;
            else
                btnAdd.Visible = false;

            Binddropdown();
            BindPosts(1, 10);
        }
    }

    #endregion

    #region "Methods"
    /// <summary>
    /// Bind Wall Main Post
    /// </summary>
    /// <param name="PageNumber"></param>
    /// <param name="PageSize"></param>
    private void BindPosts(int PageNumber, int PageSize)
    {
        string strLastName = Convert.ToString(txtPosterLastName.Text.Trim().Replace("'", "''"));
        string strFirstName = Convert.ToString(txtPosterFirstName.Text.Trim().Replace("'", "''"));
        DateTime? dtPostDateFrom = clsGeneral.FormatNullDateToStore(txtDatePostFrom.Text);
        DateTime? dtPostDateTo = clsGeneral.FormatNullDateToStore(txtDatePostTo.Text);
        string strPostText = Convert.ToString(txtPostText.Text.Trim().Replace("'", "''"));
        string strTopic = Convert.ToString(txtTopic.Text.Trim()).Replace("'", "''");

        DataSet dsPosts = clsMain_Wall.SearchWallPosts(PageNumber, PageSize, strLastName, strFirstName, dtPostDateFrom, dtPostDateTo, strPostText, strTopic);

        //// set values for paging control,so it shows values as needed.
        ctrlPageWallPost.TotalRecords = (dsPosts.Tables.Count >= 3) ? Convert.ToInt32(dsPosts.Tables[1].Rows[0][0]) : 0;
        ctrlPageWallPost.CurrentPage = (dsPosts.Tables.Count >= 3) ? Convert.ToInt32(dsPosts.Tables[2].Rows[0][2]) : 0;
        ctrlPageWallPost.RecordsToBeDisplayed = dsPosts.Tables[0].Rows.Count;
        ctrlPageWallPost.SetPageNumbers();

        if (dsPosts.Tables.Count >= 5)
        {
            dtComments = dsPosts.Tables[3];
            dtAttachments = dsPosts.Tables[4];
        }

        rptPosts.DataSource = dsPosts.Tables[0];
        rptPosts.DataBind();

        if (dsPosts.Tables[0].Rows.Count == 0)
        {
            Control FooterTemplate = rptPosts.Controls[rptPosts.Controls.Count - 1].Controls[0];
            FooterTemplate.FindControl("trEmpty").Visible = true;
        }

        // set record numbers retrieved
        lblNumber.Text = (dsPosts.Tables.Count >= 3) ? Convert.ToString(dsPosts.Tables[1].Rows[0][0]) : "0";
    }

    private void Binddropdown()
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll_SLT(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' AND Show_On_Dashboard= 'Y' AND Activation_Date <= '" + DateTime.Now + "'" ;
        dtData.DefaultView.Sort = "dba";
        dtData = dtData.DefaultView.ToTable();
        ddlRMLocationNumber.Items.Clear();
        ddlRMLocationNumber.DataTextField = "dba1";
        ddlRMLocationNumber.DataValueField = "PK_LU_Location_ID";
        ddlRMLocationNumber.DataSource = dtData;
        ddlRMLocationNumber.Style.Add("font-size", "x-small");
        ddlRMLocationNumber.DataBind();
        //check require to add "-- select --" at first item of dropdown.

        ddlRMLocationNumber.Items.Insert(0, new ListItem("--Select--","0"));
    }

    #endregion

    #region "Control Events"

    /// <summary>
    /// Button Search Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        dvSearch.Visible = true;
        dvThreads.Visible = false;

        rptPosts.DataSource = null;
        rptPosts.DataBind();

        txtDatePostFrom.Text = "";
        txtDatePostTo.Text = "";
        txtPosterFirstName.Text = "";
        txtPosterLastName.Text = "";
        txtPostText.Text = "";
        txtTopic.Text = "";
    }

    /// <summary>
    /// Button Add Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddWall.aspx?type=1");
    }

    /// <summary>
    /// Button Search result click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearchResult_Click(object sender, EventArgs e)
    {
        dvSearch.Visible = false;
        dvThreads.Visible = true;

        ctrlPageWallPost.setDrpRecordsValue();
        BindPosts(1, 10);
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
      //here we have to open message wall by location wise
       Response.Redirect("SLT_Wall_ByLocation.aspx?PK_LU_Location_ID="+ Encryption.Encrypt(ddlRMLocationNumber.SelectedValue) +"&Location="+ ddlRMLocationNumber.SelectedItem);
    }
    #endregion

    #region "Other Events"
    
    /// <summary>
    /// Implement event for Paging control when clicking on Go button
    /// </summary>
    protected void GetPage()
    {
        BindPosts(ctrlPageWallPost.CurrentPage, ctrlPageWallPost.PageSize);
    }

    /// <summary>
    /// Repeater Comments Item Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptPostsComments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ///set and get the Display file name and Save file name for attachment
            string strInput_File_Name = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Input_File_Name"));
            string strStored_File_Name = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Stored_File_Name"));
            if (strInput_File_Name.Trim() != null && strInput_File_Name != "")
            {
                if (strInput_File_Name.ToLower().EndsWith(".jpg") || strInput_File_Name.ToLower().EndsWith(".jpeg") || strInput_File_Name.ToLower().EndsWith(".gif") ||
                    strInput_File_Name.ToLower().EndsWith(".png") || strInput_File_Name.ToLower().EndsWith(".tif") || strInput_File_Name.ToLower().EndsWith(".tiff"))
                {//for Image attachment
                    Image imgAttachment = (Image)e.Item.FindControl("imgAttachmentComment");
                    imgAttachment.Visible = true;
                    imgAttachment.Style.Add("cursor", "hand");
                    imgAttachment.Style.Add("padding-top", "5px");

                    // show thumbnail of the image
                    string strFileName = strStored_File_Name;
                    string strThumbnail = strFileName.Substring(0, strFileName.LastIndexOf(".") - 1) + "_Thumb" + strFileName.Substring(strFileName.LastIndexOf("."));

                    imgAttachment.ImageUrl = AppConfig.SiteURL + "Documents/Main_Wall_Attachment/" + strThumbnail;
                    imgAttachment.Attributes.Add("onclick", "javascript:window.open('" + AppConfig.SiteURL + "Documents/Main_Wall_Attachment/" + strFileName + "')");
                }
                else
                {///for documents
                    LinkButton lnkAttchment = (LinkButton)e.Item.FindControl("lnkAttchmentComment");
                    lnkAttchment.Text = strInput_File_Name;
                    lnkAttchment.Style.Add("cursor", "hand");
                    lnkAttchment.Visible = true;
                    lnkAttchment.OnClientClick = "javascript:return openWindow('" + AppConfig.SiteURL + "Documents/Main_Wall_Attachment/" + strStored_File_Name + "');";
                }
            }
            else
            {
                ///if file name is null then disable the attachment option
                ((Label)e.Item.FindControl("lblAttchmentComment")).Visible = false;
            }

            ///set the Div height based on message length
            HiddenField hdCommentMsgLength = (HiddenField)e.Item.FindControl("hdCommentMsgLength");
            HtmlGenericControl dvCommentMessage = (HtmlGenericControl)e.Item.FindControl("dvCommentMessage");
            int intMessageLength = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Message")).Length);
            hdCommentMsgLength.Value = intMessageLength.ToString();

            ///check the message lengths
            if (intMessageLength >= 2500)
            {
                //set div height and set visible
                dvCommentMessage.Style.Add("height", "200px");
                ((HtmlContainerControl)e.Item.FindControl("trExpandControls")).Visible = true;
            }
            else
                ((HtmlContainerControl)e.Item.FindControl("trExpandControls")).Visible = false;

        }
    }

    /// <summary>
    /// Repeater Main Wall item Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptPosts_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        //check item command for add comment
        if (e.CommandName.ToString() == "btnComment")
        {
            //redirect to add sub comment screen
            decimal _PK_Main_Wall = Convert.ToDecimal(e.CommandArgument);
            Response.Redirect("AddWall.aspx?type=2&id=" + Encryption.Encrypt(_PK_Main_Wall.ToString()) + "");
        }
    }

    /// <summary>
    /// Radio button Main Entire Thread selected Index Changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void rdbThredType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //set the visible inner comments based on selection of radion button of full post
    //    if (rdbThredType.SelectedIndex == 0)
    //        trCommentDate.Visible = true;
    //    else
    //        trCommentDate.Visible = false;
    //    BindPosts(ctrlPageWallPost.CurrentPage, ctrlPageWallPost.PageSize);
    //}

    /// <summary>
    /// Radio Button Selected Index Changed Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rdbThredTypeComment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ///Bind Inner repeater and set controls
        Repeater rptPostsComments = (Repeater)((RepeaterItem)((RadioButtonList)sender).Parent).FindControl("rptPostsComments");
        if (((RadioButtonList)sender).SelectedValue.ToUpper() == "Y")
        {
            decimal _FK_Main_Wall = Convert.ToDecimal(((HiddenField)((RepeaterItem)((RadioButtonList)sender).Parent).FindControl("hdnPKMainWall")).Value);
            dtComments.DefaultView.RowFilter = "FK_Main_Wall=" + _FK_Main_Wall;
            //dtComments.DefaultView.Sort = "Update_Date " + Convert.ToString(rdbCommentDateOrder.SelectedItem.Text);
            rptPostsComments.DataSource = dtComments.DefaultView;
            rptPostsComments.DataBind();
            rptPostsComments.Visible = true;
        }
        else
        {
            rptPostsComments.DataSource = null;
            rptPostsComments.DataBind();
            rptPostsComments.Visible = false;
        }
    }

    /// <summary>
    /// Repeater Item Data Bound Event - main wall
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            decimal _PK_Main_Wall = Convert.ToDecimal(DataBinder.Eval(e.Item.DataItem, "PK_Main_Wall"));

            //get attachment for Main wall
            DataRow[] drAttachment = dtAttachments.Select("FK_Main_Wall=" + _PK_Main_Wall);
            if (drAttachment != null && drAttachment.Length > 0)
            {
                ///Get the File name to show and saved file
                string strInput_File_Name = Convert.ToString(drAttachment[0]["Input_File_Name"]);
                if (strInput_File_Name.ToLower().EndsWith(".jpg") || strInput_File_Name.ToLower().EndsWith(".jpeg") || strInput_File_Name.ToLower().EndsWith(".gif") ||
                    strInput_File_Name.ToLower().EndsWith(".png") || strInput_File_Name.ToLower().EndsWith(".tif") || strInput_File_Name.ToLower().EndsWith(".tiff"))
                {//for Image attachment
                    Image imgAttachment = (Image)e.Item.FindControl("imgAttachment");
                    imgAttachment.Visible = true;
                    imgAttachment.Style.Add("cursor", "hand");
                    imgAttachment.Style.Add("padding-top", "5px");
                    imgAttachment.Style.Add("padding-left", "5px");

                    // show thumbnail of the image
                    string strFileName = clsGeneral.Encode_Url(Convert.ToString(drAttachment[0]["Stored_File_Name"]));
                    string strThumbnail = strFileName.Substring(0, strFileName.LastIndexOf(".") - 1) + "_Thumb" + strFileName.Substring(strFileName.LastIndexOf("."));

                    if (File.Exists(AppConfig.SitePath + "Documents/Main_Wall_Attachment/" + Convert.ToString(drAttachment[0]["Stored_File_Name"])))
                    {
                        imgAttachment.ImageUrl = AppConfig.SiteURL + "Documents/Main_Wall_Attachment/" + strThumbnail;
                        imgAttachment.Attributes.Add("onclick", "javascript:return openWindow('" + AppConfig.SiteURL + "Documents/Main_Wall_Attachment/" + strFileName + "');");
                    }
                    else
                    {
                        imgAttachment.ImageUrl = AppConfig.SiteURL + "Images/NoImage.jpg";
                        imgAttachment.Attributes.Add("onclick", "javascript:return openWindow('" + AppConfig.SiteURL + "Images/NoImage.jpg" + "');");
                    }

                    //imgAttachment.ImageUrl = AppConfig.SiteURL + "Documents/Main_Wall_Attachment/" + strThumbnail;
                    //imgAttachment.Attributes.Add("onclick", "javascript:return openWindow('" + AppConfig.SiteURL + "Documents/Main_Wall_Attachment/" + strFileName + "');");
                }
                else
                {///for documents
                    LinkButton lnkAttchment = (LinkButton)e.Item.FindControl("lnkAttchment");
                    lnkAttchment.Text = strInput_File_Name;
                    lnkAttchment.Style.Add("cursor", "hand");
                    lnkAttchment.Visible = true;
                    //lnkAttchment.OnClientClick = "javascript:return openWindow('" + AppConfig.SiteURL + "Documents/Main_Wall_Attachment/" + clsGeneral.Encode_Url(Convert.ToString(drAttachment[0]["Stored_File_Name"])) + "');";
                    if (File.Exists(AppConfig.SitePath + "Documents/Main_Wall_Attachment/" + Convert.ToString(drAttachment[0]["Stored_File_Name"])))
                        lnkAttchment.OnClientClick = "javascript:return openWindow('" + AppConfig.SiteURL + "Documents/Main_Wall_Attachment/" + clsGeneral.Encode_Url(Convert.ToString(drAttachment[0]["Stored_File_Name"])) + "');";
                    else
                        lnkAttchment.OnClientClick = "javascript:alert('Attachment Not Found');return false;";
                }
            }
            else
            {
                ((Label)e.Item.FindControl("lblAttchment")).Visible = false;
            }

            ///set the radio buttons and Bind inner grid
           // RadioButtonList rdbThredTypeComment = (RadioButtonList)e.Item.FindControl("rdbThredTypeComment");
            //rdbThredTypeComment.SelectedValue = rdbThredType.SelectedValue;
            Repeater rptPostsComments = (Repeater)e.Item.FindControl("rptPostsComments");
            //Label lblShowThread = (Label)e.Item.FindControl("lblShowThread");

            //if (rdbThredType.SelectedIndex == 0)
            //{
                ///Select the records by FK wall
                dtComments.DefaultView.RowFilter = "FK_Main_Wall=" + _PK_Main_Wall;
                //dtComments.DefaultView.Sort = "Update_Date " + Convert.ToString(rdbCommentDateOrder.SelectedItem.Text);
                rptPostsComments.DataSource = dtComments.DefaultView;
                rptPostsComments.DataBind();
                rptPostsComments.Visible = true;

                ///Check data table row count
                //if (dtComments.DefaultView.Count > 0)
                //{
                   // lblShowThread.Visible = true;
                    //rdbThredTypeComment.Visible = true;
                //}
                //else
                //{
                    ///set inner comment repeater visible false
                    //rdbThredTypeComment.Visible = false;
                    //lblShowThread.Visible = false;
               // }
            //}
            //else
            //{
                ///if Sub comment not found then bind the inner repeater with null
                //rptPostsComments.DataSource = null;
                //rptPostsComments.DataBind();
                //rptPostsComments.Visible = false;

                ///set row filter
                //dtComments.DefaultView.RowFilter = "FK_Main_Wall=" + _PK_Main_Wall;
                //if (dtComments.DefaultView.Count > 0)
                //{
                //    lblShowThread.Visible = true;
                //    rdbThredTypeComment.Visible = true;
                //}
                //else
                //{
                //    rdbThredTypeComment.Visible = false;
                //    lblShowThread.Visible = false;
                //}
            //}

            ///set the Div height based on message length
            HiddenField hdMessageLength = (HiddenField)e.Item.FindControl("hdMessageLength");
            HtmlGenericControl dvMainMessage = (HtmlGenericControl)e.Item.FindControl("dvMainMessage");
            int intMessageLength = Convert.ToInt32(Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Message")).Length);
            hdMessageLength.Value = intMessageLength.ToString();

            ///check the Message length
            if (intMessageLength >= 2500)
            {
                dvMainMessage.Style.Add("height", "200px");
                ((HtmlContainerControl)e.Item.FindControl("tdExpandControls")).Visible = true;
            }
            else
                ((HtmlContainerControl)e.Item.FindControl("tdExpandControls")).Visible = false;
        }
    }
    #endregion
}