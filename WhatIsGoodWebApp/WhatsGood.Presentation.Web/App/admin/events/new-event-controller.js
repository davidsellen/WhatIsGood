'use strict';

whatsgoodAdminModule.controller("NewEventController", function ($scope, $routeParams, $location, eventRepository, establishmentRepository, artistRepository) {

    $scope.artists = artistRepository.query();
    $scope.establishments = establishmentRepository.query();

    if ($routeParams.id) {

        $.when($scope.artists.$promise, $scope.establishments.$promise).done(function () {
            eventRepository.get({ id: $routeParams.id }).$promise.then(function (eventFound) {
                $scope.currentEvent = eventFound;               
            }, function (error) {
                toastr.error('Ocorreu um erro ao carregar os dados do evento ' + $routeParams.id);
                $scope.loadingArtists = false;
            });
        });


    } else {
        $scope.currentEvent = {
            eventId: 0,
            description: '',
            artistId: 0,
            establishmentId: 0,
            eventPrice: 0,
            startDate: null,
            endDate: null
        };
    }


    // saving a new event
    $scope.createEvent = function () {

        $scope.currentEvent.startDate = $('#startDateTimepicker').data("DateTimePicker").getDate();
        $scope.currentEvent.endDate = $('#endDateTimepicker').data("DateTimePicker").getDate();

        var promise;
        var message;
        if ($scope.currentEvent.eventId && $scope.currentEvent.eventId != 0) {
            promise = eventRepository.update($scope.currentEvent.id, $scope.currentEvent).$promise;
            message = "Evento atualizado com sucesso";
        } else {
            promise = eventRepository.save($scope.currentEvent).$promise;
            message = "Evento cadastrado com sucesso";
        }


        promise.then(function (value) {
            toastr.success(message);
            $location.path("/Admin/Events");
        }, function (error) {
            toastr.error('Ocorreu um erro ao salvar o evento: '  + error.data.exceptionMessage);
        });
    };

    $scope.cancel = function () {
        $location.path("/Admin/Events");
    };
})