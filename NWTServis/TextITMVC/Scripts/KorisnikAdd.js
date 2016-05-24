var app = angular.module('app');

app.controller('KorisnikAdd', ["$scope", "$http", function ($scope, $http) {
    
    $scope.addKorisnik = function (k) {
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
        $http.post("http://textit.azurewebsites.net/api/Korisnik/", $scope.korisnik).success(function (response) {
            window.location = "http://localhost:36729/Korisnik/Index";
        }).error(function (data, status) {
            alert("Izmjena nije uspjela. Molimo pokusajte ponovo.");
        });
    }




}]);