'use strict';

var whatsgoodAdminModule = angular.module("whatsgoodAdminModule",
    ['ngRoute',
     'ngResource',
     'ui.bootstrap',
     'ng-breadcrumbs',
     'services.breadcrumbs',
    'chieffancypants.loadingBar'])

    .config(function ($routeProvider, $locationProvider) {

        $routeProvider.when('/Admin',
            { templateUrl: '/App/admin/home/index.html', label: 'Home', controller: 'HomeController' });

        $routeProvider.when('/Admin/Events',
            { templateUrl: '/App/admin/events/list-event.html', controller: 'ListEventController' });
        $routeProvider.when('/Admin/Events/Create',
            { templateUrl: '/App/admin/events/new-event.html', controller: 'NewEventController' });
        $routeProvider.when('/Admin/Events/Edit/:id',
            { templateUrl: '/App/admin/events/new-event.html', controller: 'NewEventController' });

        $routeProvider.when('/Admin/Genres',
            { templateUrl: '/App/admin/genres/list-genre.html', label: 'Gêneros', controller: 'ListGenreController' });
        $routeProvider.when('/Admin/Genres/Create',
            { templateUrl: '/App/admin/genres/save-genre.html', controller: 'SaveGenreController' });
        $routeProvider.when('/Admin/Genres/Edit/:id',
            { templateUrl: '/App/admin/genres/save-genre.html', controller: 'SaveGenreController' });

        $routeProvider.when('/Admin/Establishments',
            { templateUrl: '/App/admin/establishments/list-establishment.html', controller: 'ListEstablishmentController' });
        $routeProvider.when('/Admin/Establishments/Create',
            { templateUrl: '/App/admin/establishments/save-establishment.html', controller: 'SaveEstablishmentController' });
        $routeProvider.when('/Admin/Establishments/Edit/:id',
            { templateUrl: '/App/admin/establishments/save-establishment.html', controller: 'SaveEstablishmentController' });

        $routeProvider.when('/Admin/EstablishmentTypes',
         { templateUrl: '/App/admin/establishment-Types/list-establishment-type.html', controller: 'ListEstablishmentTypeController' });
        $routeProvider.when('/Admin/EstablishmentTypes/Create',
            { templateUrl: '/App/admin/establishment-types/save-establishment-type.html', controller: 'SaveEstablishmentTypeController' });
        $routeProvider.when('/Admin/EstablishmentTypes/Edit/:id',
            { templateUrl: '/App/admin/establishment-types/save-establishment-type.html', controller: 'SaveEstablishmentTypeController' });


        $routeProvider.when('/Admin/Artists',
          { templateUrl: '/App/admin/artists/list-artist.html', controller: 'ListArtistController' });
        $routeProvider.when('/Admin/Artists/Create',
            { templateUrl: '/App/admin/artists/save-artist.html', controller: 'SaveArtistController' });
        $routeProvider.when('/Admin/Artists/Edit/:id',
            { templateUrl: '/App/admin/artists/save-artist.html', controller: 'SaveArtistController' });


        $locationProvider.html5Mode(true);

    });