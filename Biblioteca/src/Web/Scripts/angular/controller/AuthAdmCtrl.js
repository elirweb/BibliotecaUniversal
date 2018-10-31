biblioteca.controller('authctrladm', ['$scope', 'authServiceadm', '$window', function ($scope, authServiceadm, $window) {
    $scope.LogarAdm = function () {
       
        authServiceadm.Authenticar($scope.Usuario, $scope.Senha)
            .then(function (response) {
                angular.forEach(response.data, function (value, key) {
                    if (value.token_type === "error") { $scope.MsgRetorno = value.access_token; }
                    else {
                        localStorage.setItem('token', value.access_token); localStorage.setItem('modulo', "Administrador");
                       
                        location.href = "../Biblioteca/Index";
                        
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
            $scope.LogarAdm();
        }
    }

    $scope.Logout = function () {
        localStorage.removeItem('token');
        localStorage.clear();
        $window.location.href = "http://localhost:4372";
    };

    $scope.RegistrarAdm = function () {
        var form = new FormData();
        form.append('Nome', $scope.Nome);
        form.append('Login', $scope.Login);
        form.append('Senha', $scope.Senha);
        form.append('Email', $scope.Email);

        
        authServiceadm.RegistrarAdm(form).
        then(function (response) {
            $scope.Msgerro = response;
        }).catch(function (response) {
            $scope.Msgerro = response;
            })

    };

}]);