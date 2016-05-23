var app = angular.module('app');

app.controller('Komentari', ["$scope", "$http", function ($scope, $http) {
    $scope.komentari = []
    $scope.getKomentar = function () {
        $http.get("http://textit.azurewebsites.net/api/komentar", $scope.komentari).success(function (data, status) {
            $scope.komentari = data;

        }).error(function (data, status) {
            alert("Neuspjesno!");
        });
    }

    $scope.editKomentar = function (k) {
        window.location = "http://localhost:36729/Komentar/Edit/" + k.komentarID, k;
        $scope.sadrzaj = k.sadrzaj;
    }

    $scope.deleteKomentar = function (k) {
        $http.delete("http://textit.azurewebsites.net/api/komentar/" + k.komentarID).success(function (data, status) {
            alert("Komentar obrisan!");
        }).error(function (data, status) {
            alert("Neuspjesno!");
        });
    }

}]);
