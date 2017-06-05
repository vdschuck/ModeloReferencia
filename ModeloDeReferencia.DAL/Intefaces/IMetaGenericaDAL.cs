using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DAL.Intefaces
{
    public interface IMetaGenericaDAL
    {
        IEnumerable<MetaGenerica> GetAll();

        MetaGenerica GetById(int Id);

        int Insert(MetaGenerica metaGenerica);

        int Update(MetaGenerica metaGenerica);

        int Delete(int Id);
    }
}
