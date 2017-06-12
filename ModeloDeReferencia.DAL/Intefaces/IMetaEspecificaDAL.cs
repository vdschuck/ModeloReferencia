using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DAL.Intefaces
{
    public interface IMetaEspecificaDAL
    {
        IEnumerable<MetaEspecifica> GetAll();

        MetaEspecifica GetById(int Id);

        IEnumerable<MetaEspecifica> Get(string Parameter, int Value);

        int Insert(MetaEspecifica metaEspecifica);

        int Update(MetaEspecifica metaEspecifica);

        int Delete(int Id);
    }
}
