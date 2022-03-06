
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_Mcanvia;
using app_Tservice;

namespace app_dbcavia
{
    public class dbProducto
    {

        ClsFunciones f = null;
        public dbProducto()
        {
            this.f = new ClsFunciones();
        }
        public List<MProducto> deleteproducto(string ID)
        {
            List<MProducto> xResponse = null;
            SqlDataReader xDr = null;
            SqlConnection xCon = null;

            modelFiltroID xFiltro = new modelFiltroID() { ID = ID };

            MResponse xre = f.ExecuteStoredProcedure("DEL_PRODUCTO", xFiltro, ref xDr, ref xCon);
            if (xre.iExito == true)
            {
                if (xDr.HasRows)
                {
                    xResponse = new List<MProducto>();
                    while (xDr.Read())
                    {
                        xResponse.Add(new MProducto()
                        {
                            ID = xDr["ID"].ToString(),
                            Descripcion = xDr["Descripcion"].ToString(),
                            Cantidad = decimal.Parse(xDr["Cantidad"].ToString()),
                            Precio = decimal.Parse(xDr["Precio"].ToString()),
                            CategoriaID = xDr["CategoriaID"].ToString()
                        });

                    }
                }
                xDr.Close();
                xCon.Close();
                xDr = null;
            }
            return xResponse;

        }

        public List<MProducto> tProductoPaginado(int PageIndex, int PageSize)
        {
            List<MProducto> xResponse = null;
            SqlDataReader xDr = null;
            SqlConnection xCon = null;
            Mpaginacion xFiltro = new Mpaginacion() { PageIndex = PageIndex, PageSize = PageSize, RecordCount = 1 };

            MResponse xre = f.ExecuteStoredProcedure("LIST_PAGINADO_PRODUCTO", xFiltro, ref xDr, ref xCon);
            if (xre.iExito == true)
            {
                if (xDr.HasRows)
                {
                    xResponse = new List<MProducto>();
                    while (xDr.Read())
                    {
                        xResponse.Add(new MProducto()
                        {
                            ID = xDr["ID"].ToString(),
                            Descripcion = xDr["Descripcion"].ToString(),
                            Cantidad = decimal.Parse(xDr["Cantidad"].ToString()),
                            Precio = decimal.Parse(xDr["Precio"].ToString()),
                            CategoriaID = xDr["CategoriaID"].ToString()

                        });

                    }
                }
                xDr.Close();
                xCon.Close();
                xDr = null;
            }
            return xResponse;

        }

        public MProducto tProductoXcodigo(string xCodigo)
        {
            MProducto xResponse =null;
            SqlDataReader xDr = null;
            SqlConnection xCon = null;
            modelFiltroID xFiltro = new modelFiltroID() { ID=xCodigo} ;
            
            MResponse xre = f.ExecuteStoredProcedure("XCOD_PRODUCTO", xFiltro, ref xDr, ref xCon);
            if (xre.iExito == true)
            {
                if (xDr.HasRows)
                {
                    xResponse = new MProducto();
                    while (xDr.Read())
                    {
                        xResponse.ID = xDr["ID"].ToString();
                        xResponse.Descripcion = xDr["Descripcion"].ToString();
                        xResponse.Cantidad = decimal.Parse(xDr["Cantidad"].ToString());
                        xResponse.Precio = decimal.Parse(xDr["Precio"].ToString());
                        xResponse.CategoriaID = xDr["CategoriaID"].ToString();
                        
                    }
                }
                xDr.Close();
                xCon.Close();
                xDr = null;
            }
            return xResponse;

        }

        public List<MProducto> xListProducto()
        {
            List<MProducto> xResponse = new List<MProducto>();
            SqlDataReader xDr = null;
            SqlConnection xCon = null;

            MResponse xre = f.ExecuteStoredProcedure("LIST_PRODUCTO", ref xDr, ref xCon);
            if (xre.iExito == true)
            {
                if (xDr.HasRows)
                {
                    while (xDr.Read())
                    {
                        xResponse.Add(new MProducto()
                        {
                            ID = xDr["ID"].ToString(),
                            Descripcion = xDr["Descripcion"].ToString(),
                            Cantidad = decimal.Parse(xDr["Cantidad"].ToString()),
                            Precio = decimal.Parse(xDr["Precio"].ToString()),
                            CategoriaID = xDr["CategoriaID"].ToString()
                        });
                    }
                }
                xDr.Close();
                xCon.Close();
                xDr = null;
            }
            return xResponse;

        }
        public object xupdateRroductionProcedure(string id, MProducto model)
        {
            MResponse resp = null;
            List<MProducto> list = new List<MProducto>();
            SqlDataReader xDr = null;
            SqlConnection xCon = null;
            model.ID = id;
            resp = f.ExecuteStoredProcedure("UPDATE_PRODUCTO", model, ref xDr, ref xCon);
            if (resp.iExito == true)
            {
                if (xDr.HasRows)
                {
                    while (xDr.Read())
                    {
                        list.Add(new MProducto()
                        {
                            ID = xDr["ID"].ToString(),
                            Descripcion = xDr["Descripcion"].ToString(),
                            Cantidad = decimal.Parse(xDr["Cantidad"].ToString()),
                            Precio = decimal.Parse(xDr["Precio"].ToString()),
                            CategoriaID = xDr["CategoriaID"].ToString()
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
        public Object xSaveRroductionProcedure(MProducto model)
        {
            MResponse resp = null;
            List<MProducto> list = new List<MProducto>();
            SqlDataReader xDr = null;
            SqlConnection xCon = null;
            resp = f.ExecuteStoredProcedure("PROC_PRODUCT_NS", model, ref xDr, ref xCon);
            if (resp.iExito == true)
            {
                if (xDr.HasRows)
                {
                    while (xDr.Read())
                    {
                        list.Add(new MProducto()
                        {
                            ID = xDr["ID"].ToString(),
                            Descripcion = xDr["Descripcion"].ToString(),
                            Cantidad = decimal.Parse(xDr["Cantidad"].ToString()),
                            Precio = decimal.Parse(xDr["Precio"].ToString()),
                            CategoriaID = xDr["CategoriaID"].ToString()
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
        public Object xSaveRroductionProcedureStatementType(MProductoS model)
        {
           MResponse resp=null;
            List<MProducto> list=new List<MProducto>();
            SqlDataReader xDr = null;
            SqlConnection xCon = null;
            resp=f.ExecuteStoredProcedure("PROC_PRODUCT", model,ref xDr,ref xCon );
            if (resp.iExito==true)
            {
                if (xDr.HasRows)
                {
                    while (xDr.Read())
                    {
                        list.Add(new MProducto()
                        {
                            ID=xDr["ID"].ToString(),
                            Descripcion=xDr["Descripcion"].ToString(),
                            Cantidad=decimal.Parse(xDr["Cantidad"].ToString()),
                            Precio=decimal.Parse(xDr["Precio"].ToString()),
                            CategoriaID=xDr["CategoriaID"].ToString()
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
