using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DTO
{
    public class Template
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Arquivo { get; set; }

        public string Descricao { get; set; }

        public string  Diretorio { get; set; }        
    }
}
