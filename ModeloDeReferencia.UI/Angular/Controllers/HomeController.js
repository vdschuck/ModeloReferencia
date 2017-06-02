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

    $scope.init();
}]);
