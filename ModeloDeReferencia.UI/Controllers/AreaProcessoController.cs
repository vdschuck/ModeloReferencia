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
    public class AreaProcessoController : Controller
    {
        private readonly IAreaProcessoBLL _areaProcessoBLL = new AreaProcessoBLL();
        private readonly ICategoriaBLL _categoriaBLL = new CategoriaBLL();
        private readonly INivelMaturidadeBLL _nivelMaturidadeBLL = new NivelMaturidadeBLL();
        private readonly IModeloBLL _modeloBLL = new ModeloBLL();

        public ActionResult GetAll()
        {
            var _listAreaProcesso = _areaProcessoBLL.GetAll().OrderBy(x => x.Nome).ToList();           

            foreach (var _areaProcesso in _listAreaProcesso)
            {
                _areaProcesso.NivelMaturidade = _nivelMaturidadeBLL.GetById(_areaProcesso.NivelMaturidadeId);
                _areaProcesso.Categoria = _categoriaBLL.GetById(_areaProcesso.CategoriaId);
                _areaProcesso.Modelo = _modeloBLL.GetById(_areaProcesso.ModeloId);
            }

            var list = new { listAreaProcesso = _listAreaProcesso };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllSmallTypes()
        {
            var _listCategoria = _categoriaBLL.GetAll().OrderBy(x => x.Nome).ToList();
            var _listNivelMaturidade = _nivelMaturidadeBLL.GetAll().OrderBy(x => x.Nome).ToList();
            var _listModelo = _modeloBLL.GetAll().OrderBy(x => x.Nome).ToList();

            var list = new {  listCategoria = _listCategoria, listNivelMaturidade = _listNivelMaturidade, listModelo = _listModelo };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int Id)
        {
            var result = _areaProcessoBLL.GetById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(AreaProcesso areaProcesso)
        {
            var request = _areaProcessoBLL.Insert(areaProcesso);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Update(AreaProcesso areaProcesso)
        {
            var request = _areaProcessoBLL.Update(areaProcesso);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Delete(int Id)
        {
            var request = _areaProcessoBLL.Delete(Id);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}