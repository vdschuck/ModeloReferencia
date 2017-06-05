using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DTO
{
    public class MetaGenerica
    {
        public int Id { get; set; }

        public string Nome  { get; set; }

        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public int NivelCapacidadeId { get; set; }

        public int ModeloId { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual NivelCapacidade NivelCapacidade { get; set; }
    }
}
