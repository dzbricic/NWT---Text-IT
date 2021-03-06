﻿var app = angular.module('app');

app.controller('KorisnikEdit', ["$scope", "$http", function ($scope, $http) {
    $scope.editKorisnik = function (k) {
        $scope.korisnik = {
            ime: '',
            prezime: '',
            korisnickoIme:'',
            email:'',
            tipKorisnika: '',
            potvrda: ''
        }
        $http.get("http://localhost:3106/api/Korisnik/" + k).success(function (response) {
            var arr = $.map(response, function (el) { return el });
            $scope.korisnik.korisnikID = arr[0];
            $scope.korisnik.ime = arr[1];
            $scope.korisnik.prezime = arr[2];
            $scope.korisnik.korisnickoIme = arr[3];
            $scope.korisnik.sifra = arr[4];
            $scope.korisnik.email = arr[5];
            $scope.korisnik.tipKorisnika = arr[6];
            $scope.korisnik.potvrda = arr[7];
            $scope.korisnik.banovan = arr[8];
            $scope.korisnik.salt = arr[9];
        }).error(function (data, status) {
            alert("Neuspješno!");
        });

        $scope.tipKorisnika = ["admin", "User"];
    }

    $scope.updateKorisnik = function (k) {
        
        $scope.korisnik = {
            korisnikID: $scope.korisnik.korisnikID, 
            ime: $scope.korisnik.ime,
            prezime: $scope.korisnik.prezime,
            korisnickoIme: $scope.korisnik.korisnickoIme,
            email: $scope.korisnik.email,
            
            tipKorisnika: $scope.korisnik.tipKorisnika,
            sifra: $scope.korisnik.sifra,
            potvrda: $scope.korisnik.potvrda,
            banovan: $scope.korisnik.banovan,
            salt: $scope.korisnik.salt
        }
        $http.put("http://localhost:3106/api/Korisnik/" + $scope.korisnik.korisnikID, $scope.korisnik).success(function (response) {
            alert("Uspješno ste izvršili izmjenu!");
            window.location = "http://localhost:36729/Korisnik/Index";
        }).error(function (data, status) {
            alert("Izmjena nije uspjela. Molimo pokušajte ponovo.");
        });
    }


   

}]);