app.service('AreaProcessoService', ['$resource', '$q', 'Url', function ($resource, $q, Url) {
    return {
        getAll: function () {
            var resource = $resource(Url.AreaProcesso.GetAll);
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
            var resource = $resource(Url.AreaProcesso.GetById);
            var deferred = $q.defer();

            resource.get(AreaProcesso,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        insert: function (AreaProcesso) {
            var resource = $resource(Url.AreaProcesso.Insert);
            var deferred = $q.defer();

            resource.save(AreaProcesso,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        update: function (AreaProcesso) {
            var resource = $resource(Url.AreaProcesso.Update);
            var deferred = $q.defer();

            resource.save(AreaProcesso,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        delete: function (AreaProcesso) {
            var resource = $resource(Url.AreaProcesso.Delete);
            var deferred = $q.defer();

            resource.save(AreaProcesso,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        getAllSmallTypes: function () {
            var resource = $resource(Url.AreaProcesso.GetAllSmallTypes);
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
    };
}]);