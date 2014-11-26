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
/// Date           : 28-07-08
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : Used to display a First Report List related to current First Report WIzard.
///                  it also display a checkboc that indicate that where the first report is complete or not.
///                  also a Grid for the additional Report.because we can specify more than one same First report type to single FIrst Report
///                  Wizard.
/// 
/// </summary>
public partial class SONIC_FirstReportStatus : clsBasePage
{
    #region Property
    /// <summary>
    /// Denotes the First Report ID
    /// </summary>
    public int First_Report_Wizard_ID
    {
        get
        {
            return clsGeneral.GetInt(clsSession.First_Report_Wizard_ID);
        }
        set { clsSession.First_Report_Wizard_ID = value; }
    }
    #endregion

    #region Page Load Event
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Page is Post back or not
        if (!IsPostBack)
        {
            DataSet dsCFR = Constituent_First_Report.SelectConstituentDetails_byFirstReportID(First_Report_Wizard_ID);
            //check Dataset table's row count
            if (dsCFR.Tables[0].Rows.Count > 0)
            {
                RptReportStatus.DataSource = dsCFR.Tables[0];
                RptReportStatus.DataBind();
                if (dsCFR.Tables[1].Rows.Count > 0)
                {
                    RptAdditionalRpt.DataSource = dsCFR.Tables[1];
                    RptAdditionalRpt.DataBind();
                }
                else
                {
                    trErrorMsg.Style.Add("display", "block");
                }
            }
        }
    }
    #endregion

    #region Grid Events
    /// <summary>
    /// Itemn Cretead Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RptReportStatus_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        //check Item Type
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lnkbtn = new LinkButton();
            lnkbtn = (LinkButton)e.Item.FindControl("lnkbtn");
            //Check NUll value
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Item.ItemIndex);
        }
    }
    /// <summary>
    /// Report Status Item Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RptReportStatus_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        //Check Command Name
        if(e.CommandName == "Link")
        {
            int intIndex = Convert.ToInt32(e.CommandArgument);
            HiddenField hdnURL = (HiddenField)e.Item.FindControl("hdnURL");
            HiddenField hdnFK_First_Report_ID = (HiddenField)e.Item.FindControl("hdnFK_First_Report_ID");
            HiddenField hdnFirst_Report_Table = (HiddenField)e.Item.FindControl("hdnFirst_Report_Table");
            HiddenField hdnComplete = (HiddenField)e.Item.FindControl("hdnComplete");

            Response.Redirect(hdnURL.Value + "?id=" + Encryption.Encrypt(Convert.ToInt32(hdnFK_First_Report_ID.Value).ToString()));
        }
    }
    /// <summary>
    /// Report Status Item Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RptReportStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //check Item Type
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)e.Item.FindControl("chkComplate");
            //check Report is Complete or not. according to answer set value of Complete checkbox
            if (Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "Complete")) == false)
            {
                chk.Checked = false;
            }
            else
            {
                chk.Checked = true;
            }
        }
    }
    /// <summary>
    /// Report Additional Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RptAdditionalRpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //Check Item Type
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)e.Item.FindControl("chkComplate");
            //check Report is Complete or not. according to answer set value of Complete checkbox
            if (Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "Complete")) == false)
            {
                chk.Checked = false;
            }
            else
            {
                chk.Checked = true;
            }
        }
    }
    /// <summary>
    /// Additional Item Created Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RptAdditionalRpt_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        //check Item Type
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lnkbtn = new LinkButton();
            lnkbtn = (LinkButton)e.Item.FindControl("lnkbtn");
            //Check NUll value
            if (lnkbtn != null)
                lnkbtn.CommandArgument = Convert.ToString(e.Item.ItemIndex);
        }
    }
    /// <summary>
    /// Additional Report Item Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void RptAdditionalRpt_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        //Check Command Name
        if (e.CommandName == "Link")
        {
            int intIndex = Convert.ToInt32(e.CommandArgument);
            HiddenField hdnURL = (HiddenField)e.Item.FindControl("hdnURL");
            HiddenField hdnFK_First_Report_ID = (HiddenField)e.Item.FindControl("hdnFK_First_Report_ID");
            HiddenField hdnFirst_Report_Table = (HiddenField)e.Item.FindControl("hdnFirst_Report_Table");
            HiddenField hdnComplete = (HiddenField)e.Item.FindControl("hdnComplete");

            Response.Redirect(hdnURL.Value + "?id=" + Encryption.Encrypt(Convert.ToInt32(hdnFK_First_Report_ID.Value).ToString()));
        }
    }
    #endregion
}
