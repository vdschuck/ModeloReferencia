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
    public class NivelCapacidadeBLL : INivelCapacidadeBLL
    {
        private readonly INivelCapacidadeDAL _nivelCapacidadeDAL = new NivelCapacidadeDAL();

        public int Delete(int Id)
        {
            return _nivelCapacidadeDAL.Delete(Id);
        }

        public IEnumerable<NivelCapacidade> GetAll()
        {
            return _nivelCapacidadeDAL.GetAll();
        }

        public NivelCapacidade GetById(int Id)
        {
            return _nivelCapacidadeDAL.GetById(Id);
        }

        public int Insert(NivelCapacidade nivelCapacidade)
        {
            return _nivelCapacidadeDAL.Insert(nivelCapacidade);
        }

        public int Update(NivelCapacidade nivelCapacidade)
        {
            return _nivelCapacidadeDAL.Update(nivelCapacidade);
        }
    }
}
