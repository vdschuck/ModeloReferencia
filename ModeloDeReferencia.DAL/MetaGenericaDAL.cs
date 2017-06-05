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
    public class MetaGenericaDAL : MyConnection, IMetaGenericaDAL
    {
        public int Delete(int Id)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"DELETE FROM meta_generica WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public IEnumerable<MetaGenerica> GetAll()
        {
            IEnumerable<MetaGenerica> result = null;

            using (var con = OpenConnection())
            {
                result = con.Query<MetaGenerica>("SELECT * FROM meta_generica").ToList();
                con.Dispose();
            }

            return result;
        }

        public MetaGenerica GetById(int Id)
        {
            MetaGenerica result = null;

            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM meta_generica WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.QueryFirstOrDefault<MetaGenerica>(query, parameter);
                con.Dispose();
            }

            return result;
        }

        public int Insert(MetaGenerica metaGenerica)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"INSERT INTO meta_generica" +
                            "(nome, sigla, descricao, nivelCapacidadeId, modeloId) VALUES" +
                            "(@NOME, @SIGLA, @DESCRICAO, @NIVELCAPACIDADEID, @MODELOID)";

                var parameter = new { NOME = metaGenerica.Nome, SIGLA = metaGenerica.Sigla, DESCRICAO = metaGenerica.Descricao, NIVELCAPACIDADEID = metaGenerica.NivelCapacidadeId, MODELOID = metaGenerica.ModeloId };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public int Update(MetaGenerica metaGenerica)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"UPDATE meta_generica SET " +
                             "nome = @NOME, " +
                             "sigla = @SIGLA, " +
                             "descricao = @DESCRICAO, " +
                             "nivelCapacidadeId = @NIVELCAPACIDADEID ," +
                             "modeloId = @MODELOID " +
                             "WHERE id = @ID";

                var parameter = new { ID = metaGenerica.Id,  NOME = metaGenerica.Nome, SIGLA = metaGenerica.Sigla, DESCRICAO = metaGenerica.Descricao, NIVELCAPACIDADEID = metaGenerica.NivelCapacidadeId, MODELOID = metaGenerica.ModeloId };
                
                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }
    }
}
