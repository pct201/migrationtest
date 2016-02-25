using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Building_Improvements table.
    /// </summary>
    public sealed class Building_Improvements
    {

        #region Private variables used to hold the property values

        private decimal? _PK_Building_Improvements;
        private decimal? _FK_Property_Cope;
        private string _Improvement_Description;
        private string _Service_Capacity_Increase;
        private decimal? _Revised_Square_Footage_Sales;
        private decimal? _Revised_Square_Footage_Service;
        private decimal? _Revised_Square_Footage_Parts;
        private decimal? _Revised_Square_Footage_Other;
        private decimal? _Improvement_Value;
        private DateTime? _Completion_Date;
        private string _Updated_By;
        private DateTime? _Updated_Date;
        private string _FK_Building_Ids;
        private string _Project_Number;
        private DateTime? _Start_Date;
        private DateTime? _Target_Completion_Date;
        private string _Contact_Name;
        private string _New_Build;
        private string _Open;
        private DateTime? _Project_Status_As_Of_Date;
        private decimal? _FK_LU_BI_Status;
        private string _Status_Other;
        private string _Revised_Square_Footage;
        private decimal? _Revised_Square_Footage_Service_Lane;
        private decimal? _Total_Square_Footage_Revised;
        private decimal? _Budget_Construction;
        private decimal? _Budget_Land;
        private decimal? _Budget_Misc;
        private decimal? _Budget_SubTotal_1;
        private decimal? _Budget_IT;
        private decimal? _Budget_Furniture;
        private decimal? _Budget_Equipment;
        private decimal? _Budget_Signage;
        private decimal? _Budget_SubTotal_2;
        private decimal? _Budget_Total;
        private string _Item_1;
        private string _Item_2;
        private string _Item_3;
        private string _Item_4;
        private string _Item_5;
        private string _Item_6;
        private string _Item_7;
        private int _Number_of_Havac_Before_Improvements;
        private int _Number_of_Havac_After_Improvements;
        private string _Roof_Improvement_Details;
        private string _Additional_Replace;
        private string _Other_comments;
        private decimal? _FK_Building;
        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Building_Improvements value.
        /// </summary>
        public decimal? PK_Building_Improvements
        {
            get { return _PK_Building_Improvements; }
            set { _PK_Building_Improvements = value; }
        }

        /// <summary>
        /// Gets or sets the FK_Building value.
        /// </summary>
        public decimal? FK_Property_Cope
        {
            get { return _FK_Property_Cope; }
            set { _FK_Property_Cope = value; }
        }

        /// <summary>
        /// Gets or sets the Improvement_Description value.
        /// </summary>
        public string Improvement_Description
        {
            get { return _Improvement_Description; }
            set { _Improvement_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Service_Capacity_Increase value.
        /// </summary>
        public string Service_Capacity_Increase
        {
            get { return _Service_Capacity_Increase; }
            set { _Service_Capacity_Increase = value; }
        }

        /// <summary>
        /// Gets or sets the Revised_Square_Footage_Sales value.
        /// </summary>
        public decimal? Revised_Square_Footage_Sales
        {
            get { return _Revised_Square_Footage_Sales; }
            set { _Revised_Square_Footage_Sales = value; }
        }

        /// <summary>
        /// Gets or sets the Revised_Square_Footage_Service value.
        /// </summary>
        public decimal? Revised_Square_Footage_Service
        {
            get { return _Revised_Square_Footage_Service; }
            set { _Revised_Square_Footage_Service = value; }
        }

        /// <summary>
        /// Gets or sets the Revised_Square_Footage_Parts value.
        /// </summary>
        public decimal? Revised_Square_Footage_Parts
        {
            get { return _Revised_Square_Footage_Parts; }
            set { _Revised_Square_Footage_Parts = value; }
        }

        /// <summary>
        /// Gets or sets the Revised_Square_Footage_Other value.
        /// </summary>
        public decimal? Revised_Square_Footage_Other
        {
            get { return _Revised_Square_Footage_Other; }
            set { _Revised_Square_Footage_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Improvement_Value value.
        /// </summary>
        public decimal? Improvement_Value
        {
            get { return _Improvement_Value; }
            set { _Improvement_Value = value; }
        }

        /// <summary>
        /// Gets or sets the Completion_Date value.
        /// </summary>
        public DateTime? Completion_Date
        {
            get { return _Completion_Date; }
            set { _Completion_Date = value; }
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
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime? Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }

        public string FK_Building_Ids { get { return _FK_Building_Ids; } set { _FK_Building_Ids = value; } }
        public string Project_Number { get { return _Project_Number; } set { _Project_Number = value; } }
        public DateTime? Start_Date { get { return _Start_Date; } set { _Start_Date = value; } }
        public DateTime? Target_Completion_Date { get { return _Target_Completion_Date; } set { _Target_Completion_Date = value; } }
        public string Contact_Name { get { return _Contact_Name; } set { _Contact_Name = value; } }
        public string New_Build { get { return _New_Build; } set { _New_Build = value; } }
        public string Open { get { return _Open; } set { _Open = value; } }
        public DateTime? Project_Status_As_Of_Date { get { return _Project_Status_As_Of_Date; } set { _Project_Status_As_Of_Date = value; } }
        public decimal? FK_LU_BI_Status { get { return _FK_LU_BI_Status; } set { _FK_LU_BI_Status = value; } }
        public string Status_Other { get { return _Status_Other; } set { _Status_Other = value; } }
        public string Revised_Square_Footage { get { return _Revised_Square_Footage; } set { _Revised_Square_Footage = value; } }
        public decimal? Revised_Square_Footage_Service_Lane { get { return _Revised_Square_Footage_Service_Lane; } set { _Revised_Square_Footage_Service_Lane = value; } }
        public decimal? Total_Square_Footage_Revised { get { return _Total_Square_Footage_Revised; } set { _Total_Square_Footage_Revised = value; } }
        public decimal? Budget_Construction { get { return _Budget_Construction; } set { _Budget_Construction = value; } }
        public decimal? Budget_Land { get { return _Budget_Land; } set { _Budget_Land = value; } }
        public decimal? Budget_Misc { get { return _Budget_Misc; } set { _Budget_Misc = value; } }
        public decimal? Budget_SubTotal_1 { get { return _Budget_SubTotal_1; } set { _Budget_SubTotal_1 = value; } }
        public decimal? Budget_IT { get { return _Budget_IT; } set { _Budget_IT = value; } }
        public decimal? Budget_Furniture { get { return _Budget_Furniture; } set { _Budget_Furniture = value; } }
        public decimal? Budget_Equipment { get { return _Budget_Equipment; } set { _Budget_Equipment = value; } }
        public decimal? Budget_Signage { get { return _Budget_Signage; } set { _Budget_Signage = value; } }
        public decimal? Budget_SubTotal_2 { get { return _Budget_SubTotal_2; } set { _Budget_SubTotal_2 = value; } }
        public decimal? Budget_Total { get { return _Budget_Total; } set { _Budget_Total = value; } }

        /// <summary>
        /// Gets or sets Item 1
        /// </summary>
        public string Item_1 
        { 
            get { return _Item_1; } 
            set { _Item_1 = value; } 
        }

        /// <summary>
        /// Gets or sets Item 2
        /// </summary>
        public string Item_2
        {
            get { return _Item_2; }
            set { _Item_2 = value; }
        }

        /// <summary>
        /// Gets or sets Item 3
        /// </summary>
        public string Item_3
        {
            get { return _Item_3; }
            set { _Item_3 = value; }
        }

        /// <summary>
        /// Gets or sets Item 4
        /// </summary>
        public string Item_4
        {
            get { return _Item_4; }
            set { _Item_4 = value; }
        }

        /// <summary>
        /// Gets or sets Item 5
        /// </summary>
        public string Item_5
        {
            get { return _Item_5; }
            set { _Item_5 = value; }
        }

        /// <summary>
        /// Gets or sets Item 6
        /// </summary>
        public string Item_6
        {
            get { return _Item_6; }
            set { _Item_6 = value; }
        }

        /// <summary>
        /// Gets or sets Item 7
        /// </summary>
        public string Item_7
        {
            get { return _Item_7; }
            set { _Item_7 = value; }
        }

        /// <summary>
        /// Gets or sets Number_of_Havac_Before_Improvements
        /// </summary>
        public int Number_of_Havac_Before_Improvements
        {
            get { return _Number_of_Havac_Before_Improvements; }
            set { _Number_of_Havac_Before_Improvements = value; }
        }

        /// <summary>
        /// Gets or sets Number_of_Havac_After_Improvements 7
        /// </summary>
        public int Number_of_Havac_After_Improvements
        {
            get { return _Number_of_Havac_After_Improvements; }
            set { _Number_of_Havac_After_Improvements = value; }
        }

        /// <summary>
        /// Gets or sets Roof_Improvement_Details 7
        /// </summary>
        public string Roof_Improvement_Details
        {
            get { return _Roof_Improvement_Details; }
            set { _Roof_Improvement_Details = value; }
        }

        /// <summary>
        /// Gets or sets Additional_Replace
        /// </summary>
        public string Additional_Replace
        {
            get { return _Additional_Replace; }
            set { _Additional_Replace = value; }
        }

        /// <summary>
        /// Gets or sets Other_comments
        /// </summary>
        public string Other_comments
        {
            get { return _Other_comments; }
            set { _Other_comments = value; }
        }

        public decimal? FK_Building
        {
            get { return _FK_Building; }
            set { _FK_Building = value; }
        }

        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the Building_Improvements class with default value.
        /// </summary>
        public Building_Improvements()
        {

            this._PK_Building_Improvements = null;
            this._FK_Property_Cope = null;
            this._Improvement_Description = null;
            this._Service_Capacity_Increase = null;
            this._Revised_Square_Footage_Sales = null;
            this._Revised_Square_Footage_Service = null;
            this._Revised_Square_Footage_Parts = null;
            this._Revised_Square_Footage_Other = null;
            this._Improvement_Value = null;
            this._Completion_Date = null;
            this._Updated_By = null;
            this._Updated_Date = null;

        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the Building_Improvements class based on Primary Key.
        /// </summary>
        public Building_Improvements(decimal pK_Building_Improvements)
        {
            DataTable dtBuilding_Improvements = SelectByPK(pK_Building_Improvements).Tables[0];

            if (dtBuilding_Improvements.Rows.Count == 1)
            {
                DataRow drBuilding_Improvements = dtBuilding_Improvements.Rows[0];
                if (drBuilding_Improvements["PK_Building_Improvements"] == DBNull.Value)
                    this._PK_Building_Improvements = null;
                else
                    this._PK_Building_Improvements = (decimal?)drBuilding_Improvements["PK_Building_Improvements"];

                if (drBuilding_Improvements["FK_Property_Cope"] == DBNull.Value)
                    this._FK_Property_Cope = null;
                else
                    this._FK_Property_Cope = (decimal?)drBuilding_Improvements["FK_Property_Cope"];

                if (drBuilding_Improvements["Improvement_Description"] == DBNull.Value)
                    this._Improvement_Description = null;
                else
                    this._Improvement_Description = (string)drBuilding_Improvements["Improvement_Description"];

                if (drBuilding_Improvements["Service_Capacity_Increase"] == DBNull.Value)
                    this._Service_Capacity_Increase = null;
                else
                    this._Service_Capacity_Increase = (string)drBuilding_Improvements["Service_Capacity_Increase"];

                if (drBuilding_Improvements["Revised_Square_Footage_Sales"] == DBNull.Value)
                    this._Revised_Square_Footage_Sales = null;
                else
                    this._Revised_Square_Footage_Sales = (decimal?)drBuilding_Improvements["Revised_Square_Footage_Sales"];

                if (drBuilding_Improvements["Revised_Square_Footage_Service"] == DBNull.Value)
                    this._Revised_Square_Footage_Service = null;
                else
                    this._Revised_Square_Footage_Service = (decimal?)drBuilding_Improvements["Revised_Square_Footage_Service"];

                if (drBuilding_Improvements["Revised_Square_Footage_Parts"] == DBNull.Value)
                    this._Revised_Square_Footage_Parts = null;
                else
                    this._Revised_Square_Footage_Parts = (decimal?)drBuilding_Improvements["Revised_Square_Footage_Parts"];

                if (drBuilding_Improvements["Revised_Square_Footage_Other"] == DBNull.Value)
                    this._Revised_Square_Footage_Other = null;
                else
                    this._Revised_Square_Footage_Other = (decimal?)drBuilding_Improvements["Revised_Square_Footage_Other"];

                if (drBuilding_Improvements["Improvement_Value"] == DBNull.Value)
                    this._Improvement_Value = null;
                else
                    this._Improvement_Value = (decimal?)drBuilding_Improvements["Improvement_Value"];

                if (drBuilding_Improvements["Completion_Date"] == DBNull.Value)
                    this._Completion_Date = null;
                else
                    this._Completion_Date = (DateTime?)drBuilding_Improvements["Completion_Date"];

                if (drBuilding_Improvements["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drBuilding_Improvements["Updated_By"];

                if (drBuilding_Improvements["Updated_Date"] == DBNull.Value)
                    this._Updated_Date = null;
                else
                    this._Updated_Date = (DateTime?)drBuilding_Improvements["Updated_Date"];

                if (drBuilding_Improvements["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drBuilding_Improvements["Updated_By"];

                if (drBuilding_Improvements["Project_Number"] == DBNull.Value)
                    this._Project_Number = null;
                else
                    this._Project_Number = (string)drBuilding_Improvements["Project_Number"];

                if (drBuilding_Improvements["Start_Date"] == DBNull.Value)
                    this._Start_Date = null;
                else
                    this._Start_Date = (DateTime?)drBuilding_Improvements["Start_Date"];

                if (drBuilding_Improvements["Target_Completion_Date"] == DBNull.Value)
                    this._Target_Completion_Date = null;
                else
                    this._Target_Completion_Date = (DateTime?)drBuilding_Improvements["Target_Completion_Date"];

                if (drBuilding_Improvements["Contact_Name"] == DBNull.Value)
                    this._Contact_Name = null;
                else
                    this._Contact_Name = (string)drBuilding_Improvements["Contact_Name"];

                if (drBuilding_Improvements["New_Build"] == DBNull.Value)
                    this._New_Build = null;
                else
                    this._New_Build = (string)drBuilding_Improvements["New_Build"];

                if (drBuilding_Improvements["Open"] == DBNull.Value)
                    this._Open = null;
                else
                    this._Open = (string)drBuilding_Improvements["Open"];


                if (drBuilding_Improvements["Project_Status_As_Of_Date"] == DBNull.Value)
                    this._Project_Status_As_Of_Date = null;
                else
                    this._Project_Status_As_Of_Date = (DateTime?)drBuilding_Improvements["Project_Status_As_Of_Date"];

                if (drBuilding_Improvements["FK_LU_BI_Status"] == DBNull.Value)
                    this._FK_LU_BI_Status = null;
                else
                    this._FK_LU_BI_Status = (decimal?)drBuilding_Improvements["FK_LU_BI_Status"];

                if (drBuilding_Improvements["Status_Other"] == DBNull.Value)
                    this._Status_Other = null;
                else
                    this._Status_Other = (string)drBuilding_Improvements["Status_Other"];

                if (drBuilding_Improvements["Revised_Square_Footage"] == DBNull.Value)
                    this._Revised_Square_Footage = null;
                else
                    this._Revised_Square_Footage = (string)drBuilding_Improvements["Revised_Square_Footage"];

                if (drBuilding_Improvements["Revised_Square_Footage_Service_Lane"] == DBNull.Value)
                    this._Revised_Square_Footage_Service_Lane = null;
                else
                    this._Revised_Square_Footage_Service_Lane = (decimal?)drBuilding_Improvements["Revised_Square_Footage_Service_Lane"];

                if (drBuilding_Improvements["Total_Square_Footage_Revised"] == DBNull.Value)
                    this._Total_Square_Footage_Revised = null;
                else
                    this._Total_Square_Footage_Revised = (decimal?)drBuilding_Improvements["Total_Square_Footage_Revised"];

                if (drBuilding_Improvements["Budget_Construction"] == DBNull.Value)
                    this._Budget_Construction = null;
                else
                    this._Budget_Construction = (decimal?)drBuilding_Improvements["Budget_Construction"];

                if (drBuilding_Improvements["Budget_Land"] == DBNull.Value)
                    this._Budget_Land = null;
                else
                    this._Budget_Land = (decimal?)drBuilding_Improvements["Budget_Land"];

                if (drBuilding_Improvements["Budget_Misc"] == DBNull.Value)
                    this._Budget_Misc = null;
                else
                    this._Budget_Misc = (decimal?)drBuilding_Improvements["Budget_Misc"];

                if (drBuilding_Improvements["Budget_SubTotal_1"] == DBNull.Value)
                    this._Budget_SubTotal_1 = null;
                else
                    this._Budget_SubTotal_1 = (decimal?)drBuilding_Improvements["Budget_SubTotal_1"];

                if (drBuilding_Improvements["Budget_IT"] == DBNull.Value)
                    this._Budget_IT = null;
                else
                    this._Budget_IT = (decimal?)drBuilding_Improvements["Budget_IT"];

                if (drBuilding_Improvements["Budget_Furniture"] == DBNull.Value)
                    this._Budget_Furniture = null;
                else
                    this._Budget_Furniture = (decimal?)drBuilding_Improvements["Budget_Furniture"];

                if (drBuilding_Improvements["Budget_Equipment"] == DBNull.Value)
                    this._Budget_Equipment = null;
                else
                    this._Budget_Equipment = (decimal?)drBuilding_Improvements["Budget_Equipment"];

                if (drBuilding_Improvements["Budget_Signage"] == DBNull.Value)
                    this._Budget_Signage = null;
                else
                    this._Budget_Signage = (decimal?)drBuilding_Improvements["Budget_Signage"];

                if (drBuilding_Improvements["Budget_SubTotal_2"] == DBNull.Value)
                    this._Budget_SubTotal_2 = null;
                else
                    this._Budget_SubTotal_2 = (decimal?)drBuilding_Improvements["Budget_SubTotal_2"];

                if (drBuilding_Improvements["Budget_Total"] == DBNull.Value)
                    this._Budget_Total = null;
                else
                    this._Budget_Total = (decimal?)drBuilding_Improvements["Budget_Total"];

                if (drBuilding_Improvements["Budget_Total"] == DBNull.Value)
                    this._Budget_Total = null;
                else
                    this._Budget_Total = (decimal?)drBuilding_Improvements["Budget_Total"];

                if (drBuilding_Improvements["Item_1"] == DBNull.Value)
                    this._Item_1 = null;
                else
                    this._Item_1 = Convert.ToString(drBuilding_Improvements["Item_1"]);

                if (drBuilding_Improvements["Item_2"] == DBNull.Value)
                    this._Item_2 = null;
                else
                    this._Item_2 = Convert.ToString(drBuilding_Improvements["Item_2"]);

                if (drBuilding_Improvements["Item_3"] == DBNull.Value)
                    this._Item_3 = null;
                else
                    this._Item_3 = Convert.ToString(drBuilding_Improvements["Item_3"]);

                if (drBuilding_Improvements["Item_4"] == DBNull.Value)
                    this._Item_4 = null;
                else
                    this._Item_4 = Convert.ToString(drBuilding_Improvements["Item_4"]);

                if (drBuilding_Improvements["Item_5"] == DBNull.Value)
                    this._Item_5 = null;
                else
                    this._Item_5 = Convert.ToString(drBuilding_Improvements["Item_5"]);

                if (drBuilding_Improvements["Item_6"] == DBNull.Value)
                    this._Item_6 = null;
                else
                    this._Item_6 = Convert.ToString(drBuilding_Improvements["Item_6"]);

                if (drBuilding_Improvements["Item_7"] == DBNull.Value)
                    this._Item_7 = null;
                else
                    this._Item_7 = Convert.ToString(drBuilding_Improvements["Item_7"]);

                if (drBuilding_Improvements["Number_of_Havac_Before_Improvements"] == DBNull.Value)
                    this._Number_of_Havac_Before_Improvements = 0;
                else
                    this._Number_of_Havac_Before_Improvements = (Int32)(drBuilding_Improvements["Number_of_Havac_Before_Improvements"]);

                if (drBuilding_Improvements["Number_of_Havac_After_Improvements"] == DBNull.Value)
                    this._Number_of_Havac_After_Improvements = 0;
                else
                    this._Number_of_Havac_After_Improvements = (Int32)(drBuilding_Improvements["Number_of_Havac_After_Improvements"]);

                if (drBuilding_Improvements["Roof_Improvement_Details"] == DBNull.Value)
                    this.Roof_Improvement_Details = null;
                else
                    this.Roof_Improvement_Details = Convert.ToString(drBuilding_Improvements["Roof_Improvement_Details"]);

                if (drBuilding_Improvements["Additional_Replace"] == DBNull.Value)
                    this._Additional_Replace = null;
                else
                    this._Additional_Replace = Convert.ToString(drBuilding_Improvements["Additional_Replace"]);

                if (drBuilding_Improvements["Other_comments"] == DBNull.Value)
                    this._Other_comments = null;
                else
                    this._Other_comments = Convert.ToString(drBuilding_Improvements["Other_comments"]);

                if (drBuilding_Improvements["FK_Building"] == DBNull.Value)
                    this._FK_Building = null;
                else
                    this._FK_Building = Convert.ToDecimal(drBuilding_Improvements["FK_Building"]);

            }
            else
            {
                this._PK_Building_Improvements = null;
                this._FK_Property_Cope = null;
                this._Improvement_Description = null;
                this._Service_Capacity_Increase = null;
                this._Revised_Square_Footage_Sales = null;
                this._Revised_Square_Footage_Service = null;
                this._Revised_Square_Footage_Parts = null;
                this._Revised_Square_Footage_Other = null;
                this._Improvement_Value = null;
                this._Completion_Date = null;
                this._Updated_By = null;
                this._Updated_Date = null;
                this.Project_Number = null;
                this.Start_Date = null;
                this.Target_Completion_Date = null;
                this.Contact_Name = null;
                this.New_Build = null;
                this.Open = null;
                this.Project_Status_As_Of_Date = null;
                this.FK_LU_BI_Status = null;
                this.Status_Other = null;
                this.Revised_Square_Footage = null;
                this.Revised_Square_Footage_Service_Lane = null;
                this.Total_Square_Footage_Revised = null;
                this.Budget_Construction = null;
                this.Budget_Land = null;
                this.Budget_Misc = null;
                this.Budget_SubTotal_1 = null;
                this.Budget_IT = null;
                this.Budget_Furniture = null;
                this.Budget_Equipment = null;
                this.Budget_Signage = null;
                this.Budget_SubTotal_2 = null;
                this.Budget_Total = null;
                this._Item_1 = null;
                this._Item_2 = null;
                this._Item_3 = null;
                this._Item_4 = null;
                this._Item_5 = null;
                this._Item_6 = null;
                this._Item_7 = null;
                this._Number_of_Havac_Before_Improvements = 0;
                this._Number_of_Havac_After_Improvements = 0;
                this.Roof_Improvement_Details = null;
                this._Additional_Replace = null;
                this._Other_comments = null;
            }

        }

        #endregion

        /// <summary>
        /// Inserts a record into the Building_Improvements table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsInsert");


            db.AddInParameter(dbCommand, "FK_Property_Cope", DbType.Decimal, this._FK_Property_Cope);

            db.AddInParameter(dbCommand, "FK_Building_Ids", DbType.String, this._FK_Building_Ids);

            if (string.IsNullOrEmpty(this._Improvement_Description))
                db.AddInParameter(dbCommand, "Improvement_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Improvement_Description", DbType.String, this._Improvement_Description);

            if (string.IsNullOrEmpty(this._Service_Capacity_Increase))
                db.AddInParameter(dbCommand, "Service_Capacity_Increase", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Service_Capacity_Increase", DbType.String, this._Service_Capacity_Increase);

            db.AddInParameter(dbCommand, "Revised_Square_Footage_Sales", DbType.Decimal, this._Revised_Square_Footage_Sales);

            db.AddInParameter(dbCommand, "Revised_Square_Footage_Service", DbType.Decimal, this._Revised_Square_Footage_Service);

            db.AddInParameter(dbCommand, "Revised_Square_Footage_Parts", DbType.Decimal, this._Revised_Square_Footage_Parts);

            db.AddInParameter(dbCommand, "Revised_Square_Footage_Other", DbType.Decimal, this._Revised_Square_Footage_Other);

            db.AddInParameter(dbCommand, "Improvement_Value", DbType.Decimal, this._Improvement_Value);

            db.AddInParameter(dbCommand, "Completion_Date", DbType.DateTime, this._Completion_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

            if (string.IsNullOrEmpty(this._Project_Number))
                db.AddInParameter(dbCommand, "Project_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Project_Number", DbType.String, this._Project_Number);

            db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);

            db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, this._Target_Completion_Date);

            if (string.IsNullOrEmpty(this._Contact_Name))
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);

            if (string.IsNullOrEmpty(this._New_Build))
                db.AddInParameter(dbCommand, "New_Build", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "New_Build", DbType.String, this._New_Build);

            if (string.IsNullOrEmpty(this._Open))
                db.AddInParameter(dbCommand, "Open", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Open", DbType.String, this._Open);

            db.AddInParameter(dbCommand, "Project_Status_As_Of_Date", DbType.DateTime, this._Project_Status_As_Of_Date);

            db.AddInParameter(dbCommand, "FK_LU_BI_Status", DbType.Decimal, this._FK_LU_BI_Status);

            if (string.IsNullOrEmpty(this._Status_Other))
                db.AddInParameter(dbCommand, "Status_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Status_Other", DbType.String, this._Status_Other);

            if (string.IsNullOrEmpty(this._Revised_Square_Footage))
                db.AddInParameter(dbCommand, "Revised_Square_Footage", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Revised_Square_Footage", DbType.String, this._Revised_Square_Footage);

            db.AddInParameter(dbCommand, "Revised_Square_Footage_Service_Lane", DbType.Decimal, this._Revised_Square_Footage_Service_Lane);

            db.AddInParameter(dbCommand, "Total_Square_Footage_Revised", DbType.Decimal, this._Total_Square_Footage_Revised);

            db.AddInParameter(dbCommand, "Budget_Construction", DbType.Decimal, this._Budget_Construction);

            db.AddInParameter(dbCommand, "Budget_Land", DbType.Decimal, this._Budget_Land);

            db.AddInParameter(dbCommand, "Budget_Misc", DbType.Decimal, this._Budget_Misc);

            db.AddInParameter(dbCommand, "Budget_SubTotal_1", DbType.Decimal, this._Budget_SubTotal_1);

            db.AddInParameter(dbCommand, "Budget_IT", DbType.Decimal, this._Budget_IT);

            db.AddInParameter(dbCommand, "Budget_Furniture", DbType.Decimal, this._Budget_Furniture);

            db.AddInParameter(dbCommand, "Budget_Equipment", DbType.Decimal, this._Budget_Equipment);

            db.AddInParameter(dbCommand, "Budget_Signage", DbType.Decimal, this._Budget_Signage);

            db.AddInParameter(dbCommand, "Budget_SubTotal_2", DbType.Decimal, this._Budget_SubTotal_2);

            db.AddInParameter(dbCommand, "Budget_Total", DbType.Decimal, this._Budget_Total);

            if (string.IsNullOrEmpty(this._Item_1))
                db.AddInParameter(dbCommand, "Item_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_1", DbType.String, this._Item_1);

            if (string.IsNullOrEmpty(this._Item_2))
                db.AddInParameter(dbCommand, "Item_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_2", DbType.String, this._Item_2);

            if (string.IsNullOrEmpty(this._Item_3))
                db.AddInParameter(dbCommand, "Item_3", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_3", DbType.String, this._Item_3);

            if (string.IsNullOrEmpty(this._Item_4))
                db.AddInParameter(dbCommand, "Item_4", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_4", DbType.String, this._Item_4);

            if (string.IsNullOrEmpty(this._Item_5))
                db.AddInParameter(dbCommand, "Item_5", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_5", DbType.String, this._Item_5);

            if (string.IsNullOrEmpty(this._Item_6))
                db.AddInParameter(dbCommand, "Item_6", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_6", DbType.String, this._Item_6);

            if (string.IsNullOrEmpty(this._Item_7))
                db.AddInParameter(dbCommand, "Item_7", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_7", DbType.String, this._Item_7);

            db.AddInParameter(dbCommand, "Number_of_Havac_Before_Improvements", DbType.Decimal, this._Number_of_Havac_Before_Improvements);

            db.AddInParameter(dbCommand, "Number_of_Havac_After_Improvements", DbType.Decimal, this._Number_of_Havac_After_Improvements);

            if (string.IsNullOrEmpty(this._Roof_Improvement_Details))
                db.AddInParameter(dbCommand, "Roof_Improvement_Details", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Roof_Improvement_Details", DbType.String, this._Roof_Improvement_Details);

            if (string.IsNullOrEmpty(this._Additional_Replace))
                db.AddInParameter(dbCommand, "Additional_Replace", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_Replace", DbType.String, this._Additional_Replace);

            if (string.IsNullOrEmpty(this._Other_comments))
                db.AddInParameter(dbCommand, "Other_comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_comments", DbType.String, this._Other_comments);

            db.AddInParameter(dbCommand, "FK_Building", DbType.String, this._FK_Building.HasValue ? this._FK_Building.Value : 0);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        } 

        /// <summary>
        /// Selects a single record from the Building_Improvements table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_Building_Improvements)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Building_Improvements", DbType.Decimal, pK_Building_Improvements);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Building_Improvements table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Building_Improvements table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsUpdate");


            db.AddInParameter(dbCommand, "PK_Building_Improvements", DbType.Decimal, this._PK_Building_Improvements);

            db.AddInParameter(dbCommand, "FK_Building_Ids", DbType.String, this._FK_Building_Ids);

            db.AddInParameter(dbCommand, "FK_Property_Cope", DbType.Decimal, this._FK_Property_Cope);

            if (string.IsNullOrEmpty(this._Improvement_Description))
                db.AddInParameter(dbCommand, "Improvement_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Improvement_Description", DbType.String, this._Improvement_Description);

            if (string.IsNullOrEmpty(this._Service_Capacity_Increase))
                db.AddInParameter(dbCommand, "Service_Capacity_Increase", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Service_Capacity_Increase", DbType.String, this._Service_Capacity_Increase);

            db.AddInParameter(dbCommand, "Revised_Square_Footage_Sales", DbType.Decimal, this._Revised_Square_Footage_Sales);

            db.AddInParameter(dbCommand, "Revised_Square_Footage_Service", DbType.Decimal, this._Revised_Square_Footage_Service);

            db.AddInParameter(dbCommand, "Revised_Square_Footage_Parts", DbType.Decimal, this._Revised_Square_Footage_Parts);

            db.AddInParameter(dbCommand, "Revised_Square_Footage_Other", DbType.Decimal, this._Revised_Square_Footage_Other);

            db.AddInParameter(dbCommand, "Improvement_Value", DbType.Decimal, this._Improvement_Value);

            db.AddInParameter(dbCommand, "Completion_Date", DbType.DateTime, this._Completion_Date);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);

            if (string.IsNullOrEmpty(this._Project_Number))
                db.AddInParameter(dbCommand, "Project_Number", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Project_Number", DbType.String, this._Project_Number);

            db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, this._Start_Date);

            db.AddInParameter(dbCommand, "Target_Completion_Date", DbType.DateTime, this._Target_Completion_Date);

            if (string.IsNullOrEmpty(this._Contact_Name))
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);

            if (string.IsNullOrEmpty(this._New_Build))
                db.AddInParameter(dbCommand, "New_Build", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "New_Build", DbType.String, this._New_Build);

            if (string.IsNullOrEmpty(this._Open))
                db.AddInParameter(dbCommand, "Open", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Open", DbType.String, this._Open);

            db.AddInParameter(dbCommand, "Project_Status_As_Of_Date", DbType.DateTime, this._Project_Status_As_Of_Date);

            db.AddInParameter(dbCommand, "FK_LU_BI_Status", DbType.Decimal, this._FK_LU_BI_Status);

            if (string.IsNullOrEmpty(this._Status_Other))
                db.AddInParameter(dbCommand, "Status_Other", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Status_Other", DbType.String, this._Status_Other);

            if (string.IsNullOrEmpty(this._Revised_Square_Footage))
                db.AddInParameter(dbCommand, "Revised_Square_Footage", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Revised_Square_Footage", DbType.String, this._Revised_Square_Footage);

            db.AddInParameter(dbCommand, "Revised_Square_Footage_Service_Lane", DbType.Decimal, this._Revised_Square_Footage_Service_Lane);

            db.AddInParameter(dbCommand, "Total_Square_Footage_Revised", DbType.Decimal, this._Total_Square_Footage_Revised);

            db.AddInParameter(dbCommand, "Budget_Construction", DbType.Decimal, this._Budget_Construction);

            db.AddInParameter(dbCommand, "Budget_Land", DbType.Decimal, this._Budget_Land);

            db.AddInParameter(dbCommand, "Budget_Misc", DbType.Decimal, this._Budget_Misc);

            db.AddInParameter(dbCommand, "Budget_SubTotal_1", DbType.Decimal, this._Budget_SubTotal_1);

            db.AddInParameter(dbCommand, "Budget_IT", DbType.Decimal, this._Budget_IT);

            db.AddInParameter(dbCommand, "Budget_Furniture", DbType.Decimal, this._Budget_Furniture);

            db.AddInParameter(dbCommand, "Budget_Equipment", DbType.Decimal, this._Budget_Equipment);

            db.AddInParameter(dbCommand, "Budget_Signage", DbType.Decimal, this._Budget_Signage);

            db.AddInParameter(dbCommand, "Budget_SubTotal_2", DbType.Decimal, this._Budget_SubTotal_2);

            db.AddInParameter(dbCommand, "Budget_Total", DbType.Decimal, this._Budget_Total);

            if (string.IsNullOrEmpty(this._Item_1))
                db.AddInParameter(dbCommand, "Item_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_1", DbType.String, this._Item_1);

            if (string.IsNullOrEmpty(this._Item_2))
                db.AddInParameter(dbCommand, "Item_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_2", DbType.String, this._Item_2);

            if (string.IsNullOrEmpty(this._Item_3))
                db.AddInParameter(dbCommand, "Item_3", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_3", DbType.String, this._Item_3);

            if (string.IsNullOrEmpty(this._Item_4))
                db.AddInParameter(dbCommand, "Item_4", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_4", DbType.String, this._Item_4);

            if (string.IsNullOrEmpty(this._Item_5))
                db.AddInParameter(dbCommand, "Item_5", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_5", DbType.String, this._Item_5);

            if (string.IsNullOrEmpty(this._Item_6))
                db.AddInParameter(dbCommand, "Item_6", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_6", DbType.String, this._Item_6);

            if (string.IsNullOrEmpty(this._Item_7))
                db.AddInParameter(dbCommand, "Item_7", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Item_7", DbType.String, this._Item_7);

            db.AddInParameter(dbCommand, "Number_of_Havac_Before_Improvements", DbType.Decimal, this._Number_of_Havac_Before_Improvements);

            db.AddInParameter(dbCommand, "Number_of_Havac_After_Improvements", DbType.Decimal, this._Number_of_Havac_After_Improvements);

            if (string.IsNullOrEmpty(this._Roof_Improvement_Details))
                db.AddInParameter(dbCommand, "Roof_Improvement_Details", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Roof_Improvement_Details", DbType.String, this._Roof_Improvement_Details);

            if (string.IsNullOrEmpty(this._Additional_Replace))
                db.AddInParameter(dbCommand, "Additional_Replace", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_Replace", DbType.String, this._Additional_Replace);

            if (string.IsNullOrEmpty(this._Other_comments))
                db.AddInParameter(dbCommand, "Other_comments", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_comments", DbType.String, this._Other_comments);

            db.AddInParameter(dbCommand, "FK_Building", DbType.String, this._FK_Building.HasValue ? this._FK_Building.Value : 0);

            int i = db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Building_Improvements table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Building_Improvements)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Building_Improvements", DbType.Decimal, pK_Building_Improvements);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByFK(decimal fk_Building)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsSelectByFK");

            db.AddInParameter(dbCommand, "FK_Building", DbType.Decimal, fk_Building);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectByFK_Property_Cope(decimal FK_Property_Cope)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsSelectByFK_Property_Cope");

            db.AddInParameter(dbCommand, "FK_Property_Cope", DbType.Decimal, FK_Property_Cope);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectBuildingByFK_Building_Improvements(decimal FK_Building_Improvements)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_ImprovementsSelectBuildingByFK_Building_Improvements");

            db.AddInParameter(dbCommand, "FK_Building_Improvements", DbType.Decimal, FK_Building_Improvements);

            return db.ExecuteDataSet(dbCommand);
        }


    }
}
