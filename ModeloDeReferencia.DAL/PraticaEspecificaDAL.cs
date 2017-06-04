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
    public class PraticaEspecificaDAL : MyConnection, IPraticaEspecificaDAL
    {
        public int Delete(int Id)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"DELETE FROM pratica_especifica WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public IEnumerable<PraticaEspecifica> GetAll()
        {
            IEnumerable<PraticaEspecifica> result = null;

            using (var con = OpenConnection())
            {
                result = con.Query<PraticaEspecifica>("SELECT * FROM pratica_especifica").ToList();
                con.Dispose();
            }

            return result;
        }

        public PraticaEspecifica GetById(int Id)
        {
            PraticaEspecifica result = null;

            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM praticia_especifica WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.QueryFirstOrDefault<PraticaEspecifica>(query, parameter);
                con.Dispose();
            }

            return result;
        }

        public int Insert(PraticaEspecifica praticaEspecifica)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"INSERT INTO pratica_especifica" +
                            "(nome, sigla, descricao, metaEspecificaId) VALUES" +
                            "(@NOME, @SIGLA, @DESCRICAO, @METAESPECIFICAID)";

                var parameter = new { NOME = praticaEspecifica.Nome, SIGLA = praticaEspecifica.Sigla, DESCRICAO = praticaEspecifica.Descricao, METAESPECIFICAID = praticaEspecifica.MetaEspecificaId };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public int Update(PraticaEspecifica praticaEspecifica)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"UPDATE pratica_especifica SET " +
                             "nome = @NOME, " +
                             "sigla = @SIGLA, " +
                             "descricao = @DESCRICAO, " +
                             "metaEspecificaId = @METAESPECIFICAID " +                             
                             "WHERE id = @ID";

                var parameter = new { ID = praticaEspecifica.Id,  NOME = praticaEspecifica.Nome, SIGLA = praticaEspecifica.Sigla, DESCRICAO = praticaEspecifica.Descricao, METAESPECIFICAID = praticaEspecifica.MetaEspecificaId };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }
    }
}
