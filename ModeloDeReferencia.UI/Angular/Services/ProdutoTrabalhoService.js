app.service('ProdutoTrabalhoService', ['$resource', '$q', 'Url', function ($resource, $q, Url) {
    
    return {
        getAll: function () {
            var resource = $resource(Url.ProdutoTrabalho.GetAll);
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
        getById: function (ProdutoTrabalho) {
            var resource = $resource(Url.ProdutoTrabalho.GetById);
            var deferred = $q.defer();

            resource.get(ProdutoTrabalho,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        insert: function (ProdutoTrabalho) {
            var resource = $resource(Url.ProdutoTrabalho.Insert);
            var deferred = $q.defer();

            resource.save(ProdutoTrabalho,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        update: function (ProdutoTrabalho) {
            var resource = $resource(Url.ProdutoTrabalho.Update);
            var deferred = $q.defer();

            resource.save(ProdutoTrabalho,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        delete: function (ProdutoTrabalho) {
            var resource = $resource(Url.ProdutoTrabalho.Delete);
            var deferred = $q.defer();

            resource.save(ProdutoTrabalho,
                function (data) {
                    return deferred.resolve(data);
                },
                function (response) {
                    return deferred.reject(response);
                });

            return deferred.promise;
        },
        upload: function (ProdutoTrabalho) {
            var resource = $resource(Url.ProdutoTrabalho.Insert);
            var deferred = $q.defer();

            resource.save(ProdutoTrabalho,
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