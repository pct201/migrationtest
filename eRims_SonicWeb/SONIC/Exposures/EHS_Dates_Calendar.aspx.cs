using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Exposures_EHS_Dates_Calendar : clsBasePage
{
    #region ::Properties::

    private decimal PK_RLCM
    {
        get { return clsGeneral.GetDecimal(ViewState["PK_RLCM"]); }
        set { ViewState["PK_RLCM"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblYear.Text = DateTime.Now.Year.ToString();
            int intRLCM;
            //if (!string.IsNullOrEmpty(Request.QueryString["RLCM"]))
            if (int.TryParse(Encryption.Decrypt(Request.QueryString["RLCM"]), out intRLCM))
            {
                PK_RLCM = intRLCM;
            }
            else
            {
                Response.Redirect("RLCM_QA_QC.aspx");
            }
            //PK_RLCM = 14058;

            setCalendar(Convert.ToInt32(lblYear.Text));
        }
    }

    #region ::Events::
    /// <summary>
    /// lnkbtnLess Click event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnLess_Click(object sender, EventArgs e)
    {
        lblYear.Text = Convert.ToString(Convert.ToInt64(lblYear.Text) - 1);

        setCalendar(Convert.ToInt32(lblYear.Text));
    }

    /// <summary>
    /// lnkbtnGreater Click event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkbtnGreater_Click(object sender, EventArgs e)
    {
        lblYear.Text = Convert.ToString(Convert.ToInt64(lblYear.Text) + 1);

        setCalendar(Convert.ToInt32(lblYear.Text));
    }
    #endregion

    #region ::Methods::

    /// <summary>
    /// set color by month.
    /// </summary>
    /// <param name="month"></param>
    /// <param name="strColor"></param>
    public void setColor(int month, string strColor)
    {
        switch (month)
        {
            case 1: lnkJan.CssClass = strColor;
                lnkJan.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
            case 2: lnkFeb.CssClass = strColor;
                lnkFeb.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
            case 3: lnkMar.CssClass = strColor;
                lnkMar.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
            case 4: lnkApril.CssClass = strColor;
                lnkApril.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
            case 5: lnkMay.CssClass = strColor;
                lnkMay.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
            case 6: lnkJune.CssClass = strColor;
                lnkJune.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
            case 7: lnkJuly.CssClass = strColor;
                lnkJuly.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
            case 8: lnkAug.CssClass = strColor;
                lnkAug.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
            case 9: lnkSept.CssClass = strColor;
                lnkSept.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
            case 10: lnkOct.CssClass = strColor;
                lnkOct.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
            case 11: lnkNov.CssClass = strColor;
                lnkNov.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
            case 12: lnkDec.CssClass = strColor;
                lnkDec.OnClientClick = "javascript:return Redirect('" + AppConfig.SiteURL + "SONIC/Exposures/EHS_Dates_RLCM_Monthly_QA_QC.aspx?Mnt=" + Encryption.Encrypt(month.ToString()) + "&yr=" + Encryption.Encrypt(lblYear.Text.ToString()) + "&RLCM=" + Encryption.Encrypt(Convert.ToString(PK_RLCM)) + "')";
                break;
        }
    }

    /// <summary>
    /// set calendar by data.
    /// </summary>
    public void setCalendar(int year)
    {
        DataSet dsCalendar = clsEHS_Calendar.EHS_Show_Calendar(year, null, PK_RLCM);
        DataTable dtRed = dsCalendar.Tables[1];
        DataTable dtGreen = dsCalendar.Tables[2];

        DateTime? dtPast_Due = null;

        if (dtRed.Rows.Count > 0)
        {
            dtPast_Due = Convert.ToDateTime(dtRed.Rows[0]["Red_Color"]);
        }


        for (int i = 1; i <= 12; i++)
        {
            setColor(i, "blue");
        }

        for (int j = 1; j <= dtGreen.Rows.Count; j++)
        {
            setColor(Convert.ToInt32(dtGreen.Rows[j - 1]["Green_Color"]), "green");
        }

        if (dtPast_Due != null)
        {
            for (int k = 1; k <= 12; k++)
            {
                if (new DateTime(Convert.ToInt32(lblYear.Text), k, DateTime.DaysInMonth(Convert.ToInt32(lblYear.Text), k)) >= Convert.ToDateTime(dtPast_Due) && new DateTime(Convert.ToInt32(lblYear.Text), k, 1) <= DateTime.Now)
                {
                    setColor(k, "red");
                }
            }
        }
    }

    #endregion
}