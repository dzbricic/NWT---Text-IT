var app = angular.module('app');

app.controller('Tekst', ["$scope", "$http", function ($scope, $http) {
    $scope.tekstovi = []
    $scope.currentPage = 1;
    $scope.pageSize = 4;
    $scope.itemsPerPage = 4;

    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };

    $scope.pageChanged = function () {
        $log.log('Page changed to: ' + $scope.currentPage);
    };

    
    $scope.getTekstovi= function () {
        $http.get("http://localhost:3106/api/Tekst", $scope.korisnici).success(function (data, status) {
            //$scope.tekstovi = data;
            var arr = $.map(data, function (el) { return el });
           
            for (i = 0; i < arr.length; i++) {
                $scope.brojac = 0;
                $http.get("http://localhost:3106/api/Korisnik/" + arr[i].korisnikID).success(function (response) {
                    var arr2 = $.map(response, function (el) { return el });
                    var arr = $.map(data, function (el) { return el });

                    arr[$scope.brojac].korisnikID = arr2[3];
                    $scope.brojac++;
                    $scope.tekstovi.push(arr[$scope.brojac]);

                }).error(function (data, status) {
                    alert("Neuspješno!");
                });
                $scope.tekstovi.push(arr[i]);
            }


            $scope.totalItems = data.length;
        }).error(function (data, status) {
            alert("Neuspješno!");
        });
    }

    $scope.createKomentar = function (id) {
        sessionStorage.setItem("tekstID", id);
        window.location = "http://localhost:36729/Komentar/Create";
    }
    
   

}]);

