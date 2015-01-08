using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Event table.
    /// </summary>
    public sealed class clsEvent
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Event;
        private string _Event_Number;
        private decimal? _FK_LU_Event_Type;
        private DateTime? _Event_Report_Date;
        private DateTime? _Event_Occurence_Date;
        private DateTime? _Investigation_Report_Date;
        private DateTime? _Date_Sent;
        private string _Company;
        private decimal? _FK_LU_Location;
        private string _Company_Address_1;
        private string _Company_Address_2;
        private string _Company_City;
        private decimal? _FK_LU_State;
        private string _Company_ZIP;
        private string _Company_County;
        private string _Company_Contact_First_Name;
        private string _Company_Contact_Middle_name;
        private string _Company_Contact_Last_Name;
        private string _Company_Contact_Phone;
        private string _Company_Contact_Email;
        private string _Company_Contact_Fax;
        private string _Vehicle_Number;
        private string _VIN;
        private string _Make;
        private string _Model;
        private string _Year;
        private string _Company_Titled;
        private string _License_Tag;
        private decimal? _FK_LU_State_Registered;
        private string _Police_Dept_Name;
        private string _Police_Phone;
        private string _Police_Contact_First_Name;
        private string _Police_Contact_Middle_name;
        private string _Police_Contact_Last_Name;
        private string _Badge_Number;
        private string _Facsimile;
        private string _Police_Contact_Cell_Phone;
        private string _Address_1;
        private string _Jurisdiction;
        private string _Address_2;
        private string _Police_Report_Number;
        private string _Police_Contact_City;
        private decimal? _FK_LU_Police_Dept_State;
        private string _ZIP;
        private string _Case_Number;
        private DateTime? _Report_Ordered_Date;
        private DateTime? _Report_Recieved_Date;
        private decimal? _FK_Incident;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private string _UniqueVal;
        private string _Event_Desc;
        private DateTime? _Date_Opened;
        private decimal? _FK_LU_Event_Description;
        //aci event
        private string _Sonic_Event;
        private decimal? _ACI_Event_ID;
        private string _Camera_Name;
        private string _Camera_Number;
        private decimal? _FK_LU_Company;
        private string _Other_Event_Type;
        private string _Other_Event_Desc;
        private DateTime? _Event_Start_Date;
        private DateTime? _Event_End_Date;
        private string _Event_Image;
        private string _Event_Start_Time;
        private string _Event_End_Time;
        private decimal? _EventId;

        private string _Status;
        private string _Investigator_Name;
        private string _Investigator_Email;
        private string _Investigator_Phone;
        private string _ACI_EventID;
        private DateTime? _Date_Closed;
        private string _Monitoring_Hours;
        private string _Source_Of_Information;
        private decimal? _FK_AL_FR;
        private decimal? _FK_DPD_FR;
        private decimal? _FK_PL_FR;
        private decimal? _FK_Property_FR;
        private string _Event_Root_Cause;
        private string _How_Event_Prevented;
        private decimal? _Financial_Loss;
        private string _Police_Called;
        private string _Agency_name;
        private string _Officer_Name;
        private string _Officer_Phone;
        private string _Sonic_Contact_Name;
        private string _Sonic_Contact_Phone;
        private string _Sonic_Contact_Email;


        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Event value.
        /// </summary>
        public decimal? PK_Event
        {
            get { return _PK_Event; }
            set { _PK_Event = value; }
        }

        /// <summary>
        /// Gets or sets the Event_Number value.
        /// </summary>
        public string Event_Number
        {
            get { return _Event_Number; }
            set { _Event_Number = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Event_Type value.
        /// </summary>
        public decimal? FK_LU_Event_Type
        {
            get { return _FK_LU_Event_Type; }
            set { _FK_LU_Event_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Event_Report_Date value.
        /// </summary>
        public DateTime? Event_Report_Date
        {
            get { return _Event_Report_Date; }
            set { _Event_Report_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Event_Occurence_Date value.
        /// </summary>
        public DateTime? Event_Occurence_Date
        {
            get { return _Event_Occurence_Date; }
            set { _Event_Occurence_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Investigation_Report_Date value.
        /// </summary>
        public DateTime? Investigation_Report_Date
        {
            get { return _Investigation_Report_Date; }
            set { _Investigation_Report_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Sent value.
        /// </summary>
        public DateTime? Date_Sent
        {
            get { return _Date_Sent; }
            set { _Date_Sent = value; }
        }

        /// <summary>
        /// Gets or sets the Company value.
        /// </summary>
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location value.
        /// </summary>
        public decimal? FK_LU_Location
        {
            get { return _FK_LU_Location; }
            set { _FK_LU_Location = value; }
        }

        /// <summary>
        /// Gets or sets the Company_Address_1 value.
        /// </summary>
        public string Company_Address_1
        {
            get { return _Company_Address_1; }
            set { _Company_Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Company_Address_2 value.
        /// </summary>
        public string Company_Address_2
        {
            get { return _Company_Address_2; }
            set { _Company_Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the Company_City value.
        /// </summary>
        public string Company_City
        {
            get { return _Company_City; }
            set { _Company_City = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_State value.
        /// </summary>
        public decimal? FK_LU_State
        {
            get { return _FK_LU_State; }
            set { _FK_LU_State = value; }
        }

        /// <summary>
        /// Gets or sets the Company_ZIP value.
        /// </summary>
        public string Company_ZIP
        {
            get { return _Company_ZIP; }
            set { _Company_ZIP = value; }
        }

        /// <summary>
        /// Gets or sets the Company_County value.
        /// </summary>
        public string Company_County
        {
            get { return _Company_County; }
            set { _Company_County = value; }
        }

        /// <summary>
        /// Gets or sets the Company_Contact_First_Name value.
        /// </summary>
        public string Company_Contact_First_Name
        {
            get { return _Company_Contact_First_Name; }
            set { _Company_Contact_First_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Company_Contact_Middle_name value.
        /// </summary>
        public string Company_Contact_Middle_name
        {
            get { return _Company_Contact_Middle_name; }
            set { _Company_Contact_Middle_name = value; }
        }

        /// <summary>
        /// Gets or sets the Company_Contact_Last_Name value.
        /// </summary>
        public string Company_Contact_Last_Name
        {
            get { return _Company_Contact_Last_Name; }
            set { _Company_Contact_Last_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Company_Contact_Phone value.
        /// </summary>
        public string Company_Contact_Phone
        {
            get { return _Company_Contact_Phone; }
            set { _Company_Contact_Phone = value; }
        }

        /// <summary>
        /// Gets or sets the Company_Contact_Email value.
        /// </summary>
        public string Company_Contact_Email
        {
            get { return _Company_Contact_Email; }
            set { _Company_Contact_Email = value; }
        }

        /// <summary>
        /// Gets or sets the Company_Contact_Fax value.
        /// </summary>
        public string Company_Contact_Fax
        {
            get { return _Company_Contact_Fax; }
            set { _Company_Contact_Fax = value; }
        }

        /// <summary>
        /// Gets or sets the Vehicle_Number value.
        /// </summary>
        public string Vehicle_Number
        {
            get { return _Vehicle_Number; }
            set { _Vehicle_Number = value; }
        }

        /// <summary>
        /// Gets or sets the VIN value.
        /// </summary>
        public string VIN
        {
            get { return _VIN; }
            set { _VIN = value; }
        }

        /// <summary>
        /// Gets or sets the Make value.
        /// </summary>
        public string Make
        {
            get { return _Make; }
            set { _Make = value; }
        }

        /// <summary>
        /// Gets or sets the Model value.
        /// </summary>
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }

        /// <summary>
        /// Gets or sets the Year value.
        /// </summary>
        public string Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        /// <summary>
        /// Gets or sets the Company_Titled value.
        /// </summary>
        public string Company_Titled
        {
            get { return _Company_Titled; }
            set { _Company_Titled = value; }
        }

        /// <summary>
        /// Gets or sets the License_Tag value.
        /// </summary>
        public string License_Tag
        {
            get { return _License_Tag; }
            set { _License_Tag = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_State_Registered value.
        /// </summary>
        public decimal? FK_LU_State_Registered
        {
            get { return _FK_LU_State_Registered; }
            set { _FK_LU_State_Registered = value; }
        }

        /// <summary>
        /// Gets or sets the Police_Dept_Name value.
        /// </summary>
        public string Police_Dept_Name
        {
            get { return _Police_Dept_Name; }
            set { _Police_Dept_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Police_Phone value.
        /// </summary>
        public string Police_Phone
        {
            get { return _Police_Phone; }
            set { _Police_Phone = value; }
        }

        /// <summary>
        /// Gets or sets the Police_Contact_First_Name value.
        /// </summary>
        public string Police_Contact_First_Name
        {
            get { return _Police_Contact_First_Name; }
            set { _Police_Contact_First_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Police_Contact_Middle_name value.
        /// </summary>
        public string Police_Contact_Middle_name
        {
            get { return _Police_Contact_Middle_name; }
            set { _Police_Contact_Middle_name = value; }
        }

        /// <summary>
        /// Gets or sets the Police_Contact_Last_Name value.
        /// </summary>
        public string Police_Contact_Last_Name
        {
            get { return _Police_Contact_Last_Name; }
            set { _Police_Contact_Last_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Badge_Number value.
        /// </summary>
        public string Badge_Number
        {
            get { return _Badge_Number; }
            set { _Badge_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Facsimile value.
        /// </summary>
        public string Facsimile
        {
            get { return _Facsimile; }
            set { _Facsimile = value; }
        }

        /// <summary>
        /// Gets or sets the Police_Contact_Cell_Phone value.
        /// </summary>
        public string Police_Contact_Cell_Phone
        {
            get { return _Police_Contact_Cell_Phone; }
            set { _Police_Contact_Cell_Phone = value; }
        }

        /// <summary>
        /// Gets or sets the Address_1 value.
        /// </summary>
        public string Address_1
        {
            get { return _Address_1; }
            set { _Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Jurisdiction value.
        /// </summary>
        public string Jurisdiction
        {
            get { return _Jurisdiction; }
            set { _Jurisdiction = value; }
        }

        /// <summary>
        /// Gets or sets the Address_2 value.
        /// </summary>
        public string Address_2
        {
            get { return _Address_2; }
            set { _Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the Police_Report_Number value.
        /// </summary>
        public string Police_Report_Number
        {
            get { return _Police_Report_Number; }
            set { _Police_Report_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Police_Contact_City value.
        /// </summary>
        public string Police_Contact_City
        {
            get { return _Police_Contact_City; }
            set { _Police_Contact_City = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Police_Dept_State value.
        /// </summary>
        public decimal? FK_LU_Police_Dept_State
        {
            get { return _FK_LU_Police_Dept_State; }
            set { _FK_LU_Police_Dept_State = value; }
        }

        /// <summary>
        /// Gets or sets the ZIP value.
        /// </summary>
        public string ZIP
        {
            get { return _ZIP; }
            set { _ZIP = value; }
        }

        /// <summary>
        /// Gets or sets the Case_Number value.
        /// </summary>
        public string Case_Number
        {
            get { return _Case_Number; }
            set { _Case_Number = value; }
        }

        /// <summary>
        /// Gets or sets the Report_Ordered_Date value.
        /// </summary>
        public DateTime? Report_Ordered_Date
        {
            get { return _Report_Ordered_Date; }
            set { _Report_Ordered_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Report_Recieved_Date value.
        /// </summary>
        public DateTime? Report_Recieved_Date
        {
            get { return _Report_Recieved_Date; }
            set { _Report_Recieved_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Incident value.
        /// </summary>
        public decimal? FK_Incident
        {
            get { return _FK_Incident; }
            set { _FK_Incident = value; }
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

        /// <summary>
        /// Gets or sets the Unique value
        /// </summary>
        public string UniqueVal
        {
            get { return _UniqueVal; }
            set { _UniqueVal = value; }
        }

        /// <summary>
        /// Gets or sets the Event_Desc value.
        /// </summary>
        public string Event_Desc
        {
            get { return _Event_Desc; }
            set { _Event_Desc = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Opened value.
        /// </summary>
        public DateTime? Date_Opened
        {
            get { return _Date_Opened; }
            set { _Date_Opened = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Event_Description value.
        /// </summary>
        public decimal? FK_LU_Event_Description
        {
            get { return _FK_LU_Event_Description; }
            set { _FK_LU_Event_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Sonic_Event value.
        /// </summary>
        public string Sonic_Event
        {
            get { return _Sonic_Event; }
            set { _Sonic_Event = value; }
        }

        /// <summary>
        /// Gets or sets the ACI_Event_ID value.
        /// </summary>
        public decimal? ACI_Event_ID
        {
            get { return _ACI_Event_ID; }
            set { _ACI_Event_ID = value; }
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
        /// Gets or sets the Camera_Number value.
        /// </summary>
        public string Camera_Number
        {
            get { return _Camera_Number; }
            set { _Camera_Number = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Company value.
        /// </summary>
        public decimal? FK_LU_Company
        {
            get { return _FK_LU_Company; }
            set { _FK_LU_Company = value; }
        }

        /// <summary>
        /// Gets or sets the Other_Event_Type value.
        /// </summary>
        public string Other_Event_Type
        {
            get { return _Other_Event_Type; }
            set { _Other_Event_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Other_Event_Desc value.
        /// </summary>
        public string Other_Event_Desc
        {
            get { return _Other_Event_Desc; }
            set { _Other_Event_Desc = value; }
        }

        /// <summary>
        /// Gets or sets the Event_Start_Date value.
        /// </summary>
        public DateTime? Event_Start_Date
        {
            get { return _Event_Start_Date; }
            set { _Event_Start_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Event_End_Date value.
        /// </summary>
        public DateTime? Event_End_Date
        {
            get { return _Event_End_Date; }
            set { _Event_End_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Event_Image value.
        /// </summary>
        public string Event_Image
        {
            get { return _Event_Image; }
            set { _Event_Image = value; }
        }

        /// <summary>
        /// Gets or sets the Event_Start_Time value.
        /// </summary>
        public string Event_Start_Time
        {
            get { return _Event_Start_Time; }
            set { _Event_Start_Time = value; }
        }

        /// <summary>
        /// Gets or sets the Event_End_Time value.
        /// </summary>
        public string Event_End_Time
        {
            get { return _Event_End_Time; }
            set { _Event_End_Time = value; }
        }

        /// <summary>
        /// Gets or sets the EventId value.
        /// </summary>
        public decimal? EventId
        {
            get { return _EventId; }
            set { _EventId = value; }
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
        /// Gets or sets the Investigator_Name value.
        /// </summary>
        public string Investigator_Name
        {
            get { return _Investigator_Name; }
            set { _Investigator_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Investigator_Email value.
        /// </summary>
        public string Investigator_Email
        {
            get { return _Investigator_Email; }
            set { _Investigator_Email = value; }
        }

        /// <summary>
        /// Gets or sets the Investigator_Phone value.
        /// </summary>
        public string Investigator_Phone
        {
            get { return _Investigator_Phone; }
            set { _Investigator_Phone = value; }
        }

        /// <summary>
        /// Gets or sets the ACI_EventID value.
        /// </summary>
        public string ACI_EventID
        {
            get { return _ACI_EventID; }
            set { _ACI_EventID = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Closed value.
        /// </summary>
        public DateTime? Date_Closed
        {
            get { return _Date_Closed; }
            set { _Date_Closed = value; }
        }

        /// <summary>
        /// Gets or sets the Monitoring_Hours value.
        /// </summary>
        public string Monitoring_Hours
        {
            get { return _Monitoring_Hours; }
            set { _Monitoring_Hours = value; }
        }

        /// <summary>
        /// Gets or sets the Source_Of_Information value.
        /// </summary>
        public string Source_Of_Information
        {
            get { return _Source_Of_Information; }
            set { _Source_Of_Information = value; }
        }

        /// <summary>
        /// Gets or sets the FK_AL_FR value.
        /// </summary>
        public decimal? FK_AL_FR
        {
            get { return _FK_AL_FR; }
            set { _FK_AL_FR = value; }
        }

        /// <summary>
        /// Gets or sets the FK_DPD_FR value.
        /// </summary>
        public decimal? FK_DPD_FR
        {
            get { return _FK_DPD_FR; }
            set { _FK_DPD_FR = value; }
        }

        /// <summary>
        /// Gets or sets the FK_PL_FR value.
        /// </summary>
        public decimal? FK_PL_FR
        {
            get { return _FK_PL_FR; }
            set { _FK_PL_FR = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Property_FR value.
        /// </summary>
        public decimal? FK_Property_FR
        {
            get { return _FK_Property_FR; }
            set { _FK_Property_FR = value; }
        }

        /// <summary>
        /// Gets or sets the Event_Root_Cause value.
        /// </summary>
        public string Event_Root_Cause
        {
            get { return _Event_Root_Cause; }
            set { _Event_Root_Cause = value; }
        }

        /// <summary>
        /// Gets or sets the How_Event_Prevented value.
        /// </summary>
        public string How_Event_Prevented
        {
            get { return _How_Event_Prevented; }
            set { _How_Event_Prevented = value; }
        }

        /// <summary>
        /// Gets or sets the Financial_Loss value.
        /// </summary>
        public decimal? Financial_Loss
        {
            get { return _Financial_Loss; }
            set { _Financial_Loss = value; }
        }

        /// <summary>
        /// Gets or sets the Police_Called value.
        /// </summary>
        public string Police_Called
        {
            get { return _Police_Called; }
            set { _Police_Called = value; }
        }

        /// <summary>
        /// Gets or sets the Agency_name value.
        /// </summary>
        public string Agency_name
        {
            get { return _Agency_name; }
            set { _Agency_name = value; }
        }

        /// <summary>
        /// Gets or sets the Officer_Name value.
        /// </summary>
        public string Officer_Name
        {
            get { return _Officer_Name; }
            set { _Officer_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Officer_Phone value.
        /// </summary>
        public string Officer_Phone
        {
            get { return _Officer_Phone; }
            set { _Officer_Phone = value; }
        }

        /// <summary>
        /// Gets or sets the Sonic_Contact_Name value.
        /// </summary>
        public string Sonic_Contact_Name
        {
            get { return _Sonic_Contact_Name; }
            set { _Sonic_Contact_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Sonic_Contact_Phone value.
        /// </summary>
        public string Sonic_Contact_Phone
        {
            get { return _Sonic_Contact_Phone; }
            set { _Sonic_Contact_Phone = value; }
        }

        /// <summary>
        /// Gets or sets the Sonic_Contact_Email value.
        /// </summary>
        public string Sonic_Contact_Email
        {
            get { return _Sonic_Contact_Email; }
            set { _Sonic_Contact_Email = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the clsEvent class with default value.
        /// </summary>
        public clsEvent()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsEvent class based on Primary Key.
        /// </summary>
        public clsEvent(decimal pK_Event)
        {
            DataTable dtEvent = SelectByPK(pK_Event).Tables[0];

            if (dtEvent.Rows.Count == 1)
            {
                SetValue(dtEvent.Rows[0]);

            }

        } 

        /// <summary>
        /// Initializes a new instance of the clsEvent class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drEvent)
        {
            if (drEvent["PK_Event"] == DBNull.Value)
                this._PK_Event = null;
            else
                this._PK_Event = (decimal?)drEvent["PK_Event"];

            if (drEvent["Event_Number"] == DBNull.Value)
                this._Event_Number = null;
            else
                this._Event_Number = (string)drEvent["Event_Number"];

            if (drEvent["FK_LU_Event_Type"] == DBNull.Value)
                this._FK_LU_Event_Type = null;
            else
                this._FK_LU_Event_Type = (decimal?)drEvent["FK_LU_Event_Type"];

            if (drEvent["Event_Report_Date"] == DBNull.Value)
                this._Event_Report_Date = null;
            else
                this._Event_Report_Date = (DateTime?)drEvent["Event_Report_Date"];

            if (drEvent["Event_Occurence_Date"] == DBNull.Value)
                this._Event_Occurence_Date = null;
            else
                this._Event_Occurence_Date = (DateTime?)drEvent["Event_Occurence_Date"];

            if (drEvent["Investigation_Report_Date"] == DBNull.Value)
                this._Investigation_Report_Date = null;
            else
                this._Investigation_Report_Date = (DateTime?)drEvent["Investigation_Report_Date"];

            if (drEvent["Date_Sent"] == DBNull.Value)
                this._Date_Sent = null;
            else
                this._Date_Sent = (DateTime?)drEvent["Date_Sent"];

            if (drEvent["Company"] == DBNull.Value)
                this._Company = null;
            else
                this._Company = (string)drEvent["Company"];

            if (drEvent["FK_LU_Location"] == DBNull.Value)
                this._FK_LU_Location = null;
            else
                this._FK_LU_Location = (decimal?)drEvent["FK_LU_Location"];

            if (drEvent["Company_Address_1"] == DBNull.Value)
                this._Company_Address_1 = null;
            else
                this._Company_Address_1 = (string)drEvent["Company_Address_1"];

            if (drEvent["Company_Address_2"] == DBNull.Value)
                this._Company_Address_2 = null;
            else
                this._Company_Address_2 = (string)drEvent["Company_Address_2"];

            if (drEvent["Company_City"] == DBNull.Value)
                this._Company_City = null;
            else
                this._Company_City = (string)drEvent["Company_City"];

            if (drEvent["FK_LU_State"] == DBNull.Value)
                this._FK_LU_State = null;
            else
                this._FK_LU_State = (decimal?)drEvent["FK_LU_State"];

            if (drEvent["Company_ZIP"] == DBNull.Value)
                this._Company_ZIP = null;
            else
                this._Company_ZIP = (string)drEvent["Company_ZIP"];

            if (drEvent["Company_County"] == DBNull.Value)
                this._Company_County = null;
            else
                this._Company_County = (string)drEvent["Company_County"];

            if (drEvent["Company_Contact_First_Name"] == DBNull.Value)
                this._Company_Contact_First_Name = null;
            else
                this._Company_Contact_First_Name = (string)drEvent["Company_Contact_First_Name"];

            if (drEvent["Company_Contact_Middle_name"] == DBNull.Value)
                this._Company_Contact_Middle_name = null;
            else
                this._Company_Contact_Middle_name = (string)drEvent["Company_Contact_Middle_name"];

            if (drEvent["Company_Contact_Last_Name"] == DBNull.Value)
                this._Company_Contact_Last_Name = null;
            else
                this._Company_Contact_Last_Name = (string)drEvent["Company_Contact_Last_Name"];

            if (drEvent["Company_Contact_Phone"] == DBNull.Value)
                this._Company_Contact_Phone = null;
            else
                this._Company_Contact_Phone = (string)drEvent["Company_Contact_Phone"];

            if (drEvent["Company_Contact_Email"] == DBNull.Value)
                this._Company_Contact_Email = null;
            else
                this._Company_Contact_Email = (string)drEvent["Company_Contact_Email"];

            if (drEvent["Company_Contact_Fax"] == DBNull.Value)
                this._Company_Contact_Fax = null;
            else
                this._Company_Contact_Fax = (string)drEvent["Company_Contact_Fax"];

            if (drEvent["Vehicle_Number"] == DBNull.Value)
                this._Vehicle_Number = null;
            else
                this._Vehicle_Number = (string)drEvent["Vehicle_Number"];

            if (drEvent["VIN"] == DBNull.Value)
                this._VIN = null;
            else
                this._VIN = (string)drEvent["VIN"];

            if (drEvent["Make"] == DBNull.Value)
                this._Make = null;
            else
                this._Make = (string)drEvent["Make"];

            if (drEvent["Model"] == DBNull.Value)
                this._Model = null;
            else
                this._Model = (string)drEvent["Model"];

            if (drEvent["Year"] == DBNull.Value)
                this._Year = null;
            else
                this._Year = (string)drEvent["Year"];

            if (drEvent["Company_Titled"] == DBNull.Value)
                this._Company_Titled = null;
            else
                this._Company_Titled = (string)drEvent["Company_Titled"];

            if (drEvent["License_Tag"] == DBNull.Value)
                this._License_Tag = null;
            else
                this._License_Tag = (string)drEvent["License_Tag"];

            if (drEvent["FK_LU_State_Registered"] == DBNull.Value)
                this._FK_LU_State_Registered = null;
            else
                this._FK_LU_State_Registered = (decimal?)drEvent["FK_LU_State_Registered"];

            if (drEvent["Police_Dept_Name"] == DBNull.Value)
                this._Police_Dept_Name = null;
            else
                this._Police_Dept_Name = (string)drEvent["Police_Dept_Name"];

            if (drEvent["Police_Phone"] == DBNull.Value)
                this._Police_Phone = null;
            else
                this._Police_Phone = (string)drEvent["Police_Phone"];

            if (drEvent["Police_Contact_First_Name"] == DBNull.Value)
                this._Police_Contact_First_Name = null;
            else
                this._Police_Contact_First_Name = (string)drEvent["Police_Contact_First_Name"];

            if (drEvent["Police_Contact_Middle_name"] == DBNull.Value)
                this._Police_Contact_Middle_name = null;
            else
                this._Police_Contact_Middle_name = (string)drEvent["Police_Contact_Middle_name"];

            if (drEvent["Police_Contact_Last_Name"] == DBNull.Value)
                this._Police_Contact_Last_Name = null;
            else
                this._Police_Contact_Last_Name = (string)drEvent["Police_Contact_Last_Name"];

            if (drEvent["Badge_Number"] == DBNull.Value)
                this._Badge_Number = null;
            else
                this._Badge_Number = (string)drEvent["Badge_Number"];

            if (drEvent["Facsimile"] == DBNull.Value)
                this._Facsimile = null;
            else
                this._Facsimile = (string)drEvent["Facsimile"];

            if (drEvent["Police_Contact_Cell_Phone"] == DBNull.Value)
                this._Police_Contact_Cell_Phone = null;
            else
                this._Police_Contact_Cell_Phone = (string)drEvent["Police_Contact_Cell_Phone"];

            if (drEvent["Address_1"] == DBNull.Value)
                this._Address_1 = null;
            else
                this._Address_1 = (string)drEvent["Address_1"];

            if (drEvent["Jurisdiction"] == DBNull.Value)
                this._Jurisdiction = null;
            else
                this._Jurisdiction = (string)drEvent["Jurisdiction"];

            if (drEvent["Address_2"] == DBNull.Value)
                this._Address_2 = null;
            else
                this._Address_2 = (string)drEvent["Address_2"];

            if (drEvent["Police_Report_Number"] == DBNull.Value)
                this._Police_Report_Number = null;
            else
                this._Police_Report_Number = (string)drEvent["Police_Report_Number"];

            if (drEvent["Police_Contact_City"] == DBNull.Value)
                this._Police_Contact_City = null;
            else
                this._Police_Contact_City = (string)drEvent["Police_Contact_City"];

            if (drEvent["FK_LU_Police_Dept_State"] == DBNull.Value)
                this._FK_LU_Police_Dept_State = null;
            else
                this._FK_LU_Police_Dept_State = (decimal?)drEvent["FK_LU_Police_Dept_State"];

            if (drEvent["ZIP"] == DBNull.Value)
                this._ZIP = null;
            else
                this._ZIP = (string)drEvent["ZIP"];

            if (drEvent["Case_Number"] == DBNull.Value)
                this._Case_Number = null;
            else
                this._Case_Number = (string)drEvent["Case_Number"];

            if (drEvent["Report_Ordered_Date"] == DBNull.Value)
                this._Report_Ordered_Date = null;
            else
                this._Report_Ordered_Date = (DateTime?)drEvent["Report_Ordered_Date"];

            if (drEvent["Report_Recieved_Date"] == DBNull.Value)
                this._Report_Recieved_Date = null;
            else
                this._Report_Recieved_Date = (DateTime?)drEvent["Report_Recieved_Date"];

            if (drEvent["FK_Incident"] == DBNull.Value)
                this._FK_Incident = null;
            else
                this._FK_Incident = (decimal?)drEvent["FK_Incident"];

            if (drEvent["Updated_By"] == DBNull.Value)
                this._Updated_By = null;
            else
                this._Updated_By = (string)drEvent["Updated_By"];

            if (drEvent["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drEvent["Update_Date"];

            if (drEvent["UniqueVal"] == DBNull.Value)
                this._UniqueVal = null;
            else
                this._UniqueVal = (string)drEvent["UniqueVal"];

            if (drEvent["Event_Desc"] == DBNull.Value)
                this._Event_Desc = null;
            else
                this._Event_Desc = (string)drEvent["Event_Desc"];

            if (drEvent["Date_Opened"] == DBNull.Value)
                this._Date_Opened = null;
            else
                this._Date_Opened = (DateTime?)drEvent["Date_Opened"];

            if (drEvent["FK_LU_Event_Description"] == DBNull.Value)
                this._FK_LU_Event_Description = null;
            else
                this._FK_LU_Event_Description = (decimal?)drEvent["FK_LU_Event_Description"];

            if (drEvent["Sonic_Event"] == DBNull.Value)
                this._Sonic_Event = null;
            else
                this._Sonic_Event = (string)drEvent["Sonic_Event"];

            if (drEvent["ACI_Event_ID"] == DBNull.Value)
                this._ACI_Event_ID = null;
            else
                this._ACI_Event_ID = (decimal?)drEvent["ACI_Event_ID"];

            if (drEvent["Camera_Name"] == DBNull.Value)
                this._Camera_Name = null;
            else
                this._Camera_Name = (string)drEvent["Camera_Name"];

            if (drEvent["Camera_Number"] == DBNull.Value)
                this._Camera_Number = null;
            else
                this._Camera_Number = (string)drEvent["Camera_Number"];

            if (drEvent["FK_LU_Company"] == DBNull.Value)
                this._FK_LU_Company = null;
            else
                this._FK_LU_Company = (decimal?)drEvent["FK_LU_Company"];

            if (drEvent["Other_Event_Type"] == DBNull.Value)
                this._Other_Event_Type = null;
            else
                this._Other_Event_Type = (string)drEvent["Other_Event_Type"];

            if (drEvent["Other_Event_Desc"] == DBNull.Value)
                this._Other_Event_Desc = null;
            else
                this._Other_Event_Desc = (string)drEvent["Other_Event_Desc"];

            if (drEvent["Event_Start_Date"] == DBNull.Value)
                this._Event_Start_Date = null;
            else
                this._Event_Start_Date = (DateTime?)drEvent["Event_Start_Date"];

            if (drEvent["Event_End_Date"] == DBNull.Value)
                this._Event_End_Date = null;
            else
                this._Event_End_Date = (DateTime?)drEvent["Event_End_Date"];

            if (drEvent["Event_Image"] == DBNull.Value)
                this._Event_Image = null;
            else
                this._Event_Image = (string)drEvent["Event_Image"];

            if (drEvent["Event_Start_Time"] == DBNull.Value)
                this._Event_Start_Time = null;
            else
                this._Event_Start_Time = (string)drEvent["Event_Start_Time"];

            if (drEvent["Event_End_Time"] == DBNull.Value)
                this._Event_End_Time = null;
            else
                this._Event_End_Time = (string)drEvent["Event_End_Time"];

            if (drEvent["Status"] == DBNull.Value)
                this._Status = null;
            else
                this._Status = (string)drEvent["Status"];

            if (drEvent["Investigator_Name"] == DBNull.Value)
                this._Investigator_Name = null;
            else
                this._Investigator_Name = (string)drEvent["Investigator_Name"];

            if (drEvent["Investigator_Email"] == DBNull.Value)
                this._Investigator_Email = null;
            else
                this._Investigator_Email = (string)drEvent["Investigator_Email"];

            if (drEvent["Investigator_Phone"] == DBNull.Value)
                this._Investigator_Phone = null;
            else
                this._Investigator_Phone = (string)drEvent["Investigator_Phone"];

            if (drEvent["ACI_EventID"] == DBNull.Value)
                this._ACI_EventID = null;
            else
                this._ACI_EventID = (string)drEvent["ACI_EventID"];

            if (drEvent["Date_Closed"] == DBNull.Value)
                this._Date_Closed = null;
            else
                this._Date_Closed = (DateTime?)drEvent["Date_Closed"];

            if (drEvent["Monitoring_Hours"] == DBNull.Value)
                this._Monitoring_Hours = null;
            else
                this._Monitoring_Hours = (string)drEvent["Monitoring_Hours"];

            if (drEvent["Source_Of_Information"] == DBNull.Value)
                this._Source_Of_Information = null;
            else
                this._Source_Of_Information = (string)drEvent["Source_Of_Information"];

            if (drEvent["FK_AL_FR"] == DBNull.Value)
                this._FK_AL_FR = null;
            else
                this._FK_AL_FR = (decimal?)drEvent["FK_AL_FR"];

            if (drEvent["FK_DPD_FR"] == DBNull.Value)
                this._FK_DPD_FR = null;
            else
                this._FK_DPD_FR = (decimal?)drEvent["FK_DPD_FR"];

            if (drEvent["FK_PL_FR"] == DBNull.Value)
                this._FK_PL_FR = null;
            else
                this._FK_PL_FR = (decimal?)drEvent["FK_PL_FR"];

            if (drEvent["FK_Property_FR"] == DBNull.Value)
                this._FK_Property_FR = null;
            else
                this._FK_Property_FR = (decimal?)drEvent["FK_Property_FR"];

            if (drEvent["Event_Root_Cause"] == DBNull.Value)
                this._Event_Root_Cause = null;
            else
                this._Event_Root_Cause = (string)drEvent["Event_Root_Cause"];

            if (drEvent["How_Event_Prevented"] == DBNull.Value)
                this._How_Event_Prevented = null;
            else
                this._How_Event_Prevented = (string)drEvent["How_Event_Prevented"];

            if (drEvent["Financial_Loss"] == DBNull.Value)
                this._Financial_Loss = null;
            else
                this._Financial_Loss = (decimal?)drEvent["Financial_Loss"];

            if (drEvent["Police_Called"] == DBNull.Value)
                this._Police_Called = null;
            else
                this._Police_Called = (string)drEvent["Police_Called"];

            if (drEvent["Agency_name"] == DBNull.Value)
                this._Agency_name = null;
            else
                this._Agency_name = (string)drEvent["Agency_name"];

            if (drEvent["Officer_Name"] == DBNull.Value)
                this._Officer_Name = null;
            else
                this._Officer_Name = (string)drEvent["Officer_Name"];

            if (drEvent["Officer_Phone"] == DBNull.Value)
                this._Officer_Phone = null;
            else
                this._Officer_Phone = (string)drEvent["Officer_Phone"];

            if (drEvent["Sonic_Contact_Name"] == DBNull.Value)
                this._Sonic_Contact_Name = null;
            else
                this._Sonic_Contact_Name = (string)drEvent["Sonic_Contact_Name"];

            if (drEvent["Sonic_Contact_Phone"] == DBNull.Value)
                this._Sonic_Contact_Phone = null;
            else
                this._Sonic_Contact_Phone = (string)drEvent["Sonic_Contact_Phone"];

            if (drEvent["Sonic_Contact_Email"] == DBNull.Value)
                this._Sonic_Contact_Email = null;
            else
                this._Sonic_Contact_Email = (string)drEvent["Sonic_Contact_Email"];
        }

        #endregion

        /// <summary>
        /// Inserts a record into the Event table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EventInsert");


            if (string.IsNullOrEmpty(this._Event_Number))
                db.AddInParameter(dbCommand, "Event_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Number", DbType.String, this._Event_Number);

            db.AddInParameter(dbCommand, "FK_LU_Event_Type", DbType.Decimal, this._FK_LU_Event_Type);

            db.AddInParameter(dbCommand, "Event_Report_Date", DbType.DateTime, this._Event_Report_Date);

            db.AddInParameter(dbCommand, "Event_Occurence_Date", DbType.DateTime, this._Event_Occurence_Date);

            db.AddInParameter(dbCommand, "Investigation_Report_Date", DbType.DateTime, this._Investigation_Report_Date);

            db.AddInParameter(dbCommand, "Date_Sent", DbType.DateTime, this._Date_Sent);

            if (string.IsNullOrEmpty(this._Company))
                db.AddInParameter(dbCommand, "Company", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company", DbType.String, this._Company);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            if (string.IsNullOrEmpty(this._Company_Address_1))
                db.AddInParameter(dbCommand, "Company_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Address_1", DbType.String, this._Company_Address_1);

            if (string.IsNullOrEmpty(this._Company_Address_2))
                db.AddInParameter(dbCommand, "Company_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Address_2", DbType.String, this._Company_Address_2);

            if (string.IsNullOrEmpty(this._Company_City))
                db.AddInParameter(dbCommand, "Company_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_City", DbType.String, this._Company_City);

            db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, this._FK_LU_State);

            if (string.IsNullOrEmpty(this._Company_ZIP))
                db.AddInParameter(dbCommand, "Company_ZIP", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_ZIP", DbType.String, this._Company_ZIP);

            if (string.IsNullOrEmpty(this._Company_County))
                db.AddInParameter(dbCommand, "Company_County", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_County", DbType.String, this._Company_County);

            if (string.IsNullOrEmpty(this._Company_Contact_First_Name))
                db.AddInParameter(dbCommand, "Company_Contact_First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_First_Name", DbType.String, this._Company_Contact_First_Name);

            if (string.IsNullOrEmpty(this._Company_Contact_Middle_name))
                db.AddInParameter(dbCommand, "Company_Contact_Middle_name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_Middle_name", DbType.String, this._Company_Contact_Middle_name);

            if (string.IsNullOrEmpty(this._Company_Contact_Last_Name))
                db.AddInParameter(dbCommand, "Company_Contact_Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_Last_Name", DbType.String, this._Company_Contact_Last_Name);

            if (string.IsNullOrEmpty(this._Company_Contact_Phone))
                db.AddInParameter(dbCommand, "Company_Contact_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_Phone", DbType.String, this._Company_Contact_Phone);

            if (string.IsNullOrEmpty(this._Company_Contact_Email))
                db.AddInParameter(dbCommand, "Company_Contact_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_Email", DbType.String, this._Company_Contact_Email);

            if (string.IsNullOrEmpty(this._Company_Contact_Fax))
                db.AddInParameter(dbCommand, "Company_Contact_Fax", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_Fax", DbType.String, this._Company_Contact_Fax);

            if (string.IsNullOrEmpty(this._Vehicle_Number))
                db.AddInParameter(dbCommand, "Vehicle_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_Number", DbType.String, this._Vehicle_Number);

            if (string.IsNullOrEmpty(this._VIN))
                db.AddInParameter(dbCommand, "VIN", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "VIN", DbType.String, this._VIN);

            if (string.IsNullOrEmpty(this._Make))
                db.AddInParameter(dbCommand, "Make", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Make", DbType.String, this._Make);

            if (string.IsNullOrEmpty(this._Model))
                db.AddInParameter(dbCommand, "Model", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Model", DbType.String, this._Model);

            if (string.IsNullOrEmpty(this._Year))
                db.AddInParameter(dbCommand, "Year", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Year", DbType.String, this._Year);

            if (string.IsNullOrEmpty(this._Company_Titled))
                db.AddInParameter(dbCommand, "Company_Titled", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Titled", DbType.String, this._Company_Titled);

            if (string.IsNullOrEmpty(this._License_Tag))
                db.AddInParameter(dbCommand, "License_Tag", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "License_Tag", DbType.String, this._License_Tag);

            db.AddInParameter(dbCommand, "FK_LU_State_Registered", DbType.Decimal, this._FK_LU_State_Registered);

            if (string.IsNullOrEmpty(this._Police_Dept_Name))
                db.AddInParameter(dbCommand, "Police_Dept_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Dept_Name", DbType.String, this._Police_Dept_Name);

            if (string.IsNullOrEmpty(this._Police_Phone))
                db.AddInParameter(dbCommand, "Police_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Phone", DbType.String, this._Police_Phone);

            if (string.IsNullOrEmpty(this._Police_Contact_First_Name))
                db.AddInParameter(dbCommand, "Police_Contact_First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Contact_First_Name", DbType.String, this._Police_Contact_First_Name);

            if (string.IsNullOrEmpty(this._Police_Contact_Middle_name))
                db.AddInParameter(dbCommand, "Police_Contact_Middle_name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Contact_Middle_name", DbType.String, this._Police_Contact_Middle_name);

            if (string.IsNullOrEmpty(this._Police_Contact_Last_Name))
                db.AddInParameter(dbCommand, "Police_Contact_Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Contact_Last_Name", DbType.String, this._Police_Contact_Last_Name);

            if (string.IsNullOrEmpty(this._Badge_Number))
                db.AddInParameter(dbCommand, "Badge_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Badge_Number", DbType.String, this._Badge_Number);

            if (string.IsNullOrEmpty(this._Facsimile))
                db.AddInParameter(dbCommand, "Facsimile", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Facsimile", DbType.String, this._Facsimile);

            if (string.IsNullOrEmpty(this._Police_Contact_Cell_Phone))
                db.AddInParameter(dbCommand, "Police_Contact_Cell_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Contact_Cell_Phone", DbType.String, this._Police_Contact_Cell_Phone);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Jurisdiction))
                db.AddInParameter(dbCommand, "Jurisdiction", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Jurisdiction", DbType.String, this._Jurisdiction);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._Police_Report_Number))
                db.AddInParameter(dbCommand, "Police_Report_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Report_Number", DbType.String, this._Police_Report_Number);

            if (string.IsNullOrEmpty(this._Police_Contact_City))
                db.AddInParameter(dbCommand, "Police_Contact_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Contact_City", DbType.String, this._Police_Contact_City);

            db.AddInParameter(dbCommand, "FK_LU_Police_Dept_State", DbType.Decimal, this._FK_LU_Police_Dept_State);

            if (string.IsNullOrEmpty(this._ZIP))
                db.AddInParameter(dbCommand, "ZIP", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZIP", DbType.String, this._ZIP);

            if (string.IsNullOrEmpty(this._Case_Number))
                db.AddInParameter(dbCommand, "Case_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Case_Number", DbType.String, this._Case_Number);

            db.AddInParameter(dbCommand, "Report_Ordered_Date", DbType.DateTime, this._Report_Ordered_Date);

            db.AddInParameter(dbCommand, "Report_Recieved_Date", DbType.DateTime, this._Report_Recieved_Date);

            db.AddInParameter(dbCommand, "FK_Incident", DbType.Decimal, this._FK_Incident);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Event_Desc))
                db.AddInParameter(dbCommand, "Event_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Desc", DbType.String, this._Event_Desc);

            db.AddInParameter(dbCommand, "FK_LU_Event_Description", DbType.Decimal, this._FK_LU_Event_Description);

            if (string.IsNullOrEmpty(this._Sonic_Event))
                db.AddInParameter(dbCommand, "Sonic_Event", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_Event", DbType.String, this._Sonic_Event);

            //db.AddInParameter(dbCommand, "ACI_Event_ID", DbType.Decimal, this._ACI_Event_ID);

            if (string.IsNullOrEmpty(this._Camera_Name))
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, this._Camera_Name);

            if (string.IsNullOrEmpty(this._Camera_Number))
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, this._Camera_Number);

            db.AddInParameter(dbCommand, "FK_LU_Company", DbType.Decimal, this._FK_LU_Company);

            if (string.IsNullOrEmpty(this._Other_Event_Type))
                db.AddInParameter(dbCommand, "Other_Event_Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Event_Type", DbType.String, this._Other_Event_Type);

            if (string.IsNullOrEmpty(this._Other_Event_Desc))
                db.AddInParameter(dbCommand, "Other_Event_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Event_Desc", DbType.String, this._Other_Event_Desc);

            db.AddInParameter(dbCommand, "Event_Start_Date", DbType.DateTime, this._Event_Start_Date);

            db.AddInParameter(dbCommand, "Event_End_Date", DbType.DateTime, this._Event_End_Date);

            if (string.IsNullOrEmpty(this._Event_Image))
                db.AddInParameter(dbCommand, "Event_Image", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Image", DbType.String, this._Event_Image);

            if (string.IsNullOrEmpty(this._Event_Image))
                db.AddInParameter(dbCommand, "Event_Start_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Start_Time", DbType.String, this._Event_Start_Time);

            if (string.IsNullOrEmpty(this._Event_Image))
                db.AddInParameter(dbCommand, "Event_End_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_End_Time", DbType.String, this._Event_End_Time);

            if (string.IsNullOrEmpty(this._Status))
                db.AddInParameter(dbCommand, "Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);

            if (string.IsNullOrEmpty(this._Investigator_Name))
                db.AddInParameter(dbCommand, "Investigator_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigator_Name", DbType.String, this._Investigator_Name);

            if (string.IsNullOrEmpty(this._Investigator_Email))
                db.AddInParameter(dbCommand, "Investigator_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigator_Email", DbType.String, this._Investigator_Email);

            if (string.IsNullOrEmpty(this._Investigator_Phone))
                db.AddInParameter(dbCommand, "Investigator_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigator_Phone", DbType.String, this._Investigator_Phone);

            if (string.IsNullOrEmpty(this._ACI_EventID))
                db.AddInParameter(dbCommand, "ACI_EventID", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ACI_EventID", DbType.String, this._ACI_EventID);

            db.AddInParameter(dbCommand, "Date_Closed", DbType.DateTime, this._Date_Closed);

            if (string.IsNullOrEmpty(this._Monitoring_Hours))
                db.AddInParameter(dbCommand, "Monitoring_Hours", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Monitoring_Hours", DbType.String, this._Monitoring_Hours);

            if (string.IsNullOrEmpty(this._Source_Of_Information))
                db.AddInParameter(dbCommand, "Source_Of_Information", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Source_Of_Information", DbType.String, this._Source_Of_Information);

            db.AddInParameter(dbCommand, "FK_AL_FR", DbType.Decimal, this._FK_AL_FR);

            db.AddInParameter(dbCommand, "FK_DPD_FR", DbType.Decimal, this._FK_DPD_FR);

            db.AddInParameter(dbCommand, "FK_PL_FR", DbType.Decimal, this._FK_PL_FR);

            db.AddInParameter(dbCommand, "FK_Property_FR", DbType.Decimal, this._FK_Property_FR);

            if (string.IsNullOrEmpty(this._Event_Root_Cause))
                db.AddInParameter(dbCommand, "Event_Root_Cause", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Root_Cause", DbType.String, this._Event_Root_Cause);

            if (string.IsNullOrEmpty(this._How_Event_Prevented))
                db.AddInParameter(dbCommand, "How_Event_Prevented", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "How_Event_Prevented", DbType.String, this._How_Event_Prevented);

            db.AddInParameter(dbCommand, "Financial_Loss", DbType.Decimal, this._Financial_Loss);

            if (string.IsNullOrEmpty(this._Police_Called))
                db.AddInParameter(dbCommand, "Police_Called", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Called", DbType.String, this._Police_Called);

            if (string.IsNullOrEmpty(this._Agency_name))
                db.AddInParameter(dbCommand, "Agency_name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Agency_name", DbType.String, this._Agency_name);

            if (string.IsNullOrEmpty(this._Officer_Name))
                db.AddInParameter(dbCommand, "Officer_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Officer_Name", DbType.String, this._Officer_Name);

            if (string.IsNullOrEmpty(this._Officer_Phone))
                db.AddInParameter(dbCommand, "Officer_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Officer_Phone", DbType.String, this._Officer_Phone);

            if (string.IsNullOrEmpty(this._Sonic_Contact_Name))
                db.AddInParameter(dbCommand, "Sonic_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_Contact_Name", DbType.String, this._Sonic_Contact_Name);

            if (string.IsNullOrEmpty(this._Sonic_Contact_Phone))
                db.AddInParameter(dbCommand, "Sonic_Contact_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_Contact_Phone", DbType.String, this._Sonic_Contact_Phone);

            if (string.IsNullOrEmpty(this._Sonic_Contact_Email))
                db.AddInParameter(dbCommand, "Sonic_Contact_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_Contact_Email", DbType.String, this._Sonic_Contact_Email);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Event table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet SelectByPK(decimal pK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EventSelectByPK");

            db.AddInParameter(dbCommand, "PK_Event", DbType.Decimal, pK_Event);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Event table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EventSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Event table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EventUpdate");


            db.AddInParameter(dbCommand, "PK_Event", DbType.Decimal, this._PK_Event);

            if (string.IsNullOrEmpty(this._Event_Number))
                db.AddInParameter(dbCommand, "Event_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Number", DbType.String, this._Event_Number);

            db.AddInParameter(dbCommand, "FK_LU_Event_Type", DbType.Decimal, this._FK_LU_Event_Type);

            db.AddInParameter(dbCommand, "Event_Report_Date", DbType.DateTime, this._Event_Report_Date);

            db.AddInParameter(dbCommand, "Event_Occurence_Date", DbType.DateTime, this._Event_Occurence_Date);

            db.AddInParameter(dbCommand, "Investigation_Report_Date", DbType.DateTime, this._Investigation_Report_Date);

            db.AddInParameter(dbCommand, "Date_Sent", DbType.DateTime, this._Date_Sent);

            if (string.IsNullOrEmpty(this._Company))
                db.AddInParameter(dbCommand, "Company", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company", DbType.String, this._Company);

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, this._FK_LU_Location);

            if (string.IsNullOrEmpty(this._Company_Address_1))
                db.AddInParameter(dbCommand, "Company_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Address_1", DbType.String, this._Company_Address_1);

            if (string.IsNullOrEmpty(this._Company_Address_2))
                db.AddInParameter(dbCommand, "Company_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Address_2", DbType.String, this._Company_Address_2);

            if (string.IsNullOrEmpty(this._Company_City))
                db.AddInParameter(dbCommand, "Company_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_City", DbType.String, this._Company_City);

            db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, this._FK_LU_State);

            if (string.IsNullOrEmpty(this._Company_ZIP))
                db.AddInParameter(dbCommand, "Company_ZIP", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_ZIP", DbType.String, this._Company_ZIP);

            if (string.IsNullOrEmpty(this._Company_County))
                db.AddInParameter(dbCommand, "Company_County", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_County", DbType.String, this._Company_County);

            if (string.IsNullOrEmpty(this._Company_Contact_First_Name))
                db.AddInParameter(dbCommand, "Company_Contact_First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_First_Name", DbType.String, this._Company_Contact_First_Name);

            if (string.IsNullOrEmpty(this._Company_Contact_Middle_name))
                db.AddInParameter(dbCommand, "Company_Contact_Middle_name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_Middle_name", DbType.String, this._Company_Contact_Middle_name);

            if (string.IsNullOrEmpty(this._Company_Contact_Last_Name))
                db.AddInParameter(dbCommand, "Company_Contact_Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_Last_Name", DbType.String, this._Company_Contact_Last_Name);

            if (string.IsNullOrEmpty(this._Company_Contact_Phone))
                db.AddInParameter(dbCommand, "Company_Contact_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_Phone", DbType.String, this._Company_Contact_Phone);

            if (string.IsNullOrEmpty(this._Company_Contact_Email))
                db.AddInParameter(dbCommand, "Company_Contact_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_Email", DbType.String, this._Company_Contact_Email);

            if (string.IsNullOrEmpty(this._Company_Contact_Fax))
                db.AddInParameter(dbCommand, "Company_Contact_Fax", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Contact_Fax", DbType.String, this._Company_Contact_Fax);

            if (string.IsNullOrEmpty(this._Vehicle_Number))
                db.AddInParameter(dbCommand, "Vehicle_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Vehicle_Number", DbType.String, this._Vehicle_Number);

            if (string.IsNullOrEmpty(this._VIN))
                db.AddInParameter(dbCommand, "VIN", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "VIN", DbType.String, this._VIN);

            if (string.IsNullOrEmpty(this._Make))
                db.AddInParameter(dbCommand, "Make", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Make", DbType.String, this._Make);

            if (string.IsNullOrEmpty(this._Model))
                db.AddInParameter(dbCommand, "Model", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Model", DbType.String, this._Model);

            if (string.IsNullOrEmpty(this._Year))
                db.AddInParameter(dbCommand, "Year", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Year", DbType.String, this._Year);

            if (string.IsNullOrEmpty(this._Company_Titled))
                db.AddInParameter(dbCommand, "Company_Titled", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Company_Titled", DbType.String, this._Company_Titled);

            if (string.IsNullOrEmpty(this._License_Tag))
                db.AddInParameter(dbCommand, "License_Tag", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "License_Tag", DbType.String, this._License_Tag);

            db.AddInParameter(dbCommand, "FK_LU_State_Registered", DbType.Decimal, this._FK_LU_State_Registered);

            if (string.IsNullOrEmpty(this._Police_Dept_Name))
                db.AddInParameter(dbCommand, "Police_Dept_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Dept_Name", DbType.String, this._Police_Dept_Name);

            if (string.IsNullOrEmpty(this._Police_Phone))
                db.AddInParameter(dbCommand, "Police_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Phone", DbType.String, this._Police_Phone);

            if (string.IsNullOrEmpty(this._Police_Contact_First_Name))
                db.AddInParameter(dbCommand, "Police_Contact_First_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Contact_First_Name", DbType.String, this._Police_Contact_First_Name);

            if (string.IsNullOrEmpty(this._Police_Contact_Middle_name))
                db.AddInParameter(dbCommand, "Police_Contact_Middle_name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Contact_Middle_name", DbType.String, this._Police_Contact_Middle_name);

            if (string.IsNullOrEmpty(this._Police_Contact_Last_Name))
                db.AddInParameter(dbCommand, "Police_Contact_Last_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Contact_Last_Name", DbType.String, this._Police_Contact_Last_Name);

            if (string.IsNullOrEmpty(this._Badge_Number))
                db.AddInParameter(dbCommand, "Badge_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Badge_Number", DbType.String, this._Badge_Number);

            if (string.IsNullOrEmpty(this._Facsimile))
                db.AddInParameter(dbCommand, "Facsimile", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Facsimile", DbType.String, this._Facsimile);

            if (string.IsNullOrEmpty(this._Police_Contact_Cell_Phone))
                db.AddInParameter(dbCommand, "Police_Contact_Cell_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Contact_Cell_Phone", DbType.String, this._Police_Contact_Cell_Phone);

            if (string.IsNullOrEmpty(this._Address_1))
                db.AddInParameter(dbCommand, "Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_1", DbType.String, this._Address_1);

            if (string.IsNullOrEmpty(this._Jurisdiction))
                db.AddInParameter(dbCommand, "Jurisdiction", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Jurisdiction", DbType.String, this._Jurisdiction);

            if (string.IsNullOrEmpty(this._Address_2))
                db.AddInParameter(dbCommand, "Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Address_2", DbType.String, this._Address_2);

            if (string.IsNullOrEmpty(this._Police_Report_Number))
                db.AddInParameter(dbCommand, "Police_Report_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Report_Number", DbType.String, this._Police_Report_Number);

            if (string.IsNullOrEmpty(this._Police_Contact_City))
                db.AddInParameter(dbCommand, "Police_Contact_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Contact_City", DbType.String, this._Police_Contact_City);

            db.AddInParameter(dbCommand, "FK_LU_Police_Dept_State", DbType.Decimal, this._FK_LU_Police_Dept_State);

            if (string.IsNullOrEmpty(this._ZIP))
                db.AddInParameter(dbCommand, "ZIP", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ZIP", DbType.String, this._ZIP);

            if (string.IsNullOrEmpty(this._Case_Number))
                db.AddInParameter(dbCommand, "Case_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Case_Number", DbType.String, this._Case_Number);

            db.AddInParameter(dbCommand, "Report_Ordered_Date", DbType.DateTime, this._Report_Ordered_Date);

            db.AddInParameter(dbCommand, "Report_Recieved_Date", DbType.DateTime, this._Report_Recieved_Date);

            db.AddInParameter(dbCommand, "FK_Incident", DbType.Decimal, this._FK_Incident);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Event_Desc))
                db.AddInParameter(dbCommand, "Event_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Desc", DbType.String, this._Event_Desc);

            db.AddInParameter(dbCommand, "FK_LU_Event_Description", DbType.Decimal, this._FK_LU_Event_Description);

            if (string.IsNullOrEmpty(this._Sonic_Event))
                db.AddInParameter(dbCommand, "Sonic_Event", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_Event", DbType.String, this._Sonic_Event);

            if (string.IsNullOrEmpty(this._Camera_Name))
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Name", DbType.String, this._Camera_Name);

            if (string.IsNullOrEmpty(this._Camera_Number))
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Camera_Number", DbType.String, this._Camera_Number);

            db.AddInParameter(dbCommand, "FK_LU_Company", DbType.Decimal, this._FK_LU_Company);

            if (string.IsNullOrEmpty(this._Other_Event_Type))
                db.AddInParameter(dbCommand, "Other_Event_Type", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Event_Type", DbType.String, this._Other_Event_Type);

            if (string.IsNullOrEmpty(this._Other_Event_Desc))
                db.AddInParameter(dbCommand, "Other_Event_Desc", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Event_Desc", DbType.String, this._Other_Event_Desc);

            //db.AddInParameter(dbCommand, "FK_LU_Sonic_Event", DbType.Decimal, this._FK_LU_Sonic_Event);

            db.AddInParameter(dbCommand, "Event_Start_Date", DbType.DateTime, this._Event_Start_Date);

            db.AddInParameter(dbCommand, "Event_End_Date", DbType.DateTime, this._Event_End_Date);

            if (string.IsNullOrEmpty(this._Event_Image))
                db.AddInParameter(dbCommand, "Event_Image", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Image", DbType.String, this._Event_Image);

            if (string.IsNullOrEmpty(this._Event_Start_Time))
                db.AddInParameter(dbCommand, "Event_Start_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Start_Time", DbType.String, this._Event_Start_Time);

            if (string.IsNullOrEmpty(this._Event_End_Time))
                db.AddInParameter(dbCommand, "Event_End_Time", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_End_Time", DbType.String, this._Event_End_Time);

            if (string.IsNullOrEmpty(this._Status))
                db.AddInParameter(dbCommand, "Status", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Status", DbType.String, this._Status);

            if (string.IsNullOrEmpty(this._Investigator_Name))
                db.AddInParameter(dbCommand, "Investigator_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigator_Name", DbType.String, this._Investigator_Name);

            if (string.IsNullOrEmpty(this._Investigator_Email))
                db.AddInParameter(dbCommand, "Investigator_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigator_Email", DbType.String, this._Investigator_Email);

            if (string.IsNullOrEmpty(this._Investigator_Phone))
                db.AddInParameter(dbCommand, "Investigator_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Investigator_Phone", DbType.String, this._Investigator_Phone);

            if (string.IsNullOrEmpty(this._ACI_EventID))
                db.AddInParameter(dbCommand, "ACI_EventID", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "ACI_EventID", DbType.String, this._ACI_EventID);

            db.AddInParameter(dbCommand, "Date_Closed", DbType.DateTime, this._Date_Closed);

            if (string.IsNullOrEmpty(this._Monitoring_Hours))
                db.AddInParameter(dbCommand, "Monitoring_Hours", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Monitoring_Hours", DbType.String, this._Monitoring_Hours);

            if (string.IsNullOrEmpty(this._Source_Of_Information))
                db.AddInParameter(dbCommand, "Source_Of_Information", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Source_Of_Information", DbType.String, this._Source_Of_Information);

            db.AddInParameter(dbCommand, "FK_AL_FR", DbType.Decimal, this._FK_AL_FR);

            db.AddInParameter(dbCommand, "FK_DPD_FR", DbType.Decimal, this._FK_DPD_FR);

            db.AddInParameter(dbCommand, "FK_PL_FR", DbType.Decimal, this._FK_PL_FR);

            db.AddInParameter(dbCommand, "FK_Property_FR", DbType.Decimal, this._FK_Property_FR);

            if (string.IsNullOrEmpty(this._Event_Root_Cause))
                db.AddInParameter(dbCommand, "Event_Root_Cause", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Event_Root_Cause", DbType.String, this._Event_Root_Cause);

            if (string.IsNullOrEmpty(this._How_Event_Prevented))
                db.AddInParameter(dbCommand, "How_Event_Prevented", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "How_Event_Prevented", DbType.String, this._How_Event_Prevented);

            db.AddInParameter(dbCommand, "Financial_Loss", DbType.Decimal, this._Financial_Loss);

            if (string.IsNullOrEmpty(this._Police_Called))
                db.AddInParameter(dbCommand, "Police_Called", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Police_Called", DbType.String, this._Police_Called);

            if (string.IsNullOrEmpty(this._Agency_name))
                db.AddInParameter(dbCommand, "Agency_name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Agency_name", DbType.String, this._Agency_name);

            if (string.IsNullOrEmpty(this._Officer_Name))
                db.AddInParameter(dbCommand, "Officer_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Officer_Name", DbType.String, this._Officer_Name);

            if (string.IsNullOrEmpty(this._Officer_Phone))
                db.AddInParameter(dbCommand, "Officer_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Officer_Phone", DbType.String, this._Officer_Phone);

            if (string.IsNullOrEmpty(this._Sonic_Contact_Name))
                db.AddInParameter(dbCommand, "Sonic_Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_Contact_Name", DbType.String, this._Sonic_Contact_Name);

            if (string.IsNullOrEmpty(this._Sonic_Contact_Phone))
                db.AddInParameter(dbCommand, "Sonic_Contact_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_Contact_Phone", DbType.String, this._Sonic_Contact_Phone);

            if (string.IsNullOrEmpty(this._Sonic_Contact_Email))
                db.AddInParameter(dbCommand, "Sonic_Contact_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sonic_Contact_Email", DbType.String, this._Sonic_Contact_Email);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Event table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EventDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Event", DbType.Decimal, pK_Event);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Search Event Record 
        /// </summary>
        /// <param name="Company"></param>
        /// <param name="City"></param>
        /// <param name="Country"></param>
        /// <param name="EventNumber"></param>
        /// <param name="CameraNumber"></param>
        /// <param name="AlarmNumber"></param>
        /// <param name="Operator"></param>
        /// <param name="FK_LU_State"></param>
        /// <param name="FK_LU_Location"></param>
        /// <param name="FK_LU_Event_Type"></param>
        /// <param name="FK_LU_Camera_Type"></param>
        /// <param name="FK_LU_Alarm_Type"></param>
        /// <param name="Photo_Date_From"></param>
        /// <param name="Photo_Date_To"></param>
        /// <param name="Alarm_Time_From"></param>
        /// <param name="Alarm_Time_To"></param>
        /// <param name="Investigation_Report_Date_From"></param>
        /// <param name="Investigation_Report_Date_To"></param>
        /// <param name="Event_Report_Date_From"></param>
        /// <param name="Event_Report_Date_To"></param>
        /// <param name="strOrderBy"></param>
        /// <param name="strOrder"></param>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public static DataSet EventSearch(string Company, string City, string Country, string EventNumber, string CameraNumber, string AlarmNumber, string Operator,
            decimal? FK_LU_State, decimal? FK_LU_Location, decimal? FK_LU_Event_Type, decimal? FK_LU_Camera_Type, decimal? FK_LU_Alarm_Type,
            DateTime? Photo_Date_From, DateTime? Photo_Date_To, DateTime? Alarm_Time_From, DateTime? Alarm_Time_To, DateTime? Investigation_Report_Date_From, DateTime? Investigation_Report_Date_To,
            DateTime? Event_Report_Date_From, DateTime? Event_Report_Date_To, string strOrderBy, string strOrder, int intPageNo, int intPageSize, decimal? FK_Incident, DateTime? Date_Opened,
            DateTime? Event_Occurence_Date)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EventSearch");

            db.AddInParameter(dbCommand, "Company", DbType.String, Company);
            db.AddInParameter(dbCommand, "City", DbType.String, City);
            db.AddInParameter(dbCommand, "Country", DbType.String, Country);
            db.AddInParameter(dbCommand, "EventNumber", DbType.String, EventNumber);
            db.AddInParameter(dbCommand, "CameraNumber", DbType.String, CameraNumber);
            db.AddInParameter(dbCommand, "AlarmNumber", DbType.String, AlarmNumber);
            db.AddInParameter(dbCommand, "Operator", DbType.String, Operator);
            db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, FK_LU_State);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "FK_LU_Event_Type", DbType.Decimal, FK_LU_Event_Type);
            db.AddInParameter(dbCommand, "FK_LU_Camera_Type", DbType.Decimal, FK_LU_Camera_Type);
            db.AddInParameter(dbCommand, "FK_LU_Alarm_Type", DbType.Decimal, FK_LU_Alarm_Type);
            db.AddInParameter(dbCommand, "FK_Incident", DbType.Decimal, FK_Incident);
            db.AddInParameter(dbCommand, "Photo_Date_From", DbType.DateTime, Photo_Date_From);
            db.AddInParameter(dbCommand, "Photo_Date_To", DbType.DateTime, Photo_Date_To);
            db.AddInParameter(dbCommand, "Alarm_Time_From", DbType.DateTime, Alarm_Time_From);
            db.AddInParameter(dbCommand, "Alarm_Time_To", DbType.DateTime, Alarm_Time_To);
            db.AddInParameter(dbCommand, "Investigation_Report_Date_From", DbType.DateTime, Investigation_Report_Date_From);
            db.AddInParameter(dbCommand, "Investigation_Report_Date_To", DbType.DateTime, Investigation_Report_Date_To);
            db.AddInParameter(dbCommand, "Event_Report_Date_From", DbType.DateTime, Event_Report_Date_From);
            db.AddInParameter(dbCommand, "Event_Report_Date_To", DbType.DateTime, Event_Report_Date_To);
            db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, Date_Opened);
            db.AddInParameter(dbCommand, "Event_Occurence_Date", DbType.DateTime, Event_Occurence_Date);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Search Event Record for aci
        /// </summary>
        /// <param name="Company"></param>
        /// <param name="City"></param>
        /// <param name="Country"></param>
        /// <param name="EventNumber"></param>
        /// <param name="CameraNumber"></param>
        /// <param name="AlarmNumber"></param>
        /// <param name="Operator"></param>
        /// <param name="FK_LU_State"></param>
        /// <param name="FK_LU_Location"></param>
        /// <param name="FK_LU_Event_Type"></param>
        /// <param name="FK_LU_Camera_Type"></param>
        /// <param name="FK_LU_Alarm_Type"></param>
        /// <param name="Photo_Date_From"></param>
        /// <param name="Photo_Date_To"></param>
        /// <param name="Alarm_Time_From"></param>
        /// <param name="Alarm_Time_To"></param>
        /// <param name="Investigation_Report_Date_From"></param>
        /// <param name="Investigation_Report_Date_To"></param>
        /// <param name="Event_Report_Date_From"></param>
        /// <param name="Event_Report_Date_To"></param>
        /// <param name="strOrderBy"></param>
        /// <param name="strOrder"></param>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public static DataSet EventSearch(string Company, string City, string Country, string EventNumber, string CameraNumber, string AlarmNumber, string Operator,
            decimal? FK_LU_State, decimal? FK_LU_Location, decimal? FK_LU_Event_Type, decimal? FK_LU_Camera_Type, decimal? FK_LU_Alarm_Type,
            DateTime? Photo_Date_From, DateTime? Photo_Date_To, DateTime? Alarm_Time_From, DateTime? Alarm_Time_To, DateTime? Investigation_Report_Date_From, DateTime? Investigation_Report_Date_To,
            DateTime? Event_Report_Date_From, DateTime? Event_Report_Date_To, string strOrderBy, string strOrder, int intPageNo, int intPageSize, decimal? FK_Incident, decimal? PK_Event, DateTime? Date_Opened,
            DateTime? Event_Occurence_Date, string CameraName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_EventSearch");

            db.AddInParameter(dbCommand, "Company", DbType.String, Company);
            db.AddInParameter(dbCommand, "City", DbType.String, City);
            db.AddInParameter(dbCommand, "Country", DbType.String, Country);
            db.AddInParameter(dbCommand, "EventNumber", DbType.String, EventNumber);
            db.AddInParameter(dbCommand, "CameraNumber", DbType.String, CameraNumber);
            db.AddInParameter(dbCommand, "AlarmNumber", DbType.String, AlarmNumber);
            db.AddInParameter(dbCommand, "Operator", DbType.String, Operator);
            db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, FK_LU_State);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "FK_LU_Event_Type", DbType.Decimal, FK_LU_Event_Type);
            db.AddInParameter(dbCommand, "FK_LU_Camera_Type", DbType.Decimal, FK_LU_Camera_Type);
            db.AddInParameter(dbCommand, "FK_LU_Alarm_Type", DbType.Decimal, FK_LU_Alarm_Type);
            db.AddInParameter(dbCommand, "FK_Incident", DbType.Decimal, FK_Incident);
            db.AddInParameter(dbCommand, "PK_EVENT", DbType.Decimal, PK_Event);
            db.AddInParameter(dbCommand, "Photo_Date_From", DbType.DateTime, Photo_Date_From);
            db.AddInParameter(dbCommand, "Photo_Date_To", DbType.DateTime, Photo_Date_To);
            db.AddInParameter(dbCommand, "Alarm_Time_From", DbType.DateTime, Alarm_Time_From);
            db.AddInParameter(dbCommand, "Alarm_Time_To", DbType.DateTime, Alarm_Time_To);
            db.AddInParameter(dbCommand, "Investigation_Report_Date_From", DbType.DateTime, Investigation_Report_Date_From);
            db.AddInParameter(dbCommand, "Investigation_Report_Date_To", DbType.DateTime, Investigation_Report_Date_To);
            db.AddInParameter(dbCommand, "Event_Report_Date_From", DbType.DateTime, Event_Report_Date_From);
            db.AddInParameter(dbCommand, "Event_Report_Date_To", DbType.DateTime, Event_Report_Date_To);
            db.AddInParameter(dbCommand, "Date_Opened", DbType.DateTime, Date_Opened);
            db.AddInParameter(dbCommand, "Event_Occurence_Date", DbType.DateTime, Event_Occurence_Date);
            db.AddInParameter(dbCommand, "Camera_Name", DbType.String, CameraName);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Int32, Convert.ToInt32(clsSession.UserID));

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// #Issue 3036 New Event Search Method with paging
        /// </summary>
        /// <param name="EventNumber"></param>
        /// <param name="CameraNumber"></param>
        /// <param name="FK_LU_Location"></param>
        /// <param name="FK_LU_Event_Type"></param>
        /// <param name="CameraName"></param>
        /// <param name="Actionable_Event_Status"></param>
        /// <param name="strOrderBy"></param>
        /// <param name="strOrder"></param>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <returns></returns>
        public static DataSet EventSearch_New(string EventNumber, string CameraNumber, decimal? FK_LU_Location, decimal? FK_LU_Event_Type, string CameraName, string Actionable_Event_Status,
                                                      string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EventSearch_New");

            db.AddInParameter(dbCommand, "EventNumber", DbType.String, EventNumber);
            db.AddInParameter(dbCommand, "CameraNumber", DbType.String, CameraNumber);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, FK_LU_Location);
            db.AddInParameter(dbCommand, "FK_LU_Event_Type", DbType.Decimal, FK_LU_Event_Type);
            db.AddInParameter(dbCommand, "Camera_Name", DbType.String, CameraName);
            db.AddInParameter(dbCommand, "Actinable_Event_Status", DbType.String, Actionable_Event_Status);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            dbCommand.CommandTimeout = 10000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Check if Alarm is exist or not for Event
        /// </summary>
        /// <param name="pK_Event"></param>
        /// <returns></returns>
        public static DataSet IsValidToDelete(decimal pK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Event_IsValidToDelete");
            db.AddInParameter(dbCommand, "PK_Event", DbType.Decimal, pK_Event);
          
            db.ExecuteNonQuery(dbCommand);
            return db.ExecuteDataSet(dbCommand);
            //return Convert.ToBoolean(dbCommand.Parameters["@bValid"].Value);
        }

        /// <summary>
        /// Get Event for event association page
        /// </summary>
        /// <param name="strSelectedEvents"></param>
        /// <returns></returns>
        public static DataSet GetEventForAssociation(string strSelectedEvents)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetEventForAssociation");
            db.AddInParameter(dbCommand, "events", DbType.String, strSelectedEvents);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Event 
        /// </summary>
        /// <param name="strSelectedEvents"></param>
        /// <returns></returns>
        public static DataSet GetACI_Report(DateTime? Event_From_Date, DateTime? Event_To_Date)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetACI_Report");

            db.AddInParameter(dbCommand, "Event_From_Date", DbType.DateTime, Event_From_Date);
            db.AddInParameter(dbCommand, "Event_To_Date", DbType.DateTime, Event_To_Date);
            dbCommand.CommandTimeout = 1000;

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get ACI Event  For Page 3 Dashboard
        /// </summary>
        /// <param name="strSelectedEvents"></param>
        /// <returns></returns>
        public static DataSet GetDashboardDataACI(int Month, int year)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetDashboardDataACI");

            db.AddInParameter(dbCommand, "Month", DbType.Int32, Month);
            db.AddInParameter(dbCommand, "year", DbType.Int32, year);
            dbCommand.CommandTimeout = 1000;

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Event
        /// </summary>
        /// <param name="strSelectedEvents"></param>
        /// <returns></returns>
        public static DataSet GetInvestigation_Images(decimal FK_Event, string Table_Name)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetInvestigation_Images");

            db.AddInParameter(dbCommand, "FK_Event", DbType.Decimal, FK_Event);
            db.AddInParameter(dbCommand, "Table_Name", DbType.String, Table_Name);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get FR Number
        /// </summary>
        /// <param name="strSelectedEvents"></param>
        /// <returns></returns>
        public static DataSet GetFR_NumberByEvent(decimal PK_Event)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetFR_NumberByEvent");

            db.AddInParameter(dbCommand, "PK_Event", DbType.Decimal, PK_Event);
            
            return db.ExecuteDataSet(dbCommand);
        }
    }
}
