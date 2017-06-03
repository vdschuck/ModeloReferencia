app.controller('AreaProcessoController', ["$scope", "$filter", "$timeout", "ngDialog", "Url", "AreaProcessoService", function ($scope, $filter, $timeout, ngDialog, Url, AreaProcessoService) {

    $scope.areaProcessoList = [];

    /* -- GET ALL -- */
    $scope.GetAll = function (callbackFunction) {
        var response = AreaProcessoService.getAll();
        response.then(function (data) {
            $scope.areaProcessoList = angular.copy(data.listAreaProcesso);

            if (callbackFunction) {
                callbackFunction();
            }

        }, function (error) {
        });
    };

    /* -- OPEN MODAL -- */
    $scope.Open = function (action, areaProcesso) {
        $scope.action = action;

        if (action === 'U') {
            $scope.areaProcesso = angular.copy(areaProcesso);
        } else {
            $scope.areaProcesso = {};
        }

        $scope.SaveCallback = function (areaProcesso) {
            $scope.msg = 'Registro <b> ' + areaProcesso.Nome + ' </b> ' + (action === 'I' ? ' incluído' : ' atualizado') + ' com sucesso.';

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
            template: 'Angular/Views/AreaProcesso/ModalEdit.html',
            controller: 'AreaProcessoController',
            scope: $scope
        });
    };

    /* ---------------------------- INSIDE MODAL ---------------------------- */

    /* -- GET ALL SMALL TYPES -- */
    $scope.GetAllSmallTypes = function () {
        var response = AreaProcessoService.getAllSmallTypes();
        response.then(function (data) {
            $scope.categoriaList = data.listCategoria;
            $scope.nivelMaturidadeList = data.listNivelMaturidade;    
            
            // Selected item when editing
            if ($scope.areaProcesso.Id) {
                $scope.areaProcesso.Categoria = $filter('filter')($scope.categoriaList, { Id: $scope.areaProcesso.CategoriaId })[0];
                $scope.areaProcesso.NivelMaturidade = $filter('filter')($scope.nivelMaturidadeList, { Id: $scope.areaProcesso.NivelMaturidadeId })[0];                
            }

        }, function (error) {
        });
    };

    /* -- RESET FORM -- */
    $scope.Reset = function (formAreaProcesso) {
        $timeout(function () {
            formAreaProcesso.$setPristine();
            safeApply($scope, function () {
                formAreaProcesso = {};
                $scope.areaProcesso = {};
            });
        }, 0);
    };

    $scope.clikEvent = false;
    
    /* -- SAVE -- */
    $scope.Save = function (action, formAreaProcesso) {
        if (formAreaProcesso.$valid) {

            $scope.GetAll(function () {
                var listLenght = $scope.areaProcessoList.length;
                var exist = false;

                if (action === 'I') {
                    for (var i = 0; i < listLenght; i++) {
                        if ($scope.areaProcessoList[i].Nome === $scope.areaProcesso.Nome) {
                            exist = true;
                            break;
                        }
                    }
                }

                if (!exist) {
                    if (!$scope.clikEvent) {
                        $scope.clikEvent = true;

                        var data = PrepareData(action, $scope.areaProcesso);
                        var retorno = null;

                        if (action === 'U')
                            retorno = AreaProcessoService.update(data);
                        else
                            retorno = AreaProcessoService.insert(data);

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
    $scope.Delete = function (areaProcesso) {
        $scope.msg = 'A informação será excluída. Deseja prosseguir?';

        $scope.callbackConfirmation = function () {

            var retorno = AreaProcessoService.delete(areaProcesso);

            retorno.then(function (objReturn) {

                ngDialog.closeAll();

                $scope.msg = 'Registro <b>' + areaProcesso.Nome + ' </b> excluído com sucesso.';

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
            controller: 'AreaProcessoController',
            scope: $scope
        });
    };

}]);


/* -- PREPARE DATA -- */
function PrepareData(action, data) {
    var areaProcesso = {
        Nome: data.Nome,
        Sigla: data.Sigla,
        Descricao: data.Descricao,
        NivelMaturidadeId: data.NivelMaturidade.Id,
        CategoriaId: data.Categoria.Id
    };

    if (action === 'U') {
        areaProcesso.Id = data.Id;
    }

    return areaProcesso;
}