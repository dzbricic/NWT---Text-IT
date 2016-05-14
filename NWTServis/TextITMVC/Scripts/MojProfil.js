var app = angular.module('app');

app.controller('MojProfil', ["$scope", "$http", function ($scope, $http) {
    $scope.mojProfil = function (k) {
        $scope.korisnik = {
            id: sessionStorage.getItem("ID"),
            ime: sessionStorage.getItem("ime"),
            prezime: sessionStorage.getItem("prezime"),
            korisnickoIme: sessionStorage.getItem("korisnickoIme"),
            email: sessionStorage.getItem("email"),
            tipKorisnika: sessionStorage.getItem("tipKorisnika"),
            potvrda: sessionStorage.getItem("potvrda"),
            sifra: sessionStorage.getItem("sifra")
        }
    }

    $scope.updateKorisnik = function (k) {
        $scope.korisnik = {
            id: $scope.korisnik.id,
            ime: $scope.korisnik.ime,
            prezime: $scope.korisnik.prezime,
            korisnickoIme: $scope.korisnik.korisnickoIme,
            email: $scope.korisnik.email,
            tipKorisnika: $scope.korisnik.tipKorisnika,
            sifra: $scope.korisnik.sifra,
            potvrda: $scope.korisnik.potvrda
           
        }
        $http.put("http://localhost:3106/api/Korisnik/" + $scope.korisnik.id, $scope.korisnik).success(function (response) {
            alert("OK");
            window.location = "http://localhost:36729/Korisnik/Index";
        }).error(function (data, status) {
            alert("Izmjena nije uspjela. Molimo pokusajte ponovo.");
        });
    }




}]);