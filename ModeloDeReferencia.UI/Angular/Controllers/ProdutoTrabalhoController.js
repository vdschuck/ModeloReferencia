app.controller('ProdutoTrabalhoController', ["$scope", "$filter", "$timeout", "ngDialog", "Url", "ProdutoTrabalhoService", function ($scope, $filter, $timeout, ngDialog, Url, ProdutoTrabalhoService) {

    $scope.produtoTrabalhoList = [];

    /* -- GET ALL -- */
    $scope.GetAll = function (callbackFunction) {
        var response = ProdutoTrabalhoService.getAll();
        response.then(function (data) {
            $scope.produtoTrabalhoList = angular.copy(data.listProdutoTrabalho);

            if (callbackFunction) {
                callbackFunction();
            }

        }, function (error) {
        });
    };

    /* -- OPEN MODAL -- */
    $scope.Open = function (action, produtoTrabalho) {
        $scope.action = action;

        if (action === 'U') {
            $scope.produtoTrabalho = angular.copy(produtoTrabalho);
        } else {
            $scope.produtoTrabalho = {};
        }

        $scope.SaveCallback = function (produtoTrabalho) {
            $scope.msg = 'Registro <b> ' + produtoTrabalho.Nome + ' </b> ' + (action === 'I' ? ' incluído' : ' atualizado') + ' com sucesso.';

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
            template: 'Angular/Views/ProdutoTrabalho/ModalEdit.html',
            controller: 'ProdutoTrabalhoController',
            scope: $scope
        });
    };

    /* ---------------------------- INSIDE MODAL ---------------------------- */ 

    /* -- RESET FORM -- */
    $scope.Reset = function (formProdutoTrabalho) {
        $timeout(function () {
            formProdutoTrabalho.$setPristine();
            safeApply($scope, function () {
                formProdutoTrabalho = {};
                $scope.produtoTrabalho = {};
            });
        }, 0);
    };

    $scope.clikEvent = false;

    /* -- SAVE -- */
    $scope.Save = function (action, formProdutoTrabalho) {
        if (formProdutoTrabalho.$valid) {

            $scope.GetAll(function () {
                var listLenght = $scope.produtoTrabalhoList.length;
                var exist = false;

                if (action === 'I') {
                    for (var i = 0; i < listLenght; i++) {
                        if ($scope.produtoTrabalhoList[i].Nome === $scope.produtoTrabalho.Nome) {
                            exist = true;
                            break;
                        }
                    }
                }

                if (!exist) {
                    if (!$scope.clikEvent) {
                        $scope.clikEvent = true;

                        var data = PrepareData(action, $scope.produtoTrabalho);
                        var retorno = null;

                        if (action === 'U')
                            retorno = ProdutoTrabalhoService.update(data);
                        else
                            retorno = ProdutoTrabalhoService.insert(data);

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
    $scope.Delete = function (produtoTrabalho) {
        $scope.msg = 'A informação será excluída. Deseja prosseguir?';

        $scope.callbackConfirmation = function () {

            var retorno = ProdutoTrabalhoService.delete(produtoTrabalho);

            retorno.then(function (objReturn) {

                ngDialog.closeAll();

                $scope.msg = 'Registro <b>' + produtoTrabalho.Nome + ' </b> excluído com sucesso.';

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
            controller: 'ProdutoTrabalhoController',
            scope: $scope
        });
    };

}]);


/* -- PREPARE DATA -- */
function PrepareData(action, data) {
    var produtoTrabalho = {
        Nome: data.Nome,
        Template: data.Template       
    };

    if (action === 'U') {
        produtoTrabalho.Id = data.Id;
    }

    return produtoTrabalho;
}