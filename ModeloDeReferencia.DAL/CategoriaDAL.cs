using ModeloDeReferencia.DAL.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ModeloDeReferencia.DTO;

namespace ModeloDeReferencia.DAL
{
    public class CategoriaDAL : MyConnection, ICategoriaDAL
    {
        public int Delete(int Id)
        {
            using (var con = OpenConnection())
            {
                var query = @"DELETE FROM categoria WHERE id = @ID";
                var parameter = new { ID = Id };

                return con.Execute(query.ToString(), parameter);
            }
        }

        public IEnumerable<Categoria> GetAll()
        {
            using (var con = OpenConnection())
            {
                return con.Query<Categoria>("SELECT * FROM categoria").ToList();
            }
        }

        public Categoria GetById(int Id)
        {
            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM categoria WHERE id = @ID";
                var parameter = new { ID = Id };

                return con.QueryFirstOrDefault<Categoria>(query, parameter);
            }            
        }

        public int Insert(Categoria categoria)
        {
            using (var con = OpenConnection())
            {
                var query = @"INSERT INTO categoria(nome) VALUES(@NOME)";
                var parameter = new { NOME = categoria.Nome };

                return con.Execute(query, parameter);
            }            
        }

        public int Update(Categoria categoria)
        {
            using (var con = OpenConnection())
            {
                var query = @"UPDATE categoria SET nome = @NOME WHERE id = @ID";
                var parameter = new { NOME = categoria.Nome, ID = categoria.Id };

                return con.Execute(query, parameter);
            }
        }
    }
}
