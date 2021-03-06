﻿using ModeloDeReferencia.DAL.Intefaces;
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
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"DELETE FROM categoria WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }
            
            return result;            
        }

        public IEnumerable<Categoria> GetAll()
        {
            IEnumerable<Categoria> result = null;

            using (var con = OpenConnection())
            {
                result = con.Query<Categoria>("SELECT * FROM categoria").ToList();
                con.Dispose();
            }

            return result;
        }

        public Categoria GetById(int Id)
        {
            Categoria result = null;

            using (var con = OpenConnection())
            {
                var query = @"SELECT * FROM categoria WHERE id = @ID";
                var parameter = new { ID = Id };

                result = con.QueryFirstOrDefault<Categoria>(query, parameter);
                con.Dispose();
            }

            return result;
        }

        public int Insert(Categoria categoria)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"INSERT INTO categoria(nome) VALUES(@NOME)";
                var parameter = new { NOME = categoria.Nome };

                result = con.Execute(query, parameter);
                con.Dispose();
            }

            return result;
            
        }

        public int Update(Categoria categoria)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"UPDATE categoria SET nome = @NOME WHERE id = @ID";
                var parameter = new { NOME = categoria.Nome, ID = categoria.Id };

                result = con.Execute(query, parameter);
                con.Dispose();
            }

            return result;
        }
    }
}
