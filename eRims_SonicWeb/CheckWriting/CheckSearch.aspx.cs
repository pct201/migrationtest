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
public partial class CheckWriting_CheckSearch : System.Web.UI.Page
{
    #region Public Variables
    public RIMS_Base.Biz.CCheckDetails m_objCheckDetails;
    List<RIMS_Base.CCheckDetails> lstChekDetails = null;
    #endregion
    #region Event Handlers
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("../pdf.asp", true);

        //if (!IsPostBack)
        //{
        //    dvCheckSearch.Visible = true;
        //    dvGrd.Visible = false;
        //}
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gvChkEditDel.DataSource = GetCheckDetailsForSearch();
        gvChkEditDel.DataBind();
        dvCheckSearch.Visible = false;
        dvGrd.Visible = true;

    }
    #endregion
    #region Private Methods
    private List<RIMS_Base.CCheckDetails> GetCheckDetailsForSearch()
    {
        try
        {
            m_objCheckDetails = new RIMS_Base.Biz.CCheckDetails();
            lstChekDetails = new List<RIMS_Base.CCheckDetails>();
            //lstChekDetails = m_objCheckDetails.GetCheckDetailsForSearch(chkLstClaimType.Items[0].Selected == true ? chkLstClaimType.Items[0].Value : string.Empty, chkLstClaimType.Items[1].Selected == true ? chkLstClaimType.Items[1].Value : string.Empty, chkLstClaimType.Items[2].Selected == true ? chkLstClaimType.Items[2].Value : string.Empty, chkLstClaimType.Items[3].Selected == true ? chkLstClaimType.Items[3].Value : string.Empty, string.Empty, txtClaimNo.Text, txtDtStart.Text, txtDtEnd.Text, txtFDtClose.Text, txtFDtCloseTo.Text, txtChkNo.Text);
            return lstChekDetails;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
}
