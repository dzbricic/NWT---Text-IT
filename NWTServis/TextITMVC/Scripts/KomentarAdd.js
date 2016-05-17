﻿var app = angular.module('app');

app.controller('KomentarAdd', ["$scope", "$http", function ($scope, $http) {

    $scope.addKomentar = function (k) {
        $scope.komentar = {
            id: $scope.komentar.id,
            sadrzaj: $scope.komentar.sadrzaj,
            datumObjave: new Date(),
            korisnikID: sessionStorage.getItem("ID")
        }
        $http.post("http://localhost:3106/api/komentar/", $scope.komentar).success(function (response) {
            window.location = "http://localhost:36729/Home/Index";
        }).error(function (data, status) {
            alert("Dodavanje nije uspjelo. Molimo pokusajte ponovo.");
        });
    }

}]);