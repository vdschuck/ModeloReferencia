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
    public class PraticaEspecificaController : Controller
    {
        private readonly IPraticaEspecificaBLL _praticaEspecificaBLL = new PraticaEspecificaBLL();
        private readonly IMetaEspecificaBLL _metaEspecificaBLL = new MetaEspecificaBLL();
        private readonly IProdutoTrabalhoBLL _produtoTrabalhoBLL = new ProdutoTrabalhoBLL();

        public ActionResult GetAll()
        {
            var _listPraticaEspecifica = _praticaEspecificaBLL.GetAll().OrderBy(x => x.Nome).ToList();

            foreach (var _praticaEspecifica in _listPraticaEspecifica)
            {
                _praticaEspecifica.MetaEspecifica = _metaEspecificaBLL.GetById(_praticaEspecifica.MetaEspecificaId);
                _praticaEspecifica.ProdutoTrabalho = _produtoTrabalhoBLL.GetById(_praticaEspecifica.ProdutoTrabalhoId);
            }

            var list = new { listPraticaEspecifica = _listPraticaEspecifica };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllSmallTypes()
        {
            var _listMetaEspecifica = _metaEspecificaBLL.GetAll().OrderBy(x => x.Nome).ToList();
            var _listProdutoTrabalho = _produtoTrabalhoBLL.GetAll().OrderBy(x => x.Nome).ToList();

            var list = new { listMetaEspecifica = _listMetaEspecifica, listProdutoTrabalho = _listProdutoTrabalho };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int Id)
        {
            var result = _praticaEspecificaBLL.GetById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(PraticaEspecifica praticaEspecifica)
        {
            var request = _praticaEspecificaBLL.Insert(praticaEspecifica);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Update(PraticaEspecifica praticaEspecifica)
        {
            var request = _praticaEspecificaBLL.Update(praticaEspecifica);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Delete(int Id)
        {
            var request = _praticaEspecificaBLL.Delete(Id);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}