app.factory('Url', function () {
    //Conecta os métodos Services com a controller
    return {
        Categoria: {
            GetAll:             'Categoria/GetAll',
            GetById:            'Categoria/GetById',
            Insert:             'Categoria/Insert',
            Update:             'Categoria/Update',
            Delete:             'Categoria/Delete',
            GetAllSmallTypes:   'Categoria/GetAllSmallTypes'
        },
    };
});
