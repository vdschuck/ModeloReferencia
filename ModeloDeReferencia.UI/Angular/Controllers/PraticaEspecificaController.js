app.controller('PraticaEspecificaController', ["$scope", "$filter", "$timeout", "ngDialog", "Url", "PraticaEspecificaService", function ($scope, $filter, $timeout, ngDialog, Url, PraticaEspecificaService) {

    $scope.praticaEspecificaList = [];

    /* -- GET ALL -- */
    $scope.GetAll = function (callbackFunction) {
        var response = PraticaEspecificaService.getAll();
        response.then(function (data) {
            $scope.praticaEspecificaList = angular.copy(data.listPraticaEspecifica);

            if (callbackFunction) {
                callbackFunction();
            }

        }, function (error) {
        });
    };

    /* -- OPEN MODAL -- */
    $scope.Open = function (action, praticaEspecifica) {
        $scope.action = action;

        if (action === 'U') {
            $scope.praticaEspecifica = angular.copy(praticaEspecifica);
        } else {
            $scope.praticaEspecifica = {};
        }

        $scope.SaveCallback = function (praticaEspecifica) {
            $scope.msg = 'Registro <b> ' + praticaEspecifica.Nome + ' </b> ' + (action === 'I' ? ' incluído' : ' atualizado') + ' com sucesso.';

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
            template: 'Angular/Views/PraticaEspecifica/ModalEdit.html',
            controller: 'PraticaEspecificaController',
            scope: $scope
        });
    };

    /* ---------------------------- INSIDE MODAL ---------------------------- */

    /* -- GET ALL SMALL TYPES -- */
    $scope.GetAllSmallTypes = function () {
        var response = PraticaEspecificaService.getAllSmallTypes();
        response.then(function (data) {
            $scope.metaEspecificaList = data.listMetaEspecifica;            

            // Selected item when editing
            if ($scope.praticaEspecifica.Id) {
                $scope.praticaEspecifica.MetaEspecifica = $filter('filter')($scope.metaEspecificaList, { Id: $scope.praticaEspecifica.MetaEspecificaId })[0];
            }

        }, function (error) {
        });
    };

    /* -- RESET FORM -- */
    $scope.Reset = function (formPraticaEspecifica) {
        $timeout(function () {
            formPraticaEspecifica.$setPristine();
            safeApply($scope, function () {
                formPraticaEspecifica = {};
                $scope.praticaEspecifica = {};
            });
        }, 0);
    };

    $scope.clikEvent = false;

    /* -- SAVE -- */
    $scope.Save = function (action, formPraticaEspecifica) {
        if (formPraticaEspecifica.$valid) {

            $scope.GetAll(function () {
                var listLenght = $scope.praticaEspecificaList === undefined ? 0 : $scope.praticaEspecificaList.length;
                var exist = false;

                if (action === 'I') {
                    for (var i = 0; i < listLenght; i++) {
                        if ($scope.praticaEspecificaList[i].Nome === $scope.praticaEspecifica.Nome) {
                            exist = true;
                            break;
                        }
                    }
                }

                if (!exist) {
                    if (!$scope.clikEvent) {
                        $scope.clikEvent = true;

                        var data = PreparePraticaEspecifica(action, $scope.praticaEspecifica);
                        var retorno = null;

                        if (action === 'U')
                            retorno = PraticaEspecificaService.update(data);
                        else
                            retorno = PraticaEspecificaService.insert(data);

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
    $scope.Delete = function (praticaEspecifica) {
        $scope.msg = 'A informação será excluída. Deseja prosseguir?';

        $scope.callbackConfirmation = function () {

            var retorno = PraticaEspecificaService.delete(praticaEspecifica);

            retorno.then(function (objReturn) {

                ngDialog.closeAll();

                $scope.msg = 'Registro <b>' + praticaEspecifica.Nome + ' </b> excluído com sucesso.';

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
            controller: 'PraticaEspecificaController',
            scope: $scope
        });
    };

}]);


/* -- PREPARE DATA -- */
function PreparePraticaEspecifica(action, data) {
    var praticaEspecifica = {
        Nome: data.Nome,
        Sigla: data.Sigla,
        Descricao: data.Descricao,
        MetaEspecificaId: data.MetaEspecifica.Id        
    };

    if (action === 'U') {
        praticaEspecifica.Id = data.Id;
    }

    return praticaEspecifica;
}