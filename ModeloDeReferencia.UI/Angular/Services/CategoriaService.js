app.service('CategoriaService', ['$resource', '$q', 'Url', function ($resource, $q, Url) {
    return {
        getAll: function () {
            var resource = $resource(Url.Categoria.GetAll);
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
        getById: function (categoria) {
            var resource = $resource(Url.Categoria.GetById);
            var deferred = $q.defer();

            resource.get(categoria,
              function (data) {
                  return deferred.resolve(data);
              },
              function (response) {
                  return deferred.reject(response);
              });

            return deferred.promise;
        },
        insert: function (categoria) {
            var resource = $resource(Url.Categoria.Insert);
            var deferred = $q.defer();

            resource.save(categoria,
              function (data) {
                  return deferred.resolve(data);
              },
              function (response) {
                  return deferred.reject(response);
              });

            return deferred.promise;
        },
        update: function (categoria) {
            var resource = $resource(Url.Categoria.Update);
            var deferred = $q.defer();

            resource.save(categoria,
              function (data) {
                  return deferred.resolve(data);
              },
              function (response) {
                  return deferred.reject(response);
              });

            return deferred.promise;
        },
        delete: function (categoria) {
            var resource = $resource(Url.Categoria.Delete);
            var deferred = $q.defer();

            resource.save(categoria,
              function (data) {
                  return deferred.resolve(data);
              },
              function (response) {
                  return deferred.reject(response);
              });

            return deferred.promise;
        },
        getAllSmallTypes: function () {
            var resource = $resource(Url.Categoria.GetAllSmallTypes);
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