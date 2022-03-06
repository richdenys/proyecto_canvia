using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_Mcanvia
{
    public class MProducto
    {
        public MProducto()
        {
            this.ID = "";
            this.Descripcion = "";
            this.Precio = 0;
            this.Cantidad = 0;
            this.CategoriaID = "";
          
        }

        public string ID { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public string CategoriaID { get; set; }
    
    }
}
