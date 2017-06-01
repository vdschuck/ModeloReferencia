app.service('NivelMaturidadeService', ['$resource', '$q', 'Url', function ($resource, $q, Url) {
    return {
        getAll: function () {
            var resource = $resource(Url.NivelMaturidade.GetAll);
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
        getById: function (NivelMaturidade) {
            var resource = $resource(Url.NivelMaturidade.GetById);
            var deferred = $q.defer();

            resource.get(NivelMaturidade,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        insert: function (NivelMaturidade) {
            var resource = $resource(Url.NivelMaturidade.Insert);
            var deferred = $q.defer();

            resource.save(NivelMaturidade,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        update: function (NivelMaturidade) {
            var resource = $resource(Url.NivelMaturidade.Update);
            var deferred = $q.defer();

            resource.save(NivelMaturidade,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        delete: function (NivelMaturidade) {
            var resource = $resource(Url.NivelMaturidade.Delete);
            var deferred = $q.defer();

            resource.save(NivelMaturidade,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },       
    };
}]);