using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Security;

namespace RIMS_Base.Biz
{
    [Serializable]
    public class CGeneral : RIMS_Base.CGeneral
    {
        #region Private Declarations
        RIMS_Base.CGeneral mObj_Details;
        #endregion
        #region Constructor
        public CGeneral()
        {
            mObj_Details = new RIMS_Base.Dal.CGeneral();
        }
        #endregion
        #region Public Methods   
        public override DataSet GetCountyByState(string m_strState)
        {
            return mObj_Details.GetCountyByState(m_strState);
        }
        public override List<RIMS_Base.CGeneral> GetLiabilityCoverageById(decimal pk_id)
        {
            return mObj_Details.GetLiabilityCoverageById(pk_id);
        }
        public override List<RIMS_Base.CGeneral> GetLiabilityCoverage()
        {
            return mObj_Details.GetLiabilityCoverage();
        }
        public override List<RIMS_Base.CGeneral> GetAutoClaimTypes()
        {
            return mObj_Details.GetAutoClaimTypes();
        }
        public override List<RIMS_Base.CGeneral> GetGeneralClaimTypes()
        {
            return mObj_Details.GetGeneralClaimTypes();
        }
        public override List<RIMS_Base.CGeneral> GetInjuredTypes()
        {
            return mObj_Details.GetInjuredTypes();
        }
        public override List<RIMS_Base.CGeneral> GetClaimantTypes()
        {
            return mObj_Details.GetClaimantTypes();
        }
        public override List<RIMS_Base.CGeneral> GetAllState()
        {
            return mObj_Details.GetAllState();
        }
        
        public override List<RIMS_Base.CGeneral> GetAttachamentType()
        {
            return mObj_Details.GetAttachamentType();
        }
        public override List<RIMS_Base.CGeneral> GetSupportedDocumentType()
        {
            return mObj_Details.GetSupportedDocumentType();
        }

        public override List<RIMS_Base.CGeneral> GetVendorType()
        {
            return mObj_Details.GetVendorType();
        }
        public override List<RIMS_Base.CGeneral> GetPayroll()
        {
            return mObj_Details.GetPayroll();
        }
        public override List<RIMS_Base.CGeneral> GetLossCondtionAct()
        {
            return mObj_Details.GetLossCondtionAct();
        }
        public override List<RIMS_Base.CGeneral> GetLossCondtionRecovery()
        {
            return mObj_Details.GetLossCondtionRecovery();
        }
        public override List<RIMS_Base.CGeneral> GetLossCoverageCode()
        {
            return mObj_Details.GetLossCoverageCode();
        }
        public override List<RIMS_Base.CGeneral> GetPropertyDamage()
        {
            return mObj_Details.GetPropertyDamage();
        }
        public override List<RIMS_Base.CGeneral> GetInjuryType()
        {
            return mObj_Details.GetInjuryType();
        }
        public override List<RIMS_Base.CGeneral> GetLossConditionLoss()
        {
            return mObj_Details.GetLossConditionLoss();
        }
        public override List<RIMS_Base.CGeneral> GetAttornyForm()
        {
            return mObj_Details.GetAttornyForm();
        }
        public override List<RIMS_Base.CGeneral> GetSettlementMethod()
        {
            return mObj_Details.GetSettlementMethod();
        }
        
        public override List<RIMS_Base.CGeneral> GetInjuryCode()
        {
            return mObj_Details.GetInjuryCode();
        }
        public override List<RIMS_Base.CGeneral> GetMajorClassCode()
        {
            return mObj_Details.GetMajorClassCode();
        }
        public override List<RIMS_Base.CGeneral> GetLossCondSettlement()
        {
            return mObj_Details.GetLossCondSettlement();
        }
        public override List<RIMS_Base.CGeneral> GetPayCode(string m_strPayId)
        {
            return mObj_Details.GetPayCode(m_strPayId);
        }
        public override List<RIMS_Base.CGeneral> GetNcciNature()
        {
            return mObj_Details.GetNcciNature();
        }

        public override List<RIMS_Base.CGeneral> GetNcciCause()
        {
            return mObj_Details.GetNcciCause();
        }

        public override List<RIMS_Base.CGeneral> GetNcciCode()
        {
            return mObj_Details.GetNcciCode();
        }

        public override List<RIMS_Base.CGeneral> GetWcMinorType()
        {
            return mObj_Details.GetWcMinorType();
        }

        public override List<RIMS_Base.CGeneral> GetWcMajorType()
        {
            return mObj_Details.GetWcMajorType();
        }

        public override List<RIMS_Base.CGeneral> GetHazardCode()
        {
            return mObj_Details.GetHazardCode();
        }

        public override List<RIMS_Base.CGeneral> GetFraudClaim()
        {
            return mObj_Details.GetFraudClaim();
        }

        public override List<RIMS_Base.CGeneral> GetBodyParts()
        {
            return mObj_Details.GetBodyParts();
        }

        public override List<RIMS_Base.CGeneral> GetCounty()
        {
            return mObj_Details.GetCounty();
        }

