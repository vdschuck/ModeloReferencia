app.controller('ModeloController', ["$scope", "$filter", "$timeout", "$routeParams", "$compile", "$http", "$rootScope", "$route", "$window", "$location", "ngDialog", "Url", "ModeloService", function ($scope, $filter, $timeout, $routeParams, compile, $http, $rootScope, $route, $window, $location, ngDialog, Url, ModeloService) {

    $scope.modeloList = [];

    /* -- GET ALL -- */
    $scope.GetAll = function (callbackFunction) {
        var response = ModeloService.getAll();
        response.then(function (data) {
            $scope.modeloList = angular.copy(data.listModelo);

            if (callbackFunction) {
                callbackFunction();
            }

        }, function (error) {
        });
    };

    /* -- OPEN MODAL -- */
    $scope.Open = function (action, modelo) {
        $scope.action = action;

        if (action === 'U') {
            $scope.modelo = angular.copy(modelo);
        } else {
            $scope.modelo = {};
        }

        $scope.SaveCallback = function (modelo) {
            $scope.msg = 'Registro <b> ' + modelo.Nome + ' </b> ' + (action === 'I' ? ' incluído' : ' atualizado') + ' com sucesso.';

            var dialog = ngDialog.open({
                template: 'Angular/Views/Util/ModalMessage.html',
                scope: $scope
            });

            dialog.closePromise.then(function (data) {
                ngDialog.closeAll();
            });

            $scope.GetAll();
        };

        ngDialog.open({
            template: 'Angular/Views/Modelo/ModalEdit.html',
            controller: 'ModeloController',
            scope: $scope
        });
    };

    /* ---------------------------- INSIDE MODAL ---------------------------- */

    /* -- RESET FORM -- */
    $scope.Reset = function (formModelo) {
        $timeout(function () {
            formModelo.$setPristine();
            safeApply($scope, function () {
                formModelo = {};
                $scope.modelo = {};
            });
        }, 0);
    };

    $scope.clikEvent = false;

    /* -- SAVE -- */
    $scope.Save = function (action, formModelo) {
        if (formModelo.$valid) {

            $scope.GetAll(function () {
                var listLenght = $scope.modeloList === undefined ? 0 : $scope.modeloList.length;
                var exist = false;

                if (action === 'I') {
                    for (var i = 0; i < listLenght; i++) {
                        if ($scope.modeloList[i].Nome === $scope.modelo.Nome) {
                            exist = true;
                            break;
                        }
                    }
                }

                if (!exist) {
                    if (!$scope.clikEvent) {
                        $scope.clikEvent = true;

                        var data = PrepareModelo(action, $scope.modelo);
                        var retorno = null;

                        if (action === 'U')
                            retorno = ModeloService.update(data);
                        else
                            retorno = ModeloService.insert(data);

                        retorno.then(function (objReturn) {
                            $scope.SaveCallback(data);

                        }, function (objError) {
                            $scope.clikEvent = false;
                        });
                    }
                    else {
                        return false;
                    }
                } else {
                    $scope.msg = 'Este item já existe.';
                    ngDialog.open({
                        template: 'Angular/Views/Util/ModalMessage.html',
                        scope: $scope
                    });
                }
            });
        }
    };

    /* -- DELETE -- */
    $scope.Delete = function (modelo) {
        $scope.msg = 'A informação será excluída. Deseja prosseguir?';

        $scope.callbackConfirmation = function () {

            var retorno = ModeloService.delete(modelo);

            retorno.then(function (objReturn) {

                ngDialog.closeAll();

                $scope.msg = 'Registro <b>' + modelo.Nome + ' </b> excluído com sucesso.';

                ngDialog.open({
                    template: 'Angular/Views/Util/ModalMessage.html',
                    scope: $scope
                });

                $scope.GetAll();

            }, function (objError) {
            });
        };

        ngDialog.open({
            template: 'Angular/Views/Util/ConfirmationModal.html',
            controller: 'ModeloController',
            scope: $scope
        });
    };

    /* -- SHOW -- */
    $scope.OpenShow = function (modelo) {
        $rootScope.modelo = angular.copy(modelo);
        $location.path('/modelo/show/' + $rootScope.modelo.Id);
    };

    $scope.Show = function () { 
        var response = ModeloService.show($rootScope.modelo);
        response.then(function (data) {
            $scope.modelo = $rootScope.modelo;
            $scope.areaProcessoList = data.listAreaProcesso; 
            $scope.metaGenericaList = data.listMetaGenerica;
            $scope.metaEspecificaList = data.listMetaEspecifica;
            $scope.praticaEspecificaList = data.listPraticaEspecifica;
            $scope.dateOpen = new Date();

        }, function (error) {
            });        
    };

    $scope.Export = function (name) {
        html2canvas(document.getElementById('exportThis'), {
            onrendered: function (canvas) {
                var data = canvas.toDataURL();
                var docDefinition = {
                    content: [{
                        image: data,
                        width: 500,
                    }]
                };
                pdfMake.createPdf(docDefinition).download("Modelo_" + name + ".pdf");
            }
        });
    };

}]);


/* -- PREPARE DATA -- */
function PrepareModelo(action, data) {
    var modelo = {
        Nome: data.Nome,
        Sigla: data.Sigla,
        Descricao: data.Descricao             
    };

    if (action === 'U') {
        modelo.Id = data.Id;
    }

    return modelo;
}