using ModeloDeReferencia.BLL;
using ModeloDeReferencia.BLL.Interfaces;
using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModeloDeReferencia.UI.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ITemplateBLL _templateBLL = new TemplateBLL();

        [HttpPost]
        public ActionResult Upload(string description)
        {
            string Message, fileName, actualFileName;
            Message = fileName = actualFileName = string.Empty;
            bool flag = false;

            if (Request.Files != null)
            {
                var file = Request.Files[0];
                actualFileName = file.FileName;
                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                int size = file.ContentLength;               

                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/upload"), fileName));

                    Template template = new Template
                    {
                        Nome = actualFileName,
                        Arquivo = size,
                        Descricao = description,
                        Diretorio = ""
                    };

                    var result = Insert(template);
                    flag = true;

                }
                catch (Exception)
                {
                    Message = "File upload failed! Please try again!";
                }
            }

            var Data = new { Message = Message, Status = flag };

            return Json(Data, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]           
        public ActionResult Insert(Template template)
        {
            var request = _templateBLL.Insert(template);

            return Json(JsonRequestBehavior.AllowGet);
        }



    }
}