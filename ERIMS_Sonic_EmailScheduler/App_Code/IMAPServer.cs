using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActiveUp.Net.Mail;
using System.Data;

namespace ERIMS_Sonic_EmailScheduler
{
    class IMAPServer : IDisposable
    {               
        public Imap4Client objImap4Client;
        public IMAPServer()
        {
            if (objImap4Client == null)
                objImap4Client = new Imap4Client();
        }

        public void Dispose()
        {
            if (objImap4Client != null)
            {
                objImap4Client.Disconnect();
                objImap4Client = null;
            }
        }

        public void ReadMailFromIMAPServer()
        {
            try
            {
                int _RepeatMailCount = clsGeneral.ReadMailCount;
                //Code for reading email from SMTP server                      
                //int unReadMailCount;

                clsGeneral.WriteLog("Connecting to IMAP server", false);
                objImap4Client.ConnectSsl(clsGeneral.strSMTPServer, Convert.ToInt32(clsGeneral.strPort));
                objImap4Client.Login(clsGeneral.strSMTPmail, clsGeneral.strSMTPPwd);

                clsGeneral.WriteLog("Connected to IMAP server", false);


                //Fetches mail from INBOX
                Mailbox inbox = objImap4Client.SelectMailbox("INBOX");
                //Gets mail received of today
                MessageCollection objMsgsReceivedToday = inbox.SearchParse("SENTSINCE " + DateTime.Now.ToString("dd-MMM-yyyy"));

                int unReadMailCount = objMsgsReceivedToday.Count;
                clsGeneral.WriteLog("Unread Mail Count to be processed : " + unReadMailCount.ToString(), false);

                DataSet ds;
                //for (int index = 0; index < objMsgsReceivedToday.Count; index++)
                for (int index = objMsgsReceivedToday.Count - 1; index >= 0; index--)
                {
                    if (objMsgsReceivedToday[index].HeaderFields["in-reply-to"] != null ||(objMsgsReceivedToday[index].Subject != null && objMsgsReceivedToday[index].Subject.Contains(clsGeneral.strSentMailSubjectFrmt))) //This indicates mail is reply
                    {
                        clsGeneral.WriteLog(" Message Details :" + "\n\t\t\t\t\t\tMessage Subject :" + objMsgsReceivedToday[index].Subject + "\n\t\t\t\t\t\tReply From :" + objMsgsReceivedToday[index].From + "\n\t\t\t\t\t\tReply Time :" + objMsgsReceivedToday[index].Date.ToString(), false);
                        if (_RepeatMailCount != 0)
                        {
                            try
                            {
                                Facility_Maintenance_Notes objFacility_Maintenance_Notes = new Facility_Maintenance_Notes();
                                if (objMsgsReceivedToday[index].HeaderFields["in-reply-to"] != null && objMsgsReceivedToday[index].HeaderFields["in-reply-to"].Contains("#-#"))
                                    objFacility_Maintenance_Notes.FK_Facility_Maintenance_Item = Convert.ToDecimal(objMsgsReceivedToday[index].HeaderFields["in-reply-to"].Substring(1, objMsgsReceivedToday[index].HeaderFields["in-reply-to"].IndexOf("#-#") - 1));
                                else
                                {
                                    //Fetch PK_Facility_Construction_Maintenance_Item on basis of Item_Number
                                    //If reference does not contain required message id extract it from subject line
                                    //string _strItem_Number = objMsgsReceivedToday[index].Subject.Substring(objMsgsReceivedToday[index].Subject.IndexOf(clsGeneral.strSentMailSubjectFrmt) + clsGeneral.strSentMailSubjectFrmt.Length);
                                    string _strItem_Number = "";
                                    if (objMsgsReceivedToday[index].Subject.Split(' ').Count() > 3)
                                        _strItem_Number= objMsgsReceivedToday[index].Subject.Split(' ')[3];
                                    ds = clsGeneral.SelectFacilityConstructionMaintenanceItemByItemNumber(_strItem_Number);
                                    if (ds.Tables[0].Rows.Count > 0)
                                        objFacility_Maintenance_Notes.FK_Facility_Maintenance_Item = Convert.ToDecimal(ds.Tables[0].Rows[0]["PK_Facility_Construction_Maintenance_Item"]);
                                }
                                ds = clsGeneral.SelectAuthorByEmail(objMsgsReceivedToday[index].From.Email);
                                if (ds.Tables[0].Rows.Count > 0)
                                    objFacility_Maintenance_Notes.FK_Author = Convert.ToDecimal(ds.Tables[0].Rows[0]["PK_Contactor_Security"].ToString());
                                else
                                {
                                    clsGeneral.WriteLog("User does not exist", false);
                                    continue;
                                }
                                objFacility_Maintenance_Notes.Note_Date = Convert.ToDateTime(objMsgsReceivedToday[index].Date);
                                objFacility_Maintenance_Notes.Note = clsGeneral.ExtractEmailReply(objMsgsReceivedToday[index].BodyText.TextStripped, clsGeneral.strSMTPmail);
                                objFacility_Maintenance_Notes.Author_Table = "Contractor_Security";
                                int IdentityValue = objFacility_Maintenance_Notes.Insert();

                                if (IdentityValue == 1)
                                {
                                    clsGeneral.WriteLog("Record already exists", false);
                                    _RepeatMailCount--;
                                }
                                else
                                {
                                    clsGeneral.WriteLog("Facility Management Note Record Inserted", false);

                                    Message mobj = objMsgsReceivedToday[index];
                                    //Save message attachment
                                    //For embedded objects eg images
                                    //For some mobile app image appears as embedded object instead of attachment
                                    
                                    int attachmentCnt = objMsgsReceivedToday[index].EmbeddedObjects.Count;
                                    for (int j = 0; j < attachmentCnt;j++)
                                    {
                                        string strFileName = @clsGeneral.strMailAttachmentStorePath + System.DateTime.Now.ToString("MMddyyhhmmss") + objMsgsReceivedToday[index].EmbeddedObjects[j].Filename;
                                        System.IO.File.WriteAllBytes(strFileName, objMsgsReceivedToday[index].EmbeddedObjects[j].BinaryContent);

                                        Attachment objAttachmentNotesReply = new Attachment();
                                        objAttachmentNotesReply.Attachment_Description = objMsgsReceivedToday[index].EmbeddedObjects[j].Filename;
                                        objAttachmentNotesReply.Attachment_Name = strFileName;
                                        objAttachmentNotesReply.Foreign_Key = IdentityValue;
                                        objAttachmentNotesReply.FK_Attachment_Type = 0;
                                        objAttachmentNotesReply.Attachment_Table = "Facility_Maintenance_Notes";
                                        objAttachmentNotesReply.Update_Date = DateTime.Now;
                                        objAttachmentNotesReply.Updated_By = objFacility_Maintenance_Notes.FK_Author.ToString();
                                        objAttachmentNotesReply.Insert();
                                    }
                                    //For attachment
                                    var en = objMsgsReceivedToday[index].Attachments.GetEnumerator();
                                    while (en.MoveNext())
                                    {
                                        MimePart ob = en.Current as MimePart;
                                        string strFileName = System.DateTime.Now.ToString("MMddyyhhmmss") + ob.Filename;
                                        ob.StoreToFile(@clsGeneral.strMailAttachmentStorePath + System.DateTime.Now.ToString("MMddyyhhmmss") + ob.Filename);

                                        Attachment objAttachmentNotesReply = new Attachment();
                                        objAttachmentNotesReply.Attachment_Description = strFileName;
                                        objAttachmentNotesReply.Attachment_Name = strFileName;
                                        objAttachmentNotesReply.Foreign_Key = IdentityValue;
                                        objAttachmentNotesReply.FK_Attachment_Type = 0;
                                        objAttachmentNotesReply.Attachment_Table = "Facility_Maintenance_Notes";
                                        objAttachmentNotesReply.Update_Date = DateTime.Now;
                                        objAttachmentNotesReply.Updated_By = objFacility_Maintenance_Notes.FK_Author.ToString();
                                        objAttachmentNotesReply.Insert();
                                    }
                                        _RepeatMailCount = clsGeneral.ReadMailCount; //Reset read mail count to actual if one unprocessed mail found
                                }
                            }
                            catch (Exception Ex)
                            {
                                clsGeneral.WriteLog("Exception ocurred while inserting record : " + Ex.Message + "\n Details of message not inserted :" + "\n\t\t\t\t\t\tMessage Subject :" + objMsgsReceivedToday[index].Subject + "\n\t\t\t\t\t\tReply From :" + objMsgsReceivedToday[index].From + "\n\t\t\t\t\t\tReply Time :" + objMsgsReceivedToday[index].Date.ToString(), true);
                            }

                        }
                    }
                    else
                    {
                        //clsGeneral.WriteLog("Other mail", _strCsvPath, false);
                        clsGeneral.WriteLog(" Details of message not inserted :" + "\n\t\t\t\t\t\tMessage Subject :" + objMsgsReceivedToday[index].Subject + "\n\t\t\t\t\t\tReply From :" + objMsgsReceivedToday[index].From + "\n\t\t\t\t\t\tReply Time :" + objMsgsReceivedToday[index].Date.ToString(), false);
                    }
                }
                objMsgsReceivedToday.Clear();

                clsGeneral.WriteLog("ReadMailFromIMAPServer() executed", false);
            }
            catch(Exception Ex)
            {
                //clsGeneral.WriteLog("Exception occurred while executing ReadMailFromIMAPServer()", false);
                clsGeneral.WriteLog("Exception " + Ex.Message + " occurred in ReadMailFromIMAPServer and Stack Trace:" + Ex.StackTrace, true);
            }
        }
    }
}
