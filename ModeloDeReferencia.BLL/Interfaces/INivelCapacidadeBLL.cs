using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.BLL.Interfaces
{
    public interface INivelCapacidadeBLL
    {
        IEnumerable<NivelCapacidade> GetAll();

        NivelCapacidade GetById(int Id);

        int Insert(NivelCapacidade nivelCapacidade);

        int Update(NivelCapacidade nivelCapacidade);

        int Delete(int Id);
    }
}
