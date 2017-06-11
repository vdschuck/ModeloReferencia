using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.BLL.Interfaces
{
    public interface IAreaProcessoBLL
    {
        IEnumerable<AreaProcesso> GetAll();

        AreaProcesso GetById(int Id);

        IEnumerable<AreaProcesso> Get(string Parameter, int Value);

        int Insert(AreaProcesso areaProcesso);

        int Update(AreaProcesso areaProcesso);

        int Delete(int Id);
    }
}
