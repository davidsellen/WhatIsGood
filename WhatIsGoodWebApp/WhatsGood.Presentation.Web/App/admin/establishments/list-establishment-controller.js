whatsgoodAdminModule.controller("ListEstablishmentController", function ($scope, $location, establishmentRepository) {

    establishmentRepository.query(function (result) {
        $scope.establishments = result;
    });

    $scope.create = function () {
        $location.path("/Admin/Establishments/Create");
    };

    $scope.edit = function(id) {
        $location.path("/Admin/Establishments/Edit/" + id);
    };
    
    $scope.delete = function (id, index) {
        establishmentRepository.delete({ id: id }, function () {
            $scope.establishments.splice(index, 1);
            toastr.success("Estabelecimento removido com sucesso.");
        }, function (data) {
            toastr.error("Ocorreu um erro ao tentar remover o estabelecimento.");
        });
    };
})