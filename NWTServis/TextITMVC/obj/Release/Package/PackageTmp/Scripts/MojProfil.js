var app = angular.module('app');

app.controller('MojProfil', ["$scope", "$http", function ($scope, $http) {
    $scope.mojProfil = function (k) {
        $scope.korisnik = {
            ime: '',
            prezime: '',
            korisnickoIme: '',
            email: '',
            tipKorisnika: '',
            potvrda: ''
        }
        $http.get("http://textit.azurewebsites.net/api/Korisnik/" + sessionStorage.getItem("ID")).success(function (response) {
            var arr = $.map(response, function (el) { return el });
            $scope.korisnik.id = arr[0];
            $scope.korisnik.ime = arr[1];
            $scope.korisnik.prezime = arr[2];
            $scope.korisnik.korisnickoIme = arr[3];
            $scope.korisnik.sifra = arr[4];
            $scope.korisnik.email = arr[5];
            $scope.korisnik.tipKorisnika = arr[6];
            $scope.korisnik.potvrda = arr[7];
        }).error(function (data, status) {
            alert("Neuspjesno!");
        });
       
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
            potvrda: sessionStorage.getItem("potvrda")
           
        }
        $http.put("http://textit.azurewebsites.net/api/Korisnik/" + $scope.korisnik.id, $scope.korisnik).success(function (response) {
            alert("OK");
            window.location = "http://knjizevnikutak.azurewebsites.net/Korisnik/Index";
        }).error(function (data, status) {
            alert("Izmjena nije uspjela. Molimo pokusajte ponovo.");
        });
    }




}]);