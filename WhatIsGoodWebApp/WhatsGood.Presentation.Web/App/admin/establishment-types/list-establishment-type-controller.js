whatsgoodAdminModule.controller("ListEstablishmentTypeController", function ($scope, $location, establishmentTypeRepository) {

    establishmentTypeRepository.query(function (result) {
        $scope.establishmentTypes = result;
    });

    $scope.create = function () {
        $location.path("/Admin/EstablishmentTypes/Create");
    };

    $scope.edit = function(id) {
        $location.path("/Admin/EstablishmentTypes/Edit/" + id);
    };
    
    $scope.delete = function (id, index) {
        establishmentTypeRepository.delete({ id: id }, function () {
            $scope.establishmentTypes.splice(index, 1);
            toastr.success("Tipo de Estabelecimento removido com sucesso.");
        }, function (data) {
            toastr.error("Ocorreu um erro ao tentar remover o tipo de estabelecimento.");
        });
    };
})