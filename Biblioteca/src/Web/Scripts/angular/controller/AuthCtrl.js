
biblioteca.controller('authctrl', ['$scope', 'authService', function ($scope, authService) {
    $scope.Logar = function () {
        authService.Authenticar()
            .then(function (response) {
                alert(response.access_token); // obtendo o token falta testar
            })
    }
    $scope.RecuperarSenha = function () {
        authService.Recuperar()
        .then(function (response) {
            alert(response);
        })
    }
    
}]);