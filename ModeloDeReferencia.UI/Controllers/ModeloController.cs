﻿using ModeloDeReferencia.BLL;
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

        public ActionResult GetAll()
        {
            var _listModelo = _modeloBLL.GetAll().OrderBy(x => x.Nome).ToList();

            foreach (var _modelo in _listModelo)
            {
                _modelo.AreaProcesso = _areaProcessoBLL.GetById(_modelo.AreaProcessoId);                
            }

            var list = new { listModelo = _listModelo };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllSmallTypes()
        {
            var _listAreaProcesso = _areaProcessoBLL.GetAll().OrderBy(x => x.Nome).ToList();            

            var list = new { listAreaProcesso = _listAreaProcesso };

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
    }
}