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
    public class NivelMaturidadeDAL : MyConnection, INivelMaturidadeDAL
    {
        public int Delete(int Id)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"DELETE FROM nivel_maturidade WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public IEnumerable<NivelMaturidade> GetAll()
        {
            IEnumerable<NivelMaturidade> result = null;

            using (var con = OpenConnection())
            {
                result = con.Query<NivelMaturidade>("SELECT * FROM nivel_maturidade").ToList();
                con.Dispose();
            }

            return result;
        }

        public NivelMaturidade GetById(int Id)
        {
            NivelMaturidade result = null;

            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM nivel_maturidade WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.QueryFirstOrDefault<NivelMaturidade>(query, parameter);
                con.Dispose();
            }

            return result;
        }

        public int Insert(NivelMaturidade nivelMaturidade)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"INSERT INTO nivel_maturidade(nome, sigla, descricao) VALUES(@NOME, @SIGLA, @DESCRICAO)";
                var parameter = new { NOME = nivelMaturidade.Nome, SIGLA = nivelMaturidade.Sigla, DESCRICAO = nivelMaturidade.Descricao };

                result = con.Execute(query, parameter);
                con.Dispose();
            }

            return result;
        }

        public int Update(NivelMaturidade nivelMaturidade)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"UPDATE nivel_maturidade SET nome = @NOME, descricao = @DESCRICAO, sigla = @SIGLA WHERE id = @ID";
                var parameter = new { NOME = nivelMaturidade.Nome, ID = nivelMaturidade.Id, SIGLA = nivelMaturidade.Sigla, DESCRICAO = nivelMaturidade.Descricao};

                result = con.Execute(query, parameter);
                con.Dispose();
            }

            return result;
        }
    }
}
