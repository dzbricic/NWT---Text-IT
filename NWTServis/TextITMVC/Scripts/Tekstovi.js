var app = angular.module('app');

app.controller('Tekstovi', ["$scope", "$http", function ($scope, $http) {
    $scope.tekstovi = []
    $scope.getTekst = function () {
        $http.get("http://localhost:3106/api/Tekst", $scope.tekstovi).success(function (data, status) {
            $scope.tekstovi = data;

        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }



    $scope.deleteTekst = function (k) {
        $http.delete("http://localhost:3106/api/Tekst/" + k.tekstID).success(function (data, status) {
            alert("Uspješno ste obrisali tekst!");
        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }

    $scope.editTekst = function (k) {
        window.location = "http://localhost:36729/Tekst/Edit/" + k.tekstID, k;
        $scope.sadrzaj = k.sadrzaj;
    }

}]);
