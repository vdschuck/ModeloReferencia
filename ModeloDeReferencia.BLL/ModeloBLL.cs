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
    public class ModeloBLL : IModeloBLL
    {
        private readonly IModeloDAL _modeloDAL = new ModeloDAL();

        public int Delete(int Id)
        {
            return _modeloDAL.Delete(Id);
        }

        public IEnumerable<Modelo> GetAll()
        {
            return _modeloDAL.GetAll();
        }

        public Modelo GetById(int Id)
        {
            return _modeloDAL.GetById(Id);
        }

        public int Insert(Modelo modelo)
        {
            return _modeloDAL.Insert(modelo);
        }

        public int Update(Modelo modelo)
        {
            return _modeloDAL.Update(modelo);
        }
    }
}
