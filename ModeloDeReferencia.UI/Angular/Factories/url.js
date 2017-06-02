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
    };

});
