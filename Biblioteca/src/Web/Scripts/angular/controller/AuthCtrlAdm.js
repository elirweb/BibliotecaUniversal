biblioteca.controller('authctrl', ['$scope', 'authServiceadm', function ($scope, authService) {
    $scope.Logar = function () {

        authService.Authenticar($scope.Login, $scope.Senha)
            .then(function (response) {
                angular.forEach(response.data, function (value, key) {
                    if (value.token_type === "error") { alert(value.access_token); }
                    else { localStorage.setItem('token', value.access_token); location.href = "../Biblioteca/Index"; }
                })
                document.getElementById("btnbotao").innerHTML = "Acessar";
            })
    }


    $scope.ProcessarBotao = function (idbotao, texto) {
        document.getElementById(idbotao).innerHTML = texto;
    }

}]);