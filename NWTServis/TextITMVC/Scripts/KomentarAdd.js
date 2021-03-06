﻿var app = angular.module('app');

app.controller('KomentarAdd', ["$scope", "$http", function ($scope, $http) {

    $scope.addKomentar = function (k) {
        //alert(sessionStorage.getItem("tekstID"));
        $scope.komentar = {
            id: $scope.komentar.id,
            sadrzaj: $scope.komentar.sadrzaj,
            datumObjave: new Date(),
            korisnikOstavioID: sessionStorage.getItem("ID"),
            tekstID: sessionStorage.getItem("tekstID")
        }
        $http.post("http://localhost:3106/api/komentar/", $scope.komentar).success(function (response) {
            window.location = "http://localhost:36729/Home/Index";
        }).error(function (data, status) {
            alert("Dodavanje nije uspjelo. Molimo pokušajte ponovo.");
        });
    }

}]);