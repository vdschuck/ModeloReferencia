using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DAL.Intefaces
{
    public interface IAreaProcessoDAL
    {
        IEnumerable<AreaProcesso> GetAll();

        AreaProcesso GetById(int Id);

        int Insert(AreaProcesso areaProcesso);

        int Update(AreaProcesso areaProcesso);

        int Delete(int Id);
    }
}
