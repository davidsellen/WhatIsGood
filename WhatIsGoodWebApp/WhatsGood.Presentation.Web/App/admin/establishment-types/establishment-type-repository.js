'use strict';

whatsgoodAdminModule.factory('establishmentTypeRepository', function ($resource) {
    return $resource(
        '/api/EstablishmentTypes/:id',
        { id: '@id' },
        { update: { method: 'PUT' } }
    );
})