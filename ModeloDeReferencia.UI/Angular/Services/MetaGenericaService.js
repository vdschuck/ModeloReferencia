app.service('MetaGenericaService', ['$resource', '$q', 'Url', function ($resource, $q, Url) {
    return {
        getAll: function () {
            var resource = $resource(Url.MetaGenerica.GetAll);
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
        getById: function (MetaGenerica) {
            var resource = $resource(Url.MetaGenerica.GetById);
            var deferred = $q.defer();

            resource.get(MetaGenerica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        insert: function (MetaGenerica) {
            var resource = $resource(Url.MetaGenerica.Insert);
            var deferred = $q.defer();

            resource.save(MetaGenerica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        update: function (MetaGenerica) {
            var resource = $resource(Url.MetaGenerica.Update);
            var deferred = $q.defer();

            resource.save(MetaGenerica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        delete: function (MetaGenerica) {
            var resource = $resource(Url.MetaGenerica.Delete);
            var deferred = $q.defer();

            resource.save(MetaGenerica,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        getAllSmallTypes: function () {
            var resource = $resource(Url.MetaGenerica.GetAllSmallTypes);
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