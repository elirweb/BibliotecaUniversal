biblioteca.controller('authctrladm', ['$scope', 'authServiceadm', '$window', function ($scope, authServiceadm, $window) {
    $scope.LogarAdm = function () {
       
        authServiceadm.Authenticar($scope.Usuario, $scope.Senha)
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

    $scope.Logout = function () {
        localStorage.removeItem('token');
        localStorage.clear();
        $window.location.href = "http://localhost:4372";
    };

}]);