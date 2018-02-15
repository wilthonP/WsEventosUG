using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WsEventosUG.Models;

namespace WsEventosUG.Controllers
{
    public class ConsultarPreferenciasController : ApiController
    {
        private dbEventosUGEntities db = new dbEventosUGEntities();
        public IEnumerable<spConsultarPreferencias_Result> Get()
        {
            return db.Database.SqlQuery<spConsultarPreferencias_Result>("spConsultarPreferencias").ToList();
        }
    }
}
