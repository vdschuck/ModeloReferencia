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
    public class ProdutoTrabalhoController : Controller
    {
        private readonly IProdutoTrabalhoBLL _produtoTrabalhoBLL = new ProdutoTrabalhoBLL();

        public ActionResult GetAll()
        {
            var _listProdutoTrabalho = _produtoTrabalhoBLL.GetAll().OrderBy(x => x.Nome).ToList();

            var list = new { listProdutoTrabalho = _listProdutoTrabalho };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int Id)
        {
            var result = _produtoTrabalhoBLL.GetById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(ProdutoTrabalho produtoTrabalho)
        {
            var request = _produtoTrabalhoBLL.Insert(produtoTrabalho);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Update(ProdutoTrabalho produtoTrabalho)
        {
            var request = _produtoTrabalhoBLL.Update(produtoTrabalho);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult Delete(int Id)
        {
            var request = _produtoTrabalhoBLL.Delete(Id);

            return request > 0 ? new HttpStatusCodeResult(HttpStatusCode.OK) : new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}