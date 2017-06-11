app.service('ModeloService', ['$resource', '$q', 'Url', function ($resource, $q, Url) {
    return {
        getAll: function () {
            var resource = $resource(Url.Modelo.GetAll);
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
        getById: function (Modelo) {
            var resource = $resource(Url.Modelo.GetById);
            var deferred = $q.defer();

            resource.get(Modelo,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        insert: function (Modelo) {
            var resource = $resource(Url.Modelo.Insert);
            var deferred = $q.defer();

            resource.save(Modelo,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        update: function (Modelo) {
            var resource = $resource(Url.Modelo.Update);
            var deferred = $q.defer();

            resource.save(Modelo,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        delete: function (Modelo) {
            var resource = $resource(Url.Modelo.Delete);
            var deferred = $q.defer();

            resource.save(Modelo,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        getAllSmallTypes: function () {
            var resource = $resource(Url.Modelo.GetAllSmallTypes);
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
        show: function (Modelo) {
            var resource = $resource(Url.Modelo.Show);            
            var deferred = $q.defer();

            resource.get(Modelo,
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