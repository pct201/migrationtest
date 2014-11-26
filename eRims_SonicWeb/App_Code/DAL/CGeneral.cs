#region Includes
using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Configuration;
using System.Globalization;
using System.Data.Common;
using System.Text;
using System.Security.Cryptography;
using System.Security;
#endregion

namespace RIMS_Base.Dal
{
    [Serializable]
    public class CGeneral : RIMS_Base.CGeneral
    {
        public override List<RIMS_Base.CGeneral> GetLiabilityCoverageById(decimal pk_id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LiabilityCoverage_Select");
                dbHelper.AddInParameter(cmd, "@PK_Liability_Coverage", DbType.Decimal, pk_id);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obje = new CGeneral();
                    obje = MapFromLiabilityCoverage(reader);
                    results.Add(obje);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }   
        }
        public override List<RIMS_Base.CGeneral> GetLiabilityCoverage()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LiabilityCoverage_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obje = new CGeneral();
                    obje = MapFromLiabilityCoverage(reader);
                    results.Add(obje);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }   
        }
        protected RIMS_Base.Dal.CGeneral MapFromLiabilityCoverage(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obje = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_Liability_Coverage"])) { obje.PK_Liability_Coverage = Convert.ToDecimal(reader["PK_Liability_Coverage"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc"])) { obje.FLD_Coverage_Desc = Convert.ToString(reader["Fld_Desc"], CultureInfo.InvariantCulture); }
            return obje;
        }
        public override List<RIMS_Base.CGeneral> GetGeneralClaimTypes()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GeneralClaimType_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obje = new CGeneral();
                    obje = MapFromGeneralClaimTypes(reader);
                    results.Add(obje);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromGeneralClaimTypes(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obje = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_General_Claim_Type"])) { obje.PK_General_Claim_Type = Convert.ToDecimal(reader["PK_General_Claim_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc"])) { obje.GClaimType_Fld_Desc = Convert.ToString(reader["Fld_Desc"], CultureInfo.InvariantCulture); }
            return obje;
        }

        public override List<RIMS_Base.CGeneral> GetAutoClaimTypes()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoClaimType_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obje = new CGeneral();
                    obje = MapFromAutoClaimTypes(reader);
                    results.Add(obje);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromAutoClaimTypes(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obje = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_Auto_Claim_Type"])) { obje.PK_Auto_Claim_Type = Convert.ToDecimal(reader["PK_Auto_Claim_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc"])) { obje.AClaimType_Fld_Desc = Convert.ToString(reader["Fld_Desc"], CultureInfo.InvariantCulture); }
            return obje;
        }

        public override List<RIMS_Base.CGeneral> GetInjuredTypes()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("InjuredType_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obje = new CGeneral();
                    obje = MapFromInjuredTypes(reader);
                    results.Add(obje);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral MapFromInjuredTypes(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obje = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_Injured_Type"])) { obje.PK_Injured_Type = Convert.ToDecimal(reader["PK_Injured_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc"])) { obje.InjuredType_Fld_Desc = Convert.ToString(reader["Fld_Desc"], CultureInfo.InvariantCulture); }
            return obje;
        }
        public override List<RIMS_Base.CGeneral> GetClaimantTypes()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("ClaimantType_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obje = new CGeneral();
                    obje = MapFromClaimnatType(reader);
                    results.Add(obje);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral MapFromClaimnatType(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obje = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_Claimant_Type"])) { obje.PK_Claimant_Type = Convert.ToDecimal(reader["PK_Claimant_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc"])) { obje.ClaimantType_Fld_Desc = Convert.ToString(reader["Fld_Desc"], CultureInfo.InvariantCulture); }           
            return obje;
        }

        public override List<RIMS_Base.CGeneral> GetAllState()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("State_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obje = new CGeneral();
                    obje = MapFrom(reader);
                    results.Add(obje);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }              
        protected RIMS_Base.Dal.CGeneral MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obje = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obje.PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_state"])) { obje.FLD_state = Convert.ToString(reader["FLD_state"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_abbreviation"])) { obje.FLD_abbreviation = Convert.ToString(reader["FLD_abbreviation"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Code"])) { obje.Code = Convert.ToString(reader["Code"], CultureInfo.InvariantCulture); }
            return obje;
        }
        public override List<RIMS_Base.CGeneral> GetAttachamentType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Attachment_Type_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objchment_Type = new CGeneral();
                    objchment_Type = MapFromAttachment(reader);
                    results.Add(objchment_Type);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region GetVendorType
        /// <summary>
        /// Get vendor Type 
        /// firoz shaikh
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public override List<RIMS_Base.CGeneral> GetVendorType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Vendor_Type_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objchment_Type = new CGeneral();
                    objchment_Type = MapFromVendorType(reader);
                    results.Add(objchment_Type);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral MapFromVendorType(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objor_Type = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { objor_Type.VendorType_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { objor_Type.VendorType_FLD_Desc = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_DescO"])) { objor_Type.VendorType_FLD_DescO = Convert.ToString(reader["FLD_DescO"], CultureInfo.InvariantCulture); }
            return objor_Type;
        }

        #endregion

        protected RIMS_Base.Dal.CGeneral MapFromAttachment(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objAttachment_Type = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { objAttachment_Type.PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { objAttachment_Type.FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { objAttachment_Type.FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }
            return objAttachment_Type;
        }

        public override List<RIMS_Base.CGeneral> GetSupportedDocumentType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("SupDocType_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objchment_Type = new CGeneral();
                    objchment_Type = MapFromSuppDocs(reader);
                    results.Add(objchment_Type);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromSuppDocs(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_Supp_Doc_Type"])) { obj_Doc_Type.PK_Supp_Doc_Type = Convert.ToDecimal(reader["PK_Supp_Doc_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Description"])) { obj_Doc_Type.Description = Convert.ToString(reader["Description"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Payroll_PK_ID"])) { obj_Doc_Type.Payroll_PK_ID = Convert.ToDecimal(reader["Payroll_PK_ID"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Payroll_FLD_desc"])) { obj_Doc_Type.FLD_desc = Convert.ToString(reader["Payroll_FLD_desc"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Payroll_FLD_code"])) { obj_Doc_Type.Payroll_FLD_code = Convert.ToString(reader["Payroll_FLD_code"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Major_class_code_PK_ID"])) { obj_Doc_Type.Major_class_code_PK_ID = Convert.ToDecimal(reader["Major_class_code_PK_ID"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Major_class_code_FLD_desc"])) { obj_Doc_Type.Major_class_code_FLD_desc = Convert.ToString(reader["Major_class_code_FLD_desc"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Major_class_code_FLD_code"])) { obj_Doc_Type.Major_class_code_FLD_code = Convert.ToString(reader["Major_class_code_FLD_code"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_cond_act_PK_ID"])) { obj_Doc_Type.Loss_cond_act_PK_ID = Convert.ToDecimal(reader["Loss_cond_act_PK_ID"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_cond_act_FLD_desc"])) { obj_Doc_Type.Loss_cond_act_FLD_desc = Convert.ToString(reader["Loss_cond_act_FLD_desc"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_cond_act_FLD_code"])) { obj_Doc_Type.Loss_cond_act_FLD_code = Convert.ToString(reader["Loss_cond_act_FLD_code"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["_Loss_cond_recovery_PK_ID"])) { obj_Doc_Type._Loss_cond_recovery_PK_ID = Convert.ToDecimal(reader["_Loss_cond_recovery_PK_ID"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["_Loss_cond_recovery_FLD_desc"])) { obj_Doc_Type._Loss_cond_recovery_FLD_desc = Convert.ToString(reader["_Loss_cond_recovery_FLD_desc"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["_Loss_cond_recovery_FLD_code"])) { obj_Doc_Type._Loss_cond_recovery_FLD_code = Convert.ToString(reader["_Loss_cond_recovery_FLD_code"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_coverage_code_PK_ID"])) { obj_Doc_Type.Loss_coverage_code_PK_ID = Convert.ToDecimal(reader["Loss_coverage_code_PK_ID"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_coverage_code_FLD_desc"])) { obj_Doc_Type.Loss_coverage_code_FLD_desc = Convert.ToString(reader["Loss_coverage_code_FLD_desc"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_coverage_code_FLD_code"])) { obj_Doc_Type.Loss_coverage_code_FLD_code = Convert.ToString(reader["Loss_coverage_code_FLD_code"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_coverage_code_FLD_state"])) { obj_Doc_Type.Loss_coverage_code_FLD_state = Convert.ToString(reader["Loss_coverage_code_FLD_state"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Injury_type_PK_ID"])) { obj_Doc_Type.Injury_type_PK_ID = Convert.ToDecimal(reader["Injury_type_PK_ID"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Injury_type_FLD_desc"])) { obj_Doc_Type.Injury_type_FLD_desc = Convert.ToString(reader["Injury_type_FLD_desc"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Injury_type_FLD_code"])) { obj_Doc_Type.Injury_type_FLD_code = Convert.ToString(reader["Injury_type_FLD_code"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Property_Damage_PK_ID"])) { obj_Doc_Type.Property_Damage_PK_ID = Convert.ToDecimal(reader["Property_Damage_PK_ID"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Property_Damage_FLD_desc"])) { obj_Doc_Type.Property_Damage_FLD_desc = Convert.ToString(reader["Property_Damage_FLD_desc"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Property_Damage_FLD_code"])) { obj_Doc_Type.Property_Damage_FLD_code = Convert.ToString(reader["Property_Damage_FLD_code"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_cond_loss_PK_ID"])) { obj_Doc_Type.Loss_cond_loss_PK_ID = Convert.ToDecimal(reader["Loss_cond_loss_PK_ID"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_cond_loss_FLD_desc"])) { obj_Doc_Type.Loss_cond_loss_FLD_desc = Convert.ToString(reader["Loss_cond_loss_FLD_desc"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_cond_loss_FLD_code"])) { obj_Doc_Type.Loss_cond_loss_FLD_code = Convert.ToString(reader["Loss_cond_loss_FLD_code"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Settlement_method_PK_ID"])) { obj_Doc_Type.Settlement_method_PK_ID = Convert.ToDecimal(reader["Settlement_method_PK_ID"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Settlement_method_FLD_desc"])) { obj_Doc_Type.Settlement_method_FLD_desc = Convert.ToString(reader["Settlement_method_FLD_desc"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Settlement_method_FLD_code"])) { obj_Doc_Type.Settlement_method_FLD_code = Convert.ToString(reader["Settlement_method_FLD_code"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Attorney_form_PK_ID"])) { obj_Doc_Type.Attorney_form_PK_ID = Convert.ToDecimal(reader["Attorney_form_PK_ID"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Attorney_form_FLD_desc"])) { obj_Doc_Type.Attorney_form_FLD_desc = Convert.ToString(reader["Attorney_form_FLD_desc"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Attorney_form_FLD_code"])) { obj_Doc_Type.Attorney_form_FLD_code = Convert.ToString(reader["Attorney_form_FLD_code"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_cond_settlement_PK_ID"])) { obj_Doc_Type.Loss_cond_settlement_PK_ID = Convert.ToDecimal(reader["Loss_cond_settlement_PK_ID"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_cond_settlement_FLD_desc"])) { obj_Doc_Type.Loss_cond_settlement_FLD_desc = Convert.ToString(reader["Loss_cond_settlement_FLD_desc"], CultureInfo.InvariantCulture); }
            //if (!Convert.IsDBNull(reader["Loss_cond_settlement_FLD_code"])) { obj_Doc_Type.Loss_cond_settlement_FLD_code = Convert.ToString(reader["Loss_cond_settlement_FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }
        public override List<RIMS_Base.CGeneral> GetPayroll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Payroll_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objoyer_Payroll_Table = new CGeneral();
                    objoyer_Payroll_Table = MapFromPayroll(reader);
                    results.Add(objoyer_Payroll_Table);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromPayroll(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.Payroll_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.Payroll_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.Payroll_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }
        public override List<RIMS_Base.CGeneral> GetLossCondtionAct()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LossConditionAct_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_Condition_Act = new CGeneral();
                    obj_Condition_Act = MapFromLossCondtionAct(reader);
                    results.Add(obj_Condition_Act);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromLossCondtionAct(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.Loss_cond_act_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.Loss_cond_act_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.Loss_cond_act_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }

        public override List<RIMS_Base.CGeneral> GetLossCondtionRecovery()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LossConditionsRecovery_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_Conditions_Recovery = new CGeneral();
                    obj_Conditions_Recovery = MapFromLossCondtionRecovery(reader);
                    results.Add(obj_Conditions_Recovery);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromLossCondtionRecovery(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.Loss_cond_recovery_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.Loss_cond_recovery_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.Loss_cond_recovery_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }

        public override List<RIMS_Base.CGeneral> GetLossCoverageCode()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LossCoverageCode_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_Coverage_Code = new CGeneral();
                    obj_Coverage_Code = MapFromLossCoverageCode(reader);
                    results.Add(obj_Coverage_Code);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromLossCoverageCode(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.Loss_coverage_code_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.Loss_coverage_code_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.Loss_coverage_code_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_state"])) { obj_Doc_Type.Loss_coverage_code_FLD_state = Convert.ToString(reader["FLD_state"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }
        public override List<RIMS_Base.CGeneral> GetPropertyDamage()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropertyDamage_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objerty_Damage = new CGeneral();
                    objerty_Damage = MapFromPropertyDamage(reader);
                    results.Add(objerty_Damage);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromPropertyDamage(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.Property_Damage_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.Property_Damage_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.Property_Damage_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }

        public override List<RIMS_Base.CGeneral> GetLossConditionLoss()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Lossconditionsloss_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_conditions_loss = new CGeneral();
                    obj_conditions_loss = MapFromLossConditionLoss(reader);
                    results.Add(obj_conditions_loss);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromLossConditionLoss(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.Loss_cond_loss_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.Loss_cond_loss_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.Loss_cond_loss_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }

        public override List<RIMS_Base.CGeneral> GetAttornyForm()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AttorneyForm_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromAttornyForm(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromAttornyForm(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.Attorney_form_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.Attorney_form_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.Attorney_form_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }
        public override List<RIMS_Base.CGeneral> GetSettlementMethod()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("MethodOfSettlement_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objod_Of_Settlement = new CGeneral();
                    objod_Of_Settlement = MapFromSettlementMethod(reader);
                    results.Add(objod_Of_Settlement);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromSettlementMethod(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.Settlement_method_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.Settlement_method_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.Settlement_method_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }
        public override List<RIMS_Base.CGeneral> GetInjuryType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Select_Injury_Code");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objry_Code = new CGeneral();
                    objry_Code = MapFromInjuryType(reader);
                    results.Add(objry_Code);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromInjuryType(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.Injury_type_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.Injury_type_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.injury_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }
        public override List<RIMS_Base.CGeneral> GetMajorClassCode()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("MajorClassCode_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objr_Class_Code = new CGeneral();
                    objr_Class_Code = MapFromMajorClassCode(reader);
                    results.Add(objr_Class_Code);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromMajorClassCode(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.Major_class_code_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.Major_class_code_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.Major_class_code_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }
        public override List<RIMS_Base.CGeneral> GetLossCondSettlement()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LossConditionsSettlement_Select");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_Conditions_Settlement = new CGeneral();
                    obj_Conditions_Settlement = MapFromLossCondSettlement(reader);
                    results.Add(obj_Conditions_Settlement);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromLossCondSettlement(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.Loss_cond_settlement_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.Loss_cond_settlement_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.Loss_cond_settlement_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }
        public override List<RIMS_Base.CGeneral> GetPayCode(string m_strPayId)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckWriting_GetPayCode");
                dbHelper.AddInParameter(cmd, "@TableName", DbType.String, m_strPayId);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objmnity = new CGeneral();
                    objmnity = MapFromPayCode(reader);
                    results.Add(objmnity);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }

        }
        protected RIMS_Base.Dal.CGeneral MapFromPayCode(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objmnity = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["Trans_Type"])) { objmnity.Trans_Type = Convert.ToDecimal(reader["Trans_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Trans_Code"])) { objmnity.Trans_Code = Convert.ToString(reader["Trans_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Trans_Code_Description"])) { objmnity.Trans_Code_Description = Convert.ToString(reader["Trans_Code_Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Type"])) { objmnity.Type = Convert.ToString(reader["Type"], CultureInfo.InvariantCulture); }
            return objmnity;
        }

        //................... NCCI Nature.......................//

        public override List<RIMS_Base.CGeneral> GetNcciNature()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Select_NCCINature");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objNcc = new CGeneral();
                    objNcc = MapFromNCCI(reader);
                    results.Add(objNcc);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromNCCI(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objNcci = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_Id"])) { objNcci.NCCI_Nature_PK_Id = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Code"])) { objNcci.NCCI_Nature_Fld_Code = Convert.ToString(reader["Fld_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc_1"])) { objNcci.NCCI_Nature_Fld_Desc_1 = Convert.ToString(reader["Fld_Desc_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc2"])) { objNcci.NCCI_Nature_Fld_Desc2 = Convert.ToString(reader["Fld_Desc2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Type"])) { objNcci.NCCI_Nature_Claim_Type = Convert.ToString(reader["Claim_Type"], CultureInfo.InvariantCulture); }
            return objNcci;
        }

        public override List<RIMS_Base.CGeneral> GetNcciCause()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Select_NCCICause");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objeNccCause = new CGeneral();
                    objeNccCause = MapNcciCause(reader);
                    results.Add(objeNccCause);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapNcciCause(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCause = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_id"])) { objCause.NCCI_Cause_PK_IDNCC = Convert.ToDecimal(reader["PK_id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Code"])) { objCause.NCCI_Cause_FLD_CODE = Convert.ToString(reader["Fld_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc_1"])) { objCause.NCCI_Cause_Fld_DESC_1 = Convert.ToString(reader["Fld_Desc_1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc2"])) { objCause.NCCI_Cause_Fld_DESC2 = Convert.ToString(reader["Fld_Desc2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Type"])) { objCause.NCCI_Cause_CLAIM_TYPE = Convert.ToString(reader["Claim_Type"], CultureInfo.InvariantCulture); }
            return objCause;
        }

        public override List<RIMS_Base.CGeneral> GetNcciCode()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Select_NCCICode");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objCode = new CGeneral();
                    objCode = MapFromNccCode(reader);
                    results.Add(objCode);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral MapFromNccCode(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objNccCode = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { objNccCode.NCCI_Code_PK_IDNccCode = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { objNccCode.NCCI_Code_FLD_descNccdesc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }

            if (!Convert.IsDBNull(reader["FLD_code"])) { objNccCode.NCCI_Code_FLD_codeNccCode = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return objNccCode;
        }

        public override List<RIMS_Base.CGeneral> GetWcMinorType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_MinorType]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objWcminor = new CGeneral();
                    objWcminor = MapWcMinor(reader);
                    results.Add(objWcminor);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapWcMinor(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_minor = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_minor.PK_ID_Minor = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_minor.FLD_desc_Minor = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_minor.FLD_code_Minor = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_minor;
        }

        public override List<RIMS_Base.CGeneral> GetWcMajorType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_MajorType]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objWcmajor = new CGeneral();
                    objWcmajor = MapWcMajor(reader);
                    results.Add(objWcmajor);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapWcMajor(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_major = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_major.PK_ID_Major = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_major.FLD_desc_Major = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_major.FLD_code_Minor = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_major;
        }
        public override List<RIMS_Base.CGeneral> GetHazardCode()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_Hazard_Code]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objHazard = new CGeneral();
                    objHazard = MapHazard(reader);
                    results.Add(objHazard);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapHazard(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Hazard = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_Id"])) { obj_Hazard.PK_Id_Hazard = Convert.ToDecimal(reader["PK_Id"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc1"])) { obj_Hazard.Fld_Desc1_Hazard = Convert.ToString(reader["Fld_Desc1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc2"])) { obj_Hazard.Fld_Desc2_Hazard = Convert.ToString(reader["Fld_Desc2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Code"])) { obj_Hazard.Fld_Code_Hazard = Convert.ToString(reader["Fld_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Type"])) { obj_Hazard.Claim_Type_Hazard = Convert.ToString(reader["Claim_Type"], CultureInfo.InvariantCulture); }

            return obj_Hazard;
        }

        public override List<RIMS_Base.CGeneral> GetFraudClaim()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_Fraud_Claim]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objFraud = new CGeneral();
                    objFraud = MapFraud(reader);
                    results.Add(objFraud);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral MapFraud(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Fraud = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Fraud.PK_ID_Fraud = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Fraud.FLD_desc_Fraud = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Fraud.FLD_code_Fraud = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Fraud;
        }

        public override List<RIMS_Base.CGeneral> GetBodyParts()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_Body_Parts]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objBody = new CGeneral();
                    objBody = MapBodyParts(reader);
                    results.Add(objBody);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapBodyParts(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Body = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Body.PK_ID_Body = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Body.FLD_desc_Body = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Body.FLD_code_Body = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Body;
        }

        public override List<RIMS_Base.CGeneral> GetCounty()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_County]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objCounty = new CGeneral();
                    objCounty = MapCounty(reader);
                    results.Add(objCounty);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral MapCounty(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_County = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_County.PK_ID_County = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_county"])) { obj_County.FLD_county = Convert.ToString(reader["FLD_county"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_County.FLD_code_County = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_state"])) { obj_County.FLD_state_County = Convert.ToString(reader["FLD_state"], CultureInfo.InvariantCulture); }

            return obj_County;
        }

        public override List<RIMS_Base.CGeneral> GetPreInjury()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_PreInjuryWage]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objpre = new CGeneral();
                    objpre = Mappreinjury(reader);
                    results.Add(objpre);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral Mappreinjury(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_pre = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_pre.PK_ID_pre = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_pre.FLD_desc_pre = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_pre.FLD_code_pre = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }


            return obj_pre;
        }
        public override List<RIMS_Base.CGeneral> GetManagedCareOrg()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_ManagedCoreOrg]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objmanaged = new CGeneral();
                    objmanaged = Mapmanaged(reader);
                    results.Add(objmanaged);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral Mapmanaged(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Manage = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Manage.PK_ID_Manage = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Manage.FLD_desc_Manage = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Manage.FLD_code_Manage = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }


            return obj_Manage;
        }

        public override List<RIMS_Base.CGeneral> GetClaimCause()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_ClaimCause]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objclaim = new CGeneral();
                    objclaim = Mapclaimcause(reader);
                    results.Add(objclaim);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral Mapclaimcause(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Claim = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Claim.Claim_Cause_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Claim.Claim_Cause_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Claim.Claim_Cause_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_FROI"])) { obj_Claim.Claim_Cause_Fld_FROI = Convert.ToString(reader["Fld_FROI"], CultureInfo.InvariantCulture); }
            return obj_Claim;
        }

        public override List<RIMS_Base.CGeneral> GetBenificary()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_Benificary]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objBeni = new CGeneral();
                    objBeni = Mapbenificary(reader);
                    results.Add(objBeni);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral Mapbenificary(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Beni = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Beni.Benificary_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Beni.Benificary_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Beni.Benificary_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }
            return obj_Beni;
        }

        public override List<RIMS_Base.CGeneral> GetClaimNature()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_ClaimNature]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objclaimNature = new CGeneral();
                    objclaimNature = Mapclaimnature(reader);
                    results.Add(objclaimNature);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral Mapclaimnature(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_ClaimNature = new RIMS_Base.Dal.CGeneral();
            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_ClaimNature.Claim_Nature_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_ClaimNature.Claim_Nature_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_ClaimNature.Claim_Nature_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }
            return obj_ClaimNature;
        }

        public override List<RIMS_Base.CGeneral> GetInjuryCode()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Select_Injury_Code");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objry_Code = new CGeneral();
                    objry_Code = MapFromInjuryCode(reader);
                    results.Add(objry_Code);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromInjuryCode(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Doc_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Doc_Type.injury_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Doc_Type.injury_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Doc_Type.injury_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Doc_Type;
        }

        public override List<RIMS_Base.CGeneral> GetRoadSurface()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Liability_Select_Surface]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_surface = new CGeneral();
                    obj_surface = Mapsurface(reader);
                    results.Add(obj_surface);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral Mapsurface(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_surface_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_surface_Type.Surface_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_surface_Type.Surface_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_surface_Type.Surface_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_surface_Type;
        }


        public override List<RIMS_Base.CGeneral> GetRoadType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Liability_Select_RoadType]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_RoadType = new CGeneral();
                    obj_RoadType = Maproad(reader);
                    results.Add(obj_RoadType);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral Maproad(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Road_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Road_Type.Road_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Road_Type.Road_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Road_Type.Road_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Road_Type;
        }

        public override List<RIMS_Base.CGeneral> GetComprehensive()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Liability_Select_Compehensive]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_comp = new CGeneral();
                    obj_comp = MapComp(reader);
                    results.Add(obj_comp);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral MapComp(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_Comp_Type = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_Comp_Type.comprehensive_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_Comp_Type.comprehensive_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_Comp_Type.comprehensive_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_Comp_Type;
        }

        public override List<RIMS_Base.CGeneral> GetOriginalCost()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Liability_Select_OriginalCost]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_ori = new CGeneral();
                    obj_ori = Maporg(reader);
                    results.Add(obj_ori);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral Maporg(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_orgi = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { obj_orgi.orgcost_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { obj_orgi.orgcost_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { obj_orgi.orgcost_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return obj_orgi;
        }

      


        public override List<RIMS_Base.CGeneral> GetLiabilitymajor()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Liability_Select_MajorClaim]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_major1 = new CGeneral();
                    obj_major1 = Mapmajor(reader);
                    results.Add(obj_major1);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral Mapmajor(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objmajor = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { objmajor.Lmajor_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { objmajor.Lmajor_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { objmajor.Lmajor_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return objmajor;
        }

        public override List<RIMS_Base.CGeneral> GetLiabilityminor()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Liability_Select_MinorClaim]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    
                    CGeneral obj_minor1 = new CGeneral();
                    obj_minor1 = Mapminor(reader);
                    results.Add(obj_minor1);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral Mapminor(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objminor = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { objminor.Lminor_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { objminor.Lminor_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { objminor.Lminor_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return objminor;
        }

        public override List<RIMS_Base.CGeneral> Getincident()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Liability_Select_IncidentType]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_inc = new CGeneral();
                    obj_inc = Mapinc(reader);
                    results.Add(obj_inc);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral Mapinc(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral obj_incweather = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_Weather_Incident"])) { obj_incweather.PK_Weather_Inc = Convert.ToDecimal(reader["PK_Weather_Incident"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Description"])) { obj_incweather.WeatherDescription = Convert.ToString(reader["Description"], CultureInfo.InvariantCulture); }


            return obj_incweather;
        }

        public override List<RIMS_Base.CGeneral> GetWeatherCondition()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Liability_Select_Weather]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_weather = new CGeneral();
                    obj_weather = Mapweather(reader);
                    results.Add(obj_weather);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral Mapweather(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objweather = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { objweather.Weather_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { objweather.Weather_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { objweather.Weather_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return objweather;
        }


        public override List<RIMS_Base.CGeneral> GetCollision_Deductible()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Liability_Select_Collision_Deductible]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_Collision = new CGeneral();
                    obj_Collision = MapCollision(reader);
                    results.Add(obj_Collision);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral MapCollision(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCollision = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { objCollision.Collision_PK_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_desc"])) { objCollision.Collision_FLD_desc = Convert.ToString(reader["FLD_desc"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_code"])) { objCollision.Collision_FLD_code = Convert.ToString(reader["FLD_code"], CultureInfo.InvariantCulture); }

            return objCollision;
        }

        public override List<RIMS_Base.CGeneral> Classification_code()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("[Select_Classification_Code]");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral obj_classification = new CGeneral();
                    obj_classification = MapClassificationCode(reader);
                    results.Add(obj_classification);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapClassificationCode(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCollision = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["NCCI_Classification_Code"])) { objCollision.Classification_ID = Convert.ToDecimal(reader["NCCI_Classification_Code"], CultureInfo.InvariantCulture); }
           
            return objCollision;
        }

        public override List<RIMS_Base.CGeneral> GetAdjustorNoteType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GetAdjustorNoteType");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromAdjusterNoteType(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral MapFromAdjusterNoteType(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["Pk_Adjustor_Note_Type_ID"])) { objCGeneral.Pk_Adjustor_Note_Type_ID = Convert.ToDecimal(reader["Pk_Adjustor_Note_Type_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { objCGeneral.Adjustor_Note_Type_FLD_Desc = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }
        public override List<RIMS_Base.CGeneral> GetAllEntity()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Entity_SelectAll");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromEntity(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override List<RIMS_Base.CGeneral> GetAllEntityByLoggedInUser(Decimal pk_Security_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Entity_SelectBySecurityId");
                dbHelper.AddInParameter(cmd, "@PK_Security_ID", DbType.Decimal, pk_Security_Id);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromEntity(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected RIMS_Base.Dal.CGeneral MapFromEntity(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_Entity"])) { objCGeneral.PK_Entity = Convert.ToDecimal(reader["PK_Entity"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Description"])) { objCGeneral.Entity_Description = Convert.ToString(reader["Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Code"])) { objCGeneral.Entity_Code = Convert.ToString(reader["Code"], CultureInfo.InvariantCulture); }
            
            return objCGeneral;
        }
        public override List<RIMS_Base.CGeneral> GetAllFacility()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Facility_SelectAll");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromFacility(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromFacility(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { objCGeneral.PK_Facility = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { objCGeneral.Facility_Description = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }
        public override List<RIMS_Base.CGeneral> GetAllCostCenter()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CostCenter_SelectAll");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromCC(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromCC(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { objCGeneral.PK_CostCenterId = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Subsidiary"])) { objCGeneral.CC_SubsiDiary = Convert.ToString(reader["Subsidiary"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }
        public override List<RIMS_Base.CGeneral> GetAllMobileType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("MobileType_SelectAll");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromMobileType(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromMobileType(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { objCGeneral.PK_MobileType = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_DEsc"])) { objCGeneral.Mobile_Description = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }
        public override List<RIMS_Base.CGeneral> GetAllStationaryType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("StationaryType_SelectAll");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromStationaryType(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromStationaryType(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { objCGeneral.PK_StationaryType = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_DEsc"])) { objCGeneral.Stationary_Description = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }
        public override List<RIMS_Base.CGeneral> GetAllLandStatus()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("LandStatus_SelectAll");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromLandStatus(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromLandStatus(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_Land_Status"])) { objCGeneral.PK_Land_Status = Convert.ToDecimal(reader["PK_Land_Status"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Description"])) { objCGeneral.Land_Description = Convert.ToString(reader["Description"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }

        public override List<RIMS_Base.CGeneral> GetAllFloodZone()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("FloodZone_SelectAll");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromFloodZone(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromFloodZone(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_Flood_Zone"])) { objCGeneral.PK_Flood_Zone = Convert.ToDecimal(reader["PK_Flood_Zone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc"])) { objCGeneral.Flood_Description = Convert.ToString(reader["Fld_Desc"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }

        
        public override List<RIMS_Base.CGeneral> GetAllConstrType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Construction_SelectAll");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromConstr(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromConstr(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_Construction_Type"])) { objCGeneral.PK_Constr_Type = Convert.ToDecimal(reader["PK_Construction_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Description"])) { objCGeneral.Constr_Description = Convert.ToString(reader["Description"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }

        public override List<RIMS_Base.CGeneral> GetAllLocation()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Location_SelectAll");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromLocation(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromLocation(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { objCGeneral.PK_Location_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_Desc"])) { objCGeneral.Location_Description = Convert.ToString(reader["FLD_Desc"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }

        public override List<RIMS_Base.CGeneral> GetPropertyLocationCode()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GetPropertyLocation");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromPropertyLocation(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromPropertyLocation(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_Property_Location_Code"])) { objCGeneral.PK_Property_Location_Code = Convert.ToDecimal(reader["PK_Property_Location_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc"])) { objCGeneral.FLD_Location_Desc = Convert.ToString(reader["Fld_Desc"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }

        public override List<RIMS_Base.CGeneral> GetPropertyType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GetPropertyType");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromPropertyType(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromPropertyType(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_Property_Type"])) { objCGeneral.PK_Property_Type = Convert.ToDecimal(reader["PK_Property_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc"])) { objCGeneral.FLD_PropertyType_Desc = Convert.ToString(reader["Fld_Desc"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }


        public override List<RIMS_Base.CGeneral> GetGender()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GetGender");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromGender(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromGender(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_Gender"])) { objCGeneral.PK_Gender_ID = Convert.ToDecimal(reader["PK_Gender"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc"])) { objCGeneral.FLD_Gender_Desc = Convert.ToString(reader["Fld_Desc"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }


        public override List<RIMS_Base.CGeneral> GetDriverStatus()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GetDriverStatus");
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CGeneral> results = new List<RIMS_Base.CGeneral>();
                while (reader.Read())
                {
                    CGeneral objrney_Form = new CGeneral();
                    objrney_Form = MapFromStatus(reader);
                    results.Add(objrney_Form);
                }
                reader.Close();
                cmd = null;
                dbHelper = null;
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected RIMS_Base.Dal.CGeneral MapFromStatus(IDataReader reader)
        {
            RIMS_Base.Dal.CGeneral objCGeneral = new RIMS_Base.Dal.CGeneral();

            if (!Convert.IsDBNull(reader["PK_ID"])) { objCGeneral.PK_Status_ID = Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fld_Desc"])) { objCGeneral.FLD_Status_Desc = Convert.ToString(reader["Fld_Desc"], CultureInfo.InvariantCulture); }
            return objCGeneral;
        }

        public override DataSet GetCountyByState(string m_strState)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("County_S_ByState");
                dbHelper.AddInParameter(cmd, "@State", DbType.String, m_strState);
                DataSet m_dsCommon = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;
                //return results;
                return m_dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override DataSet GetBatteries()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsBattery = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_S_Batteries");
                m_dsBattery = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;

                return m_dsBattery;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetTowerType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsTower = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_S_TowerType");
                m_dsTower = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;

                return m_dsTower;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetFireProtection()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsFP = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_S_FireProtection");
                m_dsFP = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;

                return m_dsFP;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override DataSet GetPolicyType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsFP = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_PolicyType");
                m_dsFP = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;

                return m_dsFP;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetAllAdHocFields(string ClaimType)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet m_dsFP = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Get_AdHocFields");
                dbHelper.AddInParameter(cmd, "@ClaimType", DbType.String, ClaimType);
                m_dsFP = dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;

                return m_dsFP;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
