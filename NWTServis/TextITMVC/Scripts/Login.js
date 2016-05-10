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
                alert("valja");
               
                //$scope.myData = response.data;
                sessionStorage.setItem("username", response.Username);
                sessionStorage.setItem("password", response.Password);
                //$cookie.put('username', data.Username);
                //$cookie.put('password', data.Password);
                 window.location = "http://localhost:36729/Home/Index";
            }).error(function (data) {
                alert("ne valja");
            });
        }

    
    //}
}]);