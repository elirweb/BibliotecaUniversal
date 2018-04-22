
biblioteca.controller('authctrl', ['$scope', 'authService', function ($scope, authService) {
    $scope.Logar = function () {
        authService.Authenticar($scope.Login, $scope.Senha)
            .then(function (response) {
                angular.forEach(response.data, function (value, key) {
                    if (value.token_type == "error") { alert(value.access_token); }
                    else { localStorage.setItem('token', value.access_token); location.href = "../Home/Index"; }
                })
                document.getElementById("btnbotao").innerHTML = "Acessar";
            })
    }
    $scope.RecuperarSenha = function () {
        authService.Recuperar()
        .then(function (response) {
            alert(response);
        })
    }

    $scope.ProcessarBotao = function (idbotao, texto) {
        document.getElementById(idbotao).innerHTML = texto;
    }
    
}]);