using app_dbcavia;
using app_Mcanvia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace proyect_canvia.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        // GET api/values
        public List<MProducto> Get()
        {
            dbProducto db = new dbProducto();
            List<MProducto> x = db.xListProducto();
            return x;
        }
        // GET api/values/5
        public MProducto Get(string id)
        {
            dbProducto db = new dbProducto();
            MProducto res = db.tProductoXcodigo(id);
       
            return res;
        }
        // GET api/values/5
        [Route("GetPaginado/{PageIndex}/{PageSize}")]
        [HttpGet]
        public List<MProducto> GetPaginado(int PageIndex, int PageSize)
        {
            dbProducto db = new dbProducto();
            List<MProducto> res = db.tProductoPaginado(PageIndex, PageSize);

            return res;
        }

        //GRABAR DATOS CON LA VARIABLE STATEMENTTYPE 
        [Route("xGrabarSinstamentType")]
        [HttpPost]
        public IHttpActionResult xGrabarSinstamentType([FromBody] MProductoS model)//Product/xGrabarSinstamentType
        {

            dbProducto db = new dbProducto();
            object xRe = db.xSaveRroductionProcedureStatementType(model);
            return Ok(xRe);

        }
        // POST api/values POST PARA GRABAR SIN STATEMENTTYPE
        [HttpPost]
        public IHttpActionResult Post([FromBody] MProducto model)
        {
            dbProducto db = new dbProducto();
            object xRe = db.xSaveRroductionProcedure(model);
            return Ok(xRe);
        
        }

        // PUT api/values/5
        public IHttpActionResult Put(string id, [FromBody] MProducto value)
        {
            dbProducto db = new dbProducto();
            object xRe = db.xupdateRroductionProcedure(id,value);
            return Ok(xRe);
        }

        // DELETE api/values/5
        public List<MProducto> Delete(string id)
        {
            dbProducto db = new dbProducto();
            List<MProducto> res = db.deleteproducto(id);

            return res;
        }
    }
}
