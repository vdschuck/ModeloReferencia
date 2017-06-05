using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DAL.Intefaces
{
    public interface INivelCapacidadeDAL
    {
        IEnumerable<NivelCapacidade> GetAll();

        NivelCapacidade GetById(int Id);

        int Insert(NivelCapacidade nivelCapacidade);

        int Update(NivelCapacidade nivelCapacidade);

        int Delete(int Id);
    }
}
