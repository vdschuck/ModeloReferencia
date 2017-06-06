app.controller('MetaEspecificaController', ["$scope", "$filter", "$timeout", "ngDialog", "Url", "MetaEspecificaService", function ($scope, $filter, $timeout, ngDialog, Url, MetaEspecificaService) {

    $scope.metaEspecificaList = [];

    /* -- GET ALL -- */
    $scope.GetAll = function (callbackFunction) {
        var response = MetaEspecificaService.getAll();
        response.then(function (data) {
            $scope.metaEspecificaList = angular.copy(data.listMetaEspecifica);

            if (callbackFunction) {
                callbackFunction();
            }

        }, function (error) {
        });
    };

    /* -- OPEN MODAL -- */
    $scope.Open = function (action, metaEspecifica) {
        $scope.action = action;

        if (action === 'U') {
            $scope.metaEspecifica = angular.copy(metaEspecifica);
        } else {
            $scope.metaEspecifica = {};
        }

        $scope.SaveCallback = function (metaEspecifica) {
            $scope.msg = 'Registro <b> ' + metaEspecifica.Nome + ' </b> ' + (action === 'I' ? ' incluído' : ' atualizado') + ' com sucesso.';

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
            template: 'Angular/Views/MetaEspecifica/ModalEdit.html',
            controller: 'MetaEspecificaController',
            scope: $scope
        });
    };

    /* ---------------------------- INSIDE MODAL ---------------------------- */

    /* -- GET ALL SMALL TYPES -- */
    $scope.GetAllSmallTypes = function () {
        var response = MetaEspecificaService.getAllSmallTypes();
        response.then(function (data) {
            $scope.areaProcessoList = data.listAreaProcesso;           

            // Selected item when editing
            if ($scope.metaEspecifica.Id) {
                $scope.metaEspecifica.AreaProcesso = $filter('filter')($scope.areaProcessoList, { Id: $scope.metaEspecifica.AreaProcessoId })[0];
            }

        }, function (error) {
        });
    };

    /* -- RESET FORM -- */
    $scope.Reset = function (formMetaEspecifica) {
        $timeout(function () {
            formMetaEspecifica.$setPristine();
            safeApply($scope, function () {
                formMetaEspecifica = {};
                $scope.metaEspecifica = {};
            });
        }, 0);
    };

    $scope.clikEvent = false;

    /* -- SAVE -- */
    $scope.Save = function (action, formMetaEspecifica) {
        if (formMetaEspecifica.$valid) {

            $scope.GetAll(function () {
                var listLenght = $scope.metaEspecificaList.length;
                var exist = false;

                if (action === 'I') {
                    for (var i = 0; i < listLenght; i++) {
                        if ($scope.metaEspecificaList[i].Nome === $scope.metaEspecifica.Nome) {
                            exist = true;
                            break;
                        }
                    }
                }

                if (!exist) {
                    if (!$scope.clikEvent) {
                        $scope.clikEvent = true;

                        var data = PrepareMetaEspecifica(action, $scope.metaEspecifica);
                        var retorno = null;

                        if (action === 'U')
                            retorno = MetaEspecificaService.update(data);
                        else
                            retorno = MetaEspecificaService.insert(data);

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
    $scope.Delete = function (metaEspecifica) {
        $scope.msg = 'A informação será excluída. Deseja prosseguir?';

        $scope.callbackConfirmation = function () {

            var retorno = MetaEspecificaService.delete(metaEspecifica);

            retorno.then(function (objReturn) {

                ngDialog.closeAll();

                $scope.msg = 'Registro <b>' + metaEspecifica.Nome + ' </b> excluído com sucesso.';

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
            controller: 'MetaEspecificaController',
            scope: $scope
        });
    };

}]);


/* -- PREPARE DATA -- */
function PrepareMetaEspecifica(action, data) {
    var metaEspecifica = {
        Nome: data.Nome,
        Sigla: data.Sigla,
        Descricao: data.Descricao,
        AreaProcessoId: data.AreaProcesso.Id        
    };

    if (action === 'U') {
        metaEspecifica.Id = data.Id;
    }

    return metaEspecifica;
}