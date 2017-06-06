app.service('TemplateService', ['$resource', '$q', 'Url', '$http', function ($resource, $q, Url, $http) {
    return {
        insert: function (Template) {
            var formData = new FormData();
            formData.append("file", Template);

            var defer = $q.defer();
            $http.post("/Template/Upload", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
                .success(function (d) {
                    defer.resolve(d);
                })
                .error(function () {
                    defer.reject("File Upload Failed!");
                });

            return defer.promise;
        }
    };
}]);