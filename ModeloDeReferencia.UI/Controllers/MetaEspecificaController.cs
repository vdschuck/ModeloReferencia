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
    public class MetaEspecificaController : Controller
    {
        private readonly IMetaEspecificaBLL _metaEspecificaBLL = new MetaEspecificaBLL();
        private readonly IAreaProcessoBLL _areaProcessoBLL = new AreaProcessoBLL();

        public ActionResult GetAll()
        {
            var _listMetaEspecifica = _metaEspecificaBLL.GetAll().OrderBy(x => x.Nome).ToList();

            foreach (var _metaEspecifica in _listMetaEspecifica)
            {
                _metaEspecifica.AreaProcesso = _areaProcessoBLL.GetById(_metaEspecifica.AreaProcessoId);               
            }

            var list = new { listMetaEspecifica = _listMetaEspecifica };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllSmallTypes()
        {
            var _listAreaProcesso = _areaProcessoBLL.GetAll();

            var list = new { listAreaProcesso = _listAreaProcesso };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int Id)
        {
            var result = _metaEspecificaBLL.GetById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(MetaEspecifica metaEspecifica)
        {
            var request = _metaEspecificaBLL.Insert(metaEspecifica);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Update(MetaEspecifica metaEspecifica)
        {
            var request = _metaEspecificaBLL.Update(metaEspecifica);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Delete(int Id)
        {
            var request = _metaEspecificaBLL.Delete(Id);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}