whatsgoodAdminModule.controller("ListEventController", function ($scope, $location, eventRepository) {
    eventRepository.query(function(events) {
        $scope.events = events;
    });

    $scope.newEventForm = function () {
        $location.path("/Admin/Events/Create");
    };

    $scope.edit = function(id) {
        $location.path("/Admin/Events/Edit/" + id);
    };
    
    $scope.delete = function (id, index) {
        eventRepository.delete({ id: id }, function () {
            $scope.events.splice(index, 1);
            toastr.success("Evento removido com sucesso.");
        }, function (data) {
            toastr.error("Ocorreu um erro ao tentar remover o evento.");
        });
    };
})