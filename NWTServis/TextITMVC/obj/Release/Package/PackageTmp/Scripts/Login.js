var app = angular.module('app');

app.controller('Login', ["$scope", "$http", function ($scope, $http) {
    $scope.LoginPodaci = {
        Username: '',
        Password: ''
    };
        $scope.Login = function () {
            $http.post("http://textit.azurewebsites.net/api/Login", $scope.LoginPodaci).success(function (response) {
               
                var arr = $.map(response, function (el) { return el });
                sessionStorage.setItem("ID", arr[0]);
                sessionStorage.setItem("ime", arr[1]);
                sessionStorage.setItem("prezime", arr[2]);
                sessionStorage.setItem("korisnickoIme", arr[3]);
                sessionStorage.setItem("sifra", arr[4]);
                sessionStorage.setItem("email", arr[5]);
                sessionStorage.setItem("tipKorisnika", arr[6]);
                sessionStorage.setItem("potvrda", arr[7]);
                
                if (arr[7] == true)
                {
                    alert("Uspjesno ste se logovali!");
                    window.location = "http://knjizevnikutak.azurewebsites.net/Home/Index";
                }
                else
                {
                    alert("Da biste se logirali morate potvrditi Vasu registraciju!");
                }
               
            }).error(function (data) {
                alert("Login neuspjesan!");
            });
        }
         
    //}
}]);



