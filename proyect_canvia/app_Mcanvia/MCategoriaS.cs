using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_Mcanvia
{
    public class MCategoriaS
    {
        public MCategoriaS()
        {
            this.ID = "";
            this.Descripcion = "";
            this.StatementType = "";
        }
        public string ID { get; set; }
        public string Descripcion { get; set; }
        public string StatementType { get; set; }
    }
}
