app.service('NivelCapacidadeService', ['$resource', '$q', 'Url', function ($resource, $q, Url) {
    return {
        getAll: function () {
            var resource = $resource(Url.NivelCapacidade.GetAll);
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
        getById: function (NivelCapacidade) {
            var resource = $resource(Url.NivelCapacidade.GetById);
            var deferred = $q.defer();

            resource.get(NivelCapacidade,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        insert: function (NivelCapacidade) {
            var resource = $resource(Url.NivelCapacidade.Insert);
            var deferred = $q.defer();

            resource.save(NivelCapacidade,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        update: function (NivelCapacidade) {
            var resource = $resource(Url.NivelCapacidade.Update);
            var deferred = $q.defer();

            resource.save(NivelCapacidade,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        delete: function (NivelCapacidade) {
            var resource = $resource(Url.NivelCapacidade.Delete);
            var deferred = $q.defer();

            resource.save(NivelCapacidade,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        getAllSmallTypes: function () {
            var resource = $resource(Url.NivelCapacidade.GetAllSmallTypes);
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