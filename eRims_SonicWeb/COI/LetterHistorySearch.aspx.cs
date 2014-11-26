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
public partial class Admin_LetterHistorySearch : clsBasePage
{
    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (App_Access == AccessType.NotAssigned || App_Access == AccessType.View_Only)
            Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
        txtInsured.Focus();
    }

    #region "Controls Events"
    /// <summary>
    /// Handle Search Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // get the search value from the controls entered by the user
        GetSearchValues();

        //redirect to List page which will perform search procedure
        Response.Redirect("LetterHistoryList.aspx");
    }

    #endregion
    /// <summary>
    /// Stores the user entered value in session that can be used in next page for searching
    /// </summary>
    private void GetSearchValues()
    {
        //create datatable for storing all values
        DataTable dtSearch = new DataTable();

        //add columns for each value in data table
        DataColumn dcInsured = new DataColumn("strInsuredName");
        dcInsured.DataType = Type.GetType("System.String");
        dtSearch.Columns.Add(dcInsured);

        DataColumn dcIssueDateFrom = new DataColumn("dtIssueDateFrom");
        dcIssueDateFrom.DataType = Type.GetType("System.DateTime");
        dtSearch.Columns.Add(dcIssueDateFrom);

        DataColumn dcIssueDateTo = new DataColumn("dtIssueDateTo");
        dcIssueDateTo.DataType = Type.GetType("System.DateTime");
        dtSearch.Columns.Add(dcIssueDateTo);

        DataColumn dcDateLetterSentFrom = new DataColumn("dtDateLetterSentFrom");
        dcDateLetterSentFrom.DataType = Type.GetType("System.DateTime");
        dtSearch.Columns.Add(dcDateLetterSentFrom);

        DataColumn dcdcDateLetterSentTo = new DataColumn("dtDateLetterSentTo");
        dcdcDateLetterSentTo.DataType = Type.GetType("System.DateTime");
        dtSearch.Columns.Add(dcdcDateLetterSentTo);

        // add a row with the values entered by the user in page controls
        DataRow dr = dtSearch.NewRow();
        dr["strInsuredName"] = txtInsured.Text.Trim().Replace("'", "");
        dr["dtIssueDateFrom"] = GetDateTimeFromString(txtIssueDateFrom.Text);
        dr["dtIssueDateTo"] = GetDateTimeFromString(txtIssueDateTo.Text);
        dr["dtDateLetterSentFrom"] = GetDateTimeFromString(txtDateLetterFrom.Text);
        dr["dtDateLetterSentTo"] = GetDateTimeFromString(txtDateLetterTo.Text);

        dtSearch.Rows.Add(dr);

        //store the whole data table in a session
        Session["dtLetterSearch"] = dtSearch;

    }

    /// <summary>
    /// If Valid Value is passed then it returns Valid Date after Parsing the date string.
    /// else it returns value with Minimumn value of DateTime Object.
    /// Used to Get DateTime object for Perticular Date in String.
    /// </summary>
    /// <param name="strDate">
    /// Value to be converted to DateTime.
    /// this date string must be in format Specified by DispalyDateFormat.
    /// </param>
    /// <returns>
    /// /// If Valid Value is passed then it returns Valid Date after Parsing the date string.
    /// else it returns value with Minimumn value of DateTime Object.
    /// </returns>
    private DateTime GetDateTimeFromString(string strDate)
    {
        DateTime dtTemp; // temp date time to get DateTime Value from string.
        DateTime.TryParseExact(strDate, AppConfig.DisplayDateFormat, System.Threading.Thread.CurrentThread.CurrentCulture, System.Globalization.DateTimeStyles.None, out dtTemp);
        // if strDate is blank or null or string can't be converted to date time then dtTemp will contain Min Value of Date Time.
        //return dtTemp; 
        if (dtTemp == DateTime.MinValue)
        {
            return Convert.ToDateTime(System.Data.SqlTypes.SqlDateTime.MinValue.ToString());
        }
        else
        {
            return dtTemp;
        }
    }
}
