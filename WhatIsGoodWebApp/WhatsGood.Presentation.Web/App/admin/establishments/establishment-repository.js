'use strict';

whatsgoodAdminModule.factory('establishmentRepository', function ($resource) {
    return $resource(
        '/api/Establishments/:id',
        { id: '@id' },
        { update: { method: 'PUT' } }
    );
})