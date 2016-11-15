'use strict';

whatsgoodAdminModule.factory('artistRepository', function($resource) {
    return $resource(
        '/api/Artists/:id',
        { id: '@id' },
        { update: { method: 'PUT' } }
    );
});