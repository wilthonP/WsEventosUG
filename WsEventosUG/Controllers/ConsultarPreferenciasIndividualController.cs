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
    public class ConsultarPreferenciasIndividualController : ApiController
    {
        private dbEventosUGEntities db = new dbEventosUGEntities();
        public IEnumerable<spConsultarPreferenciasIndividual_Result> Get(int id_usuario)
        {
            SqlParameter usuarioParam = new SqlParameter("id_usuario", id_usuario);
            object[] parameters = new object[] { usuarioParam };

            return db.Database.SqlQuery<spConsultarPreferenciasIndividual_Result>("spConsultarPreferenciasIndividual @id_usuario", parameters).ToList();

        }
    }
}
