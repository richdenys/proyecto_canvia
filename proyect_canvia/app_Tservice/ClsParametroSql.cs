using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_Tservice
{
    public class ClsParametroSql
    {
        public String sCampo { get; set; }
        public String sValorCampo { get; set; }
        public SqlDbType sTipCampo { get; set; }

        public ClsParametroSql()
        {
            sCampo = "";
            sValorCampo = "";
            sTipCampo = SqlDbType.Char;
        }
    }
}
