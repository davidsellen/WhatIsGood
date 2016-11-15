'use strict';


whatsgoodAdminModule.controller('HeaderCtrl', ['$scope', '$location', '$route', 'breadcrumbs', 
  function ($scope, $location, $route, breadcrumbs, cfpLoadingBar) {
      $scope.location = $location;
      $scope.breadcrumbs = breadcrumbs;
      
      $scope.isNavbarActive = function (navBarPath) {
          return navBarPath === breadcrumbs.getFirst().name;
      };

      $scope.start = function () {
          cfpLoadingBar.start();
      };

      $scope.complete = function() {
          cfpLoadingBar.complete();
      };

  }]);