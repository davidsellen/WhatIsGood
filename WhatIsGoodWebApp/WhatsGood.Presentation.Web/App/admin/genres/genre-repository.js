'use strict';

whatsgoodAdminModule.factory('genreRepository', function ($resource) {
    var apiUrl = '/api/Genres/:id';

    return $resource(
        apiUrl,
        { id: '@id' },
        { update: { method: 'PUT' } }
    );

})