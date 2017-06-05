app.controller('MetaGenericaController', ["$scope", "$filter", "$timeout", "ngDialog", "Url", "MetaGenericaService", function ($scope, $filter, $timeout, ngDialog, Url, MetaGenericaService) {

    $scope.metaGenericaList = [];

    /* -- GET ALL -- */
    $scope.GetAll = function (callbackFunction) {
        var response = MetaGenericaService.getAll();
        response.then(function (data) {
            $scope.metaGenericaList = angular.copy(data.listMetaGenerica);

            if (callbackFunction) {
                callbackFunction();
            }

        }, function (error) {
        });
    };

    /* -- OPEN MODAL -- */
    $scope.Open = function (action, metaGenerica) {
        $scope.action = action;

        if (action === 'U') {
            $scope.metaGenerica = angular.copy(metaGenerica);
        } else {
            $scope.metaGenerica = {};
        }

        $scope.SaveCallback = function (metaGenerica) {
            $scope.msg = 'Registro <b> ' + metaGenerica.Nome + ' </b> ' + (action === 'I' ? ' incluído' : ' atualizado') + ' com sucesso.';

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
            template: 'Angular/Views/MetaGenerica/ModalEdit.html',
            controller: 'MetaGenericaController',
            scope: $scope
        });
    };

    /* ---------------------------- INSIDE MODAL ---------------------------- */

    /* -- GET ALL SMALL TYPES -- */
    $scope.GetAllSmallTypes = function () {
        var response = MetaGenericaService.getAllSmallTypes();
        response.then(function (data) {
            $scope.modeloList = data.listModelo;
            $scope.nivelCapacidadeList = data.listNivelCapacidade;

            // Selected item when editing
            if ($scope.metaGenerica.Id) {
                $scope.metaGenerica.NivelCapacidade = $filter('filter')($scope.nivelCapacidadeList, { Id: $scope.metaGenerica.NivelCapacidadeId })[0];
                $scope.metaGenerica.Modelo = $filter('filter')($scope.modeloList, { Id: $scope.metaGenerica.ModeloId })[0];
            }

        }, function (error) {
        });
    };

    /* -- RESET FORM -- */
    $scope.Reset = function (formMetaGenerica) {
        $timeout(function () {
            formMetaGenerica.$setPristine();
            safeApply($scope, function () {
                formMetaGenerica = {};
                $scope.metaGenerica = {};
            });
        }, 0);
    };

    $scope.clikEvent = false;

    /* -- SAVE -- */
    $scope.Save = function (action, formMetaGenerica) {
        if (formMetaGenerica.$valid) {

            $scope.GetAll(function () {
                var listLenght = $scope.metaGenericaList === undefined ? 0 : $scope.metaGenericaList.length;
                var exist = false;

                if (action === 'I') {
                    for (var i = 0; i < listLenght; i++) {
                        if ($scope.metaGenericaList[i].Nome === $scope.metaGenerica.Nome) {
                            exist = true;
                            break;
                        }
                    }
                }

                if (!exist) {
                    if (!$scope.clikEvent) {
                        $scope.clikEvent = true;

                        var data = PrepareMetaGenerica(action, $scope.metaGenerica);
                        var retorno = null;

                        if (action === 'U')
                            retorno = MetaGenericaService.update(data);
                        else
                            retorno = MetaGenericaService.insert(data);

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
    $scope.Delete = function (metaGenerica) {
        $scope.msg = 'A informação será excluída. Deseja prosseguir?';

        $scope.callbackConfirmation = function () {

            var retorno = MetaGenericaService.delete(metaGenerica);

            retorno.then(function (objReturn) {

                ngDialog.closeAll();

                $scope.msg = 'Registro <b>' + metaGenerica.Nome + ' </b> excluído com sucesso.';

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
            controller: 'MetaGenericaController',
            scope: $scope
        });
    };

}]);


/* -- PREPARE DATA -- */
function PrepareMetaGenerica(action, data) {
    var metaGenerica = {
        Nome: data.Nome,
        Sigla: data.Sigla,
        Descricao: data.Descricao,
        ModeloId: data.Modelo.Id,
        NivelCapacidadeId: data.NivelCapacidade.Id,
    };

    if (action === 'U') {
        metaGenerica.Id = data.Id;
    }

    return metaGenerica;
}