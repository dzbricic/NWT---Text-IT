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
        VISE: "More"
    })
    $translateProvider.translations('bs', {
        KORISNICI: 'Korisnici',
        TEKSTOVI: 'Tekstovi',
        VISE: "Više"
    });
    $translateProvider.preferredLanguage('bs');
}])