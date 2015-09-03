using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using ERIMS.DAL;

public partial class Administrator_LU_Cause_Code_Information : System.Web.UI.Page
{

    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_LU_Cause_Code_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Cause_Code_Information"]);
        }
        set { ViewState["PK_LU_Cause_Code_Information"] = value; }
    }

    /// <summary>
    /// Denotes the Master Order
    /// </summary>
    public int Master_Order
    {
        get
        {
            return clsGeneral.GetInt(ViewState["Master_Order"]);
        }
        set { ViewState["Master_Order"] = value; }
    }
    #endregion

    protected int NewListOrderNumber;
    // protected List<reorderlistitem> ListDataItems;

    protected void Page_Load(object sender, EventArgs e)
    {

        //rlItemList.ItemReorder += new EventHandler<ReorderListItemReorderEventArgs>(rlItemList_ItemReorder);

        // Event handler for deleting items from the list
        //  rlItemList.ItemCommand += new EventHandler<ReorderListItemReorderEventArgs>(rlItemList_ItemCommand);


        if (!Page.IsPostBack)
        {
            
            DataSet dsInsQues = clsLU_Cause_Code_Information.SelectAll();
            // bind the grid.
            GetListData();
            BindGrid();
            btnSave.Visible = false;
            btnCancel.Visible = false;
            //rlItemList.DataSource = dsInsQues;
            //rlItemList.DataBind();
            BindData();

        }
    }

    public void BindGrid()
    {
        DataSet dsInsQues = clsLU_Cause_Code_Information.SelectAll();
        // bind the grid.
        gvQuestion.DataSource = dsInsQues;
        gvQuestion.DataBind();
    }

    protected void gvQuestion_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkView = (LinkButton)e.Row.FindControl("lnkView");
            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            LinkButton lnkRemove = (LinkButton)e.Row.FindControl("lnkRemove");
            if (lnkView != null)
                lnkView.CommandArgument = Convert.ToString(e.Row.RowIndex);
            if (lnkEdit != null)
                lnkEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
            if (lnkRemove != null)
                lnkRemove.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }

    protected void gvQuestion_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void gvQuestion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQuestion.PageIndex = e.NewPageIndex;
        BindGrid();
    }
    protected void gvQuestion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            HiddenField hdnInsID = (HiddenField)gvQuestion.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("hdnInspectionQuestionID");
            PK_LU_Cause_Code_Information = Convert.ToInt32(hdnInsID.Value.ToString());
            EditRecord();
        }
        if (e.CommandName == "View")
        {
            HiddenField hdnInsID = (HiddenField)gvQuestion.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("hdnInspectionQuestionID");
            PK_LU_Cause_Code_Information = Convert.ToInt32(hdnInsID.Value.ToString());
            ViewRecord();
        }
        if (e.CommandName == "Remove")
        {
            HiddenField hdnInsID = (HiddenField)gvQuestion.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("hdnInspectionQuestionID");
            PK_LU_Cause_Code_Information = Convert.ToInt32(hdnInsID.Value.ToString());
            clsLU_Cause_Code_Information.DeleteByPK(PK_LU_Cause_Code_Information);
            btnCancel_Click(null, null);
            BindGrid();
        }
    }
    public void EditRecord()
    {
        divQuestionViewList.Style.Add("display", "none");
        divAddNewQuestion.Style.Add("display", "block");
        divViewQuestion.Style.Add("display", "none");
        btnSave.Visible = true;
        btnCancel.Visible = true;
        btnSave.Text = "Update";
        clsLU_Cause_Code_Information objclsLU_Cause_Code_Information = new clsLU_Cause_Code_Information(PK_LU_Cause_Code_Information);
        txtFocusArea.Text = objclsLU_Cause_Code_Information.Focus_Area.ToString();
        txtQuestion.Text = objclsLU_Cause_Code_Information.Question.ToString();
        txtSortOrder.Text = objclsLU_Cause_Code_Information.Sort_Order.ToString();
        txtGuidance.Text = objclsLU_Cause_Code_Information.Guidance.ToString();
        txtReference.Text = objclsLU_Cause_Code_Information.Reference.ToString();
        rdoActive.SelectedValue = objclsLU_Cause_Code_Information.Active;

        txtFocusArea.Focus();
    }
    public void ViewRecord()
    {
        divQuestionViewList.Style.Add("display", "none");
        divAddNewQuestion.Style.Add("display", "none");
        divViewQuestion.Style.Add("display", "block");
        btnSave.Visible = false;
        btnCancel.Visible = true;
        clsLU_Cause_Code_Information objIns_Que = new clsLU_Cause_Code_Information(PK_LU_Cause_Code_Information);
        lblFocusArea.Text = objIns_Que.Focus_Area.ToString();
        lblQuestion.Text = objIns_Que.Question.ToString();
        lblSortOrder.Text = objIns_Que.Sort_Order.ToString();
        lblGuidance.Text = objIns_Que.Guidance.ToString();
        lblReference.Text = objIns_Que.Reference.ToString();
        lblActive.Text = objIns_Que.Active == "Y" ? "Yes" : "No";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        divQuestionViewList.Style.Add("display", "block");
        divAddNewQuestion.Style.Add("display", "none");
        divViewQuestion.Style.Add("display", "none");
        txtFocusArea.Text = "";
        txtGuidance.Text = "";
        txtSortOrder.Text = "";
        txtQuestion.Text = "";
        lblFocusArea.Text = "";
        lblGuidance.Text = "";
        lblQuestion.Text = "";
        lblSortOrder.Text = "";
        btnSave.Text = "Save";
        btnSave.Visible = false;
        btnCancel.Visible = false;
        rdoActive.SelectedValue = "N";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsLU_Cause_Code_Information objIns_Que = new clsLU_Cause_Code_Information(PK_LU_Cause_Code_Information);
        objIns_Que.PK_LU_Cause_Code_Information = PK_LU_Cause_Code_Information;
        objIns_Que.Focus_Area = txtFocusArea.Text.ToString();
        objIns_Que.Question = txtQuestion.Text.ToString();
        //objIns_Que.Sort_Order = txtSortOrder.Text.ToString();
        objIns_Que.Guidance = txtGuidance.Text.ToString();
        objIns_Que.Reference = txtReference.Text.ToString();
        objIns_Que.Active = rdoActive.SelectedValue;
        if (PK_LU_Cause_Code_Information > 0)
        {
            objIns_Que.Update();
        }
        else
        {
            objIns_Que.Insert();
        }
        BindGrid();
        btnCancel_Click(null, null);
    }


    protected void btnSortQuestions_Click(object sender, EventArgs e)
    {
        clsLU_Cause_Code_Information.SelectFocusArea();

        DataSet dsInsQues = clsLU_Cause_Code_Information.SelectFocusArea();
        // bind the grid.
       rptFocusArea.DataSource = dsInsQues;
       rptFocusArea.DataBind();
        divMain.Style.Add("display", "block");
        divQuestionViewList.Style.Add("display", "none");
        //pnlFocusArea.Style.Add("display", "block");
    }


    /// <summary>
    /// Reorder list items in the database when a reorder event occurs
    /// </summary>
    protected void rlItemList_ItemReorder(object sender, ReorderListItemReorderEventArgs e)
    {
        int NewOrder = e.NewIndex + 1;
        int OldOrder = e.OldIndex + 1;
        clsLU_Cause_Code_Information obj = new clsLU_Cause_Code_Information();
        DataSet dsList = clsLU_Cause_Code_Information.SelectAll();

        int ReorderListItemID = Convert.ToInt16(((Label)(e.Item.FindControl("lblPKLUCauseCodeInformation"))).Text);
        //int MasterOrder = Convert.ToInt16(((Label)(e.Item.FindControl("lblPKLUCauseCodeInformation"))).Text);

        //int db = new RealTimeReorderListDataDataContext();

        int ListItemCount = 1;
        //DataSet dsInsQues = clsLU_Cause_Code_Information.SelectAllID();
        //int ListData = from ld in db.ReorderListItems
        //orderby ld.ListOrder
        //select ld;

        DataTable dtListData = dsList.Tables[0];
        foreach (DataRow drListDataItem in dtListData.Rows)
        {

            // clsLU_Cause_Code_Information obj=new clsLU_Cause_Code_Information();


            obj.PK_LU_Cause_Code_Information = Convert.ToDecimal(drListDataItem["PK_LU_Cause_Code_Information"]);

            obj.Sort_Order = Convert.ToInt16(drListDataItem["Sort_Order"]);

            // Move forward items in this range
            if (OldOrder > NewOrder && ListItemCount >= NewOrder && ListItemCount <= OldOrder)
                obj.Sort_Order = ListItemCount + 1;
            // Move backward items in this range
            else if
                (OldOrder < NewOrder && ListItemCount <= NewOrder && ListItemCount >= OldOrder)
                obj.Sort_Order = ListItemCount - 1;

            ListItemCount++;

            // Set the changed item into the newly numerical gap
            if (obj.PK_LU_Cause_Code_Information == ReorderListItemID)
            {
                // obj.PK_LU_Cause_Code_Information = Convert.ToDecimal(drListDataItem["PK_LU_Cause_Code_Information"]);
                clsLU_Cause_Code_Information objLU_Cause_Code_Information = new clsLU_Cause_Code_Information(Convert.ToDecimal(obj.PK_LU_Cause_Code_Information));
                objLU_Cause_Code_Information.Sort_Order = NewOrder;
                objLU_Cause_Code_Information.Updated_By = Convert.ToString(drListDataItem["Updated_By"]);
                objLU_Cause_Code_Information.Update_Date = DateTime.Now.Date;
                objLU_Cause_Code_Information.UpdateSortOrder();
                BindData();
            }
        }
        //obj.PK_LU_Cause_Code_Information = ReorderListItemID;
        // obj.Update();

        //db.SubmitChanges();

        //GetListData();
        //BindData();
    }


    /// <summary>
    /// ItemCommand event used to delete list items
    /// </summary>
    void rlItemList_ItemCommand(object sender, ReorderListCommandEventArgs e)
    {
        // If you want support for multiple commands
        if (e.CommandName != "Delete")
            return;

        //int db = new RealTimeReorderListDataDataContext();

        // ListData = from ld in db.ReorderListItems
        //               where ld.ID == Convert.ToInt32(((Label)
        //                  (e.Item.FindControl("ID"))).Text)
        //               select ld;
        //db.ReorderListItems.DeleteAllOnSubmit(ListData);
        //db.SubmitChanges();
        GetListData();
        BindData();
    }


    /// <summary>
    /// Add button click event used to inset a new list item into the database
    /// </summary>
    protected void AddReorderListItem_Click(object sender, EventArgs e)
    {
        GetListData(); // Get the current NewListOrderNumber
        //var db = new RealTimeReorderListDataDataContext();
        //var RLI = new ReorderListItem
        //{
        //    ListOrder = NewListOrderNumber,
        //    Name = tbItemName.Text,
        //    Description = tbItemDescription.Text
        //};
        //db.ReorderListItems.InsertOnSubmit(RLI);
        //db.SubmitChanges();

        // Clear the form values so that watermark shows
        // tbItemName.Text = "";
        // tbItemDescription.Text = "";

        GetListData(); //Get the list with the newly inserted item
        BindData();

    }

    /// <summary>
    /// Retrieve the list items from the database
    /// </summary>
    public void GetListData()
    {

        clsLU_Cause_Code_Information obj = new clsLU_Cause_Code_Information(PK_LU_Cause_Code_Information);
        //ListDataItems = ListData.ToList();
        //NewListOrderNumber = ListDataItems.Count() + 1;
    }

    /// <summary>
    /// Bind the data the to the ReorderList control
    /// </summary>
    protected void BindData()
    {
        //rlItemList.DataSource = clsLU_Cause_Code_Information.SelectAll();
        //rlItemList.DataBind();
    }



    protected void lnkEdit_Click(object sender, EventArgs e)
    {

    }

    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        divCauseCodeInformation.Style.Add("display", "none");
        divAddNewQuestion.Style.Add("display", "block");
        divViewQuestion.Style.Add("display", "none");
        btnCancel.Visible = true;
        btnSave.Visible = true;
        btnSave.Text = "Save";
        txtFocusArea.Focus();
    }
    protected void imagePlus_Click(object sender, ImageClickEventArgs e)
    {
        //if (e.CommandName == "image")
        //{
        //    HiddenField hdnID = (HiddenField)gvQuestion.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("hdnMaster_Order");
        //    HiddenField hdnID = (HiddenField)gvQuestion.Rows.
        //    Master_Order = Convert.ToInt32(hdnID.Value.ToString());
        //    clsLU_Cause_Code_Information.SelectQuestions(Master_Order);
        //}
    }
    protected void gvFocusArea_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "image")
        {

            Master_Order = Convert.ToInt32(e.CommandArgument);
            //rlItemList.DataSource = clsLU_Cause_Code_Information.SelectQuestions(Master_Order);
            //// bind the grid.
            //rlItemList.DataBind();
        }
    }
    
    protected void rptFocusArea_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        decimal Master_Order = Convert.ToDecimal(DataBinder.Eval(e.Item.DataItem, "Master_Order"));
        ReorderList rdoList = (ReorderList)e.Item.FindControl("rlItemList");
        rdoList.DataSource = clsLU_Cause_Code_Information.SelectQuestions(Master_Order);
        //// bind the grid.
        rdoList.DataBind();
    }
}
