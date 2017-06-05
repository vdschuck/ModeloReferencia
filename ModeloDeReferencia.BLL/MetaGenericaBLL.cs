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
    public class MetaGenericaBLL : IMetaGenericaBLL
    {
        private readonly IMetaGenericaDAL _metaGenericaDAL = new MetaGenericaDAL();

        public int Delete(int Id)
        {
            return _metaGenericaDAL.Delete(Id);
        }

        public IEnumerable<MetaGenerica> GetAll()
        {
            return _metaGenericaDAL.GetAll();
        }

        public MetaGenerica GetById(int Id)
        {
            return _metaGenericaDAL.GetById(Id);
        }

        public int Insert(MetaGenerica metaGenerica)
        {
            return _metaGenericaDAL.Insert(metaGenerica);
        }

        public int Update(MetaGenerica metaGenerica)
        {
            return _metaGenericaDAL.Update(metaGenerica);
        }
    }
}
