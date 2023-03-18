using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using MultiUserAB.Areas.LOC_State.Models;
using System.Data.Common;
using System.Data;
using MultiUserAB.Areas.LOC_Country.Models;
using MultiUserAB.Areas.LOC_State.Models;
using MultiUserAB.Areas.LOC_City.Models;

namespace MultiUserAB.DAL
{
    public class LOC_DALBase : DALHelper
    {
        #region PR_LOC_Country_SelectAll

        public DataTable PR_LOC_Country_SelectAll()
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_Country_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region PR_LOC_State_SelectAll

        public DataTable PR_LOC_State_SelectAll()
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_State_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region PR_LOC_City_SelectAll

        public DataTable PR_LOC_City_SelectAll()
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_City_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion



        #region PR_LOC_Country_DeleteByPK

        public Boolean PR_LOC_Country_DeleteByPK(int CountryID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_Country_DeleteByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "CountryID", DbType.Int32, CountryID);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region PR_LOC_State_DeleteByPK

        public Boolean PR_LOC_State_DeleteByPK(int StateID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_State_DeleteByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "StateID", DbType.Int32, StateID);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region PR_LOC_City_DeleteByID

        public Boolean PR_LOC_City_DeleteByPK(int CityID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_City_DeleteByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "CityID", DbType.Int32, CityID);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion



        #region PR_LOC_Country_SelectByPK

        public DataTable PR_LOC_Country_SelectByPK(int? CountryID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_Country_SelectByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "getID", DbType.Int32, CountryID);
                DataTable dt = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region PR_LOC_State_SelectByPK

        public DataTable PR_LOC_State_SelectByPK(int? StateID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_State_SelectByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "getID", DbType.Int32, StateID);
                DataTable dt = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region PR_LOC_City_SelectByPK

        public DataTable PR_LOC_City_SelectByPK(int? CityID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_City_SelectByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "getID", DbType.Int32, CityID);
                DataTable dt = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion



        #region PR_LOC_Country_Insert

        public Boolean PR_LOC_Country_Insert(LOC_CountryModel modelLOC_Country)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_Country_Insert");
                SQL_DB.AddInParameter(DataBaseCommand, "CountryName", DbType.String, modelLOC_Country.CountryName);
                SQL_DB.AddInParameter(DataBaseCommand, "CountryCode", DbType.String, modelLOC_Country.CountryCode);
                SQL_DB.AddInParameter(DataBaseCommand, "CreationDate", DbType.DateTime, DBNull.Value);
                SQL_DB.AddInParameter(DataBaseCommand, "ModificationDate", DbType.DateTime, DBNull.Value);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region PR_LOC_Country_UpdateByPK

        public Boolean PR_LOC_Country_UpdateByPK(LOC_CountryModel modelLOC_Country)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_Country_UpdateByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "getID", DbType.Int32, modelLOC_Country.CountryID);
                SQL_DB.AddInParameter(DataBaseCommand, "CountryName", DbType.String, modelLOC_Country.CountryName);
                SQL_DB.AddInParameter(DataBaseCommand, "CountryCode", DbType.String, modelLOC_Country.CountryCode);
                SQL_DB.AddInParameter(DataBaseCommand, "ModificationDate", DbType.DateTime, DBNull.Value);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion



        #region PR_LOC_State_Insert

        public Boolean PR_LOC_State_Insert(LOC_StateModel modelLOC_State)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_State_Insert");
                SQL_DB.AddInParameter(DataBaseCommand, "StateName", DbType.String, modelLOC_State.StateName);
                SQL_DB.AddInParameter(DataBaseCommand, "CountryID", DbType.Int32, modelLOC_State.CountryID);
                SQL_DB.AddInParameter(DataBaseCommand, "CreationDate", DbType.DateTime, DBNull.Value);
                SQL_DB.AddInParameter(DataBaseCommand, "ModificationDate", DbType.DateTime, DBNull.Value);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region PR_LOC_State_UpdateByPK

