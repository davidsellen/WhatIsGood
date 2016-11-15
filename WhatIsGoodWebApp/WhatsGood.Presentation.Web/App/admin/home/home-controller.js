'use strict';

whatsgoodAdminModule.controller("HomeController", ['$scope', 'breadcrumbs', function($scope, breadcrumbs) {
    $scope.breadcrumbs = breadcrumbs;
    $scope.breadcrumbs.options = {};
    $scope.title = 'Bem vindo!';
    $scope.summary = "This is the Home page.";
}]);