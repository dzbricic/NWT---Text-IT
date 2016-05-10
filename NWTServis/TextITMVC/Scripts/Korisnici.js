var app = angular.module('app');

app.controller('Korisnik', ["$scope", "$http", function ($scope, $http) {
    $scope.korisnici = []
    $scope.getKorisnik = function () {

        $http.get("http://localhost:3106/api/Korisnik", $scope.korisnici).success(function (data, status) {
            $scope.korisnici = data;

        }).error(function (data, status) {
            alert("Neuspjesno!");
        });
    }


}]);