using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for table Facility_Construction_Maintenance_Item
    /// </summary>
    public sealed class Facility_Construction_Maintenance_Item
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Facility_Construction_Maintenance_Item;
        private decimal? _FK_Facility_Construction_Project;
        private decimal? _FK_LU_Location_ID;
        private decimal? _FK_Facility_Inspection_Item_Link;
        private decimal? _FK_Building;
        private string _Item_Number;
        private decimal? _FK_Facility_Maintenance_Type;
        private string _Title;
        private decimal? _FK_Facility_Maintenance_Status;
        private decimal? _FK_Requester;
        private string _Requester_Table;
        private string _Requester_Telephone;
        private string _Requester_Email;
        private DateTime? _Date_PCA_Ordered;
        private DateTime? _Date_PCA_Conducted;
        private decimal? _FK_PCA_Conducted_By;
        private string _PCA_Conducted_Table;
        private DateTime? _Inspection_Date;
        private decimal? _FK_Inspected_By;
        private string _Inspected_By_Table;
        private decimal? _FK_Focus_Area;
        private decimal? _FK_Facility_Inspection_Item;
        private decimal? _FK_Scope_Of_Work;
        private DateTime? _Estimated_Start_Date;
        private DateTime? _Actual_Start_Date;
        private DateTime? _Estimated_End_Date;
        private decimal? _FK_Assigned;
        private string _Assigned_Table;
        private decimal? _FK_Approved_By;
        private string _Approved_By_Table;
        private decimal? _Estimated_Amount;
        private decimal? _Proposed_Amount;
        private decimal? _Actual_Amount;
        private decimal? _Amount_Variance;
        private decimal? _FK_Firm;
        private string _FK_Contact;
        private string _Repair_Description;        
        private DateTime? _Update_Date;
        private decimal? _Updated_By;
        private decimal? _FK_LU_Maintenance_Priority;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Facility_Construction_Maintenance_Item value.
        /// </summary>
        public decimal? PK_Facility_Construction_Maintenance_Item
        {
            get { return _PK_Facility_Construction_Maintenance_Item; }
            set { _PK_Facility_Construction_Maintenance_Item = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Facility_Construction_Project value.
        /// </summary>
        public decimal? FK_Facility_Construction_Project
        {
            get { return _FK_Facility_Construction_Project; }
            set { _FK_Facility_Construction_Project = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location_ID value.
        /// </summary>
        public decimal? FK_LU_Location_ID
        {
            get { return _FK_LU_Location_ID; }
            set { _FK_LU_Location_ID = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Facility_Inspection_Item_Link value.
        /// </summary>
        public decimal? FK_Facility_Inspection_Item_Link
        {
            get { return _FK_Facility_Inspection_Item_Link; }
            set { _FK_Facility_Inspection_Item_Link = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Building value.
        /// </summary>
        public decimal? FK_Building
        {
            get { return _FK_Building; }
            set { _FK_Building = value; }
        }

        /// <summary>
        /// Gets or sets the Item_Number value.
        /// </summary>
        public string Item_Number
        {
            get { return _Item_Number; }
            set { _Item_Number = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Facility_Maintenance_Type value.
        /// </summary>
        public decimal? FK_Facility_Maintenance_Type
        {
            get { return _FK_Facility_Maintenance_Type; }
            set { _FK_Facility_Maintenance_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Title value.
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Facility_Maintenance_Status value.
        /// </summary>
        public decimal? FK_Facility_Maintenance_Status
        {
            get { return _FK_Facility_Maintenance_Status; }
            set { _FK_Facility_Maintenance_Status = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Requester value.
        /// </summary>
        public decimal? FK_Requester
        {
            get { return _FK_Requester; }
            set { _FK_Requester = value; }
        }

        /// <summary>
        /// Gets or sets the Requester_Table value.
        /// </summary>
        public string Requester_Table
        {
            get { return _Requester_Table; }
            set { _Requester_Table = value; }
        }

        /// <summary>
        /// Gets or sets the Requester_Telephone value.
        /// </summary>
        public string Requester_Telephone
        {
            get { return _Requester_Telephone; }
            set { _Requester_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Requester_Email value.
        /// </summary>
        public string Requester_Email
        {
            get { return _Requester_Email; }
            set { _Requester_Email = value; }
        }

        /// <summary>
        /// Gets or sets the Date_PCA_Ordered value.
        /// </summary>
        public DateTime? Date_PCA_Ordered
        {
            get { return _Date_PCA_Ordered; }
            set { _Date_PCA_Ordered = value; }
        }

        /// <summary>
        /// Gets or sets the Date_PCA_Conducted value.
        /// </summary>
        public DateTime? Date_PCA_Conducted
        {
            get { return _Date_PCA_Conducted; }
            set { _Date_PCA_Conducted = value; }
        }

        /// <summary>
        /// Gets or sets the FK_PCA_Conducted_By value.
        /// </summary>
        public decimal? FK_PCA_Conducted_By
        {
            get { return _FK_PCA_Conducted_By; }
            set { _FK_PCA_Conducted_By = value; }
        }

        /// <summary>
        /// Gets or sets the PCA_Conducted_Table value.
        /// </summary>
        public string PCA_Conducted_Table
        {
            get { return _PCA_Conducted_Table; }
            set { _PCA_Conducted_Table = value; }
        }

        /// <summary>
        /// Gets or sets the Inspection_Date value.
        /// </summary>
        public DateTime? Inspection_Date
        {
            get { return _Inspection_Date; }
            set { _Inspection_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Inspected_By value.
        /// </summary>
        public decimal? FK_Inspected_By
        {
            get { return _FK_Inspected_By; }
            set { _FK_Inspected_By = value; }
        }

        /// <summary>
        /// Gets or sets the Inspected_By_Table value.
        /// </summary>
        public string Inspected_By_Table
        {
            get { return _Inspected_By_Table; }
            set { _Inspected_By_Table = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Focus_Area value.
        /// </summary>
        public decimal? FK_Focus_Area
        {
            get { return _FK_Focus_Area; }
            set { _FK_Focus_Area = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Facility_Inspection_Item value.
        /// </summary>
        public decimal? FK_Facility_Inspection_Item
        {
            get { return _FK_Facility_Inspection_Item; }
            set { _FK_Facility_Inspection_Item = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Scope_Of_Work value.
        /// </summary>
        public decimal? FK_Scope_Of_Work
        {
            get { return _FK_Scope_Of_Work; }
            set { _FK_Scope_Of_Work = value; }
        }

        /// <summary>
        /// Gets or sets the Estimated_Start_Date value.
        /// </summary>
        public DateTime? Estimated_Start_Date
        {
            get { return _Estimated_Start_Date; }
            set { _Estimated_Start_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Actual_Start_Date value.
        /// </summary>
        public DateTime? Actual_Start_Date
        {
            get { return _Actual_Start_Date; }
            set { _Actual_Start_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Estimated_End_Date value.
        /// </summary>
        public DateTime? Estimated_End_Date
        {
            get { return _Estimated_End_Date; }
            set { _Estimated_End_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Assigned value.
        /// </summary>
        public decimal? FK_Assigned
        {
            get { return _FK_Assigned; }
            set { _FK_Assigned = value; }
        }

        /// <summary>
        /// Gets or sets the Assigned_Table value.
        /// </summary>
        public string Assigned_Table
        {
            get { return _Assigned_Table; }
            set { _Assigned_Table = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Approved_By value.
        /// </summary>
        public decimal? FK_Approved_By
        {
            get { return _FK_Approved_By; }
            set { _FK_Approved_By = value; }
        }

        /// <summary>
        /// Gets or sets the Approved_By_Table value.
        /// </summary>
        public string Approved_By_Table
        {
            get { return _Approved_By_Table; }
            set { _Approved_By_Table = value; }
        }

        /// <summary>
        /// Gets or sets the Estimated_Amount value.
        /// </summary>
        public decimal? Estimated_Amount
        {
            get { return _Estimated_Amount; }
            set { _Estimated_Amount = value; }
        }

        /// <summary>
        /// Gets or sets the Proposed_Amount value.
        /// </summary>
        public decimal? Proposed_Amount
        {
            get { return _Proposed_Amount; }
            set { _Proposed_Amount = value; }
        }

        /// <summary>
        /// Gets or sets the Actual_Amount value.
        /// </summary>
        public decimal? Actual_Amount
        {
            get { return _Actual_Amount; }
            set { _Actual_Amount = value; }
        }

        /// <summary>
        /// Gets or sets the Amount_Variance value.
        /// </summary>
        public decimal? Amount_Variance
        {
            get { return _Amount_Variance; }
            set { _Amount_Variance = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Firm value.
        /// </summary>
        public decimal? FK_Firm
        {
            get { return _FK_Firm; }
            set { _FK_Firm = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Contact value.
        /// </summary>
        public string FK_Contact
        {
            get { return _FK_Contact; }
            set { _FK_Contact = value; }
        }

        /// <summary>
        /// Gets or sets the Repair_Description value.
        /// </summary>
        public string Repair_Description
        {
            get { return _Repair_Description; }
            set { _Repair_Description = value; }
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
        /// Gets or sets the FK_LU_Maintenance_Priority value.
        /// </summary>
        public decimal? FK_LU_Maintenance_Priority
        {
            get { return _FK_LU_Maintenance_Priority; }
            set { _FK_LU_Maintenance_Priority = value; }
        }

        public decimal? Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Maintenance_Item class with default value.
        /// </summary>
        public Facility_Construction_Maintenance_Item()
        {


        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Maintenance_Item class based on Primary Key.
        /// </summary>
        public Facility_Construction_Maintenance_Item(decimal pK_Facility_Construction_Maintenance_Item)
        {
            DataTable dtFacility_Construction_Maintenance_Item = Select(pK_Facility_Construction_Maintenance_Item).Tables[0];

            if (dtFacility_Construction_Maintenance_Item.Rows.Count == 1)
            {
                SetValue(dtFacility_Construction_Maintenance_Item.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the Facility_Construction_Maintenance_Item class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drFacility_Construction_Maintenance_Item)
        {
            if (drFacility_Construction_Maintenance_Item["PK_Facility_Construction_Maintenance_Item"] == DBNull.Value)
                this._PK_Facility_Construction_Maintenance_Item = null;
            else
                this._PK_Facility_Construction_Maintenance_Item = (decimal?)drFacility_Construction_Maintenance_Item["PK_Facility_Construction_Maintenance_Item"];

            if (drFacility_Construction_Maintenance_Item["FK_Facility_Construction_Project"] == DBNull.Value)
                this._FK_Facility_Construction_Project = null;
            else
                this._FK_Facility_Construction_Project = (decimal?)drFacility_Construction_Maintenance_Item["FK_Facility_Construction_Project"];

            if (drFacility_Construction_Maintenance_Item["FK_LU_Location_ID"] == DBNull.Value)
                this._FK_LU_Location_ID = null;
            else
                this._FK_LU_Location_ID = (decimal?)drFacility_Construction_Maintenance_Item["FK_LU_Location_ID"];

            if (drFacility_Construction_Maintenance_Item["FK_Facility_Inspection_Item_Link"] == DBNull.Value)
                this._FK_Facility_Inspection_Item_Link = null;
            else
                this._FK_Facility_Inspection_Item_Link = (decimal?)drFacility_Construction_Maintenance_Item["FK_Facility_Inspection_Item_Link"];

            if (drFacility_Construction_Maintenance_Item["FK_Building"] == DBNull.Value)
                this._FK_Building = null;
            else
                this._FK_Building = (decimal?)drFacility_Construction_Maintenance_Item["FK_Building"];

            if (drFacility_Construction_Maintenance_Item["Item_Number"] == DBNull.Value)
                this._Item_Number = null;
            else
                this._Item_Number = (string)drFacility_Construction_Maintenance_Item["Item_Number"];

            if (drFacility_Construction_Maintenance_Item["FK_Facility_Maintenance_Type"] == DBNull.Value)
                this._FK_Facility_Maintenance_Type = null;
            else
                this._FK_Facility_Maintenance_Type = (decimal?)drFacility_Construction_Maintenance_Item["FK_Facility_Maintenance_Type"];

            if (drFacility_Construction_Maintenance_Item["Title"] == DBNull.Value)
                this._Title = null;
            else
                this._Title = (string)drFacility_Construction_Maintenance_Item["Title"];

            if (drFacility_Construction_Maintenance_Item["FK_Facility_Maintenance_Status"] == DBNull.Value)
                this._FK_Facility_Maintenance_Status = null;
            else
                this._FK_Facility_Maintenance_Status = (decimal?)drFacility_Construction_Maintenance_Item["FK_Facility_Maintenance_Status"];

            if (drFacility_Construction_Maintenance_Item["FK_LU_Maintenance_Priority"] == DBNull.Value)
                this._FK_LU_Maintenance_Priority = null;
            else
                this._FK_LU_Maintenance_Priority = (decimal?)drFacility_Construction_Maintenance_Item["FK_LU_Maintenance_Priority"];

            if (drFacility_Construction_Maintenance_Item["FK_Requester"] == DBNull.Value)
                this._FK_Requester = null;
            else
                this._FK_Requester = (decimal?)drFacility_Construction_Maintenance_Item["FK_Requester"];

            if (drFacility_Construction_Maintenance_Item["Requester_Table"] == DBNull.Value)
                this._Requester_Table = null;
            else
                this._Requester_Table = (string)drFacility_Construction_Maintenance_Item["Requester_Table"];

            if (drFacility_Construction_Maintenance_Item["Requester_Telephone"] == DBNull.Value)
                this._Requester_Telephone = null;
            else
                this._Requester_Telephone = (string)drFacility_Construction_Maintenance_Item["Requester_Telephone"];

            if (drFacility_Construction_Maintenance_Item["Requester_Email"] == DBNull.Value)
                this._Requester_Email = null;
            else
                this._Requester_Email = (string)drFacility_Construction_Maintenance_Item["Requester_Email"];

            if (drFacility_Construction_Maintenance_Item["Date_PCA_Ordered"] == DBNull.Value)
                this._Date_PCA_Ordered = null;
            else
                this._Date_PCA_Ordered = (DateTime?)drFacility_Construction_Maintenance_Item["Date_PCA_Ordered"];

            if (drFacility_Construction_Maintenance_Item["Date_PCA_Conducted"] == DBNull.Value)
                this._Date_PCA_Conducted = null;
            else
                this._Date_PCA_Conducted = (DateTime?)drFacility_Construction_Maintenance_Item["Date_PCA_Conducted"];

            if (drFacility_Construction_Maintenance_Item["FK_PCA_Conducted_By"] == DBNull.Value)
                this._FK_PCA_Conducted_By = null;
            else
                this._FK_PCA_Conducted_By = (decimal?)drFacility_Construction_Maintenance_Item["FK_PCA_Conducted_By"];

            if (drFacility_Construction_Maintenance_Item["PCA_Conducted_Table"] == DBNull.Value)
                this._PCA_Conducted_Table = null;
            else
                this._PCA_Conducted_Table = (string)drFacility_Construction_Maintenance_Item["PCA_Conducted_Table"];

            if (drFacility_Construction_Maintenance_Item["Inspection_Date"] == DBNull.Value)
                this._Inspection_Date = null;
            else
                this._Inspection_Date = (DateTime?)drFacility_Construction_Maintenance_Item["Inspection_Date"];

            if (drFacility_Construction_Maintenance_Item["FK_Inspected_By"] == DBNull.Value)
                this._FK_Inspected_By = null;
            else
                this._FK_Inspected_By = (decimal?)drFacility_Construction_Maintenance_Item["FK_Inspected_By"];

            if (drFacility_Construction_Maintenance_Item["Inspected_By_Table"] == DBNull.Value)
                this._Inspected_By_Table = null;
            else
                this._Inspected_By_Table = (string)drFacility_Construction_Maintenance_Item["Inspected_By_Table"];

            if (drFacility_Construction_Maintenance_Item["FK_Focus_Area"] == DBNull.Value)
                this._FK_Focus_Area = null;
            else
                this._FK_Focus_Area = (decimal?)drFacility_Construction_Maintenance_Item["FK_Focus_Area"];

            if (drFacility_Construction_Maintenance_Item["FK_Facility_Inspection_Item"] == DBNull.Value)
                this._FK_Facility_Inspection_Item = null;
            else
                this._FK_Facility_Inspection_Item = (decimal?)drFacility_Construction_Maintenance_Item["FK_Facility_Inspection_Item"];

            if (drFacility_Construction_Maintenance_Item["FK_Scope_Of_Work"] == DBNull.Value)
                this._FK_Scope_Of_Work = null;
            else
                this._FK_Scope_Of_Work = (decimal?)drFacility_Construction_Maintenance_Item["FK_Scope_Of_Work"];

            if (drFacility_Construction_Maintenance_Item["Estimated_Start_Date"] == DBNull.Value)
                this._Estimated_Start_Date = null;
            else
                this._Estimated_Start_Date = (DateTime?)drFacility_Construction_Maintenance_Item["Estimated_Start_Date"];

            if (drFacility_Construction_Maintenance_Item["Actual_Start_Date"] == DBNull.Value)
                this._Actual_Start_Date = null;
            else
                this._Actual_Start_Date = (DateTime?)drFacility_Construction_Maintenance_Item["Actual_Start_Date"];

            if (drFacility_Construction_Maintenance_Item["Estimated_End_Date"] == DBNull.Value)
                this._Estimated_End_Date = null;
            else
                this._Estimated_End_Date = (DateTime?)drFacility_Construction_Maintenance_Item["Estimated_End_Date"];

            if (drFacility_Construction_Maintenance_Item["FK_Assigned"] == DBNull.Value)
                this._FK_Assigned = null;
            else
                this._FK_Assigned = (decimal?)drFacility_Construction_Maintenance_Item["FK_Assigned"];

            if (drFacility_Construction_Maintenance_Item["Assigned_Table"] == DBNull.Value)
                this._Assigned_Table = null;
            else
                this._Assigned_Table = (string)drFacility_Construction_Maintenance_Item["Assigned_Table"];

            if (drFacility_Construction_Maintenance_Item["FK_Approved_By"] == DBNull.Value)
                this._FK_Approved_By = null;
            else
                this._FK_Approved_By = (decimal?)drFacility_Construction_Maintenance_Item["FK_Approved_By"];

            if (drFacility_Construction_Maintenance_Item["Approved_By_Table"] == DBNull.Value)
                this._Approved_By_Table = null;
            else
                this._Approved_By_Table = (string)drFacility_Construction_Maintenance_Item["Approved_By_Table"];

            if (drFacility_Construction_Maintenance_Item["Estimated_Amount"] == DBNull.Value)
                this._Estimated_Amount = null;
            else
                this._Estimated_Amount = (decimal?)drFacility_Construction_Maintenance_Item["Estimated_Amount"];

            if (drFacility_Construction_Maintenance_Item["Proposed_Amount"] == DBNull.Value)
                this._Proposed_Amount = null;
            else
                this._Proposed_Amount = (decimal?)drFacility_Construction_Maintenance_Item["Proposed_Amount"];

            if (drFacility_Construction_Maintenance_Item["Actual_Amount"] == DBNull.Value)
                this._Actual_Amount = null;
            else
                this._Actual_Amount = (decimal?)drFacility_Construction_Maintenance_Item["Actual_Amount"];

            if (drFacility_Construction_Maintenance_Item["Amount_Variance"] == DBNull.Value)
                this._Amount_Variance = null;
            else
                this._Amount_Variance = (decimal?)drFacility_Construction_Maintenance_Item["Amount_Variance"];

            if (drFacility_Construction_Maintenance_Item["FK_Firm"] == DBNull.Value)
                this._FK_Firm = null;
            else
                this._FK_Firm = (decimal?)drFacility_Construction_Maintenance_Item["FK_Firm"];

            if (drFacility_Construction_Maintenance_Item["FK_Contact"] == DBNull.Value)
                this._FK_Contact = null;
            else
                this._FK_Contact = (string)drFacility_Construction_Maintenance_Item["FK_Contact"];

            if (drFacility_Construction_Maintenance_Item["Repair_Description"] == DBNull.Value)
                this._Repair_Description = null;
            else
                this._Repair_Description = (string)drFacility_Construction_Maintenance_Item["Repair_Description"];            

            if (drFacility_Construction_Maintenance_Item["Update_Date"] == DBNull.Value)
                this._Update_Date = null;
            else
                this._Update_Date = (DateTime?)drFacility_Construction_Maintenance_Item["Update_Date"];
        }

        #endregion

        /// <summary>
        /// Inserts a record into the Facility_Construction_Maintenance_Item table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Maintenance_ItemInsert");


            db.AddInParameter(dbCommand, "FK_Facility_Construction_Project", DbType.Decimal, this._FK_Facility_Construction_Project);

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);

            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Item_Link", DbType.Decimal, this._FK_Facility_Inspection_Item_Link);

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);

            if (string.IsNullOrEmpty(this._Item_Number))
                db.AddInParameter(dbCommand, "Item_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_Number", DbType.String, this._Item_Number);

            db.AddInParameter(dbCommand, "FK_Facility_Maintenance_Type", DbType.Decimal, this._FK_Facility_Maintenance_Type);

            if (string.IsNullOrEmpty(this._Title))
                db.AddInParameter(dbCommand, "Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Title", DbType.String, this._Title);

            db.AddInParameter(dbCommand, "FK_Facility_Maintenance_Status", DbType.Decimal, this._FK_Facility_Maintenance_Status);

            db.AddInParameter(dbCommand, "FK_Requester", DbType.Decimal, this._FK_Requester);

            if (string.IsNullOrEmpty(this._Requester_Table))
                db.AddInParameter(dbCommand, "Requester_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Requester_Table", DbType.String, this._Requester_Table);

            if (string.IsNullOrEmpty(this._Requester_Telephone))
                db.AddInParameter(dbCommand, "Requester_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Requester_Telephone", DbType.String, this._Requester_Telephone);

            if (string.IsNullOrEmpty(this._Requester_Email))
                db.AddInParameter(dbCommand, "Requester_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Requester_Email", DbType.String, this._Requester_Email);

            db.AddInParameter(dbCommand, "Date_PCA_Ordered", DbType.DateTime, this._Date_PCA_Ordered);

            db.AddInParameter(dbCommand, "Date_PCA_Conducted", DbType.DateTime, this._Date_PCA_Conducted);

            db.AddInParameter(dbCommand, "FK_PCA_Conducted_By", DbType.Decimal, this._FK_PCA_Conducted_By);

            if (string.IsNullOrEmpty(this._PCA_Conducted_Table))
                db.AddInParameter(dbCommand, "PCA_Conducted_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "PCA_Conducted_Table", DbType.String, this._PCA_Conducted_Table);

            db.AddInParameter(dbCommand, "Inspection_Date", DbType.DateTime, this._Inspection_Date);

            db.AddInParameter(dbCommand, "FK_Inspected_By", DbType.Decimal, this._FK_Inspected_By);

            if (string.IsNullOrEmpty(this._Inspected_By_Table))
                db.AddInParameter(dbCommand, "Inspected_By_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inspected_By_Table", DbType.String, this._Inspected_By_Table);

            db.AddInParameter(dbCommand, "FK_Focus_Area", DbType.Decimal, this._FK_Focus_Area);

            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Item", DbType.Decimal, this._FK_Facility_Inspection_Item);

            db.AddInParameter(dbCommand, "FK_Scope_Of_Work", DbType.Decimal, this._FK_Scope_Of_Work);

            db.AddInParameter(dbCommand, "Estimated_Start_Date", DbType.DateTime, this._Estimated_Start_Date);

            db.AddInParameter(dbCommand, "Actual_Start_Date", DbType.DateTime, this._Actual_Start_Date);

            db.AddInParameter(dbCommand, "Estimated_End_Date", DbType.DateTime, this._Estimated_End_Date);

            db.AddInParameter(dbCommand, "FK_Assigned", DbType.Decimal, this._FK_Assigned);

            if (string.IsNullOrEmpty(this._Assigned_Table))
                db.AddInParameter(dbCommand, "Assigned_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Assigned_Table", DbType.String, this._Assigned_Table);

            db.AddInParameter(dbCommand, "FK_Approved_By", DbType.Decimal, this._FK_Approved_By);

            if (string.IsNullOrEmpty(this._Approved_By_Table))
                db.AddInParameter(dbCommand, "Approved_By_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Approved_By_Table", DbType.String, this._Approved_By_Table);

            db.AddInParameter(dbCommand, "Estimated_Amount", DbType.Decimal, this._Estimated_Amount);

            db.AddInParameter(dbCommand, "Proposed_Amount", DbType.Decimal, this._Proposed_Amount);

            db.AddInParameter(dbCommand, "Actual_Amount", DbType.Decimal, this._Actual_Amount);

            db.AddInParameter(dbCommand, "Amount_Variance", DbType.Decimal, this._Amount_Variance);

            db.AddInParameter(dbCommand, "FK_Firm", DbType.Decimal, this._FK_Firm);

            if (string.IsNullOrEmpty(this._FK_Contact))
                db.AddInParameter(dbCommand, "FK_Contact", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_Contact", DbType.String, this._FK_Contact);

            if (string.IsNullOrEmpty(this._Repair_Description))
                db.AddInParameter(dbCommand, "Repair_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Repair_Description", DbType.String, this._Repair_Description);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "FK_LU_Maintenance_Priority", DbType.Decimal, this._FK_LU_Maintenance_Priority);

            db.AddInParameter(dbCommand, "Source", DbType.String, "ERIMS");
            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Facility_Construction_Maintenance_Item table.
        /// </summary>
        /// <returns>DataSet</returns>
        private DataSet Select(decimal pK_Facility_Construction_Maintenance_Item)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Maintenance_ItemSelect");

            db.AddInParameter(dbCommand, "PK_Facility_Construction_Maintenance_Item", DbType.Decimal, pK_Facility_Construction_Maintenance_Item);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a Last Primary Key from the Facility_Construction_Maintenance_Item table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet GetLastPrimaryKey()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Maintenance_ItemGetLastPrimaryKey");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Facility_Construction_Maintenance_Item table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Maintenance_ItemSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Facility_Construction_Maintenance_Item table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Maintenance_ItemUpdate");


            db.AddInParameter(dbCommand, "PK_Facility_Construction_Maintenance_Item", DbType.Decimal, this._PK_Facility_Construction_Maintenance_Item);

            db.AddInParameter(dbCommand, "FK_Facility_Construction_Project", DbType.Decimal, this._FK_Facility_Construction_Project);

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, this._FK_LU_Location_ID);

            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Item_Link", DbType.Decimal, this._FK_Facility_Inspection_Item_Link);

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, this._FK_Building);

            if (string.IsNullOrEmpty(this._Item_Number))
                db.AddInParameter(dbCommand, "Item_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_Number", DbType.String, this._Item_Number);

            db.AddInParameter(dbCommand, "FK_Facility_Maintenance_Type", DbType.Decimal, this._FK_Facility_Maintenance_Type);

            if (string.IsNullOrEmpty(this._Title))
                db.AddInParameter(dbCommand, "Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Title", DbType.String, this._Title);

            db.AddInParameter(dbCommand, "FK_Facility_Maintenance_Status", DbType.Decimal, this._FK_Facility_Maintenance_Status);

            db.AddInParameter(dbCommand, "FK_Requester", DbType.Decimal, this._FK_Requester);

            if (string.IsNullOrEmpty(this._Requester_Table))
                db.AddInParameter(dbCommand, "Requester_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Requester_Table", DbType.String, this._Requester_Table);

            if (string.IsNullOrEmpty(this._Requester_Telephone))
                db.AddInParameter(dbCommand, "Requester_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Requester_Telephone", DbType.String, this._Requester_Telephone);

            if (string.IsNullOrEmpty(this._Requester_Email))
                db.AddInParameter(dbCommand, "Requester_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Requester_Email", DbType.String, this._Requester_Email);

            db.AddInParameter(dbCommand, "Date_PCA_Ordered", DbType.DateTime, this._Date_PCA_Ordered);

            db.AddInParameter(dbCommand, "Date_PCA_Conducted", DbType.DateTime, this._Date_PCA_Conducted);

            db.AddInParameter(dbCommand, "FK_PCA_Conducted_By", DbType.Decimal, this._FK_PCA_Conducted_By);

            if (string.IsNullOrEmpty(this._PCA_Conducted_Table))
                db.AddInParameter(dbCommand, "PCA_Conducted_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "PCA_Conducted_Table", DbType.String, this._PCA_Conducted_Table);

            db.AddInParameter(dbCommand, "Inspection_Date", DbType.DateTime, this._Inspection_Date);

            db.AddInParameter(dbCommand, "FK_Inspected_By", DbType.Decimal, this._FK_Inspected_By);

            if (string.IsNullOrEmpty(this._Inspected_By_Table))
                db.AddInParameter(dbCommand, "Inspected_By_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Inspected_By_Table", DbType.String, this._Inspected_By_Table);

            db.AddInParameter(dbCommand, "FK_Focus_Area", DbType.Decimal, this._FK_Focus_Area);

            db.AddInParameter(dbCommand, "FK_Facility_Inspection_Item", DbType.Decimal, this._FK_Facility_Inspection_Item);

            db.AddInParameter(dbCommand, "FK_Scope_Of_Work", DbType.Decimal, this._FK_Scope_Of_Work);

            db.AddInParameter(dbCommand, "Estimated_Start_Date", DbType.DateTime, this._Estimated_Start_Date);

            db.AddInParameter(dbCommand, "Actual_Start_Date", DbType.DateTime, this._Actual_Start_Date);

            db.AddInParameter(dbCommand, "Estimated_End_Date", DbType.DateTime, this._Estimated_End_Date);

            db.AddInParameter(dbCommand, "FK_Assigned", DbType.Decimal, this._FK_Assigned);

            if (string.IsNullOrEmpty(this._Assigned_Table))
                db.AddInParameter(dbCommand, "Assigned_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Assigned_Table", DbType.String, this._Assigned_Table);

            db.AddInParameter(dbCommand, "FK_Approved_By", DbType.Decimal, this._FK_Approved_By);

            if (string.IsNullOrEmpty(this._Approved_By_Table))
                db.AddInParameter(dbCommand, "Approved_By_Table", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Approved_By_Table", DbType.String, this._Approved_By_Table);

            db.AddInParameter(dbCommand, "Estimated_Amount", DbType.Decimal, this._Estimated_Amount);

            db.AddInParameter(dbCommand, "Proposed_Amount", DbType.Decimal, this._Proposed_Amount);

            db.AddInParameter(dbCommand, "Actual_Amount", DbType.Decimal, this._Actual_Amount);

            db.AddInParameter(dbCommand, "Amount_Variance", DbType.Decimal, this._Amount_Variance);

            db.AddInParameter(dbCommand, "FK_Firm", DbType.Decimal, this._FK_Firm);

            if (string.IsNullOrEmpty(this._FK_Contact))
                db.AddInParameter(dbCommand, "FK_Contact", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "FK_Contact", DbType.String, this._FK_Contact);

            if (string.IsNullOrEmpty(this._Repair_Description))
                db.AddInParameter(dbCommand, "Repair_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Repair_Description", DbType.String, this._Repair_Description);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "FK_LU_Maintenance_Priority", DbType.Decimal, this._FK_LU_Maintenance_Priority);

            db.AddInParameter(dbCommand, "Source", DbType.String, "ERIMS");

            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Facility_Construction_Maintenance_Item table.
        /// </summary>
        public void UpdateItemNumberByPrimaryKey()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Maintenance_ItemUpdateItemNumber");

            db.AddInParameter(dbCommand, "PK_Facility_Construction_Maintenance_Item", DbType.Decimal, this._PK_Facility_Construction_Maintenance_Item);

            if (string.IsNullOrEmpty(this._Item_Number))
                db.AddInParameter(dbCommand, "Item_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_Number", DbType.String, this._Item_Number);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Facility_Construction_Maintenance_Item table by a composite primary key.
        /// </summary>
        public static void Delete(decimal pK_Facility_Construction_Maintenance_Item)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Maintenance_ItemDelete");

            db.AddInParameter(dbCommand, "PK_Facility_Construction_Maintenance_Item", DbType.Decimal, pK_Facility_Construction_Maintenance_Item);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Method To bind Grid Details
        /// </summary>
        /// <param name="fK_Location"></param>
        public static DataSet GetMaintenanceDetailsByLocation(decimal fK_LU_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Facility_Construction_Maintenance_ItemGetDetailsByLocation");

            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, fK_LU_Location);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
