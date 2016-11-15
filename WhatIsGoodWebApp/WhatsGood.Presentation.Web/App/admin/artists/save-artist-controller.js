'use strict';

whatsgoodAdminModule.controller("SaveArtistController",
    function ($scope, $http, $routeParams, $location, artistRepository, genreRepository) {

        $scope.currentArtist = null;

        $scope.genres = genreRepository.query();
        

        if ($routeParams.id) {

            $.when($scope.genres.$promise).done(function () {
                artistRepository.get({ id: $routeParams.id }).$promise.then(function(result) {
                    $scope.currentArtist = result;

                    if (result != null) {
                        var selectedGenre = result.genre;
                        if (selectedGenre != null && selectedGenre.id) {
                            for (var i = 0; i < $scope.genres.length; i++) {
                                var genre = $scope.genres[i];
                                if (selectedGenre.id == genre.id) {
                                    $scope.currentArtist.genre = genre;
                                    break;
                                }
                            }
                        }
                    }
                }, function(error) {
                    toastr.error('Ocorreu um erro ao carregar os dados do Artista ' + $routeParams.id);
                });
            });
            
        } else {
            $scope.currentArtist = {
                id: 0,
                name: '',
                countryName: '',
                photoUrl: '',
                webSiteUrl: '',
                email: '',
                genre: {
                    id: 0,
                    description: ''
                }
            };
        }

        $scope.isUnchanged = function (artist) {
            return angular.equals(artist, $scope.currentArtist);
        };
        
        $scope.save = function () {
            var promise;
            var message;
            if ($scope.currentArtist.id && $scope.currentArtist.id != 0) {
                promise = artistRepository.update($scope.currentArtist).$promise;
                message = "Artista atualizado com sucesso.";
            } else {
                promise = artistRepository.save($scope.currentArtist).$promise;
                message = "Artista cadastrado com sucesso.";
            }

            promise.then(function (value) {
                toastr.success(message);
                $location.path("/Admin/Artists");
            }, function (error) {
                toastr.error('Ocorreu um erro ao salvar o Artista.');
            });
        };

        $scope.cancel = function () {
            $location.path("/Admin/Artists");
        };


    });

