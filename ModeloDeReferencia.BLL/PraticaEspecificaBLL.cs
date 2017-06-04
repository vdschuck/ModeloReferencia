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
    public class PraticaEspecificaBLL : IPraticaEspecificaBLL
    {
        private readonly IPraticaEspecificaDAL _praticaEspecificaDAL = new PraticaEspecificaDAL();
        public int Delete(int Id)
        {
            return _praticaEspecificaDAL.Delete(Id);
        }

        public IEnumerable<PraticaEspecifica> GetAll()
        {
            return _praticaEspecificaDAL.GetAll();
        }

        public PraticaEspecifica GetById(int Id)
        {
            return _praticaEspecificaDAL.GetById(Id);
        }

        public int Insert(PraticaEspecifica praticaEspecifica)
        {
            return _praticaEspecificaDAL.Insert(praticaEspecifica);
        }

        public int Update(PraticaEspecifica praticaEspecifica)
        {
            return _praticaEspecificaDAL.Update(praticaEspecifica);
        }
    }
}
