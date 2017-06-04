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
    public class ModeloDAL : MyConnection, IModeloDAL
    {
        public int Delete(int Id)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"DELETE FROM modelo WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public IEnumerable<Modelo> GetAll()
        {
            IEnumerable<Modelo> result = null;

            using (var con = OpenConnection())
            {
                result = con.Query<Modelo>("SELECT * FROM modelo").ToList();
                con.Dispose();
            }

            return result;
        }

        public Modelo GetById(int Id)
        {
            Modelo result = null;

            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM modelo WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.QueryFirstOrDefault<Modelo>(query, parameter);
                con.Dispose();
            }

            return result;
        }

        public int Insert(Modelo modelo)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"INSERT INTO modelo" +
                            "(nome, sigla, descricao, areaProcessoId) VALUES" +
                            "(@NOME, @SIGLA, @DESCRICAO, @AREAPROCESSOID)";

                var parameter = new { NOME = modelo.Nome, SIGLA = modelo.Sigla, DESCRICAO = modelo.Descricao, AREAPROCESSOID = modelo.AreaProcessoId };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public int Update(Modelo modelo)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"UPDATE modelo SET " +
                             "nome = @NOME, " +
                             "sigla = @SIGLA, " +
                             "descricao = @DESCRICAO, " +
                             "areaProcessoId = @AREAPROCESSOID " +                             
                             "WHERE id = @ID";

                var parameter = new { ID = modelo.Id, NOME = modelo.Nome, SIGLA = modelo.Sigla, DESCRICAO = modelo.Descricao, AREAPROCESSOID = modelo.AreaProcessoId };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }
    }
}
