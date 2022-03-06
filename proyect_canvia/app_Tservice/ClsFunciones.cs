
using app_Mcanvia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace app_Tservice
{
    public class ClsFunciones
    {


        /// <summary>
        /// ExecuteStoredProcedure SIN PARAMETROS
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="xDr"></param>
        /// <param name="sqlConnObj"></param>
        /// <returns></returns>
        public MResponse ExecuteStoredProcedure(string procedureName,ref SqlDataReader xDr,ref SqlConnection sqlConnObj)
        {

            MResponse xResponse = new MResponse();
            try
            {
                 sqlConnObj = new SqlConnection(dbConnection.cn);

                SqlCommand sqlCmd = new SqlCommand(procedureName, sqlConnObj);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlConnObj.Open();
               xDr=sqlCmd.ExecuteReader();
               
                xResponse.iExito = true;
                xResponse.xMessage = "La solicitud se realizo correctamente";

            }
            catch (Exception ex)
            {
                xResponse.iExito = false;
                xResponse.xMessage=ex.Message;

                return xResponse;
            }
            return xResponse;
          
        }


        public MResponse ExecuteStoredProcedure(string procedureName, object model,ref SqlDataReader xDr,ref SqlConnection sqlConnObj)
        {
            MResponse xResponse = new MResponse();
            var parameters = GenerateSQLParameters(model);
             sqlConnObj = new SqlConnection(dbConnection.cn);

            SqlCommand sqlCmd = new SqlCommand(procedureName, sqlConnObj);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (var param in parameters)
                {
                    sqlCmd.Parameters.Add(param);
                }

                sqlConnObj.Open();
                xDr=sqlCmd.ExecuteReader();
                
                xResponse.iExito = true;
                xResponse.xMessage = "Los Datos se crearon correctamente";
            }
            catch (Exception ex)
            {
                xResponse.iExito = false;
                xResponse.xMessage = ex.Message;
                return xResponse;
            }
            return xResponse;
        }

        private List<SqlParameter> GenerateSQLParameters(object model)
        {
            var paramList = new List<SqlParameter>();
            Type modelType = model.GetType();
            var properties = modelType.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    paramList.Add(new SqlParameter(property.Name, DBNull.Value));
                }
                else
                {
                    paramList.Add(new SqlParameter(property.Name, property.GetValue(model)));
                }
            }
            return paramList;

        }

        public bool EjecutarSql(string CadenaSql)
        {


            SqlConnection objCN = null;
            SqlCommand objCMD = null;
            Boolean bRespuesta = false;

            try
            {


                objCN = new SqlConnection(dbConnection.cn);
                objCN.Open();
                objCMD = new SqlCommand(CadenaSql, objCN);
                objCMD.CommandType = CommandType.Text;
                objCMD.CommandTimeout = 0;
                objCMD.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                bRespuesta = false;
                throw new Exception(e.Message);

            }
            finally
            { 
                if (objCN.State == ConnectionState.Open)
                {
                    objCN.Close();
                }

                objCMD = null;
                objCN = null;
            }

            bRespuesta = true;

            return bRespuesta;
        }

        public ClsParametroSql PAsignaVal(string scampo, string sValcampo, [Optional, DefaultParameterValue(SqlDbType.Char)] SqlDbType stipcampo)
        {
            List<ClsParametroSql> lista = new List<ClsParametroSql>();
            //ClsAsignaValor CampoSql = new ClsAsignaValor();
            ClsParametroSql item = new ClsParametroSql();
            item.sCampo = scampo;
            item.sValorCampo = sValcampo;
            item.sTipCampo = stipcampo;
            return item;
            //CampoSql.ClsParametrosSlq.Add(item);

        }
        public bool OpenDr(ref SqlDataReader xDr,
                                 string xSql, ref SqlConnection xCon,
                                 [Optional, DefaultParameterValue(null)] SqlTransaction objTra)
        {

            Boolean bRetorno = true;

            if (objTra == null)
            {
                if (!dbOpen(ref xCon, xSql, ref xDr, 3, ""))
                {
                    bRetorno = false;
                }

            }
            else
            {


                if (!dbOpenDr3(ref xCon, objTra, ref xDr, xSql))
                {
                    bRetorno = false;
                }

            }



            return bRetorno;
        }
        public Boolean dbOpen(ref SqlConnection xSqlConnection, string xSql,
                         ref SqlDataReader objD,
                         [Optional, DefaultParameterValue(1)] int bObj,
                         [Optional, DefaultParameterValue("")] string objName)
        {


            //'Autor          :   Elme tapara

            SqlCommand objCmd = null;
            Boolean bRespuesta = false;
            try
            {
                xSqlConnection = new SqlConnection(dbConnection.cn);
                xSqlConnection.Open();
                objCmd = new SqlCommand(xSql, xSqlConnection);
                //objCmd.CommandType = CommandType.Text;
                objCmd.CommandTimeout = 0;
                objD = objCmd.ExecuteReader();
                bRespuesta = true;

            }
            catch (Exception ex)
            {
                bRespuesta = false;
                throw new Exception("Error de apertura de tabla " + ex.Message + " " + xSql);
                ///MessageBox.Show(ex.ToString()) ;
            }
            finally
            {
                objCmd = null;
                //objAda = null;

            }

            return bRespuesta;
        }
        public Boolean dbOpenDr3(ref SqlConnection objCon, SqlTransaction objTra, ref SqlDataReader objD, string cSql)
        {
            Boolean bRetorno = false;
            SqlCommand objCmd = null;
            SqlDataAdapter objAda = null;

            try
            {
                objCon = new SqlConnection(dbConnection.cn);
                objCon.Open();
                objCmd = new SqlCommand(cSql, objCon);
                objTra = objCon.BeginTransaction(IsolationLevel.ReadUncommitted);
                objCmd.Transaction = objTra;
                objD = objCmd.ExecuteReader();
                bRetorno = true;

            }
            catch (Exception ex)
            {
                bRetorno = false;
                throw new Exception("Error de apertura de tabla " + ex.Message + " " + cSql);
            }
            finally
            {

                objCmd = null;
                objAda = null;
            }

            return bRetorno;
        }

    }
}
