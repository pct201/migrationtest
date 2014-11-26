using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Exposure_Alarms table.
    /// </summary>
    public sealed class clsExposure_Alarms
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Exposure_Alarms;
        private decimal? _FK_Alarm_Location;
        private decimal? _FK_LU_Alarm_Type;
        private string _Alarm_Number;
        private DateTime? _Alarm_Date;
        private string _Time_Of_Alarm;
        private string _Operator_First_Name;
        private string _Operator_Last_name;
        private string _Camera_Number;
        private string _Camera_Name;
        private decimal? _FK_LU_Camera_Type;
        private string _Description;
        private DateTime? _Photo_Date;
        private decimal? _FK_LU_Action_Type;
        private decimal? _FK_LU_Alarm_Action;
        private decimal? _FK_LU_Alarm_Person;
        private decimal? _FK_LU_Alarm_Vehicle;
        private decimal? _FK_LU_Alarm_Environmental;
        private decimal? _FK_LU_Client_Caused;
        private decimal? _FK_LU_Equipment_Malfunction;
        private string _Other;
        private string _Image_Name;
        private byte? _FalsePositive;
        private string _User_Name;
        private string _Policy_Name;
        private decimal? _FK_Event;
        private string _Priority_Level;
        private string _Camera_ID;
        private string _Subsection_Code;
        private string _Camera_Type_Code;
        private string _License_Type_Code;
        private string _Camera_Description;
        private string _Group_ID;
        private string _Location_Code;
        private string _Building_Number;
        private string _Updated_By;
        private DateTime? _Update_Date;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Exposure_Alarms value.
        /// </summary>
        public decimal? PK_Exposure_Alarms
        {
            get { return _PK_Exposure_Alarms; }
            set { _PK_Exposure_Alarms = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Alarm_Location value.
        /// </summary>
        public decimal? FK_Alarm_Location
        {
            get { return _FK_Alarm_Location; }
            set { _FK_Alarm_Location = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Alarm_Type value.
        /// </summary>
        public decimal? FK_LU_Alarm_Type
        {
            get { return _FK_LU_Alarm_Type; }
            set { _FK_LU_Alarm_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Alarm_Number value.
        /// </summary>
        public string Alarm_Number
        {
            get { return _Alarm_Number; }
            set { _Alarm_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Time_Of_Alarm value.
        /// </summary>
        public DateTime? Alarm_Date
        {
            get { return _Alarm_Date; }
            set { _Alarm_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Time_Of_Alarm value.
        /// </summary>
        public string Time_Of_Alarm
        {
            get { return _Time_Of_Alarm; }
            set { _Time_Of_Alarm = value; }
        }

        /// <summary>
        /// Gets or sets the Operator_First_Name value.
        /// </summary>
        public string Operator_First_Name
        {
            get { return _Operator_First_Name; }
            set { _Operator_First_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Operator_Last_name value.
        /// </summary>
        public string Operator_Last_name
        {
            get { return _Operator_Last_name; }
            set { _Operator_Last_name = value; }
        }

        /// <summary>
        /// Gets or sets the Camera_Number value.
        /// </summary>
        public string Camera_Number
        {
            get { return _Camera_Number; }
            set { _Camera_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Camera_Name value.
        /// </summary>
        public string Camera_Name
        {
            get { return _Camera_Name; }
            set { _Camera_Name = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Camera_Type value.
        /// </summary>
        public decimal? FK_LU_Camera_Type
        {
            get { return _FK_LU_Camera_Type; }
            set { _FK_LU_Camera_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// Gets or sets the Photo_Date value.
        /// </summary>
        public DateTime? Photo_Date
        {
            get { return _Photo_Date; }
            set { _Photo_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Action_Type value.
        /// </summary>
        public decimal? FK_LU_Action_Type
        {
            get { return _FK_LU_Action_Type; }
            set { _FK_LU_Action_Type = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Alarm_Action value.
        /// </summary>
        public decimal? FK_LU_Alarm_Action
        {
            get { return _FK_LU_Alarm_Action; }
            set { _FK_LU_Alarm_Action = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Alarm_Person value.
        /// </summary>
        public decimal? FK_LU_Alarm_Person
        {
            get { return _FK_LU_Alarm_Person; }
            set { _FK_LU_Alarm_Person = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Alarm_Vehicle value.
        /// </summary>
        public decimal? FK_LU_Alarm_Vehicle
        {
            get { return _FK_LU_Alarm_Vehicle; }
            set { _FK_LU_Alarm_Vehicle = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Alarm_Environmental value.
        /// </summary>
        public decimal? FK_LU_Alarm_Environmental
        {
            get { return _FK_LU_Alarm_Environmental; }
            set { _FK_LU_Alarm_Environmental = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Client_Caused value.
        /// </summary>
        public decimal? FK_LU_Client_Caused
        {
            get { return _FK_LU_Client_Caused; }
            set { _FK_LU_Client_Caused = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Equipment_Malfunction value.
        /// </summary>
        public decimal? FK_LU_Equipment_Malfunction
        {
            get { return _FK_LU_Equipment_Malfunction; }
            set { _FK_LU_Equipment_Malfunction = value; }
        }

        /// <summary>
        /// Gets or sets the Other value.
        /// </summary>
        public string Other
        {
            get { return _Other; }
            set { _Other = value; }
        }

        /// <summary>
        /// Gets or sets the Image_Name value.
        /// </summary>
        public string Image_Name
        {
            get { return _Image_Name; }
            set { _Image_Name = value; }
        }

        /// <summary>
        /// Gets or sets the FalsePositive value.
        /// </summary>
        public byte? FalsePositive
        {
            get { return _FalsePositive; }
            set { _FalsePositive = value; }
        }

        /// <summary>
        /// Gets or sets the User_Name value.
        /// </summary>
        public string User_Name
        {
            get { return _User_Name; }
            set { _User_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Policy_Name value.
        /// </summary>
        public string Policy_Name
        {
            get { return _Policy_Name; }
            set { _Policy_Name = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Event value.
        /// </summary>
        public decimal? FK_Event
        {
            get { return _FK_Event; }
            set { _FK_Event = value; }
        }

        /// <summary>
        /// Gets or sets the Priority_Level value.
        /// </summary>
        public string Priority_Level
        {
            get { return _Priority_Level; }
            set { _Priority_Level = value; }
        }

        /// <summary>
        /// Gets or sets the Camera_ID value.
        /// </summary>
        public string Camera_ID
        {
            get { return _Camera_ID; }
            set { _Camera_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Subsection_Code value.
        /// </summary>
        public string Subsection_Code
        {
            get { return _Subsection_Code; }
            set { _Subsection_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Camera_Type_Code value.
        /// </summary>
        public string Camera_Type_Code
        {
            get { return _Camera_Type_Code; }
            set { _Camera_Type_Code = value; }
        }

        /// <summary>
        /// Gets or sets the License_Type_Code value.
        /// </summary>
        public string License_Type_Code
        {
            get { return _License_Type_Code; }
            set { _License_Type_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Camera_Description value.
        /// </summary>
        public string Camera_Description
        {
            get { return _Camera_Description; }
            set { _Camera_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Group_ID value.
        /// </summary>
        public string Group_ID
        {
            get { return _Group_ID; }
            set { _Group_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Location_Code value.
        /// </summary>
        public string Location_Code
        {
            get { return _Location_Code; }
            set { _Location_Code = value; }
        }

        /// <summary>
        /// Gets or sets the Building_Number value.
        /// </summary>
        public string Building_Number
        {
            get { return _Building_Number; }
            set { _Building_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime? Update_Date
        {
            get { return _Update_Date; }
            set { _Update_Date = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsExposure_Alarms class with default value.
        /// </summary>
        public clsExposure_Alarms()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsExposure_Alarms class based on Primary Key.
        /// </summary>
        public clsExposure_Alarms(decimal pK_Exposure_Alarms)
        {
            DataTable dtExposure_Alarms = SelectByPK(pK_Exposure_Alarms).Tables[0];

            if (dtExposure_Alarms.Rows.Count == 1)
            {
                SetValue(dtExposure_Alarms.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsExposure_Alarms class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drExposure_Alarms)
        {
            if (drExposure_Alarms["PK_Exposure_Alarms"] == DBNull.Value)
                this._PK_Exposure_Alarms = null;
            else
                this._PK_Exposure_Alarms = (decimal?)drExposure_Alarms["PK_Exposure_Alarms"];

            if (drExposure_Alarms["FK_Alarm_Location"] == DBNull.Value)
                this._FK_Alarm_Location = null;
            else
                this._FK_Alarm_Location = (decimal?)drExposure_Alarms["FK_Alarm_Location"];

            if (drExposure_Alarms["FK_LU_Alarm_Type"] == DBNull.Value)
                this._FK_LU_Alarm_Type = null;
            else
                this._FK_LU_Alarm_Type = (decimal?)drExposure_Alarms["FK_LU_Alarm_Type"];

            if (drExposure_Alarms["Alarm_Number"] == DBNull.Value)
                this._Alarm_Number = null;
            else
                this._Alarm_Number = (string)drExposure_Alarms["Alarm_Number"];

            if (drExposure_Alarms["Alarm_Date"] == DBNull.Value)
                this._Alarm_Date = null;
            else
                this._Alarm_Date = (DateTime)drExposure_Alarms["Alarm_Date"];

            if (drExposure_Alarms["Time_Of_Alarm"] == DBNull.Value)
                this._Time_Of_Alarm = null;
            else
                this._Time_Of_Alarm = (string)drExposure_Alarms["Time_Of_Alarm"];

            if (drExposure_Alarms["Operator_First_Name"] == DBNull.Value)
                this._Operator_First_Name = null;
            else
                this._Operator_First_Name = (string)drExposure_Alarms["Operator_First_Name"];

            if (drExposure_Alarms["Operator_Last_name"] == DBNull.Value)
                this._Operator_Last_name = null;
            else
                this._Operator_Last_name = (string)drExposure_Alarms["Operator_Last_name"];

            if (drExposure_Alarms["Camera_Number"] == DBNull.Value)
                this._Camera_Number = null;
            else
                this._Camera_Number = (string)drExposure_Alarms["Camera_Number"];

            if (drExposure_Alarms["Camera_Name"] == DBNull.Value)
                this._Camera_Name = null;
            else
                this._Camera_Name = (string)drExposure_Alarms["Camera_Name"];

            if (drExposure_Alarms["FK_LU_Camera_Type"] == DBNull.Value)
                this._FK_LU_Camera_Type = null;
            else
                this._FK_LU_Camera_Type = (decimal?)drExposure_Alarms["FK_LU_Camera_Type"];

            if (drExposure_Alarms["Description"] == DBNull.Value)
                this._Description = null;
            else
                this._Description = (string)drExposure_Alarms["Description"];

            if (drExposure_Alarms["Photo_Date"] == DBNull.Value)
                this._Photo_Date = null;
            else
                this._Photo_Date = (DateTime?)drExposure_Alarms["Photo_Date"];

            if (drExposure_Alarms["FK_LU_Action_Type"] == DBNull.Value)
                this._FK_LU_Action_Type = null;
            else
                this._FK_LU_Action_Type = (decimal?)drExposure_Alarms["FK_LU_Action_Type"];

            if (drExposure_Alarms["FK_LU_Alarm_Action"] == DBNull.Value)
                this._FK_LU_Alarm_Action = null;
            else
                this._FK_LU_Alarm_Action = (decimal?)drExposure_Alarms["FK_LU_Alarm_Action"];

            if (drExposure_Alarms["FK_LU_Alarm_Person"] == DBNull.Value)
                this._FK_LU_Alarm_Person = null;
            else
                this._FK_LU_Alarm_Person = (decimal?)drExposure_Alarms["FK_LU_Alarm_Person"];

            if (drExposure_Alarms["FK_LU_Alarm_Vehicle"] == DBNull.Value)
                this._FK_LU_Alarm_Vehicle = null;
            else
                this._FK_LU_Alarm_Vehicle = (decimal?)drExposure_Alarms["FK_LU_Alarm_Vehicle"];

            if (drExposure_Alarms["FK_LU_Alarm_Environmental"] == DBNull.Value)
                this._FK_LU_Alarm_Environmental = null;
            else
                this._FK_LU_Alarm_Environmental = (decimal?)drExposure_Alarms["FK_LU_Alarm_Environmental"];

            if (drExposure_Alarms["FK_LU_Client_Caused"] == DBNull.Value)
                this._FK_LU_Client_Caused = null;
            else
                this._FK_LU_Client_Caused = (decimal?)drExposure_Alarms["FK_LU_Client_Caused"];

            if (drExposure_Alarms["FK_LU_Equipment_Malfunction"] == DBNull.Value)
                this._FK_LU_Equipment_Malfunction = null;
            else
                this._FK_LU_Equipment_Malfunction = (decimal?)drExposure_Alarms["FK_LU_Equipment_Malfunction"];

            if (drExposure_Alarms["Other"] == DBNull.Value)
                this._Other = null;
            else
                this._Other = (string)drExposure_Alarms["Other"];

            if (drExposure_Alarms["Image_Name"] == DBNull.Value)
                this._Image_Name = null;
            else
                this._Image_Name = (string)drExposure_Alarms["Image_Name"];

            if (drExposure_Alarms["FalsePositive"] == DBNull.Value)
                this._FalsePositive = null;
            else
                this._FalsePositive = (byte?)drExposure_Alarms["FalsePositive"];

            if (drExposure_Alarms["User_Name"] == DBNull.Value)
                this._User_Name = null;
            else
                this._User_Name = (string)drExposure_Alarms["User_Name"];

            if (drExposure_Alarms["Policy_Name"] == DBNull.Value)
                this._Policy_Name = null;
            else
                this._Policy_Name = (string)drExposure_Alarms["Policy_Name"];

            if (drExposure_Alarms["FK_Event"] == DBNull.Value)
                this._FK_Event = null;
            else
                this._FK_Event = (decimal?)drExposure_Alarms["FK_Event"];

            if (drExposure_Alarms["Priority_Level"] == DBNull.Value)
                this._Priority_Level = null;
            else
                this._Priority_Level = (string)drExposure_Alarms["Priority_Level"];

            if (drExposure_Alarms["Camera_ID"] == DBNull.Value)
                this._Camera_ID = null;
            else
                this._Camera_ID = (string)drExposure_Alarms["Camera_ID"];

            if (drExposure_Alarms["Subsection_Code"] == DBNull.Value)
                this._Subsection_Code = null;
            else
                this._Subsection_Code = (string)drExposure_Alarms["Subsection_Code"];

            if (drExposure_Alarms["Camera_Type_Code"] == DBNull.Value)
                this._Camera_Type_Code = null;
            else
                this._Camera_Type_Code = (string)drExposure_Alarms["Camera_Type_Code"];

            if (drExposure_Alarms["License_Type_Code"] == DBNull.Value)
                this._License_Type_Code = null;
            else
                this._License_Type_Code = (string)drExposure_Alarms["License_Type_Code"];

            if (drExposure_Alarms["Camera_Description"] == DBNull.Value)
                this._Camera_Description = null;
            else
                this._Camera_Description = (string)drExposure_Alarms["Camera_Description"];

            if (drExposure_Alarms["Group_ID"] == DBNull.Value)
                this._Group_ID = null;
            else
                this._Group_ID = (string)drExposure_Alarms["Group_ID"];

            if (drExposure_Alarms["Location_Code"] == DBNull.Value)
                this._Location_Code = null;
            else
                this._Location_Code = (string)drExposure_Alarms["Location_Code"];

            if (drExposure_Alarms["Building_Number"] == DBNull.Value)
                this._Building_Number = null;
            else
                this._Building_Number = (string)drExposure_Alarms["Building_Number"];

            if (drExposure_Alarms["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drExposure_Alarms["Updated_By"];

            if (drExposure_Alarms["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drExposure_Alarms["Update_Date"];


        }

        #endregion

        /// <summary>
        /// Inserts a record into the Exposure_Alarms table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Exposure_AlarmsInsert");


            db.AddInParameter(dbCommand, "FK_Alarm_Location", DbType.Decimal, this._FK_Alarm_Location);

            db.AddInParameter(dbCommand, "FK_LU_Alarm_Type", DbType.Decimal, this._FK_LU_Alarm_Type);

            if (string.IsNullOrEmpty(this._Alarm_Number))
                db.AddInParameter(dbCommand, "Alarm_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Alarm_Number", DbType.String, this._Alarm_Number);

            db.AddInParameter(dbCommand, "Alarm_Date", DbType.DateTime, this._Alarm_Date);

            if (string.IsNullOrEmpty(this._Time_Of_Alarm))
                db.AddInParameter(dbCommand, "Time_Of_Alarm", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Time_Of_Alarm", DbType.String, this._Time_Of_Alarm);

            if (string.IsNullOrEmpty(this._Operator_First_Name))
                db.AddInParameter(dbCommand, "Operator_First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Operator_First_Name", DbType.String, this._Operator_First_Name);

            if (string.IsNullOrEmpty(this._Operator_Last_name))
                db.AddInParameter(dbCommand, "Operator_Last_name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Operator_Last_name", DbType.String, this._Operator_Last_name);

            if (string.IsNullOrEmpty(this._Camera_Number))
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, this._Camera_Number);

            if (string.IsNullOrEmpty(this._Camera_Name))
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, this._Camera_Name);

            db.AddInParameter(dbCommand, "FK_LU_Camera_Type", DbType.Decimal, this._FK_LU_Camera_Type);

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            db.AddInParameter(dbCommand, "Photo_Date", DbType.DateTime, this._Photo_Date);

            db.AddInParameter(dbCommand, "FK_LU_Action_Type", DbType.Decimal, this._FK_LU_Action_Type);

            db.AddInParameter(dbCommand, "FK_LU_Alarm_Action", DbType.Decimal, this._FK_LU_Alarm_Action);

            db.AddInParameter(dbCommand, "FK_LU_Alarm_Person", DbType.Decimal, this._FK_LU_Alarm_Person);

            db.AddInParameter(dbCommand, "FK_LU_Alarm_Vehicle", DbType.Decimal, this._FK_LU_Alarm_Vehicle);

            db.AddInParameter(dbCommand, "FK_LU_Alarm_Environmental", DbType.Decimal, this._FK_LU_Alarm_Environmental);

            db.AddInParameter(dbCommand, "FK_LU_Client_Caused", DbType.Decimal, this._FK_LU_Client_Caused);

            db.AddInParameter(dbCommand, "FK_LU_Equipment_Malfunction", DbType.Decimal, this._FK_LU_Equipment_Malfunction);

            if (string.IsNullOrEmpty(this._Other))
                db.AddInParameter(dbCommand, "Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other", DbType.String, this._Other);

            if (string.IsNullOrEmpty(this._Image_Name))
                db.AddInParameter(dbCommand, "Image_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Image_Name", DbType.String, this._Image_Name);

            db.AddInParameter(dbCommand, "FalsePositive", DbType.Byte, this._FalsePositive);

            if (string.IsNullOrEmpty(this._User_Name))
                db.AddInParameter(dbCommand, "User_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "User_Name", DbType.String, this._User_Name);

            if (string.IsNullOrEmpty(this._Policy_Name))
                db.AddInParameter(dbCommand, "Policy_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Policy_Name", DbType.String, this._Policy_Name);

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            if (string.IsNullOrEmpty(this._Priority_Level))
                db.AddInParameter(dbCommand, "Priority_Level", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Priority_Level", DbType.String, this._Priority_Level);

            if (string.IsNullOrEmpty(this._Camera_ID))
                db.AddInParameter(dbCommand, "Camera_ID", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_ID", DbType.String, this._Camera_ID);

            if (string.IsNullOrEmpty(this._Subsection_Code))
                db.AddInParameter(dbCommand, "Subsection_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subsection_Code", DbType.String, this._Subsection_Code);

            if (string.IsNullOrEmpty(this._Camera_Type_Code))
                db.AddInParameter(dbCommand, "Camera_Type_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Type_Code", DbType.String, this._Camera_Type_Code);

            if (string.IsNullOrEmpty(this._License_Type_Code))
                db.AddInParameter(dbCommand, "License_Type_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "License_Type_Code", DbType.String, this._License_Type_Code);

            if (string.IsNullOrEmpty(this._Camera_Description))
                db.AddInParameter(dbCommand, "Camera_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Description", DbType.String, this._Camera_Description);

            if (string.IsNullOrEmpty(this._Group_ID))
                db.AddInParameter(dbCommand, "Group_ID", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Group_ID", DbType.String, this._Group_ID);

            if (string.IsNullOrEmpty(this._Location_Code))
                db.AddInParameter(dbCommand, "Location_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location_Code", DbType.String, this._Location_Code);

            if (string.IsNullOrEmpty(this._Building_Number))
                db.AddInParameter(dbCommand, "Building_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Building_Number", DbType.String, this._Building_Number);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Exposure_Alarms table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Exposure_Alarms)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Exposure_AlarmsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Exposure_Alarms", DbType.Decimal, pK_Exposure_Alarms);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Exposure_Alarms table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Exposure_AlarmsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Exposure_Alarms table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Exposure_AlarmsUpdate");


            db.AddInParameter(dbCommand, "PK_Exposure_Alarms", DbType.Decimal, this._PK_Exposure_Alarms);

            db.AddInParameter(dbCommand, "FK_Alarm_Location", DbType.Decimal, this._FK_Alarm_Location);

            db.AddInParameter(dbCommand, "FK_LU_Alarm_Type", DbType.Decimal, this._FK_LU_Alarm_Type);

            if (string.IsNullOrEmpty(this._Alarm_Number))
                db.AddInParameter(dbCommand, "Alarm_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Alarm_Number", DbType.String, this._Alarm_Number);

            db.AddInParameter(dbCommand, "Alarm_Date", DbType.DateTime, this._Alarm_Date);

            if (string.IsNullOrEmpty(this._Time_Of_Alarm))
                db.AddInParameter(dbCommand, "Time_Of_Alarm", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Time_Of_Alarm", DbType.String, this._Time_Of_Alarm);

            if (string.IsNullOrEmpty(this._Operator_First_Name))
                db.AddInParameter(dbCommand, "Operator_First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Operator_First_Name", DbType.String, this._Operator_First_Name);

            if (string.IsNullOrEmpty(this._Operator_Last_name))
                db.AddInParameter(dbCommand, "Operator_Last_name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Operator_Last_name", DbType.String, this._Operator_Last_name);

            if (string.IsNullOrEmpty(this._Camera_Number))
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, this._Camera_Number);

            if (string.IsNullOrEmpty(this._Camera_Name))
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, this._Camera_Name);

            db.AddInParameter(dbCommand, "FK_LU_Camera_Type", DbType.Decimal, this._FK_LU_Camera_Type);

            if (string.IsNullOrEmpty(this._Description))
                db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);

            db.AddInParameter(dbCommand, "Photo_Date", DbType.DateTime, this._Photo_Date);

            db.AddInParameter(dbCommand, "FK_LU_Action_Type", DbType.Decimal, this._FK_LU_Action_Type);

            db.AddInParameter(dbCommand, "FK_LU_Alarm_Action", DbType.Decimal, this._FK_LU_Alarm_Action);

            db.AddInParameter(dbCommand, "FK_LU_Alarm_Person", DbType.Decimal, this._FK_LU_Alarm_Person);

            db.AddInParameter(dbCommand, "FK_LU_Alarm_Vehicle", DbType.Decimal, this._FK_LU_Alarm_Vehicle);

            db.AddInParameter(dbCommand, "FK_LU_Alarm_Environmental", DbType.Decimal, this._FK_LU_Alarm_Environmental);

            db.AddInParameter(dbCommand, "FK_LU_Client_Caused", DbType.Decimal, this._FK_LU_Client_Caused);

            db.AddInParameter(dbCommand, "FK_LU_Equipment_Malfunction", DbType.Decimal, this._FK_LU_Equipment_Malfunction);

            if (string.IsNullOrEmpty(this._Other))
                db.AddInParameter(dbCommand, "Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other", DbType.String, this._Other);

            if (string.IsNullOrEmpty(this._Image_Name))
                db.AddInParameter(dbCommand, "Image_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Image_Name", DbType.String, this._Image_Name);

            db.AddInParameter(dbCommand, "FalsePositive", DbType.Byte, this._FalsePositive);

            if (string.IsNullOrEmpty(this._User_Name))
                db.AddInParameter(dbCommand, "User_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "User_Name", DbType.String, this._User_Name);

            if (string.IsNullOrEmpty(this._Policy_Name))
                db.AddInParameter(dbCommand, "Policy_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Policy_Name", DbType.String, this._Policy_Name);

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, this._FK_Event);

            if (string.IsNullOrEmpty(this._Priority_Level))
                db.AddInParameter(dbCommand, "Priority_Level", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Priority_Level", DbType.String, this._Priority_Level);

            if (string.IsNullOrEmpty(this._Camera_ID))
                db.AddInParameter(dbCommand, "Camera_ID", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_ID", DbType.String, this._Camera_ID);

            if (string.IsNullOrEmpty(this._Subsection_Code))
                db.AddInParameter(dbCommand, "Subsection_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Subsection_Code", DbType.String, this._Subsection_Code);

            if (string.IsNullOrEmpty(this._Camera_Type_Code))
                db.AddInParameter(dbCommand, "Camera_Type_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Type_Code", DbType.String, this._Camera_Type_Code);

            if (string.IsNullOrEmpty(this._License_Type_Code))
                db.AddInParameter(dbCommand, "License_Type_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "License_Type_Code", DbType.String, this._License_Type_Code);

            if (string.IsNullOrEmpty(this._Camera_Description))
                db.AddInParameter(dbCommand, "Camera_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Description", DbType.String, this._Camera_Description);

            if (string.IsNullOrEmpty(this._Group_ID))
                db.AddInParameter(dbCommand, "Group_ID", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Group_ID", DbType.String, this._Group_ID);

            if (string.IsNullOrEmpty(this._Location_Code))
                db.AddInParameter(dbCommand, "Location_Code", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Location_Code", DbType.String, this._Location_Code);

            if (string.IsNullOrEmpty(this._Building_Number))
                db.AddInParameter(dbCommand, "Building_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Building_Number", DbType.String, this._Building_Number);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Exposure_Alarms table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Exposure_Alarms)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Exposure_AlarmsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Exposure_Alarms", DbType.Decimal, pK_Exposure_Alarms);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Alarm Search
        /// </summary>
        /// <param name="Alarm_Number"></param>
        /// <param name="Camera_Number"></param>
        /// <param name="Country"></param>
        /// <param name="City"></param>
        /// <param name="Operator"></param>
        /// <param name="FK_LU_State"></param>
        /// <param name="FK_LU_Location"></param>
        /// <param name="FK_LU_Camera_Type"></param>
        /// <param name="FK_LU_Company"></param>
        /// <param name="FK_LU_Alarm_Type"></param>
        /// <param name="Alarm_Time_From"></param>
        /// <param name="Alarm_Time_To"></param>
        /// <param name="Photo_Date_From"></param>
        /// <param name="Photo_Date_To"></param>
        /// <param name="strOrderBy"></param>
        /// <param name="strOrder"></param>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public static DataSet AlarmSearch(string Alarm_Number, string Camera_Number, string Country, string City, string Operator, decimal? FK_LU_State,
            decimal? FK_LU_Location, decimal? FK_LU_Camera_Type, decimal? FK_LU_Company, decimal? FK_LU_Alarm_Type, string Alarm_Time_From, string Alarm_Time_To,
            DateTime? Photo_Date_From, DateTime? Photo_Date_To, string strOrderBy, string strOrder, int intPageNo, int intPageSize, decimal? FK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AlarmSearch");
            db.AddInParameter(dbCommand, "Alarm_Number", DbType.String, Alarm_Number);
            db.AddInParameter(dbCommand, "Camera_Number", DbType.String, Camera_Number);
            db.AddInParameter(dbCommand, "Country", DbType.String, Country);
            db.AddInParameter(dbCommand, "City", DbType.String, City);
            db.AddInParameter(dbCommand, "Operator", DbType.String, Operator);
            db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, FK_LU_State);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "FK_LU_Camera_Type", DbType.Decimal, FK_LU_Camera_Type);
            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);
            db.AddInParameter(dbCommand, "FK_LU_Company", DbType.Decimal, FK_LU_Company);
            db.AddInParameter(dbCommand, "FK_LU_Alarm_Type", DbType.Decimal, FK_LU_Alarm_Type);
            db.AddInParameter(dbCommand, "Alarm_Time_From", DbType.String, Alarm_Time_From);
            db.AddInParameter(dbCommand, "Alarm_Time_To", DbType.String, Alarm_Time_To);
            db.AddInParameter(dbCommand, "Photo_Date_From", DbType.DateTime, Photo_Date_From);
            db.AddInParameter(dbCommand, "Photo_Date_To", DbType.DateTime, Photo_Date_To);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetAlarmForAssociation()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetAlarmForAssociation");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Check if Alarm is exist or not for Event
        /// </summary>
        /// <param name="pK_Event"></param>
        /// <returns></returns>
        public static DataSet IsValidToDelete(decimal pK_ExposureAlarm)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ALARM_IsValidToDelete");
            db.AddInParameter(dbCommand, "PK_Exposure_Alarms", DbType.Decimal, pK_ExposureAlarm);

            db.ExecuteNonQuery(dbCommand);
            return db.ExecuteDataSet(dbCommand);
            //return Convert.ToBoolean(dbCommand.Parameters["@bValid"].Value);
        }
    }
}
