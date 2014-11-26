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
public partial class Controls_SONIC_Purchasing_PurchasingAsset : System.Web.UI.UserControl
{    
    public string StrRedirectTo
    {
        get
        {
            if (ViewState["StrRedirectTo"] != null)
            {
                return Convert.ToString(ViewState["StrRedirectTo"]);
            }
            else
            {
                return "PurchasingAssetInformation.aspx";
            }
        }
        set
        {
            ViewState["StrRedirectTo"] = value;
        }
    }   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (clsSession.Current_Purchasing_Asset_ID > 0)
            {
                // bind the property identification information
                BindNotes();
            }
        }
    }
    private void BindNotes()
    {
        // create a new executive risk identification object.            
        Purchasing_Asset objAsset = new Purchasing_Asset();
        if (objAsset.View(clsSession.Current_Purchasing_Asset_ID))
        {
            lblType.Text = objAsset.Type;
            //lblManufacturer.Text = objAsset.FK_LU_Manufacturer.ToString();
            lblSupplier.Text = objAsset.Supplier;
            rptManufacturer.DataSource = Purchasing_Asset.SelectAllByPurchasingAssetManufacturer(clsSession.Current_Purchasing_Asset_ID);
            rptManufacturer.DataBind();
            rptDepartment.DataSource = Purchasing_Asset.SelectAllByPurchasingAsset(clsSession.Current_Purchasing_Asset_ID);
            rptDepartment.DataBind();
            rptLocation.DataSource = Purchasing_Asset.SelectAllByPurchasingAssetLocation(clsSession.Current_Purchasing_Asset_ID);
            rptLocation.DataBind();
        }
    }
}
