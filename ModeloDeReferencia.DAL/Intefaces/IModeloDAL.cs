using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DAL.Intefaces
{
    public interface IModeloDAL
    {
        IEnumerable<Modelo> GetAll();

        Modelo GetById(int Id);

        int Insert(Modelo modelo);

        int Update(Modelo modelo);

        int Delete(int Id);
    }
}
