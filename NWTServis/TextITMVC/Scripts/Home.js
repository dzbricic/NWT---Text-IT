var app = angular.module('app');

app.controller('Tekst', ["$scope", "$http", function ($scope, $http) {
    $scope.tekstovi = []
   
    $scope.currentPage = 1;
    $scope.pageSize = 4;
    $scope.itemsPerPage = 4;

    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };

    $scope.pageChanged = function () {
        $log.log('Page changed to: ' + $scope.currentPage);
    };

    
    $scope.getTekstovi= function () {
        $http.get("http://textit.azurewebsites.net/api/Tekst", $scope.korisnici).success(function (data, status) {
            $scope.tekstovi = data;
            $scope.totalItems = data.length;
        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }
    
   

}]);

