using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WsEventosUG.Models;


namespace WsEventosUG.Controllers
{
    public class ConsultarLoginController : ApiController
    {
        private dbEventosUGEntities db = new dbEventosUGEntities();

        public IEnumerable<spConsultarLogin_Result> Get(string correo, string clave)
        {
            
             SqlParameter correoParam = new SqlParameter("correo", correo);
             SqlParameter claveParam = new SqlParameter("clave", clave);
             object[] parameters = new object[] { correoParam, claveParam };
             
            return db.Database.SqlQuery<spConsultarLogin_Result>("spConsultarLogin @correo, @clave", parameters).ToList();
        }
    }
}
