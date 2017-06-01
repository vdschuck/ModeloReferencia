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
    public class AreaProcessoBLL : IAreaProcessoBLL
    {
        private readonly IAreaProcessoDAL _areaProcessoDAL = new AreaProcessoDAL();        

        public int Delete(int Id)
        {
            return _areaProcessoDAL.Delete(Id);
        }

        public IEnumerable<AreaProcesso> GetAll()
        {
            return _areaProcessoDAL.GetAll();
        }

        public AreaProcesso GetById(int Id)
        {
            return _areaProcessoDAL.GetById(Id);
        }

        public int Insert(AreaProcesso areaProcesso)
        {
            return _areaProcessoDAL.Insert(areaProcesso);
        }

        public int Update(AreaProcesso areaProcesso)
        {
            return _areaProcessoDAL.Update(areaProcesso);
        }
    }
}
