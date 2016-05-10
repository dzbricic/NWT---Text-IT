var app = angular.module('app');
app.controller('Logout', ["$scope", function ($scope) {
    $scope.logout = function () {
        sessionStorage.removeItem("ID");
        sessionStorage.removeItem("ime");
        sessionStorage.removeItem("prezime");
        sessionStorage.removeItem("korisnickoIme");
        sessionStorage.removeItem("sifra");
        sessionStorage.removeItem("tipKorisnika");
        window.location = "http://localhost:36729/Home/Index";
    }
}]);