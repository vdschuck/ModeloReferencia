app.service('PraticaEspecificaService', ['$resource', '$q', 'Url', function ($resource, $q, Url) {
    return {
        getAll: function () {
            var resource = $resource(Url.PraticaEspecifica.GetAll);
            var deferred = $q.defer();

            resource.get(
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        getById: function (AreaProcesso) {
            var resource = $resource(Url.PraticaEspecifica.GetById);
            var deferred = $q.defer();

            resource.get(PraticaEspecifica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        insert: function (PraticaEspecifica) {
            var resource = $resource(Url.PraticaEspecifica.Insert);
            var deferred = $q.defer();

            resource.save(PraticaEspecifica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        update: function (PraticaEspecifica) {
            var resource = $resource(Url.PraticaEspecifica.Update);
            var deferred = $q.defer();

            resource.save(PraticaEspecifica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        delete: function (PraticaEspecifica) {
            var resource = $resource(Url.PraticaEspecifica.Delete);
            var deferred = $q.defer();

            resource.save(PraticaEspecifica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        getAllSmallTypes: function () {
            var resource = $resource(Url.PraticaEspecifica.GetAllSmallTypes);
            var deferred = $q.defer();

            resource.get(
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        }
    };
}]);