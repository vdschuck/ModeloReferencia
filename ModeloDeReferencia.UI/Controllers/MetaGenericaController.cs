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
    public class MetaGenericaController : Controller
    {
        private readonly IMetaGenericaBLL _metaGenericaBLL = new MetaGenericaBLL();
        private readonly IModeloBLL _modeloBLL = new ModeloBLL();
        private readonly INivelCapacidadeBLL _nivelCapacidadeBLL = new NivelCapacidadeBLL();

        public ActionResult GetAll()
        {
            var _listMetaGenerica = _metaGenericaBLL.GetAll().OrderBy(x => x.Nome).ToList();

            foreach (var _metaGenerica in _listMetaGenerica)
            {
                _metaGenerica.Modelo = _modeloBLL.GetById(_metaGenerica.ModeloId);
                _metaGenerica.NivelCapacidade = _nivelCapacidadeBLL.GetById(_metaGenerica.NivelCapacidadeId);
            }

            var list = new { listMetaGenerica = _listMetaGenerica };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllSmallTypes()
        {
            var _listNivelCapacidade = _nivelCapacidadeBLL.GetAll().OrderBy(x => x.Nome).ToList();
            var _listModelo= _modeloBLL.GetAll().OrderBy(x => x.Nome).ToList();

            var list = new { listModelo = _listModelo, listNivelCapacidade = _listNivelCapacidade };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int Id)
        {
            var result = _metaGenericaBLL.GetById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(MetaGenerica metaGenerica)
        {
            var request = _metaGenericaBLL.Insert(metaGenerica);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Update(MetaGenerica metaGenerica)
        {
            var request = _metaGenericaBLL.Update(metaGenerica);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Delete(int Id)
        {
            var request = _metaGenericaBLL.Delete(Id);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}