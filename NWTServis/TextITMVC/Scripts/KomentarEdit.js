var app = angular.module('app');

app.controller('KomentarEdit', ["$scope", "$http", function ($scope, $http) {
    $scope.editKomentar = function (k) {
        $scope.komentar = {
            sadrzaj: '',
            datumObjave: '',
            korisnikID: ''
        }
        $http.get("http://localhost:3106/api/Komentar/" + k).success(function (response) {
            var arr = $.map(response, function (el) { return el });
            $scope.komentar.id = arr[0];
            $scope.komentar.sadrzaj = arr[1];
            $scope.komentar.datumObjave = arr[2];
            $scope.komentar.korisnikID = arr[3];
        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }

    $scope.updateKomentar= function (k) {
        $scope.komentar = {
            id: $scope.komentar.id,
            sadrzaj: $scope.komentar.sadrzaj,
            datumObjave: new Date(),
            korisnikID: sessionStorage.getItem("ID")
        }
        $http.post("http://localhost:3106/api/Komentar/" + $scope.komentar.id, $scope.komentar).success(function (response) {
            alert("Uspješno ste izvršili izmjenu!");
            window.location = "http://localhost:36729/komentar/Index";
        }).error(function (data, status) {
            alert("Izmjena nije uspjela. Molimo pokušajte ponovo.");
        });
    }




}]);