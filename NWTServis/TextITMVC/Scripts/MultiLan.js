var app = angular.module('app', "pascalprecht.translate");
app.controller("appctrl", ["$scope", "$translate", function ($scope, $translate) {
    $scope.selectedLanguage = $translate.prefferedLanguage;
    $scope.switchLanguage = function (lang) {
        $translate.use(lang);
    }
}]);
app.config(["$translateProvider", function ($translateProvider) {
    $translateProvider.useStaticFilesLoader({
        prefix: 'Languages/lang-',
        suffix: '.json'
    });
    $translateProvider.prefferedLanguage('bs');
}])