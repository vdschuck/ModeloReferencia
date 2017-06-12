using ModeloDeReferencia.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeReferencia.DTO;
using ModeloDeReferencia.DAL.Intefaces;
using ModeloDeReferencia.DAL;

namespace ModeloDeReferencia.BLL
{
    public class MetaEspecificaBLL : IMetaEspecificaBLL
    {
        private readonly IMetaEspecificaDAL _metaEspecificaDAL = new MetaEspecificaDAL();

        public int Delete(int Id)
        {
            return _metaEspecificaDAL.Delete(Id);
        }

        public IEnumerable<MetaEspecifica> GetAll()
        {
            return _metaEspecificaDAL.GetAll();
        }

        public MetaEspecifica GetById(int Id)
        {
            return _metaEspecificaDAL.GetById(Id);
        }

        public IEnumerable<MetaEspecifica> Get(string Parameter, int Value)
        {
            return _metaEspecificaDAL.Get(Parameter, Value);
        }

        public int Insert(MetaEspecifica metaEspecifica)
        {
            return _metaEspecificaDAL.Insert(metaEspecifica);
        }

        public int Update(MetaEspecifica metaEspecifica)
        {
            return _metaEspecificaDAL.Update(metaEspecifica);
        }
    }
}
