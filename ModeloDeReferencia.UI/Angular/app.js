var app = angular.module('app', ['ngRoute', 'ngSanitize', 'ngMessages', 'ngResource', 'ngDialog', 'ui.bootstrap', 'ui.select', 'angularUtils.directives.dirPagination']);

app.config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {

    $routeProvider
         .when('/', {
             controller: 'HomeController',
             templateUrl: 'Angular/Views/Home/Index.html'
         })
        .when('/home', {
            controller: 'HomeController',
            templateUrl: 'Angular/Views/Home/Index.html'
        })       
        .when('/categoria', {
            controller: 'CategoriaController',
            templateUrl: 'Angular/Views/Categoria/Index.html'
        })
        .otherwise({ redirectTo: '/' });

    $locationProvider.hashPrefix('');
    $httpProvider.interceptors.push('authInterceptor');
}]);
