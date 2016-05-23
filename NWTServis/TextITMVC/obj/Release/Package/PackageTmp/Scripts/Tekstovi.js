var app = angular.module('app');

app.controller('Tekstovi', ["$scope", "$http", function ($scope, $http) {
    $scope.tekstovi = []
    $scope.getTekst = function () {
        $http.get("http://textit.azurewebsites.net/api/Tekst", $scope.tekstovi).success(function (data, status) {
            $scope.tekstovi = data;

        }).error(function (data, status) {
            alert("Neuspjesno!");
        });
    }



    $scope.deleteTekst = function (k) {
        $http.delete("http://textit.azurewebsites.net/api/Tekst/" + k.tekstID).success(function (data, status) {
            alert("Obrisan tekst!");
        }).error(function (data, status) {
            alert("Neuspjesno!");
        });
    }

    $scope.editTekst = function (k) {
        window.location = "http://knjizevnikutak.azurewebsites.net/Tekst/Edit/" + k.tekstID, k;
        $scope.sadrzaj = k.sadrzaj;
    }

}]);
