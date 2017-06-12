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
    public class MetaEspecificaDAL : MyConnection, IMetaEspecificaDAL
    {
        public int Delete(int Id)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"DELETE FROM meta_especifica WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public IEnumerable<MetaEspecifica> GetAll()
        {
            IEnumerable<MetaEspecifica> result = null;

            using (var con = OpenConnection())
            {
                result = con.Query<MetaEspecifica>("SELECT * FROM meta_especifica").ToList();
                con.Dispose();
            }

            return result;
        }

        public MetaEspecifica GetById(int Id)
        {
            MetaEspecifica result = null;

            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM meta_especifica WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.QueryFirstOrDefault<MetaEspecifica>(query, parameter);
                con.Dispose();
            }

            return result;
        }

        public IEnumerable<MetaEspecifica> Get(string Parameter, int Value)
        {
            IEnumerable<MetaEspecifica> result = null;

            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM meta_especifica WHERE " + Parameter + " = " + Value;

                result = con.Query<MetaEspecifica>(query.ToString()).ToList();
                con.Dispose();
            }

            return result;
        }

        public int Insert(MetaEspecifica metaEspecifica)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"INSERT INTO meta_especifica" +
                            "(nome, sigla, descricao, areaProcessoId) VALUES " +
                            "(@NOME, @SIGLA, @DESCRICAO, @AREAPROCESSOID)";

                var parameter = new { NOME = metaEspecifica.Nome, SIGLA = metaEspecifica.Sigla, DESCRICAO = metaEspecifica.Descricao, AREAPROCESSOID = metaEspecifica.AreaProcessoId };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public int Update(MetaEspecifica metaEspecifica)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"UPDATE meta_especifica SET " +
                             "nome = @NOME, " +
                             "sigla = @SIGLA, " +
                             "descricao = @DESCRICAO, " +
                             "areaProcessoId = @AREAPROCESSOID " +                             
                             "WHERE id = @ID";

                var parameter = new { ID = metaEspecifica.Id, NOME = metaEspecifica.Nome, SIGLA = metaEspecifica.Sigla, DESCRICAO = metaEspecifica.Descricao, AREAPROCESSOID = metaEspecifica.AreaProcessoId };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }
    }
}
