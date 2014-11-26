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
/// <summary>
/// Date : 2 OCT 2008
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To get the information for OSHA Recordable for Investigation
/// 
/// Functionality:
/// Provides question along with Yes and No button
/// 
/// When clicking yes button it imposes next question if available otherwise
/// writes YES to the OSHA recordable on investigation page
/// 
/// When clicking No button it imposes next question if available otherwise
/// returns to the inestigation page without changes for OSHA recordable on investigation page
/// </summary>
public partial class SONIC_Exposures_InvestigationWzard : System.Web.UI.Page
{
    #region "Variables"

    /// <summary>
    /// Array of questions to be displayed one at a time when YES button clicked
    /// </summary>
    private string[] strQuestionYes = {"Did the case occur on the employer's premises, parking facility or company controlled recreational facility?",
                                       "Was the employee off duty and on the employer's premises as a member of the general public?",
                                       "Did the employee experience illness, injury or death?",
                                       "Did the injury or illness result in death, loss of consciousness, or in-patient hospitalization?"
                                      };

    /// <summary>
    /// Array of questions to be displayed one at a time when NO button is clicked
    /// </summary>
    private string[] strQuestionNo = {"Was the employee in some work related activity or required by the employer to participate in the recreational activity?",
                                       "Was the employee present at the location as a condition of employment?",
                                       "Was the employee in travel status and engaged in work or travel function?",
                                       "Did the injury or illness result in one or more days away from work, one or more days of restricted work activity (not performing ALL routine job functions), or job transfer?",
                                       "Did the injury or illness require medical treatment beyond First aid?"
                                      };

    #endregion

    #region "Properties"
    /// <summary>
    /// Denotes index to loop through strQuestionYes array
    /// </summary>
    public int intYesIndex
    {
        get { return Convert.ToInt32(ViewState["intYesIndex"]); }
        set { ViewState["intYesIndex"] = value; }
    }

    /// <summary>
    /// Denotes index to loop through strQuestionNo array
    /// </summary>
    public int intNoIndex
    {
        get { return Convert.ToInt32(ViewState["intNoIndex"]); }
        set { ViewState["intNoIndex"] = value; }
    }


    #endregion

    #region "Control Events"

    /// <summary>
    /// Handles an event when page is loaded first time
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // when the page is loaded first time
        if (!IsPostBack)
        {
            // show first question and initialize No index with -1
            lblQuestion.Text = strQuestionYes[0];
            intNoIndex = -1;
        }
    }

    /// <summary>
    /// Handles Yes button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnYes_Click(object sender, EventArgs e)
    {
        // set next question from strQuestionYes array and increment index to point to next question
        // and make necessary settings for no index
        lblQuestion.Text = strQuestionYes[++intYesIndex];
        if (intYesIndex == 2) { intNoIndex = 2; }
    }

    /// <summary>
    /// Handles No button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNo_Click(object sender, EventArgs e)
    {
        // set next question from strQuestionNo array and increment index to point to next question
        // and make necessary settings for yes index
        if (intNoIndex == -1) { intYesIndex = 1; }        
        lblQuestion.Text = strQuestionNo[++intNoIndex];
    }
    #endregion
}
