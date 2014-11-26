using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Franchise table.
    /// </summary>
    public sealed class Franchise
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Franchise;
        private decimal? _FK_Building_Id;
        private DateTime? _Construction_Start;
        private decimal? _FK_LU_Franchise_Brand;
        private DateTime? _Construction_Finish;
        //private decimal? _FK_LU_Franchise_Brand_Image;
        private DateTime? _Anticipated_Completion;
        //private decimal? _FK_LU_Franchise_Plans_Submitted;
        //private decimal? _FK_LU_Franchise_Additional_Land;
        //private decimal? _FK_LU_Franchise_Permit_Secured;
        private DateTime? _Franchise_Renewal_Date;
        //private decimal? _FK_LU_Franchise_Option_1;
        //private DateTime? _Franchise_Option_1;
        //private decimal? _FK_LU_Franchise_Option_2;
        //private DateTime? _Franchise_Option_2;
        //private decimal? _FK_LU_Franchise_Option_3;
        //private DateTime? _Franchise_Option_3;
        //private decimal? _FK_LU_Franchise_Option_4;
        //private DateTime? _Franchise_Option_4;
        //private decimal? _FK_LU_Franchise_Option_5;
        //private DateTime? _Franchise_Option_5;
        private string _Renewal_Options;
        private string _Scope_of_Improvements;
        private string _Additional_Notes;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private decimal? _Proposed_Improvements_Costs;
        private string _Additional_Land_Comments;
        private DateTime? _Plans_Submitted_for_Approval;
        private DateTime? _Signage_Ordered;

        private DateTime? _Permit_Secured;
        #endregion

        #region Public Property
        public DateTime? Permit_Secured
        {
            get { return _Permit_Secured; }
            set { _Permit_Secured = value; }
        }
        public DateTime? Plans_Submitted_for_Approval
        {
            get { return _Plans_Submitted_for_Approval; }
            set { _Plans_Submitted_for_Approval = value; }
        }

        public string Additional_Land_Comments
        {
            get { return _Additional_Land_Comments; }
            set { _Additional_Land_Comments = value; }
        }
        /// <summary>
        /// Gets or sets the PK_Franchise value.
        /// </summary>
        public decimal? PK_Franchise
        {
            get { return _PK_Franchise; }
            set { _PK_Franchise = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Building_Id value.
        /// </summary>
        public decimal? FK_Building_Id
        {
            get { return _FK_Building_Id; }
            set { _FK_Building_Id = value; }
        }

        /// <summary>
        /// Gets or sets the Construction_Start value.
        /// </summary>
        public DateTime? Construction_Start
        {
            get { return _Construction_Start; }
            set { _Construction_Start = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Franchise_Brand value.
        /// </summary>
        public decimal? FK_LU_Franchise_Brand
        {
            get { return _FK_LU_Franchise_Brand; }
            set { _FK_LU_Franchise_Brand = value; }
        }

        /// <summary>
        /// Gets or sets the Construction_Finish value.
        /// </summary>
        public DateTime? Construction_Finish
        {
            get { return _Construction_Finish; }
            set { _Construction_Finish = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Franchise_Brand_Image value.
        /// </summary>
        //public decimal? FK_LU_Franchise_Brand_Image
        //{
        //    get { return _FK_LU_Franchise_Brand_Image; }
        //    set { _FK_LU_Franchise_Brand_Image = value; }
        //}

        /// <summary>
        /// Gets or sets the Anticipated_Completion value.
        /// </summary>
        public DateTime? Anticipated_Completion
        {
            get { return _Anticipated_Completion; }
            set { _Anticipated_Completion = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Franchise_Plans_Submitted value.
        /// </summary>
        //public decimal? FK_LU_Franchise_Plans_Submitted
        //{
        //    get { return _FK_LU_Franchise_Plans_Submitted; }
        //    set { _FK_LU_Franchise_Plans_Submitted = value; }
        //}

        ///// <summary>
        ///// Gets or sets the FK_LU_Franchise_Additional_Land value.
        ///// </summary>
        //public decimal? FK_LU_Franchise_Additional_Land
        //{
        //    get { return _FK_LU_Franchise_Additional_Land; }
        //    set { _FK_LU_Franchise_Additional_Land = value; }
        //}

        ///// <summary>
        ///// Gets or sets the FK_LU_Franchise_Permit_Secured value.
        ///// </summary>
        //public decimal? FK_LU_Franchise_Permit_Secured
        //{
        //    get { return _FK_LU_Franchise_Permit_Secured; }
        //    set { _FK_LU_Franchise_Permit_Secured = value; }
        //}

        /// <summary>
        /// Gets or sets the Franchise_Renewal_Date value.
        /// </summary>
        public DateTime? Franchise_Renewal_Date
        {
            get { return _Franchise_Renewal_Date; }
            set { _Franchise_Renewal_Date = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Franchise_Option_1 value.
        /// </summary>
        //public decimal? FK_LU_Franchise_Option_1
        //{
        //    get { return _FK_LU_Franchise_Option_1; }
        //    set { _FK_LU_Franchise_Option_1 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Franchise_Option_1 value.
        ///// </summary>
        //public DateTime? Franchise_Option_1
        //{
        //    get { return _Franchise_Option_1; }
        //    set { _Franchise_Option_1 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the FK_LU_Franchise_Option_2 value.
        ///// </summary>
        //public decimal? FK_LU_Franchise_Option_2
        //{
        //    get { return _FK_LU_Franchise_Option_2; }
        //    set { _FK_LU_Franchise_Option_2 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Franchise_Option_2 value.
        ///// </summary>
        //public DateTime? Franchise_Option_2
        //{
        //    get { return _Franchise_Option_2; }
        //    set { _Franchise_Option_2 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the FK_LU_Franchise_Option_3 value.
        ///// </summary>
        //public decimal? FK_LU_Franchise_Option_3
        //{
        //    get { return _FK_LU_Franchise_Option_3; }
        //    set { _FK_LU_Franchise_Option_3 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Franchise_Option_3 value.
        ///// </summary>
        //public DateTime? Franchise_Option_3
        //{
        //    get { return _Franchise_Option_3; }
        //    set { _Franchise_Option_3 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the FK_LU_Franchise_Option_4 value.
        ///// </summary>
        //public decimal? FK_LU_Franchise_Option_4
        //{
        //    get { return _FK_LU_Franchise_Option_4; }
        //    set { _FK_LU_Franchise_Option_4 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Franchise_Option_4 value.
        ///// </summary>
        //public DateTime? Franchise_Option_4
        //{
        //    get { return _Franchise_Option_4; }
        //    set { _Franchise_Option_4 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the FK_LU_Franchise_Option_5 value.
        ///// </summary>
        //public decimal? FK_LU_Franchise_Option_5
        //{
        //    get { return _FK_LU_Franchise_Option_5; }
        //    set { _FK_LU_Franchise_Option_5 = value; }
        //}

        ///// <summary>
        ///// Gets or sets the Franchise_Option_5 value.
        ///// </summary>
        //public DateTime? Franchise_Option_5
        //{
        //    get { return _Franchise_Option_5; }
        //    set { _Franchise_Option_5 = value; }
        //}

        /// <summary>
        /// Gets or sets the Renewal_Options value.
        /// </summary>
        public string Renewal_Options
        {
            get { return _Renewal_Options; }
            set { _Renewal_Options = value; }
        }

        /// <summary>
        /// Gets or sets the Scope_of_Improvements value.
        /// </summary>
        public string Scope_of_Improvements
        {
            get { return _Scope_of_Improvements; }
            set { _Scope_of_Improvements = value; }
        }

        /// <summary>
        /// Gets or sets the Additional_Notes value.
        /// </summary>
        public string Additional_Notes
        {
            get { return _Additional_Notes; }
            set { _Additional_Notes = value; }
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

        public DateTime? Signage_Ordered
        {
            get { return _Signage_Ordered; }
            set { _Signage_Ordered = value; }
        }

        /// <summary>
        /// Gets or sets the Proposed_Improvements_Costs value.
        /// </summary>
        public decimal? Proposed_Improvements_Costs
        {
            get { return _Proposed_Improvements_Costs; }
            set { _Proposed_Improvements_Costs = value; }
        }


        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Franchise class with default value.
        /// </summary>
        public Franchise()
        {

            this._PK_Franchise = null;
            this._FK_Building_Id = null;
            this._Construction_Start = null;
            this._FK_LU_Franchise_Brand = null;
            this._Construction_Finish = null;
            //this._FK_LU_Franchise_Brand_Image = null;
            this._Anticipated_Completion = null;
            //this._FK_LU_Franchise_Plans_Submitted = null;
            //this._FK_LU_Franchise_Additional_Land = null;
            //this._FK_LU_Franchise_Permit_Secured = null;
            this._Franchise_Renewal_Date = null;
            //this._FK_LU_Franchise_Option_1 = null;
            //this._Franchise_Option_1 = null;
            //this._FK_LU_Franchise_Option_2 = null;
            //this._Franchise_Option_2 = null;
            //this._FK_LU_Franchise_Option_3 = null;
            //this._Franchise_Option_3 = null;
            //this._FK_LU_Franchise_Option_4 = null;
            //this._Franchise_Option_4 = null;
            //this._FK_LU_Franchise_Option_5 = null;
            //this._Franchise_Option_5 = null;
            this._Renewal_Options = null;
            this._Scope_of_Improvements = null;
            this._Additional_Notes = null;
            this._Updated_By = null;
            this._Update_Date = null;
            this._Proposed_Improvements_Costs = null;
            this._Signage_Ordered = null;
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Franchise class based on Primary Key.
        /// </summary>
        public Franchise(decimal pK_Franchise)
        {
            DataTable dtFranchise = SelectByPK(pK_Franchise).Tables[0];

            if (dtFranchise.Rows.Count == 1)
            {
                DataRow drFranchise = dtFranchise.Rows[0];
                if (drFranchise["PK_Franchise"] == DBNull.Value)
                    this._PK_Franchise = null;
                else
                    this._PK_Franchise = (decimal?)drFranchise["PK_Franchise"];

                if (drFranchise["FK_Building_Id"] == DBNull.Value)
                    this._FK_Building_Id = null;
                else
                    this._FK_Building_Id = (decimal?)drFranchise["FK_Building_Id"];

                if (drFranchise["Construction_Start"] == DBNull.Value)
                    this._Construction_Start = null;
                else
                    this._Construction_Start = (DateTime?)drFranchise["Construction_Start"];

                if (drFranchise["FK_LU_Franchise_Brand"] == DBNull.Value)
                    this._FK_LU_Franchise_Brand = null;
                else
                    this._FK_LU_Franchise_Brand = (decimal?)drFranchise["FK_LU_Franchise_Brand"];

                if (drFranchise["Construction_Finish"] == DBNull.Value)
                    this._Construction_Finish = null;
                else
                    this._Construction_Finish = (DateTime?)drFranchise["Construction_Finish"];

                //if (drFranchise["FK_LU_Franchise_Brand_Image"] == DBNull.Value)
                //    this._FK_LU_Franchise_Brand_Image = null;
                //else
                //    this._FK_LU_Franchise_Brand_Image = (decimal?)drFranchise["FK_LU_Franchise_Brand_Image"];

                if (drFranchise["Anticipated_Completion"] == DBNull.Value)
                    this._Anticipated_Completion = null;
                else
                    this._Anticipated_Completion = (DateTime?)drFranchise["Anticipated_Completion"];

                //if (drFranchise["FK_LU_Franchise_Plans_Submitted"] == DBNull.Value)
                //    this._FK_LU_Franchise_Plans_Submitted = null;
                //else
                //    this._FK_LU_Franchise_Plans_Submitted = (decimal?)drFranchise["FK_LU_Franchise_Plans_Submitted"];

                //if (drFranchise["FK_LU_Franchise_Additional_Land"] == DBNull.Value)
                //    this._FK_LU_Franchise_Additional_Land = null;
                //else
                //    this._FK_LU_Franchise_Additional_Land = (decimal?)drFranchise["FK_LU_Franchise_Additional_Land"];

                //if (drFranchise["FK_LU_Franchise_Permit_Secured"] == DBNull.Value)
                //    this._FK_LU_Franchise_Permit_Secured = null;
                //else
                //    this._FK_LU_Franchise_Permit_Secured = (decimal?)drFranchise["FK_LU_Franchise_Permit_Secured"];

                if (drFranchise["Franchise_Renewal_Date"] == DBNull.Value)
                    this._Franchise_Renewal_Date = null;
                else
                    this._Franchise_Renewal_Date = (DateTime?)drFranchise["Franchise_Renewal_Date"];

                //if (drFranchise["FK_LU_Franchise_Option_1"] == DBNull.Value)
                //    this._FK_LU_Franchise_Option_1 = null;
                //else
                //    this._FK_LU_Franchise_Option_1 = (decimal?)drFranchise["FK_LU_Franchise_Option_1"];

                //if (drFranchise["Franchise_Option_1"] == DBNull.Value)
                //    this._Franchise_Option_1 = null;
                //else
                //    this._Franchise_Option_1 = (DateTime?)drFranchise["Franchise_Option_1"];

                //if (drFranchise["FK_LU_Franchise_Option_2"] == DBNull.Value)
                //    this._FK_LU_Franchise_Option_2 = null;
                //else
                //    this._FK_LU_Franchise_Option_2 = (decimal?)drFranchise["FK_LU_Franchise_Option_2"];

                //if (drFranchise["Franchise_Option_2"] == DBNull.Value)
                //    this._Franchise_Option_2 = null;
                //else
                //    this._Franchise_Option_2 = (DateTime?)drFranchise["Franchise_Option_2"];

                //if (drFranchise["FK_LU_Franchise_Option_3"] == DBNull.Value)
                //    this._FK_LU_Franchise_Option_3 = null;
                //else
                //    this._FK_LU_Franchise_Option_3 = (decimal?)drFranchise["FK_LU_Franchise_Option_3"];

                //if (drFranchise["Franchise_Option_3"] == DBNull.Value)
                //    this._Franchise_Option_3 = null;
                //else
                //    this._Franchise_Option_3 = (DateTime?)drFranchise["Franchise_Option_3"];

                //if (drFranchise["FK_LU_Franchise_Option_4"] == DBNull.Value)
                //    this._FK_LU_Franchise_Option_4 = null;
                //else
                //    this._FK_LU_Franchise_Option_4 = (decimal?)drFranchise["FK_LU_Franchise_Option_4"];

                //if (drFranchise["Franchise_Option_4"] == DBNull.Value)
                //    this._Franchise_Option_4 = null;
                //else
                //    this._Franchise_Option_4 = (DateTime?)drFranchise["Franchise_Option_4"];

                //if (drFranchise["FK_LU_Franchise_Option_5"] == DBNull.Value)
                //    this._FK_LU_Franchise_Option_5 = null;
                //else
                //    this._FK_LU_Franchise_Option_5 = (decimal?)drFranchise["FK_LU_Franchise_Option_5"];

                //if (drFranchise["Franchise_Option_5"] == DBNull.Value)
                //    this._Franchise_Option_5 = null;
                //else
                //    this._Franchise_Option_5 = (DateTime?)drFranchise["Franchise_Option_5"];

                if (drFranchise["Renewal_Options"] == DBNull.Value)
                    this._Renewal_Options = null;
                else
                    this._Renewal_Options = (string)drFranchise["Renewal_Options"];

                if (drFranchise["Scope_of_Improvements"] == DBNull.Value)
                    this._Scope_of_Improvements = null;
                else
                    this._Scope_of_Improvements = (string)drFranchise["Scope_of_Improvements"];

                if (drFranchise["Additional_Notes"] == DBNull.Value)
                    this._Additional_Notes = null;
                else
                    this._Additional_Notes = (string)drFranchise["Additional_Notes"];

                if (drFranchise["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drFranchise["Updated_By"];

                if (drFranchise["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drFranchise["Update_Date"];

                if (drFranchise["Proposed_Improvements_Costs"] == DBNull.Value)
                    this._Proposed_Improvements_Costs = null;
                else
                    this._Proposed_Improvements_Costs = (decimal?)drFranchise["Proposed_Improvements_Costs"];

                if (drFranchise["Additional_Land_Comments"] == DBNull.Value)
                    this._Additional_Land_Comments = null;
                else
                    this._Additional_Land_Comments = (string)drFranchise["Additional_Land_Comments"];

                if (drFranchise["Plans_Submitted_for_Approval"] == DBNull.Value)
                    this._Plans_Submitted_for_Approval = null;
                else
                    this._Plans_Submitted_for_Approval = (DateTime?)drFranchise["Plans_Submitted_for_Approval"];

                if (drFranchise["Permit_Secured"] == DBNull.Value)
                    this._Permit_Secured = null;
                else
                    this._Permit_Secured = (DateTime?)drFranchise["Permit_Secured"];

                if (drFranchise["Signage_Ordered"] == DBNull.Value)
                    this._Signage_Ordered = null;
                else
                    this._Signage_Ordered = (DateTime?)drFranchise["Signage_Ordered"];

            }
            else
            {
                this._PK_Franchise = null;
                this._FK_Building_Id = null;
                this._Construction_Start = null;
                this._FK_LU_Franchise_Brand = null;
                this._Construction_Finish = null;
                // this._FK_LU_Franchise_Brand_Image = null;
                this._Anticipated_Completion = null;
                //this._FK_LU_Franchise_Plans_Submitted = null;
                //this._FK_LU_Franchise_Additional_Land = null;
                //this._FK_LU_Franchise_Permit_Secured = null;
                this._Franchise_Renewal_Date = null;
                //this._FK_LU_Franchise_Option_1 = null;
                //this._Franchise_Option_1 = null;
                //this._FK_LU_Franchise_Option_2 = null;
                //this._Franchise_Option_2 = null;
                //this._FK_LU_Franchise_Option_3 = null;
                //this._Franchise_Option_3 = null;
                //this._FK_LU_Franchise_Option_4 = null;
                //this._Franchise_Option_4 = null;
                //this._FK_LU_Franchise_Option_5 = null;
                //this._Franchise_Option_5 = null;
                this._Renewal_Options = null;
                this._Scope_of_Improvements = null;
                this._Additional_Notes = null;
                this._Updated_By = null;
                this._Update_Date = null;
                this._Proposed_Improvements_Costs = null;
                this._Additional_Land_Comments = null;
                this._Permit_Secured = null;
                this._Plans_Submitted_for_Approval = null;
                this._Signage_Ordered = null;
            }
        }

        #endregion

        /// <summary>
        /// Inserts a record into the Franchise table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FranchiseInsert");


            db.AddInParameter(dbCommand, "FK_Building_Id", DbType.Decimal, this._FK_Building_Id);

            db.AddInParameter(dbCommand, "Construction_Start", DbType.DateTime, this._Construction_Start);

            db.AddInParameter(dbCommand, "FK_LU_Franchise_Brand", DbType.Decimal, this._FK_LU_Franchise_Brand);

            db.AddInParameter(dbCommand, "Construction_Finish", DbType.DateTime, this._Construction_Finish);
           
            db.AddInParameter(dbCommand, "Anticipated_Completion", DbType.DateTime, this._Anticipated_Completion);           

            db.AddInParameter(dbCommand, "Franchise_Renewal_Date", DbType.DateTime, this._Franchise_Renewal_Date);           

            if (string.IsNullOrEmpty(this._Renewal_Options))
                db.AddInParameter(dbCommand, "Renewal_Options", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Renewal_Options", DbType.String, this._Renewal_Options);

            if (string.IsNullOrEmpty(this._Scope_of_Improvements))
                db.AddInParameter(dbCommand, "Scope_of_Improvements", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Scope_of_Improvements", DbType.String, this._Scope_of_Improvements);

            if (string.IsNullOrEmpty(this._Additional_Notes))
                db.AddInParameter(dbCommand, "Additional_Notes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_Notes", DbType.String, this._Additional_Notes);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "Proposed_Improvements_Costs", DbType.Decimal, this._Proposed_Improvements_Costs);

            if (string.IsNullOrEmpty(this._Additional_Land_Comments))
                db.AddInParameter(dbCommand, "Additional_Land_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_Land_Comments", DbType.String, this._Additional_Land_Comments);
            // Execute the query and return the new identity value

            db.AddInParameter(dbCommand, "Plans_Submitted_for_Approval", DbType.DateTime, this._Plans_Submitted_for_Approval);
            db.AddInParameter(dbCommand, "Permit_Secured", DbType.DateTime, this._Permit_Secured);
            db.AddInParameter(dbCommand, "Signage_Ordered", DbType.DateTime, this._Signage_Ordered);

            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Franchise table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_Franchise)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FranchiseSelectByPK");

            db.AddInParameter(dbCommand, "PK_Franchise", DbType.Decimal, pK_Franchise);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Franchise table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FranchiseSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Franchise table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FranchiseUpdate");


            db.AddInParameter(dbCommand, "PK_Franchise", DbType.Decimal, this._PK_Franchise);

            db.AddInParameter(dbCommand, "FK_Building_Id", DbType.Decimal, this._FK_Building_Id);

            db.AddInParameter(dbCommand, "Construction_Start", DbType.DateTime, this._Construction_Start);

            db.AddInParameter(dbCommand, "FK_LU_Franchise_Brand", DbType.Decimal, this._FK_LU_Franchise_Brand);

            db.AddInParameter(dbCommand, "Construction_Finish", DbType.DateTime, this._Construction_Finish);

            //db.AddInParameter(dbCommand, "FK_LU_Franchise_Brand_Image", DbType.Decimal, this._FK_LU_Franchise_Brand_Image);

            db.AddInParameter(dbCommand, "Anticipated_Completion", DbType.DateTime, this._Anticipated_Completion);

            //db.AddInParameter(dbCommand, "FK_LU_Franchise_Plans_Submitted", DbType.Decimal, this._FK_LU_Franchise_Plans_Submitted);

            //db.AddInParameter(dbCommand, "FK_LU_Franchise_Additional_Land", DbType.Decimal, this._FK_LU_Franchise_Additional_Land);

            //db.AddInParameter(dbCommand, "FK_LU_Franchise_Permit_Secured", DbType.Decimal, this._FK_LU_Franchise_Permit_Secured);

            db.AddInParameter(dbCommand, "Franchise_Renewal_Date", DbType.DateTime, this._Franchise_Renewal_Date);

            //db.AddInParameter(dbCommand, "FK_LU_Franchise_Option_1", DbType.Decimal, this._FK_LU_Franchise_Option_1);

            //db.AddInParameter(dbCommand, "Franchise_Option_1", DbType.DateTime, this._Franchise_Option_1);

            //db.AddInParameter(dbCommand, "FK_LU_Franchise_Option_2", DbType.Decimal, this._FK_LU_Franchise_Option_2);

            //db.AddInParameter(dbCommand, "Franchise_Option_2", DbType.DateTime, this._Franchise_Option_2);

            //db.AddInParameter(dbCommand, "FK_LU_Franchise_Option_3", DbType.Decimal, this._FK_LU_Franchise_Option_3);

            //db.AddInParameter(dbCommand, "Franchise_Option_3", DbType.DateTime, this._Franchise_Option_3);

            //db.AddInParameter(dbCommand, "FK_LU_Franchise_Option_4", DbType.Decimal, this._FK_LU_Franchise_Option_4);

            //db.AddInParameter(dbCommand, "Franchise_Option_4", DbType.DateTime, this._Franchise_Option_4);

            //db.AddInParameter(dbCommand, "FK_LU_Franchise_Option_5", DbType.Decimal, this._FK_LU_Franchise_Option_5);

            //db.AddInParameter(dbCommand, "Franchise_Option_5", DbType.DateTime, this._Franchise_Option_5);

            if (string.IsNullOrEmpty(this._Renewal_Options))
                db.AddInParameter(dbCommand, "Renewal_Options", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Renewal_Options", DbType.String, this._Renewal_Options);

            if (string.IsNullOrEmpty(this._Scope_of_Improvements))
                db.AddInParameter(dbCommand, "Scope_of_Improvements", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Scope_of_Improvements", DbType.String, this._Scope_of_Improvements);

            if (string.IsNullOrEmpty(this._Additional_Notes))
                db.AddInParameter(dbCommand, "Additional_Notes", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_Notes", DbType.String, this._Additional_Notes);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "Proposed_Improvements_Costs", DbType.Decimal, this._Proposed_Improvements_Costs);

            if (string.IsNullOrEmpty(this._Additional_Land_Comments))
                db.AddInParameter(dbCommand, "Additional_Land_Comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_Land_Comments", DbType.String, this._Additional_Land_Comments);

            db.AddInParameter(dbCommand, "Plans_Submitted_for_Approval", DbType.DateTime, this._Plans_Submitted_for_Approval);
            db.AddInParameter(dbCommand, "Permit_Secured", DbType.DateTime, this._Permit_Secured);
            db.AddInParameter(dbCommand, "Signage_Ordered", DbType.DateTime, this._Signage_Ordered);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Franchise table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Franchise)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("FranchiseDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Franchise", DbType.Decimal, pK_Franchise);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Franchise table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectFranchiseByLoction(decimal FK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectFranchiseByLoction");

            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, FK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}