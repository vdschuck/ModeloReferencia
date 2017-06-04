using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DAL.Intefaces
{
    public interface IPraticaEspecificaDAL
    {
        IEnumerable<PraticaEspecifica> GetAll();

        PraticaEspecifica GetById(int Id);

        int Insert(PraticaEspecifica praticaEspecifica);

        int Update(PraticaEspecifica praticaEspecifica);

        int Delete(int Id);
    }
}
