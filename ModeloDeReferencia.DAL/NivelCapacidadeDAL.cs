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
    public class NivelCapacidadeDAL : MyConnection, INivelCapacidadeDAL
    {
        public int Delete(int Id)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"DELETE FROM nivel_capacidade WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public IEnumerable<NivelCapacidade> GetAll()
        {
            IEnumerable<NivelCapacidade> result = null;

            using (var con = OpenConnection())
            {
                result = con.Query<NivelCapacidade>("SELECT * FROM nivel_capacidade").ToList();
                con.Dispose();
            }

            return result;
        }

        public NivelCapacidade GetById(int Id)
        {
            NivelCapacidade result = null;

            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM nivel_capacidade WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.QueryFirstOrDefault<NivelCapacidade>(query, parameter);
                con.Dispose();
            }

            return result;
        }

        public int Insert(NivelCapacidade nivelCapacidade)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"INSERT INTO nivel_capacidade" +
                            "(nome, sigla, descricao) VALUES" +
                            "(@NOME, @SIGLA, @DESCRICAO)";

                var parameter = new { NOME = nivelCapacidade.Nome, SIGLA = nivelCapacidade.Sigla, DESCRICAO = nivelCapacidade.Descricao };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public int Update(NivelCapacidade nivelCapacidade)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"UPDATE nivel_capacidade SET " +
                             "nome = @NOME, " +
                             "sigla = @SIGLA, " +
                             "descricao = @DESCRICAO " +                             
                             "WHERE id = @ID";

                var parameter = new { ID = nivelCapacidade.Id, NOME = nivelCapacidade.Nome, SIGLA = nivelCapacidade.Sigla, DESCRICAO = nivelCapacidade.Descricao };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }
    }
}
