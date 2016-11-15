'use strict';

whatsgoodAdminModule.controller("SaveGenreController", function ($scope, $routeParams, $location, genreRepository) {

    if ($routeParams.id) {
        
            genreRepository.get({ id: $routeParams.id }).$promise.then(function (genreFound) {
                $scope.currentGenre = genreFound;
            }, function (error) {
                toastr.error('Ocorreu um erro ao carregar os dados do evento ' + $routeParams.id);
                $scope.loadingArtists = false;
            });

    } else {
        $scope.currentGenre = {
            id: 0,
            description: ''
        };
    }

    $scope.save = function () {
        var promise;
        var message;
        if ($scope.currentGenre.id && $scope.currentGenre.id != 0) {
            promise = genreRepository.update($scope.currentGenre).$promise;
            message = "Gênero atualizado com sucesso";
        } else {
            promise = genreRepository.save($scope.currentGenre).$promise;
            message = "Gênero cadastrado com sucesso";
        }

        promise.then(function (value) {
            toastr.success(message);
            $location.path("/Admin/Genres");
        }, function (error) {
            toastr.error('Ocorreu um erro ao salvar o gênero.');
        });
    };

    $scope.cancel = function () {
        $location.path("/Admin/Genres");
    };
})