using ModeloDeReferencia.DAL.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDeReferencia.DTO;
using Dapper;

namespace ModeloDeReferencia.DAL
{
    public class ProdutoTrabalhoDAL : MyConnection, IProdutoTrabalhoDAL
    {
        public int Delete(int Id)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"DELETE FROM produto_trabalho WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public IEnumerable<ProdutoTrabalho> GetAll()
        {
            IEnumerable<ProdutoTrabalho> result = null;

            using (var con = OpenConnection())
            {
                result = con.Query<ProdutoTrabalho>("SELECT * FROM produto_trabalho").ToList();
                con.Dispose();
            }

            return result;
        }

        public ProdutoTrabalho GetById(int Id)
        {
            ProdutoTrabalho result = null;

            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM produto_trabalho WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.QueryFirstOrDefault<ProdutoTrabalho>(query, parameter);
                con.Dispose();
            }

            return result;
        }

        public int Insert(ProdutoTrabalho produtoTrabalho)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"INSERT INTO produto_trabalho(nome, template) VALUES(@NOME, @TEMPLATE)";
                var parameter = new { NOME = produtoTrabalho.Nome, TEMPLATE = produtoTrabalho.Template };

                result = con.Execute(query, parameter);
                con.Dispose();
            }

            return result;
        }

        public int Update(ProdutoTrabalho produtoTrabalho)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"UPDATE produto_trabalho SET nome = @NOME, template = @TEMPLATE WHERE id = @ID";
                var parameter = new { NOME = produtoTrabalho.Nome, ID = produtoTrabalho.Id, TEMPLATE = produtoTrabalho.Template};

                result = con.Execute(query, parameter);
                con.Dispose();
            }

            return result;
        }
    }
}