        public override List<RIMS_Base.CGeneral> GetPreInjury()
        {
            return mObj_Details.GetPreInjury();
        }

        public override List<RIMS_Base.CGeneral> GetManagedCareOrg()
        {
            return mObj_Details.GetManagedCareOrg();
        }

        public override List<RIMS_Base.CGeneral> GetClaimCause()
        {
            return mObj_Details.GetClaimCause();
        }

        public override List<RIMS_Base.CGeneral> GetClaimNature()
        {
            return mObj_Details.GetClaimNature();
        }

        public override List<RIMS_Base.CGeneral> GetBenificary()
        {
            return mObj_Details.GetBenificary();
        }

        public override List<RIMS_Base.CGeneral> GetRoadSurface()
        {
            return mObj_Details.GetRoadSurface();
        }

        public override List<RIMS_Base.CGeneral> GetRoadType()
        {
            return mObj_Details.GetRoadType();
        }

        public override List<RIMS_Base.CGeneral> GetComprehensive()
        {
            return mObj_Details.GetComprehensive();
        }

        public override List<RIMS_Base.CGeneral> GetOriginalCost()
        {
            return mObj_Details.GetOriginalCost();
        }

        public override List<RIMS_Base.CGeneral> GetLiabilitymajor()
        {
            return mObj_Details.GetLiabilitymajor();
        }

        public override List<RIMS_Base.CGeneral> GetLiabilityminor()
        {
            return mObj_Details.GetLiabilityminor();
        }

        public override List<RIMS_Base.CGeneral> Getincident()
        {
            return mObj_Details.Getincident();
        }
        
        public override List<RIMS_Base.CGeneral> GetWeatherCondition()
        {
            return mObj_Details.GetWeatherCondition();
        }

        public override List<RIMS_Base.CGeneral> GetCollision_Deductible()
        {
            return mObj_Details.GetCollision_Deductible();
        }

        public override List<RIMS_Base.CGeneral> Classification_code()
        {
            return mObj_Details.Classification_code();
        }
        public override List<RIMS_Base.CGeneral> GetAdjustorNoteType()
        {
            return mObj_Details.GetAdjustorNoteType();
        }
        public override List<RIMS_Base.CGeneral> GetAllEntity()
        {
            return mObj_Details.GetAllEntity();
        }
        public override List<RIMS_Base.CGeneral> GetAllEntityByLoggedInUser(Decimal pk_Security_Id)
        {
            return mObj_Details.GetAllEntityByLoggedInUser(pk_Security_Id);
        }
        public override List<RIMS_Base.CGeneral> GetAllFacility()
        {
            return mObj_Details.GetAllFacility();
        }
        public override List<RIMS_Base.CGeneral> GetAllCostCenter()
        {
            return mObj_Details.GetAllCostCenter();
        }


        public override List<RIMS_Base.CGeneral> GetGender()
        {
            return mObj_Details.GetGender();
        }
        public override List<RIMS_Base.CGeneral> GetDriverStatus()
        {
            return mObj_Details.GetDriverStatus();
        }



        public override List<RIMS_Base.CGeneral> GetAllMobileType()
        {
            return mObj_Details.GetAllMobileType();
        }
        public override List<RIMS_Base.CGeneral> GetAllStationaryType()
        {
            return mObj_Details.GetAllStationaryType();
        }
        public override List<RIMS_Base.CGeneral> GetAllLandStatus()
        {
            return mObj_Details.GetAllLandStatus();
        }
        public override List<RIMS_Base.CGeneral> GetAllFloodZone()
        {
            return mObj_Details.GetAllFloodZone();
        }

        public override List<RIMS_Base.CGeneral> GetAllConstrType()
        {
            return mObj_Details.GetAllConstrType();
        }
        public override List<RIMS_Base.CGeneral> GetAllLocation()
        {
            return mObj_Details.GetAllLocation();
        }
        public override List<RIMS_Base.CGeneral> GetPropertyType()
        {
            return mObj_Details.GetPropertyType();
        }
        public override List<RIMS_Base.CGeneral> GetPropertyLocationCode()
        {
            return mObj_Details.GetPropertyLocationCode();
        }
        public override DataSet GetBatteries()
        {
            return mObj_Details.GetBatteries();
        }
        public override DataSet GetTowerType()
        {
            return mObj_Details.GetTowerType();
        }
        public override DataSet GetFireProtection()
        {
            return mObj_Details.GetFireProtection();
        }
        public override DataSet GetPolicyType()
        {
            return mObj_Details.GetPolicyType();
        }
        public override DataSet GetAllAdHocFields(string ClaimType)
        {
            return mObj_Details.GetAllAdHocFields(ClaimType);
        }
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader =
                                            new AppSettingsReader();
            // Get the key from config file

            string key = (string)settingsReader.GetValue("SecurityKey",
                                                         typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes =
                     new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                            new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey",
                                                         typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes =
                        new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }


    #endregion
    } 
}
