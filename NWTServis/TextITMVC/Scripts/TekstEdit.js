var app = angular.module('app');

app.controller('TekstEdit', ["$scope", "$http", function ($scope, $http) {
    $scope.editTekst = function (t) {
        $scope.tekst = {
            naslov: '',
            sadrzaj: '',
            link: '',
            like: '',
            datumObjave: '',
            korisnikID: ''
        }
        $http.get("http://textit.azurewebsites.net/api/Tekst/" + t).success(function (response) {
            var arr = $.map(response, function (el) { return el });
            $scope.tekst.id = arr[0];
            $scope.tekst.naslov = arr[1];
            $scope.tekst.sadrzaj = arr[2];
            $scope.tekst.link = arr[3];
            $scope.tekst.like = arr[4];
            $scope.tekst.datumObjave = arr[5];
            $scope.tekst.korisnikID = arr[9];
        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }

    $scope.updateTekst = function (k) {
        $scope.tekst = {
            id: $scope.tekst.id,
            naslov: $scope.tekst.naslov,
            sadrzaj: $scope.tekst.sadrzaj,
            link: $scope.tekst.link,
            like: $scope.tekst.like,
            datumObjave: new Date(),
            korisnikID: sessionStorage.getItem("ID")
        }
        $http.post("http://textit.azurewebsites.net/api/Tekst/" + $scope.tekst.id, $scope.tekst).success(function (response) {
            alert("Uspješno ste izvršili izmjenu!");
            window.location = "http://localhost:36729/Tekst/Index";
        }).error(function (data, status) {
            alert("Izmjena nije uspjela. Molimo pokušajte ponovo.");
        });
    }




}]);