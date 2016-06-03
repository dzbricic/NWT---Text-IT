﻿var app = angular.module('app');

app.controller('Komentari', ["$scope", "$http", function ($scope, $http) {
    $scope.komentari = []
    $scope.getKomentar = function () {
        $http.get("http://localhost:3106/api/komentar", $scope.komentari).success(function (data, status) {
            var arr = $.map(data, function (el) { return el });
            for (i = 0; i < arr.length; i++) {
                if (arr[i].tekstID == sessionStorage.getItem("tekstID")) {
                    $scope.komentari.push(arr[i]);
                }
            }
            //$scope.komentari = data;
            
        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }
    $scope.getKomentari = function () {
        $http.get("http://localhost:3106/api/komentar", $scope.komentari).success(function (data, status) {
            $scope.komentari = data;

        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }

    $scope.editKomentar = function (k) {
        window.location = "http://localhost:36729/Komentar/Edit/" + k.komentarID, k;
        $scope.sadrzaj = k.sadrzaj;
    }

    $scope.deleteKomentar = function (k) {
        $http.delete("http://localhost:3106/api/komentar/" + k.komentarID).success(function (data, status) {
            alert("Uspješno ste obrisali komentar!");
        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }

}]);
