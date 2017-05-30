using ModeloDeReferencia.BLL.Interfaces;
using ModeloDeReferencia.DAL;
using ModeloDeReferencia.DAL.Intefaces;
using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.BLL
{
    public class NivelMaturidadeBLL : INivelMaturidadeBLL
    {
        private readonly INivelMaturidadeDAL _nivelMaturidadeDAL = new NivelMaturidadeDAL();

        public int Delete(int Id)
        {
            return _nivelMaturidadeDAL.Delete(Id);
        }

        public IEnumerable<NivelMaturidade> GetAll()
        {
            return _nivelMaturidadeDAL.GetAll();
        }

        public NivelMaturidade GetById(int Id)
        {
            return _nivelMaturidadeDAL.GetById(Id);
        }

        public int Insert(NivelMaturidade nivelMaturidade)
        {
            return _nivelMaturidadeDAL.Insert(nivelMaturidade);
        }

        public int Update(NivelMaturidade nivelMaturidade)
        {
            return _nivelMaturidadeDAL.Update(nivelMaturidade);
        }
    }
}
