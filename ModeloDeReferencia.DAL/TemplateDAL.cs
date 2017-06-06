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
    public class TemplateDAL : MyConnection, ITemplateDAL
    {
        public int Insert(Template template)
        {
            var result = 0;

            using (var con = OpenConnection())
            {
                var query = @"INSERT INTO template" +
                            "(nome, arquivo, descricao, diretorio) VALUES" +
                            "(@NOME, @ARQUIVO, @DESCRICAO, @DIRETORIO)";

                var parameter = new { NOME = template.Nome, ARQUIVO = template.Arquivo, DESCRICAO = template.Descricao, DIRETORIO = template.Diretorio };

                result = con.Execute(query.ToString(), parameter);
                con.Dispose();
            }

            return result;
        }

    }
}
