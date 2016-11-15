'use strict';

whatsgoodAdminModule.controller("ListGenreController", function ($scope, $location, genreRepository) {
    genreRepository.query(function (genres) {
        $scope.genres = genres;
    });

    $scope.newGenre = function () {
        $location.path("/Admin/Genres/Create");
    };

    $scope.edit = function (id) {
        $location.path("/Admin/Genres/Edit/" + id);
    };

    $scope.delete = function (id, index) {
        genreRepository.delete({ id: id }, function () {
            $scope.genres.splice(index, 1);
            toastr.success("Gênero removido com sucesso.");
        }, function (data) {
            toastr.error("Ocorreu um erro ao tentar remover o gênero.");
        });

    };
})