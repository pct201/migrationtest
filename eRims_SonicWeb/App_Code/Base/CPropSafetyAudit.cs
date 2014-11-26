#region Includes
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

    [Serializable]
    public abstract class CPropSafetyAudit
    {

        #region Constructor
        public CPropSafetyAudit()
        {
            this._pK_Safety_Audit = 0;
            this._fK_Property_COPE = 0;
            this._date_Of_Audit = DateTime.Now;
            this._leader_Name = string.Empty;
            this._general_Safety_Actual =0;
            this._general_Safety_Maximum = 0;
            this._general_Safety_Percent =0;
            this._housekeeping_Actual = 0;
            this._housekeeping_Maximum = 0;
            this._housekeeping_Percent =0;
            this._ergonomics_Actual = 0;
            this._ergonomics_Maximum = 0;
            this._ergonomics_Percent = 0;
            this._eAP_Actual =0;
            this._eAP_Maximum =0;
            this._eAP_Percent =0;
            this._hazardous_Materials_Actual =0;
            this._hazardous_Materials_Maximum =0;
            this._hazardous_Materials_Percent = 0;
            this._fire_Electrical_Actual = 0;
            this._fire_Electrical_Maximum = 0;
            this._fire_Electrical_Percent = 0;
            this._vehicle_Safety_Actual =0;
            this._vehicle_Safety_Maximum = 0;
            this._vehicle_Safety_Percent = 0;
            this._safety_Culture_Actual = 0;
            this._safety_Culture_Maximum = 0;
            this._safety_Culture_Percent = 0;
            this._physical_Security_Actual = 0;
            this._physical_Security_Maximum = 0;
            this._physical_Security_Percent = 0;
            this._network_Operations_Actual = 0;
            this._network_Operations_Maximum = 0;
            this._network_Operations_Percent = 0;
            this._pPE_Actual = 0;
            this._pPE_Maximum = 0;
            this._pPE_Percent = 0;
            this._hand_Tool_Eqiupment_Actual = 0;
            this._hand_Tool_Eqiupment_Maximum =0;
            this._hand_Tool_Eqiupment_Percent = 0;
            this._battery_Room_Actual = 0;
            this._battery_Room_Maximum = 0;
            this._battery_Room_Percent = 0;
            this._special_HLE_Actual = 0;
            this._special_HLE_Maximum = 0;
            this._special_HLE_Percent = 0;
            this._excavations_Actual = 0;
            this._excavations_Maximum = 0;
            this._excavations_Percent = 0;
            this._fall_Protection_Actual =0;
            this._fall_Protection_Maximum = 0;
            this._fall_Protection_Percent = 0;
            this._confined_Space_Actual = 0;
            this._confined_Space_Maximum = 0;
            this._confined_Space_Percent = 0;
            this._total_Actual = 0;
            this._total_Maximum = 0;
            this._total_Percent = 0;
            this._updated_By = 0;
            this._update_Date = DateTime.Now;
        }
        #endregion

        #region Private Variables
        private System.Int32 _pK_Safety_Audit;
        private System.Decimal _fK_Property_COPE;
        private System.DateTime? _date_Of_Audit;
        private System.String _leader_Name;
        private System.Decimal? _general_Safety_Actual;
        private System.Decimal? _general_Safety_Maximum;
        private System.Decimal? _general_Safety_Percent;
        private System.Decimal? _housekeeping_Actual;
        private System.Decimal? _housekeeping_Maximum;
        private System.Decimal? _housekeeping_Percent;
        private System.Decimal? _ergonomics_Actual;
        private System.Decimal? _ergonomics_Maximum;
        private System.Decimal? _ergonomics_Percent;
        private System.Decimal? _eAP_Actual;
        private System.Decimal? _eAP_Maximum;
        private System.Decimal? _eAP_Percent;
        private System.Decimal? _hazardous_Materials_Actual;
        private System.Decimal? _hazardous_Materials_Maximum;
        private System.Decimal? _hazardous_Materials_Percent;
        private System.Decimal? _fire_Electrical_Actual;
        private System.Decimal? _fire_Electrical_Maximum;
        private System.Decimal? _fire_Electrical_Percent;
        private System.Decimal? _vehicle_Safety_Actual;
        private System.Decimal? _vehicle_Safety_Maximum;
        private System.Decimal? _vehicle_Safety_Percent;
        private System.Decimal? _safety_Culture_Actual;
        private System.Decimal? _safety_Culture_Maximum;
        private System.Decimal? _safety_Culture_Percent;
        private System.Decimal? _physical_Security_Actual;
        private System.Decimal? _physical_Security_Maximum;
        private System.Decimal? _physical_Security_Percent;
        private System.Decimal? _network_Operations_Actual;
        private System.Decimal? _network_Operations_Maximum;
        private System.Decimal? _network_Operations_Percent;
        private System.Decimal? _pPE_Actual;
        private System.Decimal? _pPE_Maximum;
        private System.Decimal? _pPE_Percent;
        private System.Decimal? _hand_Tool_Eqiupment_Actual;
        private System.Decimal? _hand_Tool_Eqiupment_Maximum;
        private System.Decimal? _hand_Tool_Eqiupment_Percent;
        private System.Decimal? _battery_Room_Actual;
        private System.Decimal? _battery_Room_Maximum;
        private System.Decimal? _battery_Room_Percent;
        private System.Decimal? _special_HLE_Actual;
        private System.Decimal? _special_HLE_Maximum;
        private System.Decimal? _special_HLE_Percent;
        private System.Decimal? _excavations_Actual;
        private System.Decimal? _excavations_Maximum;
        private System.Decimal? _excavations_Percent;
        private System.Decimal? _fall_Protection_Actual;
        private System.Decimal? _fall_Protection_Maximum;
        private System.Decimal? _fall_Protection_Percent;
        private System.Decimal? _confined_Space_Actual;
        private System.Decimal? _confined_Space_Maximum;
        private System.Decimal? _confined_Space_Percent;
        private System.Decimal? _total_Actual;
        private System.Decimal? _total_Maximum;
        private System.Decimal? _total_Percent;
        private System.Decimal _updated_By;
        private System.DateTime _update_Date;
        #endregion

        #region Public Properties
        public System.Int32 PK_Safety_Audit
        {
            get { return _pK_Safety_Audit; }
            set { _pK_Safety_Audit = value; }
        }

        public System.Decimal FK_Property_COPE
        {
            get { return _fK_Property_COPE; }
            set { _fK_Property_COPE = value; }
        }

        public System.DateTime? Date_Of_Audit
        {
            get { return _date_Of_Audit; }
            set { _date_Of_Audit = value; }
        }

        public System.String Leader_Name
        {
            get { return _leader_Name; }
            set { _leader_Name = value; }
        }

        public System.Decimal? General_Safety_Actual
        {
            get { return _general_Safety_Actual; }
            set { _general_Safety_Actual = value; }
        }

        public System.Decimal? General_Safety_Maximum
        {
            get { return _general_Safety_Maximum; }
            set { _general_Safety_Maximum = value; }
        }

        public System.Decimal? General_Safety_Percent
        {
            get { return _general_Safety_Percent; }
            set { _general_Safety_Percent = value; }
        }

        public System.Decimal? Housekeeping_Actual
        {
            get { return _housekeeping_Actual; }
            set { _housekeeping_Actual = value; }
        }

        public System.Decimal? Housekeeping_Maximum
        {
            get { return _housekeeping_Maximum; }
            set { _housekeeping_Maximum = value; }
        }

        public System.Decimal? Housekeeping_Percent
        {
            get { return _housekeeping_Percent; }
            set { _housekeeping_Percent = value; }
        }

        public System.Decimal? Ergonomics_Actual
        {
            get { return _ergonomics_Actual; }
            set { _ergonomics_Actual = value; }
        }

        public System.Decimal? Ergonomics_Maximum
        {
            get { return _ergonomics_Maximum; }
            set { _ergonomics_Maximum = value; }
        }

        public System.Decimal? Ergonomics_Percent
        {
            get { return _ergonomics_Percent; }
            set { _ergonomics_Percent = value; }
        }

        public System.Decimal? EAP_Actual
        {
            get { return _eAP_Actual; }
            set { _eAP_Actual = value; }
        }

        public System.Decimal? EAP_Maximum
        {
            get { return _eAP_Maximum; }
            set { _eAP_Maximum = value; }
        }

        public System.Decimal? EAP_Percent
        {
            get { return _eAP_Percent; }
            set { _eAP_Percent = value; }
        }

        public System.Decimal? Hazardous_Materials_Actual
        {
            get { return _hazardous_Materials_Actual; }
            set { _hazardous_Materials_Actual = value; }
        }

        public System.Decimal? Hazardous_Materials_Maximum
        {
            get { return _hazardous_Materials_Maximum; }
            set { _hazardous_Materials_Maximum = value; }
        }

        public System.Decimal? Hazardous_Materials_Percent
        {
            get { return _hazardous_Materials_Percent; }
            set { _hazardous_Materials_Percent = value; }
        }

        public System.Decimal? Fire_Electrical_Actual
        {
            get { return _fire_Electrical_Actual; }
            set { _fire_Electrical_Actual = value; }
        }

        public System.Decimal? Fire_Electrical_Maximum
        {
            get { return _fire_Electrical_Maximum; }
            set { _fire_Electrical_Maximum = value; }
        }

        public System.Decimal? Fire_Electrical_Percent
        {
            get { return _fire_Electrical_Percent; }
            set { _fire_Electrical_Percent = value; }
        }

        public System.Decimal? Vehicle_Safety_Actual
        {
            get { return _vehicle_Safety_Actual; }
            set { _vehicle_Safety_Actual = value; }
        }

        public System.Decimal? Vehicle_Safety_Maximum
        {
            get { return _vehicle_Safety_Maximum; }
            set { _vehicle_Safety_Maximum = value; }
        }

        public System.Decimal? Vehicle_Safety_Percent
        {
            get { return _vehicle_Safety_Percent; }
            set { _vehicle_Safety_Percent = value; }
        }

        public System.Decimal? Safety_Culture_Actual
        {
            get { return _safety_Culture_Actual; }
            set { _safety_Culture_Actual = value; }
        }

        public System.Decimal? Safety_Culture_Maximum
        {
            get { return _safety_Culture_Maximum; }
            set { _safety_Culture_Maximum = value; }
        }

        public System.Decimal? Safety_Culture_Percent
        {
            get { return _safety_Culture_Percent; }
            set { _safety_Culture_Percent = value; }
        }

        public System.Decimal? Physical_Security_Actual
        {
            get { return _physical_Security_Actual; }
            set { _physical_Security_Actual = value; }
        }

        public System.Decimal? Physical_Security_Maximum
        {
            get { return _physical_Security_Maximum; }
            set { _physical_Security_Maximum = value; }
        }

        public System.Decimal? Physical_Security_Percent
        {
            get { return _physical_Security_Percent; }
            set { _physical_Security_Percent = value; }
        }

        public System.Decimal? Network_Operations_Actual
        {
            get { return _network_Operations_Actual; }
            set { _network_Operations_Actual = value; }
        }

        public System.Decimal? Network_Operations_Maximum
        {
            get { return _network_Operations_Maximum; }
            set { _network_Operations_Maximum = value; }
        }

        public System.Decimal? Network_Operations_Percent
        {
            get { return _network_Operations_Percent; }
            set { _network_Operations_Percent = value; }
        }

        public System.Decimal? PPE_Actual
        {
            get { return _pPE_Actual; }
            set { _pPE_Actual = value; }
        }

        public System.Decimal? PPE_Maximum
        {
            get { return _pPE_Maximum; }
            set { _pPE_Maximum = value; }
        }

        public System.Decimal? PPE_Percent
        {
            get { return _pPE_Percent; }
            set { _pPE_Percent = value; }
        }

        public System.Decimal? Hand_Tool_Eqiupment_Actual
        {
            get { return _hand_Tool_Eqiupment_Actual; }
            set { _hand_Tool_Eqiupment_Actual = value; }
        }

        public System.Decimal? Hand_Tool_Eqiupment_Maximum
        {
            get { return _hand_Tool_Eqiupment_Maximum; }
            set { _hand_Tool_Eqiupment_Maximum = value; }
        }

        public System.Decimal? Hand_Tool_Eqiupment_Percent
        {
            get { return _hand_Tool_Eqiupment_Percent; }
            set { _hand_Tool_Eqiupment_Percent = value; }
        }

        public System.Decimal? Battery_Room_Actual
        {
            get { return _battery_Room_Actual; }
            set { _battery_Room_Actual = value; }
        }

        public System.Decimal? Battery_Room_Maximum
        {
            get { return _battery_Room_Maximum; }
            set { _battery_Room_Maximum = value; }
        }

        public System.Decimal? Battery_Room_Percent
        {
            get { return _battery_Room_Percent; }
            set { _battery_Room_Percent = value; }
        }

        public System.Decimal? Special_HLE_Actual
        {
            get { return _special_HLE_Actual; }
            set { _special_HLE_Actual = value; }
        }

        public System.Decimal? Special_HLE_Maximum
        {
            get { return _special_HLE_Maximum; }
            set { _special_HLE_Maximum = value; }
        }

        public System.Decimal? Special_HLE_Percent
        {
            get { return _special_HLE_Percent; }
            set { _special_HLE_Percent = value; }
        }

        public System.Decimal? Excavations_Actual
        {
            get { return _excavations_Actual; }
            set { _excavations_Actual = value; }
        }

        public System.Decimal? Excavations_Maximum
        {
            get { return _excavations_Maximum; }
            set { _excavations_Maximum = value; }
        }

        public System.Decimal? Excavations_Percent
        {
            get { return _excavations_Percent; }
            set { _excavations_Percent = value; }
        }

        public System.Decimal? Fall_Protection_Actual
        {
            get { return _fall_Protection_Actual; }
            set { _fall_Protection_Actual = value; }
        }

        public System.Decimal? Fall_Protection_Maximum
        {
            get { return _fall_Protection_Maximum; }
            set { _fall_Protection_Maximum = value; }
        }

        public System.Decimal? Fall_Protection_Percent
        {
            get { return _fall_Protection_Percent; }
            set { _fall_Protection_Percent = value; }
        }

        public System.Decimal? Confined_Space_Actual
        {
            get { return _confined_Space_Actual; }
            set { _confined_Space_Actual = value; }
        }

        public System.Decimal? Confined_Space_Maximum
        {
            get { return _confined_Space_Maximum; }
            set { _confined_Space_Maximum = value; }
        }

        public System.Decimal? Confined_Space_Percent
        {
            get { return _confined_Space_Percent; }
            set { _confined_Space_Percent = value; }
        }

        public System.Decimal? Total_Actual
        {
            get { return _total_Actual; }
            set { _total_Actual = value; }
        }

        public System.Decimal? Total_Maximum
        {
            get { return _total_Maximum; }
            set { _total_Maximum = value; }
        }

        public System.Decimal? Total_Percent
        {
            get { return _total_Percent; }
            set { _total_Percent = value; }
        }

        public System.Decimal Updated_By
        {
            get { return _updated_By; }
            set { _updated_By = value; }
        }

        public System.DateTime Update_Date
        {
            get { return _update_Date; }
            set { _update_Date = value; }
        }

        #endregion

        #region Abstract Methods
        public abstract DataSet GetAll();
        public abstract DataSet PropSafetyAudit_GetByID(System.Decimal lPK_Safety_Audit);
        public abstract int PropSafetyAudit_InsertUpdate(RIMS_Base.CPropSafetyAudit obj);
        public abstract int PropSafetyAudit__Delete(System.String lPK_Safety_Audit);
        public abstract DataSet PropSafetyAudit_BYCOPEId(System.Decimal PK_COPE_Id);
        #endregion

    }

}
