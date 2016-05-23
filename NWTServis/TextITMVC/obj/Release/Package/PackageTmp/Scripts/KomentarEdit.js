var app = angular.module('app');

app.controller('KomentarEdit', ["$scope", "$http", function ($scope, $http) {
    $scope.editKomentar = function (k) {
        $scope.komentar = {
            sadrzaj: '',
            datumObjave: '',
            korisnikID: ''
        }
        $http.get("http://textit.azurewebsites.net/api/Komentar/" + k).success(function (response) {
            var arr = $.map(response, function (el) { return el });
            $scope.komentar.id = arr[0];
            $scope.komentar.sadrzaj = arr[1];
            $scope.komentar.datumObjave = arr[2];
            $scope.komentar.korisnikID = arr[3];
        }).error(function (data, status) {
            alert("Neuspjesno!");
        });
    }

    $scope.updateKomentar= function (k) {
        $scope.komentar = {
            id: $scope.komentar.id,
            sadrzaj: $scope.komentar.sadrzaj,
            datumObjave: new Date(),
            korisnikID: sessionStorage.getItem("ID")
        }
        $http.put("http://textit.azurewebsites.net/api/komentar/" + $scope.komentar.id, $scope.komentar).success(function (response) {
            alert("OK");
            window.location = "http://knjizevnikutak.azurewebsites.net/Komentar/Index";
        }).error(function (data, status) {
            alert("Izmjena nije uspjela. Molimo pokusajte ponovo.");
        });
    }




}]);