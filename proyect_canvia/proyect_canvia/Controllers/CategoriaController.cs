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
    [RoutePrefix("api/Categoria")]
    public class CategoriaController : ApiController
    {
        // GET api/values
        public List<MCategoria> Get()
        {
            dbCategoria db=new dbCategoria();
            List<MCategoria> x = db.xListCategoria(); 
            return x;
        }

        // GET api/values/5
        public MCategoria Get(string id)
        {
            dbCategoria db = new dbCategoria();
            MCategoria res = db.tCategoriaXcodigo(id);

            return res;
        }
        // GET api/values/5
        [Route("GetPaginado/{PageIndex}/{PageSize}")]
        [HttpGet]
        public List<MCategoria> GetPaginado(int PageIndex,int PageSize)
        {
            dbCategoria db = new dbCategoria();
            List<MCategoria> res = db.tCategoriaPaginado(PageIndex,PageSize);

            return res;
        }


        // POST api/values ESTO ES UN MATENIMINJETO SIN LA VARIABLE StatementType
        [HttpPost]
        [Route("PostSINStatementType")]
        public IHttpActionResult PostSINStatementType([FromBody] MCategoriaS value)//Categoria/PostSINStatementType
        {
            dbCategoria db = new dbCategoria();
            object xres = db.xSaveCategoriaProcedureStatementType(value);
            return Ok(xres);
         
        }

        // POST api/values ESTO ES UN MATENIMINJETO CON LA VARIABLE StatementType
        public IHttpActionResult Post([FromBody] MCategoria value)
        {
            dbCategoria db = new dbCategoria();
            object xres = db.xSaveCategoriaProcedure(value);
            return Ok(xres);
        }

        // PUT api/values/5
        public IHttpActionResult Put(string id, [FromBody] MCategoria value)
        {
            dbCategoria db = new dbCategoria();
            object xres = db.xUpdateCategoriaProcedure(id,value);
            return Ok(xres);
        }

        // DELETE api/values/5
        public List<MCategoria> Delete(string id)
        {
            dbCategoria db = new dbCategoria();
           List<MCategoria> res = db.deletecategoria(id);

            return res;
        }
    }
}
