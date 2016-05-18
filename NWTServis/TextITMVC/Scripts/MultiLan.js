var app = angular.module('app', ['pascalprecht.translate','ngRoute']);
app.controller("appctrl", ["$scope", "$translate", function ($scope, $translate) {
    $scope.selectedLanguage = $translate.preferredLanguage;
    $scope.switchLanguage = function (lang) {
        $translate.use(lang);
    }
}]);
app.config(["$translateProvider", function ($translateProvider) {
    $translateProvider.translations('en', {
        KORISNICI: 'Users',
        TEKSTOVI: 'Texts',
        VISE: "More",
        POCETNA: "Home",
        NOVIRACUN: "Create a new account.",
        REGISTRACIJA: "Registration",
        REGISTRUJSE: "Register",
        PRIJAVA: "Log in",
        LOGIN: "Log in with your account.",
        REGSE: "Register if you don't have account.",
        ODJAVA: "Log out",
        KOMENTARI: "Comments"
    })
    $translateProvider.translations('bs', {
        KORISNICI: 'Korisnici',
        TEKSTOVI: 'Tekstovi',
        VISE: "Više",
        POCETNA: "Početna",
        NOVIRACUN: "Kreiraj novi račun.",
        REGISTRACIJA: "Registracija",
        REGISTRUJSE: "Registruj se",
        PRIJAVA: "Prijava",
        LOGIN: "Logirajte se sa postojećim računom.",
        REGSE: "Registrujte se ukoliko nemate račun.",
        ODJAVA: "Odjava",
        KOMENTARI: "Komentari"
    });
    $translateProvider.preferredLanguage('bs');
}])