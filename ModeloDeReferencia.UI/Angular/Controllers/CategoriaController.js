app.controller('CategoriaController', ["$scope", "$filter", "$timeout", "ngDialog", "Url", "CategoriaService", function ($scope, $filter, $timeout, ngDialog, Url, CategoriaService) {

    $scope.categoriaList = [];

    /* -- GET ALL -- */
    $scope.getAll = function (callbackFunction) {
        var response = CategoriaService.getAll();
        response.then(function (data) {
            $scope.categoriaList = angular.copy(data.categoriaList);

            if (callbackFunction) {
                callbackFunction();
            }

        }, function (error) {
        });
    };

    /* -- OPEN MODAL -- */
    $scope.openCategoria = function (categoriaAction, categoria) {
        $scope.categoriaAction = categoriaAction;

        if (categoriaAction == 'U') {
            $scope.categoria = angular.copy(categoria);
        } else {
            $scope.categoria = {};
        }

        $scope.saveCallback = function (categoria) {
            $scope.msg = 'Registro <b> ' + categoria.Nome + ' </b> ' + (categoriaAction == 'I' ? ' incluído' : ' atualizado') + ' com sucesso.';

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
            template: 'Angular/Views/Categoria/ModalEdit.html',
            controller: 'CategoriaController',
            scope: $scope
        });
    };

    /* ---------------------------- INSIDE MODAL ---------------------------- */
    $scope.reset = function (formCategoria) {
        $timeout(function () {
            formCategoria.$setPristine();
            safeApply($scope, function () {
                formCategoria = {};
                $scope.categoria = {};
            });
        }, 0);
    };

    $scope.clikEventCategoria = false;

    /* -- SAVE CATEGORIA -- */
    $scope.saveCategoria = function (categoriaAction, formCategoria) {
        if (formCategoria.$valid) {

            $scope.getAll(function () {
                var listLenght = $scope.categoriaList.length;
                var exist = false;

                for (var i = 0; i < listLenght; i++) {
                    if ($scope.categoriaList[i].Nome == $scope.categoria.Nome) {
                        exist = true;
                        break;
                    }
                }
                if (!exist) {
                    if (!$scope.clikEventCategoria) {
                        $scope.clikEventCategoria = true;

                        var categoria = prepareCategoria(categoriaAction, $scope.categoria);
                        var retorno;

                        if (categoriaAction == 'U')
                            retorno = CategoriaService.update(categoria);
                        else
                            retorno = CategoriaService.insert(categoria);

                        retorno.then(function (objReturn) {
                            $scope.saveCallback(categoria);

                        }, function (objError) {
                            $scope.categoriaAction = false;
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

    /* -- DELETE CATEGORIA -- */
    $scope.deleteCategoria = function (categoria) {
        $scope.msg = 'A informação será excluída. Deseja prosseguir?';

        $scope.callbackConfirmation = function () {

            var retorno = CategoriaService.delete(categoria);

            retorno.then(function (objReturn) {

                ngDialog.closeAll();

                $scope.msg = 'Registro <b>' + categoria.Nome + ' </b> excluído com sucesso.';

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
            controller: 'CategoriaController',
            scope: $scope
        });
    }
    
}]);


/* -- PREPARE CATEGORIA -- */
function prepareCategoria(categoriaAction, categoriaScope) {
    var categoria = {
        Nome: categoriaScope.Nome  
    };

    if (categoriaAction == 'U') {
        categoria.Id = categoriaScope.Id;
    }

    return categoria;
}