var app = angular.module('app');

app.controller('KomentarAdd', ["$scope", "$http", function ($scope, $http) {

    $scope.addKomentar = function (k) {
        $scope.komentar = {
            id: $scope.komentar.id,
            sadrzaj: $scope.komentar.sadrzaj,
            datumObjave: new Date(),
            korisnikID: sessionStorage.getItem("ID")
        }
        $http.post("http://textit.azurewebsites.net/api/komentar/", $scope.komentar).success(function (response) {
            window.location = "http://knjizevnikutak.azurewebsites.net/Home/Index";
        }).error(function (data, status) {
            alert("Dodavanje nije uspjelo. Molimo pokusajte ponovo.");
        });
    }

}]);