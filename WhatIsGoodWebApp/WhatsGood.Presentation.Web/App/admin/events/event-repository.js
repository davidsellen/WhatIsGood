'use strict';

whatsgoodAdminModule.factory('eventRepository', function ($resource) {
    return $resource(
        '/api/Events/:id',
        { id: '@id' },
        { update: { method: 'PUT' } }
    );
})