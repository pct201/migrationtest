#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{
    [Serializable]
    public abstract class CGeneral
    {
        #region Constructor
        public CGeneral()
        {
            this._pK_ID = -1;
            this._fLD_state = string.Empty;
            this._fLD_abbreviation = string.Empty;
            this._code = string.Empty;
            this._fLD_desc = string.Empty;
            this._fLD_code = string.Empty;
            this._pK_Supp_Doc_Type = -1;
            this._description = string.Empty;
            this._payroll_pK_ID = -1;
            this._payroll_fLD_desc = string.Empty;
            this._payroll_fLD_code = string.Empty;
            this._loss_cond_act_pK_ID = -1;
            this._loss_cond_act_fLD_desc = string.Empty;
            this._loss_cond_act_fLD_code = string.Empty;
            this._loss_cond_recovery_pK_ID = -1;
            this._loss_cond_recovery_fLD_desc = string.Empty;
            this._loss_cond_recovery_fLD_code = string.Empty;
            this._loss_coverage_code_pK_ID = -1;
            this._loss_coverage_code_fLD_desc = string.Empty;
            this._loss_coverage_code_fLD_code = string.Empty;
            this._loss_coverage_code_fLD_state = string.Empty;
            this._Property_Damage_pK_ID = -1;
            this._Property_Damage_fLD_desc = string.Empty;
            this._Property_Damage_fLD_code = string.Empty;
            this._loss_cond_loss_pK_ID = -1;
            this._loss_cond_loss_fLD_desc = string.Empty;
            this._loss_cond_loss_fLD_code = string.Empty;
            this._attorney_form_pK_ID = -1;
            this._attorney_form_fLD_desc = string.Empty;
            this._attorney_form_fLD_code = string.Empty;
            this._settlement_method_pK_ID = -1;
            this._settlement_method_fLD_desc = string.Empty;
            this._settlement_method_fLD_code = string.Empty;
            this._injury_type_pK_ID = -1;
            this._injury_type_fLD_desc = string.Empty;
            this._injury_type_fLD_code = string.Empty;
            this._major_class_code_pK_ID = -1;
            this._major_class_code_fLD_desc = string.Empty;
            this._major_class_code_fLD_code = string.Empty;
            this._loss_cond_settlement_pK_ID = -1;
            this._loss_cond_settlement_fLD_desc = string.Empty;
            this._loss_cond_settlement_fLD_code = string.Empty;

            this.Collision_pK_ID = -1;
            this.Collision_fLD_desc = string.Empty;
            this.Collision_fLD_code = string.Empty;

            this.comprehensive_pK_ID = -1;
            this.comprehensive_fLD_desc = string.Empty;
            this.comprehensive_fLD_code = string.Empty;

            this.orgcost_pK_ID = -1;
            this.orgcost_fLD_desc = string.Empty;
            this.orgcost_fLD_code = string.Empty;

            //road Type
            this.Road_pK_ID = -1;
            this.Road_fLD_desc = string.Empty;
            this.Road_fLD_code = string.Empty;

            // Surface Type
            this.surface_pK_ID = -1;
            this.surface_fLD_desc = string.Empty;
            this.surface_fLD_code = string.Empty;

            //injury Code
            this.injury_pK_ID = -1;
            this.injury_fLD_desc = string.Empty;
            this.injury_fLD_code = string.Empty;


            // For Benificiary Code


            this._Benificary_pK_ID = -1;
            this._Benificary_fLD_desc = string.Empty;
            this._Benificary_fLD_code = string.Empty;


            //For Claim Nature 

            this._Claim_Nature_pK_ID = -1;
            this._Claim_Nature_fLD_desc = string.Empty;
            this._Claim_Nature_fLD_code = string.Empty;

            //For Medical Indemnity Expenses
            this._trans_Type = -1;
            this._trans_Code = string.Empty;
            this._trans_Code_Description = string.Empty;
            this._type = string.Empty;
            //for NCCI_Nature
            this._NCCI_Nature_fld_Code = string.Empty;
            this._NCCI_Nature_fld_Desc_1 = string.Empty;
            this._NCCI_Nature_fld_Desc2 = string.Empty;
            this._NCCI_Nature_claim_Type = string.Empty;
            //for NCCI_Cause
            this._NCCI_Cause_pK_Id = -1;
            this._NCCI_Cause_fld_Code = string.Empty;
            this._NCCI_Cause_fld_Desc_1 = string.Empty;
            this._NCCI_Cause_fld_Desc2 = string.Empty;
            this._NCCI_Cause_claim_Type = string.Empty;
            //NCCI Classification
            this._NCCI_Classification_ID = -1;
            // For Calim Cause
            this._Claim_Cause_pK_ID = -1;
            this._Claim_Cause_fLD_desc = string.Empty;
            this._Claim_Cause_fLD_code = string.Empty;
            this._Claim_Cause_fld_FROI = string.Empty;

            //for NCCI_Code
            this._NCCI_Code_pK_ID = -1;
            this._NCCI_Code_fLD_desc = string.Empty;
            this._NCCI_Code_fLD_code = string.Empty;

            //for Wc minor Type
            this._Wc_minor_pK_ID = -1;
            this._Wc_minor_fLD_desc = string.Empty;
            this._Wc_minor_fLD_code = string.Empty;

            //for Wc Mejor Type
            this._Wc_Mejor_pK_ID = -1;
            this._Wc_Mejor_fLD_desc = string.Empty;
            this._Wc_Mejor_fLD_code = string.Empty;

            // Hazard Code
            this._Hazard_pK_Id = -1;
            this._Hazard_fld_Desc_1 = string.Empty;
            this._Hazard_fld_Desc2 = string.Empty;
            this._Hazard_fld_Code = string.Empty;
            this._Hazard_claim_Type = string.Empty;

            // For Fraudulent Claim Indicator 
            this._Fraudulent_pK_ID = -1;
            this._Fraudulent_fLD_desc = string.Empty;
            this._Fraudulent_fLD_code = string.Empty;

            // Body Parts Combo
            this._Body_Parts_pK_ID = -1;
            this._Body_Parts_fLD_desc = string.Empty;
            this._Body_Parts_fLD_code = string.Empty;

            //For County Code

            this._County_pK_ID = -1;
            this._County_fLD_desc = string.Empty;
            this._County_fLD_code = string.Empty;
            this._County_fLD_state = string.Empty;

            //For pre Injury Code

            this._Pre_Injury_pK_ID = -1;
            this._Pre_Injury_fLD_desc = string.Empty;
            this._Pre_Injury_fLD_code = string.Empty;

            //For Managed care org Type
            this._Managed_care_org_pK_ID = -1;
            this._Managed_care_org_fLD_desc = string.Empty;
            this._Managed_care_org_fLD_code = string.Empty;
            //
            this.Lmajor_pK_ID = -1;
            this.Lmajor_fLD_desc = string.Empty;
            this.Lmajor_fLD_code = string.Empty;
           //
            this.Lminor_pK_ID = -1;
            this.Lminor_fLD_desc = string.Empty;
            this.Lminor_fLD_code = string.Empty;
            //
            this.Weather_pK_ID = -1;
            this.Weather_fLD_desc = string.Empty;
            this.Weather_fLD_code = string.Empty;
            //
            this._pK_Weather_Incident = -1;
            this._Weather_description = string.Empty;

            // --- Get Note Type for the Adjuster
            this._pk_Adjustor_Note_Type_ID = -1;
            this._adjustor_Note_Type_FLD_Desc = string.Empty;
            //Entity for Property Page
            this._pK_Entity=-1;
            this._Entity_description=string.Empty;
	        //Facility for Property Page,.
            this._PK_Facility_ID = -1;
            this._Facility_Description=string.Empty;
            //Cost Center
            this._PK_CostCenter_ID=-1;
            this._CostCenter_Subsidiary=string.Empty;
            //Mobile Type
            this._PK_MoibleType_ID=-1;
            this._Mobile_Description=string.Empty;
            //Stationary Type
            this._PK_StationaryType_ID=-1;
            this._Stationary_Description=string.Empty;
            //Land Status
            this._PK_Land_Status = -1;
            this._Land_Description = string.Empty;
            //Flood Zone
            this._PK_Flood_Zone = -1;
            this._Flood_Description = string.Empty;
            //Construction Type
            this._PK_Constr_Type = -1;
            this._Contstr_Description = string.Empty;
            //Location
            this._PK_Location_ID = -1;
            this._Location_Description = string.Empty;

            //Claimant Type
            this._PK_Claimant_Type=-1;
            this._ClaimantType_Fld_Desc=string.Empty;

            //Injured Type
            this._PK_Injured_Type = -1;
            this._InjuredType_Fld_Desc = string.Empty;

            //General Claim type
            this._PK_General_Claim_Type = -1;
            this._GClaimType_Fld_Desc = string.Empty;

            //Auto Claim type
            this._PK_Auto_Claim_Type = -1;
            this._AClaimType_Fld_Desc = string.Empty;
            
            // Location Code
            this._PK_Property_Location_Code = -1;
            this._FLD_Location_Desc = string.Empty;

            //Property Type
            this._PK_Property_Type = -1;
            this._FLD_PropertyType_Desc = string.Empty;

            //Driver Status
           // this._pK_Status_ID = -1;
            this._fld_Status_Desc = string.Empty;

            //Gender
          //  this._pK_Gender = -1;
            this._fld_Gender_Desc = string.Empty;
                        
        }
	       #endregion

        #region Private Variables

        private System.Decimal _pK_Status_ID;
        private System.String _fld_Status_Desc;

        private System.Decimal _pK_Gender;
        private System.String _fld_Gender_Desc;

        private System.Decimal _pK_ID;
        private System.String _fLD_state;
        private System.String _fLD_abbreviation;
        private System.String _code;
        private System.String _fLD_desc;
        private System.String _fLD_code;
        private System.Decimal _pK_Supp_Doc_Type;
        private System.String _description;
        private System.Decimal _payroll_pK_ID;
        private System.String _payroll_fLD_desc;
        private System.String _payroll_fLD_code;
        private System.Decimal _loss_cond_act_pK_ID;
        private System.String _loss_cond_act_fLD_desc;
        private System.String _loss_cond_act_fLD_code;
        private System.Decimal _loss_cond_recovery_pK_ID;
        private System.String _loss_cond_recovery_fLD_desc;
        private System.String _loss_cond_recovery_fLD_code;
        private System.Decimal _loss_coverage_code_pK_ID;
        private System.String _loss_coverage_code_fLD_desc;
        private System.String _loss_coverage_code_fLD_code;
        private System.String _loss_coverage_code_fLD_state;
        private System.Decimal _Property_Damage_pK_ID;
        private System.String _Property_Damage_fLD_desc;
        private System.String _Property_Damage_fLD_code;
        private System.Decimal _loss_cond_loss_pK_ID;
        private System.String _loss_cond_loss_fLD_desc;
        private System.String _loss_cond_loss_fLD_code;
        private System.Decimal _attorney_form_pK_ID;
        private System.String _attorney_form_fLD_desc;
        private System.String _attorney_form_fLD_code;
        private System.Decimal _settlement_method_pK_ID;
        private System.String _settlement_method_fLD_desc;
        private System.String _settlement_method_fLD_code;
        private System.Decimal _injury_type_pK_ID;
        private System.String _injury_type_fLD_desc;
        private System.String _injury_type_fLD_code;
        private System.Decimal _major_class_code_pK_ID;
        private System.String _major_class_code_fLD_desc;
        private System.String _major_class_code_fLD_code;
        private System.Decimal _loss_cond_settlement_pK_ID;
        private System.String _loss_cond_settlement_fLD_desc;
        private System.String _loss_cond_settlement_fLD_code;

        private System.Decimal Collision_pK_ID;
        private System.String Collision_fLD_desc;
        private System.String Collision_fLD_code;

        private System.Decimal _pK_Weather_Incident;
        private System.String _Weather_description;

        private System.Decimal Weather_pK_ID;
        private System.String Weather_fLD_desc;
        private System.String Weather_fLD_code;

        private System.Decimal orgcost_pK_ID;
        private System.String orgcost_fLD_desc;
        private System.String orgcost_fLD_code;

        //surface type
        private System.Decimal surface_pK_ID;
        private System.String surface_fLD_desc;
        private System.String surface_fLD_code;


        //injury code
        private System.Decimal injury_pK_ID;
        private System.String injury_fLD_desc;
        private System.String injury_fLD_code;

        private System.Decimal _trans_Type;
        private System.String _trans_Code;
        private System.String _trans_Code_Description;
        private System.String _type;

        //for Benificary code
        private System.Decimal _Benificary_pK_ID;
        private System.String _Benificary_fLD_desc;
        private System.String _Benificary_fLD_code;

        //For Claim Nature
        private System.Decimal _Claim_Nature_pK_ID;
        private System.String _Claim_Nature_fLD_desc;
        private System.String _Claim_Nature_fLD_code;

        //For Claim Cause
        private System.Decimal _Claim_Cause_pK_ID;
        private System.String _Claim_Cause_fLD_desc;
        private System.String _Claim_Cause_fLD_code;
        private System.String _Claim_Cause_fld_FROI;

        //for NCCI_Nature

        private System.Decimal _NCCI_Nature_pK_Id;
        private System.String _NCCI_Nature_fld_Code;
        private System.String _NCCI_Nature_fld_Desc_1;
        private System.String _NCCI_Nature_fld_Desc2;
        private System.String _NCCI_Nature_claim_Type;

        //for NCCI_Cause


        private System.Decimal _NCCI_Cause_pK_Id;
        private System.String _NCCI_Cause_fld_Code;
        private System.String _NCCI_Cause_fld_Desc_1;
        private System.String _NCCI_Cause_fld_Desc2;
        private System.String _NCCI_Cause_claim_Type;

        //for NCCI_Code
        private System.Decimal _NCCI_Code_pK_ID;
        private System.String _NCCI_Code_fLD_desc;
        private System.String _NCCI_Code_fLD_code;

        //for wc minor Type


        private System.Decimal _Wc_minor_pK_ID;
        private System.String _Wc_minor_fLD_desc;
        private System.String _Wc_minor_fLD_code;

        //for wc mejor Type
        private System.Decimal _Wc_Mejor_pK_ID;
        private System.String _Wc_Mejor_fLD_desc;
        private System.String _Wc_Mejor_fLD_code;

        //Hazard Code

        private System.Decimal _Hazard_pK_Id;
        private System.String _Hazard_fld_Desc_1;
        private System.String _Hazard_fld_Desc2;
        private System.String _Hazard_fld_Code;
        private System.String _Hazard_claim_Type;

        // For Fraudulent Claim Indicator 

        private System.Decimal _Fraudulent_pK_ID;
        private System.String _Fraudulent_fLD_desc;
        private System.String _Fraudulent_fLD_code;

        // Body Parts Combo

        private System.Decimal _Body_Parts_pK_ID;
        private System.String _Body_Parts_fLD_desc;
        private System.String _Body_Parts_fLD_code;

        //For County Combo
        private System.Decimal _County_pK_ID;
        private System.String _County_fLD_desc;
        private System.String _County_fLD_code;
        private System.String _County_fLD_state;

        //For pre injury combo

        private System.Decimal _Pre_Injury_pK_ID;
        private System.String _Pre_Injury_fLD_desc;
        private System.String _Pre_Injury_fLD_code;

        //For Managed care org Type
        private System.Decimal _Managed_care_org_pK_ID;
        private System.String _Managed_care_org_fLD_desc;
        private System.String _Managed_care_org_fLD_code;

        // For Vendor Type
        private System.Decimal _VendorType_PK_ID;
        private System.String _VendorType_FLD_Desc;
        private System.String _VendorType_FLD_DescO;
        //For Road Type
        private System.Decimal Road_pK_ID;
        private System.String Road_fLD_desc;
        private System.String Road_fLD_code;

        //
        private System.Decimal comprehensive_pK_ID;
        private System.String comprehensive_fLD_desc;
        private System.String comprehensive_fLD_code;
        //
        private System.Decimal Lmajor_pK_ID;
        private System.String Lmajor_fLD_desc;
        private System.String Lmajor_fLD_code;

        //
        private System.Decimal Lminor_pK_ID;
        private System.String Lminor_fLD_desc;
        private System.String Lminor_fLD_code;
        
        //-- Adjuster Note
        private System.Decimal _pk_Adjustor_Note_Type_ID;
        private System.String _adjustor_Note_Type_FLD_Desc;
        // Entity For Property Page
        private System.Decimal _pK_Entity;
        private System.String _Entity_description;
        private System.String _Entity_Code;

        //Facility For Property Page
        private System.Decimal _PK_Facility_ID;
        private System.String _Facility_Description;
        //Cost Center
        private System.Decimal _PK_CostCenter_ID;
        private System.String _CostCenter_Subsidiary;
        //Mobile Type
        private System.Decimal _PK_MoibleType_ID;
        private System.String _Mobile_Description;
        //Stationary Type
        private System.Decimal _PK_StationaryType_ID;
        private System.String _Stationary_Description;
        // Land Status
        private System.Decimal _PK_Land_Status;
        private System.String _Land_Description;
        //Flood Zone
        private System.Decimal _PK_Flood_Zone ;
        private System.String _Flood_Description;
        //Construction type
        private System.Decimal _PK_Constr_Type;
        private System.String _Contstr_Description;
        //Loaction
        private System.Decimal _PK_Location_ID;
        private System.String _Location_Description;

        //Claimant type
        private System.Decimal _PK_Claimant_Type;
        private System.String _ClaimantType_Fld_Desc;

        //Injured Type
        private System.Decimal _PK_Injured_Type;
        private System.String _InjuredType_Fld_Desc;

        //General Claim Type
        private System.Decimal _PK_General_Claim_Type;
        private System.String _GClaimType_Fld_Desc;

        //Auto Claim Type
        private System.Decimal _PK_Auto_Claim_Type;
        private System.String _AClaimType_Fld_Desc;

        //Property Type
        private System.Decimal _PK_Property_Type;
        private System.String _FLD_PropertyType_Desc;

        //Location Code
        private System.Decimal _PK_Property_Location_Code;
        private System.String _FLD_Location_Desc;

        //Liability Coverage
        private System.Decimal _PK_Liability_Coverage;
        private System.String _FLD_Coverage_Desc;

        #endregion


        //Driver Status
             

        public System.Decimal PK_Status_ID
        {
            get { return _pK_Status_ID; }
            set { _pK_Status_ID = value; }
        }
        public System.String FLD_Status_Desc
        {
            get { return _fld_Gender_Desc; }
            set { _fld_Gender_Desc = value; }
        }


        //Gender
        public System.Decimal PK_Gender_ID
        {
            get { return _pK_Gender; }
            set { _pK_Gender = value; }
        }
        public System.String FLD_Gender_Desc
        {
            get { return _fld_Gender_Desc; }
            set { _fld_Gender_Desc = value; }
        }

        //NCCI
        private System.Decimal _NCCI_Classification_ID;

        #region Public Properties
        //Liability Coverage
        public System.Decimal PK_Liability_Coverage
        {
            get { return _PK_Liability_Coverage; }
            set { _PK_Liability_Coverage = value; }
        }
        public System.String FLD_Coverage_Desc
        {
            get { return _FLD_Coverage_Desc; }
            set { _FLD_Coverage_Desc = value; }
        }


        // Location Code
        public System.Decimal PK_Property_Location_Code
        {
            get { return _PK_Property_Location_Code; }
            set { _PK_Property_Location_Code = value; }
        }
        public System.String FLD_Location_Desc
        {
            get { return _FLD_Location_Desc; }
            set { _FLD_Location_Desc = value; }
        }

        //Property Type
        public System.Decimal PK_Property_Type
        {
            get { return _PK_Property_Type; }
            set { _PK_Property_Type = value; }
        }
        public System.String FLD_PropertyType_Desc
        {
            get { return _FLD_PropertyType_Desc; }
            set { _FLD_PropertyType_Desc = value; }
        }

        //Auto Claim type
        public System.Decimal PK_Auto_Claim_Type
        {
            get { return _PK_Auto_Claim_Type; }
            set { _PK_Auto_Claim_Type = value; }
        }
        public System.String AClaimType_Fld_Desc
        {
            get { return _AClaimType_Fld_Desc; }
            set { _AClaimType_Fld_Desc = value; }
        }

        //General Claim type
        public System.Decimal PK_General_Claim_Type
        {
            get { return _PK_General_Claim_Type; }
            set { _PK_General_Claim_Type = value; }
        }
        public System.String GClaimType_Fld_Desc
        {
            get { return _GClaimType_Fld_Desc; }
            set { _GClaimType_Fld_Desc = value; }
        }

        //Injured Type
        public System.Decimal PK_Injured_Type
        {
            get { return  _PK_Injured_Type; }
            set { _PK_Injured_Type = value; }
        }
        public System.String InjuredType_Fld_Desc
        {
            get { return _InjuredType_Fld_Desc; }
            set { _InjuredType_Fld_Desc = value; }
        }

        //Claimant type
        public System.Decimal PK_Claimant_Type
        {
            get { return _PK_Claimant_Type; }
            set { _PK_Claimant_Type = value; }
        }
        public System.String ClaimantType_Fld_Desc
        {
            get { return _ClaimantType_Fld_Desc; }
            set { _ClaimantType_Fld_Desc = value; }
        }

        //NCCI CLassification
        public System.Decimal Classification_ID
        {
            get { return _NCCI_Classification_ID; }
            set { _NCCI_Classification_ID = value; }
        }
        //Loaction
        public System.Decimal PK_Location_ID
        {
            get { return _PK_Location_ID; }
            set { _PK_Location_ID = value; }
        }

        public System.String Location_Description
        {
            get { return _Location_Description; }
            set { _Location_Description = value; }
        }
        //Flood Zone
        public System.Decimal PK_Constr_Type
        {
            get { return _PK_Constr_Type; }
            set { _PK_Constr_Type = value; }
        }

        public System.String Constr_Description
        {
            get { return _Contstr_Description; }
            set { _Contstr_Description = value; }
        }

        //Flood Zone
        public System.Decimal PK_Flood_Zone
        {
            get { return _PK_Flood_Zone; }
            set { _PK_Flood_Zone = value; }
        }

        public System.String Flood_Description
        {
            get { return _Flood_Description; }
            set { _Flood_Description = value; }
        }

        //Stationary Type
        public System.Decimal PK_Land_Status
        {
            get { return _PK_Land_Status; }
            set { _PK_Land_Status = value; }
        }

        public System.String Land_Description
        {
            get { return _Land_Description; }
            set { _Land_Description = value; }
        }
        //Stationary Type
        public System.Decimal PK_StationaryType
        {
            get { return _PK_StationaryType_ID; }
            set { _PK_StationaryType_ID = value; }
        }

        public System.String Stationary_Description
        {
            get { return _Stationary_Description; }
            set { _Stationary_Description = value; }
        }
        //Mobile Type
        public System.Decimal PK_MobileType
        {
            get { return _PK_MoibleType_ID; }
            set { _PK_MoibleType_ID = value; }
        }

        public System.String Mobile_Description
        {
            get { return _Mobile_Description; }
            set { _Mobile_Description = value; }
        }
        //Cost center
        public System.Decimal PK_CostCenterId
        {
            get { return _PK_CostCenter_ID; }
            set { _PK_CostCenter_ID = value; }
        }

        public System.String CC_SubsiDiary
        {
            get { return _CostCenter_Subsidiary; }
            set { _CostCenter_Subsidiary= value; }
        }

        //Facility Property
        public System.Decimal PK_Facility
        {
            get { return _PK_Facility_ID; }
            set { _PK_Facility_ID = value; }
        }

        public System.String Facility_Description
        {
            get { return _Facility_Description; }
            set { _Facility_Description = value; }
        }
        //Entity Property
        public System.Decimal PK_Entity
        {
            get { return _pK_Entity; }
            set { _pK_Entity = value; }
        }

        public System.String Entity_Description
        {
            get { return _Entity_description; }
            set { _Entity_description = value; }
        }
        public System.String Entity_Code
        {
            get { return _Entity_Code; }
            set { _Entity_Code = value; }
        }
        //Collision

        public System.Decimal Collision_PK_ID
        {
            get { return Collision_pK_ID; }
            set { Collision_pK_ID = value; }
        }

        public System.String Collision_FLD_desc
        {
            get { return Collision_fLD_desc; }
            set { Collision_fLD_desc = value; }
        }

        public System.String Collision_FLD_code
        {
            get { return Collision_fLD_code; }
            set { Collision_fLD_code = value; }
        }


        //
        public System.Decimal PK_Weather_Inc
        {
            get { return _pK_Weather_Incident; }
            set { _pK_Weather_Incident = value; }
        }

        public System.String WeatherDescription
        {
            get { return _Weather_description; }
            set { _Weather_description = value; }
        }
        //
        public System.Decimal Weather_PK_ID
        {
            get { return Weather_pK_ID; }
            set { Weather_pK_ID = value; }
        }

        public System.String Weather_FLD_desc
        {
            get { return Weather_fLD_desc; }
            set { Weather_fLD_desc = value; }
        }

        public System.String Weather_FLD_code
        {
            get { return Weather_fLD_code; }
            set { Weather_fLD_code = value; }
        }
        //
        public System.Decimal Lminor_PK_ID
        {
            get { return Lminor_pK_ID; }
            set { Lminor_pK_ID = value; }
        }

        public System.String Lminor_FLD_desc
        {
            get { return Lminor_fLD_desc; }
            set { Lminor_fLD_desc = value; }
        }

        public System.String Lminor_FLD_code
        {
            get { return Lminor_fLD_code; }
            set { Lminor_fLD_code = value; }
        }
        //
        public System.Decimal Lmajor_PK_ID
        {
            get { return Lmajor_pK_ID; }
            set { Lmajor_pK_ID = value; }
        }

        public System.String Lmajor_FLD_desc
        {
            get { return Lmajor_fLD_desc; }
            set { Lmajor_fLD_desc = value; }
        }

        public System.String Lmajor_FLD_code
        {
            get { return Lmajor_fLD_code; }
            set { Lmajor_fLD_code = value; }
        }

        //Raod Type
        public System.Decimal Road_PK_ID
        {
            get { return Road_pK_ID; }
            set { Road_pK_ID = value; }
        }

        public System.String Road_FLD_desc
        {
            get { return Road_fLD_desc; }
            set { Road_fLD_desc = value; }
        }

        public System.String Road_FLD_code
        {
            get { return Road_fLD_code; }
            set { Road_fLD_code = value; }
        }


        //surface type

        public System.Decimal Surface_PK_ID
        {
            get { return surface_pK_ID; }
            set { surface_pK_ID = value; }
        }

        public System.String Surface_FLD_desc
        {
            get { return surface_fLD_desc; }
            set { surface_fLD_desc = value; }
        }

        public System.String Surface_FLD_code
        {
            get { return surface_fLD_code; }
            set { surface_fLD_code = value; }
        }

        //injury code
        public System.Decimal injury_PK_ID
        {
            get { return injury_pK_ID; }
            set { injury_pK_ID = value; }
        }

        public System.String injury_FLD_desc
        {
            get { return injury_fLD_desc; }
            set { injury_fLD_desc = value; }
        }

        public System.String injury_FLD_code
        {
            get { return injury_fLD_code; }
            set { injury_fLD_code = value; }
        }


        //Benificary Code
        public System.Decimal Benificary_PK_ID
        {
            get { return _Benificary_pK_ID; }
            set { _Benificary_pK_ID = value; }
        }

        public System.String Benificary_FLD_desc
        {
            get { return _Benificary_fLD_desc; }
            set { _Benificary_fLD_desc = value; }
        }

        public System.String Benificary_FLD_code
        {
            get { return _Benificary_fLD_code; }
            set { _Benificary_fLD_code = value; }
        }


        // For Vendor Type
        public System.Decimal VendorType_PK_ID
        {
            get { return _VendorType_PK_ID; }
            set { _VendorType_PK_ID = value; }
        }

        public System.String VendorType_FLD_Desc
        {
            get { return _VendorType_FLD_Desc; }
            set { _VendorType_FLD_Desc = value; }
        }
        public System.String VendorType_FLD_DescO
        {
            get { return _VendorType_FLD_DescO; }
            set { _VendorType_FLD_DescO = value; }
        }

        //For Claim Nature
        public System.Decimal Claim_Nature_PK_ID
        {
            get { return _Claim_Nature_pK_ID; }
            set { _Claim_Nature_pK_ID = value; }
        }

        public System.String Claim_Nature_FLD_desc
        {
            get { return _Claim_Nature_fLD_desc; }
            set { _Claim_Nature_fLD_desc = value; }
        }

        public System.String Claim_Nature_FLD_code
        {
            get { return _Claim_Nature_fLD_code; }
            set { _Claim_Nature_fLD_code = value; }
        }

        //For Claim Cause
        public System.Decimal Claim_Cause_PK_ID
        {
            get { return _Claim_Cause_pK_ID; }
            set { _Claim_Cause_pK_ID = value; }
        }

        public System.String Claim_Cause_FLD_desc
        {
            get { return _Claim_Cause_fLD_desc; }
            set { _Claim_Cause_fLD_desc = value; }
        }

        public System.String Claim_Cause_FLD_code
        {
            get { return _Claim_Cause_fLD_code; }
            set { _Claim_Cause_fLD_code = value; }
        }

        public System.String Claim_Cause_Fld_FROI
        {
            get { return _Claim_Cause_fld_FROI; }
            set { _Claim_Cause_fld_FROI = value; }
        }
       
        //For NCCI_Nature

        public System.Decimal NCCI_Nature_PK_Id
        {
            get { return _NCCI_Nature_pK_Id; }
            set { _NCCI_Nature_pK_Id = value; }
        }

        public System.String NCCI_Nature_Fld_Code
        {
            get { return _NCCI_Nature_fld_Code; }
            set { _NCCI_Nature_fld_Code = value; }
        }

        public System.String NCCI_Nature_Fld_Desc_1
        {
            get { return _NCCI_Nature_fld_Desc_1; }
            set { _NCCI_Nature_fld_Desc_1 = value; }
        }

        public System.String NCCI_Nature_Fld_Desc2
        {
            get { return _NCCI_Nature_fld_Desc2; }
            set { _NCCI_Nature_fld_Desc2 = value; }
        }

        public System.String NCCI_Nature_Claim_Type
        {
            get { return _NCCI_Nature_claim_Type; }
            set { _NCCI_Nature_claim_Type = value; }
        }

        //...............................for NCCI_Cause.........................................


        public System.Decimal NCCI_Cause_PK_IDNCC
        {
            get { return _NCCI_Cause_pK_Id; }
            set { _NCCI_Cause_pK_Id = value; }
        }

        public System.String NCCI_Cause_FLD_CODE
        {
            get { return _NCCI_Cause_fld_Code; }
            set { _NCCI_Cause_fld_Code = value; }
        }

        public System.String NCCI_Cause_Fld_DESC_1
        {
            get { return _NCCI_Cause_fld_Desc_1; }
            set { _NCCI_Cause_fld_Desc_1 = value; }
        }

        public System.String NCCI_Cause_Fld_DESC2
        {
            get { return _NCCI_Cause_fld_Desc2; }
            set { _NCCI_Cause_fld_Desc2 = value; }
        }

        public System.String NCCI_Cause_CLAIM_TYPE
        {
            get { return _NCCI_Cause_claim_Type; }
            set { _NCCI_Cause_claim_Type = value; }
        }
        //...............................for NCCI_Code.........................................

        public System.Decimal NCCI_Code_PK_IDNccCode
        {
            get { return _NCCI_Code_pK_ID; }
            set { _NCCI_Code_pK_ID = value; }
        }

        public System.String NCCI_Code_FLD_descNccdesc
        {
            get { return _NCCI_Code_fLD_desc; }
            set { _NCCI_Code_fLD_desc = value; }
        }

        public System.String NCCI_Code_FLD_codeNccCode
        {
            get { return _NCCI_Code_fLD_code; }
            set { _NCCI_Code_fLD_code = value; }
        }


        //...............................for wc minor type.........................................

        public System.Decimal PK_ID_Minor
        {
            get { return _Wc_minor_pK_ID; }
            set { _Wc_minor_pK_ID = value; }
        }

        public System.String FLD_desc_Minor
        {
            get { return _Wc_minor_fLD_desc; }
            set { _Wc_minor_fLD_desc = value; }
        }

        public System.String FLD_code_Minor
        {
            get { return _Wc_minor_fLD_code; }
            set { _Wc_minor_fLD_code = value; }
        }


        //...............................for wc Mejor type.........................................
        


        public System.Decimal PK_ID_Major
        {
            get { return _Wc_Mejor_pK_ID; }
            set { _Wc_Mejor_pK_ID = value; }
        }

        public System.String FLD_desc_Major
        {
            get { return _Wc_Mejor_fLD_desc; }
            set { _Wc_Mejor_fLD_desc = value; }
        }

        public System.String FLD_code_Major
        {
            get { return _Wc_Mejor_fLD_code; }
            set { _Wc_Mejor_fLD_code = value; }
        }

        //  .........................................Hazard Code............................................
        
           
        public System.Decimal PK_Id_Hazard
        {
            get { return _Hazard_pK_Id; }
            set { _Hazard_pK_Id = value; }
        }

        public System.String Fld_Desc1_Hazard
        {
            get { return _Hazard_fld_Desc_1; }
            set { _Hazard_fld_Desc_1 = value; }
        }

        public System.String Fld_Desc2_Hazard
        {
            get { return _Hazard_fld_Desc2; }
            set { _Hazard_fld_Desc2 = value; }
        }

        public System.String Fld_Code_Hazard
        {
            get { return _Hazard_fld_Code; }
            set { _Hazard_fld_Code = value; }
        }

        public System.String Claim_Type_Hazard
        {
            get { return _Hazard_claim_Type; }
            set { _Hazard_claim_Type = value; }
        }

        // For Fraudulent Claim Indicator 
         

        public System.Decimal PK_ID_Fraud
        {
            get { return _Fraudulent_pK_ID; }
            set { _Fraudulent_pK_ID = value; }
        }

        public System.String FLD_desc_Fraud
        {
            get { return _Fraudulent_fLD_desc; }
            set { _Fraudulent_fLD_desc = value; }
        }

        public System.String FLD_code_Fraud
        {
            get { return _Fraudulent_fLD_code; }
            set { _Fraudulent_fLD_code = value; }
        }
        // ..........................For Body Parts.......................................
        public System.Decimal PK_ID_Body
        {
            get { return _Body_Parts_pK_ID; }
            set { _Body_Parts_pK_ID = value; }
        }

        public System.String FLD_desc_Body
        {
            get { return _Body_Parts_fLD_desc; }
            set { _Body_Parts_fLD_desc = value; }
        }

        public System.String FLD_code_Body
        {
            get { return _Body_Parts_fLD_code; }
            set { _Body_Parts_fLD_code = value; }
        }

        //...............................County Code.......................................
        public System.Decimal PK_ID_County
        {
            get { return _County_pK_ID; }
            set { _County_pK_ID = value; }
        }

        public System.String FLD_county
        {
            get { return _County_fLD_desc; }
            set { _County_fLD_desc = value; }
        }

        public System.String FLD_code_County
        {
            get { return _County_fLD_code; }
            set { _County_fLD_code = value; }
        }

        public System.String FLD_state_County
        {
            get { return _County_fLD_state; }
            set { _County_fLD_state = value; }
        }

        //.................................pre injury combo...............
       	

        public System.Decimal PK_ID_pre
        {
            get { return _Pre_Injury_pK_ID; }
            set { _Pre_Injury_pK_ID = value; }
        }

        public System.String FLD_desc_pre
        {
            get { return _Pre_Injury_fLD_desc; }
            set { _Pre_Injury_fLD_desc = value; }
        }

        public System.String FLD_code_pre
        {
            get { return _Pre_Injury_fLD_code; }
            set { _Pre_Injury_fLD_code = value; }
        }

        //................................. For Managed care org Type Combo................
        public System.Decimal PK_ID_Manage
        {
            get { return _Managed_care_org_pK_ID; }
            set { _Managed_care_org_pK_ID = value; }
        }

        public System.String FLD_desc_Manage
        {
            get { return _Managed_care_org_fLD_desc; }
            set { _Managed_care_org_fLD_desc = value; }
        }

        public System.String FLD_code_Manage
        {
            get { return _Managed_care_org_fLD_code; }
            set { _Managed_care_org_fLD_code = value; }
        }

        public System.Decimal PK_ID
        {
            get { return _pK_ID; }
            set { _pK_ID = value; }
        }

        public System.String FLD_state
        {
            get { return _fLD_state; }
            set { _fLD_state = value; }
        }

        public System.String FLD_abbreviation
        {
            get { return _fLD_abbreviation; }
            set { _fLD_abbreviation = value; }
        }

        public System.String Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public System.String FLD_desc
        {
            get { return _fLD_desc; }
            set { _fLD_desc = value; }
        }

        public System.String FLD_code
        {
            get { return _fLD_code; }
            set { _fLD_code = value; }
        }
        public System.Decimal PK_Supp_Doc_Type
        {
            get { return _pK_Supp_Doc_Type; }
            set { _pK_Supp_Doc_Type = value; }
        }

        public System.String Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public System.Decimal Payroll_PK_ID
        {
            get { return _payroll_pK_ID; }
            set { _payroll_pK_ID = value; }
        }

        public System.String Payroll_FLD_desc
        {
            get { return _payroll_fLD_desc; }
            set { _payroll_fLD_desc = value; }
        }

        public System.String Payroll_FLD_code
        {
            get { return _payroll_fLD_code; }
            set { _payroll_fLD_code = value; }
        }
        public System.Decimal Loss_cond_act_PK_ID
        {
            get { return _loss_cond_act_pK_ID; }
            set { _loss_cond_act_pK_ID = value; }
        }

        public System.String Loss_cond_act_FLD_desc
        {
            get { return _loss_cond_act_fLD_desc; }
            set { _loss_cond_act_fLD_desc = value; }
        }

        public System.String Loss_cond_act_FLD_code
        {
            get { return _loss_cond_act_fLD_code; }
            set { _loss_cond_act_fLD_code = value; }
        }
        public System.Decimal Loss_cond_recovery_PK_ID
        {
            get { return _loss_cond_recovery_pK_ID; }
            set { _loss_cond_recovery_pK_ID = value; }
        }

        public System.String Loss_cond_recovery_FLD_desc
        {
            get { return _loss_cond_recovery_fLD_desc; }
            set { _loss_cond_recovery_fLD_desc = value; }
        }

        public System.String Loss_cond_recovery_FLD_code
        {
            get { return _loss_cond_recovery_fLD_code; }
            set { _loss_cond_recovery_fLD_code = value; }
        }
        public System.Decimal Loss_coverage_code_PK_ID
        {
            get { return _loss_coverage_code_pK_ID; }
            set { _loss_coverage_code_pK_ID = value; }
        }

        public System.String Loss_coverage_code_FLD_desc
        {
            get { return _loss_coverage_code_fLD_desc; }
            set { _loss_coverage_code_fLD_desc = value; }
        }

        public System.String Loss_coverage_code_FLD_code
        {
            get { return _loss_coverage_code_fLD_code; }
            set { _loss_coverage_code_fLD_code = value; }
        }

        public System.String Loss_coverage_code_FLD_state
        {
            get { return _loss_coverage_code_fLD_state; }
            set { _loss_coverage_code_fLD_state = value; }
        }
        public System.Decimal Property_Damage_PK_ID
        {
            get { return _Property_Damage_pK_ID; }
            set { _Property_Damage_pK_ID = value; }
        }

        public System.String Property_Damage_FLD_desc
        {
            get { return _Property_Damage_fLD_desc; }
            set { _Property_Damage_fLD_desc = value; }
        }

        public System.String Property_Damage_FLD_code
        {
            get { return _Property_Damage_fLD_code; }
            set { _Property_Damage_fLD_code = value; }
        }
        public System.Decimal Loss_cond_loss_PK_ID
        {
            get { return _loss_cond_loss_pK_ID; }
            set { _loss_cond_loss_pK_ID = value; }
        }

        public System.String Loss_cond_loss_FLD_desc
        {
            get { return _loss_cond_loss_fLD_desc; }
            set { _loss_cond_loss_fLD_desc = value; }
        }

        public System.String Loss_cond_loss_FLD_code
        {
            get { return _loss_cond_loss_fLD_code; }
            set { _loss_cond_loss_fLD_code = value; }
        }
        public System.Decimal Attorney_form_PK_ID
        {
            get { return _attorney_form_pK_ID; }
            set { _attorney_form_pK_ID = value; }
        }

        public System.String Attorney_form_FLD_desc
        {
            get { return _attorney_form_fLD_desc; }
            set { _attorney_form_fLD_desc = value; }
        }

        public System.String Attorney_form_FLD_code
        {
            get { return _attorney_form_fLD_code; }
            set { _attorney_form_fLD_code = value; }
        }
        public System.Decimal Settlement_method_PK_ID
        {
            get { return _settlement_method_pK_ID; }
            set { _settlement_method_pK_ID = value; }
        }

        public System.String Settlement_method_FLD_desc
        {
            get { return _settlement_method_fLD_desc; }
            set { _settlement_method_fLD_desc = value; }
        }

        public System.String Settlement_method_FLD_code
        {
            get { return _settlement_method_fLD_code; }
            set { _settlement_method_fLD_code = value; }
        }
        public System.Decimal Injury_type_PK_ID
        {
            get { return _injury_type_pK_ID; }
            set { _injury_type_pK_ID = value; }
        }

        public System.String Injury_type_FLD_desc
        {
            get { return _injury_type_fLD_desc; }
            set { _injury_type_fLD_desc = value; }
        }

        public System.String Injury_type_FLD_code
        {
            get { return _injury_type_fLD_code; }
            set { _injury_type_fLD_code = value; }
        }
        public System.Decimal Major_class_code_PK_ID
        {
            get { return _major_class_code_pK_ID; }
            set { _major_class_code_pK_ID = value; }
        }

        public System.String Major_class_code_FLD_desc
        {
            get { return _major_class_code_fLD_desc; }
            set { _major_class_code_fLD_desc = value; }
        }

        public System.String Major_class_code_FLD_code
        {
            get { return _major_class_code_fLD_code; }
            set { _major_class_code_fLD_code = value; }
        }
        public System.Decimal Loss_cond_settlement_PK_ID
        {
            get { return _loss_cond_settlement_pK_ID; }
            set { _loss_cond_settlement_pK_ID = value; }
        }

        public System.String Loss_cond_settlement_FLD_desc
        {
            get { return _loss_cond_settlement_fLD_desc; }
            set { _loss_cond_settlement_fLD_desc = value; }
        }

        public System.String Loss_cond_settlement_FLD_code
        {
            get { return _loss_cond_settlement_fLD_code; }
            set { _loss_cond_settlement_fLD_code = value; }
        }
        public System.Decimal Trans_Type
        {
            get { return _trans_Type; }
            set { _trans_Type = value; }
        }

        public System.String Trans_Code
        {
            get { return _trans_Code; }
            set { _trans_Code = value; }
        }

        public System.String Trans_Code_Description
        {
            get { return _trans_Code_Description; }
            set { _trans_Code_Description = value; }
        }

        public System.String Type
        {
            get { return _type; }
            set { _type = value; }
        }
       
        // original Cost
        public System.Decimal orgcost_PK_ID
        {
            get { return orgcost_pK_ID; }
            set { orgcost_pK_ID = value; }
        }

        public System.String orgcost_FLD_desc
        {
            get { return orgcost_fLD_desc; }
            set { orgcost_fLD_desc = value; }
        }

        public System.String orgcost_FLD_code
        {
            get { return orgcost_fLD_code; }
            set { orgcost_fLD_code = value; }
        }
        //comrehnsive

        public System.Decimal comprehensive_PK_ID
	{
		get { return comprehensive_pK_ID; }
		set { comprehensive_pK_ID = value; }
	}

	    public System.String comprehensive_FLD_desc
	{
		get { return  comprehensive_fLD_desc; }
		set { comprehensive_fLD_desc = value; }
	}

	    public System.String comprehensive_FLD_code
	{
		get { return  comprehensive_fLD_code; }
		set { comprehensive_fLD_code = value; }
	}

        public System.Decimal Pk_Adjustor_Note_Type_ID
    {
        get { return _pk_Adjustor_Note_Type_ID; }
        set { _pk_Adjustor_Note_Type_ID = value; }
    }

        public System.String Adjustor_Note_Type_FLD_Desc
    {
        get { return _adjustor_Note_Type_FLD_Desc; }
        set { _adjustor_Note_Type_FLD_Desc = value; }
    }
        #endregion

        #region Abstract Methods
        public abstract List<CGeneral> GetAllState();
        public abstract List<CGeneral> GetAttachamentType();
        public abstract List<CGeneral> GetSupportedDocumentType();
        public abstract List<CGeneral> GetVendorType();
        public abstract List<CGeneral> GetPayroll();
        public abstract List<CGeneral> GetLossCondtionAct();
        public abstract List<CGeneral> GetLossCondtionRecovery();
        public abstract List<CGeneral> GetLossCoverageCode();
        public abstract List<CGeneral> GetPropertyDamage();
        public abstract List<CGeneral> GetLossConditionLoss();
        public abstract List<CGeneral> GetAttornyForm();
        public abstract List<CGeneral> GetSettlementMethod();
        public abstract List<CGeneral> GetInjuryType();
        public abstract List<CGeneral> GetMajorClassCode();
        public abstract List<CGeneral> GetLossCondSettlement();
        public abstract List<CGeneral> GetPayCode(string m_strPayId);
        public abstract List<CGeneral> GetNcciNature();
        public abstract List<CGeneral> GetNcciCause();
        public abstract List<CGeneral> GetNcciCode();
        public abstract List<CGeneral> GetWcMinorType();
        public abstract List<CGeneral> GetWcMajorType();
        public abstract List<CGeneral> GetHazardCode();
        public abstract List<CGeneral> GetFraudClaim();
        public abstract List<CGeneral> GetBodyParts();
        public abstract List<CGeneral> GetCounty();
        public abstract List<CGeneral> GetPreInjury();
        public abstract List<CGeneral> GetManagedCareOrg();
        public abstract List<CGeneral> GetClaimCause();
        public abstract List<CGeneral> GetClaimNature();
        public abstract List<CGeneral> GetBenificary();
        public abstract List<CGeneral> GetInjuryCode();

        public abstract List<CGeneral> GetRoadSurface();
        public abstract List<CGeneral> GetRoadType();
        public abstract List<CGeneral> GetComprehensive();
        public abstract List<CGeneral> GetOriginalCost();

        public abstract List<CGeneral> GetLiabilitymajor();
        public abstract List<CGeneral> GetLiabilityminor();
        public abstract List<CGeneral> Getincident();
        public abstract List<CGeneral> GetWeatherCondition();
        public abstract List<CGeneral> GetCollision_Deductible();
        public abstract List<CGeneral> Classification_code();

        public abstract List<CGeneral> GetAdjustorNoteType();
        public abstract List<CGeneral> GetAllEntity();
        public abstract List<RIMS_Base.CGeneral> GetAllEntityByLoggedInUser(Decimal pk_Security_Id);
        public abstract List<CGeneral> GetAllFacility();
        public abstract List<CGeneral> GetAllCostCenter();
        public abstract List<CGeneral> GetAllMobileType();
        public abstract List<CGeneral> GetAllStationaryType();
        public abstract List<CGeneral> GetAllLandStatus();
        public abstract List<CGeneral> GetAllFloodZone();
        public abstract List<CGeneral> GetAllConstrType();
        public abstract List<CGeneral> GetAllLocation();

        public abstract List<CGeneral> GetClaimantTypes();
        public abstract List<CGeneral> GetInjuredTypes();
        public abstract List<CGeneral> GetAutoClaimTypes();
        public abstract List<CGeneral> GetGeneralClaimTypes();

        public abstract List<CGeneral> GetPropertyType();
        public abstract List<CGeneral> GetPropertyLocationCode();

        public abstract List<CGeneral> GetLiabilityCoverage();
        public abstract List<CGeneral> GetLiabilityCoverageById(Decimal pk_id);
        public abstract DataSet GetCountyByState(string m_strState);

        public abstract List<CGeneral> GetGender();
        public abstract List<CGeneral> GetDriverStatus();

        public abstract DataSet GetBatteries();
        public abstract DataSet GetTowerType();
        public abstract DataSet GetFireProtection();

        public abstract DataSet GetPolicyType();
        public abstract DataSet GetAllAdHocFields(string ClaimType);
        #endregion
    
    }

}
