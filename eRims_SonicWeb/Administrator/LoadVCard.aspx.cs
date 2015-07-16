using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Thought.vCards;
using ERIMS.DAL;

public partial class Administrator_LoadVCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ClientScript.GetPostBackEventReference(this, string.Empty);

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string filePath = Path.Combine(Server.MapPath(".."), "temp");
        string ActionType = "C";//C = Check, U = Update;
        string strArgs = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];
        if (strArgs != "UpdateDetails")
        {
            filePath += "\\" + fluVcard.FileName;
            fluVcard.SaveAs(filePath);
            Session["vCardfilePath"] = filePath;
        }
        else
        {
            filePath = Convert.ToString(Session["vCardfilePath"]);
            ActionType = "U";
            Session["vCardfilePath"] = null;
        }
        vCard vCard_temp = new vCard(filePath);

        if (vCard_temp != null && !string.IsNullOrEmpty(vCard_temp.FamilyName) && !string.IsNullOrEmpty(vCard_temp.GivenName))
        {
            Contractor_Security objContracor = new Contractor_Security();
            objContracor.First_Name = vCard_temp.GivenName;
            objContracor.Last_Name = vCard_temp.FamilyName;
            objContracor.Contractor_Company_Name = vCard_temp.Organization;
            if (vCard_temp.DeliveryAddresses != null && vCard_temp.DeliveryAddresses.Count > 0)
            {
                foreach (vCardDeliveryAddress add in vCard_temp.DeliveryAddresses)
                {
                    if (add.IsWork)
                    {
                        objContracor.Address_1 = add.Street;
                        objContracor.City = add.City;
                        objContracor.State = add.Region;
                        objContracor.Zip_Code = add.PostalCode;
                        break;
                    }
                }
            }
            if (vCard_temp.Phones != null && vCard_temp.Phones.Count > 0)
            {
                foreach (vCardPhone phone in vCard_temp.Phones)
                {
                    if (phone.IsCellular)
                        objContracor.Cell_Telephone = phone.FullNumber;
                    if (phone.IsWork)
                        objContracor.Office_Telephone = phone.FullNumber;
                    if (phone.IsPager)
                        objContracor.Pager = phone.FullNumber;
                }
            }
            if (vCard_temp.EmailAddresses != null && vCard_temp.EmailAddresses.Count > 0)
            {
                objContracor.Email = vCard_temp.EmailAddresses[0].Address;
            }
            if (Session["PK_Contactor_Security"] != null)
            {
                objContracor.PK_Contactor_Security = Convert.ToDecimal(Session["PK_Contactor_Security"]);
                Session["PK_Contactor_Security"] = null;
            }
            string returnVal = objContracor.ImportContractorSecurityFromVCard(ActionType);
            if (returnVal.ToLower() == "exist")
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), DateTime.Now.ToString(), "javascript:valueSave();", true);
                Session["PK_Contactor_Security"] = objContracor.PK_Contactor_Security;
                return;
            }
            else
            {
                string script = "alert('Import successfull.');self.close();";
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "", script, true);
            }

        }

    }
}