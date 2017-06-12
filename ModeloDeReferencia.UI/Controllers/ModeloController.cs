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
    public class ModeloController : Controller
    {
        private readonly IModeloBLL _modeloBLL = new ModeloBLL();
        private readonly IAreaProcessoBLL _areaProcessoBLL = new AreaProcessoBLL();
        private readonly IMetaGenericaBLL _metaGenericaBLL = new MetaGenericaBLL();
        private readonly INivelCapacidadeBLL _nivelCapacidadeBLL = new NivelCapacidadeBLL();
        private readonly INivelMaturidadeBLL _nivelMaturidadeBLL = new NivelMaturidadeBLL();
        private readonly ICategoriaBLL _categoriaBLL = new CategoriaBLL();
        private readonly IMetaEspecificaBLL _metaEspecificaBLL = new MetaEspecificaBLL();
        private readonly IPraticaEspecificaBLL _praticaEspecificaBLL = new PraticaEspecificaBLL();
        private readonly IProdutoTrabalhoBLL _produtoTrabalhoBLL = new ProdutoTrabalhoBLL();

        public ActionResult GetAll()
        {
            var _listModelo = _modeloBLL.GetAll().OrderBy(x => x.Nome).ToList();            

            var list = new { listModelo = _listModelo };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int Id)
        {
            var result = _modeloBLL.GetById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(Modelo modelo)
        {
            var request = _modeloBLL.Insert(modelo);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Update(Modelo modelo)
        {
            var request = _modeloBLL.Update(modelo);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Delete(int Id)
        {
            var request = _modeloBLL.Delete(Id);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Show(Modelo modelo)
        {
            var _listAreaProcesso = _areaProcessoBLL.Get("modeloId", modelo.Id);
            var _listMetaGenerica = _metaGenericaBLL.Get("modeloId", modelo.Id);
            var _listMetaEspecifica = (IEnumerable<MetaEspecifica>) null;
            var _listPraticaEspecifica= (IEnumerable<PraticaEspecifica>) null;

            foreach (var _metaGenerica in _listMetaGenerica) {
                _metaGenerica.NivelCapacidade = _nivelCapacidadeBLL.GetById(_metaGenerica.NivelCapacidadeId);
            }

            foreach (var _areaProcesso in _listAreaProcesso)
            {
                _listMetaEspecifica = _metaEspecificaBLL.Get("areaProcessoId", _areaProcesso.Id);

                _areaProcesso.NivelMaturidade = _nivelMaturidadeBLL.GetById(_areaProcesso.NivelMaturidadeId);
                _areaProcesso.Categoria = _categoriaBLL.GetById(_areaProcesso.CategoriaId);
                
            }

            foreach(var _metaEspecifica in _listMetaEspecifica)
            {
                _listPraticaEspecifica = _praticaEspecificaBLL.Get("metaEspecificaId", _metaEspecifica.Id);
            }

            foreach(var _praticaEspecifica in _listPraticaEspecifica)
            {
                _praticaEspecifica.ProdutoTrabalho = _produtoTrabalhoBLL.GetById(_praticaEspecifica.ProdutoTrabalhoId);
            }

            var list = new { listAreaProcesso = _listAreaProcesso, listMetaGenerica = _listMetaGenerica, listMetaEspecifica = _listMetaEspecifica, listPraticaEspecifica = _listPraticaEspecifica };

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}