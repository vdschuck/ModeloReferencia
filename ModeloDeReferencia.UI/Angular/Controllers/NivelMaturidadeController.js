app.controller('NivelMaturidadeController', ["$scope", "$filter", "$timeout", "ngDialog", "Url", "NivelMaturidadeService", function ($scope, $filter, $timeout, ngDialog, Url, NivelMaturidadeService) {

    $scope.nivelMaturidadeList = [];

    /* -- GET ALL -- */
    $scope.getAll = function (callbackFunction) {
        var response = NivelMaturidadeService.getAll();
        response.then(function (data) {
            $scope.nivelMaturidadeList = angular.copy(data.nivelMaturidadeList);

            if (callbackFunction) {
                callbackFunction();
            }

        }, function (error) {
        });
    };

    /* -- OPEN MODAL -- */
    $scope.openNivelMaturidade = function (nivelMaturidadeAction, nivelMaturidade) {
        $scope.nivelMaturidadeAction = nivelMaturidadeAction;

        if (nivelMaturidadeAction == 'U') {
            $scope.nivelMaturidade = angular.copy(nivelMaturidade);
        } else {
            $scope.nivelMaturidade = {};
        }

        $scope.saveCallback = function (nivelMaturidade, success) {
            if (success)
                $scope.msg = 'Registro <b> ' + nivelMaturidade.Nome + ' </b> ' + (nivelMaturidadeAction == 'I' ? ' incluído' : ' atualizado') + ' com sucesso.';
            else
                $scope.msg = 'Não foi possível atualizar o registro <b>' + nivelMaturidade.Nome + '</b>.';

            var dialog = ngDialog.open({
                template: 'Angular/Views/Util/ModalMessage.html',
                scope: $scope
            });

            dialog.closePromise.then(function (data) {
                ngDialog.closeAll();
            });

            $scope.getAll();
        };

        ngDialog.open({
            template: 'Angular/Views/NivelMaturidade/ModalEdit.html',
            controller: 'NivelMaturidadeController',
            scope: $scope
        });
    };

    /* ---------------------------- INSIDE MODAL ---------------------------- */
    $scope.reset = function (formNivelMaturidade) {
        $timeout(function () {
            formNivelMaturidade.$setPristine();
            safeApply($scope, function () {
                formNivelMaturidade = {};
                $scope.nivelMaturidade = {};
            });
        }, 0);
    };

    $scope.clikEventNivelMaturidade = false;

    /* -- SAVE NIVEL MATURIDADE -- */
    $scope.saveNivelMaturidade = function (nivelMaturidadeAction, formNivelMaturidade) {
        if (formNivelMaturidade.$valid) {

            $scope.getAll(function () {
                var listLenght = $scope.nivelMaturidadeList.length;
                var exist = false;

                if (nivelMaturidadeAction == 'I') {
                    for (var i = 0; i < listLenght; i++) {
                        if ($scope.nivelMaturidadeList[i].Nome == $scope.nivelMaturidade.Nome) {
                            exist = true;
                            break;
                        }
                    }
                }
                
                if (!exist) {
                    if (!$scope.clikEventNivelMaturidade) {
                        $scope.clikEventNivelMaturidade = true;

                        var nivelMaturidade = prepareNivelMaturidade(nivelMaturidadeAction, $scope.nivelMaturidade);
                        var retorno;

                        if (nivelMaturidadeAction == 'U')
                            retorno = NivelMaturidadeService.update(nivelMaturidade);
                        else
                            retorno = NivelMaturidadeService.insert(nivelMaturidade);

                        retorno.then(function (objReturn) {
                            $scope.saveCallback(nivelMaturidade, true);

                        }, function (objError) {
                            $scope.clikEventNivelMaturidade = false;
                            $scope.saveCallback(nivelMaturidade, false);
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

    /* -- DELETE NIVEL MATURIDADE -- */
    $scope.deleteNivelMaturidade = function (nivelMaturidade) {
        $scope.msg = 'A informação será excluída. Deseja prosseguir?';

        $scope.callbackConfirmation = function () {

            var retorno = NivelMaturidadeService.delete(nivelMaturidade);

            retorno.then(function (objReturn) {

                ngDialog.closeAll();

                $scope.msg = 'Registro <b>' + nivelMaturidade.Nome + ' </b> excluído com sucesso.';

                ngDialog.open({
                    template: 'Angular/Views/Util/ModalMessage.html',
                    scope: $scope
                });

                $scope.getAll();

            }, function (objError) {
            });
        };

        ngDialog.open({
            template: 'Angular/Views/Util/ConfirmationModal.html',
            controller: 'NivelMaturidadeController',
            scope: $scope
        });
    }

}]);


/* -- PREPARE NIVEL MATURIDADE -- */
function prepareNivelMaturidade(nivelMaturidadeAction, nivelMaturidadeScope) {
    var nivelMaturidade = {        
        Nome: nivelMaturidadeScope.Nome,
        Sigla: nivelMaturidadeScope.Sigla,
        Descricao: (nivelMaturidadeScope.Descricao) ? nivelMaturidadeScope.Descricao : ' '
    };

    if (nivelMaturidadeAction == 'U')
       nivelMaturidade.Id = nivelMaturidadeScope.Id;    

    return nivelMaturidade;
}