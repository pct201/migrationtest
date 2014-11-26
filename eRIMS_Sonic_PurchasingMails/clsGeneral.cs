using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Aspose.Words;

namespace eRIMS_Sonic_PurchasingMails
{
    class clsGeneral
    {
        public static string strServicePath;
        public clsGeneral()
        { }

        public static void SaveFile(string strFileText, string strFileName)
        {
            string strLisenceFile = strServicePath + "\\Aspose.Words.lic";

            if (File.Exists(strLisenceFile))
            {
                //This shows how to license Aspose.Words, if you don't specify a license, 
                //Aspose.Words works in evaluation mode.
                Aspose.Words.License license = new Aspose.Words.License();
                license.SetLicense(strLisenceFile);
            }

            Aspose.Words.Document doc = new Aspose.Words.Document();

            //Build string builder to transport to Doc
            //Once the builder is created, its cursor is positioned at the beginning of the document.
            Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
            //builder.Font.Size = 12;
            //builder.Font.Bold = false;
            //builder.Font.Color = System.Drawing.Color.Black;
            builder.PageSetup.PaperSize = PaperSize.Letter;
            builder.PageSetup.BottomMargin = 40;
            builder.PageSetup.TopMargin = 40;
            builder.PageSetup.LeftMargin = 40;
            builder.PageSetup.RightMargin = 40;
            //builder.Font.Name = "Arial";
            builder.InsertParagraph();
            builder.InsertHtml(strFileText);
            //builder.Write(litLetter.Text);

            doc.MailMerge.DeleteFields();

            string strFullPath = strServicePath + "\\" + strFileName;
            doc.Save(strFullPath, Aspose.Words.SaveFormat.Doc);
        }

        /// <summary>
        /// Sets the dates for the labels which are not mendatory fields,
        /// it may have null value which should return an empty string
        /// </summary>
        /// <param name="objDate"></param>
        /// <returns></returns>
        public static string FormatDBNullDateToDisplay(object objDate)
        {
            if (objDate == DBNull.Value || objDate == null)
                return string.Empty;
            else
                return Convert.ToDateTime(objDate).ToString(eRIMS_Sonic_PurchasingMails.DateDisplayFormat);
        }

        /// <summary>
        /// Converts decimal value to string to be displayed in labels
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        public static string GetStringValue(object objValue)
        {
            if (objValue == null || objValue == DBNull.Value)
                return string.Empty;
            else
                return Convert.ToDecimal(objValue).ToString("C").Replace("$", "");
        }
    }
}
