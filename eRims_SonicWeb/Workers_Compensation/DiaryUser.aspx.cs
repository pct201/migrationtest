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
using RIMS_Base.Biz;

public partial class WorkerCompensation_DiaryUser : System.Web.UI.Page
{
    #region Private Variables      
    
    public RIMS_Base.Biz.CSecurity biz_ObjSecurity;
    List<RIMS_Base.CSecurity> lstSecurity = null;
    protected string val;
    public RIMS_Base.Biz.Diary m_objUserList;
    DataSet m_dsUserList;
    DataView dvView = new DataView();

    string strSortExp = String.Empty;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mode"].ToString() != String.Empty && Session["mode"] != null)
        {
            val = Session["mode"].ToString();
        } 

        if (!IsPostBack)
        {
            ViewState["CostCenter"] = null;
                        
            if (Session["WorkerCompID"] != null && Session["WorkerCompID"].ToString() != String.Empty)
            {
                RIMS_Base.Biz.CWorkersComp objWorkerComp = new RIMS_Base.Biz.CWorkersComp();
                List<RIMS_Base.CWorkersComp> lstWorkerComp = new List<RIMS_Base.CWorkersComp>();
                try
                {
                    lstWorkerComp = objWorkerComp.Get_Worker_CompensationByID(Convert.ToInt32(Session["WorkerCompID"].ToString()));
                    if (lstWorkerComp.Count > 0)
                    {
                        ViewState["CostCenter"] =lstWorkerComp[0].FK_Entity.ToString();
                        BindUserData(lstWorkerComp[0].FK_Entity.ToString());                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    objWorkerComp = null;
                    lstWorkerComp = null;
                }
            }
           
        }

    }
    public void BindUserData(string CostCenter)
    {
        try
        {
            //biz_ObjSecurity = new RIMS_Base.Biz.CSecurity();
            //lstSecurity = new List<RIMS_Base.CSecurity>();
            //lstSecurity=biz_ObjSecurity.GetAll();
            //dgUsers.DataSource=lstSecurity;
            //dgUsers.DataBind();
            
            m_objUserList = new RIMS_Base.Biz.Diary();
            m_dsUserList = new DataSet();
            m_dsUserList = m_objUserList.GetAssignToUser(CostCenter);
            //dvView = m_dsUserList.Tables[0].DefaultView;
            dgUsers.DataSource = m_dsUserList;
            dgUsers.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    // -- Bind the Column of the DataGrid
    protected void dgUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lbtnTemp=new LinkButton();
            lbtnTemp = ((LinkButton)(e.Row.FindControl("lbtnUserName")));
            string userName;
            userName = lbtnTemp.CommandArgument.ToString();
            string userID = ((LinkButton)e.Row.FindControl("lbtnUserID")).CommandArgument.ToString();
            string assignTO = userName +',' + userID;
            lbtnTemp.Attributes.Add("onclick", "test('" + assignTO + "');");

            lbtnTemp = ((LinkButton)(e.Row.FindControl("lbtnFirstName")));
            userName = lbtnTemp.CommandArgument.ToString();
            lbtnTemp.Attributes.Add("onclick", "test('" + assignTO + "');");

            lbtnTemp = ((LinkButton)(e.Row.FindControl("lbtnLastName")));
            userName = lbtnTemp.CommandArgument.ToString();
            lbtnTemp.Attributes.Add("onclick", "test('" + assignTO + "');");

            lbtnTemp = ((LinkButton)(e.Row.FindControl("lbtnCostCenter")));
            userName = lbtnTemp.CommandArgument.ToString();
            lbtnTemp.Attributes.Add("onclick", "test('" + assignTO + "');");

            lbtnTemp = ((LinkButton)(e.Row.FindControl("lbtnDivision")));
            userName = lbtnTemp.CommandArgument.ToString();
            lbtnTemp.Attributes.Add("onclick", "test('" + assignTO + "');");

        }
    }

    protected void dgUsers_Sorting(object sender, GridViewSortEventArgs e)
    {
        m_objUserList = new RIMS_Base.Biz.Diary();
        m_dsUserList = new DataSet();              

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
        
        if (ViewState["CostCenter"] != null)
        {
            m_dsUserList = m_objUserList.GetAssignToUser(ViewState["CostCenter"].ToString());
            
            dvView = m_dsUserList.Tables[0].DefaultView;
            if (ViewState["SortExp"] != null)
            {
                if(ViewState["sortDirection"].ToString() == "Descending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Desc";
                if (ViewState["sortDirection"].ToString() == "Ascending")
                    dvView.Sort = ViewState["SortExp"].ToString() + " Asc";
            }

        }
           // m_dsUserList.Sort(new RIMS_Base.GenericComparer<RIMS_Base.CDiary>((string)ViewState["SortExp"], (SortDirection)ViewState["sortDirection"]));
        dgUsers.DataSource = dvView;
        dgUsers.DataBind();

       
    }
    protected void dgUsers_RowCreated(object sender, GridViewRowEventArgs e)
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
        foreach (DataControlField field in dgUsers.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = dgUsers.Columns.IndexOf(field);
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
        Image sortImage = new Image();

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
   
}
