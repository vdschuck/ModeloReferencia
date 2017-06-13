app.controller('NivelCapacidadeController', ["$scope", "$filter", "$timeout", "ngDialog", "Url", "NivelCapacidadeService", function ($scope, $filter, $timeout, ngDialog, Url, NivelCapacidadeService) {

    $scope.nivelCapacidadeList = [];

    /* -- GET ALL -- */
    $scope.GetAll = function (callbackFunction) {
        var response = NivelCapacidadeService.getAll();
        response.then(function (data) {
            $scope.nivelCapacidadeList = angular.copy(data.listNivelCapacidade);

            if (callbackFunction) {
                callbackFunction();
            }

        }, function (error) {
        });
    };

    /* -- OPEN MODAL -- */
    $scope.Open = function (action, nivelCapacidade) {
        $scope.action = action;

        if (action === 'U') {
            $scope.nivelCapacidade = angular.copy(nivelCapacidade);
        } else {
            $scope.nivelCapacidade = {};
        }

        $scope.SaveCallback = function (nivelCapacidade) {
            $scope.msg = 'Registro <b> ' + nivelCapacidade.Nome + ' </b> ' + (action === 'I' ? ' incluído' : ' atualizado') + ' com sucesso.';

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
            template: 'Angular/Views/NivelCapacidade/ModalEdit.html',
            controller: 'NivelCapacidadeController',
            scope: $scope
        });
    };

    /* ---------------------------- INSIDE MODAL ---------------------------- */
       

    /* -- RESET FORM -- */
    $scope.Reset = function (formNivelCapacidade) {
        $timeout(function () {
            formNivelCapacidade.$setPristine();
            safeApply($scope, function () {
                formNivelCapacidade = {};
                $scope.nivelCapacidade = {};
            });
        }, 0);
    };

    $scope.clikEvent = false;

    /* -- SAVE -- */
    $scope.Save = function (action, formNivelCapacidade) {
        if (formNivelCapacidade.$valid) {

            $scope.GetAll(function () {
                var listLenght = $scope.nivelCapacidadeList === undefined ? 0 : $scope.nivelCapacidadeList.length;
                var exist = false;

                if (action === 'I') {
                    for (var i = 0; i < listLenght; i++) {
                        if ($scope.nivelCapacidadeList[i].Nome === $scope.nivelCapacidade.Nome) {
                            exist = true;
                            break;
                        }
                    }
                }

                if (!exist) {
                    if (!$scope.clikEvent) {
                        $scope.clikEvent = true;

                        var data = PrepareNivelCapacidade(action, $scope.nivelCapacidade);
                        var retorno = null;

                        if (action === 'U')
                            retorno = NivelCapacidadeService.update(data);
                        else
                            retorno = NivelCapacidadeService.insert(data);

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
    $scope.Delete = function (nivelCapacidade) {
        $scope.msg = 'A informação será excluída. Deseja prosseguir?';

        $scope.callbackConfirmation = function () {

            var retorno = NivelCapacidadeService.delete(nivelCapacidade);

            retorno.then(function (objReturn) {

                ngDialog.closeAll();

                $scope.msg = 'Registro <b>' + nivelCapacidade.Nome + ' </b> excluído com sucesso.';

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
            controller: 'NivelCapacidadeController',
            scope: $scope
        });
    };

}]);


/* -- PREPARE DATA -- */
function PrepareNivelCapacidade(action, data) {
    var nivelCapacidade = {
        Nome: data.Nome,
        Sigla: data.Sigla,
        Descricao: data.Descricao       
    };

    if (action === 'U') {
        nivelCapacidade.Id = data.Id;
    }

    return nivelCapacidade;
}