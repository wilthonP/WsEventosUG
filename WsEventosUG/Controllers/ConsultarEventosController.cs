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
    public class ConsultarEventosController : ApiController
    {
        private dbEventosUGEntities db = new dbEventosUGEntities();

        public IEnumerable<spConsultarEventos_Result> Get(int id_usuario, int id_evento)
        {

            SqlParameter usuarioParam = new SqlParameter("id_usuario", id_usuario);
            SqlParameter eventoParam = new SqlParameter("id_evento", id_evento);
            object[] parameters = new object[] { usuarioParam, eventoParam };

            return db.Database.SqlQuery<spConsultarEventos_Result>("spConsultarEventos @id_usuario, @id_evento", parameters).ToList();
        }
    }
}
