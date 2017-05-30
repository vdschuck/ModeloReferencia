﻿using ModeloDeReferencia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeReferencia.DAL.Intefaces
{
    public interface INivelMaturidadeDAL
    {
        IEnumerable<NivelMaturidade> GetAll();

        NivelMaturidade GetById(int Id);

        int Insert(NivelMaturidade nivelMaturidade);

        int Update(NivelMaturidade nivelMaturidade);

        int Delete(int Id);
    }
}
