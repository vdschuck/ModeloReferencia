app.factory('authInterceptor', ['$q', '$window', '$rootScope', '$location', function ($q, $window, $rootScope, $location) {
    return {
        'request': function (config) {
            return config;
        },

        'requestError': function (request) {
            return $q.reject(rejection);
        },

        'response': function (response) {
            return response || $q.when(response);
        },

        'responseError': function (response) {
            if ((InternalAccess.indexOf(window.location.host) != -1) || ExternalAccess.indexOf(window.location.host) != -1) {
                return $q.reject(response);
            }
            if (response.status == 0 && (response.config.params != null || response.config.data != null)) {
                response.status = 401;
            }
            if (response.status == 401) {
                $rootScope.userLogged = false;
                delete localStorage.Profiles;
                delete localStorage.User;
                $rootScope.loader = false;
                $location.path('/login');
                return $q.reject(response);
            } else if (response.status == 403) {
                $location.path('/');
                return $q.reject(response);
            } else if (response.status == 500) {
                return $q.reject(response);
            } else {
                return $q.reject(response);
            }
        }
    };
}]);

app.config(['$httpProvider', function ($httpProvider) {
    //Enable cross domain calls
    $httpProvider.defaults.useXDomain = true;
    //Remove the header used to identify ajax call  that would prevent CORS from working
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
    $httpProvider.interceptors.push('authInterceptor');
}]);