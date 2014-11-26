using System;
using System.Web.UI.WebControls;
namespace monthcalendar
{

    public partial class MonthSelectControl : System.Web.UI.UserControl
    {
        public String Value
        {
            get { return txtMonthYear.Text; }
            set { txtMonthYear.Text = value; }
        }

        public string EmptyErrorMessage
        {
            get { return reqDate.ErrorMessage; }
            set { reqDate.ErrorMessage = value; }
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
                txtYear.Text = DateTime.Today.Year.ToString();

            imgCal.Attributes.Add("onclick", "ShowDiv('" + ImagePopup.ClientID + "');");
            lnkClose.Attributes.Add("onclick", "HideDiv('" + ImagePopup.ClientID + "');");
            imgPrev.Attributes.Add("onclick", "nextYear(false,'" + txtYear.ClientID + "');");
            imgNext.Attributes.Add("onclick", "nextYear(true,'" + txtYear.ClientID + "');");

            lnkJan.Attributes.Add("onclick", "lnkMonthClick('01','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
            lnkFeb.Attributes.Add("onclick", "lnkMonthClick('02','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
            lnkMar.Attributes.Add("onclick", "lnkMonthClick('03','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
            lnkApr.Attributes.Add("onclick", "lnkMonthClick('04','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
            lnkMay.Attributes.Add("onclick", "lnkMonthClick('05','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
            lnkJun.Attributes.Add("onclick", "lnkMonthClick('06','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
            lnkJul.Attributes.Add("onclick", "lnkMonthClick('07','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
            lnkAug.Attributes.Add("onclick", "lnkMonthClick('08','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
            lnkSep.Attributes.Add("onclick", "lnkMonthClick('09','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
            lnkOct.Attributes.Add("onclick", "lnkMonthClick('10','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
            lnkNov.Attributes.Add("onclick", "lnkMonthClick('11','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
            lnkDec.Attributes.Add("onclick", "lnkMonthClick('12','" + txtMonthYear.ClientID + "','" + txtYear.ClientID + "','" + ImagePopup.ClientID + "');");
        }
    }
}
