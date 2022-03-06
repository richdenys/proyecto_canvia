using app_Mcanvia;
using app_Tservice;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_dbcavia
{
    public class dbCategoria
    {
        ClsFunciones f = null;
        public dbCategoria()
        {
            this.f = new ClsFunciones();
        }

        public List<MCategoria> deletecategoria(string ID)
        {
           List<MCategoria> xResponse = null;
            SqlDataReader xDr = null;
            SqlConnection xCon = null;

            modelFiltroID xFiltro = new modelFiltroID() { ID = ID };

            MResponse xre = f.ExecuteStoredProcedure("DEL_CATEGORIA", xFiltro, ref xDr, ref xCon);
            if (xre.iExito == true)
            {
                if (xDr.HasRows)
                {
                    xResponse = new List<MCategoria>();
                    while (xDr.Read())
                    {
                        xResponse.Add(new MCategoria()
                        {
                            ID = xDr["ID"].ToString(),
                            Descripcion = xDr["Descripcion"].ToString(),
                        });

                    }
                }
                xDr.Close();
                xCon.Close();
                xDr = null;
            }
            return xResponse;
        }

        public List<MCategoria> tCategoriaPaginado(int PageIndex,int PageSize)
        {
            List<MCategoria> xResponse = null;
            SqlDataReader xDr = null;
            SqlConnection xCon = null;
            Mpaginacion xFiltro = new Mpaginacion() { PageIndex = PageIndex, PageSize= PageSize,RecordCount=1 };

            MResponse xre = f.ExecuteStoredProcedure("LIST_PAGINADO_CATEGORIA", xFiltro, ref xDr, ref xCon);
            if (xre.iExito == true)
            {
                if (xDr.HasRows)
                {
                    xResponse= new List<MCategoria>();
                    while (xDr.Read())
                    {
                        xResponse.Add(new MCategoria()
                        {
                        ID = xDr["ID"].ToString(),
                        Descripcion = xDr["Descripcion"].ToString(),
                        });
                      
                    }
                }
                xDr.Close();
                xCon.Close();
                xDr = null;
            }
            return xResponse;

        }
        public MCategoria tCategoriaXcodigo(string xCodigo)
        {
            MCategoria xResponse = null;
            SqlDataReader xDr = null;
            SqlConnection xCon = null;
            
            modelFiltroID xFiltro = new modelFiltroID() { ID = xCodigo };

            MResponse xre = f.ExecuteStoredProcedure("LIS_XCODIGOCATE", xFiltro, ref xDr, ref xCon);
            if (xre.iExito == true)
            {
                if (xDr.HasRows)
                {
                    xResponse = new MCategoria();
                    while (xDr.Read())
                    {
                        xResponse.ID = xDr["ID"].ToString();
                        xResponse.Descripcion = xDr["Descripcion"].ToString();
              

                    }
                }
                xDr.Close();
                xCon.Close();
                xDr = null;
            }
            return xResponse;

        }

        public List<MCategoria> xListCategoria()
        {
            List<MCategoria> xResponse=new List<MCategoria>();
            SqlDataReader xDr = null;
            SqlConnection xCon = null;

            MResponse xre= f.ExecuteStoredProcedure("LIS_CATEGORIA", ref xDr, ref xCon);
            if (xre.iExito==true)
            {
                if (xDr.HasRows)
                {
                    while (xDr.Read())
                    {
                        xResponse.Add(new MCategoria()
                        {
                            ID = xDr["ID"].ToString(),
                            Descripcion=xDr["Descripcion"].ToString(),
                        });
                    }
                }
                xDr.Close();
                xCon.Close();
                xDr = null;
            }
            return xResponse;

        } 

        public object xUpdateCategoriaProcedure(string ID, MCategoria model)
        {
            MResponse resp = null;
            List<object> list = new List<object>();
            SqlDataReader xDr = null;
            SqlConnection xCon = null;
            model.ID = ID;
            resp = f.ExecuteStoredProcedure("UPDATE_CATEGORIA", model, ref xDr, ref xCon);
            if (resp.iExito == true)
            {
                if (xDr.HasRows)
                {
                    while (xDr.Read())
                    {

                        list.Add(new MCategoria()
                        {
                            ID = xDr["ID"].ToString(),
                            Descripcion = xDr["Descripcion"].ToString()
                        });
                    }
                }
                xDr.Close();
                xCon.Close();
                xDr = null;

                return list;
            }
            else
            {
                return resp;
            }

        }
        public object xSaveCategoriaProcedure(MCategoria model)
        {
            MResponse resp = null;
            List<object> list = new List<object>();
            SqlDataReader xDr = null;
            SqlConnection xCon = null;
            resp = f.ExecuteStoredProcedure("PROC_CATEGORIA_NS", model,ref xDr,ref xCon);
            if (resp.iExito==true)
            {
                if (xDr.HasRows)
                {
                    while (xDr.Read())
                    {

                        list.Add(new MCategoria()
                        {
                            ID = xDr["ID"].ToString(),
                            Descripcion = xDr["Descripcion"].ToString()
                        });
                    }
                }
                xDr.Close();
                xCon.Close();
                xDr = null;
          
                return list;
            }
            else
            {
                return resp;
            }
            
        }
        /// <summary>
        /// CON VARIABLE DE StatementType
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object xSaveCategoriaProcedureStatementType(MCategoriaS model)
        {
            MResponse resp = null;
            List<object> list = new List<object>();
            SqlDataReader xDr = null;
            SqlConnection xCon = null;
            resp = f.ExecuteStoredProcedure("PROC_CATEGORIA", model, ref xDr, ref xCon);
            if (resp.iExito == true)
            {
                if (xDr.HasRows)
                {
                    while (xDr.Read())
                    {

                        list.Add(new MCategoria()
                        {
                            ID = xDr["ID"].ToString(),
                            Descripcion = xDr["Descripcion"].ToString()
                        });
                    }
                }
                xDr.Close();
                xCon.Close();
                xDr = null;

                return list;
            }
            else
            {
                return resp;
            }

        }
    }
}
