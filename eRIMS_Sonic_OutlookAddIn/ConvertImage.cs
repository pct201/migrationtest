using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;

namespace eRIMS_Sonic_OutlookAddIn
{
    class ConvertImage : System.Windows.Forms.AxHost
    {
        private ConvertImage()
            : base(null)
        {
        }

        public static stdole.IPictureDisp Convert(System.Drawing.Image image)
        {
            return (stdole.IPictureDisp)System.Windows.Forms.AxHost.GetIPictureDispFromPicture(image);
        }


        public static stdole.IPictureDisp getImage()
        {
            stdole.IPictureDisp tempImage = null;
            try
            {
                //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActivation));
                tempImage = ConvertImage.Convert(((System.Drawing.Image)(global::eRIMS_Sonic_OutlookAddIn.Properties.Resources.Erims)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tempImage;
        }
    }


}
