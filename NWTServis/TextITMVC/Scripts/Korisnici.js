var app = angular.module('app');

app.controller('Korisnik', ["$scope", "$http", function ($scope, $http) {
    $scope.korisnici = []
    $scope.getKorisnik = function () {
        $http.get("http://textit.azurewebsites.net/api/Korisnik", $scope.korisnici).success(function (data, status) {
            $scope.korisnici = data;

        }).error(function (data, status) {
            alert("Neuspjesno!");
        });
    }



    $scope.deleteKorisnik = function (k) {
        $http.delete("http://textit.azurewebsites.net/api/Korisnik/" + k.korisnikID).success(function (data, status) {
            alert("Banovan korisnik!");
        }).error(function (data, status) {
            alert("Neuspjesno!");
        });
    }
    $scope.editKorisnik = function (k)
    {
        window.location = "http://localhost:36729/Korisnik/Edit/" + k.korisnikID, k;
        $scope.ime = k.ime;
       // $location.path('/employee-details/' + employee.EmployeeNumber);
    }

}]);
