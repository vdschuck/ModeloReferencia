using ModeloDeReferencia.BLL;
using ModeloDeReferencia.BLL.Interfaces;
using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Net;
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


        [HttpPost]
        public ActionResult Upload()
        {
            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            int request = 0;
            string[] data = new string[hfc.Count];
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/upload/");


            try
            {    
                for (int i = 0; i <= hfc.Count - 1; i++)
                {
                    System.Web.HttpPostedFile hpf = hfc[i];

                    if (hpf.ContentLength > 0)
                    {
                        if (!System.IO.File.Exists(path + Path.GetFileName(hpf.FileName)))
                        {
                            hpf.SaveAs(path + Path.GetFileName(hpf.FileName));
                            data[i] = hpf.FileName;
                            request += 1;
                        }
                        else
                        {
                            throw new Exception("Existe um arquivo salvo com o mesmo nome! ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }

            return data.Length > 0 ? Json(data, JsonRequestBehavior.AllowGet) : Json(HttpStatusCode.Forbidden);
        }
    }
}