﻿using Dapper;
using ModeloDeReferencia.DAL.Intefaces;
using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DAL
{
    public class AreaProcessoDAL : MyConnection, IAreaProcessoDAL
    {
        public int Delete(int Id)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"DELETE FROM area_processo WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public IEnumerable<AreaProcesso> GetAll()
        {
            IEnumerable<AreaProcesso> result = null;

            using (var con = OpenConnection())
            {
                result = con.Query<AreaProcesso>("SELECT * FROM area_processo").ToList();
                con.Dispose();
            }

            return result;
        }

        public AreaProcesso GetById(int Id)
        {
            AreaProcesso result = null;

            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM area_processo WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.QueryFirstOrDefault<AreaProcesso>(query, parameter);
                con.Dispose();
            }

            return result;
        }

        public IEnumerable<AreaProcesso> Get(string Parameter, int Value)
        {
            IEnumerable<AreaProcesso> result = null;

            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM area_processo WHERE " + Parameter + " = " + Value;                

                result = con.Query<AreaProcesso>(query.ToString()).ToList();
                con.Dispose();
            }

            return result;
        }

        public int Insert(AreaProcesso areaProcesso)
        {
            var result = 0;            

            using (var con = OpenConnection())
            {
                var query = @"INSERT INTO area_processo" +
                            "(nome, sigla, descricao, nivelMaturidadeId, categoriaId, modeloId) " +
                            "VALUES(@NOME, @SIGLA, @DESCRICAO, @NIVELMATURIDADEID, @CATEGORIAID, @MODELOID)";
               
                var parameter = new { NOME = areaProcesso.Nome, SIGLA = areaProcesso.Sigla, DESCRICAO = areaProcesso.Descricao, CATEGORIAID = areaProcesso.CategoriaId, NIVELMATURIDADEID = areaProcesso.NivelMaturidadeId , MODELOID = areaProcesso.ModeloId };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

        public int Update(AreaProcesso areaProcesso)
        {
            var result = 0;                  

            using (var con = OpenConnection())
            {
                var query = @"UPDATE area_processo SET " +
                             "nome = @NOME, " +
                             "sigla = @SIGLA, " +
                             "descricao = @DESCRICAO, " +
                             "nivelMaturidadeId = @NIVELMATURIDADEID, " +
                             "categoriaId = @CATEGORIAID, " +
                             "modeloId = @MODELOID " +
                             "WHERE id = @ID";
               
                var parameter = new { ID = areaProcesso.Id, NOME = areaProcesso.Nome, SIGLA = areaProcesso.Sigla, DESCRICAO = areaProcesso.Descricao, CATEGORIAID = areaProcesso.CategoriaId, NIVELMATURIDADEID = areaProcesso.NivelMaturidadeId, MODELOID = areaProcesso.ModeloId };
                
                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }
    }
}
