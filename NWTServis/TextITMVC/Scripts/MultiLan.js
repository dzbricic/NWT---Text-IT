var app = angular.module('app', ['pascalprecht.translate', 'ngRoute', 'ui.bootstrap']);
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
        KOMENTARI: "Comments",
        MOJPROFIL: "My profile",
        STATISTIKA: "Statistics",
        PRVA: "First",
        PRETHODNA: "Previous",
        SLJEDECA: "Next",
        ZADNJA: "Last",
        DOBRODOSLI: "Welcome to our little sweety online library. Feel free to open your mind and soul and share your thoughts with us!"
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
        KOMENTARI: "Komentari",
        MOJPROFIL: "Moj profil",
        STATISTIKA: "Statistika",
        PRVA: "Prva",
        PRETHODNA: "Prethodna",
        SLJEDECA: "Sljedeća",
        ZADNJA: "Zadnja",
        DOBRODOSLI: "Dobrodošli u naš mali književni kutak. Osjećajte se slobodnim da ostavite svoja djela!"
    });
    $translateProvider.preferredLanguage('bs');
}])

.filter('startFrom', function () {
    return function (data, start) {
        return data.slice(start);
    }
});