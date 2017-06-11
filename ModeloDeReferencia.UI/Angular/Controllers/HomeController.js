app.controller('HomeController', ["$scope", "$compile", '$rootScope', '$route', '$window', '$location', '$filter', 'ngDialog', function ($scope, $compile, $rootScope, $route, $window, $location, $filter, ngDialog) {
    
    $scope.init = function () {
        $location.path('/');
    };
    $scope.openCategoria = function () {
        $location.path('/categoria');
    };
    $scope.openNivelMaturidade = function () {
        $location.path('/nivelMaturidade');
    };   
    $scope.openAreaProcesso = function () {
        $location.path('/areaProcesso');
    };  
    $scope.openProdutoTrabalho = function () {
        $location.path('/produtoTrabalho');
    }; 
    $scope.openMetaEspecifica = function () {
        $location.path('/metaEspecifica');
    }; 
    $scope.openPraticaEspecifica = function () {
        $location.path('/praticaEspecifica');
    };
    $scope.openModelo = function () {
        $location.path('/modelo');
    };   
    $scope.openNivelCapacidade = function () {
        $location.path('/nivelCapacidade');
    };
    $scope.openMetaGenerica = function () {
        $location.path('/metaGenerica');
    }
    $scope.init();
}]);
