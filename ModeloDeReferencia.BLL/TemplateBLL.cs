using ModeloDeReferencia.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeReferencia.DTO;
using ModeloDeReferencia.DAL;
using ModeloDeReferencia.DAL.Intefaces;

namespace ModeloDeReferencia.BLL
{
    public class TemplateBLL : ITemplateBLL
    {
        private readonly ITemplateDAL _templateDAL = new TemplateDAL();

        public int Insert(Template template)
        {
            return _templateDAL.Insert(template);
        }
    }
}
