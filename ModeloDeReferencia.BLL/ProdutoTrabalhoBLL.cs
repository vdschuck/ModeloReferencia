using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeReferencia.DTO;
using ModeloDeReferencia.DAL.Intefaces;
using ModeloDeReferencia.DAL;
using ModeloDeReferencia.BLL.Interfaces;

namespace ModeloDeReferencia.BLL
{
    public class ProdutoTrabalhoBLL : IProdutoTrabalhoBLL
    {
        private readonly IProdutoTrabalhoDAL _produtoTrabalhoDAL = new ProdutoTrabalhoDAL();
        public int Delete(int Id)
        {
            return _produtoTrabalhoDAL.Delete(Id);
        }

        public IEnumerable<ProdutoTrabalho> GetAll()
        {
            return _produtoTrabalhoDAL.GetAll();
        }

        public ProdutoTrabalho GetById(int Id)
        {
            return _produtoTrabalhoDAL.GetById(Id);
        }

        public int Insert(ProdutoTrabalho produtoTrabalho)
        {
            return _produtoTrabalhoDAL.Insert(produtoTrabalho);
        }

        public int Update(ProdutoTrabalho produtoTrabalho)
        {
            return _produtoTrabalhoDAL.Update(produtoTrabalho);
        }
    }
}
