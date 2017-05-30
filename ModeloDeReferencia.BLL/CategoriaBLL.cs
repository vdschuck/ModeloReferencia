using ModeloDeReferencia.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeReferencia.DAL;
using ModeloDeReferencia.DAL.Intefaces;
using ModeloDeReferencia.DTO;

namespace ModeloDeReferencia.BLL
{
    public class CategoriaBLL : ICategoriaBLL
    {
        private readonly ICategoriaDAL _categoriaDAL = new CategoriaDAL();

        public int Delete(int Id)
        {
           return _categoriaDAL.Delete(Id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _categoriaDAL.GetAll();
        }

        public Categoria GetById(int Id)
        {
            return _categoriaDAL.GetById(Id);
        }

        public int Insert(Categoria categoria)
        {
            return _categoriaDAL.Insert(categoria);
        }

        public int Update(Categoria categoria)
        {
            return _categoriaDAL.Update(categoria);
        }
    }
}
