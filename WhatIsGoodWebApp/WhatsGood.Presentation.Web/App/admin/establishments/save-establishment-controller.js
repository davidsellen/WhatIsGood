'use strict';

whatsgoodAdminModule.controller("SaveEstablishmentController",
    function ($scope, $http, $routeParams, $location, establishmentRepository, establishmentTypeRepository) {

        $scope.currentEstablishment = null;
        $scope.addressSearchText = '';
        $scope.establishmentTypes = establishmentTypeRepository.query();

        if ($routeParams.id) {
            $.when($scope.establishmentTypes.$promise).done(function () {
                establishmentRepository.get({ id: $routeParams.id }).$promise.then(function (result) {
                    $scope.currentEstablishment = result;
                    var latitude = $scope.currentEstablishment.address.latitude;
                    var longitude = $scope.currentEstablishment.address.longitude;
                    if (latitude && longitude) {
                        $scope.loadMap(latitude, longitude);
                    }
                }, function (error) {
                    toastr.error('Ocorreu um erro ao carregar os dados do Estabelecimento ' + $routeParams.id);
                    toastr.error(error.data.exceptionMessage);
                    $scope.loadingArtists = false;
                });
            });
        } else {
            $scope.currentEstablishment = {
                establishmentId: 0,
                name: '',
                capacity: 0,
                imageUrl: '',
                webSiteUrl: '',
                ownParking: false,
                acessibily: false,
                establishmentTypeId: 0,
                address: {
                    addressId: 0,
                    streetName: '',
                    complement: '',
                    number: '',
                    postalCode: '',
                    city: '',
                    province: '',
                    district: '',
                    country: '',
                    latitude: 0,
                    longitude: 0
                },
                parking: {
                    parkingId: 0,
                    price: 0,
                    capacity: 0
                },
                contact: {
                    contactId: 0,
                    firstName: '',
                    LastName: '',
                    emailAddress: '',
                    phoneNumber: '',
                    birthDate: null,
                }
            };
        }

        // saving a new event
        $scope.save = function () {

            if ($scope.currentEstablishment.address == null) {
                toastr.error('Para cadastrar um estabelecimento é necessário informar um endereço.');
                return;
            }

            var promise;
            var message;
            if ($scope.currentEstablishment.establishmentId && $scope.currentEstablishment.establishmentId != 0) {
                promise = establishmentRepository.update($scope.currentEstablishment).$promise;
                message = "Estabelecimento atualizado com sucesso.";
            } else {
                promise = establishmentRepository.save($scope.currentEstablishment).$promise;
                message = "Estabelecimento cadastrado com sucesso.";
            }

            promise.then(function (value) {
                toastr.success(message);
                $location.path("/Admin/Establishments");
            }, function (error) {
                toastr.error('Ocorreu um erro ao salvar o Estabelecimento.' + error.data.exceptionMessage);
            });
        };

        $scope.cancel = function () {
            $location.path("/Admin/Establishments");
        };

        $scope.searchingAddress = true;

        $scope.searchAddress = function () {


            $.ajax({
                url: "http://dev.virtualearth.net/REST/v1/Locations",
                dataType: "jsonp",
                data: {
                    key: "AnaQFblp6sa5YrFrwtYSsjdWHyVl6PRj0o9DzALqZFXLaO5JJEfYA-TdUZGMBLRj",
                    q: $scope.addressSearchText
                },
                jsonp: "jsonp",
                success: function (data) {
                    var result = data.resourceSets[0];
                    if (result) {
                        if (result.estimatedTotal == 0) {

                            toastr.alert("Localidade não encontrada.");
                        }
                        else {
                            $scope.$apply(function () {
                                var item = result.resources[0];

                                if (item == null) return;

                                if ($scope.currentEstablishment.address == null || $scope.currentEstablishment.address == undefined) {
                                    $scope.currentEstablishment.address = {
                                        addressId: 0,
                                        streetName: '',
                                        complement: '',
                                        number: '',
                                        postalCode: '',
                                        city: '',
                                        province: '',
                                        district: '',
                                        country: '',
                                        latitude: 0,
                                        longitude: 0
                                    };
                                }
                                $scope.currentEstablishment.address.streetName = item.address.addressLine;
                                $scope.currentEstablishment.address.postalCode = item.address.postalCode;
                                $scope.currentEstablishment.address.city = item.address.locality;
                                $scope.currentEstablishment.address.province = item.address.adminDistrict;
                                $scope.currentEstablishment.address.country = item.address.countryRegion;
                                $scope.currentEstablishment.address.latitude = item.point.coordinates[0];
                                $scope.currentEstablishment.address.longitude = item.point.coordinates[1];
                                $scope.loadMap($scope.currentEstablishment.address.latitude, $scope.currentEstablishment.address.longitude);
                            });
                        }
                    }
                },
                error: function (data) {
                    toastr.error('Ocorreu um erro ao pesquisar o endereço informado.');
                    $scope.searchingAddress = true;
                }
            });


        };

        $scope.loadMap = function (latitude, longitude) {
            $scope.searchingAddress = false;
            var mapOptions = {
                credentials: "AnaQFblp6sa5YrFrwtYSsjdWHyVl6PRj0o9DzALqZFXLaO5JJEfYA-TdUZGMBLRj",
                center: new Microsoft.Maps.Location(latitude, longitude),
                mapTypeId: Microsoft.Maps.MapTypeId.road,
                zoom: 11,
                showScalebar: false,
                enableSearchLogo: false
            };

            var map = new Microsoft.Maps.Map(document.getElementById("SDKmap"), mapOptions);
            // Define the pushpin location
            var loc = new Microsoft.Maps.Location(latitude, longitude);
            // Add a pin to the map
            var pin = new Microsoft.Maps.Pushpin(loc, { draggable: true });
            Microsoft.Maps.Events.addHandler(pin, 'dragend', $scope.changedLocation);
            map.entities.push(pin);
            // Center the map on the location
            map.setView({ center: loc, zoom: 11 });

        };

        $scope.changedLocation = function (e) {
            var loc = e.entity.getLocation();

            $scope.$apply(function () {
                $scope.currentEstablishment.address.latitude = loc.latitude;
                $scope.currentEstablishment.address.longitude = loc.longitude;
            });

        };
    });


