using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;


public class AciImportHelper
{
    /// <summary>
    /// Set Directory to create new zip file
    /// </summary>
    /// <param name="strAttachments"></param>
    /// <param name="strzipDir"></param>
    public static void SetZipDirectory(string[] strAttachments, string strzipDir)
    {
        //if (Directory.Exists(strzipDir)) Directory.Delete(strzipDir, true);
        if (Directory.Exists(strzipDir))
        {
            string[] files = Directory.GetFiles(strzipDir);
            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
        }
        if (File.Exists(strzipDir + ".Zip")) File.Delete(strzipDir + ".Zip");
        Directory.CreateDirectory(strzipDir);
        for (int j = 0; j < strAttachments.Length; j++)
        {
            if (strAttachments[j] != null)
            {
                string Attachmentname = strAttachments[j];
                FileInfo fi = new FileInfo(Attachmentname);
                FileInfo fiTo = new FileInfo(strzipDir + "\\" + fi.Name);//if in destination same file name already exist then not copied
                if (fi.Exists && !fiTo.Exists)
                {
                    File.Copy(Attachmentname, strzipDir + "\\" + fi.Name);
                    
                }
                
            }
        }
    }

    /// <summary>
    /// Create Zip file
    /// </summary>
    /// <param name="SourcePath"></param>
    public static void ConvertZIP(string SourcePath)
    {
        string destinationPath = SourcePath + ".Zip";
        FastZipEvents events = new FastZipEvents();
        events.ProcessFile = ProcessFileMethod;
        FastZip fZip = new FastZip();
        fZip.CreateZip(destinationPath, SourcePath, true, "");
    }

    /// <summary>
    /// Used to create zip file
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private static void ProcessFileMethod(object sender, ScanEventArgs args)
    {
        try
        {
            string str = args.Name;
        }
        catch (Exception ex)
        {

        }

    }
}

