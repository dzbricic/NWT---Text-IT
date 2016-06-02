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
        $http.get("http://localhost:3106/api/Korisnik/" + sessionStorage.getItem("ID")).success(function (response) {
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
            alert("Neuspješno!");
        });
       
    }

    $scope.updateKorisnikMojProfil = function (k) {
        $scope.korisnik = {
            korisnikID: sessionStorage.getItem("ID"),
            ime: $scope.korisnik.ime,
            prezime: $scope.korisnik.prezime,
            korisnickoIme: $scope.korisnik.korisnickoIme,
            email: $scope.korisnik.email,
            tipKorisnika: $scope.korisnik.tipKorisnika,
            sifra: $scope.korisnik.sifra,
            potvrda: sessionStorage.getItem("potvrda"),
            salt: sessionStorage.getItem("salt")
                
           
        }
        $http.put("http://localhost:3106/api/Korisnik/" + $scope.korisnik.korisnikID, $scope.korisnik).success(function (response) {
            alert("Uspjesno ste izmijenili svoje podatke!");
            window.location = "http://localhost:36729/Korisnik/Index";
        }).error(function (data, status) {
            alert("Izmjena nije uspjela. Molimo pokusajte ponovo.");
        });
    }




}]);