        public Boolean PR_LOC_State_UpdateByPK(LOC_StateModel modelLOC_State)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_State_UpdateByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "getID", DbType.Int32, modelLOC_State.StateID);
                SQL_DB.AddInParameter(DataBaseCommand, "StateName", DbType.String, modelLOC_State.StateName);
                SQL_DB.AddInParameter(DataBaseCommand, "CountryID", DbType.Int32, modelLOC_State.CountryID);
                SQL_DB.AddInParameter(DataBaseCommand, "ModificationDate", DbType.DateTime2, DBNull.Value);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion



        #region PR_LOC_City_Insert

        public Boolean PR_LOC_City_Insert(LOC_CityModel modelLOC_City)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_City_Insert");
                SQL_DB.AddInParameter(DataBaseCommand, "CityName", DbType.String, modelLOC_City.CityName);
                SQL_DB.AddInParameter(DataBaseCommand, "CountryID", DbType.Int32, modelLOC_City.CountryID);
                SQL_DB.AddInParameter(DataBaseCommand, "StateID", DbType.Int32, modelLOC_City.StateID);
                SQL_DB.AddInParameter(DataBaseCommand, "CreationDate", DbType.DateTime, DBNull.Value);
                SQL_DB.AddInParameter(DataBaseCommand, "ModificationDate", DbType.DateTime, DBNull.Value);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region PR_LOC_City_UpdateByPK

        public Boolean PR_LOC_City_UpdateByPK(LOC_CityModel modelLOC_City)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_City_UpdateByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "getID", DbType.Int32, modelLOC_City.CityID);
                SQL_DB.AddInParameter(DataBaseCommand, "CityName", DbType.String, modelLOC_City.CityName);
                SQL_DB.AddInParameter(DataBaseCommand, "CountryID", DbType.Int32, modelLOC_City.CountryID);
                SQL_DB.AddInParameter(DataBaseCommand, "StateID", DbType.Int32, modelLOC_City.StateID);
                SQL_DB.AddInParameter(DataBaseCommand, "ModificationDate", DbType.DateTime, DBNull.Value);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion



        #region PR_LOC_Country_Filter

        public DataTable PR_LOC_Country_Filter(string CountryName, string CountryCode)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_Country_Filter");
                DataTable DataTB = new DataTable();
                if (CountryName == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "CountryName", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "CountryName", DbType.String, CountryName);
                if (CountryCode == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "CountryCode", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "CountryCode", DbType.String, CountryCode);
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    DataTB.Load(dr);
                }

                return DataTB;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region PR_LOC_State_Filter

        public DataTable PR_LOC_State_Filter(string StateName, string CountryName)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_State_Filter");
                DataTable DataTB = new DataTable();
                if (CountryName == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "CountryName", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "CountryName", DbType.String, CountryName);
                if (StateName == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "StateName", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "StateName", DbType.String, StateName);
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    DataTB.Load(dr);
                }

                return DataTB;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region PR_LOC_City_Filter

        public DataTable PR_LOC_City_Filter(string CityName, string StateName, string CountryName)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_City_Filter");
                DataTable DataTB = new DataTable();
                if (CountryName == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "CountryName", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "CountryName", DbType.String, CountryName);


                if (StateName == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "StateName", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "StateName", DbType.String, StateName);


                if (CityName == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "CityName", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "CityName", DbType.String, CityName);
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    DataTB.Load(dr);
                }

                return DataTB;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion


        #region PR_LOC_Country_SelectfromDropDown
        public DataTable PR_LOC_Country_SelectfromDropDown()
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_Country_SelectfromDropDown");

                DataTable DataTB = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    DataTB.Load(dr);
                }

                return DataTB;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region PR_LOC_State_SelectForDropDownByCountryID

        public DataTable PR_LOC_State_SelectForDropDownByCountryID(int CountryID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_State_SelectForDropDownByCountryID");
                SQL_DB.AddInParameter(DataBaseCommand, "CountryID", DbType.Int32, CountryID);
                DataTable DataTB = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    DataTB.Load(dr);
                }

                return DataTB;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region PR_LOC_City_SelectForDropDownByStateID

        public DataTable PR_LOC_City_SelectForDropDownByStateID(int StateID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_LOC_City_SelectForDropDownByStateID");
                SQL_DB.AddInParameter(DataBaseCommand, "StateID", DbType.Int32, StateID);
                DataTable DataTB = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    DataTB.Load(dr);
                }

                return DataTB;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
