var app = angular.module('app');

app.controller('TekstAdd', ["$scope", "$http", function ($scope, $http) {

    $scope.addTekst = function (k) {
        $scope.tekst = {
            id: $scope.tekst.id,
            naslov: $scope.tekst.naslov,
            sadrzaj: $scope.tekst.sadrzaj,
            link: $scope.tekst.link,
            like: $scope.tekst.like,
            datumObjave: new Date(),
            korisnikID: sessionStorage.getItem("ID")
        }
        $http.post("http://textit.azurewebsites.net/api/Tekst/", $scope.tekst).success(function (response) {
            window.location = "http://knjizevnikutak.azurewebsites.net/Tekst/Index";
        }).error(function (data, status) {
            alert("Izmjena nije uspjela. Molimo pokusajte ponovo.");
        });
    }




}]);