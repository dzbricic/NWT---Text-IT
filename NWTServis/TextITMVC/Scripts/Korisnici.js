var app = angular.module('app');

app.controller('Korisnik', ["$scope", "$http", function ($scope, $http) {
    $scope.korisnici = []
    $scope.getKorisnik = function () {
        //$http.get("http://textit.azurewebsites.net/api/Korisnik", $scope.korisnici).success(function (data, status) {
        $http.get("http://localhost:3106/api/Korisnik", $scope.korisnici).success(function (data, status) {
            $scope.korisnici = data;

        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }



    $scope.deleteKorisnik = function (k) {
        //$http.delete("http://textit.azurewebsites.net/api/Korisnik/" + k.korisnikID).success(function (data, status) {
        $http.delete("http://localhost:3106/api/Korisnik/" + k.korisnikID).success(function (data, status) {
            alert("Uspješno ste obrisali korisnika!");
        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }
    $scope.editKorisnik = function (k)
    {
        window.location = "http://localhost:36729/Korisnik/Edit/" + k.korisnikID, k;
        $scope.ime = k.ime;
       // $location.path('/employee-details/' + employee.EmployeeNumber);
    }

}]);
