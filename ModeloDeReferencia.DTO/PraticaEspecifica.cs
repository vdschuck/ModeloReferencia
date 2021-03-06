﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DTO
{
    public class PraticaEspecifica
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public int MetaEspecificaId { get; set; }

        public int ProdutoTrabalhoId { get; set; }

        public virtual MetaEspecifica MetaEspecifica { get; set; }

        public virtual ProdutoTrabalho ProdutoTrabalho { get; set; }
    }
}
