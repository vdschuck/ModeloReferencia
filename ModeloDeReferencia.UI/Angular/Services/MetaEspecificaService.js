app.service('MetaEspecificaService', ['$resource', '$q', 'Url', function ($resource, $q, Url) {
    return {
        getAll: function () {
            var resource = $resource(Url.MetaEspecifica.GetAll);
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
        getById: function (MetaEspecifica) {
            var resource = $resource(Url.MetaEspecifica.GetById);
            var deferred = $q.defer();

            resource.get(MetaEspecifica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        insert: function (MetaEspecifica) {
            var resource = $resource(Url.MetaEspecifica.Insert);
            var deferred = $q.defer();

            resource.save(MetaEspecifica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        update: function (MetaEspecifica) {
            var resource = $resource(Url.MetaEspecifica.Update);
            var deferred = $q.defer();

            resource.save(MetaEspecifica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        delete: function (MetaEspecifica) {
            var resource = $resource(Url.MetaEspecifica.Delete);
            var deferred = $q.defer();

            resource.save(MetaEspecifica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        getAllSmallTypes: function () {
            var resource = $resource(Url.MetaEspecifica.GetAllSmallTypes);
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