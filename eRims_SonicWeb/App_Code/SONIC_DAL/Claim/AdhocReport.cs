using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for AdhocReport
    /// </summary>
    public class AdhocReport
    {
        #region Private variables used to hold the property values

        private decimal? _ReportId;
        private string _ReportName;
        private string _Claim_Type;
        private string _AL_Claim_Origin;
        private string _OStatus;
        private string _CStatus;
        private string _ROStatus;
        private string _ClaimOpenCriteria;
        private DateTime? _ClaimOpenStartDate;
        private DateTime? _ClaimOpenEndDate;
        private string _ClaimCloseCriteria;
        private DateTime? _ClaimCloseStartDate;
        private DateTime? _ClaimCloseEndDate;
        private string _DOICriteria;
        private DateTime? _DOIStart;
        private DateTime? _DOIEnd;
        private string _ValueAsOfDateCriteria;
        private DateTime? _ValueAsOfDateStartDate;
        private DateTime? _ValueAsOfDateEndDate;
        private string _ClaimReserveCriteria;
        private DateTime? _ClaimReserveStartDate;
        private DateTime? _ClaimReserveEndDate;
        private string _ClaimPaymentCriteria;
        private DateTime? _ClaimPaymentStartDate;
        private DateTime? _ClaimPaymentEndDate;
        private string _Location;
        private string _Region;
        private string _Market;
        private string _CoverageState;
        private string _BodyPart;
        private string _Cause;
        private string _NatureOfInjury;
        private string _MPCriteria;
        private decimal? _MPStartAmount;
        private decimal? _MPEndAmount;
        private string _MICriteria;
        private decimal? _MIStartAmount;
        private decimal? _MIEndAmount;
        private string _EPCriteria;
        private decimal? _EPStartAmount;
        private decimal? _EPEndAmount;
        private string _EICriteria;
        private decimal? _EIStartAmount;
        private decimal? _EIEndAmount;
        private string _IPCriteria;
        private decimal? _IPStartAmount;
        private decimal? _IPEndAmount;
        private string _IICriteria;
        private decimal? _IIStartAmount;
        private decimal? _IIEndAmount;
        private string _TPCriteria;
        private decimal? _TPStartAmount;
        private decimal? _TPEndAmount;
        private string _TICriteria;
        private decimal? _TIStartAmount;
        private decimal? _TIEndAmount;
        private string _TOCriteria;
        private decimal? _TOStartAmount;
        private decimal? _TOEndAmount;
        private string _OutputFields;
        private string _SortFields;
        private string _ShowSubTotal;
        private string _ShowGrandTotal;
        private DateTime? _PriorValueDate;
        private decimal? _UserId;
        private DateTime? _UpdatedDate;
        private string _MOCriteria;
        private decimal? _MOStartAmount;
        private decimal? _MOEndAmount;
        private string _EOCriteria;
        private decimal? _EOStartAmount;
        private decimal? _EOEndAmount;
        private string _IOCriteria;
        private decimal? _IOStartAmount;
        private decimal? _IOEndAmount;
        private string _OutputFieldsOrder;
        private string _Indicator;
        private string _SonicCauseCode;
        private string _ClaimSubStaus;
        private string _FullFinalClincher;

        private string _TCompCriteria;
        private decimal? _TCompStartAmount;
        private decimal? _TCompEndAmount;
        private string _TReserveCriteria;
        private decimal? _TReserveStartAmount;
        private decimal? _TReserveEndAmount;
        private string _UCostCriteria;
        private decimal? _UCostStartAmount;
        private decimal? _UCostEndAmount;
        private string _LMVCriteria;
        private decimal? _LMVStartAmount;
        private decimal? _LMVEndAmount;
        private string _HCPCriteria;
        private decimal? _HCPStartAmount;
        private decimal? _HCPEndAmount;
        private string _HCRCriteria;
        private decimal? _HCRStartAmount;
        private decimal? _HCREndAmount;
        private string _SColledtedCriteria;
        private decimal? _SColledtedStartAmount;
        private decimal? _SColledtedEndAmount;
        private string _TChargedCriteria;        
        private decimal? _TChargedStartAmount;
        private decimal? _TChargedEndAmount;
        private string _TTotalPaidCriteria;
        private decimal? _TTotalPaidStartAmount;
        private decimal? _TTotalPaidEndAmount;
        private string _LineofCoverage;
        private string _DateRestrictedBeginCriteria;
        private DateTime? _DateRestrictedBeginStartDate;
        private DateTime? _DateRestrictedBeginEndDate;
        private string _DateRestrictedEndCriteria;
        private DateTime? _DateRestrictedEndStartDate;
        private DateTime? _DateRestrictedEndEndDate;

        #endregion

        #region Public Property

        
        /// <summary>
        /// Gets or sets the ReportId value.
        /// </summary>
        public decimal? ReportId
        {
            get { return _ReportId; }
            set { _ReportId = value; }
        }

        /// <summary>
        /// Gets or sets the ReportName value.
        /// </summary>
        public string ReportName
        {
            get { return _ReportName; }
            set { _ReportName = value; }
        }

        /// <summary>
        /// Gets or sets the Claim_Type value.
        /// </summary>
        public string Claim_Type
        {
            get { return _Claim_Type; }
            set { _Claim_Type = value; }
        }

        /// <summary>
        /// Gets or sets AL_Claim_Origin
        /// </summary>
        public string AL_Claim_Origin
        {
            get { return _AL_Claim_Origin; }
            set { _AL_Claim_Origin = value; }
        }

        /// <summary>
        /// Gets or sets the OStatus value.
        /// </summary>
        public string OStatus
        {
            get { return _OStatus; }
            set { _OStatus = value; }
        }

        /// <summary>
        /// Gets or sets the CStatus value.
        /// </summary>
        public string CStatus
        {
            get { return _CStatus; }
            set { _CStatus = value; }
        }

        /// <summary>
        /// Gets or sets the ROStatus value.
        /// </summary>
        public string ROStatus
        {
            get { return _ROStatus; }
            set { _ROStatus = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimOpenCriteria value.
        /// </summary>
        public string ClaimOpenCriteria
        {
            get { return _ClaimOpenCriteria; }
            set { _ClaimOpenCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimOpenStartDate value.
        /// </summary>
        public DateTime? ClaimOpenStartDate
        {
            get { return _ClaimOpenStartDate; }
            set { _ClaimOpenStartDate = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimOpenEndDate value.
        /// </summary>
        public DateTime? ClaimOpenEndDate
        {
            get { return _ClaimOpenEndDate; }
            set { _ClaimOpenEndDate = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimCloseCriteria value.
        /// </summary>
        public string ClaimCloseCriteria
        {
            get { return _ClaimCloseCriteria; }
            set { _ClaimCloseCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimCloseStartDate value.
        /// </summary>
        public DateTime? ClaimCloseStartDate
        {
            get { return _ClaimCloseStartDate; }
            set { _ClaimCloseStartDate = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimCloseEndDate value.
        /// </summary>
        public DateTime? ClaimCloseEndDate
        {
            get { return _ClaimCloseEndDate; }
            set { _ClaimCloseEndDate = value; }
        }

        /// <summary>
        /// Gets or sets the DOICriteria value.
        /// </summary>
        public string DOICriteria
        {
            get { return _DOICriteria; }
            set { _DOICriteria = value; }
        }

        /// <summary>
        /// Gets or sets the DOIStart value.
        /// </summary>
        public DateTime? DOIStart
        {
            get { return _DOIStart; }
            set { _DOIStart = value; }
        }

        /// <summary>
        /// Gets or sets the DOIEnd value.
        /// </summary>
        public DateTime? DOIEnd
        {
            get { return _DOIEnd; }
            set { _DOIEnd = value; }
        }

        /// <summary>
        /// Gets or sets the ValueAsOfDateCriteria value.
        /// </summary>
        public string ValueAsOfDateCriteria
        {
            get { return _ValueAsOfDateCriteria; }
            set { _ValueAsOfDateCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the ValueAsOfDateStartDate value.
        /// </summary>
        public DateTime? ValueAsOfDateStartDate
        {
            get { return _ValueAsOfDateStartDate; }
            set { _ValueAsOfDateStartDate = value; }
        }

        /// <summary>
        /// Gets or sets the ValueAsOfDateEndDate value.
        /// </summary>
        public DateTime? ValueAsOfDateEndDate
        {
            get { return _ValueAsOfDateEndDate; }
            set { _ValueAsOfDateEndDate = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimReserveCriteria value.
        /// </summary>
        public string ClaimReserveCriteria
        {
            get { return _ClaimReserveCriteria; }
            set { _ClaimReserveCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimReserveStartDate value.
        /// </summary>
        public DateTime? ClaimReserveStartDate
        {
            get { return _ClaimReserveStartDate; }
            set { _ClaimReserveStartDate = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimReserveEndDate value.
        /// </summary>
        public DateTime? ClaimReserveEndDate
        {
            get { return _ClaimReserveEndDate; }
            set { _ClaimReserveEndDate = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimPaymentCriteria value.
        /// </summary>
        public string ClaimPaymentCriteria
        {
            get { return _ClaimPaymentCriteria; }
            set { _ClaimPaymentCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimPaymentStartDate value.
        /// </summary>
        public DateTime? ClaimPaymentStartDate
        {
            get { return _ClaimPaymentStartDate; }
            set { _ClaimPaymentStartDate = value; }
        }

        /// <summary>
        /// Gets or sets the ClaimPaymentEndDate value.
        /// </summary>
        public DateTime? ClaimPaymentEndDate
        {
            get { return _ClaimPaymentEndDate; }
            set { _ClaimPaymentEndDate = value; }
        }

        /// <summary>
        /// Gets or sets the Location value.
        /// </summary>
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        /// <summary>
        /// Gets or sets the Region value.
        /// </summary>
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }

        /// <summary>
        /// Gets or sets the Market value.
        /// </summary>
        public string Market
        {
            get { return _Market; }
            set { _Market = value; }
        }

        /// <summary>
        /// Gets or sets the CoverageState value.
        /// </summary>
        public string CoverageState
        {
            get { return _CoverageState; }
            set { _CoverageState = value; }
        }

        /// <summary>
        /// Gets or sets the BodyPart value.
        /// </summary>
        public string BodyPart
        {
            get { return _BodyPart; }
            set { _BodyPart = value; }
        }

        /// <summary>
        /// Gets or sets the Cause value.
        /// </summary>
        public string Cause
        {
            get { return _Cause; }
            set { _Cause = value; }
        }

        /// <summary>
        /// Gets or sets the NatureOfInjury value.
        /// </summary>
        public string NatureOfInjury
        {
            get { return _NatureOfInjury; }
            set { _NatureOfInjury = value; }
        }

        /// <summary>
        /// Gets or sets the MPCriteria value.
        /// </summary>
        public string MPCriteria
        {
            get { return _MPCriteria; }
            set { _MPCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the MPStartAmount value.
        /// </summary>
        public decimal? MPStartAmount
        {
            get { return _MPStartAmount; }
            set { _MPStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the MPEndAmount value.
        /// </summary>
        public decimal? MPEndAmount
        {
            get { return _MPEndAmount; }
            set { _MPEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the MICriteria value.
        /// </summary>
        public string MICriteria
        {
            get { return _MICriteria; }
            set { _MICriteria = value; }
        }

        /// <summary>
        /// Gets or sets the MIStartAmount value.
        /// </summary>
        public decimal? MIStartAmount
        {
            get { return _MIStartAmount; }
            set { _MIStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the MIEndAmount value.
        /// </summary>
        public decimal? MIEndAmount
        {
            get { return _MIEndAmount; }
            set { _MIEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the EPCriteria value.
        /// </summary>
        public string EPCriteria
        {
            get { return _EPCriteria; }
            set { _EPCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the EPStartAmount value.
        /// </summary>
        public decimal? EPStartAmount
        {
            get { return _EPStartAmount; }
            set { _EPStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the EPEndAmount value.
        /// </summary>
        public decimal? EPEndAmount
        {
            get { return _EPEndAmount; }
            set { _EPEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the EICriteria value.
        /// </summary>
        public string EICriteria
        {
            get { return _EICriteria; }
            set { _EICriteria = value; }
        }

        /// <summary>
        /// Gets or sets the EIStartAmount value.
        /// </summary>
        public decimal? EIStartAmount
        {
            get { return _EIStartAmount; }
            set { _EIStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the EIEndAmount value.
        /// </summary>
        public decimal? EIEndAmount
        {
            get { return _EIEndAmount; }
            set { _EIEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the IPCriteria value.
        /// </summary>
        public string IPCriteria
        {
            get { return _IPCriteria; }
            set { _IPCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the IPStartAmount value.
        /// </summary>
        public decimal? IPStartAmount
        {
            get { return _IPStartAmount; }
            set { _IPStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the IPEndAmount value.
        /// </summary>
        public decimal? IPEndAmount
        {
            get { return _IPEndAmount; }
            set { _IPEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the IICriteria value.
        /// </summary>
        public string IICriteria
        {
            get { return _IICriteria; }
            set { _IICriteria = value; }
        }

        /// <summary>
        /// Gets or sets the IIStartAmount value.
        /// </summary>
        public decimal? IIStartAmount
        {
            get { return _IIStartAmount; }
            set { _IIStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the IIEndAmount value.
        /// </summary>
        public decimal? IIEndAmount
        {
            get { return _IIEndAmount; }
            set { _IIEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the TPCriteria value.
        /// </summary>
        public string TPCriteria
        {
            get { return _TPCriteria; }
            set { _TPCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the TPStartAmount value.
        /// </summary>
        public decimal? TPStartAmount
        {
            get { return _TPStartAmount; }
            set { _TPStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the TPEndAmount value.
        /// </summary>
        public decimal? TPEndAmount
        {
            get { return _TPEndAmount; }
            set { _TPEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the TICriteria value.
        /// </summary>
        public string TICriteria
        {
            get { return _TICriteria; }
            set { _TICriteria = value; }
        }

        /// <summary>
        /// Gets or sets the TIStartAmount value.
        /// </summary>
        public decimal? TIStartAmount
        {
            get { return _TIStartAmount; }
            set { _TIStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the TIEndAmount value.
        /// </summary>
        public decimal? TIEndAmount
        {
            get { return _TIEndAmount; }
            set { _TIEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the TOCriteria value.
        /// </summary>
        public string TOCriteria
        {
            get { return _TOCriteria; }
            set { _TOCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the TOStartAmount value.
        /// </summary>
        public decimal? TOStartAmount
        {
            get { return _TOStartAmount; }
            set { _TOStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the TOEndAmount value.
        /// </summary>
        public decimal? TOEndAmount
        {
            get { return _TOEndAmount; }
            set { _TOEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the OutputFields value.
        /// </summary>
        public string OutputFields
        {
            get { return _OutputFields; }
            set { _OutputFields = value; }
        }

        /// <summary>
        /// Gets or sets the SortFields value.
        /// </summary>
        public string SortFields
        {
            get { return _SortFields; }
            set { _SortFields = value; }
        }

        /// <summary>
        /// Gets or sets the ShowSubTotal value.
        /// </summary>
        public string ShowSubTotal
        {
            get { return _ShowSubTotal; }
            set { _ShowSubTotal = value; }
        }

        /// <summary>
        /// Gets or sets the ShowGrandTotal value.
        /// </summary>
        public string ShowGrandTotal
        {
            get { return _ShowGrandTotal; }
            set { _ShowGrandTotal = value; }
        }

        /// <summary>
        /// Gets or sets the PriorValueDate value.
        /// </summary>
        public DateTime? PriorValueDate
        {
            get { return _PriorValueDate; }
            set { _PriorValueDate = value; }
        }

        /// <summary>
        /// Gets or sets the UserId value.
        /// </summary>
        public decimal? UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        /// <summary>
        /// Gets or sets the UpdatedDate value.
        /// </summary>
        public DateTime? UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }

        /// <summary>
        /// Gets or sets the MOCriteria value.
        /// </summary>
        public string MOCriteria
        {
            get { return _MOCriteria; }
            set { _MOCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the MOStartAmount value.
        /// </summary>
        public decimal? MOStartAmount
        {
            get { return _MOStartAmount; }
            set { _MOStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the MOEndAmount value.
        /// </summary>
        public decimal? MOEndAmount
        {
            get { return _MOEndAmount; }
            set { _MOEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the EOCriteria value.
        /// </summary>
        public string EOCriteria
        {
            get { return _EOCriteria; }
            set { _EOCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the EOStartAmount value.
        /// </summary>
        public decimal? EOStartAmount
        {
            get { return _EOStartAmount; }
            set { _EOStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the EOEndAmount value.
        /// </summary>
        public decimal? EOEndAmount
        {
            get { return _EOEndAmount; }
            set { _EOEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the IOCriteria value.
        /// </summary>
        public string IOCriteria
        {
            get { return _IOCriteria; }
            set { _IOCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the IOStartAmount value.
        /// </summary>
        public decimal? IOStartAmount
        {
            get { return _IOStartAmount; }
            set { _IOStartAmount = value; }
        }

        /// <summary>
        /// Gets or sets the IOEndAmount value.
        /// </summary>
        public decimal? IOEndAmount
        {
            get { return _IOEndAmount; }
            set { _IOEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the OutputFieldsOrder value.
        /// </summary>
        public string OutputFieldsOrder
        {
            get { return _OutputFieldsOrder; }
            set { _OutputFieldsOrder = value; }
        }

        /// <summary>
        /// Gets or sets the OutputFieldsOrder value.
        /// </summary>
        public string Indicator
        {
            get { return _Indicator; }
            set { _Indicator = value; }
        }

        /// <summary>
        /// Gets or sets the OutputFieldsOrder value.
        /// </summary>
        public string SonicCauseCode
        {
            get { return _SonicCauseCode; }
            set { _SonicCauseCode = value; }
        }
        
        public string ClaimSubStaus
        {
            get { return _ClaimSubStaus; }
            set { _ClaimSubStaus = value; }
        }

        public string FullFinalClincher
        {
            get { return _FullFinalClincher; }
            set { _FullFinalClincher = value; }
        }

        /// <summary>
        /// Get or Set Total Comp Criteria
        /// </summary>
        public string TCompCriteria
        {
            get { return _TCompCriteria; }
            set { _TCompCriteria = value; }
        }

        /// <summary>
        /// Get or Set Total Comp Start Amount
        /// </summary>
        public decimal? TCompStartAmount
        {
            get { return _TCompStartAmount; }
            set { _TCompStartAmount = value; }
        }

        /// <summary>
        /// Get or Set Total Comp End Amount
        /// </summary>
        public decimal? TCompEndAmount
        {
            get { return _TPEndAmount; }
            set { _TPEndAmount = value; }
        }

        /// <summary>
        /// Get or Set Total Reserve Criteria
        /// </summary>
        public string TReserveCriteria
        {
            get { return _TReserveCriteria; }
            set { _TReserveCriteria = value; }
        }

        /// <summary>
        /// Get or Set Total Reserve Start Amount 
        /// </summary>
        public decimal? TReserveStartAmount
        {
            get { return _TReserveStartAmount; }
            set { _TReserveStartAmount = value; }
        }

        /// <summary>
        /// Get or Set Total Reserve End Amount 
        /// </summary>
        public decimal? TReserveEndAmount
        {
            get { return _TReserveEndAmount; }
            set { _TReserveEndAmount = value; }
        }

        /// <summary>
        /// Get or Set Unlimited Cost Criteria 
        /// </summary>
        public string UCostCriteria
        {
            get { return _UCostCriteria; }
            set { _UCostCriteria = value; }
        }

        /// <summary>
        /// Get or Set Unlimited Cost Start Amount 
        /// </summary>
        public decimal? UCostStartAmount
        {
            get { return _UCostStartAmount; }
            set { _UCostStartAmount = value; }
        }

        /// <summary>
        ///  Get or Set Unlimited Cost End Amount 
        /// </summary>
        public decimal? UCostEndAmount
        {
            get { return _UCostEndAmount; }
            set { _UCostEndAmount = value; }
        }

        /// <summary>
        /// Get or Set Limited to MV  Criteria
        /// </summary>
        public string LMVCriteria
        {
            get { return _LMVCriteria; }
            set { _LMVCriteria = value; }
        }

        /// <summary>
        /// Get or Set Limited to MV Start Amount
        /// </summary>
        public decimal? LMVStartAmount
        {
            get { return _LMVStartAmount; }
            set { _LMVStartAmount = value; }
        }

        /// <summary>
        /// Get or Set Limited to MV End Amount
        /// </summary>
        public decimal? LMVEndAmount
        {
            get { return _LMVEndAmount; }
            set { _LMVEndAmount = value; }
        }

        /// <summary>
        ///  Get or Set HC Percent Criteria
        /// </summary>
        public string HCPCriteria
        {
            get { return _HCPCriteria; }
            set { _HCPCriteria = value; }
        }

        /// <summary>
        /// Get or Set HC Percent Start Amount 
        /// </summary>
        public decimal? HCPStartAmount
        {
            get { return _HCPStartAmount; }
            set { _HCPStartAmount = value; }
        }

        /// <summary>
        /// Get or Set HC Percent End Amount 
        /// </summary>
        public decimal? HCPEndAmount
        {
            get { return _HCPEndAmount; }
            set { _HCPEndAmount = value; }
        }

        /// <summary>
        /// Get or Set HC Relief  Criteria
        /// </summary>
        public string HCRCriteria
        {
            get { return _HCRCriteria; }
            set { _HCRCriteria = value; }
        }

        /// <summary>
        /// Get or Set HC Relief  Start Amount
        /// </summary>
        public decimal? HCRStartAmount
        {
            get { return _HCRStartAmount; }
            set { _HCRStartAmount = value; }
        }

        /// <summary>
        ///  Get or Set HC Relief End Amount
        /// </summary>
        public decimal? HCREndAmount
        {
            get { return _HCREndAmount; }
            set { _HCREndAmount = value; }
        }

        /// <summary>
        ///  Get or Set Subrogation Collected Criteria 
        /// </summary>
        public string SColledtedCriteria
        {
            get { return _SColledtedCriteria; }
            set { _SColledtedCriteria = value; }
        }

        /// <summary>
        /// Get or Set Subrogation Collected Start Amount  
        /// </summary>
        public decimal? SColledtedStartAmount
        {
            get { return _SColledtedStartAmount; }
            set { _SColledtedStartAmount = value; }
        }

        /// <summary>
        /// Get or Set Subrogation Collected End Amount
        /// </summary>
        public decimal? SColledtedEndAmount
        {
            get { return _SColledtedEndAmount; }
            set { _SColledtedEndAmount = value; }
        }

        /// <summary>
        ///  Get or Set Total Charged Criteria
        /// </summary>
        public string TChargedCriteria
        {
            get { return _TChargedCriteria; }
            set { _TChargedCriteria = value; }
        }

        /// <summary>
        /// Get or Set Total Charged start amount
        /// </summary>
        public decimal? TChargedStartAmount
        {
            get { return _TChargedStartAmount; }
            set { _TChargedStartAmount = value; }
        }

        /// <summary>
        /// Get or Set Total Charged end amount
        /// </summary>
        public decimal? TChargedEndAmount
        {
            get { return _TChargedEndAmount; }
            set { _TChargedEndAmount = value; }
        }

        /// <summary>
        ///  Get or Set Total TotalPaid Criteria
        /// </summary>
        public string TTotalPaidCriteria
        {
            get { return _TTotalPaidCriteria; }
            set { _TTotalPaidCriteria = value; }
        }

        /// <summary>
        /// Get or Set Total TotalPaid start amount
        /// </summary>
        public decimal? TTotalPaidStartAmount
        {
            get { return _TTotalPaidStartAmount; }
            set { _TTotalPaidStartAmount = value; }
        }

        /// <summary>
        /// Get or Set Total TotalPaid end amount
        /// </summary>
        public decimal? TTotalPaidEndAmount
        {
            get { return _TTotalPaidEndAmount; }
            set { _TTotalPaidEndAmount = value; }
        }

        /// <summary>
        /// Gets or sets the line of coverage
        /// </summary>
        public string LineofCoverage
        {
            get { return _LineofCoverage; }
            set { _LineofCoverage = value; }
        }

        /// <summary>
        /// Gets or sets the DateRestrictedBeginCriteria value.
        /// </summary>
        public string DateRestrictedBeginCriteria
        {
            get { return _DateRestrictedBeginCriteria; }
            set { _DateRestrictedBeginCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the DateRestrictedBeginStartDate value.
        /// </summary>
        public DateTime? DateRestrictedBeginStartDate
        {
            get { return _DateRestrictedBeginStartDate; }
            set { _DateRestrictedBeginStartDate = value; }
        }

        /// <summary>
        /// Gets or sets the DateRestrictedBeginEndDate value.
        /// </summary>
        public DateTime? DateRestrictedBeginEndDate
        {
            get { return _DateRestrictedBeginEndDate; }
            set { _DateRestrictedBeginEndDate = value; }
        }

        /// <summary>
        /// Gets or sets the DateRestrictedEndCriteria value.
        /// </summary>
        public string DateRestrictedEndCriteria
        {
            get { return _DateRestrictedEndCriteria; }
            set { _DateRestrictedEndCriteria = value; }
        }

        /// <summary>
        /// Gets or sets the DateRestrictedEndStartDate value.
        /// </summary>
        public DateTime? DateRestrictedEndStartDate
        {
            get { return _DateRestrictedEndStartDate; }
            set { _DateRestrictedEndStartDate = value; }
        }

        /// <summary>
        /// Gets or sets the DateRestrictedEndEndDate value.
        /// </summary>
        public DateTime? DateRestrictedEndEndDate
        {
            get { return _DateRestrictedEndEndDate; }
            set { _DateRestrictedEndEndDate = value; }
        }
               
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the AdhocReport class with default value.
        /// </summary>
        public AdhocReport()
        {

            this._ReportId = null;
            this._ReportName = null;
            this._Claim_Type = null;
            this._OStatus = null;
            this._CStatus = null;
            this._ROStatus = null;
            this._ClaimOpenCriteria = null;
            this._ClaimOpenStartDate = null;
            this._ClaimOpenEndDate = null;
            this._ClaimCloseCriteria = null;
            this._ClaimCloseStartDate = null;
            this._ClaimCloseEndDate = null;
            this._DOICriteria = null;
            this._DOIStart = null;
            this._DOIEnd = null;
            this._ValueAsOfDateCriteria = null;
            this._ValueAsOfDateStartDate = null;
            this._ValueAsOfDateEndDate = null;
            this._ClaimReserveCriteria = null;
            this._ClaimReserveStartDate = null;
            this._ClaimReserveEndDate = null;
            this._ClaimPaymentCriteria = null;
            this._ClaimPaymentStartDate = null;
            this._ClaimPaymentEndDate = null;
            this._Location = null;
            this._Region = null;
            this._Market = null;
            this._CoverageState = null;
            this._BodyPart = null;
            this._Cause = null;
            this._NatureOfInjury = null;
            this._MPCriteria = null;
            this._MPStartAmount = null;
            this._MPEndAmount = null;
            this._MICriteria = null;
            this._MIStartAmount = null;
            this._MIEndAmount = null;
            this._EPCriteria = null;
            this._EPStartAmount = null;
            this._EPEndAmount = null;
            this._EICriteria = null;
            this._EIStartAmount = null;
            this._EIEndAmount = null;
            this._IPCriteria = null;
            this._IPStartAmount = null;
            this._IPEndAmount = null;
            this._IICriteria = null;
            this._IIStartAmount = null;
            this._IIEndAmount = null;
            this._TPCriteria = null;
            this._TPStartAmount = null;
            this._TPEndAmount = null;
            this._TICriteria = null;
            this._TIStartAmount = null;
            this._TIEndAmount = null;
            this._TOCriteria = null;
            this._TOStartAmount = null;
            this._TOEndAmount = null;
            this._OutputFields = null;
            this._SortFields = null;
            this._ShowSubTotal = null;
            this._ShowGrandTotal = null;
            this._PriorValueDate = null;
            this._UserId = null;
            this._UpdatedDate = null;
            this._MOCriteria = null;
            this._MOStartAmount = null;
            this._MOEndAmount = null;
            this._EOCriteria = null;
            this._EOStartAmount = null;
            this._EOEndAmount = null;
            this._IOCriteria = null;
            this._IOStartAmount = null;
            this._IOEndAmount = null;
            this._OutputFieldsOrder = null;
            this._Indicator = null;
            this._SonicCauseCode = null;
            this._ClaimSubStaus = null;
            this._FullFinalClincher = null;

            this._TCompCriteria = null;
            this._TCompStartAmount = null;
            this._TCompEndAmount = null;
            this._TReserveCriteria = null;
            this._TReserveStartAmount = null;
            this._TReserveEndAmount = null;
            this._UCostCriteria = null;
            this._UCostStartAmount = null;
            this._UCostEndAmount = null;
            this._LMVCriteria = null;
            this._LMVStartAmount = null;
            this._LMVEndAmount = null;
            this._HCPCriteria = null;
            this._HCPStartAmount = null;
            this._HCPEndAmount = null;
            this._HCRCriteria = null;
            this._HCRStartAmount = null;
            this._HCREndAmount = null;
            this._SColledtedCriteria = null;
            this._SColledtedStartAmount = null;
            this._SColledtedEndAmount = null;
            this._TChargedCriteria = null;
            this._TChargedStartAmount = null;
            this._TChargedEndAmount = null;
            this._TTotalPaidCriteria = null;
            this._TTotalPaidStartAmount = null;
            this._TTotalPaidEndAmount = null;
            this._LineofCoverage = null;
            this._DateRestrictedBeginCriteria = null;
            this._DateRestrictedBeginStartDate = null;
            this._DateRestrictedBeginEndDate = null;
            this._DateRestrictedEndCriteria = null;
            this._DateRestrictedEndStartDate = null;
            this._DateRestrictedEndEndDate = null;
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the AdhocReport class based on Primary Key.
        /// </summary>
        public AdhocReport(decimal reportId)
        {
            DataTable dtAdhocReport = SelectByPK(reportId).Tables[0];

            if (dtAdhocReport.Rows.Count == 1)
            {
                DataRow drAdhocReport = dtAdhocReport.Rows[0];
                if (drAdhocReport["ReportId"] == DBNull.Value)
                    this._ReportId = null;
                else
                    this._ReportId = (decimal?)drAdhocReport["ReportId"];

                if (drAdhocReport["ReportName"] == DBNull.Value)
                    this._ReportName = null;
                else
                    this._ReportName = (string)drAdhocReport["ReportName"];

                if (drAdhocReport["Claim_Type"] == DBNull.Value)
                    this._Claim_Type = null;
                else
                    this._Claim_Type = (string)drAdhocReport["Claim_Type"];

                if (drAdhocReport["OStatus"] == DBNull.Value)
                    this._OStatus = null;
                else
                    this._OStatus = (string)drAdhocReport["OStatus"];

                if (drAdhocReport["CStatus"] == DBNull.Value)
                    this._CStatus = null;
                else
                    this._CStatus = (string)drAdhocReport["CStatus"];

                if (drAdhocReport["ROStatus"] == DBNull.Value)
                    this._ROStatus = null;
                else
                    this._ROStatus = (string)drAdhocReport["ROStatus"];

                if (drAdhocReport["ClaimOpenCriteria"] == DBNull.Value)
                    this._ClaimOpenCriteria = null;
                else
                    this._ClaimOpenCriteria = (string)drAdhocReport["ClaimOpenCriteria"];

                if (drAdhocReport["ClaimOpenStartDate"] == DBNull.Value)
                    this._ClaimOpenStartDate = null;
                else
                    this._ClaimOpenStartDate = (DateTime?)drAdhocReport["ClaimOpenStartDate"];

                if (drAdhocReport["ClaimOpenEndDate"] == DBNull.Value)
                    this._ClaimOpenEndDate = null;
                else
                    this._ClaimOpenEndDate = (DateTime?)drAdhocReport["ClaimOpenEndDate"];

                if (drAdhocReport["ClaimCloseCriteria"] == DBNull.Value)
                    this._ClaimCloseCriteria = null;
                else
                    this._ClaimCloseCriteria = (string)drAdhocReport["ClaimCloseCriteria"];

                if (drAdhocReport["ClaimCloseStartDate"] == DBNull.Value)
                    this._ClaimCloseStartDate = null;
                else
                    this._ClaimCloseStartDate = (DateTime?)drAdhocReport["ClaimCloseStartDate"];

                if (drAdhocReport["ClaimCloseEndDate"] == DBNull.Value)
                    this._ClaimCloseEndDate = null;
                else
                    this._ClaimCloseEndDate = (DateTime?)drAdhocReport["ClaimCloseEndDate"];

                if (drAdhocReport["DOICriteria"] == DBNull.Value)
                    this._DOICriteria = null;
                else
                    this._DOICriteria = (string)drAdhocReport["DOICriteria"];

                if (drAdhocReport["DOIStart"] == DBNull.Value)
                    this._DOIStart = null;
                else
                    this._DOIStart = (DateTime?)drAdhocReport["DOIStart"];

                if (drAdhocReport["DOIEnd"] == DBNull.Value)
                    this._DOIEnd = null;
                else
                    this._DOIEnd = (DateTime?)drAdhocReport["DOIEnd"];

                if (drAdhocReport["ValueAsOfDateCriteria"] == DBNull.Value)
                    this._ValueAsOfDateCriteria = null;
                else
                    this._ValueAsOfDateCriteria = (string)drAdhocReport["ValueAsOfDateCriteria"];

                if (drAdhocReport["ValueAsOfDateStartDate"] == DBNull.Value)
                    this._ValueAsOfDateStartDate = null;
                else
                    this._ValueAsOfDateStartDate = (DateTime?)drAdhocReport["ValueAsOfDateStartDate"];

                if (drAdhocReport["ValueAsOfDateEndDate"] == DBNull.Value)
                    this._ValueAsOfDateEndDate = null;
                else
                    this._ValueAsOfDateEndDate = (DateTime?)drAdhocReport["ValueAsOfDateEndDate"];

                if (drAdhocReport["ClaimReserveCriteria"] == DBNull.Value)
                    this._ClaimReserveCriteria = null;
                else
                    this._ClaimReserveCriteria = (string)drAdhocReport["ClaimReserveCriteria"];

                if (drAdhocReport["ClaimReserveStartDate"] == DBNull.Value)
                    this._ClaimReserveStartDate = null;
                else
                    this._ClaimReserveStartDate = (DateTime?)drAdhocReport["ClaimReserveStartDate"];

                if (drAdhocReport["ClaimReserveEndDate"] == DBNull.Value)
                    this._ClaimReserveEndDate = null;
                else
                    this._ClaimReserveEndDate = (DateTime?)drAdhocReport["ClaimReserveEndDate"];

                if (drAdhocReport["ClaimPaymentCriteria"] == DBNull.Value)
                    this._ClaimPaymentCriteria = null;
                else
                    this._ClaimPaymentCriteria = (string)drAdhocReport["ClaimPaymentCriteria"];

                if (drAdhocReport["ClaimPaymentStartDate"] == DBNull.Value)
                    this._ClaimPaymentStartDate = null;
                else
                    this._ClaimPaymentStartDate = (DateTime?)drAdhocReport["ClaimPaymentStartDate"];

                if (drAdhocReport["ClaimPaymentEndDate"] == DBNull.Value)
                    this._ClaimPaymentEndDate = null;
                else
                    this._ClaimPaymentEndDate = (DateTime?)drAdhocReport["ClaimPaymentEndDate"];

                if (drAdhocReport["Location"] == DBNull.Value)
                    this._Location = null;
                else
                    this._Location = (string)drAdhocReport["Location"];

                if (drAdhocReport["Region"] == DBNull.Value)
                    this._Region = null;
                else
                    this._Region = (string)drAdhocReport["Region"];

                if (drAdhocReport["Market"] == DBNull.Value)
                    this._Market = null;
                else
                    this._Market = (string)drAdhocReport["Market"];

                if (drAdhocReport["CoverageState"] == DBNull.Value)
                    this._CoverageState = null;
                else
                    this._CoverageState = (string)drAdhocReport["CoverageState"];

                if (drAdhocReport["BodyPart"] == DBNull.Value)
                    this._BodyPart = null;
                else
                    this._BodyPart = (string)drAdhocReport["BodyPart"];

                if (drAdhocReport["Cause"] == DBNull.Value)
                    this._Cause = null;
                else
                    this._Cause = (string)drAdhocReport["Cause"];

                if (drAdhocReport["NatureOfInjury"] == DBNull.Value)
                    this._NatureOfInjury = null;
                else
                    this._NatureOfInjury = (string)drAdhocReport["NatureOfInjury"];

                if (drAdhocReport["MPCriteria"] == DBNull.Value)
                    this._MPCriteria = null;
                else
                    this._MPCriteria = (string)drAdhocReport["MPCriteria"];

                if (drAdhocReport["MPStartAmount"] == DBNull.Value)
                    this._MPStartAmount = null;
                else
                    this._MPStartAmount = (decimal?)drAdhocReport["MPStartAmount"];

                if (drAdhocReport["MPEndAmount"] == DBNull.Value)
                    this._MPEndAmount = null;
                else
                    this._MPEndAmount = (decimal?)drAdhocReport["MPEndAmount"];

                if (drAdhocReport["MICriteria"] == DBNull.Value)
                    this._MICriteria = null;
                else
                    this._MICriteria = (string)drAdhocReport["MICriteria"];

                if (drAdhocReport["MIStartAmount"] == DBNull.Value)
                    this._MIStartAmount = null;
                else
                    this._MIStartAmount = (decimal?)drAdhocReport["MIStartAmount"];

                if (drAdhocReport["MIEndAmount"] == DBNull.Value)
                    this._MIEndAmount = null;
                else
                    this._MIEndAmount = (decimal?)drAdhocReport["MIEndAmount"];

                if (drAdhocReport["EPCriteria"] == DBNull.Value)
                    this._EPCriteria = null;
                else
                    this._EPCriteria = (string)drAdhocReport["EPCriteria"];

                if (drAdhocReport["EPStartAmount"] == DBNull.Value)
                    this._EPStartAmount = null;
                else
                    this._EPStartAmount = (decimal?)drAdhocReport["EPStartAmount"];

                if (drAdhocReport["EPEndAmount"] == DBNull.Value)
                    this._EPEndAmount = null;
                else
                    this._EPEndAmount = (decimal?)drAdhocReport["EPEndAmount"];

                if (drAdhocReport["EICriteria"] == DBNull.Value)
                    this._EICriteria = null;
                else
                    this._EICriteria = (string)drAdhocReport["EICriteria"];

                if (drAdhocReport["EIStartAmount"] == DBNull.Value)
                    this._EIStartAmount = null;
                else
                    this._EIStartAmount = (decimal?)drAdhocReport["EIStartAmount"];

                if (drAdhocReport["EIEndAmount"] == DBNull.Value)
                    this._EIEndAmount = null;
                else
                    this._EIEndAmount = (decimal?)drAdhocReport["EIEndAmount"];

                if (drAdhocReport["IPCriteria"] == DBNull.Value)
                    this._IPCriteria = null;
                else
                    this._IPCriteria = (string)drAdhocReport["IPCriteria"];

                if (drAdhocReport["IPStartAmount"] == DBNull.Value)
                    this._IPStartAmount = null;
                else
                    this._IPStartAmount = (decimal?)drAdhocReport["IPStartAmount"];

                if (drAdhocReport["IPEndAmount"] == DBNull.Value)
                    this._IPEndAmount = null;
                else
                    this._IPEndAmount = (decimal?)drAdhocReport["IPEndAmount"];

                if (drAdhocReport["IICriteria"] == DBNull.Value)
                    this._IICriteria = null;
                else
                    this._IICriteria = (string)drAdhocReport["IICriteria"];

                if (drAdhocReport["IIStartAmount"] == DBNull.Value)
                    this._IIStartAmount = null;
                else
                    this._IIStartAmount = (decimal?)drAdhocReport["IIStartAmount"];

                if (drAdhocReport["IIEndAmount"] == DBNull.Value)
                    this._IIEndAmount = null;
                else
                    this._IIEndAmount = (decimal?)drAdhocReport["IIEndAmount"];

                if (drAdhocReport["TPCriteria"] == DBNull.Value)
                    this._TPCriteria = null;
                else
                    this._TPCriteria = (string)drAdhocReport["TPCriteria"];

                if (drAdhocReport["TPStartAmount"] == DBNull.Value)
                    this._TPStartAmount = null;
                else
                    this._TPStartAmount = (decimal?)drAdhocReport["TPStartAmount"];

                if (drAdhocReport["TPEndAmount"] == DBNull.Value)
                    this._TPEndAmount = null;
                else
                    this._TPEndAmount = (decimal?)drAdhocReport["TPEndAmount"];

                if (drAdhocReport["TICriteria"] == DBNull.Value)
                    this._TICriteria = null;
                else
                    this._TICriteria = (string)drAdhocReport["TICriteria"];

                if (drAdhocReport["TIStartAmount"] == DBNull.Value)
                    this._TIStartAmount = null;
                else
                    this._TIStartAmount = (decimal?)drAdhocReport["TIStartAmount"];

                if (drAdhocReport["TIEndAmount"] == DBNull.Value)
                    this._TIEndAmount = null;
                else
                    this._TIEndAmount = (decimal?)drAdhocReport["TIEndAmount"];

                if (drAdhocReport["TOCriteria"] == DBNull.Value)
                    this._TOCriteria = null;
                else
                    this._TOCriteria = (string)drAdhocReport["TOCriteria"];

                if (drAdhocReport["TOStartAmount"] == DBNull.Value)
                    this._TOStartAmount = null;
                else
                    this._TOStartAmount = (decimal?)drAdhocReport["TOStartAmount"];

                if (drAdhocReport["TOEndAmount"] == DBNull.Value)
                    this._TOEndAmount = null;
                else
                    this._TOEndAmount = (decimal?)drAdhocReport["TOEndAmount"];

                if (drAdhocReport["OutputFields"] == DBNull.Value)
                    this._OutputFields = null;
                else
                    this._OutputFields = (string)drAdhocReport["OutputFields"];

                if (drAdhocReport["SortFields"] == DBNull.Value)
                    this._SortFields = null;
                else
                    this._SortFields = (string)drAdhocReport["SortFields"];

                if (drAdhocReport["ShowSubTotal"] == DBNull.Value)
                    this._ShowSubTotal = null;
                else
                    this._ShowSubTotal = (string)drAdhocReport["ShowSubTotal"];

                if (drAdhocReport["ShowGrandTotal"] == DBNull.Value)
                    this._ShowGrandTotal = null;
                else
                    this._ShowGrandTotal = (string)drAdhocReport["ShowGrandTotal"];

                if (drAdhocReport["PriorValueDate"] == DBNull.Value)
                    this._PriorValueDate = null;
                else
                    this._PriorValueDate = (DateTime?)drAdhocReport["PriorValueDate"];

                if (drAdhocReport["UserId"] == DBNull.Value)
                    this._UserId = null;
                else
                    this._UserId = (decimal?)drAdhocReport["UserId"];

                if (drAdhocReport["UpdatedDate"] == DBNull.Value)
                    this._UpdatedDate = null;
                else
                    this._UpdatedDate = (DateTime?)drAdhocReport["UpdatedDate"];

                if (drAdhocReport["MOCriteria"] == DBNull.Value)
                    this._MOCriteria = null;
                else
                    this._MOCriteria = (string)drAdhocReport["MOCriteria"];

                if (drAdhocReport["MOStartAmount"] == DBNull.Value)
                    this._MOStartAmount = null;
                else
                    this._MOStartAmount = (decimal?)drAdhocReport["MOStartAmount"];

                if (drAdhocReport["MOEndAmount"] == DBNull.Value)
                    this._MOEndAmount = null;
                else
                    this._MOEndAmount = (decimal?)drAdhocReport["MOEndAmount"];

                if (drAdhocReport["EOCriteria"] == DBNull.Value)
                    this._EOCriteria = null;
                else
                    this._EOCriteria = (string)drAdhocReport["EOCriteria"];

                if (drAdhocReport["EOStartAmount"] == DBNull.Value)
                    this._EOStartAmount = null;
                else
                    this._EOStartAmount = (decimal?)drAdhocReport["EOStartAmount"];

                if (drAdhocReport["EOEndAmount"] == DBNull.Value)
                    this._EOEndAmount = null;
                else
                    this._EOEndAmount = (decimal?)drAdhocReport["EOEndAmount"];

                if (drAdhocReport["IOCriteria"] == DBNull.Value)
                    this._IOCriteria = null;
                else
                    this._IOCriteria = (string)drAdhocReport["IOCriteria"];

                if (drAdhocReport["IOStartAmount"] == DBNull.Value)
                    this._IOStartAmount = null;
                else
                    this._IOStartAmount = (decimal?)drAdhocReport["IOStartAmount"];

                if (drAdhocReport["IOEndAmount"] == DBNull.Value)
                    this._IOEndAmount = null;
                else
                    this._IOEndAmount = (decimal?)drAdhocReport["IOEndAmount"];

                if (drAdhocReport["OutputFieldsOrder"] == DBNull.Value)
                    this._OutputFieldsOrder = null;
                else
                    this._OutputFieldsOrder = (string)drAdhocReport["OutputFieldsOrder"];

                if (drAdhocReport["Indicator"] == DBNull.Value)
                    this._Indicator = null;
                else
                    this._Indicator = (string)drAdhocReport["Indicator"];

                if (drAdhocReport["Sonic_Cause_Code"] == DBNull.Value)
                    this._SonicCauseCode = null;
                else
                    this._SonicCauseCode = (string)drAdhocReport["Sonic_Cause_Code"];

                if (drAdhocReport["ClaimSubStaus"] == DBNull.Value)
                    this._ClaimSubStaus = null;
                else
                    this._ClaimSubStaus = (string)drAdhocReport["ClaimSubStaus"];
                
                if (drAdhocReport["AlClaimOrigin"] == DBNull.Value)
                    this._AL_Claim_Origin = null;
                else
                    this._AL_Claim_Origin = (string)drAdhocReport["AlClaimOrigin"];

                if (drAdhocReport["FullFinalClincher"] == DBNull.Value)
                    this._FullFinalClincher = null;
                else
                    this._FullFinalClincher = (string)drAdhocReport["FullFinalClincher"];

                if (drAdhocReport["TCompCriteria"] == DBNull.Value)
                    this._TCompCriteria = null;
                else
                    this._TCompCriteria = (string)drAdhocReport["TCompCriteria"];

                if (drAdhocReport["TCompStartAmount"] == DBNull.Value)
                    this._TCompStartAmount = null;
                else
                    this._TCompStartAmount = (decimal?)drAdhocReport["TCompStartAmount"];

                if (drAdhocReport["TCompEndAmount"] == DBNull.Value)
                    this._TCompEndAmount = null;
                else
                    this._TCompEndAmount = (decimal?)drAdhocReport["TCompEndAmount"];

                if (drAdhocReport["TReserveCriteria"] == DBNull.Value)
                    this._TReserveCriteria = null;
                else
                    this._TReserveCriteria = (string)drAdhocReport["TReserveCriteria"];

                if (drAdhocReport["TReserveStartAmount"] == DBNull.Value)
                    this._TReserveStartAmount = null;
                else
                    this._TReserveStartAmount = (decimal?)drAdhocReport["TReserveStartAmount"];

                if (drAdhocReport["TReserveEndAmount"] == DBNull.Value)
                    this._TReserveEndAmount = null;
                else
                    this._TReserveEndAmount = (decimal?)drAdhocReport["TReserveEndAmount"];

                if (drAdhocReport["UCostCriteria"] == DBNull.Value)
                    this._UCostCriteria = null;
                else
                    this._UCostCriteria = (string)drAdhocReport["UCostCriteria"];

                if (drAdhocReport["UCostStartAmount"] == DBNull.Value)
                    this._UCostStartAmount = null;
                else
                    this._UCostStartAmount = (decimal?)drAdhocReport["UCostStartAmount"];

                if (drAdhocReport["UCostEndAmount"] == DBNull.Value)
                    this._UCostEndAmount = null;
                else
                    this._UCostEndAmount = (decimal?)drAdhocReport["UCostEndAmount"];

                if (drAdhocReport["LMVCriteria"] == DBNull.Value)
                    this._LMVCriteria = null;
                else
                    this._LMVCriteria = (string)drAdhocReport["LMVCriteria"];

                if (drAdhocReport["LMVStartAmount"] == DBNull.Value)
                    this._LMVStartAmount = null;
                else
                    this._LMVStartAmount = (decimal?)drAdhocReport["LMVStartAmount"];

                if (drAdhocReport["LMVEndAmount"] == DBNull.Value)
                    this._LMVEndAmount = null;
                else
                    this._LMVEndAmount = (decimal?)drAdhocReport["LMVEndAmount"];

                if (drAdhocReport["HCPCriteria"] == DBNull.Value)
                    this._HCPCriteria = null;
                else
                    this._HCPCriteria = (string)drAdhocReport["HCPCriteria"];

                if (drAdhocReport["HCPStartAmount"] == DBNull.Value)
                    this._HCPStartAmount = null;
                else
                    this._HCPStartAmount = (decimal)drAdhocReport["HCPStartAmount"];

                if (drAdhocReport["HCPEndAmount"] == DBNull.Value)
                    this._HCPEndAmount = null;
                else
                    this._HCPEndAmount = (decimal?)drAdhocReport["HCPEndAmount"];

                if (drAdhocReport["HCRCriteria"] == DBNull.Value)
                    this._HCRCriteria = null;
                else
                    this._HCRCriteria = (string)drAdhocReport["HCRCriteria"];

                if (drAdhocReport["HCRStartAmount"] == DBNull.Value)
                    this._HCRStartAmount = null;
                else
                    this._HCRStartAmount = (decimal?)drAdhocReport["HCRStartAmount"];

                if (drAdhocReport["HCREndAmount"] == DBNull.Value)
                    this._HCREndAmount = null;
                else
                    this._HCREndAmount = (decimal?)drAdhocReport["HCREndAmount"];

                if (drAdhocReport["SColledtedCriteria"] == DBNull.Value)
                    this._SColledtedCriteria = null;
                else
                    this._SColledtedCriteria = (string)drAdhocReport["SColledtedCriteria"];

                if (drAdhocReport["SColledtedStartAmount"] == DBNull.Value)
                    this._SColledtedStartAmount = null;
                else
                    this._SColledtedStartAmount = (decimal?)drAdhocReport["SColledtedStartAmount"];

                if (drAdhocReport["SColledtedEndAmount"] == DBNull.Value)
                    this._SColledtedEndAmount = null;
                else
                    this._SColledtedEndAmount = (decimal?)drAdhocReport["SColledtedEndAmount"];

                if (drAdhocReport["TChargedCriteria"] == DBNull.Value)
                    this._TChargedCriteria = null;
                else
                    this._TChargedCriteria = (string)drAdhocReport["TChargedCriteria"];
                

                if (drAdhocReport["TChargedStartAmount"] == DBNull.Value)
                    this._TChargedStartAmount = null;
                else
                    this._TChargedStartAmount = (decimal?)drAdhocReport["TChargedStartAmount"];


                if (drAdhocReport["TChargedEndAmount"] == DBNull.Value)
                    this._TChargedEndAmount = null;
                else
                    this._TChargedEndAmount = (decimal?)drAdhocReport["TChargedEndAmount"];

                if (drAdhocReport["TTotalPaidCriteria"] == DBNull.Value)
                    this._TTotalPaidCriteria = null;
                else
                    this._TTotalPaidCriteria = (string)drAdhocReport["TTotalPaidCriteria"];


                if (drAdhocReport["TTotalPaidStartAmount"] == DBNull.Value)
                    this._TTotalPaidStartAmount = null;
                else
                    this._TTotalPaidStartAmount = (decimal?)drAdhocReport["TTotalPaidStartAmount"];


                if (drAdhocReport["TTotalPaidEndAmount"] == DBNull.Value)
                    this._TTotalPaidEndAmount = null;
                else
                    this._TTotalPaidEndAmount = (decimal?)drAdhocReport["TTotalPaidEndAmount"];


                if (drAdhocReport["LineofCoverage"] == DBNull.Value)
                    this._LineofCoverage = null;
                else
                    this._LineofCoverage = (string)drAdhocReport["LineofCoverage"];

                if (drAdhocReport["DateRestrictedBeginCriteria"] == DBNull.Value)
                    this._DateRestrictedBeginCriteria = null;
                else
                    this._DateRestrictedBeginCriteria = (string)drAdhocReport["DateRestrictedBeginCriteria"];

                if (drAdhocReport["DateRestrictedBeginStartDate"] == DBNull.Value)
                    this._DateRestrictedBeginStartDate = null;
                else
                    this._DateRestrictedBeginStartDate = (DateTime?)drAdhocReport["DateRestrictedBeginStartDate"];

                if (drAdhocReport["DateRestrictedBeginEndDate"] == DBNull.Value)
                    this._DateRestrictedBeginEndDate = null;
                else
                    this._DateRestrictedBeginEndDate = (DateTime?)drAdhocReport["DateRestrictedBeginEndDate"];

                if (drAdhocReport["DateRestrictedEndCriteria"] == DBNull.Value)
                    this._DateRestrictedEndCriteria = null;
                else
                    this._DateRestrictedEndCriteria = (string)drAdhocReport["DateRestrictedEndCriteria"];

                if (drAdhocReport["DateRestrictedEndStartDate"] == DBNull.Value)
                    this._DateRestrictedEndStartDate = null;
                else
                    this._DateRestrictedEndStartDate = (DateTime?)drAdhocReport["DateRestrictedEndStartDate"];

                if (drAdhocReport["DateRestrictedEndEndDate"] == DBNull.Value)
                    this._DateRestrictedEndEndDate = null;
                else
                    this._DateRestrictedEndEndDate = (DateTime?)drAdhocReport["DateRestrictedEndEndDate"];
            }
            else
            {
                this._ReportId = null;
                this._ReportName = null;
                this._Claim_Type = null;
                this._OStatus = null;
                this._CStatus = null;
                this._ROStatus = null;
                this._ClaimOpenCriteria = null;
                this._ClaimOpenStartDate = null;
                this._ClaimOpenEndDate = null;
                this._ClaimCloseCriteria = null;
                this._ClaimCloseStartDate = null;
                this._ClaimCloseEndDate = null;
                this._DOICriteria = null;
                this._DOIStart = null;
                this._DOIEnd = null;
                this._ValueAsOfDateCriteria = null;
                this._ValueAsOfDateStartDate = null;
                this._ValueAsOfDateEndDate = null;
                this._ClaimReserveCriteria = null;
                this._ClaimReserveStartDate = null;
                this._ClaimReserveEndDate = null;
                this._ClaimPaymentCriteria = null;
                this._ClaimPaymentStartDate = null;
                this._ClaimPaymentEndDate = null;
                this._Location = null;
                this._Region = null;
                this._CoverageState = null;
                this._BodyPart = null;
                this._Cause = null;
                this._NatureOfInjury = null;
                this._MPCriteria = null;
                this._MPStartAmount = null;
                this._MPEndAmount = null;
                this._MICriteria = null;
                this._MIStartAmount = null;
                this._MIEndAmount = null;
                this._EPCriteria = null;
                this._EPStartAmount = null;
                this._EPEndAmount = null;
                this._EICriteria = null;
                this._EIStartAmount = null;
                this._EIEndAmount = null;
                this._IPCriteria = null;
                this._IPStartAmount = null;
                this._IPEndAmount = null;
                this._IICriteria = null;
                this._IIStartAmount = null;
                this._IIEndAmount = null;
                this._TPCriteria = null;
                this._TPStartAmount = null;
                this._TPEndAmount = null;
                this._TICriteria = null;
                this._TIStartAmount = null;
                this._TIEndAmount = null;
                this._TOCriteria = null;
                this._TOStartAmount = null;
                this._TOEndAmount = null;
                this._OutputFields = null;
                this._SortFields = null;
                this._ShowSubTotal = null;
                this._ShowGrandTotal = null;
                this._PriorValueDate = null;
                this._UserId = null;
                this._UpdatedDate = null;
                this._MOCriteria = null;
                this._MOStartAmount = null;
                this._MOEndAmount = null;
                this._EOCriteria = null;
                this._EOStartAmount = null;
                this._EOEndAmount = null;
                this._IOCriteria = null;
                this._IOStartAmount = null;
                this._IOEndAmount = null;
                this._OutputFieldsOrder = null;
                this._Indicator = null;
                this._SonicCauseCode = null;
                this._ClaimSubStaus = null;
                this._AL_Claim_Origin = null;
                this._FullFinalClincher = null;

                this._TCompCriteria = null;
                this._TCompStartAmount = null;
                this._TCompEndAmount = null;
                this._TReserveCriteria = null;
                this._TReserveStartAmount = null;
                this._TReserveEndAmount = null;
                this._UCostCriteria = null;
                this._UCostStartAmount = null;
                this._UCostEndAmount = null;
                this._LMVCriteria = null;
                this._LMVStartAmount = null;
                this._LMVEndAmount = null;
                this._HCPCriteria = null;
                this._HCPStartAmount = null;
                this._HCPEndAmount = null;
                this._HCRCriteria = null;
                this._HCRStartAmount = null;
                this._HCREndAmount = null;
                this._SColledtedCriteria = null;
                this._SColledtedStartAmount = null;
                this._SColledtedEndAmount = null;
                this._TChargedCriteria = null;
                this._TChargedStartAmount = null;
                this._TChargedEndAmount = null;
                this._TTotalPaidCriteria = null;
                this._TTotalPaidStartAmount = null;
                this._TTotalPaidEndAmount = null;

                this._LineofCoverage = null;

                this._DateRestrictedBeginCriteria = null;
                this._DateRestrictedBeginStartDate = null;
                this._DateRestrictedBeginEndDate = null;
                this._DateRestrictedEndCriteria = null;
                this._DateRestrictedEndStartDate = null;
                this._DateRestrictedEndEndDate = null;
            }

        }

        #endregion

        #region Methods

        /// <summary>
        /// Inserts a record into the AdhocReport table.
        /// </summary>
        /// <returns></returns>
        public int InsertUpdate()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReportInsertUpdate");


            db.AddInParameter(dbCommand, "ReportId", DbType.Decimal, this._ReportId);
            if (string.IsNullOrEmpty(this._ReportName))
                db.AddInParameter(dbCommand, "ReportName", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ReportName", DbType.String, this._ReportName);

            if (string.IsNullOrEmpty(this._Claim_Type))
                db.AddInParameter(dbCommand, "Claim_Type",   DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Claim_Type", DbType.String, this._Claim_Type);

            if (string.IsNullOrEmpty(this._OStatus))
                db.AddInParameter(dbCommand, "OStatus", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OStatus", DbType.String, this._OStatus);

            if (string.IsNullOrEmpty(this._CStatus))
                db.AddInParameter(dbCommand, "CStatus", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CStatus", DbType.String, this._CStatus);

            if (string.IsNullOrEmpty(this._ROStatus))
                db.AddInParameter(dbCommand, "ROStatus", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ROStatus", DbType.String, this._ROStatus);

            if (string.IsNullOrEmpty(this._ClaimOpenCriteria))
                db.AddInParameter(dbCommand, "ClaimOpenCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ClaimOpenCriteria", DbType.String, this._ClaimOpenCriteria);

            db.AddInParameter(dbCommand, "ClaimOpenStartDate", DbType.DateTime, this._ClaimOpenStartDate);

            db.AddInParameter(dbCommand, "ClaimOpenEndDate", DbType.DateTime, this._ClaimOpenEndDate);

            if (string.IsNullOrEmpty(this._ClaimCloseCriteria))
                db.AddInParameter(dbCommand, "ClaimCloseCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ClaimCloseCriteria", DbType.String, this._ClaimCloseCriteria);

            db.AddInParameter(dbCommand, "ClaimCloseStartDate", DbType.DateTime, this._ClaimCloseStartDate);

            db.AddInParameter(dbCommand, "ClaimCloseEndDate", DbType.DateTime, this._ClaimCloseEndDate);

            if (string.IsNullOrEmpty(this._DOICriteria))
                db.AddInParameter(dbCommand, "DOICriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DOICriteria", DbType.String, this._DOICriteria);

            db.AddInParameter(dbCommand, "DOIStart", DbType.DateTime, this._DOIStart);

            db.AddInParameter(dbCommand, "DOIEnd", DbType.DateTime, this._DOIEnd);

            if (string.IsNullOrEmpty(this._ValueAsOfDateCriteria))
                db.AddInParameter(dbCommand, "ValueAsOfDateCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ValueAsOfDateCriteria", DbType.String, this._ValueAsOfDateCriteria);

            db.AddInParameter(dbCommand, "ValueAsOfDateStartDate", DbType.DateTime, this._ValueAsOfDateStartDate);

            db.AddInParameter(dbCommand, "ValueAsOfDateEndDate", DbType.DateTime, this._ValueAsOfDateEndDate);

            if (string.IsNullOrEmpty(this._ClaimReserveCriteria))
                db.AddInParameter(dbCommand, "ClaimReserveCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ClaimReserveCriteria", DbType.String, this._ClaimReserveCriteria);

            db.AddInParameter(dbCommand, "ClaimReserveStartDate", DbType.DateTime, this._ClaimReserveStartDate);

            db.AddInParameter(dbCommand, "ClaimReserveEndDate", DbType.DateTime, this._ClaimReserveEndDate);

            if (string.IsNullOrEmpty(this._ClaimPaymentCriteria))
                db.AddInParameter(dbCommand, "ClaimPaymentCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ClaimPaymentCriteria", DbType.String, this._ClaimPaymentCriteria);

            db.AddInParameter(dbCommand, "ClaimPaymentStartDate", DbType.DateTime, this._ClaimPaymentStartDate);

            db.AddInParameter(dbCommand, "ClaimPaymentEndDate", DbType.DateTime, this._ClaimPaymentEndDate);

            if (string.IsNullOrEmpty(this._Location))
                db.AddInParameter(dbCommand, "Location", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location", DbType.String, this._Location);

            if (string.IsNullOrEmpty(this._Region))
                db.AddInParameter(dbCommand, "Region", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Region", DbType.String, this._Region);

            if (string.IsNullOrEmpty(this._Market))
                db.AddInParameter(dbCommand, "Market", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Market", DbType.String, this._Market);

            if (string.IsNullOrEmpty(this._CoverageState))
                db.AddInParameter(dbCommand, "CoverageState", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "CoverageState", DbType.String, this._CoverageState);

            if (string.IsNullOrEmpty(this._BodyPart))
                db.AddInParameter(dbCommand, "BodyPart", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "BodyPart", DbType.String, this._BodyPart);

            if (string.IsNullOrEmpty(this._Cause))
                db.AddInParameter(dbCommand, "Cause", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Cause", DbType.String, this._Cause);

            if (string.IsNullOrEmpty(this._NatureOfInjury))
                db.AddInParameter(dbCommand, "NatureOfInjury", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "NatureOfInjury", DbType.String, this._NatureOfInjury);

            if (string.IsNullOrEmpty(this._MPCriteria))
                db.AddInParameter(dbCommand, "MPCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "MPCriteria", DbType.String, this._MPCriteria);

            db.AddInParameter(dbCommand, "MPStartAmount", DbType.Decimal, this._MPStartAmount);

            db.AddInParameter(dbCommand, "MPEndAmount", DbType.Decimal, this._MPEndAmount);

            if (string.IsNullOrEmpty(this._MICriteria))
                db.AddInParameter(dbCommand, "MICriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "MICriteria", DbType.String, this._MICriteria);

            db.AddInParameter(dbCommand, "MIStartAmount", DbType.Decimal, this._MIStartAmount);

            db.AddInParameter(dbCommand, "MIEndAmount", DbType.Decimal, this._MIEndAmount);

            if (string.IsNullOrEmpty(this._EPCriteria))
                db.AddInParameter(dbCommand, "EPCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EPCriteria", DbType.String, this._EPCriteria);

            db.AddInParameter(dbCommand, "EPStartAmount", DbType.Decimal, this._EPStartAmount);

            db.AddInParameter(dbCommand, "EPEndAmount", DbType.Decimal, this._EPEndAmount);

            if (string.IsNullOrEmpty(this._EICriteria))
                db.AddInParameter(dbCommand, "EICriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EICriteria", DbType.String, this._EICriteria);

            db.AddInParameter(dbCommand, "EIStartAmount", DbType.Decimal, this._EIStartAmount);

            db.AddInParameter(dbCommand, "EIEndAmount", DbType.Decimal, this._EIEndAmount);

            if (string.IsNullOrEmpty(this._IPCriteria))
                db.AddInParameter(dbCommand, "IPCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "IPCriteria", DbType.String, this._IPCriteria);

            db.AddInParameter(dbCommand, "IPStartAmount", DbType.Decimal, this._IPStartAmount);

            db.AddInParameter(dbCommand, "IPEndAmount", DbType.Decimal, this._IPEndAmount);

            if (string.IsNullOrEmpty(this._IICriteria))
                db.AddInParameter(dbCommand, "IICriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "IICriteria", DbType.String, this._IICriteria);

            db.AddInParameter(dbCommand, "IIStartAmount", DbType.Decimal, this._IIStartAmount);

            db.AddInParameter(dbCommand, "IIEndAmount", DbType.Decimal, this._IIEndAmount);

            if (string.IsNullOrEmpty(this._TPCriteria))
                db.AddInParameter(dbCommand, "TPCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TPCriteria", DbType.String, this._TPCriteria);

            db.AddInParameter(dbCommand, "TPStartAmount", DbType.Decimal, this._TPStartAmount);

            db.AddInParameter(dbCommand, "TPEndAmount", DbType.Decimal, this._TPEndAmount);

            if (string.IsNullOrEmpty(this._TICriteria))
                db.AddInParameter(dbCommand, "TICriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TICriteria", DbType.String, this._TICriteria);

            db.AddInParameter(dbCommand, "TIStartAmount", DbType.Decimal, this._TIStartAmount);

            db.AddInParameter(dbCommand, "TIEndAmount", DbType.Decimal, this._TIEndAmount);

            if (string.IsNullOrEmpty(this._TOCriteria))
                db.AddInParameter(dbCommand, "TOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TOCriteria", DbType.String, this._TOCriteria);

            db.AddInParameter(dbCommand, "TOStartAmount", DbType.Decimal, this._TOStartAmount);

            db.AddInParameter(dbCommand, "TOEndAmount", DbType.Decimal, this._TOEndAmount);

            if (string.IsNullOrEmpty(this._OutputFields))
                db.AddInParameter(dbCommand, "OutputFields", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "OutputFields", DbType.String, this._OutputFields);

            if (string.IsNullOrEmpty(this._SortFields))
                db.AddInParameter(dbCommand, "SortFields", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SortFields", DbType.String, this._SortFields);

            if (string.IsNullOrEmpty(this._ShowSubTotal))
                db.AddInParameter(dbCommand, "ShowSubTotal", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ShowSubTotal", DbType.String, this._ShowSubTotal);

            if (string.IsNullOrEmpty(this._ShowGrandTotal))
                db.AddInParameter(dbCommand, "ShowGrandTotal", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ShowGrandTotal", DbType.String, this._ShowGrandTotal);

            db.AddInParameter(dbCommand, "PriorValueDate", DbType.DateTime, this._PriorValueDate);

            db.AddInParameter(dbCommand, "UserId", DbType.Decimal, this._UserId);

            db.AddInParameter(dbCommand, "UpdatedDate", DbType.DateTime, this._UpdatedDate);

            if (string.IsNullOrEmpty(this._MOCriteria))
                db.AddInParameter(dbCommand, "MOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "MOCriteria", DbType.String, this._MOCriteria);

            db.AddInParameter(dbCommand, "MOStartAmount", DbType.Decimal, this._MOStartAmount);

            db.AddInParameter(dbCommand, "MOEndAmount", DbType.Decimal, this._MOEndAmount);

            if (string.IsNullOrEmpty(this._EOCriteria))
                db.AddInParameter(dbCommand, "EOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EOCriteria", DbType.String, this._EOCriteria);

            db.AddInParameter(dbCommand, "EOStartAmount", DbType.Decimal, this._EOStartAmount);

            db.AddInParameter(dbCommand, "EOEndAmount", DbType.Decimal, this._EOEndAmount);

            if (string.IsNullOrEmpty(this._IOCriteria))
                db.AddInParameter(dbCommand, "IOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "IOCriteria", DbType.String, this._IOCriteria);

            db.AddInParameter(dbCommand, "IOStartAmount", DbType.Decimal, this._IOStartAmount);

            db.AddInParameter(dbCommand, "IOEndAmount", DbType.Decimal, this._IOEndAmount);

            db.AddInParameter(dbCommand, "OutputFieldsOrder", DbType.String, this._OutputFieldsOrder);
            db.AddInParameter(dbCommand, "Indicator", DbType.String, this._Indicator);
            db.AddInParameter(dbCommand, "Sonic_Cause_Code", DbType.String, this._SonicCauseCode);
            db.AddInParameter(dbCommand, "ClaimSubStaus", DbType.String, this._ClaimSubStaus);
            db.AddInParameter(dbCommand, "ALClaimOrigin", DbType.String, this._AL_Claim_Origin);
            db.AddInParameter(dbCommand, "FullFinalClincher", DbType.String, this._FullFinalClincher);


            if (string.IsNullOrEmpty(this._TCompCriteria))
                db.AddInParameter(dbCommand, "TCompCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TCompCriteria", DbType.String, this._TCompCriteria);

            db.AddInParameter(dbCommand, "TCompStartAmount", DbType.Decimal, this._TCompStartAmount);

            db.AddInParameter(dbCommand, "TCompEndAmount", DbType.Decimal, this._TCompEndAmount);

            if (string.IsNullOrEmpty(this._TReserveCriteria))
                db.AddInParameter(dbCommand, "TReserveCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TReserveCriteria", DbType.String, this._TReserveCriteria);

            db.AddInParameter(dbCommand, "TReserveStartAmount", DbType.Decimal, this._TReserveStartAmount);

            db.AddInParameter(dbCommand, "TReserveEndAmount", DbType.Decimal, this._TReserveEndAmount);

            if (string.IsNullOrEmpty(this._UCostCriteria))
                db.AddInParameter(dbCommand, "UCostCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "UCostCriteria", DbType.String, this._UCostCriteria);

            db.AddInParameter(dbCommand, "UCostStartAmount", DbType.Decimal, this._UCostStartAmount);

            db.AddInParameter(dbCommand, "UCostEndAmount", DbType.Decimal, this._UCostEndAmount);

            if (string.IsNullOrEmpty(this._LMVCriteria))
                db.AddInParameter(dbCommand, "LMVCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LMVCriteria", DbType.String, this._LMVCriteria);

            db.AddInParameter(dbCommand, "LMVStartAmount", DbType.Decimal, this._LMVStartAmount);

            db.AddInParameter(dbCommand, "LMVEndAmount", DbType.Decimal, this._LMVEndAmount);

            if (string.IsNullOrEmpty(this._HCPCriteria))
                db.AddInParameter(dbCommand, "HCPCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "HCPCriteria", DbType.String, this._HCPCriteria);

            db.AddInParameter(dbCommand, "HCPStartAmount", DbType.Decimal, this._HCPStartAmount);

            db.AddInParameter(dbCommand, "HCPEndAmount", DbType.Decimal, this._HCPEndAmount);

            if (string.IsNullOrEmpty(this._HCRCriteria))
                db.AddInParameter(dbCommand, "HCRCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "HCRCriteria", DbType.String, this._HCRCriteria);

            db.AddInParameter(dbCommand, "HCRStartAmount", DbType.Decimal, this._HCRStartAmount);

            db.AddInParameter(dbCommand, "HCREndAmount", DbType.Decimal, this._HCREndAmount);


            if (string.IsNullOrEmpty(this._SColledtedCriteria))
                db.AddInParameter(dbCommand, "SColledtedCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SColledtedCriteria", DbType.String, this._SColledtedCriteria);

            db.AddInParameter(dbCommand, "SColledtedStartAmount", DbType.Decimal, this._SColledtedStartAmount);

            db.AddInParameter(dbCommand, "SColledtedEndAmount", DbType.Decimal, this._SColledtedEndAmount);

            if (string.IsNullOrEmpty(this._TChargedCriteria))
                db.AddInParameter(dbCommand, "TChargedCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TChargedCriteria", DbType.String, this._TChargedCriteria);

            db.AddInParameter(dbCommand, "TChargedStartAmount", DbType.Decimal, this._TChargedStartAmount);

            db.AddInParameter(dbCommand, "TChargedEndAmount", DbType.Decimal, this._TChargedEndAmount);

            if (string.IsNullOrEmpty(this._TTotalPaidCriteria))
                db.AddInParameter(dbCommand, "TTotalPaidCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "TTotalPaidCriteria", DbType.String, this._TTotalPaidCriteria);

            db.AddInParameter(dbCommand, "TTotalPaidStartAmount", DbType.Decimal, this._TTotalPaidStartAmount);

            db.AddInParameter(dbCommand, "TTotalPaidEndAmount", DbType.Decimal, this._TTotalPaidEndAmount);

            if (string.IsNullOrEmpty(this._LineofCoverage))
                db.AddInParameter(dbCommand, "LineofCoverage", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LineofCoverage", DbType.String, this._LineofCoverage);

            if (string.IsNullOrEmpty(this._DateRestrictedBeginCriteria))
                db.AddInParameter(dbCommand, "DateRestrictedBeginCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DateRestrictedBeginCriteria", DbType.String, this._DateRestrictedBeginCriteria);

            db.AddInParameter(dbCommand, "DateRestrictedBeginStartDate", DbType.DateTime, this._DateRestrictedBeginStartDate);

            db.AddInParameter(dbCommand, "DateRestrictedBeginEndDate", DbType.DateTime, this._DateRestrictedBeginEndDate);

            if (string.IsNullOrEmpty(this._DateRestrictedEndCriteria))
                db.AddInParameter(dbCommand, "DateRestrictedEndCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DateRestrictedEndCriteria", DbType.String, this._DateRestrictedEndCriteria);

            db.AddInParameter(dbCommand, "DateRestrictedEndStartDate", DbType.DateTime, this._DateRestrictedEndStartDate);

            db.AddInParameter(dbCommand, "DateRestrictedEndEndDate", DbType.DateTime, this._DateRestrictedEndEndDate);


            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the AdhocReport table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal reportId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReportSelectByPK");

            db.AddInParameter(dbCommand, "ReportId", DbType.Decimal, reportId);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all record from the AdhocReport table by a claimType.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByClaimType(string claimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReportSelectByClaimType");

            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, claimType);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the AdhocReport table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReportSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the AdhocReport table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal reportId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReportDeleteByPK");

            db.AddInParameter(dbCommand, "ReportId", DbType.Decimal, reportId);

            db.ExecuteNonQuery(dbCommand);
        }

        public DataSet GetReportWC(DateTime PriorValueDate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReportGenerateReport");

            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, _Claim_Type);
            db.AddInParameter(dbCommand, "@OStatus", DbType.String, _OStatus);
            db.AddInParameter(dbCommand, "@CStatus", DbType.String, _CStatus);
            db.AddInParameter(dbCommand, "@ROStatus", DbType.String, _ROStatus);

            db.AddInParameter(dbCommand, "@ClaimOpenCriteria", DbType.String, _ClaimOpenCriteria);
            db.AddInParameter(dbCommand, "@ClaimOpenStartDate", DbType.String, _ClaimOpenStartDate);
            db.AddInParameter(dbCommand, "@ClaimOpenEndDate", DbType.String, _ClaimOpenEndDate);

            db.AddInParameter(dbCommand, "@ClaimCloseCriteria", DbType.String, _ClaimCloseCriteria);
            db.AddInParameter(dbCommand, "@ClaimCloseStartDate", DbType.String, _ClaimCloseStartDate);
            db.AddInParameter(dbCommand, "@ClaimCloseEndDate", DbType.String, _ClaimCloseEndDate);

            db.AddInParameter(dbCommand, "@DOICriteria", DbType.String, _DOICriteria);
            db.AddInParameter(dbCommand, "@DOIStart", DbType.String, _DOIStart);
            db.AddInParameter(dbCommand, "@DOIEnd", DbType.String, _DOIEnd);

            db.AddInParameter(dbCommand, "@ClaimReserveCriteria", DbType.String, _ClaimReserveCriteria);
            db.AddInParameter(dbCommand, "@ClaimReserveStartDate", DbType.String, _ClaimReserveStartDate);
            db.AddInParameter(dbCommand, "@ClaimReserveEndDate", DbType.String, _ClaimReserveEndDate);

            db.AddInParameter(dbCommand, "@ClaimPaymentCriteria", DbType.String, _ClaimPaymentCriteria);
            db.AddInParameter(dbCommand, "@ClaimPaymentStartDate", DbType.String, _ClaimPaymentStartDate);
            db.AddInParameter(dbCommand, "@ClaimPaymentEndDate", DbType.String, _ClaimPaymentEndDate);

            db.AddInParameter(dbCommand, "@Location", DbType.String, _Location);
            db.AddInParameter(dbCommand, "@Region", DbType.String, _Region);
            db.AddInParameter(dbCommand, "@CoverageState", DbType.String, _CoverageState);
            db.AddInParameter(dbCommand, "@BodyPart", DbType.String, _BodyPart);
            db.AddInParameter(dbCommand, "@Cause", DbType.String, _Cause);
            db.AddInParameter(dbCommand, "@Nature_Of_Injury", DbType.String, _NatureOfInjury);

            db.AddInParameter(dbCommand, "@MPCriteria", DbType.String, _MPCriteria);
            db.AddInParameter(dbCommand, "@MPStartAmount", DbType.Decimal, _MPStartAmount);
            db.AddInParameter(dbCommand, "@MPEndAmount", DbType.Decimal, _MPEndAmount);

            db.AddInParameter(dbCommand, "@MICriteria", DbType.String, _MICriteria);
            db.AddInParameter(dbCommand, "@MIStartAmount", DbType.Decimal, _MIStartAmount);
            db.AddInParameter(dbCommand, "@MIEndAmount", DbType.Decimal, _MIEndAmount);

            db.AddInParameter(dbCommand, "@EPCriteria", DbType.String, _EPCriteria);
            db.AddInParameter(dbCommand, "@EPStartAmount", DbType.Decimal, _EPStartAmount);
            db.AddInParameter(dbCommand, "@EPEndAmount", DbType.Decimal, _EPEndAmount);

            db.AddInParameter(dbCommand, "@EICriteria", DbType.String, _EICriteria);
            db.AddInParameter(dbCommand, "@EIStartAmount", DbType.Decimal, _EIStartAmount);
            db.AddInParameter(dbCommand, "@EIEndAmount", DbType.Decimal, _EIEndAmount);

            db.AddInParameter(dbCommand, "@IPCriteria", DbType.String, _IPCriteria);
            db.AddInParameter(dbCommand, "@IPStartAmount", DbType.Decimal, _IPStartAmount);
            db.AddInParameter(dbCommand, "@IPEndAmount", DbType.Decimal, _IPEndAmount);

            db.AddInParameter(dbCommand, "@IICriteria", DbType.String, _IICriteria);
            db.AddInParameter(dbCommand, "@IIStartAmount", DbType.Decimal, _IIStartAmount);
            db.AddInParameter(dbCommand, "@IIEndAmount", DbType.Decimal, _IIEndAmount);

            db.AddInParameter(dbCommand, "@TPCriteria", DbType.String, _TPCriteria);
            db.AddInParameter(dbCommand, "@TPStartAmount", DbType.Decimal, _TPStartAmount);
            db.AddInParameter(dbCommand, "@TPEndAmount", DbType.Decimal, _TPEndAmount);

            db.AddInParameter(dbCommand, "@TICriteria", DbType.String, _TICriteria);
            db.AddInParameter(dbCommand, "@TIStartAmount", DbType.Decimal, _TIStartAmount);
            db.AddInParameter(dbCommand, "@TIEndAmount", DbType.Decimal, _TIEndAmount);

            db.AddInParameter(dbCommand, "@TOCriteria", DbType.String, _TOCriteria);
            db.AddInParameter(dbCommand, "@TOStartAmount", DbType.Decimal, _TOStartAmount);
            db.AddInParameter(dbCommand, "@TOEndAmount", DbType.Decimal, _TOEndAmount);

            db.AddInParameter(dbCommand, "@OutputFields", DbType.String, _OutputFields);
            db.AddInParameter(dbCommand, "@SortFields", DbType.String, _SortFields);
            db.AddInParameter(dbCommand, "@EmployeeID", DbType.String, clsSession.UserID);

            if (string.IsNullOrEmpty(this._ValueAsOfDateCriteria))
                db.AddInParameter(dbCommand, "ValueAsOfDateCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ValueAsOfDateCriteria", DbType.String, this._ValueAsOfDateCriteria);
            db.AddInParameter(dbCommand, "ValueAsOfDateStartDate", DbType.String, this._ValueAsOfDateStartDate);
            db.AddInParameter(dbCommand, "ValueAsOfDateEndDate", DbType.String, this._ValueAsOfDateEndDate);

            if (string.IsNullOrEmpty(this._EOCriteria))
                db.AddInParameter(dbCommand, "EOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EOCriteria", DbType.String, this._EOCriteria);

            db.AddInParameter(dbCommand, "EOStartAmount", DbType.Decimal, this._EOStartAmount);

            db.AddInParameter(dbCommand, "EOEndAmount", DbType.Decimal, this._EOEndAmount);

            if (string.IsNullOrEmpty(this._IOCriteria))
                db.AddInParameter(dbCommand, "IOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "IOCriteria", DbType.String, this._IOCriteria);

            db.AddInParameter(dbCommand, "IOStartAmount", DbType.Decimal, this._IOStartAmount);

            db.AddInParameter(dbCommand, "IOEndAmount", DbType.Decimal, this._IOEndAmount);

            if (string.IsNullOrEmpty(this._Indicator))
                db.AddInParameter(dbCommand, "Indicator", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Indicator", DbType.String, this._Indicator);

            if (string.IsNullOrEmpty(this._SonicCauseCode))
                db.AddInParameter(dbCommand, "Sonic_cause_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_cause_Code", DbType.String, this._SonicCauseCode);

            if (string.IsNullOrEmpty(this._ClaimSubStaus))
                db.AddInParameter(dbCommand, "ClaimSubStaus", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ClaimSubStaus", DbType.String, this._ClaimSubStaus);

            if (string.IsNullOrEmpty(this._FullFinalClincher))
                db.AddInParameter(dbCommand, "FullFinalClincher", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FullFinalClincher", DbType.String, this._FullFinalClincher);

            if (string.IsNullOrEmpty(this._DateRestrictedBeginCriteria))
                db.AddInParameter(dbCommand, "DateRestrictedBeginCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DateRestrictedBeginCriteria", DbType.String, this._DateRestrictedBeginCriteria);

            db.AddInParameter(dbCommand, "DateRestrictedBeginStartDate", DbType.DateTime, this._DateRestrictedBeginStartDate);

            db.AddInParameter(dbCommand, "DateRestrictedBeginEndDate", DbType.DateTime, this._DateRestrictedBeginEndDate);

            if (string.IsNullOrEmpty(this._DateRestrictedEndCriteria))
                db.AddInParameter(dbCommand, "DateRestrictedEndCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DateRestrictedEndCriteria", DbType.String, this._DateRestrictedEndCriteria);

            db.AddInParameter(dbCommand, "DateRestrictedEndStartDate", DbType.DateTime, this._DateRestrictedEndStartDate);

            db.AddInParameter(dbCommand, "DateRestrictedEndEndDate", DbType.DateTime, this._DateRestrictedEndEndDate);

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        public DataSet GetReportNS(DateTime PriorValueDate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReportGenerateReportNS");

            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, _Claim_Type);
            db.AddInParameter(dbCommand, "@OStatus", DbType.String, _OStatus);
            db.AddInParameter(dbCommand, "@CStatus", DbType.String, _CStatus);
            db.AddInParameter(dbCommand, "@ROStatus", DbType.String, _ROStatus);

            db.AddInParameter(dbCommand, "@ClaimOpenCriteria", DbType.String, _ClaimOpenCriteria);
            db.AddInParameter(dbCommand, "@ClaimOpenStartDate", DbType.String, _ClaimOpenStartDate);
            db.AddInParameter(dbCommand, "@ClaimOpenEndDate", DbType.String, _ClaimOpenEndDate);

            db.AddInParameter(dbCommand, "@ClaimCloseCriteria", DbType.String, _ClaimCloseCriteria);
            db.AddInParameter(dbCommand, "@ClaimCloseStartDate", DbType.String, _ClaimCloseStartDate);
            db.AddInParameter(dbCommand, "@ClaimCloseEndDate", DbType.String, _ClaimCloseEndDate);

            db.AddInParameter(dbCommand, "@DOICriteria", DbType.String, _DOICriteria);
            db.AddInParameter(dbCommand, "@DOIStart", DbType.String, _DOIStart);
            db.AddInParameter(dbCommand, "@DOIEnd", DbType.String, _DOIEnd);

            db.AddInParameter(dbCommand, "@ClaimReserveCriteria", DbType.String, _ClaimReserveCriteria);
            db.AddInParameter(dbCommand, "@ClaimReserveStartDate", DbType.String, _ClaimReserveStartDate);
            db.AddInParameter(dbCommand, "@ClaimReserveEndDate", DbType.String, _ClaimReserveEndDate);

            db.AddInParameter(dbCommand, "@ClaimPaymentCriteria", DbType.String, _ClaimPaymentCriteria);
            db.AddInParameter(dbCommand, "@ClaimPaymentStartDate", DbType.String, _ClaimPaymentStartDate);
            db.AddInParameter(dbCommand, "@ClaimPaymentEndDate", DbType.String, _ClaimPaymentEndDate);

            db.AddInParameter(dbCommand, "@Location", DbType.String, _Location);
            db.AddInParameter(dbCommand, "@Region", DbType.String, _Region);
            db.AddInParameter(dbCommand, "@CoverageState", DbType.String, _CoverageState);
            db.AddInParameter(dbCommand, "@BodyPart", DbType.String, _BodyPart);
            db.AddInParameter(dbCommand, "@Cause", DbType.String, _Cause);
            db.AddInParameter(dbCommand, "@Nature_Of_Injury", DbType.String, _NatureOfInjury);

            db.AddInParameter(dbCommand, "@MPCriteria", DbType.String, _MPCriteria);
            db.AddInParameter(dbCommand, "@MPStartAmount", DbType.Decimal, _MPStartAmount);
            db.AddInParameter(dbCommand, "@MPEndAmount", DbType.Decimal, _MPEndAmount);

            db.AddInParameter(dbCommand, "@MICriteria", DbType.String, _MICriteria);
            db.AddInParameter(dbCommand, "@MIStartAmount", DbType.Decimal, _MIStartAmount);
            db.AddInParameter(dbCommand, "@MIEndAmount", DbType.Decimal, _MIEndAmount);

            db.AddInParameter(dbCommand, "@EPCriteria", DbType.String, _EPCriteria);
            db.AddInParameter(dbCommand, "@EPStartAmount", DbType.Decimal, _EPStartAmount);
            db.AddInParameter(dbCommand, "@EPEndAmount", DbType.Decimal, _EPEndAmount);

            db.AddInParameter(dbCommand, "@EICriteria", DbType.String, _EICriteria);
            db.AddInParameter(dbCommand, "@EIStartAmount", DbType.Decimal, _EIStartAmount);
            db.AddInParameter(dbCommand, "@EIEndAmount", DbType.Decimal, _EIEndAmount);

            db.AddInParameter(dbCommand, "@IPCriteria", DbType.String, _IPCriteria);
            db.AddInParameter(dbCommand, "@IPStartAmount", DbType.Decimal, _IPStartAmount);
            db.AddInParameter(dbCommand, "@IPEndAmount", DbType.Decimal, _IPEndAmount);

            db.AddInParameter(dbCommand, "@IICriteria", DbType.String, _IICriteria);
            db.AddInParameter(dbCommand, "@IIStartAmount", DbType.Decimal, _IIStartAmount);
            db.AddInParameter(dbCommand, "@IIEndAmount", DbType.Decimal, _IIEndAmount);

            db.AddInParameter(dbCommand, "@TPCriteria", DbType.String, _TPCriteria);
            db.AddInParameter(dbCommand, "@TPStartAmount", DbType.Decimal, _TPStartAmount);
            db.AddInParameter(dbCommand, "@TPEndAmount", DbType.Decimal, _TPEndAmount);

            db.AddInParameter(dbCommand, "@TICriteria", DbType.String, _TICriteria);
            db.AddInParameter(dbCommand, "@TIStartAmount", DbType.Decimal, _TIStartAmount);
            db.AddInParameter(dbCommand, "@TIEndAmount", DbType.Decimal, _TIEndAmount);

            db.AddInParameter(dbCommand, "@TOCriteria", DbType.String, _TOCriteria);
            db.AddInParameter(dbCommand, "@TOStartAmount", DbType.Decimal, _TOStartAmount);
            db.AddInParameter(dbCommand, "@TOEndAmount", DbType.Decimal, _TOEndAmount);

            db.AddInParameter(dbCommand, "@OutputFields", DbType.String, _OutputFields);
            db.AddInParameter(dbCommand, "@SortFields", DbType.String, _SortFields);
            db.AddInParameter(dbCommand, "@EmployeeID", DbType.String, clsSession.UserID);

            if (string.IsNullOrEmpty(this._ValueAsOfDateCriteria))
                db.AddInParameter(dbCommand, "ValueAsOfDateCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ValueAsOfDateCriteria", DbType.String, this._ValueAsOfDateCriteria);
            db.AddInParameter(dbCommand, "ValueAsOfDateStartDate", DbType.String, this._ValueAsOfDateStartDate);
            db.AddInParameter(dbCommand, "ValueAsOfDateEndDate", DbType.String, this._ValueAsOfDateEndDate);

            if (string.IsNullOrEmpty(this._EOCriteria))
                db.AddInParameter(dbCommand, "EOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EOCriteria", DbType.String, this._EOCriteria);

            db.AddInParameter(dbCommand, "EOStartAmount", DbType.Decimal, this._EOStartAmount);

            db.AddInParameter(dbCommand, "EOEndAmount", DbType.Decimal, this._EOEndAmount);

            if (string.IsNullOrEmpty(this._IOCriteria))
                db.AddInParameter(dbCommand, "IOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "IOCriteria", DbType.String, this._IOCriteria);

            db.AddInParameter(dbCommand, "IOStartAmount", DbType.Decimal, this._IOStartAmount);

            db.AddInParameter(dbCommand, "IOEndAmount", DbType.Decimal, this._IOEndAmount);

            if (string.IsNullOrEmpty(this._Indicator))
                db.AddInParameter(dbCommand, "Indicator", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Indicator", DbType.String, this._Indicator);

            if (string.IsNullOrEmpty(this._SonicCauseCode))
                db.AddInParameter(dbCommand, "Sonic_cause_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_cause_Code", DbType.String, this._SonicCauseCode);

            if (string.IsNullOrEmpty(this._ClaimSubStaus))
                db.AddInParameter(dbCommand, "ClaimSubStaus", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ClaimSubStaus", DbType.String, this._ClaimSubStaus);

            if (string.IsNullOrEmpty(this._FullFinalClincher))
                db.AddInParameter(dbCommand, "FullFinalClincher", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FullFinalClincher", DbType.String, this._FullFinalClincher);

            if (string.IsNullOrEmpty(this._DateRestrictedBeginCriteria))
                db.AddInParameter(dbCommand, "DateRestrictedBeginCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DateRestrictedBeginCriteria", DbType.String, this._DateRestrictedBeginCriteria);

            db.AddInParameter(dbCommand, "DateRestrictedBeginStartDate", DbType.DateTime, this._DateRestrictedBeginStartDate);

            db.AddInParameter(dbCommand, "DateRestrictedBeginEndDate", DbType.DateTime, this._DateRestrictedBeginEndDate);

            if (string.IsNullOrEmpty(this._DateRestrictedEndCriteria))
                db.AddInParameter(dbCommand, "DateRestrictedEndCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "DateRestrictedEndCriteria", DbType.String, this._DateRestrictedEndCriteria);

            db.AddInParameter(dbCommand, "DateRestrictedEndStartDate", DbType.DateTime, this._DateRestrictedEndStartDate);

            db.AddInParameter(dbCommand, "DateRestrictedEndEndDate", DbType.DateTime, this._DateRestrictedEndEndDate);

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        public DataSet GetReportAL(DateTime PriorValueDate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReportGenerateALReport");

            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, _Claim_Type);
            db.AddInParameter(dbCommand, "@OStatus", DbType.String, _OStatus);
            db.AddInParameter(dbCommand, "@CStatus", DbType.String, _CStatus);
            db.AddInParameter(dbCommand, "@ROStatus", DbType.String, _ROStatus);

            db.AddInParameter(dbCommand, "@ClaimOpenCriteria", DbType.String, _ClaimOpenCriteria);
            db.AddInParameter(dbCommand, "@ClaimOpenStartDate", DbType.String, _ClaimOpenStartDate);
            db.AddInParameter(dbCommand, "@ClaimOpenEndDate", DbType.String, _ClaimOpenEndDate);

            db.AddInParameter(dbCommand, "@ClaimCloseCriteria", DbType.String, _ClaimCloseCriteria);
            db.AddInParameter(dbCommand, "@ClaimCloseStartDate", DbType.String, _ClaimCloseStartDate);
            db.AddInParameter(dbCommand, "@ClaimCloseEndDate", DbType.String, _ClaimCloseEndDate);

            db.AddInParameter(dbCommand, "@DOICriteria", DbType.String, _DOICriteria);
            db.AddInParameter(dbCommand, "@DOIStart", DbType.String, _DOIStart);
            db.AddInParameter(dbCommand, "@DOIEnd", DbType.String, _DOIEnd);

            db.AddInParameter(dbCommand, "@ClaimReserveCriteria", DbType.String, _ClaimReserveCriteria);
            db.AddInParameter(dbCommand, "@ClaimReserveStartDate", DbType.String, _ClaimReserveStartDate);
            db.AddInParameter(dbCommand, "@ClaimReserveEndDate", DbType.String, _ClaimReserveEndDate);

            db.AddInParameter(dbCommand, "@ClaimPaymentCriteria", DbType.String, _ClaimPaymentCriteria);
            db.AddInParameter(dbCommand, "@ClaimPaymentStartDate", DbType.String, _ClaimPaymentStartDate);
            db.AddInParameter(dbCommand, "@ClaimPaymentEndDate", DbType.String, _ClaimPaymentEndDate);

            db.AddInParameter(dbCommand, "@Location", DbType.String, _Location);
            db.AddInParameter(dbCommand, "@Region", DbType.String, _Region);
            db.AddInParameter(dbCommand, "@CoverageState", DbType.String, _CoverageState);
            //db.AddInParameter(dbCommand, "@BodyPart", DbType.String, _BodyPart);
            //db.AddInParameter(dbCommand, "@Cause", DbType.String, _Cause);
            //db.AddInParameter(dbCommand, "@Nature_Of_Injury", DbType.String, _NatureOfInjury);

            //db.AddInParameter(dbCommand, "@MPCriteria", DbType.String, _MPCriteria);
            //db.AddInParameter(dbCommand, "@MPStartAmount", DbType.Decimal, _MPStartAmount);
            //db.AddInParameter(dbCommand, "@MPEndAmount", DbType.Decimal, _MPEndAmount);

            //db.AddInParameter(dbCommand, "@MICriteria", DbType.String, _MICriteria);
            //db.AddInParameter(dbCommand, "@MIStartAmount", DbType.Decimal, _MIStartAmount);
            //db.AddInParameter(dbCommand, "@MIEndAmount", DbType.Decimal, _MIEndAmount);

            db.AddInParameter(dbCommand, "@EPCriteria", DbType.String, _EPCriteria);
            db.AddInParameter(dbCommand, "@EPStartAmount", DbType.Decimal, _EPStartAmount);
            db.AddInParameter(dbCommand, "@EPEndAmount", DbType.Decimal, _EPEndAmount);

            db.AddInParameter(dbCommand, "@EICriteria", DbType.String, _EICriteria);
            db.AddInParameter(dbCommand, "@EIStartAmount", DbType.Decimal, _EIStartAmount);
            db.AddInParameter(dbCommand, "@EIEndAmount", DbType.Decimal, _EIEndAmount);

            db.AddInParameter(dbCommand, "@IPCriteria", DbType.String, _IPCriteria);
            db.AddInParameter(dbCommand, "@IPStartAmount", DbType.Decimal, _IPStartAmount);
            db.AddInParameter(dbCommand, "@IPEndAmount", DbType.Decimal, _IPEndAmount);

            db.AddInParameter(dbCommand, "@IICriteria", DbType.String, _IICriteria);
            db.AddInParameter(dbCommand, "@IIStartAmount", DbType.Decimal, _IIStartAmount);
            db.AddInParameter(dbCommand, "@IIEndAmount", DbType.Decimal, _IIEndAmount);

            db.AddInParameter(dbCommand, "@TPCriteria", DbType.String, _TPCriteria);
            db.AddInParameter(dbCommand, "@TPStartAmount", DbType.Decimal, _TPStartAmount);
            db.AddInParameter(dbCommand, "@TPEndAmount", DbType.Decimal, _TPEndAmount);

            db.AddInParameter(dbCommand, "@TICriteria", DbType.String, _TICriteria);
            db.AddInParameter(dbCommand, "@TIStartAmount", DbType.Decimal, _TIStartAmount);
            db.AddInParameter(dbCommand, "@TIEndAmount", DbType.Decimal, _TIEndAmount);

            db.AddInParameter(dbCommand, "@TOCriteria", DbType.String, _TOCriteria);
            db.AddInParameter(dbCommand, "@TOStartAmount", DbType.Decimal, _TOStartAmount);
            db.AddInParameter(dbCommand, "@TOEndAmount", DbType.Decimal, _TOEndAmount);

            db.AddInParameter(dbCommand, "@OutputFields", DbType.String, _OutputFields);
            db.AddInParameter(dbCommand, "@SortFields", DbType.String, _SortFields);
            db.AddInParameter(dbCommand, "@EmployeeID", DbType.String, clsSession.UserID);

            if (string.IsNullOrEmpty(this._ValueAsOfDateCriteria))
                db.AddInParameter(dbCommand, "ValueAsOfDateCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ValueAsOfDateCriteria", DbType.String, this._ValueAsOfDateCriteria);
            db.AddInParameter(dbCommand, "ValueAsOfDateStartDate", DbType.String, this._ValueAsOfDateStartDate);
            db.AddInParameter(dbCommand, "ValueAsOfDateEndDate", DbType.String, this._ValueAsOfDateEndDate);

            if (string.IsNullOrEmpty(this._MOCriteria))
                db.AddInParameter(dbCommand, "MOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "MOCriteria", DbType.String, this._MOCriteria);

            db.AddInParameter(dbCommand, "MOStartAmount", DbType.Decimal, this._MOStartAmount);

            db.AddInParameter(dbCommand, "MOEndAmount", DbType.Decimal, this._MOEndAmount);

            if (string.IsNullOrEmpty(this._EOCriteria))
                db.AddInParameter(dbCommand, "EOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EOCriteria", DbType.String, this._EOCriteria);

            db.AddInParameter(dbCommand, "EOStartAmount", DbType.Decimal, this._EOStartAmount);

            db.AddInParameter(dbCommand, "EOEndAmount", DbType.Decimal, this._EOEndAmount);

            if (string.IsNullOrEmpty(this._IOCriteria))
                db.AddInParameter(dbCommand, "IOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "IOCriteria", DbType.String, this._IOCriteria);

            db.AddInParameter(dbCommand, "IOStartAmount", DbType.Decimal, this._IOStartAmount);

            db.AddInParameter(dbCommand, "IOEndAmount", DbType.Decimal, this._IOEndAmount);
            db.AddInParameter(dbCommand, "ALClaimOrigin", DbType.String, this._AL_Claim_Origin);
            if (string.IsNullOrEmpty(this._ClaimSubStaus))
                db.AddInParameter(dbCommand, "ClaimSubStaus", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ClaimSubStaus", DbType.String, this._ClaimSubStaus);

            if (string.IsNullOrEmpty(this._LineofCoverage))
                db.AddInParameter(dbCommand, "LineofCoverage", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "LineofCoverage", DbType.String, this._LineofCoverage);

            return db.ExecuteDataSet(dbCommand);
        }

        public DataSet GetReportPL(DateTime PriorValueDate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReportGeneratePLReport");

            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, _Claim_Type);
            db.AddInParameter(dbCommand, "@OStatus", DbType.String, _OStatus);
            db.AddInParameter(dbCommand, "@CStatus", DbType.String, _CStatus);
            db.AddInParameter(dbCommand, "@ROStatus", DbType.String, _ROStatus);

            db.AddInParameter(dbCommand, "@ClaimOpenCriteria", DbType.String, _ClaimOpenCriteria);
            db.AddInParameter(dbCommand, "@ClaimOpenStartDate", DbType.String, _ClaimOpenStartDate);
            db.AddInParameter(dbCommand, "@ClaimOpenEndDate", DbType.String, _ClaimOpenEndDate);

            db.AddInParameter(dbCommand, "@ClaimCloseCriteria", DbType.String, _ClaimCloseCriteria);
            db.AddInParameter(dbCommand, "@ClaimCloseStartDate", DbType.String, _ClaimCloseStartDate);
            db.AddInParameter(dbCommand, "@ClaimCloseEndDate", DbType.String, _ClaimCloseEndDate);

            db.AddInParameter(dbCommand, "@DOICriteria", DbType.String, _DOICriteria);
            db.AddInParameter(dbCommand, "@DOIStart", DbType.String, _DOIStart);
            db.AddInParameter(dbCommand, "@DOIEnd", DbType.String, _DOIEnd);

            db.AddInParameter(dbCommand, "@ClaimReserveCriteria", DbType.String, _ClaimReserveCriteria);
            db.AddInParameter(dbCommand, "@ClaimReserveStartDate", DbType.String, _ClaimReserveStartDate);
            db.AddInParameter(dbCommand, "@ClaimReserveEndDate", DbType.String, _ClaimReserveEndDate);

            db.AddInParameter(dbCommand, "@ClaimPaymentCriteria", DbType.String, _ClaimPaymentCriteria);
            db.AddInParameter(dbCommand, "@ClaimPaymentStartDate", DbType.String, _ClaimPaymentStartDate);
            db.AddInParameter(dbCommand, "@ClaimPaymentEndDate", DbType.String, _ClaimPaymentEndDate);

            db.AddInParameter(dbCommand, "@Location", DbType.String, _Location);
            db.AddInParameter(dbCommand, "@Region", DbType.String, _Region);
            db.AddInParameter(dbCommand, "@CoverageState", DbType.String, _CoverageState);
            //db.AddInParameter(dbCommand, "@BodyPart", DbType.String, _BodyPart);
            //db.AddInParameter(dbCommand, "@Cause", DbType.String, _Cause);
            //db.AddInParameter(dbCommand, "@Nature_Of_Injury", DbType.String, _NatureOfInjury);

            //db.AddInParameter(dbCommand, "@MPCriteria", DbType.String, _MPCriteria);
            //db.AddInParameter(dbCommand, "@MPStartAmount", DbType.Decimal, _MPStartAmount);
            //db.AddInParameter(dbCommand, "@MPEndAmount", DbType.Decimal, _MPEndAmount);

            //db.AddInParameter(dbCommand, "@MICriteria", DbType.String, _MICriteria);
            //db.AddInParameter(dbCommand, "@MIStartAmount", DbType.Decimal, _MIStartAmount);
            //db.AddInParameter(dbCommand, "@MIEndAmount", DbType.Decimal, _MIEndAmount);

            db.AddInParameter(dbCommand, "@EPCriteria", DbType.String, _EPCriteria);
            db.AddInParameter(dbCommand, "@EPStartAmount", DbType.Decimal, _EPStartAmount);
            db.AddInParameter(dbCommand, "@EPEndAmount", DbType.Decimal, _EPEndAmount);

            db.AddInParameter(dbCommand, "@EICriteria", DbType.String, _EICriteria);
            db.AddInParameter(dbCommand, "@EIStartAmount", DbType.Decimal, _EIStartAmount);
            db.AddInParameter(dbCommand, "@EIEndAmount", DbType.Decimal, _EIEndAmount);

            db.AddInParameter(dbCommand, "@IPCriteria", DbType.String, _IPCriteria);
            db.AddInParameter(dbCommand, "@IPStartAmount", DbType.Decimal, _IPStartAmount);
            db.AddInParameter(dbCommand, "@IPEndAmount", DbType.Decimal, _IPEndAmount);

            db.AddInParameter(dbCommand, "@IICriteria", DbType.String, _IICriteria);
            db.AddInParameter(dbCommand, "@IIStartAmount", DbType.Decimal, _IIStartAmount);
            db.AddInParameter(dbCommand, "@IIEndAmount", DbType.Decimal, _IIEndAmount);

            db.AddInParameter(dbCommand, "@TPCriteria", DbType.String, _TPCriteria);
            db.AddInParameter(dbCommand, "@TPStartAmount", DbType.Decimal, _TPStartAmount);
            db.AddInParameter(dbCommand, "@TPEndAmount", DbType.Decimal, _TPEndAmount);

            db.AddInParameter(dbCommand, "@TICriteria", DbType.String, _TICriteria);
            db.AddInParameter(dbCommand, "@TIStartAmount", DbType.Decimal, _TIStartAmount);
            db.AddInParameter(dbCommand, "@TIEndAmount", DbType.Decimal, _TIEndAmount);

            db.AddInParameter(dbCommand, "@TOCriteria", DbType.String, _TOCriteria);
            db.AddInParameter(dbCommand, "@TOStartAmount", DbType.Decimal, _TOStartAmount);
            db.AddInParameter(dbCommand, "@TOEndAmount", DbType.Decimal, _TOEndAmount);

            db.AddInParameter(dbCommand, "@OutputFields", DbType.String, _OutputFields);
            db.AddInParameter(dbCommand, "@SortFields", DbType.String, _SortFields);
            db.AddInParameter(dbCommand, "@EmployeeID", DbType.Decimal, clsSession.UserID);

            if (string.IsNullOrEmpty(this._ValueAsOfDateCriteria))
                db.AddInParameter(dbCommand, "ValueAsOfDateCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ValueAsOfDateCriteria", DbType.String, this._ValueAsOfDateCriteria);
            db.AddInParameter(dbCommand, "ValueAsOfDateStartDate", DbType.String, this._ValueAsOfDateStartDate);
            db.AddInParameter(dbCommand, "ValueAsOfDateEndDate", DbType.String, this._ValueAsOfDateEndDate);

            if (string.IsNullOrEmpty(this._MOCriteria))
                db.AddInParameter(dbCommand, "MOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "MOCriteria", DbType.String, this._MOCriteria);

            db.AddInParameter(dbCommand, "MOStartAmount", DbType.Decimal, this._MOStartAmount);

            db.AddInParameter(dbCommand, "MOEndAmount", DbType.Decimal, this._MOEndAmount);

            if (string.IsNullOrEmpty(this._EOCriteria))
                db.AddInParameter(dbCommand, "EOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "EOCriteria", DbType.String, this._EOCriteria);

            db.AddInParameter(dbCommand, "EOStartAmount", DbType.Decimal, this._EOStartAmount);

            db.AddInParameter(dbCommand, "EOEndAmount", DbType.Decimal, this._EOEndAmount);

            if (string.IsNullOrEmpty(this._IOCriteria))
                db.AddInParameter(dbCommand, "IOCriteria", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "IOCriteria", DbType.String, this._IOCriteria);

            db.AddInParameter(dbCommand, "IOStartAmount", DbType.Decimal, this._IOStartAmount);

            db.AddInParameter(dbCommand, "IOEndAmount", DbType.Decimal, this._IOEndAmount);
            if (string.IsNullOrEmpty(this._ClaimSubStaus))
                db.AddInParameter(dbCommand, "ClaimSubStaus", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ClaimSubStaus", DbType.String, this._ClaimSubStaus);
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataTable FillClaimStatus()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("lu_claim_statusSelectAll");

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        public static DataSet IsReportNameExists(string ReportName, Decimal ReportID, string ClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReprotIsExists");

            db.AddInParameter(dbCommand, "@ReportName", DbType.String, ReportName);
            db.AddInParameter(dbCommand, "@ReportId", DbType.Decimal, ReportID);
            db.AddInParameter(dbCommand, "@ClaimType", DbType.String, ClaimType);

            return db.ExecuteDataSet(dbCommand);
        }

        public DataSet GetWCOhioAdhocReport()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("WCOhioAdhocReport");

            db.AddInParameter(dbCommand, "ClaimOpenCriteria", DbType.String, _ClaimOpenCriteria);
            db.AddInParameter(dbCommand, "ClaimOpenStartDate", DbType.DateTime, _ClaimOpenStartDate);
            db.AddInParameter(dbCommand, "ClaimOpenEndDate", DbType.DateTime, _ClaimOpenEndDate);
            db.AddInParameter(dbCommand, "ClaimCloseCriteria", DbType.String, _ClaimCloseCriteria);
            db.AddInParameter(dbCommand, "ClaimCloseStartDate", DbType.DateTime, _ClaimCloseStartDate);
            db.AddInParameter(dbCommand, "ClaimCloseEndDate", DbType.DateTime, _ClaimCloseEndDate);
            db.AddInParameter(dbCommand, "DOICriteria", DbType.String, _DOICriteria);
            db.AddInParameter(dbCommand, "DOIStart", DbType.DateTime, _DOIStart);
            db.AddInParameter(dbCommand, "DOIEnd", DbType.DateTime, _DOIEnd);
            db.AddInParameter(dbCommand, "ClaimReserveCriteria", DbType.String, _ClaimReserveCriteria);
            db.AddInParameter(dbCommand, "ClaimReserveStartDate", DbType.DateTime, _ClaimReserveStartDate);
            db.AddInParameter(dbCommand, "ClaimReserveEndDate", DbType.DateTime, _ClaimReserveEndDate);

            db.AddInParameter(dbCommand, "MPCriteria", DbType.String, _MPCriteria);
            db.AddInParameter(dbCommand, "MPStartAmount", DbType.Decimal, _MPStartAmount);
            db.AddInParameter(dbCommand, "MPEndAmount", DbType.Decimal, _MPEndAmount);

            db.AddInParameter(dbCommand, "TCompCriteria", DbType.String, _TCompCriteria);
            db.AddInParameter(dbCommand, "TCompStartAmount", DbType.Decimal, _TCompStartAmount);
            db.AddInParameter(dbCommand, "TCompEndAmount", DbType.Decimal, _TCompEndAmount);

            db.AddInParameter(dbCommand, "TReserveCriteria", DbType.String, _TReserveCriteria);
            db.AddInParameter(dbCommand, "TReserveStartAmount", DbType.Decimal, _TReserveStartAmount);
            db.AddInParameter(dbCommand, "TReserveEndAmount", DbType.Decimal, _TReserveEndAmount);

            db.AddInParameter(dbCommand, "UCostCriteria", DbType.String, _UCostCriteria);
            db.AddInParameter(dbCommand, "UCostStartAmount", DbType.Decimal, _UCostStartAmount);
            db.AddInParameter(dbCommand, "UCostEndAmount", DbType.Decimal, _UCostEndAmount);

            db.AddInParameter(dbCommand, "LMVCriteria", DbType.String, _LMVCriteria);
            db.AddInParameter(dbCommand, "LMVStartAmount", DbType.Decimal, _LMVStartAmount);
            db.AddInParameter(dbCommand, "LMVEndAmount", DbType.Decimal, _LMVEndAmount);


            db.AddInParameter(dbCommand, "HCPCriteria", DbType.String, _HCPCriteria);
            db.AddInParameter(dbCommand, "HCPStartAmount", DbType.Decimal, _HCPStartAmount);
            db.AddInParameter(dbCommand, "HCPEndAmount", DbType.Decimal, _HCPEndAmount);

            db.AddInParameter(dbCommand, "HCRCriteria", DbType.String, _HCRCriteria);
            db.AddInParameter(dbCommand, "HCRStartAmount", DbType.Decimal, _HCRStartAmount);
            db.AddInParameter(dbCommand, "HCREndAmount", DbType.Decimal, _HCREndAmount);

            db.AddInParameter(dbCommand, "SColledtedCriteria", DbType.String, _SColledtedCriteria);
            db.AddInParameter(dbCommand, "SColledtedStartAmount", DbType.Decimal, _SColledtedStartAmount);
            db.AddInParameter(dbCommand, "SColledtedEndAmount", DbType.Decimal, _SColledtedEndAmount);

            db.AddInParameter(dbCommand, "TChargedCriteria", DbType.String, _TChargedCriteria);
            db.AddInParameter(dbCommand, "TChargedStartAmount", DbType.Decimal, _TChargedStartAmount);
            db.AddInParameter(dbCommand, "TChargedEndAmount ", DbType.Decimal, _TChargedEndAmount);

            db.AddInParameter(dbCommand, "TTotalPaidCriteria", DbType.String, _TTotalPaidCriteria);
            db.AddInParameter(dbCommand, "TTotalPaidStartAmount", DbType.Decimal, _TTotalPaidStartAmount);
            db.AddInParameter(dbCommand, "TTotalPaidEndAmount ", DbType.Decimal, _TTotalPaidEndAmount);

            db.AddInParameter(dbCommand, "Location", DbType.String, _Location);
            db.AddInParameter(dbCommand, "Status", DbType.String, _OStatus);
            db.AddInParameter(dbCommand, "OutputFields", DbType.String, _OutputFields);
            db.AddInParameter(dbCommand, "SortFields ", DbType.String, _SortFields);
            

            
            return db.ExecuteDataSet(dbCommand);
        }


        #endregion
    }
}
