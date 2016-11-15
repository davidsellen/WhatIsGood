whatsgoodAdminModule.controller("ListArtistController", function ($scope, $location, artistRepository) {

    artistRepository.query(function (result) {
        $scope.artists = result;
    });

    $scope.create = function () {
        $location.path("/Admin/Artists/Create");
    };

    $scope.edit = function(id) {
        $location.path("/Admin/Artists/Edit/" + id);
    };
    
    $scope.delete = function (id, index) {
        artistRepository.delete({ id: id }, function () {
            $scope.artists.splice(index, 1);
            toastr.success("Artista removido com sucesso.");
        }, function (data) {
            toastr.error("Ocorreu um erro ao tentar remover o artista.");
        });
    };
})