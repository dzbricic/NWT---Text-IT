var app = angular.module('app');

app.controller('Komentari', ["$scope", "$http", function ($scope, $http) {
    $scope.komentari = []
    $scope.getKomentar = function () {
        $http.get("http://localhost:3106/api/komentar", $scope.komentari).success(function (data, status) {
            $scope.komentari = data;

        }).error(function (data, status) {
            alert("Neuspjesno!");
        });
    }

}]);
