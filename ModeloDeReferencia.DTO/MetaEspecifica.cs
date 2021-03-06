﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DTO
{
    public class MetaEspecifica
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public int AreaProcessoId { get; set; }

        public virtual AreaProcesso AreaProcesso {get; set;}
    }
}
