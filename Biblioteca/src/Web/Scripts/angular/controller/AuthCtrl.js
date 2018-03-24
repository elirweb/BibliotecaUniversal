'use strict'

biblioteca.controller('authctrl', ['authService', '$scope', function ($scope, authService) {
    $scope.Logar = function () {
        authService.Authenticar()
            .then(function (response) {
                alert(response.access_token); // obtendo o token falta testar
            })
    }
}]);