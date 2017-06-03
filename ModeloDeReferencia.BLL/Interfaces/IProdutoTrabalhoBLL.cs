using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.BLL.Interfaces
{
    public interface IProdutoTrabalhoBLL
    {
        IEnumerable<ProdutoTrabalho> GetAll();

        ProdutoTrabalho GetById(int Id);

        int Insert(ProdutoTrabalho produtoTrabalho);

        int Update(ProdutoTrabalho produtoTrabalho);

        int Delete(int Id);
    }
}
