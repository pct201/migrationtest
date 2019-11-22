using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Investigation table.
    /// </summary>
    public sealed class Investigation
    {
        #region Fields


        private int _PK_Investigation_ID;
        private int _FK_WC_FR_ID;
        private DateTime _Action_Reviewed;
        private int _FK_LU_Location_ID;
        private Nullable<bool> _Cause_1;
        private Nullable<bool> _Cause_2;
        private Nullable<bool> _Cause_3;
        private Nullable<bool> _Cause_4;
        private Nullable<bool> _Cause_5;
        private Nullable<bool> _Cause_6;
        private Nullable<bool> _Cause_7;
        private Nullable<bool> _Cause_8;
        private Nullable<bool> _Cause_9;
        private Nullable<bool> _Cause_10;
        private Nullable<bool> _Cause_11;
        private Nullable<bool> _Cause_12;
        private Nullable<bool> _Cause_13;
        private Nullable<bool> _Cause_14;
        private Nullable<bool> _Cause_15;
        private Nullable<bool> _Cause_16;
        private Nullable<bool> _Cause_17;
        private Nullable<bool> _Cause_18;
        private Nullable<bool> _Cause_19;
        private Nullable<bool> _Cause_20;
        private Nullable<bool> _Cause_21;
        private Nullable<bool> _Cause_22;
        private Nullable<bool> _Cause_23;
        private Nullable<bool> _Cause_24;
        private Nullable<bool> _Cause_25;
        private Nullable<bool> _Cause_26;
        private Nullable<bool> _Cause_27;
        private Nullable<bool> _Cause_28;
        private Nullable<bool> _Cause_29;
        private Nullable<bool> _Cause_30;
        private Nullable<bool> _Cause_31;
        private Nullable<bool> _Cause_32;
        private Nullable<bool> _Cause_33;
        private Nullable<bool> _Cause_34;
        private Nullable<bool> _Cause_35;
        private Nullable<bool> _Cause_36;
        private Nullable<bool> _Cause_37;
        private Nullable<bool> _Cause_38;
        private Nullable<bool> _Cause_39;
        private Nullable<bool> _Cause_40;
        private Nullable<bool> _Cause_41;
        private Nullable<bool> _Cause_42;
        private string _Cause_42_detail;
        private string _Cause_Comment;
        private Nullable<bool> _Personal_Job_Factors_1;
        private Nullable<bool> _Personal_Job_Factors_2;
        private Nullable<bool> _Personal_Job_Factors_3;
        private Nullable<bool> _Personal_Job_Factors_4;
        private Nullable<bool> _Personal_Job_Factors_5;
        private Nullable<bool> _Personal_Job_Factors_6;
        private Nullable<bool> _Personal_Job_Factors_7;
        private Nullable<bool> _Personal_Job_Factors_8;
        private Nullable<bool> _Personal_Job_Factors_9;
        private Nullable<bool> _Personal_Job_Factors_10;
        private Nullable<bool> _Personal_Job_Factors_11;
        private Nullable<bool> _Personal_Job_Factors_12;
        private Nullable<bool> _Personal_Job_Factors_13;
        private Nullable<bool> _Personal_Job_Factors_14;
        private Nullable<bool> _Personal_Job_Factors_15;
        private Nullable<bool> _Personal_Job_Factors_16;
        private Nullable<bool> _Personal_Job_Factors_17;
        private Nullable<bool> _Personal_Job_Factors_18;
        private Nullable<bool> _Personal_Job_Factors_19;
        private string _Personal_Job_Factors_17_Details;
        private string _Personal_Job_Comment;
        private string _Conclusions;
        private Nullable<bool> _OSHA_Recordable;
        private string _Sonic_Cause_Code;
        private string _Corrective_Action_Description;
        private string _Assigned_To;
        private string _AssignedBy;
        private DateTime _To_Be_Competed_by;
        private string _Status;
        private string _Lessons_Learned;
        private DateTime _Cause_Reviewed;
        private bool _Location_Information_Complete;
        private bool _RLCM_Complete;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        private string _Investigative_Quality;
        private string _Original_Sonic_S0_Cause_Code;
        private string _Sonic_S0_Cause_Code_Promoted;
        private DateTime? _Date_Sonic_S0_Cause_Code_Promoted;
        private DateTime? _Date_Submitted_by_Store;
        private string _RLCM_Comments;
        private DateTime? _Date_RLCM_Review_Completed;
        private decimal? _Lag_Time;
        private decimal? _FK_LU_Contributing_Factor;
        private string _Contributing_Factor_Other;
        private string _Timing;
        private string _Timing_Comment;
        private string _SLT_Involvement;
        private string _SLT_Involvement_Comment;
        private string _Witnesses;
        private string _Witnesses_Comment;
        private string _SLT_Visit;
        private string _SLT_Visit_Comment;
        private string _Root_Causes;
        private string _Root_Causes_Comment;
        private string _Action_Plan;
        private string _Action_Plan_Comment;
        private string _Focus_Area;
        private string _Communicated;
        private DateTime? _Date_Communicated;
        private string _No_Communication_Explanation;
        private decimal? _FK_LU_OSHA_Incident;
        private decimal? _FK_LU_OSHA_Injury;
        private string _RLCM_Review_Approve;

        private string _Physician_Other_Professional;
        private string _Facility;
        private string _Facility_Address;
        private string _Facility_City;
        private decimal? _FK_State_Facility;
        private string _Facility_Zip_Code;
        private string _Emergency_Room;
        private string _Time_Began_Work;
        private string _Activity_Before_Incident;
        private string _Object_Substance_Involved;
        private Nullable<bool> _Admitted_to_Hospital;
        private string _Slipping;

        private decimal? _FK_Nature_of_Injury;
        private decimal? _FK_Body_Parts_Affected;
        private DateTime? _Return_To_Work_Date;
        #endregion


        #region Properties


        /// <summary> 
        /// Gets or sets the PK_Investigation_ID value.
        /// </summary>
        public int PK_Investigation_ID
        {
            get { return _PK_Investigation_ID; }
            set { _PK_Investigation_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_WC_FR_ID value.
        /// </summary>
        public int FK_WC_FR_ID
        {
            get { return _FK_WC_FR_ID; }
            set { _FK_WC_FR_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Action_Reviewed value.
        /// </summary>
        public DateTime Action_Reviewed
        {
            get { return _Action_Reviewed; }
            set { _Action_Reviewed = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public int FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_1 value.
        /// </summary>
        public Nullable<bool> Cause_1
        {
            get { return _Cause_1; }
            set { _Cause_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_2 value.
        /// </summary>
        public Nullable<bool> Cause_2
        {
            get { return _Cause_2; }
            set { _Cause_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_3 value.
        /// </summary>
        public Nullable<bool> Cause_3
        {
            get { return _Cause_3; }
            set { _Cause_3 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_4 value.
        /// </summary>
        public Nullable<bool> Cause_4
        {
            get { return _Cause_4; }
            set { _Cause_4 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_5 value.
        /// </summary>
        public Nullable<bool> Cause_5
        {
            get { return _Cause_5; }
            set { _Cause_5 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_6 value.
        /// </summary>
        public Nullable<bool> Cause_6
        {
            get { return _Cause_6; }
            set { _Cause_6 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_7 value.
        /// </summary>
        public Nullable<bool> Cause_7
        {
            get { return _Cause_7; }
            set { _Cause_7 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_8 value.
        /// </summary>
        public Nullable<bool> Cause_8
        {
            get { return _Cause_8; }
            set { _Cause_8 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_9 value.
        /// </summary>
        public Nullable<bool> Cause_9
        {
            get { return _Cause_9; }
            set { _Cause_9 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_10 value.
        /// </summary>
        public Nullable<bool> Cause_10
        {
            get { return _Cause_10; }
            set { _Cause_10 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_11 value.
        /// </summary>
        public Nullable<bool> Cause_11
        {
            get { return _Cause_11; }
            set { _Cause_11 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_12 value.
        /// </summary>
        public Nullable<bool> Cause_12
        {
            get { return _Cause_12; }
            set { _Cause_12 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_13 value.
        /// </summary>
        public Nullable<bool> Cause_13
        {
            get { return _Cause_13; }
            set { _Cause_13 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_14 value.
        /// </summary>
        public Nullable<bool> Cause_14
        {
            get { return _Cause_14; }
            set { _Cause_14 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_15 value.
        /// </summary>
        public Nullable<bool> Cause_15
        {
            get { return _Cause_15; }
            set { _Cause_15 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_16 value.
        /// </summary>
        public Nullable<bool> Cause_16
        {
            get { return _Cause_16; }
            set { _Cause_16 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_17 value.
        /// </summary>
        public Nullable<bool> Cause_17
        {
            get { return _Cause_17; }
            set { _Cause_17 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_18 value.
        /// </summary>
        public Nullable<bool> Cause_18
        {
            get { return _Cause_18; }
            set { _Cause_18 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_19 value.
        /// </summary>
        public Nullable<bool> Cause_19
        {
            get { return _Cause_19; }
            set { _Cause_19 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_20 value.
        /// </summary>
        public Nullable<bool> Cause_20
        {
            get { return _Cause_20; }
            set { _Cause_20 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_21 value.
        /// </summary>
        public Nullable<bool> Cause_21
        {
            get { return _Cause_21; }
            set { _Cause_21 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_22 value.
        /// </summary>
        public Nullable<bool> Cause_22
        {
            get { return _Cause_22; }
            set { _Cause_22 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_23 value.
        /// </summary>
        public Nullable<bool> Cause_23
        {
            get { return _Cause_23; }
            set { _Cause_23 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_24 value.
        /// </summary>
        public Nullable<bool> Cause_24
        {
            get { return _Cause_24; }
            set { _Cause_24 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_25 value.
        /// </summary>
        public Nullable<bool> Cause_25
        {
            get { return _Cause_25; }
            set { _Cause_25 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_26 value.
        /// </summary>
        public Nullable<bool> Cause_26
        {
            get { return _Cause_26; }
            set { _Cause_26 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_27 value.
        /// </summary>
        public Nullable<bool> Cause_27
        {
            get { return _Cause_27; }
            set { _Cause_27 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_28 value.
        /// </summary>
        public Nullable<bool> Cause_28
        {
            get { return _Cause_28; }
            set { _Cause_28 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_29 value.
        /// </summary>
        public Nullable<bool> Cause_29
        {
            get { return _Cause_29; }
            set { _Cause_29 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_30 value.
        /// </summary>
        public Nullable<bool> Cause_30
        {
            get { return _Cause_30; }
            set { _Cause_30 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_31 value.
        /// </summary>
        public Nullable<bool> Cause_31
        {
            get { return _Cause_31; }
            set { _Cause_31 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_32 value.
        /// </summary>
        public Nullable<bool> Cause_32
        {
            get { return _Cause_32; }
            set { _Cause_32 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_33 value.
        /// </summary>
        public Nullable<bool> Cause_33
        {
            get { return _Cause_33; }
            set { _Cause_33 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_34 value.
        /// </summary>
        public Nullable<bool> Cause_34
        {
            get { return _Cause_34; }
            set { _Cause_34 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_35 value.
        /// </summary>
        public Nullable<bool> Cause_35
        {
            get { return _Cause_35; }
            set { _Cause_35 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_36 value.
        /// </summary>
        public Nullable<bool> Cause_36
        {
            get { return _Cause_36; }
            set { _Cause_36 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_37 value.
        /// </summary>
        public Nullable<bool> Cause_37
        {
            get { return _Cause_37; }
            set { _Cause_37 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_38 value.
        /// </summary>
        public Nullable<bool> Cause_38
        {
            get { return _Cause_38; }
            set { _Cause_38 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_39 value.
        /// </summary>
        public Nullable<bool> Cause_39
        {
            get { return _Cause_39; }
            set { _Cause_39 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_40 value.
        /// </summary>
        public Nullable<bool> Cause_40
        {
            get { return _Cause_40; }
            set { _Cause_40 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_41 value.
        /// </summary>
        public Nullable<bool> Cause_41
        {
            get { return _Cause_41; }
            set { _Cause_41 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_42 value.
        /// </summary>
        public Nullable<bool> Cause_42
        {
            get { return _Cause_42; }
            set { _Cause_42 = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_42_detail value.
        /// </summary>
        public string Cause_42_detail
        {
            get { return _Cause_42_detail; }
            set { _Cause_42_detail = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_Comment value.
        /// </summary>
        public string Cause_Comment
        {
            get { return _Cause_Comment; }
            set { _Cause_Comment = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_1 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_1
        {
            get { return _Personal_Job_Factors_1; }
            set { _Personal_Job_Factors_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_2 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_2
        {
            get { return _Personal_Job_Factors_2; }
            set { _Personal_Job_Factors_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_3 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_3
        {
            get { return _Personal_Job_Factors_3; }
            set { _Personal_Job_Factors_3 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_4 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_4
        {
            get { return _Personal_Job_Factors_4; }
            set { _Personal_Job_Factors_4 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_5 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_5
        {
            get { return _Personal_Job_Factors_5; }
            set { _Personal_Job_Factors_5 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_6 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_6
        {
            get { return _Personal_Job_Factors_6; }
            set { _Personal_Job_Factors_6 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_7 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_7
        {
            get { return _Personal_Job_Factors_7; }
            set { _Personal_Job_Factors_7 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_8 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_8
        {
            get { return _Personal_Job_Factors_8; }
            set { _Personal_Job_Factors_8 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_9 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_9
        {
            get { return _Personal_Job_Factors_9; }
            set { _Personal_Job_Factors_9 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_10 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_10
        {
            get { return _Personal_Job_Factors_10; }
            set { _Personal_Job_Factors_10 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_11 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_11
        {
            get { return _Personal_Job_Factors_11; }
            set { _Personal_Job_Factors_11 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_12 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_12
        {
            get { return _Personal_Job_Factors_12; }
            set { _Personal_Job_Factors_12 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_13 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_13
        {
            get { return _Personal_Job_Factors_13; }
            set { _Personal_Job_Factors_13 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_14 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_14
        {
            get { return _Personal_Job_Factors_14; }
            set { _Personal_Job_Factors_14 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_15 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_15
        {
            get { return _Personal_Job_Factors_15; }
            set { _Personal_Job_Factors_15 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_16 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_16
        {
            get { return _Personal_Job_Factors_16; }
            set { _Personal_Job_Factors_16 = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_17 value.
        /// </summary>
        public Nullable<bool> Personal_Job_Factors_17
        {
            get { return _Personal_Job_Factors_17; }
            set { _Personal_Job_Factors_17 = value; }
        }

        public Nullable<bool> Personal_Job_Factors_18
        {
            get { return _Personal_Job_Factors_18; }
            set { _Personal_Job_Factors_18 = value; }
        }

        public Nullable<bool> Personal_Job_Factors_19
        {
            get { return _Personal_Job_Factors_19; }
            set { _Personal_Job_Factors_19 = value; }
        }
        /// <summary> 
        /// Gets or sets the Personal_Job_Factors_17_Details value.
        /// </summary>
        public string Personal_Job_Factors_17_Details
        {
            get { return _Personal_Job_Factors_17_Details; }
            set { _Personal_Job_Factors_17_Details = value; }
        }


        /// <summary> 
        /// Gets or sets the Personal_Job_Comment value.
        /// </summary>
        public string Personal_Job_Comment
        {
            get { return _Personal_Job_Comment; }
            set { _Personal_Job_Comment = value; }
        }


        /// <summary> 
        /// Gets or sets the Conclusions value.
        /// </summary>
        public string Conclusions
        {
            get { return _Conclusions; }
            set { _Conclusions = value; }
        }


        /// <summary> 
        /// Gets or sets the OSHA_Recordable value.
        /// </summary>
        public Nullable<bool> OSHA_Recordable
        {
            get { return _OSHA_Recordable; }
            set { _OSHA_Recordable = value; }
        }


        /// <summary> 
        /// Gets or sets the Sonic_Cause_Code value.
        /// </summary>
        public string Sonic_Cause_Code
        {
            get { return _Sonic_Cause_Code; }
            set { _Sonic_Cause_Code = value; }
        }


        /// <summary> 
        /// Gets or sets the Corrective_Action_Description value.
        /// </summary>
        public string Corrective_Action_Description
        {
            get { return _Corrective_Action_Description; }
            set { _Corrective_Action_Description = value; }
        }


        /// <summary> 
        /// Gets or sets the Assigned_To value.
        /// </summary>
        public string Assigned_To
        {
            get { return _Assigned_To; }
            set { _Assigned_To = value; }
        }


        /// <summary> 
        /// Gets or sets the AssignedBy value.
        /// </summary>
        public string AssignedBy
        {
            get { return _AssignedBy; }
            set { _AssignedBy = value; }
        }


        /// <summary> 
        /// Gets or sets the To_Be_Competed_by value.
        /// </summary>
        public DateTime To_Be_Competed_by
        {
            get { return _To_Be_Competed_by; }
            set { _To_Be_Competed_by = value; }
        }


        /// <summary> 
        /// Gets or sets the Status value.
        /// </summary>
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }


        /// <summary> 
        /// Gets or sets the Lessons_Learned value.
        /// </summary>
        public string Lessons_Learned
        {
            get { return _Lessons_Learned; }
            set { _Lessons_Learned = value; }
        }


        /// <summary> 
        /// Gets or sets the Cause_Reviewed value.
        /// </summary>
        public DateTime Cause_Reviewed
        {
            get { return _Cause_Reviewed; }
            set { _Cause_Reviewed = value; }
        }

        public bool Location_Information_Complete
        {
            get { return _Location_Information_Complete; }
            set { _Location_Information_Complete = value; }
        }

        public bool RLCM_Complete
        {
            get { return _RLCM_Complete; }
            set { _RLCM_Complete = value; }
        }

        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public decimal Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary> 
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Investigative_Quality value.
        /// </summary>
        public string Investigative_Quality
        {
            get { return _Investigative_Quality; }
            set { _Investigative_Quality = value; }
        }

        /// <summary>
        /// Gets or sets the Original_Sonic_S0_Cause_Code value.
        /// </summary>
        public string Original_Sonic_S0_Cause_Code
        {
            get { return _Original_Sonic_S0_Cause_Code; }
            set { _Original_Sonic_S0_Cause_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Sonic_S0_Cause_Code_Promoted value.
        /// </summary>
        public string Sonic_S0_Cause_Code_Promoted
        {
            get { return _Sonic_S0_Cause_Code_Promoted; }
            set { _Sonic_S0_Cause_Code_Promoted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Sonic_S0_Cause_Code_Promoted value.
        /// </summary>
        public DateTime? Date_Sonic_S0_Cause_Code_Promoted
        {
            get { return _Date_Sonic_S0_Cause_Code_Promoted; }
            set { _Date_Sonic_S0_Cause_Code_Promoted = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Submitted_by_Store value.
        /// </summary>
        public DateTime? Date_Submitted_by_Store
        {
            get { return _Date_Submitted_by_Store; }
            set { _Date_Submitted_by_Store = value; }
        }

        /// Gets or sets the RLCM_Comments value.
        /// </summary>
        public string RLCM_Comments
        {
            get { return _RLCM_Comments; }
            set { _RLCM_Comments = value; }
        }

        /// <summary>
        /// Gets or sets the Date_RLCM_Review_Completed value.
        /// </summary>
        public DateTime? Date_RLCM_Review_Completed
        {
            get { return _Date_RLCM_Review_Completed; }
            set { _Date_RLCM_Review_Completed = value; }
        }

        /// <summary>
        /// Gets or sets the Date_RLCM_Review_Completed value.
        /// </summary>
        public decimal? Lag_Time
        {
            get { return _Lag_Time; }
            set { _Lag_Time = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Contributing_Factor value.
        /// </summary>
        public decimal? FK_LU_Contributing_Factor
        {
            get { return _FK_LU_Contributing_Factor; }
            set { _FK_LU_Contributing_Factor = value; }
        }

        /// <summary>
        /// Gets or sets the Contributing_Factor_Other value.
        /// </summary>
        public string Contributing_Factor_Other
        {
            get { return _Contributing_Factor_Other; }
            set { _Contributing_Factor_Other = value; }
        }

        public string Timing
        {
            get { return _Timing; }
            set { _Timing = value; }
        }

        public string Timing_Comment
        {
            get { return _Timing_Comment; }
            set { _Timing_Comment = value; }
        }

        public string SLT_Involvement
        {
            get { return _SLT_Involvement; }
            set { _SLT_Involvement = value; }
        }

        public string SLT_Involvement_Comment
        {
            get { return _SLT_Involvement_Comment; }
            set { _SLT_Involvement_Comment = value; }
        }

        public string Witnesses
        {
            get { return _Witnesses; }
            set { _Witnesses = value; }
        }

        public string Witnesses_Comment
        {
            get { return _Witnesses_Comment; }
            set { _Witnesses_Comment = value; }
        }

        public string SLT_Visit
        {
            get { return _SLT_Visit; }
            set { _SLT_Visit = value; }
        }

        public string SLT_Visit_Comment
        {
            get { return _SLT_Visit_Comment; }
            set { _SLT_Visit_Comment = value; }
        }

        public string Root_Causes
        {
            get { return _Root_Causes; }
            set { _Root_Causes = value; }
        }

        public string Root_Causes_Comment
        {
            get { return _Root_Causes_Comment; }
            set { _Root_Causes_Comment = value; }
        }

        public string Action_Plan
        {
            get { return _Action_Plan; }
            set { _Action_Plan = value; }
        }

        public string Action_Plan_Comment
        {
            get { return _Action_Plan_Comment; }
            set { _Action_Plan_Comment = value; }
        }

        /// <summary>
        /// Gets or sets the Focus_Area value.
        /// </summary>
        public string Focus_Area
        {
            get { return _Focus_Area; }
            set { _Focus_Area = value; }
        }

        /// <summary>
        /// Gets or sets the Communicated value.
        /// </summary>
        public string Communicated
        {
            get { return _Communicated; }
            set { _Communicated = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Communicated value.
        /// </summary>
        public DateTime? Date_Communicated
        {
            get { return _Date_Communicated; }
            set { _Date_Communicated = value; }
        }

        /// <summary>
        /// Gets or sets the No_Communication_Explanation value.
        /// </summary>
        public string No_Communication_Explanation
        {
            get { return _No_Communication_Explanation; }
            set { _No_Communication_Explanation = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_OSHA_Incident value.
        /// </summary>
        public decimal? FK_LU_OSHA_Incident
        {
            get { return _FK_LU_OSHA_Incident; }
            set { _FK_LU_OSHA_Incident = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_OSHA_Injury value.
        /// </summary>
        public decimal? FK_LU_OSHA_Injury
        {
            get { return _FK_LU_OSHA_Injury; }
            set { _FK_LU_OSHA_Injury = value; }
        }

        /// <summary>
        /// Gets or sets the RLCM_Review_Approve value.
        /// </summary>
        public string RLCM_Review_Approve
        {
            get { return _RLCM_Review_Approve; }
            set { _RLCM_Review_Approve = value; }
        }

        /// <summary>
        /// Gets or sets Physician_Other_Professional value
        /// </summary>
        public string Physician_Other_Professional
        {
            get { return _Physician_Other_Professional; }
            set { _Physician_Other_Professional = value; }
        }

        /// <summary>
        /// Gets or sets Facility value
        /// </summary>
        public string Facility
        {
            get { return _Facility; }
            set { _Facility = value; }
        }

        /// <summary>
        /// Gets or sets Facility_Address value
        /// </summary>
        public string Facility_Address
        {
            get { return _Facility_Address; }
            set { _Facility_Address = value; }
        }

        /// <summary>
        /// Gets or sets Facility_City value
        /// </summary>
        public string Facility_City
        {
            get { return _Facility_City; }
            set { _Facility_City = value; }
        }

        /// <summary>
        /// Gets or sets FK_State_Facility value
        /// </summary>
        public decimal? FK_State_Facility
        {
            get { return _FK_State_Facility; }
            set { _FK_State_Facility = value; }
        }

        /// <summary>
        /// Gets or sets Facility_Zip_Code value
        /// </summary>
        public string Facility_Zip_Code
        {
            get { return _Facility_Zip_Code; }
            set { _Facility_Zip_Code = value; }
        }

        /// <summary>
        /// Gets or sets Emergency_Room value
        /// </summary>
        public string Emergency_Room
        {
            get { return _Emergency_Room; }
            set { _Emergency_Room = value; }
        }

        /// <summary>
        /// Gets or sets Time_Began_Work value
        /// </summary>
        public string Time_Began_Work
        {
            get { return _Time_Began_Work; }
            set { _Time_Began_Work = value; }
        }

        /// <summary>
        /// Gets or sets Activity_Before_Incident value
        /// </summary>
        public string Activity_Before_Incident
        {
            get { return _Activity_Before_Incident; }
            set { _Activity_Before_Incident = value; }
        }

        /// <summary>
        /// Gets or sets Object_Substance_Involved value
        /// </summary>
        public string Object_Substance_Involved
        {
            get { return _Object_Substance_Involved; }
            set { _Object_Substance_Involved = value; }
        }

        /// <summary> 
        /// Gets or sets the Admitted_to_Hospital value.
        /// </summary>
        public Nullable<bool> Admitted_to_Hospital
        {
            get { return _Admitted_to_Hospital; }
            set { _Admitted_to_Hospital = value; }
        }

        /// <summary>
        /// Gets or sets the Slipping value.
        /// </summary>
        public string Slipping
        {
            get { return _Slipping; }
            set { _Slipping = value; }
        }

        /// <summary>
        /// Gets or sets FK_Nature_of_Injury
        /// </summary>
        public decimal? FK_Nature_of_Injury
        {
            get { return _FK_Nature_of_Injury; }
            set { _FK_Nature_of_Injury = value; }
        }

        /// <summary>
        /// Gets or sets FK_Body_Parts_Affected
        /// </summary>
        public decimal? FK_Body_Parts_Affected
        {
            get { return _FK_Body_Parts_Affected; }
            set { _FK_Body_Parts_Affected = value; }
        }

        /// <summary>
        /// Gets or sets the Return_To_Work_Date value.
        /// </summary>
        public DateTime? Return_To_Work_Date
        {
            get { return _Return_To_Work_Date; }
            set { _Return_To_Work_Date = value; }
        }
        
        #endregion

        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the Investigation class. with the default value.
        /// </summary>
        public Investigation()
        {

            this._PK_Investigation_ID = -1;
            this._FK_WC_FR_ID = -1;
            this._Action_Reviewed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._FK_LU_Location_ID = -1;
            this._Cause_42_detail = "";
            this._Cause_Comment = "";
            this._Personal_Job_Factors_17_Details = "";
            this._Personal_Job_Comment = "";
            this._Conclusions = "";
            this._OSHA_Recordable = null;
            this._Sonic_Cause_Code = "";
            this._Corrective_Action_Description = "";
            this._Assigned_To = "";
            this._AssignedBy = "";
            this._To_Be_Competed_by = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Status = "";
            this._Lessons_Learned = "";
            this._Cause_Reviewed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Location_Information_Complete = false;
            this._RLCM_Complete = false;
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Investigative_Quality = null;
            this._Original_Sonic_S0_Cause_Code = null;
            this._Sonic_S0_Cause_Code_Promoted = null;
            this._Date_Sonic_S0_Cause_Code_Promoted = null;
            this._RLCM_Comments = null;
            this.FK_LU_Contributing_Factor = null;
            this.Contributing_Factor_Other = "";
            this.FK_LU_OSHA_Incident = null;
            this.FK_LU_OSHA_Injury = null;
            this.RLCM_Review_Approve = string.Empty;

            this._Physician_Other_Professional = string.Empty;
            this._Facility = string.Empty;
            this._Facility_Address = string.Empty;
            this._Facility_City = string.Empty;
            this._FK_State_Facility = null;
            this._Facility_Zip_Code = string.Empty;
            this._Emergency_Room = string.Empty;
            this._Time_Began_Work = string.Empty;
            this._Activity_Before_Incident = string.Empty;
            this._Object_Substance_Involved = string.Empty;
            this._Admitted_to_Hospital = false;
            this._Slipping = string.Empty;
        }

        /// <summary> 
        /// Initializes a new instance of the Investigation class for passed PrimaryKey with the values set from Database.
        /// </summary>
        public Investigation(int PK)
        {

            DataTable dtInvestigation = SelectByPK(PK).Tables[0];

            if (dtInvestigation.Rows.Count > 0)
            {

                DataRow drInvestigation = dtInvestigation.Rows[0];

                this._PK_Investigation_ID = drInvestigation["PK_Investigation_ID"] != DBNull.Value ? Convert.ToInt32(drInvestigation["PK_Investigation_ID"]) : 0;
                this._FK_WC_FR_ID = drInvestigation["FK_WC_FR_ID"] != DBNull.Value ? Convert.ToInt32(drInvestigation["FK_WC_FR_ID"]) : 0;
                this._Action_Reviewed = drInvestigation["Action_Reviewed"] != DBNull.Value ? Convert.ToDateTime(drInvestigation["Action_Reviewed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_LU_Location_ID = drInvestigation["FK_LU_Location_ID"] != DBNull.Value ? Convert.ToInt32(drInvestigation["FK_LU_Location_ID"]) : 0;
                if (drInvestigation["Cause_1"] != DBNull.Value) this._Cause_1 = Convert.ToBoolean(drInvestigation["Cause_1"]);
                if (drInvestigation["Cause_2"] != DBNull.Value) this._Cause_2 = Convert.ToBoolean(drInvestigation["Cause_2"]);
                if (drInvestigation["Cause_3"] != DBNull.Value) this._Cause_3 = Convert.ToBoolean(drInvestigation["Cause_3"]);
                if (drInvestigation["Cause_4"] != DBNull.Value) this._Cause_4 = Convert.ToBoolean(drInvestigation["Cause_4"]);
                if (drInvestigation["Cause_5"] != DBNull.Value) this._Cause_5 = Convert.ToBoolean(drInvestigation["Cause_5"]);
                if (drInvestigation["Cause_6"] != DBNull.Value) this._Cause_6 = Convert.ToBoolean(drInvestigation["Cause_6"]);
                if (drInvestigation["Cause_7"] != DBNull.Value) this._Cause_7 = Convert.ToBoolean(drInvestigation["Cause_7"]);
                if (drInvestigation["Cause_8"] != DBNull.Value) this._Cause_8 = Convert.ToBoolean(drInvestigation["Cause_8"]);
                if (drInvestigation["Cause_9"] != DBNull.Value) this._Cause_9 = Convert.ToBoolean(drInvestigation["Cause_9"]);
                if (drInvestigation["Cause_10"] != DBNull.Value) this._Cause_10 = Convert.ToBoolean(drInvestigation["Cause_10"]);
                if (drInvestigation["Cause_11"] != DBNull.Value) this._Cause_11 = Convert.ToBoolean(drInvestigation["Cause_11"]);
                if (drInvestigation["Cause_12"] != DBNull.Value) this._Cause_12 = Convert.ToBoolean(drInvestigation["Cause_12"]);
                if (drInvestigation["Cause_13"] != DBNull.Value) this._Cause_13 = Convert.ToBoolean(drInvestigation["Cause_13"]);
                if (drInvestigation["Cause_14"] != DBNull.Value) this._Cause_14 = Convert.ToBoolean(drInvestigation["Cause_14"]);
                if (drInvestigation["Cause_15"] != DBNull.Value) this._Cause_15 = Convert.ToBoolean(drInvestigation["Cause_15"]);
                if (drInvestigation["Cause_16"] != DBNull.Value) this._Cause_16 = Convert.ToBoolean(drInvestigation["Cause_16"]);
                if (drInvestigation["Cause_17"] != DBNull.Value) this._Cause_17 = Convert.ToBoolean(drInvestigation["Cause_17"]);
                if (drInvestigation["Cause_18"] != DBNull.Value) this._Cause_18 = Convert.ToBoolean(drInvestigation["Cause_18"]);
                if (drInvestigation["Cause_19"] != DBNull.Value) this._Cause_19 = Convert.ToBoolean(drInvestigation["Cause_19"]);
                if (drInvestigation["Cause_20"] != DBNull.Value) this._Cause_20 = Convert.ToBoolean(drInvestigation["Cause_20"]);
                if (drInvestigation["Cause_21"] != DBNull.Value) this._Cause_21 = Convert.ToBoolean(drInvestigation["Cause_21"]);
                if (drInvestigation["Cause_22"] != DBNull.Value) this._Cause_22 = Convert.ToBoolean(drInvestigation["Cause_22"]);
                if (drInvestigation["Cause_23"] != DBNull.Value) this._Cause_23 = Convert.ToBoolean(drInvestigation["Cause_23"]);
                if (drInvestigation["Cause_24"] != DBNull.Value) this._Cause_24 = Convert.ToBoolean(drInvestigation["Cause_24"]);
                if (drInvestigation["Cause_25"] != DBNull.Value) this._Cause_25 = Convert.ToBoolean(drInvestigation["Cause_25"]);
                if (drInvestigation["Cause_26"] != DBNull.Value) this._Cause_26 = Convert.ToBoolean(drInvestigation["Cause_26"]);
                if (drInvestigation["Cause_27"] != DBNull.Value) this._Cause_27 = Convert.ToBoolean(drInvestigation["Cause_27"]);
                if (drInvestigation["Cause_28"] != DBNull.Value) this._Cause_28 = Convert.ToBoolean(drInvestigation["Cause_28"]);
                if (drInvestigation["Cause_29"] != DBNull.Value) this._Cause_29 = Convert.ToBoolean(drInvestigation["Cause_29"]);
                if (drInvestigation["Cause_30"] != DBNull.Value) this._Cause_30 = Convert.ToBoolean(drInvestigation["Cause_30"]);

                if (drInvestigation["Cause_31"] != DBNull.Value) this._Cause_31 = Convert.ToBoolean(drInvestigation["Cause_31"]);
                if (drInvestigation["Cause_32"] != DBNull.Value) this._Cause_32 = Convert.ToBoolean(drInvestigation["Cause_32"]);
                if (drInvestigation["Cause_33"] != DBNull.Value) this._Cause_33 = Convert.ToBoolean(drInvestigation["Cause_33"]);
                if (drInvestigation["Cause_34"] != DBNull.Value) this._Cause_34 = Convert.ToBoolean(drInvestigation["Cause_34"]);
                if (drInvestigation["Cause_35"] != DBNull.Value) this._Cause_35 = Convert.ToBoolean(drInvestigation["Cause_35"]);
                if (drInvestigation["Cause_36"] != DBNull.Value) this._Cause_36 = Convert.ToBoolean(drInvestigation["Cause_36"]);
                if (drInvestigation["Cause_37"] != DBNull.Value) this._Cause_37 = Convert.ToBoolean(drInvestigation["Cause_37"]);
                if (drInvestigation["Cause_38"] != DBNull.Value) this._Cause_38 = Convert.ToBoolean(drInvestigation["Cause_38"]);
                if (drInvestigation["Cause_39"] != DBNull.Value) this._Cause_39 = Convert.ToBoolean(drInvestigation["Cause_39"]);
                if (drInvestigation["Cause_40"] != DBNull.Value) this._Cause_40 = Convert.ToBoolean(drInvestigation["Cause_40"]);
                if (drInvestigation["Cause_41"] != DBNull.Value) this._Cause_41 = Convert.ToBoolean(drInvestigation["Cause_41"]);
                if (drInvestigation["Cause_42"] != DBNull.Value) this._Cause_42 = Convert.ToBoolean(drInvestigation["Cause_42"]);

                this._Cause_42_detail = Convert.ToString(drInvestigation["Cause_42_detail"]);
                this._Cause_Comment = Convert.ToString(drInvestigation["Cause_Comment"]);
                if (drInvestigation["Personal_Job_Factors_1"] != DBNull.Value) this._Personal_Job_Factors_1 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_1"]);
                if (drInvestigation["Personal_Job_Factors_2"] != DBNull.Value) this._Personal_Job_Factors_2 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_2"]);
                if (drInvestigation["Personal_Job_Factors_3"] != DBNull.Value) this._Personal_Job_Factors_3 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_3"]);
                if (drInvestigation["Personal_Job_Factors_4"] != DBNull.Value) this._Personal_Job_Factors_4 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_4"]);
                if (drInvestigation["Personal_Job_Factors_5"] != DBNull.Value) this._Personal_Job_Factors_5 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_5"]);
                if (drInvestigation["Personal_Job_Factors_6"] != DBNull.Value) this._Personal_Job_Factors_6 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_6"]);
                if (drInvestigation["Personal_Job_Factors_7"] != DBNull.Value) this._Personal_Job_Factors_7 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_7"]);
                if (drInvestigation["Personal_Job_Factors_8"] != DBNull.Value) this._Personal_Job_Factors_8 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_8"]);
                if (drInvestigation["Personal_Job_Factors_9"] != DBNull.Value) this._Personal_Job_Factors_9 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_9"]);
                if (drInvestigation["Personal_Job_Factors_10"] != DBNull.Value) this._Personal_Job_Factors_10 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_10"]);
                if (drInvestigation["Personal_Job_Factors_11"] != DBNull.Value) this._Personal_Job_Factors_11 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_11"]);
                if (drInvestigation["Personal_Job_Factors_12"] != DBNull.Value) this._Personal_Job_Factors_12 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_12"]);
                if (drInvestigation["Personal_Job_Factors_13"] != DBNull.Value) this._Personal_Job_Factors_13 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_13"]);
                if (drInvestigation["Personal_Job_Factors_14"] != DBNull.Value) this._Personal_Job_Factors_14 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_14"]);
                if (drInvestigation["Personal_Job_Factors_15"] != DBNull.Value) this._Personal_Job_Factors_15 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_15"]);
                if (drInvestigation["Personal_Job_Factors_16"] != DBNull.Value) this._Personal_Job_Factors_16 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_16"]);
                if (drInvestigation["Personal_Job_Factors_17"] != DBNull.Value) this._Personal_Job_Factors_17 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_17"]);
                if (drInvestigation["Personal_Job_Factors_18"] != DBNull.Value) this._Personal_Job_Factors_18 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_18"]);
                if (drInvestigation["Personal_Job_Factors_19"] != DBNull.Value) this._Personal_Job_Factors_19 = Convert.ToBoolean(drInvestigation["Personal_Job_Factors_19"]);
                this._Personal_Job_Factors_17_Details = Convert.ToString(drInvestigation["Personal_Job_Factors_17_Details"]);
                this._Personal_Job_Comment = Convert.ToString(drInvestigation["Personal_Job_Comment"]);
                this._Conclusions = Convert.ToString(drInvestigation["Conclusions"]);
                if (drInvestigation["OSHA_Recordable"] != DBNull.Value) this._OSHA_Recordable = Convert.ToBoolean(drInvestigation["OSHA_Recordable"]);
                this._Sonic_Cause_Code = Convert.ToString(drInvestigation["Sonic_Cause_Code"]);
                this._Corrective_Action_Description = Convert.ToString(drInvestigation["Corrective_Action_Description"]);
                this._Assigned_To = Convert.ToString(drInvestigation["Assigned_To"]);
                this._AssignedBy = Convert.ToString(drInvestigation["AssignedBy"]);
                this._To_Be_Competed_by = drInvestigation["To_Be_Competed_by"] != DBNull.Value ? Convert.ToDateTime(drInvestigation["To_Be_Competed_by"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status = Convert.ToString(drInvestigation["Status"]);
                this._Lessons_Learned = Convert.ToString(drInvestigation["Lessons_Learned"]);
                this._Cause_Reviewed = drInvestigation["Cause_Reviewed"] != DBNull.Value ? Convert.ToDateTime(drInvestigation["Cause_Reviewed"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Location_Information_Complete = (drInvestigation["Location_Information_Complete"] != DBNull.Value) ? Convert.ToBoolean(drInvestigation["Location_Information_Complete"]) : false;
                this._RLCM_Complete = (drInvestigation["RLCM_Complete"] != DBNull.Value) ? Convert.ToBoolean(drInvestigation["RLCM_Complete"]) : false; ;
                this._Updated_By = drInvestigation["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drInvestigation["Updated_By"]) : 0;
                this._Updated_Date = drInvestigation["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drInvestigation["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                if (drInvestigation["Investigative_Quality"] == DBNull.Value)
                    this._Investigative_Quality = null;
                else
                    this._Investigative_Quality = (string)drInvestigation["Investigative_Quality"];
                if (drInvestigation["Original_Sonic_S0_Cause_Code"] == DBNull.Value)
                    this._Original_Sonic_S0_Cause_Code = null;
                else
                    this._Original_Sonic_S0_Cause_Code = (string)drInvestigation["Original_Sonic_S0_Cause_Code"];

                if (drInvestigation["Sonic_S0_Cause_Code_Promoted"] == DBNull.Value)
                    this._Sonic_S0_Cause_Code_Promoted = null;
                else
                    this._Sonic_S0_Cause_Code_Promoted = (string)drInvestigation["Sonic_S0_Cause_Code_Promoted"];

                if (drInvestigation["Date_Sonic_S0_Cause_Code_Promoted"] == DBNull.Value)
                    this._Date_Sonic_S0_Cause_Code_Promoted = null;
                else
                    this._Date_Sonic_S0_Cause_Code_Promoted = (DateTime?)drInvestigation["Date_Sonic_S0_Cause_Code_Promoted"];

                if (drInvestigation["Date_Submitted_by_Store"] == DBNull.Value)
                    this._Date_Submitted_by_Store = null;
                else
                    this._Date_Submitted_by_Store = (DateTime?)drInvestigation["Date_Submitted_by_Store"];

                if (drInvestigation["RLCM_Comments"] == DBNull.Value)
                    this._RLCM_Comments = null;
                else
                    this._RLCM_Comments = (string)drInvestigation["RLCM_Comments"];


                if (drInvestigation["Date_RLCM_Review_Completed"] == DBNull.Value)
                    this._Date_RLCM_Review_Completed = null;
                else
                    this._Date_RLCM_Review_Completed = (DateTime?)drInvestigation["Date_RLCM_Review_Completed"];

                if (drInvestigation["Lag_Time"] == DBNull.Value)
                    this._Lag_Time = null;
                else
                    this._Lag_Time = (decimal?)drInvestigation["Lag_Time"];

                if (drInvestigation["FK_LU_Contributing_Factor"] == DBNull.Value)
                    this._FK_LU_Contributing_Factor = null;
                else
                    this._FK_LU_Contributing_Factor = (decimal?)drInvestigation["FK_LU_Contributing_Factor"];

                if (drInvestigation["Contributing_Factor_Other"] == DBNull.Value)
                    this._Contributing_Factor_Other = null;
                else
                    this._Contributing_Factor_Other = (string)drInvestigation["Contributing_Factor_Other"];

                if (drInvestigation["Timing"] == DBNull.Value)
                    this._Timing = null;
                else
                    this._Timing = (string)drInvestigation["Timing"];

                if (drInvestigation["Timing_Comment"] == DBNull.Value)
                    this._Timing_Comment = null;
                else
                    this._Timing_Comment = (string)drInvestigation["Timing_Comment"];

                if (drInvestigation["SLT_Involvement"] == DBNull.Value)
                    this._SLT_Involvement = null;
                else
                    this._SLT_Involvement = (string)drInvestigation["SLT_Involvement"];

                if (drInvestigation["SLT_Involvement_Comment"] == DBNull.Value)
                    this._SLT_Involvement_Comment = null;
                else
                    this._SLT_Involvement_Comment = (string)drInvestigation["SLT_Involvement_Comment"];

                if (drInvestigation["Witnesses"] == DBNull.Value)
                    this._Witnesses = null;
                else
                    this._Witnesses = (string)drInvestigation["Witnesses"];

                if (drInvestigation["Witnesses_Comment"] == DBNull.Value)
                    this._Witnesses_Comment = null;
                else
                    this._Witnesses_Comment = (string)drInvestigation["Witnesses_Comment"];

                if (drInvestigation["SLT_Visit"] == DBNull.Value)
                    this._SLT_Visit = null;
                else
                    this._SLT_Visit = (string)drInvestigation["SLT_Visit"];

                if (drInvestigation["SLT_Visit_Comment"] == DBNull.Value)
                    this._SLT_Visit_Comment = null;
                else
                    this._SLT_Visit_Comment = (string)drInvestigation["SLT_Visit_Comment"];

                if (drInvestigation["Root_Causes"] == DBNull.Value)
                    this._Root_Causes = null;
                else
                    this._Root_Causes = (string)drInvestigation["Root_Causes"];

                if (drInvestigation["Root_Causes_Comment"] == DBNull.Value)
                    this._Root_Causes_Comment = null;
                else
                    this._Root_Causes_Comment = (string)drInvestigation["Root_Causes_Comment"];

                if (drInvestigation["Action_Plan"] == DBNull.Value)
                    this._Action_Plan = null;
                else
                    this._Action_Plan = (string)drInvestigation["Action_Plan"];

                if (drInvestigation["Action_Plan_Comment"] == DBNull.Value)
                    this._Action_Plan_Comment = null;
                else
                    this._Action_Plan_Comment = (string)drInvestigation["Action_Plan_Comment"];

                if (drInvestigation["Focus_Area"] == DBNull.Value)
                    this._Focus_Area = null;
                else
                    this._Focus_Area = (string)drInvestigation["Focus_Area"];

                if (drInvestigation["Communicated"] == DBNull.Value)
                    this._Communicated = null;
                else
                    this._Communicated = (string)drInvestigation["Communicated"];

                if (drInvestigation["Date_Communicated"] == DBNull.Value)
                    this._Date_Communicated = null;
                else
                    this._Date_Communicated = (DateTime?)drInvestigation["Date_Communicated"];

                if (drInvestigation["No_Communication_Explanation"] == DBNull.Value)
                    this._No_Communication_Explanation = null;
                else
                    this._No_Communication_Explanation = (string)drInvestigation["No_Communication_Explanation"];

                if (drInvestigation["FK_LU_OSHA_Incident"] == DBNull.Value)
                    this._FK_LU_OSHA_Incident = null;
                else
                    this._FK_LU_OSHA_Incident = (decimal?)drInvestigation["FK_LU_OSHA_Incident"];

                if (drInvestigation["FK_LU_OSHA_Injury"] == DBNull.Value)
                    this._FK_LU_OSHA_Injury = null;
                else
                    this._FK_LU_OSHA_Injury = (decimal?)drInvestigation["FK_LU_OSHA_Injury"];

                if (drInvestigation["RLCM_Review_Approve"] == DBNull.Value)
                    this._RLCM_Review_Approve = null;
                else
                    this._RLCM_Review_Approve = (string)drInvestigation["RLCM_Review_Approve"];

                this._Physician_Other_Professional = Convert.ToString(drInvestigation["Physician_Other_Professional"]);
                this._Facility = Convert.ToString(drInvestigation["Facility"]);
                this._Facility_Address = Convert.ToString(drInvestigation["Facility_Address"]);
                this._Facility_City = Convert.ToString(drInvestigation["Facility_City"]);

                if (drInvestigation["FK_State_Facility"] == DBNull.Value)
                    this._FK_State_Facility = null;
                else
                    this._FK_State_Facility = Convert.ToDecimal(drInvestigation["FK_State_Facility"]);

                this._Facility_Zip_Code = Convert.ToString(drInvestigation["Facility_Zip_Code"]);
                this._Emergency_Room = Convert.ToString(drInvestigation["Emergency_Room"]);
                this._Time_Began_Work = Convert.ToString(drInvestigation["Time_Began_Work"]);
                this._Activity_Before_Incident = Convert.ToString(drInvestigation["Activity_Before_Incident"]);
                this._Object_Substance_Involved = Convert.ToString(drInvestigation["Object_Substance_Involved"]);

                if (drInvestigation["Admitted_to_Hospital"] != DBNull.Value)
                    this._Admitted_to_Hospital = Convert.ToBoolean(drInvestigation["Admitted_to_Hospital"]);


                if (drInvestigation["Slipping"] == DBNull.Value)
                    this._Slipping = null;
                else
                    this._Slipping = (string)drInvestigation["Slipping"];

                if (drInvestigation["FK_Nature_of_Injury"] == DBNull.Value)
                    this._FK_Nature_of_Injury = null;
                else
                    this._FK_Nature_of_Injury = (decimal)drInvestigation["FK_Nature_of_Injury"];


                if (drInvestigation["FK_Body_Parts_Affected"] == DBNull.Value)
                    this._FK_Body_Parts_Affected = null;
                else
                    this._FK_Body_Parts_Affected = (decimal)drInvestigation["FK_Body_Parts_Affected"];

                if (drInvestigation["Return_To_Work_Date"] == DBNull.Value)
                    this._Return_To_Work_Date = null;
                else
                    this._Return_To_Work_Date = (DateTime?)drInvestigation["Return_To_Work_Date"];
                
            }
            else
            {

                this._PK_Investigation_ID = -1;
                this._FK_WC_FR_ID = -1;
                this._Action_Reviewed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._FK_LU_Location_ID = -1;
                this._Cause_42_detail = "";
                this._Cause_Comment = "";
                this._Personal_Job_Factors_17_Details = "";
                this._Personal_Job_Comment = "";
                this._Conclusions = "";
                this._OSHA_Recordable = null;
                this._Sonic_Cause_Code = "";
                this._Corrective_Action_Description = "";
                this._Assigned_To = "";
                this._AssignedBy = "";
                this._To_Be_Competed_by = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Status = "";
                this._Lessons_Learned = "";
                this._Cause_Reviewed = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Location_Information_Complete = false;
                this._RLCM_Complete = false;
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Investigative_Quality = null;
                this._Original_Sonic_S0_Cause_Code = null;
                this._Sonic_S0_Cause_Code_Promoted = null;
                this._Date_Sonic_S0_Cause_Code_Promoted = null;
                this._RLCM_Comments = null;
                this.FK_LU_Contributing_Factor = null;
                this._Contributing_Factor_Other = "";
                this.Timing = string.Empty;
                this.Timing_Comment = string.Empty;
                this.SLT_Involvement = string.Empty;
                this.SLT_Involvement_Comment = string.Empty;
                this.Witnesses = string.Empty;
                this.Witnesses_Comment = string.Empty;
                this.SLT_Visit = string.Empty;
                this.SLT_Visit_Comment = string.Empty;
                this.Root_Causes = string.Empty;
                this.Root_Causes_Comment = string.Empty;
                this.Action_Plan = string.Empty;
                this.Action_Plan_Comment = string.Empty;
                this.Focus_Area = string.Empty;
                this.Communicated = string.Empty;
                this.Date_Communicated = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this.No_Communication_Explanation = string.Empty;

                this.FK_LU_OSHA_Incident = null;
                this.FK_LU_OSHA_Injury = null;
                this.RLCM_Review_Approve = string.Empty;

                this._Physician_Other_Professional = string.Empty;
                this._Facility = string.Empty;
                this._Facility_Address = string.Empty;
                this._Facility_City = string.Empty;
                this._FK_State_Facility = null;
                this._Facility_Zip_Code = string.Empty;
                this._Emergency_Room = string.Empty;
                this._Time_Began_Work = string.Empty;
                this._Activity_Before_Incident = string.Empty;
                this._Object_Substance_Involved = string.Empty;
                this._Admitted_to_Hospital = false;
                this._Slipping = string.Empty;
                this._FK_Nature_of_Injury = null;
                this._FK_Body_Parts_Affected = null;
                this.Return_To_Work_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inserts a record into the Investigation table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationInsert");

            db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Int32, this._FK_WC_FR_ID);

            if (this._Action_Reviewed != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Action_Reviewed", DbType.DateTime, this._Action_Reviewed);
            else
                db.AddInParameter(dbCommand, "Action_Reviewed", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Cause_1", DbType.Boolean, this._Cause_1);
            db.AddInParameter(dbCommand, "Cause_2", DbType.Boolean, this._Cause_2);
            db.AddInParameter(dbCommand, "Cause_3", DbType.Boolean, this._Cause_3);
            db.AddInParameter(dbCommand, "Cause_4", DbType.Boolean, this._Cause_4);
            db.AddInParameter(dbCommand, "Cause_5", DbType.Boolean, this._Cause_5);
            db.AddInParameter(dbCommand, "Cause_6", DbType.Boolean, this._Cause_6);
            db.AddInParameter(dbCommand, "Cause_7", DbType.Boolean, this._Cause_7);
            db.AddInParameter(dbCommand, "Cause_8", DbType.Boolean, this._Cause_8);
            db.AddInParameter(dbCommand, "Cause_9", DbType.Boolean, this._Cause_9);
            db.AddInParameter(dbCommand, "Cause_10", DbType.Boolean, this._Cause_10);
            db.AddInParameter(dbCommand, "Cause_11", DbType.Boolean, this._Cause_11);
            db.AddInParameter(dbCommand, "Cause_12", DbType.Boolean, this._Cause_12);
            db.AddInParameter(dbCommand, "Cause_13", DbType.Boolean, this._Cause_13);
            db.AddInParameter(dbCommand, "Cause_14", DbType.Boolean, this._Cause_14);
            db.AddInParameter(dbCommand, "Cause_15", DbType.Boolean, this._Cause_15);
            db.AddInParameter(dbCommand, "Cause_16", DbType.Boolean, this._Cause_16);
            db.AddInParameter(dbCommand, "Cause_17", DbType.Boolean, this._Cause_17);
            db.AddInParameter(dbCommand, "Cause_18", DbType.Boolean, this._Cause_18);
            db.AddInParameter(dbCommand, "Cause_19", DbType.Boolean, this._Cause_19);
            db.AddInParameter(dbCommand, "Cause_20", DbType.Boolean, this._Cause_20);
            db.AddInParameter(dbCommand, "Cause_21", DbType.Boolean, this._Cause_21);
            db.AddInParameter(dbCommand, "Cause_22", DbType.Boolean, this._Cause_22);
            db.AddInParameter(dbCommand, "Cause_23", DbType.Boolean, this._Cause_23);
            db.AddInParameter(dbCommand, "Cause_24", DbType.Boolean, this._Cause_24);
            db.AddInParameter(dbCommand, "Cause_25", DbType.Boolean, this._Cause_25);
            db.AddInParameter(dbCommand, "Cause_26", DbType.Boolean, this._Cause_26);
            db.AddInParameter(dbCommand, "Cause_27", DbType.Boolean, this._Cause_27);
            db.AddInParameter(dbCommand, "Cause_28", DbType.Boolean, this._Cause_28);
            db.AddInParameter(dbCommand, "Cause_29", DbType.Boolean, this._Cause_29);
            db.AddInParameter(dbCommand, "Cause_30", DbType.Boolean, this._Cause_30);
            db.AddInParameter(dbCommand, "Cause_31", DbType.Boolean, this._Cause_31);
            db.AddInParameter(dbCommand, "Cause_32", DbType.Boolean, this._Cause_32);
            db.AddInParameter(dbCommand, "Cause_33", DbType.Boolean, this._Cause_33);
            db.AddInParameter(dbCommand, "Cause_34", DbType.Boolean, this._Cause_34);
            db.AddInParameter(dbCommand, "Cause_35", DbType.Boolean, this._Cause_35);
            db.AddInParameter(dbCommand, "Cause_36", DbType.Boolean, this._Cause_36);
            db.AddInParameter(dbCommand, "Cause_37", DbType.Boolean, this._Cause_37);
            db.AddInParameter(dbCommand, "Cause_38", DbType.Boolean, this._Cause_38);
            db.AddInParameter(dbCommand, "Cause_39", DbType.Boolean, this._Cause_39);
            db.AddInParameter(dbCommand, "Cause_40", DbType.Boolean, this._Cause_40);
            db.AddInParameter(dbCommand, "Cause_41", DbType.Boolean, this._Cause_41);
            db.AddInParameter(dbCommand, "Cause_42", DbType.Boolean, this._Cause_42);
            db.AddInParameter(dbCommand, "Cause_42_detail", DbType.String, this._Cause_42_detail);
            db.AddInParameter(dbCommand, "Cause_Comment", DbType.String, this._Cause_Comment);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_1", DbType.Boolean, this._Personal_Job_Factors_1);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_2", DbType.Boolean, this._Personal_Job_Factors_2);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_3", DbType.Boolean, this._Personal_Job_Factors_3);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_4", DbType.Boolean, this._Personal_Job_Factors_4);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_5", DbType.Boolean, this._Personal_Job_Factors_5);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_6", DbType.Boolean, this._Personal_Job_Factors_6);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_7", DbType.Boolean, this._Personal_Job_Factors_7);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_8", DbType.Boolean, this._Personal_Job_Factors_8);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_9", DbType.Boolean, this._Personal_Job_Factors_9);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_10", DbType.Boolean, this._Personal_Job_Factors_10);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_11", DbType.Boolean, this._Personal_Job_Factors_11);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_12", DbType.Boolean, this._Personal_Job_Factors_12);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_13", DbType.Boolean, this._Personal_Job_Factors_13);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_14", DbType.Boolean, this._Personal_Job_Factors_14);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_15", DbType.Boolean, this._Personal_Job_Factors_15);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_16", DbType.Boolean, this._Personal_Job_Factors_16);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_17", DbType.Boolean, this._Personal_Job_Factors_17);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_18", DbType.Boolean, this._Personal_Job_Factors_18);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_19", DbType.Boolean, this._Personal_Job_Factors_19);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_17_Details", DbType.String, this._Personal_Job_Factors_17_Details);
            db.AddInParameter(dbCommand, "Personal_Job_Comment", DbType.String, this._Personal_Job_Comment);
            db.AddInParameter(dbCommand, "Conclusions", DbType.String, this._Conclusions);

            if (this._OSHA_Recordable == null)
                db.AddInParameter(dbCommand, "OSHA_Recordable", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OSHA_Recordable", DbType.Boolean, this._OSHA_Recordable);

            db.AddInParameter(dbCommand, "Sonic_Cause_Code", DbType.String, this._Sonic_Cause_Code);
            db.AddInParameter(dbCommand, "Corrective_Action_Description", DbType.String, this._Corrective_Action_Description);
            db.AddInParameter(dbCommand, "Assigned_To", DbType.String, this._Assigned_To);
            db.AddInParameter(dbCommand, "AssignedBy", DbType.String, this._AssignedBy);

            if (this._To_Be_Competed_by != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "To_Be_Competed_by", DbType.DateTime, this._To_Be_Competed_by);
            else
                db.AddInParameter(dbCommand, "To_Be_Competed_by", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);
            db.AddInParameter(dbCommand, "Lessons_Learned", DbType.String, this._Lessons_Learned);

            if (this._Cause_Reviewed != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Cause_Reviewed", DbType.DateTime, this._Cause_Reviewed);
            else
                db.AddInParameter(dbCommand, "Cause_Reviewed", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Location_Information_Complete", DbType.Boolean, this._Location_Information_Complete);
            db.AddInParameter(dbCommand, "RLCM_Complete", DbType.Boolean, this._RLCM_Complete);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            if (string.IsNullOrEmpty(this._Investigative_Quality))
                db.AddInParameter(dbCommand, "Investigative_Quality", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigative_Quality", DbType.String, this._Investigative_Quality);
            if (string.IsNullOrEmpty(this._Original_Sonic_S0_Cause_Code))
                db.AddInParameter(dbCommand, "Original_Sonic_S0_Cause_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Original_Sonic_S0_Cause_Code", DbType.String, this._Original_Sonic_S0_Cause_Code);

            if (string.IsNullOrEmpty(this._Sonic_S0_Cause_Code_Promoted))
                db.AddInParameter(dbCommand, "Sonic_S0_Cause_Code_Promoted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_S0_Cause_Code_Promoted", DbType.String, this._Sonic_S0_Cause_Code_Promoted);

            db.AddInParameter(dbCommand, "Date_Sonic_S0_Cause_Code_Promoted", DbType.DateTime, this._Date_Sonic_S0_Cause_Code_Promoted);

            db.AddInParameter(dbCommand, "Date_Submitted_by_Store", DbType.DateTime, this._Date_Submitted_by_Store);

            if (string.IsNullOrEmpty(this._RLCM_Comments))
                db.AddInParameter(dbCommand, "RLCM_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Comments", DbType.String, this._RLCM_Comments);

            db.AddInParameter(dbCommand, "Date_RLCM_Review_Completed", DbType.DateTime, this._Date_RLCM_Review_Completed);
            db.AddInParameter(dbCommand, "Lag_Time", DbType.Decimal, this._Lag_Time);
            db.AddInParameter(dbCommand, "FK_LU_Contributing_Factor", DbType.Decimal, this._FK_LU_Contributing_Factor);
            if (string.IsNullOrEmpty(this._Contributing_Factor_Other))
                db.AddInParameter(dbCommand, "Contributing_Factor_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contributing_Factor_Other", DbType.String, this._Contributing_Factor_Other);

            db.AddInParameter(dbCommand, "Timing", DbType.String, this._Timing);
            db.AddInParameter(dbCommand, "Timing_Comment", DbType.String, this._Timing_Comment);
            db.AddInParameter(dbCommand, "SLT_Involvement", DbType.String, this._SLT_Involvement);
            db.AddInParameter(dbCommand, "SLT_Involvement_Comment", DbType.String, this._SLT_Involvement_Comment);
            db.AddInParameter(dbCommand, "Witnesses", DbType.String, this._Witnesses);
            db.AddInParameter(dbCommand, "Witnesses_Comment", DbType.String, this._Witnesses_Comment);
            db.AddInParameter(dbCommand, "SLT_Visit", DbType.String, this._SLT_Visit);
            db.AddInParameter(dbCommand, "SLT_Visit_Comment", DbType.String, this._SLT_Visit_Comment);
            db.AddInParameter(dbCommand, "Root_Causes", DbType.String, this._Root_Causes);
            db.AddInParameter(dbCommand, "Root_Causes_Comment", DbType.String, this._Root_Causes_Comment);
            db.AddInParameter(dbCommand, "Action_Plan", DbType.String, this._Action_Plan);
            db.AddInParameter(dbCommand, "Action_Plan_Comment", DbType.String, this._Action_Plan_Comment);

            if (string.IsNullOrEmpty(this._Focus_Area))
                db.AddInParameter(dbCommand, "Focus_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Focus_Area", DbType.String, this._Focus_Area);

            if (string.IsNullOrEmpty(this._Communicated))
                db.AddInParameter(dbCommand, "Communicated", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Communicated", DbType.String, this._Communicated);

            db.AddInParameter(dbCommand, "Date_Communicated", DbType.DateTime, this._Date_Communicated);

            if (string.IsNullOrEmpty(this._No_Communication_Explanation))
                db.AddInParameter(dbCommand, "No_Communication_Explanation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "No_Communication_Explanation", DbType.String, this._No_Communication_Explanation);

            db.AddInParameter(dbCommand, "FK_LU_OSHA_Incident", DbType.Decimal, this._FK_LU_OSHA_Incident);

            db.AddInParameter(dbCommand, "FK_LU_OSHA_Injury", DbType.Decimal, this._FK_LU_OSHA_Injury);

            if (string.IsNullOrEmpty(this._RLCM_Review_Approve))
                db.AddInParameter(dbCommand, "RLCM_Review_Approve", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Review_Approve", DbType.String, this._RLCM_Review_Approve);

            db.AddInParameter(dbCommand, "Physician_Other_Professional", DbType.String, this._Physician_Other_Professional);
            db.AddInParameter(dbCommand, "Facility", DbType.String, this._Facility);
            db.AddInParameter(dbCommand, "Facility_Address", DbType.String, this._Facility_Address);
            db.AddInParameter(dbCommand, "Facility_City", DbType.String, this._Facility_City);
            db.AddInParameter(dbCommand, "FK_State_Facility", DbType.Decimal, this._FK_State_Facility);
            db.AddInParameter(dbCommand, "Facility_Zip_Code", DbType.String, this._Facility_Zip_Code);
            db.AddInParameter(dbCommand, "Emergency_Room", DbType.String, this._Emergency_Room);
            db.AddInParameter(dbCommand, "Time_Began_Work", DbType.String, this._Time_Began_Work);
            db.AddInParameter(dbCommand, "Activity_Before_Incident", DbType.String, this._Activity_Before_Incident);
            db.AddInParameter(dbCommand, "Object_Substance_Involved", DbType.String, this._Object_Substance_Involved);
            db.AddInParameter(dbCommand, "Admitted_to_Hospital", DbType.Boolean, this._Admitted_to_Hospital);

            if (string.IsNullOrEmpty(this._Slipping))
                db.AddInParameter(dbCommand, "Slipping", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Slipping", DbType.String, this._Slipping);

            db.AddInParameter(dbCommand, "Return_to_Work_Date", DbType.DateTime, this._Return_To_Work_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Investigation table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Investigation_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationSelectByPK");

            db.AddInParameter(dbCommand, "PK_Investigation_ID", DbType.Int32, pK_Investigation_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Investigation table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Investigation table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationUpdate");

            db.AddInParameter(dbCommand, "PK_Investigation_ID", DbType.Int32, this._PK_Investigation_ID);
            db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Int32, this._FK_WC_FR_ID);
            if (this._Action_Reviewed != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Action_Reviewed", DbType.DateTime, this._Action_Reviewed);
            else
                db.AddInParameter(dbCommand, "Action_Reviewed", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, this._FK_LU_Location_ID);
            db.AddInParameter(dbCommand, "Cause_1", DbType.Boolean, this._Cause_1);
            db.AddInParameter(dbCommand, "Cause_2", DbType.Boolean, this._Cause_2);
            db.AddInParameter(dbCommand, "Cause_3", DbType.Boolean, this._Cause_3);
            db.AddInParameter(dbCommand, "Cause_4", DbType.Boolean, this._Cause_4);
            db.AddInParameter(dbCommand, "Cause_5", DbType.Boolean, this._Cause_5);
            db.AddInParameter(dbCommand, "Cause_6", DbType.Boolean, this._Cause_6);
            db.AddInParameter(dbCommand, "Cause_7", DbType.Boolean, this._Cause_7);
            db.AddInParameter(dbCommand, "Cause_8", DbType.Boolean, this._Cause_8);
            db.AddInParameter(dbCommand, "Cause_9", DbType.Boolean, this._Cause_9);
            db.AddInParameter(dbCommand, "Cause_10", DbType.Boolean, this._Cause_10);
            db.AddInParameter(dbCommand, "Cause_11", DbType.Boolean, this._Cause_11);
            db.AddInParameter(dbCommand, "Cause_12", DbType.Boolean, this._Cause_12);
            db.AddInParameter(dbCommand, "Cause_13", DbType.Boolean, this._Cause_13);
            db.AddInParameter(dbCommand, "Cause_14", DbType.Boolean, this._Cause_14);
            db.AddInParameter(dbCommand, "Cause_15", DbType.Boolean, this._Cause_15);
            db.AddInParameter(dbCommand, "Cause_16", DbType.Boolean, this._Cause_16);
            db.AddInParameter(dbCommand, "Cause_17", DbType.Boolean, this._Cause_17);
            db.AddInParameter(dbCommand, "Cause_18", DbType.Boolean, this._Cause_18);
            db.AddInParameter(dbCommand, "Cause_19", DbType.Boolean, this._Cause_19);
            db.AddInParameter(dbCommand, "Cause_20", DbType.Boolean, this._Cause_20);
            db.AddInParameter(dbCommand, "Cause_21", DbType.Boolean, this._Cause_21);
            db.AddInParameter(dbCommand, "Cause_22", DbType.Boolean, this._Cause_22);
            db.AddInParameter(dbCommand, "Cause_23", DbType.Boolean, this._Cause_23);
            db.AddInParameter(dbCommand, "Cause_24", DbType.Boolean, this._Cause_24);
            db.AddInParameter(dbCommand, "Cause_25", DbType.Boolean, this._Cause_25);
            db.AddInParameter(dbCommand, "Cause_26", DbType.Boolean, this._Cause_26);
            db.AddInParameter(dbCommand, "Cause_27", DbType.Boolean, this._Cause_27);
            db.AddInParameter(dbCommand, "Cause_28", DbType.Boolean, this._Cause_28);
            db.AddInParameter(dbCommand, "Cause_29", DbType.Boolean, this._Cause_29);
            db.AddInParameter(dbCommand, "Cause_30", DbType.Boolean, this._Cause_30);
            db.AddInParameter(dbCommand, "Cause_31", DbType.Boolean, this._Cause_31);
            db.AddInParameter(dbCommand, "Cause_32", DbType.Boolean, this._Cause_32);
            db.AddInParameter(dbCommand, "Cause_33", DbType.Boolean, this._Cause_33);
            db.AddInParameter(dbCommand, "Cause_34", DbType.Boolean, this._Cause_34);
            db.AddInParameter(dbCommand, "Cause_35", DbType.Boolean, this._Cause_35);
            db.AddInParameter(dbCommand, "Cause_36", DbType.Boolean, this._Cause_36);
            db.AddInParameter(dbCommand, "Cause_37", DbType.Boolean, this._Cause_37);
            db.AddInParameter(dbCommand, "Cause_38", DbType.Boolean, this._Cause_38);
            db.AddInParameter(dbCommand, "Cause_39", DbType.Boolean, this._Cause_39);
            db.AddInParameter(dbCommand, "Cause_40", DbType.Boolean, this._Cause_40);
            db.AddInParameter(dbCommand, "Cause_41", DbType.Boolean, this._Cause_41);
            db.AddInParameter(dbCommand, "Cause_42", DbType.Boolean, this._Cause_42);
            db.AddInParameter(dbCommand, "Cause_42_detail", DbType.String, this._Cause_42_detail);
            db.AddInParameter(dbCommand, "Cause_Comment", DbType.String, this._Cause_Comment);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_1", DbType.Boolean, this._Personal_Job_Factors_1);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_2", DbType.Boolean, this._Personal_Job_Factors_2);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_3", DbType.Boolean, this._Personal_Job_Factors_3);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_4", DbType.Boolean, this._Personal_Job_Factors_4);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_5", DbType.Boolean, this._Personal_Job_Factors_5);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_6", DbType.Boolean, this._Personal_Job_Factors_6);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_7", DbType.Boolean, this._Personal_Job_Factors_7);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_8", DbType.Boolean, this._Personal_Job_Factors_8);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_9", DbType.Boolean, this._Personal_Job_Factors_9);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_10", DbType.Boolean, this._Personal_Job_Factors_10);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_11", DbType.Boolean, this._Personal_Job_Factors_11);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_12", DbType.Boolean, this._Personal_Job_Factors_12);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_13", DbType.Boolean, this._Personal_Job_Factors_13);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_14", DbType.Boolean, this._Personal_Job_Factors_14);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_15", DbType.Boolean, this._Personal_Job_Factors_15);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_16", DbType.Boolean, this._Personal_Job_Factors_16);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_17", DbType.Boolean, this._Personal_Job_Factors_17);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_18", DbType.Boolean, this._Personal_Job_Factors_18);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_19", DbType.Boolean, this._Personal_Job_Factors_19);
            db.AddInParameter(dbCommand, "Personal_Job_Factors_17_Details", DbType.String, this._Personal_Job_Factors_17_Details);
            db.AddInParameter(dbCommand, "Personal_Job_Comment", DbType.String, this._Personal_Job_Comment);
            db.AddInParameter(dbCommand, "Conclusions", DbType.String, this._Conclusions);

            if (this._OSHA_Recordable == null)
                db.AddInParameter(dbCommand, "OSHA_Recordable", DbType.Boolean, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OSHA_Recordable", DbType.Boolean, this._OSHA_Recordable);

            db.AddInParameter(dbCommand, "Sonic_Cause_Code", DbType.String, this._Sonic_Cause_Code);
            db.AddInParameter(dbCommand, "Corrective_Action_Description", DbType.String, this._Corrective_Action_Description);
            db.AddInParameter(dbCommand, "Assigned_To", DbType.String, this._Assigned_To);
            db.AddInParameter(dbCommand, "AssignedBy", DbType.String, this._AssignedBy);

            if (this._To_Be_Competed_by != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "To_Be_Competed_by", DbType.DateTime, this._To_Be_Competed_by);
            else
                db.AddInParameter(dbCommand, "To_Be_Competed_by", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);
            db.AddInParameter(dbCommand, "Lessons_Learned", DbType.String, this._Lessons_Learned);

            if (this._Cause_Reviewed != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Cause_Reviewed", DbType.DateTime, this._Cause_Reviewed);
            else
                db.AddInParameter(dbCommand, "Cause_Reviewed", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "Location_Information_Complete", DbType.Boolean, this._Location_Information_Complete);
            db.AddInParameter(dbCommand, "RLCM_Complete", DbType.Boolean, this._RLCM_Complete);
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, DateTime.Now);
            if (string.IsNullOrEmpty(this._Investigative_Quality))
                db.AddInParameter(dbCommand, "Investigative_Quality", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigative_Quality", DbType.String, this._Investigative_Quality);
            if (string.IsNullOrEmpty(this._Original_Sonic_S0_Cause_Code))
                db.AddInParameter(dbCommand, "Original_Sonic_S0_Cause_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Original_Sonic_S0_Cause_Code", DbType.String, this._Original_Sonic_S0_Cause_Code);

            if (string.IsNullOrEmpty(this._Sonic_S0_Cause_Code_Promoted))
                db.AddInParameter(dbCommand, "Sonic_S0_Cause_Code_Promoted", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_S0_Cause_Code_Promoted", DbType.String, this._Sonic_S0_Cause_Code_Promoted);

            db.AddInParameter(dbCommand, "Date_Sonic_S0_Cause_Code_Promoted", DbType.DateTime, this._Date_Sonic_S0_Cause_Code_Promoted);

            db.AddInParameter(dbCommand, "Date_Submitted_by_Store", DbType.DateTime, this._Date_Submitted_by_Store);

            if (string.IsNullOrEmpty(this._RLCM_Comments))
                db.AddInParameter(dbCommand, "RLCM_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Comments", DbType.String, this._RLCM_Comments);

            db.AddInParameter(dbCommand, "Date_RLCM_Review_Completed", DbType.DateTime, this._Date_RLCM_Review_Completed);
            db.AddInParameter(dbCommand, "Lag_Time", DbType.Decimal, this._Lag_Time);
            db.AddInParameter(dbCommand, "FK_LU_Contributing_Factor", DbType.Decimal, this._FK_LU_Contributing_Factor);
            if (string.IsNullOrEmpty(this._Contributing_Factor_Other))
                db.AddInParameter(dbCommand, "Contributing_Factor_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contributing_Factor_Other", DbType.String, this._Contributing_Factor_Other);

            db.AddInParameter(dbCommand, "Timing", DbType.String, this._Timing);
            db.AddInParameter(dbCommand, "Timing_Comment", DbType.String, this._Timing_Comment);
            db.AddInParameter(dbCommand, "SLT_Involvement", DbType.String, this._SLT_Involvement);
            db.AddInParameter(dbCommand, "SLT_Involvement_Comment", DbType.String, this._SLT_Involvement_Comment);
            db.AddInParameter(dbCommand, "Witnesses", DbType.String, this._Witnesses);
            db.AddInParameter(dbCommand, "Witnesses_Comment", DbType.String, this._Witnesses_Comment);
            db.AddInParameter(dbCommand, "SLT_Visit", DbType.String, this._SLT_Visit);
            db.AddInParameter(dbCommand, "SLT_Visit_Comment", DbType.String, this._SLT_Visit_Comment);
            db.AddInParameter(dbCommand, "Root_Causes", DbType.String, this._Root_Causes);
            db.AddInParameter(dbCommand, "Root_Causes_Comment", DbType.String, this._Root_Causes_Comment);
            db.AddInParameter(dbCommand, "Action_Plan", DbType.String, this._Action_Plan);
            db.AddInParameter(dbCommand, "Action_Plan_Comment", DbType.String, this._Action_Plan_Comment);
            if (string.IsNullOrEmpty(this._Focus_Area))
                db.AddInParameter(dbCommand, "Focus_Area", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Focus_Area", DbType.String, this._Focus_Area);

            if (string.IsNullOrEmpty(this._Communicated))
                db.AddInParameter(dbCommand, "Communicated", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Communicated", DbType.String, this._Communicated);

            db.AddInParameter(dbCommand, "Date_Communicated", DbType.DateTime, this._Date_Communicated);

            if (string.IsNullOrEmpty(this._No_Communication_Explanation))
                db.AddInParameter(dbCommand, "No_Communication_Explanation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "No_Communication_Explanation", DbType.String, this._No_Communication_Explanation);

            db.AddInParameter(dbCommand, "FK_LU_OSHA_Incident", DbType.Decimal, this._FK_LU_OSHA_Incident);

            db.AddInParameter(dbCommand, "FK_LU_OSHA_Injury", DbType.Decimal, this._FK_LU_OSHA_Injury);

            if (string.IsNullOrEmpty(this._RLCM_Review_Approve))
                db.AddInParameter(dbCommand, "RLCM_Review_Approve", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "RLCM_Review_Approve", DbType.String, this._RLCM_Review_Approve);

            db.AddInParameter(dbCommand, "Physician_Other_Professional", DbType.String, this._Physician_Other_Professional);
            db.AddInParameter(dbCommand, "Facility", DbType.String, this._Facility);
            db.AddInParameter(dbCommand, "Facility_Address", DbType.String, this._Facility_Address);
            db.AddInParameter(dbCommand, "Facility_City", DbType.String, this._Facility_City);
            db.AddInParameter(dbCommand, "FK_State_Facility", DbType.Decimal, this._FK_State_Facility);
            db.AddInParameter(dbCommand, "Facility_Zip_Code", DbType.String, this._Facility_Zip_Code);
            db.AddInParameter(dbCommand, "Emergency_Room", DbType.String, this._Emergency_Room);
            db.AddInParameter(dbCommand, "Time_Began_Work", DbType.String, this._Time_Began_Work);
            db.AddInParameter(dbCommand, "Activity_Before_Incident", DbType.String, this._Activity_Before_Incident);
            db.AddInParameter(dbCommand, "Object_Substance_Involved", DbType.String, this._Object_Substance_Involved);
            if (this._Admitted_to_Hospital != true && this.Admitted_to_Hospital != false)
            {
                db.AddInParameter(dbCommand, "Admitted_to_Hospital", DbType.Boolean, DBNull.Value);
            }
            else
            {
                db.AddInParameter(dbCommand, "Admitted_to_Hospital", DbType.Boolean, this._Admitted_to_Hospital);
            }

            if (string.IsNullOrEmpty(this._Slipping))
                db.AddInParameter(dbCommand, "Slipping", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Slipping", DbType.String, this._Slipping);

            db.AddInParameter(dbCommand, "FK_Nature_of_Injury", DbType.Decimal, this._FK_Nature_of_Injury);
            db.AddInParameter(dbCommand, "FK_Body_Parts_Affected", DbType.Decimal, this._FK_Body_Parts_Affected);
            db.AddInParameter(dbCommand, "Return_to_Work_Date", DbType.DateTime, this._Return_To_Work_Date);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Investigation table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Investigation_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Investigation_ID", DbType.Int32, pK_Investigation_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static int SelectPKByWc_FR_ID(int Wc_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationSelectPKByWc_FR_ID");

            db.AddInParameter(dbCommand, "FK_WC_FR_ID", DbType.Int32, Wc_FR_ID);
            db.AddOutParameter(dbCommand, "PK_Investigation_ID", DbType.Int32, 1);

            db.ExecuteNonQuery(dbCommand);
            return Convert.ToInt32(dbCommand.Parameters["@PK_Investigation_ID"].Value);
        }

        public static DataSet GetWCInformation(decimal WC_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationGetWCInformation");
            db.AddInParameter(dbCommand, "WC_FR_ID", DbType.Decimal, WC_FR_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        //InvestigationSelectByWc_FR_ID 

        public static DataSet SelectByWc_FR_ID(decimal PK_WC_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationSelectByWc_FR_ID");

            db.AddInParameter(dbCommand, "PK_WC_FR_ID", DbType.Decimal, PK_WC_FR_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectWCsByRMLocation(string rM_Location_Number, decimal wC_FR_ID_To_Exclude)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationSelectWCByRMLocation");
            db.AddInParameter(dbCommand, "RM_Location_Number", DbType.String, rM_Location_Number);
            db.AddInParameter(dbCommand, "WC_FR_ID_To_Exclude", DbType.Decimal, wC_FR_ID_To_Exclude);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFKLocation(int fK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationSelectByFKLocation");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location);
            return db.ExecuteDataSet(dbCommand);
        }

        public static int SelectPKByFKLoc(int fK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationSelectPKByFKLoc");
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Int32, fK_LU_Location);
            db.AddOutParameter(dbCommand, "PK_Investigation_ID", DbType.Int32, 1);
            db.ExecuteNonQuery(dbCommand);

            return Convert.ToInt32(dbCommand.Parameters["@PK_Investigation_ID"].Value);
        }

        public static DataSet SearchByPaging(string strPKLocationIDs, decimal fr_number, string strIncidentDate, string strFromDate, string strToDate, string strRegional, Nullable<decimal> decCurrentEmployee, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationSearch");

            db.AddInParameter(dbCommand, "PK_Location_IDs", DbType.String, strPKLocationIDs);
            db.AddInParameter(dbCommand, "IncidentDate", DbType.String, strIncidentDate);
            db.AddInParameter(dbCommand, "From_Date", DbType.String, strFromDate);
            db.AddInParameter(dbCommand, "FR_Number", DbType.Decimal, fr_number);
            db.AddInParameter(dbCommand, "To_Date", DbType.String, strToDate);
            db.AddInParameter(dbCommand, "Regional", DbType.String, strRegional);
            if (decCurrentEmployee != null && decCurrentEmployee > 0)
                db.AddInParameter(dbCommand, "CurrentEmployee", DbType.Decimal, decCurrentEmployee);
            else
                db.AddInParameter(dbCommand, "CurrentEmployee", DbType.Decimal, DBNull.Value);

            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataTable SelectRegionalOfficers(decimal lu_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("InvestigationSelectRegionalOfficers");
            db.AddInParameter(dbCommand, "@PK_LU_Location_ID", DbType.Decimal, lu_Location_ID);
            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// get All Investigation Record for Passed Comma seperated Region like ',1,2,'
        /// </summary>
        /// <param name="strRegion"></param>
        /// <returns></returns>
        public static DataTable GetAllInvestigationByRegion(string strRegion)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Investigation_SelectByRegion");

            db.AddInParameter(dbCommand, "@Region", DbType.String, strRegion);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        public static void UpdateSonicCauseCode(decimal pk_Investigation, string strSonic_Cause_Code)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UpdateInvestigation_SonicCauseCode");

            db.AddInParameter(dbCommand, "PK_Investigation_ID", DbType.Decimal, pk_Investigation);
            db.AddInParameter(dbCommand, "Sonic_Cause_Code", DbType.String, strSonic_Cause_Code);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Cause_Code_Information table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllCauseCodeInformation()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_Code_InformationFocusAreaSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the LU_Cause_Code_Information table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAllCauseCodeInformationByMasterNode(int Master_Order)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_Cause_Code_InformationSelectByMasterOrder");
            db.AddInParameter(dbCommand, "Master_Order", DbType.Int32, Master_Order);
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}
