app.controller('ModeloController', ["$scope", "$filter", "$timeout", "ngDialog", "Url", "ModeloService", function ($scope, $filter, $timeout, ngDialog, Url, ModeloService) {

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

    $scope.Show = function (modelo) {
        var response = ModeloService.show(modelo);
        response.then(function (data) {
            $scope.areaProcessoList = data.listAreaProcesso;           

        }, function (error) {
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