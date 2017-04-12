using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActiveUp.Net.Mail;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;


namespace ERIMS_Sonic_EmailScheduler
{
    class POP3Server : IDisposable
    {
        Pop3Client objPop3Client;

        public POP3Server()
        {
            if (objPop3Client == null)
                objPop3Client = new Pop3Client();
        }

        public void Dispose()
        {
            if (objPop3Client != null)
            {
                objPop3Client.Disconnect();
                objPop3Client = null;
            }
        }

        public void ReadMailFromPOP3Server()
        {
            try
            {
                clsGeneral.WriteLog("Executing ReadMailFromPOP3Server()", false);
                int _RepeatMailCount = clsGeneral.ReadMailCount;
                Message objMessage;

                int count;
                //Code for reading email from SMTP server                      
                //int unReadMailCount;

                clsGeneral.WriteLog("Connecting to SMTP server POP3", false);
                objPop3Client.Connect(clsGeneral.strSMTPServer, Convert.ToInt32(clsGeneral.strPort), clsGeneral.strSMTPmail, clsGeneral.strSMTPPwd);

                clsGeneral.WriteLog("Connected to SMTP server POP3", false);

                int unReadMailCount = objPop3Client.MessageCount;
                clsGeneral.WriteLog("Unread Mail Count to be processed : " + unReadMailCount.ToString(), false);
                string strMessageBody;
                DataSet ds;

                for (int i = unReadMailCount; i <= unReadMailCount && i != 0; i--)
                {
                    objMessage = objPop3Client.RetrieveMessageObject(i);

                    if (objMessage.HeaderFields["in-reply-to"] != null || (objMessage.Subject != null && objMessage.Subject.Contains(clsGeneral.strSentMailSubjectFrmt))) //This indicates mail is reply
                    {
                        clsGeneral.WriteLog(" Message Details :" + "\n\t\t\t\t\t\tMessage Subject :" + objMessage.Subject + "\n\t\t\t\t\t\tReply From :" + objMessage.From + "\n\t\t\t\t\t\tReply Time :" + objMessage.Date.ToString(), false);
                        if (_RepeatMailCount != 0)
                        {
                            try
                            {
                                Facility_Maintenance_Notes objFacility_Maintenance_Notes = new Facility_Maintenance_Notes();
                                if (objMessage.HeaderFields["in-reply-to"].Contains("#-#"))
                                    objFacility_Maintenance_Notes.FK_Facility_Maintenance_Item = Convert.ToDecimal(objMessage.HeaderFields["in-reply-to"].Substring(0, objMessage.HeaderFields["in-reply-to"].IndexOf("#-#")));
                                else
                                {
                                    //Fetch PK_Facility_Construction_Maintenance_Item on basis of Item_Number
                                    //If reference does not contain required message id extract it from subject line
                                    //string _strItem_Number = objMessage.Subject.Substring(objMessage.Subject.IndexOf(clsGeneral.strSentMailSubjectFrmt) + clsGeneral.strSentMailSubjectFrmt.Length);
                                    string _strItem_Number = "";
                                    if (objMessage.Subject.Split(' ').Count() > 3)
                                        _strItem_Number = objMessage.Subject.Split(' ')[3];
                                    ds = clsGeneral.SelectFacilityConstructionMaintenanceItemByItemNumber(_strItem_Number);
                                    if (ds.Tables[0].Rows.Count > 0)
                                        objFacility_Maintenance_Notes.FK_Facility_Maintenance_Item = Convert.ToDecimal(ds.Tables[0].Rows[0]["PK_Facility_Construction_Maintenance_Item"]);
                                }
                                ds = clsGeneral.SelectAuthorByEmail(objMessage.From.Email);
                                if (ds.Tables[0].Rows.Count > 0)
                                    objFacility_Maintenance_Notes.FK_Author = Convert.ToDecimal(ds.Tables[0].Rows[0]["PK_Contactor_Security"].ToString());
                                else
                                {
                                    clsGeneral.WriteLog("User does not exist", false);
                                    continue;
                                }
                                objFacility_Maintenance_Notes.Note_Date = Convert.ToDateTime(objMessage.Date);
                                objFacility_Maintenance_Notes.Note = clsGeneral.ExtractEmailReply(objMessage.BodyText.TextStripped, clsGeneral.strSMTPmail);
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

                                    //Save message attachment at the specified path
                                    //Save message attachment  
                                    //For some mobile app image appears as embedded object instead of attachment
                                    int attachmentCnt = objMessage.EmbeddedObjects.Count;
                                    for (int j = 0; j < attachmentCnt; j++)
                                    {
                                        string strFileName = @clsGeneral.strMailAttachmentStorePath + System.DateTime.Now.ToString("MMddyyhhmmss") + objMessage.EmbeddedObjects[j].Filename;
                                        System.IO.File.WriteAllBytes(strFileName, objMessage.EmbeddedObjects[j].BinaryContent);

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
                                    
                                    //For attachment
                                    var en = objMessage.Attachments.GetEnumerator();
                                    while (en.MoveNext())
                                    {
                                        MimePart ob = en.Current as MimePart;
                                        string strFileName = System.DateTime.Now.ToString("MMddyyhhmmss") + ob.Filename;
                                        ob.StoreToFile(@clsGeneral.strMailAttachmentStorePath + strFileName);

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
                                clsGeneral.WriteLog("Exception ocurred while inserting record : " + Ex.Message + "\n Details of message not inserted :" + "\n\t\t\t\t\t\tMessage Subject :" + objMessage.Subject + "\n\t\t\t\t\t\tReply From :" + objMessage.From + "\n\t\t\t\t\t\tReply Time :" + objMessage.Date.ToString(), true);
                            }
                        }
                    }
                }

                clsGeneral.WriteLog("ReadMailFromPOP3Server() executed", false);
            }
            catch (Exception Ex)
            {
                clsGeneral.WriteLog("Exception " + Ex.Message + " occurred in ReadMailFromPOP3Server() and Stack Trace:" + Ex.StackTrace, true);
            }


        }
    }
}
