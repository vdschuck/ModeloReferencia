app.factory('Url', function () {
    //Conecta os métodos Services com a controller
    return {
        Categoria: {
            GetAll:             'Categoria/GetAll',
            GetById:            'Categoria/GetById',
            Insert:             'Categoria/Insert',
            Update:             'Categoria/Update',
            Delete:             'Categoria/Delete'           
        },
        NivelMaturidade: {
            GetAll:             'NivelMaturidade/GetAll',
            GetById:            'NivelMaturidade/GetById',
            Insert:             'NivelMaturidade/Insert',
            Update:             'NivelMaturidade/Update',
            Delete:             'NivelMaturidade/Delete'            
        },
        AreaProcesso: {
            GetAll:             'AreaProcesso/GetAll',
            GetById:            'AreaProcesso/GetById',
            Insert:             'AreaProcesso/Insert',
            Update:             'AreaProcesso/Update',
            Delete:             'AreaProcesso/Delete',
            GetAllSmallTypes:   'AreaProcesso/GetAllSmallTypes'
        },
        ProdutoTrabalho: {
            GetAll:             'ProdutoTrabalho/GetAll',
            GetById:            'ProdutoTrabalho/GetById',
            Insert:             'ProdutoTrabalho/Insert',
            Update:             'ProdutoTrabalho/Update',
            Delete:             'ProdutoTrabalho/Delete',
            GetAllSmallTypes:   'ProdutoTrabalho/GetAllSmallTypes'
        },
        MetaEspecifica: {
            GetAll:             'MetaEspecifica/GetAll',
            GetById:            'MetaEspecifica/GetById',
            Insert:             'MetaEspecifica/Insert',
            Update:             'MetaEspecifica/Update',
            Delete:             'MetaEspecifica/Delete',
            GetAllSmallTypes:   'MetaEspecifica/GetAllSmallTypes'
        },
        PraticaEspecifica: {
            GetAll:             'PraticaEspecifica/GetAll',
            GetById:            'PraticaEspecifica/GetById',
            Insert:             'PraticaEspecifica/Insert',
            Update:             'PraticaEspecifica/Update',
            Delete:             'PraticaEspecifica/Delete',
            GetAllSmallTypes:   'PraticaEspecifica/GetAllSmallTypes'
        },
        Modelo: {
            GetAll:             'Modelo/GetAll',
            GetById:            'Modelo/GetById',
            Insert:             'Modelo/Insert',
            Update:             'Modelo/Update',
            Delete:             'Modelo/Delete',
            GetAllSmallTypes:   'Modelo/GetAllSmallTypes'
        },
        NivelCapacidade: {
            GetAll:             'NivelCapacidade/GetAll',
            GetById:            'NivelCapacidade/GetById',
            Insert:             'NivelCapacidade/Insert',
            Update:             'NivelCapacidade/Update',
            Delete:             'NivelCapacidade/Delete'           
        }
    };

});
