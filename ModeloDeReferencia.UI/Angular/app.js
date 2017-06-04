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
        .when('/nivelMaturidade', {
            controller: 'NivelMaturidadeController',
            templateUrl: 'Angular/Views/NivelMaturidade/Index.html'
        })
        .when('/areaProcesso', {
            controller: 'AreaProcessoController',
            templateUrl: 'Angular/Views/AreaProcesso/Index.html'
        })
        .when('/produtoTrabalho', {
            controller: 'ProdutoTrabalhoController',
            templateUrl: 'Angular/Views/ProdutoTrabalho/Index.html'
        })
        .when('/metaEspecifica', {
            controller: 'MetaEspecificaController',
            templateUrl: 'Angular/Views/MetaEspecifica/Index.html'
        })
        .when('/praticaEspecifica', {
            controller: 'PraticaEspecificaController',
            templateUrl: 'Angular/Views/PraticaEspecifica/Index.html'
        })
        .when('/modelo', {
            controller: 'ModeloController',
            templateUrl: 'Angular/Views/Modelo/Index.html'
        })
        .otherwise({ redirectTo: '/' });

    $locationProvider.hashPrefix('');
    $httpProvider.interceptors.push('authInterceptor');
}]);
