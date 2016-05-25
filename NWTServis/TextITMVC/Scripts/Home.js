var app = angular.module('app');

app.controller('Tekst', ["$scope", "$http", function ($scope, $http) {
    $scope.tekstovi = []
    $scope.getTekstovi= function () {
        $http.get("http://textit.azurewebsites.net/api/Tekst", $scope.korisnici).success(function (data, status) {
            $scope.tekstovi = data;
        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }

}]);
