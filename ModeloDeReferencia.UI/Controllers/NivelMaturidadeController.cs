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
    public class NivelMaturidadeController : Controller
    {
        private readonly INivelMaturidadeBLL _nivelMaturidadeBLL = new NivelMaturidadeBLL();

        public ActionResult GetAll()
        {
            var _listNivelMaturidade = _nivelMaturidadeBLL.GetAll().OrderBy(x => x.Nome).ToList();

            var list = new { listNivelMaturidade = _listNivelMaturidade };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int Id)
        {
            var result = _nivelMaturidadeBLL.GetById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(NivelMaturidade nivelMaturidade)
        {
            var request = _nivelMaturidadeBLL.Insert(nivelMaturidade);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Update(NivelMaturidade nivelMaturidade)
        {
            var request = _nivelMaturidadeBLL.Update(nivelMaturidade);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Delete(int Id)
        {
            var request = _nivelMaturidadeBLL.Delete(Id);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}