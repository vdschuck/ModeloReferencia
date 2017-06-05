using ModeloDeReferencia.BLL;
using ModeloDeReferencia.BLL.Interfaces;
using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ModeloDeReferencia.UI.Controllers
{
    public class NivelCapacidadeController : Controller
    {
        private readonly INivelCapacidadeBLL _nivelCapacidadeBLL = new NivelCapacidadeBLL();

        public ActionResult GetAll()
        {
            var _listNivelCapacidade = _nivelCapacidadeBLL.GetAll().OrderBy(x => x.Nome).ToList();

            var list = new { listNivelCapacidade = _listNivelCapacidade };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int Id)
        {
            var result = _nivelCapacidadeBLL.GetById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(NivelCapacidade nivelCapacidade)
        {
            var request = _nivelCapacidadeBLL.Insert(nivelCapacidade);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Update(NivelCapacidade nivelCapacidade)
        {
            var request = _nivelCapacidadeBLL.Update(nivelCapacidade);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Delete(int Id)
        {
            var request = _nivelCapacidadeBLL.Delete(Id);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}