'use strict';

whatsgoodAdminModule.controller("SaveEstablishmentTypeController", function ($scope, $routeParams, $location, establishmentTypeRepository) {

    $scope.currentEstablishmentType = null;
    
    if ($routeParams.id) {
        establishmentTypeRepository.get({ id: $routeParams.id }).$promise.then(function (result) {
            $scope.currentEstablishmentType = result;
        }, function (error) {
            toastr.error('Ocorreu um erro ao carregar os dados do Tpo de Estabelecimento ' + $routeParams.id);
            $scope.loadingArtists = false;
        });
    } else {
        $scope.currentEstablishmentType = {
            id: 0,
            name: ''
        };
    }

    $scope.save = function () {
        var promise;
        var message;
        if ($scope.currentEstablishmentType.id && $scope.currentEstablishmentType.id != 0) {
            promise = establishmentTypeRepository.update($scope.currentEstablishmentType).$promise;
            message = "Tipo de Estabelecimento atualizado com sucesso.";
        } else {
            promise = establishmentTypeRepository.save($scope.currentEstablishmentType).$promise;
            message = "Tipo de Estabelecimento cadastrado com sucesso.";
        }

        promise.then(function (value) {
            toastr.success(message);
            $location.path("/Admin/EstablishmentTypes");
        }, function (error) {
            toastr.error('Ocorreu um erro ao salvar o tipo de Estabelecimento.' + error.data.exceptionMessage);
        });
    };

    $scope.cancel = function () {
        $location.path("/Admin/EstablishmentTypes");
    };

});

