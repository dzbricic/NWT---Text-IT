var app = angular.module('app');

app.controller('Login', ["$scope", "$http", function ($scope, $http) {
    $scope.LoginPodaci = {
        Username: '',
        Password: ''
    };
    //$http.defaults.headers.put = {
    //    'Access-Control-Allow-Origin': '*',
    //    'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS',
    //    'Access-Control-Allow-Headers': 'Content-Type, X-Requested-With'
    //};
    //$http.defaults.useXDomain = true;

    //$scope.throughdata = function () {

    //    delete $http.defaults.headers.common['X-Requested-With'];
        $scope.Login = function () {

            $http.post("http://localhost:3106/api/Login", $scope.LoginPodaci).success(function (response) {
               
                var arr = $.map(response, function (el) { return el });
                sessionStorage.setItem("ID", arr[0]);
                sessionStorage.setItem("ime", arr[1]);
                sessionStorage.setItem("prezime", arr[2]);
                sessionStorage.setItem("korisnickoIme", arr[3]);
                sessionStorage.setItem("sifra", arr[4]);
                sessionStorage.setItem("tipKorisnika", arr[6]);
                alert("Uspjesno ste se logovali!");
                window.location = "http://localhost:36729/Home/Index";
            }).error(function (data) {
                alert("Login neuspjesan!");
            });
        }
        
    
    //}
}]);