
biblioteca.controller('authctrl', ['$scope', 'authService', '$window', '$rootScope', function ($scope, authService, $window, $rootScope) {
    $scope.Logar = function () {
       
        authService.Authenticar($scope.Login, $scope.Senha)
            .then(function (response) {
                
                angular.forEach(response.data, function (value, key) {
                    if (value.token_type === "error") { $scope.MsgRetorno = value.access_token; }
                    else {
                        localStorage.setItem('token', value.access_token); localStorage.setItem('modulo', "Usuario");
                        location.href = "../Usuario/Index";
                    }
                })
                document.getElementById("btnbotao").innerHTML = "Acessar";
            }).catch(function (response) {
                $scope.MsgRetorno = "Ops! ocorreu erro no app";
                document.getElementById('btnbotao').innerHTML = "Acessar";
            })
    }
    $scope.ProcessarBotao = function (idbotao, texto) {

        if (document.getElementById("Login").value == "" || document.getElementById("Senha").value == "")
            $scope.MsgRetorno = "Ops! campo em branco";
        else {
            $scope.MsgRetorno = "";
            document.getElementById(idbotao).innerHTML = texto;
            $scope.Logar();
        } 

        
    }
    $scope.Logout = function () {
            localStorage.removeItem('token');
            localStorage.clear();
            $window.location.href = "http://localhost:4372";
    };
    
}]);