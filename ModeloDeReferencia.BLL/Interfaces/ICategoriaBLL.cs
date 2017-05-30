using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.BLL.Interfaces
{
    public interface ICategoriaBLL
    {
        IEnumerable<Categoria> GetAll();

        Categoria GetById(int Id);

        int Insert(Categoria categoria);

        int Update(Categoria categoria);

        int Delete(int Id);
    }
}
