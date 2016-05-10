var app = angular.module('app');
app.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/', {
                templateUrl: '/Home/Index.cshtml',
                controller: 'HomeController'
            }).
            when('/korisnik', {
                templateUrl: '/Korisnik/Index.cshtml',
                controller: 'KorisnikController'
            }).
            otherwise({
                redirectTo: '/'
            })
    }
]);

app.controller("singlePage", ["$scope", function ($scope) {
    
}]);